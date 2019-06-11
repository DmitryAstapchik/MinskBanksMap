using DataAccessLayer;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MinskBanksMap
{
    public partial class FormEditDepartment : Form
    {
        FormMap map;
        readonly int depId;
        Department dep;

        public FormEditDepartment(int depId)
        {
            InitializeComponent();
            this.depId = depId;
        }

        // fills the form fields
        private void FormEditDepartment_Load(object sender, EventArgs e)
        {
            map = Owner as FormMap;
            dep = map.db.Departments.Single(d => d.Id == depId);

            textBoxBank.Text = dep.Bank.Name;
            if (dep.ExchangeRates != null)
            {
                textBoxUSDSell.Text = dep.ExchangeRates.USDSell.HasValue ? dep.ExchangeRates.USDSell.Value.ToString("N3") : string.Empty;
                textBoxUSDBuy.Text = dep.ExchangeRates.USDBuy.HasValue ? dep.ExchangeRates.USDBuy.Value.ToString("N3") : string.Empty;
                textBoxEURSell.Text = dep.ExchangeRates.EURSell.HasValue ? dep.ExchangeRates.EURSell.Value.ToString("N3") : string.Empty;
                textBoxEURBuy.Text = dep.ExchangeRates.EURBuy.HasValue ? dep.ExchangeRates.EURBuy.Value.ToString("N3") : string.Empty;
                textBoxRURSell.Text = dep.ExchangeRates.RURSell.HasValue ? dep.ExchangeRates.RURSell.Value.ToString("N3") : string.Empty;
                textBoxRURBuy.Text = dep.ExchangeRates.RURBuy.HasValue ? dep.ExchangeRates.RURBuy.Value.ToString("N3") : string.Empty;
            }
            textBoxLatitude.Text = dep.Latitude.ToString();
            textBoxLongitude.Text = dep.Longitude.ToString();
            textBoxAddress.Text = dep.Address;
        }

        private void ButtonOK_Click(object sender, EventArgs e) 
        {
            // accept department changes
            if (dep.ExchangeRates == null)
            {
                dep.ExchangeRates = new DataAccessLayer.Entities.ExchangeRates();
            }
            dep.ExchangeRates.USDSell = double.TryParse(textBoxUSDSell.Text, out double parsed) ? (double?)parsed : null;
            dep.ExchangeRates.USDBuy = double.TryParse(textBoxUSDBuy.Text, out parsed) ? (double?)parsed : null;
            dep.ExchangeRates.EURSell = double.TryParse(textBoxEURSell.Text, out parsed) ? (double?)parsed : null;
            dep.ExchangeRates.EURBuy = double.TryParse(textBoxEURBuy.Text, out parsed) ? (double?)parsed : null;
            dep.ExchangeRates.RURSell = double.TryParse(textBoxRURSell.Text, out parsed) ? (double?)parsed : null;
            dep.ExchangeRates.RURBuy = double.TryParse(textBoxRURBuy.Text, out parsed) ? (double?)parsed : null;
            dep.Address = textBoxAddress.Text;
            dep.Latitude = Convert.ToDouble(textBoxLatitude.Text);
            dep.Longitude = Convert.ToDouble(textBoxLongitude.Text);
            map.db.SaveChanges();

            // set a new position for the department marker if the department coordinates have been changed
            var marker = map.gMap.Overlays.Single(o => o.Id == dep.Bank.Id.ToString()).Markers.Single(m => m.Tag.ToString() == dep.Id.ToString());
            marker.ToolTipText =  map.CreateToolTipText(marker);
            if (marker.Position != new PointLatLng(dep.Latitude, dep.Longitude))
            {
                marker.Overlay.Markers.Remove(marker);
                GMapMarker newMarker = new GMarkerGoogle(new PointLatLng(dep.Latitude, dep.Longitude), GMarkerGoogleType.green)
                {
                    ToolTipText = marker.ToolTipText,
                    Tag = marker.Tag
                };
                marker.Overlay.Markers.Add(newMarker);
            }

            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
