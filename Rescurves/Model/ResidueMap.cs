using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Rescurves.View;
using HelixToolkit.Wpf;
using Microsoft.Office.Tools.Ribbon;

namespace Rescurves.Model
{

    public class ResidueMap
    {
        public MapWindow MapWindow { get; set; }
        public RibbonDropDownItem DropDownItem { get; set; }

        public Collection<ResidueLine> ResidueLines = new Collection<ResidueLine>();
        public Collection<string> Sources = new Collection<string>();
        public List<BillboardTextItem> ComponentLabels = new List<BillboardTextItem>();

        public ResidueMap()
        {
            this.MapWindow = new MapWindow();
            this.MapWindow.MapViewer.DrawBorders(new MapBounds());
        }

        public void ReDisplayMap()
        {
            if (this.MapWindow.IsDisposed)
                Recreate();
            else {
                this.MapWindow.WindowState = FormWindowState.Minimized;
                this.MapWindow.Show();
                this.MapWindow.WindowState = FormWindowState.Normal;
            }
        }

        public void SendToBack()
        {
            this.MapWindow.SendToBack();
        }

        public void ShowMap()
        {
            this.MapWindow.Show();
            MapWindow.BringToFront();
        }

        public void Recreate()
        {
            this.MapWindow.MapViewer.ClearResidueLines();

            this.MapWindow = new MapWindow();
            this.MapWindow.MapViewer.DrawBorders(new MapBounds());
            AddResidueLines(this.ResidueLines);
            AddComponentLabels(this.ComponentLabels);

            MapWindow.Show();
            MapWindow.BringToFront();
        }

        public void AddResidueLine(ResidueLine residueLine)
        {
            if (residueLine == null)
                return;
            this.MapWindow.MapViewer.AddResidueLine(residueLine);
            if (!this.ResidueLines.Contains(residueLine))
                this.ResidueLines.Add(residueLine);
        }

        public void AddResidueLines(IEnumerable<ResidueLine> residueLines)
        {
            foreach (ResidueLine residueLine in residueLines)
                this.AddResidueLine(residueLine);
        }

        public void AddResidueLines(Collection<ResidueLine> residueLines)
        {
            residueLines.ToList().ForEach(this.AddResidueLine);
        }

        public void AddComponentLabels(IEnumerable<BillboardTextItem> components)
        {
            if (components.Count() == 4)
            {
                this.ComponentLabels = components.ToList();
                this.MapWindow.MapViewer.DefineComponentLabels(this.ComponentLabels);
            }
        }

        public void RemoveResidueLine(ResidueLine residueLine)
        {
            //TODO is all that has to be removed?
            this.MapWindow.MapViewer.RemoveResidueLine(residueLine);
            this.ResidueLines.Remove(residueLine);
        }
    }
}
