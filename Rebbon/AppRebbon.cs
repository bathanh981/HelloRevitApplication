using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HelloRevitApplication.Rebbon
{
    class AppRebbon
    {
           public static void AddRibbonPanel(UIControlledApplication application)
        {
            //Tab Name that will display in Revit
            string TabName = "Revit App";

            //Create the Ribbon Tab
            application.CreateRibbonTab(TabName);

            //Get the assembly path to execute commands
            string AssemblyPath = Assembly.GetExecutingAssembly().Location;
         

            //
            BitmapImage ButtonImage = new BitmapImage(new Uri(@"C:\Bathanh\Contents\Resources\Button100x100.png"));
            //Create a Panel within the Tab
            RibbonPanel RibbonPanelOne = application.CreateRibbonPanel(TabName, "Demo");
            //Create Push Button Data to create the Push button from
            PushButtonData pbdTestButton = new PushButtonData("cmdTestButton", "HelloRevitAPI", AssemblyPath, "HelloRevitApplication.Commands.HelloWorld");
            //Create a Push Button from the Push Button Data
            PushButton pbTestButton = RibbonPanelOne.AddItem(pbdTestButton) as PushButton;
            //Set Button Image
            pbTestButton.LargeImage = ButtonImage;
            //Set Button Tool Tips
            pbTestButton.ToolTip = "Hello Revit API";
            //Set Button Long description which is the text that flys out when you hover on a button longer
            //pbTestButton.LongDescription = "Give the user more information about how they need to use the button features";

            //LoadCombination
            BitmapImage ButtonImageLoadCombination = new BitmapImage(new Uri(@"C:\Bathanh\Contents\Resources\ChangeViewReference100x100.png"));
            //Create a Panel within the Tab
            RibbonPanel RibbonPanelLoadCombination = application.CreateRibbonPanel(TabName, "LoadCombinations");
            //Create Push Button Data to create the Push button from
            PushButtonData pbdLoadCombinaionButton = new PushButtonData("cmdLoadCombinationButton", "LoadCombination", AssemblyPath, "HelloRevitApplication.Commands.LoadCombinnationTCVN");
            //Create a Push Button from the Push Button Data
            PushButton pbLoadCombinationButton = RibbonPanelLoadCombination.AddItem(pbdLoadCombinaionButton) as PushButton;
            //Set Button Image
            pbLoadCombinationButton.LargeImage = ButtonImageLoadCombination;
            //Set Button Tool Tips
            pbLoadCombinationButton.ToolTip = "Tạo tải trọng và tổ hợp tải trọng theo TCVN";
            //Set Button Long description which is the text that flys out when you hover on a button longer
            pbLoadCombinationButton.LongDescription = "Click";

            //LineLoad
            BitmapImage ButtonImageLineLoad = new BitmapImage(new Uri(@"C:\Bathanh\Contents\Resources\ChangeViewReference100x100.png"));
            //Create a Panel within the Tab
            //Create Push Button Data to create the Push button from
            PushButtonData pbdLineLoadButton = new PushButtonData("cmdLineLoad", "LineLoad", AssemblyPath, "HelloRevitApplication.Commands.AutoLineLoads");
            //Set Button Image
            pbdLineLoadButton.LargeImage = ButtonImageLineLoad;
            //Set Button Tool Tips
            pbdLineLoadButton.ToolTip = "Tạo Line Load";
            //Set Button Long description which is the text that flys out when you hover on a button longer
            pbdLineLoadButton.LongDescription = "Chọn dầm cần đặt tải trọng";

            //Arae Load
            BitmapImage ButtonImageAraeLoad = new BitmapImage(new Uri(@"C:\Bathanh\Contents\Resources\ChangeViewReference100x100.png"));
            //Create a Panel within the Tab
            //Create Push Button Data to create the Push button from
            PushButtonData pbdAraeLoadButton = new PushButtonData("cmdAreaLoad", "AraeLoad", AssemblyPath, "HelloRevitApplication.Commands.AutoAreaLoads");
            //Set Button Image
            pbdAraeLoadButton.LargeImage = ButtonImageLineLoad;
            //Set Button Tool Tips
            pbdAraeLoadButton.ToolTip = "Tạo Area Load";
            //Set Button Long description which is the text that flys out when you hover on a button longer
            pbdAraeLoadButton.LongDescription = "Chọn sàn cần đặt tải trọng";



            //Loads
            BitmapImage ButtonImageLoads = new BitmapImage(new Uri(@"C:\Bathanh\Contents\Resources\ChangeViewReference100x100.png"));
            //Create a Panel within the Tab
            RibbonPanel RibbonPanelLoads = application.CreateRibbonPanel(TabName, "Loads");
            PulldownButtonData pulldownButtonDataLoads = new PulldownButtonData("pulldownButtonDataLoads", "Loads");
            PulldownButton pulldownButtonLoads = RibbonPanelLoads.AddItem(pulldownButtonDataLoads) as PulldownButton;

            pulldownButtonLoads.LargeImage = ButtonImageLoads;
            pulldownButtonLoads.AddPushButton(pbdLineLoadButton);
            pulldownButtonLoads.AddPushButton(pbdAraeLoadButton);

        }
    }
}
