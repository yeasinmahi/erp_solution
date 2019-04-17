using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Utility
{
    public static class GridViewUtil
    {
        public static GridViewRow GetCurrentGridViewRowOnButtonClick(object sender)
        {
            return (GridViewRow) ((Button) sender).NamingContainer;
        }
        public static GridViewRow GetCurrentGridViewRowOnTextboxChanged(object sender)
        {
            return (GridViewRow)((TextBox)sender).NamingContainer;
        }
        public static GridViewRow GetCurrentGridViewRow(GridView gridView, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            return gridView.Rows[rowIndex];
        }
        public static BoundField CreateBoundField(string headerText, string value)
        {
            BoundField field = new BoundField
            {
                HeaderText = headerText,
                DataField = value
            };
            return field;

        }
        public static BoundField CreateBoundField(string value)
        {
            BoundField field = new BoundField
            {
                HeaderText = value.ToTitle(),
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

        public static GridView CreateGridView(DataTable dataTable)
        {
            GridView gridView = new GridView();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>()
                .Select(x => x.ColumnName)
                .ToArray();
            foreach (string columnName in columnNames)
            {
                gridView.Columns.Add(CreateBoundField(columnName));
            }
            gridView.DataSource = dataTable;
            gridView.DataBind();
            return gridView;
        }
        public static bool LoadGridwithXml(string xmlString, GridView gridView, out string message)
        {
            try
            {
                StringReader sr = new StringReader(xmlString);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridView.DataSource = ds;
                }
                else
                {
                    gridView.DataSource = "";
                }
                gridView.DataBind();
                message = "Successfully Load GridView";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }
        public static bool Loads(this GridView gridView, DataTable dataTable)
        {
            if (gridView == null) return false;
            if (dataTable == null) return false;
            
            gridView.DataSource = dataTable;
            gridView.DataBind();
            return true;
        }

        public static DataTable InitDataTable(object obj)
        {
            DataSet sampleDataSet = new DataSet {Locale = CultureInfo.InvariantCulture};
            DataTable sampleDataTable = sampleDataSet.Tables.Add("TblDaynamic");

            PropertyInfo[] propertyInfos = Common.GetProperties(obj);
            foreach (PropertyInfo p in propertyInfos)
            {
                sampleDataTable.Columns.Add(p.Name, typeof(string));
            }
            return sampleDataTable;

            //sampleDataTable.Columns.Add("intMasterId", typeof(string));
            //sampleDataTable.Columns.Add("strItemName", typeof(string));
            //for (int i = 1; i <= 49; i++)
            //{
            //    var sampleDataRow = sampleDataTable.NewRow();
            //    sampleDataRow["intMasterId"] = "Cell1: " + i.ToString(CultureInfo.CurrentCulture);
            //    sampleDataRow["strItemName"] = "Cell2: " + i.ToString(CultureInfo.CurrentCulture);
            //    sampleDataTable.Rows.Add(sampleDataRow);
            //}

            //return sampleDataTable;
        }

        
        public static bool UnLoad(this GridView gridView)
        {
            try
            {
                gridView.DataSource = null;
                gridView.DataBind();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
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
        public CreateItemTemplate(ListItemType item, ControlType type)
        {
            myListItemType = item;
            controlType = type;
        }

        //Overwrite the InstantiateIn() function of the ITemplate interface.
        public void InstantiateIn(Control container)
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
