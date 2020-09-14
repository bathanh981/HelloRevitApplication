using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands.Entity
{
    class LoadCombinationEntity
    {
       private ICollection<LoadComponentEntity> loadComponentEntities;
       private string name;
        private ElementId id;
        public string Name { get => name; set => name = value; }
        public ElementId Id { get => id; set => id = value; }
        internal ICollection<LoadComponentEntity> LoadComponentEntities { get => loadComponentEntities; set => loadComponentEntities = value; }

        public LoadCombinationEntity()
        {
            LoadComponentEntities = new List<LoadComponentEntity>();
        }

        public LoadCombinationEntity(string name)
        {
            LoadComponentEntities = new List<LoadComponentEntity>();
            Name = name;
        }

        public LoadCombinationEntity(string name, ICollection<LoadComponentEntity> loadComponentEntities) : this(name)
        {
            LoadComponentEntities = loadComponentEntities;
        }

        public IList< LoadComponent> GetLoadComponents()
        {
            IList<LoadComponent> loads = new List<LoadComponent>(); 
            foreach(LoadComponentEntity componentEntity in this.LoadComponentEntities)
            {
                loads.Add(new LoadComponent(componentEntity.LoadCaseEntity.Id, componentEntity.Factor));
            }
            return loads;
        }
    }
}
