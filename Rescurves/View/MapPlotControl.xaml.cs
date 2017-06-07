using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using ExcelWithHelixPrelim.Controller;
using ExcelWithHelixPrelim.Model;
using HelixToolkit.Wpf;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelWithHelixPrelim.View
{
    /// <summary>
    /// Interaction logic for MapPlotControl.xaml
    /// </summary>
    public partial class MapPlotControl : UserControl
    {
        private LinesVisual3D MapEdges { get; set; }

        public MapPlotControl()
        {
            InitializeComponent();
            MapView3D.ShowCoordinateSystem = false;
            //MapView3D.ShowCameraInfo = true;
            this.DataContext = this;
            CompositionTarget.Rendering += this.CompositionTargetRendering;
        }
        
        public void AddResidueLine(LinesVisual3D residueLine)
        {
            MapView3D.Children.Add(residueLine);
        }

        public void DefineComponentLabels(IList<BillboardTextItem> componentsTextItems)
        {
            ComponentsTextGroupV3D.Items = componentsTextItems;
        }

        public void RemoveResidueLine(LinesVisual3D residueLine)
        {
            if (MapView3D.Children.Contains(residueLine))
                MapView3D.Children.Remove(residueLine);
        }

        public void ClearResidueLines()
        {
            MapView3D.Children.Clear();
        }

        public void DrawBorders(MapBounds mapBounds)
        {
            this.MapEdges = new LinesVisual3D { Color = Colors.BlueViolet };
            MapEdges.Points = new Point3DCollection(mapBounds.CornerPoints);
            MapView3D.Children.Add(MapEdges);

            foreach (Point3D borderPoint in mapBounds.BorderPoints)
            {
                Ellipse pointCircle = new Ellipse { Width = 2.5, Height = 2.5, Fill = Brushes.BlueViolet };
                Overlay.SetPosition3D(pointCircle, borderPoint);
                this.BorderDotPointsOverlay.Children.Add(pointCircle);
            }
        }

        public void Recenter()
        {
            double xa = 0.5 / 3;
            double xb = 0.5 / 3;
            double xc = 0.5 / 3;
            double xd = 0.5;
            double xx = xb + 0.5 * xc + 0.5 * xd;
            double yy = 0.5 * Math.Sqrt(3) * xc + (1.0 / 6.0) * Math.Sqrt(3) * xd;
            double zz = Math.Sqrt(2.0 / 3.0) * xd;

            MapView3D.Camera.LookDirection = new Vector3D(-1.8, -1, -0.5);
            MapView3D.Camera.UpDirection = new Vector3D(0.5, 0.3, 0.8);
            MapView3D.Camera.Position = new Point3D(xx + 1.8, yy + 1, zz + 0.5);
            MapView3D.Camera.NearPlaneDistance = 0.1;
            MapView3D.Camera.FarPlaneDistance = double.PositiveInfinity;
        }

        public Canvas DotsOverlayCanvas()
        {
            return this.DotPointsOverlay;
        }

        public Canvas RepresentativeOverlayCanvas()
        {
            return this.RepresentativePointsOverlay;
        }

        /// <summary>
        /// The composition target rendering.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CompositionTargetRendering(object sender, EventArgs e)
        {
            var matrix = Viewport3DHelper.GetTotalTransform(this.MapView3D.Viewport);
            foreach (FrameworkElement element in this.DotPointsOverlay.Children)
            {
                var position = Overlay.GetPosition3D(element);
                var position2D = matrix.Transform(position);
                Canvas.SetLeft(element, position2D.X - element.ActualWidth / 2);
                Canvas.SetTop(element, position2D.Y - element.ActualHeight / 2);
            }
            foreach (FrameworkElement element in this.RepresentativePointsOverlay.Children)
            {
                var position = Overlay.GetPosition3D(element);
                var position2D = matrix.Transform(position);
                Canvas.SetLeft(element, position2D.X - element.ActualWidth / 2);
                Canvas.SetTop(element, position2D.Y - element.ActualHeight / 2);
            }
            foreach (FrameworkElement element in this.BorderDotPointsOverlay.Children)
            {
                var position = Overlay.GetPosition3D(element);
                var position2D = matrix.Transform(position);
                Canvas.SetLeft(element, position2D.X - element.ActualWidth / 2);
                Canvas.SetTop(element, position2D.Y - element.ActualHeight / 2);
            }
        }

    }
}
