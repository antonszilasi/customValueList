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
    
    public interface BESTSingularValueComponent

    {// An Interface for Components where only a singular value needs to be input by the user

        string selectedValue { get; }
    }
}
