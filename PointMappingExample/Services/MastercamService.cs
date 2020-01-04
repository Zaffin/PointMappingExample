using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Mastercam.IO;
using Mastercam.IO.Types;
using Mastercam.Math;
using Mastercam.Support;
using Mastercam.Database;

namespace PointMappingExample.Services
{
    class MastercamService : IMastercamService
    {
        public List<MCView> GetViews()
        {
            return SearchManager.GetViews().ToList();
        }

        public Point3D SelectSinglePoint()
        {
            var selectedPoint = new Point3D();

            SelectionManager.AskForPoint("Select a Point", 
                                         PointMask.Null, 
                                         ref selectedPoint);

            PromptManager.Clear();

            return selectedPoint;
        }

        public Point3D MapPoint(Point3D point, MCView view)
        {
            return ViewManager.ConvertToViewCoordinates(point, view);
        }

        public Point3D MapPoint(Point3D point, Matrix3D matrix)
        {
            var mappedX = (point.x * matrix.Row1.x) +
                          (point.y * matrix.Row2.x) +
                          (point.z * matrix.Row3.x);

            var mappedY = (point.x * matrix.Row1.y) +
                          (point.y * matrix.Row2.y) +
                          (point.z * matrix.Row3.y);

            var mappedZ = (point.x * matrix.Row1.z) +
                          (point.y * matrix.Row2.z) +
                          (point.z * matrix.Row3.z);

            return new Point3D
            {
                x = mappedX,
                y = mappedY,
                z = mappedZ
            };
        }

    }
}
