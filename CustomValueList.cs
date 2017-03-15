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
    public class CustomValueList : Grasshopper.Kernel.Special.GH_ValueList
    {
        public new List<GH_ValueListItem> ListItems;

        public GH_ValueListAttributes instanceAttributes;

        private readonly Guid ID = new Guid("{f0a735ba-5fb5-43b7-a4c4-fe9e6df05b62}");

        public CustomValueList() : base()
        {

            this.ListMode = Grasshopper.Kernel.Special.GH_ValueListMode.DropDown;
            this.Description = "The BEST Value List";
            this.Name = "The BBEST Value List";
            this.Category = "Testing";

            base.ListItems.Clear();

            this.ListItems = new List<GH_ValueListItem>();

            //base.ListItems.Add(new GH_ValueListItem("21", "21"));
            //base.ListItems.Add(new GH_ValueListItem("22", "22"));
            base.ListItems.Add(new GH_ValueListItem("23", "23"));
            base.ListItems.Add(new GH_ValueListItem("24", "24"));
            base.ListItems.Add(new GH_ValueListItem("25", "25"));
            base.ListItems.Add(new GH_ValueListItem("26", "26"));
            base.ListItems.Add(new GH_ValueListItem("27", "27"));
        }

        public override bool AppendMenuItems(ToolStripDropDown menu)
        {
            this.Menu_AppendObjectName(menu);

            this.Menu_AppendEnableItem(menu);

            this.AppendAdditionalMenuItems(menu);

            this.Menu_AppendObjectHelp(menu);

            return true;
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
        }

        public override Guid ComponentGuid
        {
            get
            {
                return ID;
            }
        }

        public new List<Grasshopper.Kernel.Special.GH_ValueListItem> SelectedItems
        {// Allow user to select multiple items unlike the default GH_ValueList
            get
            {
                List<GH_ValueListItem> list = new List<GH_ValueListItem>();

                if (this.ListItems.Count != 0)
                {
                    foreach (Grasshopper.Kernel.Special.GH_ValueListItem item in this.ListItems)
                    {
                        if (item.Selected)
                        {
                            list.Add(item);
                        }
                    }
                    return list;
                }
                return list;
            }
        }

        public override void CreateAttributes()
        {
            CustomValueListAttributes instanceAttributes = new CustomValueListAttributes(this);

            foreach (GH_ValueListItem item in base.ListItems)
            {
                ToolStripMenuItem ToolStripItem = new ToolStripMenuItem(item.Name);
                ToolStripItem.Click += new EventHandler(this.ValueMenuItem_Click);
                ToolStripItem.MouseLeave += new EventHandler(MouseLeave);
                ToolStripItem.MouseEnter += new EventHandler(MouseEnter);

                instanceAttributes.collectionToolStripMenuItems.Add(ToolStripItem);
            }

            this.instanceAttributes = instanceAttributes;

            base.m_attributes = this.instanceAttributes;
        }

        private void ValueMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item2 = (ToolStripMenuItem)sender;
            if (!item2.Checked)
            {
                item2.Checked = true;

                ToolStripDropDownMenu menu = (ToolStripDropDownMenu)item2.Owner;
                menu.Show();

                return;
            }
            else
            {
                item2.Checked = false;

                ToolStripDropDownMenu menu = (ToolStripDropDownMenu)item2.Owner;
                menu.Show();

                return;
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            ToolStripMenuItem item2 = (ToolStripMenuItem)sender;
            ToolStripDropDownMenu menu = (ToolStripDropDownMenu)item2.Owner;
            menu.Hide();
        }

        private void MouseEnter(object sender,EventArgs e)
        {
            ToolStripMenuItem item2 = (ToolStripMenuItem)sender;
            ToolStripDropDownMenu menu = (ToolStripDropDownMenu)item2.Owner;
            menu.Show();
        }
    }
}
