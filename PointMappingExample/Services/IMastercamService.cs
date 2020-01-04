using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mastercam.Database;
using Mastercam.Math;

namespace PointMappingExample.Services
{
    public interface IMastercamService
    {
        List<MCView> GetViews();

        Point3D SelectSinglePoint();

        Point3D MapPoint(Point3D point, MCView view);

        Point3D MapPoint(Point3D point, Matrix3D view);
  
    }
}
