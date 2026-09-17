using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helen_Form_Project
{
    public partial class Form1 : Form
    {
        private GeoCoordinateWatcher watcher;

        public Form1()
        {
            InitializeComponent();

            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.MovementThreshold = 5; // metres - fires PositionChanged again once moved this far
            watcher.PositionChanged += Watcher_PositionChanged;
            watcher.StatusChanged += Watcher_StatusChanged;
            watcher.TryStart(false, TimeSpan.FromSeconds(10));
        }

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            lblLocation.Text = $"Lat: {e.Position.Location.Latitude:F6}\nLong: {e.Position.Location.Longitude:F6}";
        }

        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.NoData)
            {
                lblLocation.Text = "No GPS data available";
            }
            else if (e.Status == GeoPositionStatus.Disabled)
            {
                lblLocation.Text = "Location access is disabled";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            watcher.Stop();
            watcher.Dispose();
        }
    }
}
