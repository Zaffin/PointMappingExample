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

            return selectedPoint;
        }

        public Point3D MapPoint(Point3D point, MCView view)
        {
            return ViewManager.ConvertToViewCoordinates(point, view);
        }

        public void ClearPrompt()
        {
            PromptManager.Clear();
        }
    }
}
