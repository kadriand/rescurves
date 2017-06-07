using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            InitializeComponent();
            MapViewer = mapViewerControl;
        }

        public MapWindow(MapPlotControl mapViewer)
        {
            InitializeComponent();
            mapViewerControl = mapViewer;
            MapViewer = mapViewerControl;
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

        private void dataPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            if (dataPointsToolStripMenuItem.Checked)
                mapManager.HidePoints(this);
            else
                mapManager.DisplayPoints(this);

            dataPointsToolStripMenuItem.Checked = !dataPointsToolStripMenuItem.Checked;
        }

        private void pointLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapManager mapManager = Globals.ThisAddIn.MapManager;
            if (pointLabelsToolStripMenuItem.Checked)
                mapManager.HidePointLabels(this);
            else
                mapManager.DisplayPointLabels(this);

            pointLabelsToolStripMenuItem.Checked = !pointLabelsToolStripMenuItem.Checked;
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddinPreferencesWindow addinPreferencesWindow = new AddinPreferencesWindow();
            addinPreferencesWindow.Show();
        }

        private void aboutRescurves3DToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }
    }
}
