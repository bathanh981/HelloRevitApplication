
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using HelloRevitApplication.Commands.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HelloRevitApplication.Commands
{

    class ViewData {


        private ICollection<Entity.LoadNatureEntity> loadNatureEntities;
        private ICollection<Entity.LoadCaseEntity> loadCaseEntities;
        private ICollection<LoadCombinationEntity> loadCombinationEntities;

        public ICollection<LoadNatureEntity> LoadNatureEntities { get => loadNatureEntities; set => loadNatureEntities = value; }
        public ICollection<LoadCaseEntity> LoadCaseEntities { get => loadCaseEntities; set => loadCaseEntities = value; }
        public ICollection<LoadCombinationEntity> LoadCombinationEntities { get => loadCombinationEntities; set => loadCombinationEntities = value; }

        public ViewData()
        {
            PrepareDataLoadCombonation();
        }

        public void PrepareDataLoadCombonation()
        {

            LoadNatureEntities = new List<LoadNatureEntity> { };
            LoadNatureEntity loadNatureDL = new LoadNatureEntity("Tỉnh tải");
            LoadNatureEntity loadNatureLL = new LoadNatureEntity("Hoạt tải");
            LoadNatureEntity loadNatureWIND = new LoadNatureEntity("Gió");
            LoadNatureEntity loadNatureSEISMIC = new LoadNatureEntity("Động đất");
            LoadNatureEntities.Add(loadNatureDL);
            LoadNatureEntities.Add(loadNatureLL);
            LoadNatureEntities.Add(loadNatureWIND);
            LoadNatureEntities.Add(loadNatureSEISMIC);


            LoadCaseEntities = new List<LoadCaseEntity> { };
            LoadCaseEntity loadCaseEntityTTBT = new LoadCaseEntity("TTBT", LoadCaseCategory.Dead, loadNatureDL);
            LoadCaseEntity loadCaseEntityTUONG = new LoadCaseEntity("TUONG", LoadCaseCategory.Dead, loadNatureDL);
            LoadCaseEntity loadCaseEntityHOANTHIEN = new LoadCaseEntity("HOANTHIEN", LoadCaseCategory.Dead, loadNatureDL);
            LoadCaseEntity loadCaseEntityHOATTAI = new LoadCaseEntity("HOATTAI", LoadCaseCategory.Live, loadNatureLL);
            LoadCaseEntity loadCaseEntityGIOX = new LoadCaseEntity("GIOX", LoadCaseCategory.Wind , loadNatureWIND);
            LoadCaseEntity loadCaseEntityGIOY = new LoadCaseEntity("GIOY", LoadCaseCategory.Wind, loadNatureWIND);
            LoadCaseEntity loadCaseEntityDONGDAT = new LoadCaseEntity("DONGDAT", LoadCaseCategory.Seismic, loadNatureSEISMIC);
            LoadCaseEntities.Add(loadCaseEntityTTBT);
            LoadCaseEntities.Add(loadCaseEntityTUONG);
            LoadCaseEntities.Add(loadCaseEntityHOANTHIEN);
            LoadCaseEntities.Add(loadCaseEntityHOATTAI);
            LoadCaseEntities.Add(loadCaseEntityGIOX);
            LoadCaseEntities.Add(loadCaseEntityGIOY);
            LoadCaseEntities.Add(loadCaseEntityDONGDAT);

            LoadCombinationEntities = new List<LoadCombinationEntity> { };

            LoadCombinationEntity th1 = new LoadCombinationEntity("TH1");

            th1.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTTBT, 1.1));/// Id chưa tạo
            th1.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTUONG, 1.15));
            th1.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOANTHIEN, 1.1));
            LoadCombinationEntities.Add(th1);

            LoadCombinationEntity th2 = new LoadCombinationEntity("TH2");
            th2.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTTBT, 1.1));
            th2.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTUONG, 1.15));
            th2.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOANTHIEN, 1.1));
            th2.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOATTAI, 1.2));
            LoadCombinationEntities.Add(th2);

            LoadCombinationEntity th3 = new LoadCombinationEntity("TH3");
            th3.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTTBT, 1.1));
            th3.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTUONG, 1.15));
            th3.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOANTHIEN, 1.1));
            th3.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOATTAI, 1.2));
            th3.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityGIOX, 1.2));
            LoadCombinationEntities.Add(th3);

            LoadCombinationEntity th4 = new LoadCombinationEntity("TH4");
            th4.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTTBT, 1.1));
            th4.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTUONG, 1.15));
            th4.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOANTHIEN, 1.1));
            th4.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOATTAI, 1.2));
            th4.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityGIOX, -0.9));
            LoadCombinationEntities.Add(th4);

            LoadCombinationEntity th5 = new LoadCombinationEntity("TH5");
            th5.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTTBT, 1.1));
            th5.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTUONG, 1.15));
            th5.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOANTHIEN, 1.1));
            th5.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOATTAI, 1.2));
            th5.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityGIOY, 1.2));
            LoadCombinationEntities.Add(th5);

            LoadCombinationEntity th6 = new LoadCombinationEntity("TH6");
            th6.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTTBT, 1.1));
            th6.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityTUONG, 1.15));
            th6.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOANTHIEN, 1.1));
            th6.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityHOATTAI, 1.2));
            th6.LoadComponentEntities.Add(new LoadComponentEntity(loadCaseEntityGIOY, -0.9));
            LoadCombinationEntities.Add(th6);
           // LoadComponent a= new LoadComponent()

        }

        public void PrepareDataLoas()
        {

        }
    }
}
