using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Utility
{
    public class GridViewUtil
    {
        public static BoundField CreateBoundField(string headerText, string value)
        {
            BoundField field = new BoundField
            {
                HeaderText = headerText,
                DataField = value
            };
            return field;

        }
        public static GridView RemoveGridColumn(GridView gridView)
        {
            for (int i = 2; i < gridView.Columns.Count;)
            {
                gridView.Columns.RemoveAt(i);
            }
            return gridView;
        }

    }
    public class CreateItemTemplate : ITemplate
    {
        public enum ControlType
        {
            Sl,
            Label,
            CheckBox,
            TextBox
        }
        //Field to store the ListItemType value
        private ListItemType myListItemType;

        private ControlType controlType;
        public CreateItemTemplate()
        {
            //
            // TODO: Add default constructor logic here
            //
        }

        //Parameterrised constructor
        public CreateItemTemplate(ListItemType Item, ControlType type)
        {
            myListItemType = Item;
            controlType = type;
        }

        //Overwrite the InstantiateIn() function of the ITemplate interface.
        public void InstantiateIn(System.Web.UI.Control container)
        {
            //Code to create the ItemTemplate and its field.

            if (myListItemType == ListItemType.Item)
            {
                switch (controlType)
                {
                    case ControlType.Label:
                        Label label = new Label();
                        container.Controls.Add(label);
                        break;
                    case ControlType.CheckBox:
                        CheckBox checkBox = new CheckBox();
                        checkBox.ID = "chkbx";
                        container.Controls.Add(checkBox);
                        break;
                    case ControlType.TextBox:
                        TextBox textBox = new TextBox();
                        container.Controls.Add(textBox);
                        break;
                    case ControlType.Sl:
                        Label sl = new Label();
                        container.Controls.Add(sl);
                        break;

                }
            }else if (myListItemType == ListItemType.Header)
            {
                switch (controlType)
                {
                    case ControlType.CheckBox:
                        CheckBox checkBox = new CheckBox();
                        checkBox.ID = "chkbxAll";
                        container.Controls.Add(checkBox);
                        break;
                }
            }
        }

    }
}
