using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using Rescurves.Model;

namespace Rescurves.View
{
    public partial class PacPlotRibbon
    {
        private void PacPlotRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
            item.Label = "";
            this.mapsDropDown.Items.Add(item);
        }

        private void launcherButton_Click(object sender, RibbonControlEventArgs e)
        {
            ResidueMap residueMap = Globals.ThisAddIn.MapManager.CreateMap();
            if (residueMap == null)
                return;

            RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
            item.Label = "Map " + (this.mapsDropDown.Items.Count);
            this.mapsDropDown.Items.Add(item);
            residueMap.DropDownItem = item;
        }

        private void mapsDropDown_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            RibbonDropDownItem item = this.mapsDropDown.SelectedItem;
            ResidueMap residueMap = Globals.ThisAddIn.MapManager.ResidueMaps.First(map => map.DropDownItem.Equals(item));

            if (residueMap == null)
                return;

            residueMap.ReDisplayMap();
            this.mapsDropDown.SelectedItem = this.mapsDropDown.Items[0];
        }

        private void settingsButton_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
