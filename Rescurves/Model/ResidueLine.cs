using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace ExcelWithHelixPrelim.Model
{

    public class ResidueLine : LinesVisual3D
    {
        public string SourceGroup { get; set; }


        public Collection<CompositionPoint> CompositionPoints { get; set; }

        public ResidueLine()
        {
            this.CompositionPoints = new Collection<CompositionPoint>();
        }

        public Collection<CompositionPoint> RepresentativePoints()
        {
            Collection<CompositionPoint> sortedPoints = new Collection<CompositionPoint>();
            Collection<CompositionPoint> excludedPoints = new Collection<CompositionPoint>();

            try
            {
                if (this.CompositionPoints.Count == 0)
                    return sortedPoints;

                List<CompositionPoint> listedPoints = this.CompositionPoints.ToList();
                foreach (CompositionPoint compositionPoint in listedPoints)
                {
                    if (excludedPoints.Contains(compositionPoint))
                        continue;
                    sortedPoints.Add(compositionPoint);
                    List<CompositionPoint> nearbyPoints = listedPoints.FindAll(cp => cp.Equals(compositionPoint));
                    foreach (CompositionPoint nearbyPoint in nearbyPoints)
                        if (!excludedPoints.Contains(nearbyPoint))
                            excludedPoints.Add(nearbyPoint);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }

            return sortedPoints;
        }
    }
}
