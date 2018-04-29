using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Rescurves.Model;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Rescurves.View;
using HelixToolkit.Wpf;
using Microsoft.Office.Interop.Excel;
using Rescurves.Configuration;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Rescurves.Controller
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

            ShowMap(residueMap);
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
            //string selectedRng = rng.Address[Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing];

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

            ShowMap(residueMap);
        }

        public void UpdateCurves(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            ClearMap(residueMap);

            residueMap.Sources.ToList().ForEach(source =>
            {
                Worksheet activeWorksheet = (Worksheet)_xlApp.ActiveSheet;
                Range selectedRange = activeWorksheet.Range[source];
                residueMap.AddResidueLines(_rangeParser.RangeToResidueLines(selectedRange));
            });

            ShowMap(residueMap);
        }

        public void ClearMap(ResidueMap residueMap)
        {
            residueMap.ResidueLines.ToList().ForEach(residueLine =>
            {
                residueMap.RemoveResidueLine(residueLine);
                residueMap.MapWindow.MapViewer.RemoveResidueLineArrowHeads(residueLine);
                residueLine.TemperatureArrowHeads.Clear();
            });
            residueMap.MapWindow.MapViewer.DotsOverlayCanvas().Visibility = Visibility.Collapsed;
            residueMap.MapWindow.MapViewer.DotsOverlayCanvas().Children.Clear();
            residueMap.MapWindow.MapViewer.RepresentativeOverlayCanvas().Visibility = Visibility.Collapsed;
            residueMap.MapWindow.MapViewer.RepresentativeOverlayCanvas().Children.Clear();
        }

        private void ShowMap(ResidueMap residueMap)
        {
            if (ResCurvesPreferences.TemperatureColumn)
                DisplayTemperatureArrows(residueMap);
            if (ResCurvesPreferences.DisplayPointLabels)
                DisplayPointLabels(residueMap);
            if (ResCurvesPreferences.DisplayPoints)
                DisplayPoints(residueMap);

            residueMap.ShowMap();
        }

        public void DisplayPoints(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap != null)
                DisplayPoints(residueMap);
        }

        public void DisplayPoints(ResidueMap residueMap)
        {
            Canvas circlesOverlayCanvas = residueMap.MapWindow.MapViewer.DotsOverlayCanvas();

            if (circlesOverlayCanvas.Children.Count > 0 && circlesOverlayCanvas.Visibility.Equals(Visibility.Hidden))
                circlesOverlayCanvas.Visibility = Visibility.Visible;

            Collection<CompositionPoint> orderedPoints = new Collection<CompositionPoint>();
            residueMap.ResidueLines.ToList().ForEach(line =>
            {
                foreach (CompositionPoint point in line.CompositionPoints)
                {
                    Ellipse pointCircle = new Ellipse { Width = 4, Height = 4, Fill = System.Windows.Media.Brushes.Tomato };
                    Overlay.SetPosition3D(pointCircle, point.Point3D);
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

        /**
         * Displays the concentration of a set of representative points of every residue line
         * 
         */
        public void DisplayPointLabels(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap != null)
                DisplayPointLabels(residueMap);
        }

        /**
         * Displays the concentration of a set of representative points of every residue line
         * 
         */
        public void DisplayPointLabels(ResidueMap residueMap)
        {
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
                Overlay.SetPosition3D(text, point.Point3D);
                representativeOverlayCanvas.Children.Add(text);
            }
        }

        /**
         * Hides the concentration of a set of representative points of every residue line
         * 
         */
        public void HidePointLabels(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;

            Canvas representativeOverlayCanvas = residueMap.MapWindow.MapViewer.RepresentativeOverlayCanvas();
            representativeOverlayCanvas.Visibility = Visibility.Hidden;
        }

        /**
         * Displays the concentration of a set of representative points of every residue line
         * 
         */
        private void DisplayTemperatureArrows(ResidueMap residueMap)
        {
            residueMap?.ResidueLines.ToList().ForEach(residueLine =>
            {
                if (residueLine.TemperatureArrowHeads.Count == 0)
                    MakeTemperatureArrows(residueLine);
                residueMap.MapWindow.MapViewer.AddResidueLineArrowHeads(residueLine);
            });
        }

        public void DisplayTemperatureArrows(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap != null)
                DisplayTemperatureArrows(residueMap);
        }

        private void MakeTemperatureArrows(ResidueLine residueLine)
        {
            if (residueLine.CompositionPoints.Count == 0)
                return;

            CompositionPoint previousArrowedPoint = residueLine.CompositionPoints[0];
            CompositionPoint previousDirectionPoint = residueLine.CompositionPoints[0];

            for (int rl = 1; rl < residueLine.CompositionPoints.Count; rl++)
            {
                CompositionPoint point = residueLine.CompositionPoints[rl];
                if (EuclideanDistance(point, previousArrowedPoint) < 0.05)
                {
                    previousDirectionPoint = point;
                    continue;
                }

                Point3D point3D = point.Point3D;
                Point3D previousPoint3D = previousDirectionPoint.Point3D;

                if (double.IsNaN(point.Temperature) || double.IsNaN(previousDirectionPoint.Temperature))
                    continue;

                Vector3D vector3DNormal = point.Temperature > previousDirectionPoint.Temperature ?
                    new Vector3D(point3D.X - previousPoint3D.X, point3D.Y - previousPoint3D.Y, point3D.Z - previousPoint3D.Z) :
                    new Vector3D(previousPoint3D.X - point3D.X, previousPoint3D.Y - point3D.Y, previousPoint3D.Z - point3D.Z);

                var vector3DOrigin = point.Temperature > previousDirectionPoint.Temperature ? previousPoint3D : point3D;

                var tempArrow = new TruncatedConeVisual3D
                {
                    Origin = vector3DOrigin,
                    Normal = vector3DNormal,
                    Height = 0.015,
                    BaseRadius = 0.003,
                    TopRadius = 0,
                    Fill = System.Windows.Media.Brushes.Tomato
                };

                residueLine.TemperatureArrowHeads.Add(tempArrow);
                previousArrowedPoint = point;
                previousDirectionPoint = point;
            }
        }

        /**
         * Hides the concentration of a set of representative points of every residue line
         * 
         */
        public void HideTemperatureArrows(MapWindow mapWindow)
        {
            ResidueMap residueMap = this.ResidueMaps.ToList().FindLast(map => map.MapWindow.Equals(mapWindow));
            if (residueMap == null)
                return;
            foreach (ResidueLine residueLine in residueMap.ResidueLines)
                foreach (TruncatedConeVisual3D lineTemperatureArrow in residueLine.TemperatureArrowHeads)
                    lineTemperatureArrow.Visible = false;
        }

        private double EuclideanDistance(CompositionPoint point1, CompositionPoint point2)
        {
            double distance = Math.Pow((point1.Point3D.X - point2.Point3D.X), 2);
            distance += Math.Pow((point1.Point3D.Y - point2.Point3D.Y), 2);
            distance += Math.Pow((point1.Point3D.Z - point2.Point3D.Z), 2);
            return Math.Pow(distance, 0.5);
        }

    }

}
