using DataAccessLayer;
using DataAccessLayer.Entities;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MinskBanksMap
{
    public partial class FormAddDepartment : Form
    {
        FormMap map;

        public FormAddDepartment()
        {
            InitializeComponent();
        }

        // fills the form fields
        private void FormAddDepartment_Load(object sender, EventArgs e)
        {
            map = Owner as FormMap;
            Point point = map.gMap.PointToClient(new Point(Location.X, Location.Y));
            textBoxLatitude.Text = map.gMap.FromLocalToLatLng(point.X, point.Y).Lat.ToString();
            textBoxLongitude.Text = map.gMap.FromLocalToLatLng(point.X, point.Y).Lng.ToString();
            var visibleBankOverlays = map.gMap.Overlays.Take(map.gMap.Overlays.Count - 1).Where(o => o.IsVisibile == true);
            foreach (var overlay in visibleBankOverlays)
            {
                comboBoxBank.Items.Add(map.banks.Single(b => b.Id == int.Parse(overlay.Id)).Name);
            }
            if (comboBoxBank.Items.Count == 1)
            {
                comboBoxBank.SelectedIndex = 0;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxBank.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран банк.", "Выберите банк", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // save new department to DB
            map = Owner as FormMap;
            Department dep = new Department()
            {
                Address = textBoxAddress.Text,
                ExchangeRates = new ExchangeRates()
                {
                    USDSell = double.TryParse(textBoxUSDSell.Text, out double parsed) ? (double?)parsed : null,
                    USDBuy = double.TryParse(textBoxUSDBuy.Text, out parsed) ? (double?)parsed : null,
                    EURSell = double.TryParse(textBoxEURSell.Text, out parsed) ? (double?)parsed : null,
                    EURBuy = double.TryParse(textBoxEURBuy.Text, out parsed) ? (double?)parsed : null,
                    RURSell = double.TryParse(textBoxRURSell.Text, out parsed) ? (double?)parsed : null,
                    RURBuy = double.TryParse(textBoxRURBuy.Text, out parsed) ? (double?)parsed : null,
                    DepId = map.db.Departments.Count() + 1,
                    BankId = map.banks.Single(b => b.Name == comboBoxBank.SelectedItem.ToString()).Id
                },
                Id = map.db.Departments.Count() + 1,
                Latitude = Convert.ToDouble(textBoxLatitude.Text),
                Longitude = Convert.ToDouble(textBoxLongitude.Text)
            };
            map.db.Banks.Single(b => b.Name == comboBoxBank.SelectedItem.ToString()).Departments.Add(dep);
            map.db.SaveChanges();

            // add new marker to bank overlay
            GMapMarker marker = new GMarkerGoogle(new GMap.NET.PointLatLng(Convert.ToDouble(textBoxLatitude.Text), Convert.ToDouble(textBoxLongitude.Text)), GMarkerGoogleType.green)
            {
                Tag = dep.Id
            };
            marker.ToolTipText = map.CreateToolTipText(marker);
            map.gMap.Overlays.Single(o => o.Id == map.db.Banks.Single(b => b.Name == comboBoxBank.SelectedItem.ToString()).Id.ToString()).Markers.Add(marker);

            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
