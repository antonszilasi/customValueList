using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Geometry;
using Grasshopper;
using Grasshopper.Kernel;
using System.Windows.Forms;

namespace BEST
{ 
    
    public interface ReadJsonInterface

    {// Interface for classes that read JSon files
        void readJsonFile();
    }
}
