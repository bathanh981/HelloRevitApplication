using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands.SeclectionFilter
{
    class BeamSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                return true;
            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_AnalyticalNodes_Lines)
                return true;
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}
