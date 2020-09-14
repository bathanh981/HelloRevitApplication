using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands.Entity
{
    class LoadCaseEntity
    {
        private string name;
        private LoadNatureEntity loadNatureEntity;
        private LoadCaseCategory loadCaseCategory;
        private ElementId id;
        public string Name { get => name; set => name = value; }
        public LoadCaseCategory LoadCaseCategory { get => loadCaseCategory; set => loadCaseCategory = value; }
        public LoadNatureEntity LoadNatureEntity { get => loadNatureEntity; set => loadNatureEntity = value; }
        public ElementId Id { get => id; set => id = value; }

        public LoadCaseEntity()
        {
            loadCaseCategory = new LoadCaseCategory();
            loadNatureEntity = new LoadNatureEntity();
        }

        public LoadCaseEntity(string name, LoadCaseCategory loadCaseCategory, LoadNatureEntity loadNatureEntity)
        {
            Name = name;
            LoadCaseCategory = loadCaseCategory;
            LoadNatureEntity = loadNatureEntity;
        }

    }
}
