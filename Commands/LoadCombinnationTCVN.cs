using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace HelloRevitApplication.Commands
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class LoadCombinnationTCVN : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            Singleton.Instance = new Singleton();
            Singleton.Instance.RevitData.UIApplication = commandData.Application;
            Singleton.Instance.RevitData.Transaction.SetName("LoadCombination");
            Singleton.Instance.RevitData.Transaction.Start();

            try
            {
                PrepareData();
            }
            catch(Exception e)
            {
                message = e.Message + "\n " + e.StackTrace;
                return Result.Failed;
            }
            finally
            {
                Singleton.Instance.RevitData.Transaction.Commit();

            }
            TaskDialog.Show("Thành công", "Tải trọng và tô hợp tải trọng đã được tải lên");
            return Result.Succeeded;
        }

        public void PrepareData()
        {
           PrepareDataLoadCaseAndLoadCombonation();
        }

        public void PrepareDataLoadCaseAndLoadCombonation()
        {
            Singleton.Instance.RevitData.DeleteLoadNatureAndLoadCase();
            // taoj theo tieu chuan

            foreach (Entity.LoadNatureEntity load in Singleton.Instance.ViewData.LoadNatureEntities)
            {
                Singleton.Instance.RevitData.CreateLoadNature(load);
            }

            foreach (Entity.LoadCaseEntity load in Singleton.Instance.ViewData.LoadCaseEntities)
            {
                Singleton.Instance.RevitData.CreateLoadCase(load);
            }

            foreach (Entity.LoadCombinationEntity load in Singleton.Instance.ViewData.LoadCombinationEntities)
            {
                Singleton.Instance.RevitData.CreateLoadCombination(load);
            }


        }      
    }
}
