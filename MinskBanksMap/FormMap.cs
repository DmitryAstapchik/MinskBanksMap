using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using DataAccessLayer.Entities;
using DataAccessLayer;
using System.Reflection;

namespace MinskBanksMap
{
    public partial class FormMap : Form
    {
        public BanksContext db = new BanksContext();
        public List<Bank> banks;
        GMapMarker iAmHere; // marker 'I am here'
        GMapMarker nearest; // marker nearest to 'I am here'
        List<GMapMarker> resultMarkers = new List<GMapMarker>(); // markers showing selected exchange rates

        public FormMap()
        {
            InitializeComponent();
        }

        private void FormMap_Load(object sender, EventArgs e)
        {
            // map display
            gMap.MapProvider = GMapProviders.WikiMapiaMap; // change map provider if the map is not displayed
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMap.SetPositionByKeywords("Minsk, Belarus");
            gMap.DragButton = MouseButtons.Left;
            gMap.ShowCenter = false;
            gMap.IgnoreMarkerOnMouseWheel = true;

            // list of banks with departments and exchange rates
            banks = db.Banks.ToList();

            // add bank overlays with markers and bank menu items
            foreach (var bank in banks)
            {
                GMapOverlay overlay = new GMapOverlay(bank.Id.ToString());
                gMap.Overlays.Add(overlay);
                var menuItem = new ToolStripMenuItem(bank.Name, null, ToolStripMenuItemBank_CheckedChanged)
                {
                    CheckOnClick = true,
                    Tag = bank.Id.ToString()
                };
                ((ToolStripMenuItem)menuStrip.Items[0]).DropDownItems.Add(menuItem);
                foreach (var dep in bank.Departments)
                {
                    GMapMarker marker = new GMarkerGoogle(new PointLatLng(dep.Latitude, dep.Longitude), GMarkerGoogleType.green)
                    {
                        Tag = dep.Id,
                    };
                    marker.ToolTipText = CreateToolTipText(marker);
                    overlay.Markers.Add(marker);
                    overlay.IsVisibile = false;
                }
            }
            gMap.Overlays.Add(new GMapOverlay("I am here"));
            gMap.Overlays.First().IsVisibile = true;
            ((ToolStripMenuItem)((ToolStripMenuItem)menuStrip.Items[0]).DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)menuStrip.Items[0]).DropDownItems.Add(new ToolStripMenuItem("Выбрать все", null, ToolStripMenuItemAllBanks_CheckedChanged));
            ((ToolStripMenuItem)menuStrip.Items[0]).DropDownItems.Add(new ToolStripMenuItem("Убрать все", null, ToolStripMenuItemNoBanks_CheckedChanged));
        }

        // creates tooltip text for the marker
        public string CreateToolTipText(GMapMarker marker)
        {
            var dep = db.Departments.Single(d => d.Id.ToString() == marker.Tag.ToString());
            var format = "{0}\n{1}\nUSD продажа: {2}\nUSD покупка: {3}\nEUR продажа: {4}\nEUR покупка: {5}\nRUR продажа: {6}\nRUR покупка: {7}";
            var empty = "нет данных";
            if (dep.ExchangeRates == null)
            {
                return string.Format(format, dep.Bank.Name, dep.Address, empty, empty, empty, empty, empty, empty);
            }
            else
            {
                return string.Format(format, dep.Bank.Name, dep.Address,
                    dep.ExchangeRates.USDSell.HasValue ? dep.ExchangeRates.USDSell.Value.ToString("F3") : empty,
                    dep.ExchangeRates.USDBuy.HasValue ? dep.ExchangeRates.USDBuy.Value.ToString("F3") : empty,
                    dep.ExchangeRates.EURSell.HasValue ? dep.ExchangeRates.EURSell.Value.ToString("F3") : empty,
                    dep.ExchangeRates.EURBuy.HasValue ? dep.ExchangeRates.EURBuy.Value.ToString("F3") : empty,
                    dep.ExchangeRates.RURSell.HasValue ? dep.ExchangeRates.RURSell.Value.ToString("F3") : empty,
                    dep.ExchangeRates.RURBuy.HasValue ? dep.ExchangeRates.RURBuy.Value.ToString("F3") : empty);
            }
        }

        // show/hide bank overlay
        private void ToolStripMenuItemBank_CheckedChanged(object sender, EventArgs e) 
        {
            gMap.Overlays.Single(o => o.Id == ((ToolStripMenuItem)sender).Tag.ToString()).IsVisibile = ((ToolStripMenuItem)sender).Checked;
        }

        // selects all banks
        private void ToolStripMenuItemAllBanks_CheckedChanged(object sender, EventArgs e) 
        {
            foreach (var overlay in gMap.Overlays)
            {
                overlay.IsVisibile = true;
            }

            var banksMenu = toolStripMenuItemBanksSelection.DropDownItems;
            foreach (ToolStripMenuItem item in banksMenu.OfType<ToolStripMenuItem>().Take(banksMenu.Count - 2))
            {
                item.Checked = true;
            }
        }

        // clears all bank selections
        private void ToolStripMenuItemNoBanks_CheckedChanged(object sender, EventArgs e) 
        {
            foreach (var overlay in gMap.Overlays.Take(gMap.Overlays.Count - 1))
            {
                overlay.IsVisibile = false;
            }

            foreach (ToolStripMenuItem item in toolStripMenuItemBanksSelection.DropDownItems)
            {
                item.Checked = false;
            }
        }

        // zooms and centers in view mode and shows edit form in edit mode
        private void GMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e) 
        {
            if (toolStripMenuItemViewMode.Checked)
            {
                gMap.SetZoomToFitRect(new RectLatLng(item.Position, new SizeLatLng(0.000001, 0.000001)));
            }
            else if (toolStripMenuItemEditMode.Checked)
            {
                var form = new FormEditDepartment((int)item.Tag)
                {
                    Owner = this,
                    StartPosition = FormStartPosition.Manual
                };
                form.Location = new Point(
                    PointToScreen(e.Location).X + form.Width > PointToClient(Location).X + Width ? PointToClient(Location).X + Width - form.Width - 10 : PointToScreen(e.Location).X,
                    PointToScreen(e.Location).Y + form.Height > PointToClient(Location).Y + Height ? PointToClient(Location).Y + Height - form.Height : PointToScreen(e.Location).Y);
                form.ShowDialog();
            }
        }

        // shows departments with selected exchange rate
        void ShowChosenExchangeRates(PropertyInfo currency, MethodInfo minOrMax) 
        {
            var selectedDeps = new List<Department>();
            var visibleBankOverlays = gMap.Overlays.Take(gMap.Overlays.Count - 1).Where(o => o.IsVisibile == true);
            foreach (var overlay in visibleBankOverlays)
            {
                foreach (var bank in banks)
                {
                    if (bank.Id == Convert.ToInt32(overlay.Id))
                    {
                        foreach (var department in bank.Departments)
                        {
                            if (department.ExchangeRates != null)
                            {
                                selectedDeps.Add(department);
                            }
                        }
                    }
                }
            }

            if (selectedDeps.Count != 0)
            {
                var resultRate = (double)minOrMax.MakeGenericMethod(typeof(Department)).Invoke(
                    null, 
                    new object[] 
                    {
                        selectedDeps.Except(selectedDeps.Where(d => currency.GetValue(d.ExchangeRates) == null)),
                        new Func<Department, double>(dep => (double)currency.GetValue(dep.ExchangeRates))
                    });
                var resultDeps = selectedDeps
                    .Except(selectedDeps.Where(d => currency.GetValue(d.ExchangeRates) == null))
                    .Where(d => (double)currency.GetValue(d.ExchangeRates) == resultRate);
                foreach (var marker in resultMarkers)
                {
                    ChangeMarkerColor(marker, GMarkerGoogleType.green);
                }
                resultMarkers.Clear();
                foreach (var dep in resultDeps)
                {
                    foreach (var overlay in visibleBankOverlays)
                    {
                        foreach (var marker in overlay.Markers)
                        {
                            if (marker.Tag.ToString() == dep.Id.ToString())
                            {
                                resultMarkers.Add(marker);
                            }
                        }
                    }
                }
                foreach (var marker in resultMarkers)
                {
                    ChangeMarkerColor(marker, GMarkerGoogleType.yellow);
                }
            }
            else
            {
                MessageBox.Show("На карте нет отделений.", "Невозможное действие", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // changes color of the marker
        private void ChangeMarkerColor(GMapMarker marker, GMarkerGoogleType newColor) 
        {
            if (marker == null)
            {
                return;
            }
            GMapMarker newMarker = new GMarkerGoogle(marker.Position, newColor)
            {
                ToolTipText = marker.ToolTipText,
                Tag = marker.Tag
            };
            var overlay = marker.Overlay;
            overlay.Markers.Remove(overlay.Markers.Single(m => m.Tag == marker.Tag));
            overlay.Markers.Add(newMarker);
        }

        // event handler for 'show exchange rates' menu items
        private void ToolStripMenuItemCurrency_Click(object sender, EventArgs e) 
        {
            var clickedMenuItem = (ToolStripMenuItem)sender;
            var propInfo = typeof(ExchangeRates).GetProperty(clickedMenuItem.Tag.ToString() + clickedMenuItem.OwnerItem.Tag);
            var methodInfo = typeof(Enumerable).GetMethods().Single(m => m.Name == clickedMenuItem.OwnerItem.OwnerItem.Tag.ToString() && m.GetParameters().Length == 2 && m.ReturnType == typeof(double));
            ShowChosenExchangeRates(propInfo, methodInfo);
        }

        // cancels showing departments with selected exchange rates
        private void ToolStripMenuItemCancelRates_Click(object sender, EventArgs e) 
        {
            foreach (var marker in resultMarkers)
            {
                ChangeMarkerColor(marker, GMarkerGoogleType.green);
            }
        }

        // adds 'I am here' marker to the map
        private void ToolStripMenuItemIAmHere_Click(object sender, EventArgs e)
        {
            ChangeMarkerColor(nearest, GMarkerGoogleType.green);

            Point point = gMap.PointToClient(new Point(((ToolStripMenuItem)sender).GetCurrentParent().Location.X, ((ToolStripMenuItem)sender).GetCurrentParent().Location.Y));
            iAmHere = new GMarkerGoogle(new PointLatLng(gMap.FromLocalToLatLng(point.X, point.Y).Lat, gMap.FromLocalToLatLng(point.X, point.Y).Lng), GMarkerGoogleType.orange_dot)
            {
                ToolTipText = "Я здесь"
            };
            gMap.Overlays.Last().Markers.Clear();
            gMap.Overlays.Last().Markers.Add(iAmHere);

            toolStripMenuItemShowNearest.Enabled = true;
            toolStripMenuItemReset.Enabled = true;
        }

        // gives the nearest marker a different color
        private void ToolStripMenuItemShowNearest_Click(object sender, EventArgs e)
        {
            nearest = gMap.Overlays.First(o => o.IsVisibile).Markers.First();
            var minDistance = GetDistance(iAmHere, nearest);
            foreach (var overlay in gMap.Overlays.Take(gMap.Overlays.Count - 1).Where(o => o.IsVisibile == true))
            {
                foreach (var marker in overlay.Markers)
                {
                    var distance = GetDistance(iAmHere, marker);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearest = marker;
                    }
                }
            }

            ChangeMarkerColor(nearest, GMarkerGoogleType.blue);
            iAmHere.ToolTipText = string.Format("Я здесь\nРасстояние до ближайшего: {0:F3} км", minDistance);
        }

        // gets distance between two markers in meters
        private double GetDistance(GMapMarker mrk1, GMapMarker mrk2)
        {
            var lat1 = mrk1.Position.Lat;
            var lat2 = mrk2.Position.Lat;
            var lon1 = mrk1.Position.Lng;
            var lon2 = mrk2.Position.Lng;
            var dLat = (lat2 - lat1) * (Math.PI / 180);
            var dLon = (lon2 - lon1) * (Math.PI / 180);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return 6371 * c;
        }

        // cancels 'I am here' and nearest markers
        private void ToolStripMenuItemReset_Click(object sender, EventArgs e)
        {
            gMap.Overlays.Last().Markers.Clear();
            ChangeMarkerColor(nearest, GMarkerGoogleType.green);
            nearest = null;

            toolStripMenuItemShowNearest.Enabled = false;
            toolStripMenuItemReset.Enabled = false;
        }

        // enters view mode
        private void ToolStripMenuItemViewMode_Click(object sender, EventArgs e)
        {
            toolStripMenuItemViewMode.Checked = true;
            toolStripMenuItemEditMode.Checked = false;
            gMap.ContextMenuStrip = contextMenuStripViewMode;
            toolStripMenuItemShowRates.Enabled = true;
        }

        // enters edit mode
        private void ToolStripMenuItemEditMode_Click(object sender, EventArgs e)
        {
            toolStripMenuItemViewMode.Checked = false;
            toolStripMenuItemEditMode.Checked = true;
            gMap.ContextMenuStrip = contextMenuStripEditMode;
            toolStripMenuItemShowRates.Enabled = false;

            ToolStripMenuItemCancelRates_Click(sender, e);
            ToolStripMenuItemReset_Click(sender, e);
        }

        // shows add department dialog
        private void ToolStripMenuItemAddDepartment_Click(object sender, EventArgs e)
        {
            var form = new FormAddDepartment
            {
                Owner = this,
                StartPosition = FormStartPosition.Manual
            };
            var point = ((ToolStripMenuItem)sender).GetCurrentParent().Location;
            form.Location = new Point(point.X, point.Y + form.Height > PointToClient(Location).Y + Height ? PointToClient(Location).Y + Height - form.Height : point.Y);
            form.ShowDialog();
        }

        // cancels showing departments with selected exchange rates
        private void ToolStripMenuItemBanksSelection_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItemCancelRates_Click(sender, e);
        }
    }
}