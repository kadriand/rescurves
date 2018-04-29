using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Rescurves.Controller;

namespace Rescurves.Model
{
    public class MapBounds
    {
        public IEnumerable<Point3D> CornerPoints { get; set; }
        public IEnumerable<Point3D> BorderPoints { get; set; }

        public MapBounds()
        {
            this.CornerPoints = GenerateBorders();
            this.BorderPoints = PointCircles();
        }

        public IEnumerable<Point3D> GenerateBorders()
        {
            double[,] boundPoints = new double[,] {{ 1,0,0,0},
                {0,1,0,0},
                {1,0,0,0},
                {0,0,1,0},
                {1,0,0,0},
                {0,0,0,1},
                {0,1,0,0},
                {0,0,1,0},
                {0,1,0,0},
                {0,0,0,1},
                {0,0,1,0},
                {0,0,0,1}
                };

            for (int i = 0; i < boundPoints.GetLength(0); i++)
            {
                double xa = boundPoints[i, 0];
                double xb = boundPoints[i, 1];
                double xc = boundPoints[i, 2];
                double xd = boundPoints[i, 3];

                double xx = xb + 0.5 * xc + 0.5 * xd;
                double yy = 0.5 * Math.Sqrt(3) * xc + (1.0 / 6.0) * Math.Sqrt(3) * xd;
                double zz = Math.Sqrt(2.0 / 3.0) * xd;

                var pt = new Point3D(xx, yy, zz);
                yield return pt;
            }
        }

        public IEnumerable<Point3D> PointCircles()
        {
            double[] comPoints = new double[] { 0, 0, 0, 0 };

            for (int i = 1; i <= comPoints.Length; i++)
            {
                int compAindex = 0;
                int compBindex = compAindex + i;
                while (compBindex < comPoints.Length)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        comPoints = new double[] { 0, 0, 0, 0 };
                        comPoints[compAindex] = (j + 1.0) / 10;
                        comPoints[compBindex] = 1 - (j + 1.0) / 10;

                        CompositionPoint compositionPoint = new CompositionPoint(comPoints[0], comPoints[1], comPoints[2], comPoints[3]);
                        yield return compositionPoint.Point3D;
                    }
                    compAindex++;
                    compBindex++;
                }
            }
        }
    }
}
