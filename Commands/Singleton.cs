using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRevitApplication.Commands
{
    class Singleton { 
        private RevitData revitData;
        private ViewData viewData;
        private OtherData otherData;
       

        public static Singleton Instance { get; set; }

        public RevitData RevitData { get { if (revitData == null) revitData = new RevitData(); return revitData; } }
        public ViewData ViewData { get { if (viewData == null) viewData = new ViewData(); return viewData; } }
        public OtherData OtherData { get { if (otherData == null) otherData = new OtherData(); return otherData; } }


    }
}