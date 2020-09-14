using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class AutoLineLoads : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            Singleton.Instance = new Singleton();
            Singleton.Instance.RevitData.UIApplication = commandData.Application;
            Singleton.Instance.RevitData.Transaction.SetName("Auto LineLoads");
            Singleton.Instance.RevitData.Transaction.Start();

            try
            {
                PrepareData();
            }
            catch (Exception e)
            {
                message = e.Message + "\n " + e.StackTrace;
                return Result.Failed;
            }
            finally
            {
                Singleton.Instance.RevitData.Transaction.Commit();

            }
            TaskDialog.Show("Thành công", "Tạo tải trọng thành công");
            return Result.Succeeded;
        }

        public void PrepareData()
        {
            Singleton.Instance.RevitData.LineLoads();
        }
    }
}
