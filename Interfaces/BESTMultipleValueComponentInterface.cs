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
    
    public interface BESTMultipleValueComponentInterface

    {// An Interface for Components where multiple values can be input by the user

        List<string> selectedValues { get; }
    }
}
