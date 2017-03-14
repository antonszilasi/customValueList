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

        private readonly Guid ID = new Guid("{f0a735ba-5fb5-43b7-a4c4-fe9e6df05b62}");

        public CustomValueList() : base()
        {

            this.ListMode = Grasshopper.Kernel.Special.GH_ValueListMode.DropDown;
            this.Description = "The BEST Value List";
            this.Name = "The BBEST Value List";
            this.Category = "Testing";

            base.ListItems.Clear();

            this.ListItems = new List<GH_ValueListItem>();

            base.ListItems.Add(new GH_ValueListItem("21", "21"));
            base.ListItems.Add(new GH_ValueListItem("22", "22"));
            this.ListItems.Add(new GH_ValueListItem("23", "23"));
            this.ListItems.Add(new GH_ValueListItem("24", "24"));
            this.ListItems.Add(new GH_ValueListItem("25", "25"));
            this.ListItems.Add(new GH_ValueListItem("26", "26"));
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
            this.m_attributes = new CustomValueListAttributes(this);
        }

    }
}
