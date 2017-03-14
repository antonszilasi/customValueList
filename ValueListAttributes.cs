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
        private CustomValueList ownerOfThisAttribute;

        public CustomValueListAttributes(GH_ValueList owner) : base(owner)
        {
            //this.ownerOfThisAttribute = owner;
        }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {
            base.Render(canvas, graphics, channel);
        }

        protected override void Layout()
        {
            base.Layout();
        }

        public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            return GH_ObjectResponse.Ignore;
        }

        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToolStripDropDownMenu menu = new ToolStripDropDownMenu();

                foreach (GH_ValueListItem item in this.ownerOfThisAttribute.ListItems)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(item.Name);
                    //menuItem.Tag = item.Name;
                    menuItem.Click += new EventHandler(this.ValueMenuItem_Click);

                    menu.Items.Add(menuItem);
                }

                menu.Show(sender, e.ControlLocation);
                return GH_ObjectResponse.Handled;
            }
            return base.RespondToMouseDown(sender, e);
        }

        private void ValueMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item2 = (ToolStripMenuItem)sender;
            if (!item2.Checked)
            {
                //item2.Checked = true;
                item2.CheckState = CheckState.Checked;
                //GH_ValueListItem tag = new GH_ValueListItem(item2.Name.ToString(), item2.Name.ToString());
                //if (tag != null)
                //{
                //    this.ownerOfThisAttribute.SelectItem(this.Owner.ListItems.IndexOf(tag));
                //}
            }
            else
            {
                item2.CheckState = CheckState.Unchecked;
            }
        }
    }
}
