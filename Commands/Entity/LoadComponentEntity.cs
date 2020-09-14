using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands.Entity
{
    class LoadComponentEntity
    {
        private LoadCaseEntity loadCaseEntity;
        private double factor;

        public double Factor { get => factor; set => factor = value; }
        internal LoadCaseEntity LoadCaseEntity { get => loadCaseEntity; set => loadCaseEntity = value; }

        public LoadComponentEntity()
        {
            loadCaseEntity = new LoadCaseEntity();
        }

        public LoadComponentEntity(LoadCaseEntity loadCaseEntity, double factor)
        {
            Factor = factor;
            LoadCaseEntity = loadCaseEntity;
        }

        public LoadComponentEntity(LoadCaseEntity loadCaseEntity)
        {
            LoadCaseEntity = loadCaseEntity;
            factor = 1;
        }
    }
}
