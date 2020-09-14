using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands
{
    class RevitData
    {
        private UIApplication uIApplication;
        private Application application;
        private UIDocument uiDocument;
        private Document document;
        private Selection selection;
        private Transaction transaction;

        private ICollection<Element> loadCases;
        private ICollection<Element> loadNatures;
        private ICollection<Element> loadCombinations;
        public RevitData()
        {
            loadCases = new List<Element>();
            loadNatures = new List<Element>();
            loadCombinations = new List<Element>();
        }

        public UIApplication UIApplication { get => uIApplication; set => uIApplication = value; }
        public Application Application { get { if (application == null) application = UIApplication.Application; return application; } }
        public UIDocument UiDocument { get { if (uiDocument == null) uiDocument = UIApplication.ActiveUIDocument; return uiDocument; } }
        public Document Document { get { if (document == null) document = UiDocument.Document; return document; } }
        public Selection Selection { get { if (selection == null) selection = UiDocument.Selection; return selection; } }
        public Transaction Transaction { get { if (transaction == null) transaction = new Transaction(Document, "Add-in"); return transaction; } }

        public ICollection<Element> LoadCases
        {
            get
            {
                if (loadCases.Count == 0)
                {
                    loadCases = UI.FilteredElementCollectorByClass(typeof(LoadCase), document);
                }
                return loadCases;

            }
        }
        public ICollection<Element> LoadNatures
        {
            get
            {
                if (loadNatures.Count == 0)
                {
                    loadNatures = UI.FilteredElementCollectorByClass(typeof(LoadNature), document);
                }
                return loadNatures;

            }
        }
        public ICollection<Element> LoadCombinations
        {
            get
            {
                if (loadCombinations.Count == 0)
                {
                    loadCombinations = UI.FilteredElementCollectorByClass(typeof(LoadCombination), document);
                }

                return loadCombinations;

            }
        }

        public void DeleteLoadNatureAndLoadCase()
        {
            foreach (Element e in LoadCases)
            {

                document.Delete(e.Id);
            }

            foreach (Element e in LoadNatures)
            {
                document.Delete(e.Id);
            }
            foreach (Element e in LoadCombinations)
            {
                document.Delete(e.Id);
            }
        }

        public Entity.LoadNatureEntity CreateLoadNature(Entity.LoadNatureEntity loadNatureEntity)
        {
            LoadNature loadNature = LoadNature.Create(document, loadNatureEntity.Name);
            loadNatureEntity.Id = loadNature.Id;
            loadNatures.Add(loadNature);
            return loadNatureEntity;
        }

        public Entity.LoadCaseEntity CreateLoadCase(Entity.LoadCaseEntity loadCaseEntity)
        {
            LoadCase loadCase = LoadCase.Create(document, loadCaseEntity.Name, loadCaseEntity.LoadNatureEntity.Id, loadCaseEntity.LoadCaseCategory);
            loadCaseEntity.Id = loadCase.Id;
            loadCases.Add(loadCase);
            return loadCaseEntity;
        }

        public Entity.LoadCombinationEntity CreateLoadCombination(Entity.LoadCombinationEntity loadCombinationEntity)
        {
            LoadCombination loadCombination;

            try
            {
                loadCombination = LoadCombination.Create(document, loadCombinationEntity.Name);
                loadCombination.SetComponents(loadCombinationEntity.GetLoadComponents());
                loadCombinations.Add(loadCombination);
                loadCombinationEntity.Id = loadCombination.Id;
            }
            catch (Exception e)
            {
                //loadCombination = loadCombinations.First(load => load.Name.Equals(loadCombinationEntity)) as LoadCombination;
            }
            return loadCombinationEntity;
        }

        public void LineLoads()
        {

            IList<Reference> beams = Selection.PickObjects(ObjectType.Element, new Commands.SeclectionFilter.BeamSelectionFilter());
            foreach (Reference r in beams)
            {
                Element e = Document.GetElement(r);
                CreateLineLoad(e);
            }
        }

        public void AreaLoads()
        {
            IList<Reference> floors = Selection.PickObjects(ObjectType.Element, new Commands.SeclectionFilter.FloorSeclectionFilter());
            foreach (Reference r in floors)
            {
                Element e = Document.GetElement(r);
                CreateAreaLoad(e);
            }
        }

        public void CreateLineLoad(Element e)
        {
            AnalyticalModelStick analyticalModelStick = e.GetAnalyticalModel() as AnalyticalModelStick;

            LineLoad lineLoad = LineLoad.Create(Document, analyticalModelStick, new XYZ(0, 0, -1.1), new XYZ(0, 0, 0), null);

            Element loadCase = LoadCases.First(load => { return load.Name.Equals("TTBT"); });
            lineLoad.LoadCaseId = loadCase.Id;
        }
        public void CreateAreaLoad(Element e)
        {
            AnalyticalModelSurface analyticalModelSurface = e.GetAnalyticalModel() as AnalyticalModelSurface;

            AreaLoad areaLoad = AreaLoad.Create(Document, analyticalModelSurface, new XYZ(0, 0, -304.8*1.2), null);

           
            Element loadCase = LoadCases.First(load => { return load.Name.Equals("HOANTHIEN"); });
            areaLoad.LoadCaseId = loadCase.Id;
        }

    }
}
