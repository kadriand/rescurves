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

namespace Rescurves.View.Secondary
{
    public partial class AddinPreferencesWindow : Form
    {
        public AddinPreferencesWindow()
        {
            InitializeComponent();
            this.columnCellsTB.Text = ResCurvesPreferences.CellsBetweenColumns.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int parsed;
            bool success = Int32.TryParse(this.columnCellsTB.Text, out parsed);
            if (success)
                ResCurvesPreferences.CellsBetweenColumns = parsed;
            this.Dispose();
        }

        private void columnCellsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
