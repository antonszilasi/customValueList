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

    public interface BESTDashboardInterface

    {// Interface for components that will be on the BESTDashboard
        GH_Document OnPingDocument();
    }
}
