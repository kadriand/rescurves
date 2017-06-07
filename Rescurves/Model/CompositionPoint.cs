using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace ExcelWithHelixPrelim.Model
{

    public class CompositionPoint
    {
        public double Xa = 0;
        public double Xb = 0;
        public double Xc = 0;
        public double Xd = 0;
        public Point3D point3D { get; set; }
        //public double Temperature = 0;


        // TODO UNUSED METHOD
        public CompositionPoint(double xa, double xb, double xc, double xd, Point3D point3D)
        {
            this.Xa = xa;
            this.Xb = xb;
            this.Xc = xc;
            this.Xd = xd;
            this.point3D = point3D;
        }

        public CompositionPoint(double xa, double xb, double xc, double xd)
        {
            this.Xa = xa;
            this.Xb = xb;
            this.Xc = xc;
            this.Xd = xd;

            double xx = xb + 0.5 * xc + 0.5 * xd;
            double yy = 0.5 * Math.Sqrt(3) * xc + (1.0 / 6.0) * Math.Sqrt(3) * xd;
            double zz = Math.Sqrt(2.0 / 3.0) * xd;

            this.point3D = new Point3D(xx, yy, zz);
        }

        public override string ToString()
        {
            try
            {
                StringBuilder point3D = new StringBuilder("[");

                point3D.Append(Xa < 0.01 ? Xa.ToString("e2").Replace("e-00", "e-").Replace("e+000", "") : Xa.ToString("F2", CultureInfo.InvariantCulture));
                point3D.Append(", " + (Xb < 0.01 ? Xb.ToString("e2").Replace("e-00", "e-").Replace("e+000", "") : Xb.ToString("F2", CultureInfo.InvariantCulture)));
                point3D.Append(", " + (Xc < 0.01 ? Xc.ToString("e2").Replace("e-00", "e-").Replace("e+000", "") : Xc.ToString("F2", CultureInfo.InvariantCulture)));
                point3D.Append(", " + (Xd < 0.01 ? Xd.ToString("e2").Replace("e-00", "e-").Replace("e+000", "") : Xd.ToString("F2", CultureInfo.InvariantCulture)));
                point3D.Append("]");
                return point3D.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return "[" + Xa.ToString("E2") + ", " + Xb.ToString("E2") + ", " + Xc.ToString("E2") + " ," +
                       Xd.ToString("E2") + "]";
            }

        }

        public bool Equals(CompositionPoint cp)
        {
            double tolerance = 0.08;
            if (Math.Abs(cp.Xa - this.Xa) < tolerance && Math.Abs(cp.Xb - this.Xb) < tolerance && Math.Abs(cp.Xc - this.Xc) < tolerance && Math.Abs(cp.Xd - this.Xd) < tolerance)
                return true;
            return false;
        }
    }
}
