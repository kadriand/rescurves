using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rescurves.Configuration;
using Rescurves.Controller;
using Rescurves.Model;
using Rescurves.View.Secondary;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Rescurves.View
{
    public partial class MapWindow : Form
    {
        public MapPlotControl MapViewer { get; set; }

        public MapWindow()
        {
            Initialize();
            MapViewer = mapViewerControl;
        }

        public MapWindow(MapPlotControl mapViewer)
        {
            Initialize();
            mapViewerControl = mapViewer;
            MapViewer = mapViewerControl;
        }

        private void Initialize()
        {
            InitializeComponent();
            dataPointsToolStripMenuItem.Checked = ResCurvesPreferences.DisplayPoints;
            pointLabelsToolStripMenuItem.Checked = ResCurvesPreferences.DisplayPointLabels;
            temperatureArrowsToolStripMenuItem.Checked = ResCurvesPreferences.TemperatureColumn;
        }

        private void newCurveBtn_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            mapManager.NewCurves(this);
        }

        private void coordinatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            mapManager.UpdateCurves(this);
        }

        private void recenterBtn_Click(object sender, EventArgs e)
        {
            this.MapViewer.Recenter();
        }

        private void editCurvesBtn_Click(object sender, EventArgs e)
        {

        }

        private void DataPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            if (dataPointsToolStripMenuItem.Checked)
                mapManager.HidePoints(this);
            else
                mapManager.DisplayPoints(this);

            dataPointsToolStripMenuItem.Checked = !dataPointsToolStripMenuItem.Checked;
            ResCurvesPreferences.DisplayPoints = dataPointsToolStripMenuItem.Checked;
        }

        private void PointLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            if (pointLabelsToolStripMenuItem.Checked)
                mapManager.HidePointLabels(this);
            else
                mapManager.DisplayPointLabels(this);

            pointLabelsToolStripMenuItem.Checked = !pointLabelsToolStripMenuItem.Checked;
            ResCurvesPreferences.DisplayPointLabels = pointLabelsToolStripMenuItem.Checked;
        }

        private void PreferencesToolStripMenuItem(object sender, EventArgs e)
        {
            AddinPreferencesWindow addinPreferencesWindow = new AddinPreferencesWindow();
            addinPreferencesWindow.Show();
        }

        private void aboutRescurves3DToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void TemperatureArrowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            if (temperatureArrowsToolStripMenuItem.Checked)
                mapManager.HideTemperatureArrows(this);
            else
                mapManager.DisplayTemperatureArrows(this);

            temperatureArrowsToolStripMenuItem.Checked = !temperatureArrowsToolStripMenuItem.Checked;
            ResCurvesPreferences.DisplayPoints = temperatureArrowsToolStripMenuItem.Checked;
        }
    }
}
