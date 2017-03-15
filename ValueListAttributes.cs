using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Grasshopper;
using Grasshopper.GUI;
using Grasshopper.Kernel;
using Grasshopper.Plugin;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel.Attributes;
using GH_IO.Serialization;
using Grasshopper.Kernel.Special;

namespace CustomValueList
{
    public class CustomValueListAttributes : GH_ValueListAttributes
    {
        public CustomValueList ownerOfThisAttribute;

        public List<ToolStripMenuItem> collectionToolStripMenuItems;

        public CustomValueListAttributes(CustomValueList owner) : base(owner)
        {
            this.ownerOfThisAttribute = owner;

            this.collectionToolStripMenuItems = new List<ToolStripMenuItem>();
        }

        public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            return GH_ObjectResponse.Ignore;
        }

        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Grasshopper.Kernel.Special.GH_ValueListItem firstSelectedItem = this.Owner.FirstSelectedItem;
                if (firstSelectedItem.BoxRight.Contains(e.CanvasLocation))
                 {  ToolStripDropDownMenu menu = new ToolStripDropDownMenu();
                    menu.AutoClose = true;

                    foreach (ToolStripMenuItem toolStripItem in this.collectionToolStripMenuItems)
                    {
                        menu.Items.Add(toolStripItem);
                    }

                    menu.Show(sender, e.ControlLocation);
                        
                    return GH_ObjectResponse.Handled;
                }
            }
            return base.RespondToMouseDown(sender, e);
        }
    }
}
