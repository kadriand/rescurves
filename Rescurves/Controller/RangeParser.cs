using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Rescurves.Configuration;
using Rescurves.Model;
using HelixToolkit.Wpf;
using Microsoft.Office.Interop.Excel;

namespace Rescurves.Controller
{
    class RangeParser
    {
        readonly Application _xlApp = Globals.ThisAddIn.Application;

        public IEnumerable<ResidueLine> RangeToResidueLines(Range selectedRange)
        {
            if (selectedRange == null)
                yield break;

            String selection = selectedRange.AddressLocal[Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing];
            IEnumerable<Range> pointsColumns = SplitPointColumns(selectedRange);
            foreach (Range lines in pointsColumns)
            {
                ResidueLine residueLine = new ResidueLine();
                residueLine.Color = Colors.Coral;
                residueLine.Points = new Point3DCollection(GeneratePoints(lines, residueLine));
                residueLine.SourceGroup = selection;
                yield return residueLine;
            }
        }

        // Finds the components inside the range selected
        public IEnumerable<BillboardTextItem> RangeToComponentLabels(Range selectedRange)
        {
            if (selectedRange == null || selectedRange.Columns.Count < 4 || selectedRange.Rows.Count < 1)
                yield break;

            Range componentsRange = _xlApp.Range[(Range)selectedRange.Columns[1], (Range)selectedRange.Columns[4]];

            Debug.WriteLine("Components: ");
            for (int i = 1; i <= componentsRange.Columns.Count; i++)
            {
                string component = "";
                double xx;
                double yy;
                double zz;
                try
                {
                    Range cell = (Range)componentsRange.Cells[1, i];
                    component = cell?.Value2?.ToString();
                    double value;
                    if (Double.TryParse(component, out value))
                        yield break;

                    Debug.Write(component + ", ");

                    double xa = i == 1 ? 1 : 0;
                    double xb = i == 2 ? 1 : 0;
                    double xc = i == 3 ? 1 : 0;
                    double xd = i == 4 ? 1.05 : 0;
                    xx = xb + 0.5 * xc + 0.5 * xd;
                    yy = 0.5 * Math.Sqrt(3) * xc + (1.0 / 6.0) * Math.Sqrt(3) * xd;
                    zz = Math.Sqrt(2.0 / 3.0) * xd;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    yield break;
                }

                yield return new BillboardTextItem
                {
                    Text = component,
                    Position = new Point3D(xx, yy, zz),
                    DepthOffset = 0,
                    WorldDepthOffset = 0.0
                };
            }
        }

        private IEnumerable<Range> SplitPointColumns(Range selectedRange)
        {
            int columnsCount = selectedRange.Columns.Count;

            int firstLineColumn = 1;
            int lastLineColumn = ResCurvesPreferences.ComponentsCount;

            while (lastLineColumn <= columnsCount)
            {
                Range residueRange = null;
                try
                {
                    residueRange = _xlApp.Range[(Range)selectedRange.Columns[firstLineColumn], (Range)selectedRange.Columns[lastLineColumn]];
                    residueRange.Interior.ColorIndex = 36;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    residueRange = null;
                }

                firstLineColumn += ResCurvesPreferences.ComponentsCount + ResCurvesPreferences.CellsBetweenColumns;
                lastLineColumn += ResCurvesPreferences.ComponentsCount + ResCurvesPreferences.CellsBetweenColumns;
                if (residueRange != null)
                    yield return residueRange;
            }
        }

        public IEnumerable<Point3D> GeneratePoints(Range singleLineRange, ResidueLine residueLine)
        {
            Point3D? lastPoint = null;

            foreach (Range row in singleLineRange.Rows)
            {
                //Do something with the row.
                Point3D pt;
                try
                {
                    string xaRange = ((Range)row.Cells[1, 1]).Value.ToString();
                    string xbRange = ((Range)row.Cells[1, 2]).Value.ToString();
                    string xcRange = ((Range)row.Cells[1, 3]).Value.ToString();
                    string xdRange = ((Range)row.Cells[1, 4]).Value.ToString();

                    double xa = 0;
                    double xb = 0;
                    double xc = 0;
                    double xd = 0;

                    if (!Double.TryParse(xaRange, out xa) ||
                        !Double.TryParse(xbRange, out xb) ||
                        !Double.TryParse(xcRange, out xc) ||
                        !Double.TryParse(xdRange, out xd))
                    {
                        lastPoint = null;
                        continue;
                    }

                    if (Math.Abs(xa + xb + xc + xd - 1) > 0.01)
                        continue;

                    CompositionPoint compositionPoint = new CompositionPoint(xa, xb, xc, xd);
                    residueLine.CompositionPoints.Add(compositionPoint);
                    pt = compositionPoint.Point3D;

                    if (ResCurvesPreferences.TemperatureColumn && row.Columns.Count > ResCurvesPreferences.ComponentsCount)
                    {
                        string tempRange = ((Range)row.Cells[1, 5]).Value.ToString();
                        double temperature;
                        if (Double.TryParse(tempRange, out temperature))
                            compositionPoint.Temperature = temperature;
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    continue;
                }

                if (lastPoint.HasValue)
                {
                    yield return lastPoint.Value;
                    yield return pt;
                }
                lastPoint = pt;
            };
        }

    }
}
