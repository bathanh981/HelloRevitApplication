using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands
{
    class UI
    {
        public static ICollection<Element> FilteredElementCollectorByClass(Type type, Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<Element> elements = collector.OfClass(type).ToElements();
            if (elements == null) elements = new List<Element>();
            return elements;
        }
    }
}
