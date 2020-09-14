using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands.Entity
{
    class LoadNatureEntity
    {
        private string name;
        private ElementId id;
        public string Name { get => name; set => name = value; }
        public ElementId Id { get => id; set => id = value; }

        public LoadNatureEntity()
        {
        }

        public LoadNatureEntity(string name)
        {
            Name = name;
        }
    }
}
