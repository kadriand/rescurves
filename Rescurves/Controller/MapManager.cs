using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using ExcelWithHelixPrelim.Model;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using ExcelWithHelixPrelim.View;
using HelixToolkit.Wpf;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ExcelWithHelixPrelim.Controller
{
    public class MapManager
    {
        public Collection<ResidueMap> ResidueMaps;

        private readonly RangeParser _rangeParser;

        readonly Application _xlApp = Globals.ThisAddIn.Application;

        public MapManager()
        {
            ResidueMaps = new Collection<ResidueMap>();
            _rangeParser = new RangeParser();
        }

        public ResidueMap CreateMap()
        {
            ResidueMap residueMap = new ResidueMap();

            Range selectedRange = SelectRange();
            if (selectedRange == null)
                return null;

            residueMap.AddComponentLabels(this._rangeParser.RangeToComponentLabels(selectedRange));
            residueMap.AddResidueLines(this._rangeParser.RangeToResidueLines(selectedRange));
            String selection = selectedRange.AddressLocal[Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing];
            residueMap.Sources.Add(selection);

            ResidueMaps.Add(residueMap);
            residueMap.ShowMap();

            return residueMap;
        }

        public Range SelectRange()
        {
            Range selection = _xlApp.Selection as Range;
            string currentLocation = null;
            if (selection != null)
                currentLocation = selection.AddressLocal[Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing];

            //Implements InputBox method with last argument value is set as 8
            var inputBox = _xlApp.InputBox("Select Range", Type.Missing, currentLocation ?? Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 8);
            if (!(inputBox is Range))
                return null;

            //Declares range object
            Range rng = (Range)inputBox;
            //Display the range address that we just received as an input using InputBox method
            string selectedRng = rng.Address[Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing];

            return rng;
        }

        public void NewCurves(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            residueMap.SendToBack();
            Range selectedRange = SelectRange();
            if (selectedRange == null)
                return;

            if (residueMap.ComponentLabels.Count != 4)
                residueMap.AddComponentLabels(_rangeParser.RangeToComponentLabels(selectedRange));
            residueMap.AddResidueLines(_rangeParser.RangeToResidueLines(selectedRange));
            String selection = selectedRange.AddressLocal[Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing];
            residueMap.Sources.Add(selection);

            residueMap.ShowMap();
        }

        public void UpdateCurves(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            residueMap.ResidueLines.ToList().ForEach(residueMap.RemoveResidueLine);

            residueMap.Sources.ToList().ForEach(source =>
            {
                Worksheet activeWorksheet = (Worksheet)_xlApp.ActiveSheet;
                Range selectedRange = activeWorksheet.Range[source];
                residueMap.AddResidueLines(_rangeParser.RangeToResidueLines(selectedRange));
            });
        }

        public void DisplayPoints(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            Canvas circlesOverlayCanvas = residueMap.MapWindow.MapViewer.DotsOverlayCanvas();

            if (circlesOverlayCanvas.Children.Count > 0 && circlesOverlayCanvas.Visibility.Equals(Visibility.Hidden))
                circlesOverlayCanvas.Visibility = Visibility.Visible;

            Collection<CompositionPoint> orderedPoints = new Collection<CompositionPoint>();
            residueMap.ResidueLines.ToList().ForEach(line =>
            {
                foreach (CompositionPoint point in line.CompositionPoints)
                {
                    Ellipse pointCircle = new Ellipse { Width = 4, Height = 4, Fill = System.Windows.Media.Brushes.Tomato };
                    Overlay.SetPosition3D(pointCircle, point.point3D);
                    circlesOverlayCanvas.Children.Add(pointCircle);
                }
                foreach (CompositionPoint compositionPoint in line.RepresentativePoints())
                    orderedPoints.Add(compositionPoint);
            });

        }

        public void HidePoints(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            Canvas circlesOverlayCanvas = residueMap.MapWindow.MapViewer.DotsOverlayCanvas();
            circlesOverlayCanvas.Visibility = Visibility.Hidden;
        }

        public void DisplayPointLabels(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            Canvas representativeOverlayCanvas = residueMap.MapWindow.MapViewer.RepresentativeOverlayCanvas();

            if (representativeOverlayCanvas.Children.Count > 0 && representativeOverlayCanvas.Visibility.Equals(Visibility.Hidden))
                representativeOverlayCanvas.Visibility = Visibility.Visible;

            Collection<CompositionPoint> orderedPoints = new Collection<CompositionPoint>();
            residueMap.ResidueLines.ToList().ForEach(line =>
            {
                foreach (CompositionPoint compositionPoint in line.RepresentativePoints())
                    orderedPoints.Add(compositionPoint);
            });

            ResidueLine orderedResidueLine = new ResidueLine();
            orderedResidueLine.CompositionPoints = orderedPoints;
            foreach (CompositionPoint point in orderedResidueLine.RepresentativePoints())
            {
                TextBlock text = new TextBlock { Text = point.ToString() };
                Overlay.SetPosition3D(text, point.point3D);
                representativeOverlayCanvas.Children.Add(text);
            }

        }

        public void HidePointLabels(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            Canvas representativeOverlayCanvas = residueMap.MapWindow.MapViewer.RepresentativeOverlayCanvas();
            representativeOverlayCanvas.Visibility = Visibility.Hidden;
        }
    }


}
