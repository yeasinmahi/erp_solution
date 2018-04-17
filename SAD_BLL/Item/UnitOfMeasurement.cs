using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace SAD_BLL.Item
{
    public class UnitOfMesurement
    {
        public UnitOfMesurement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private object[] GetUOMlist()
        {            
            ArrayList arr = new ArrayList();
            //Never change the values but can change the text or boolean values.
            arr.Add(AddToUOMClass("Size", "1", false, true));
            arr.Add(AddToUOMClass("Weight", "2", true, true));
            arr.Add(AddToUOMClass("Piece", "3", true, false));
            arr.Add(AddToUOMClass("Lot", "4", true, false));
            arr.Add(AddToUOMClass("Volume", "5", true, true));
            arr.Add(AddToUOMClass("SQR FT", "6", true, false));
            return arr.ToArray();
        }

        private ItemUOM AddToUOMClass(string text, string value, bool isShowInSell, bool isShowInUOM)
        {
            ItemUOM uom = new ItemUOM();

            uom.Text = text;
            uom.Value = value;
            uom.IsShowInSell = isShowInSell;
            uom.IsShowInUOM = isShowInUOM;

            return uom;
        }

         public ListItemCollection GetAllUnitOfMeasurementForBOM(string selectedUOM)
         {
             ListItemCollection unitOfMeasurementsForBOM = new ListItemCollection();
             //Never Change these values. Can up down or change text
             switch (selectedUOM)
             {
                 case "1":
                     unitOfMeasurementsForBOM.Add(new ListItem("SQR. FT", "11"));
                     unitOfMeasurementsForBOM.Add(new ListItem("SQR. IN", "12"));
                     break;
                 case "2":
                     unitOfMeasurementsForBOM.Add(new ListItem("KG", "21"));
                     unitOfMeasurementsForBOM.Add(new ListItem("GR", "22"));
                     break;
                 case "3":
                     unitOfMeasurementsForBOM.Add(new ListItem("PC", "31"));                
                     break;
                 case "5":
                     unitOfMeasurementsForBOM.Add(new ListItem("CM", "51"));
                     break;
             }
             return unitOfMeasurementsForBOM;
         }

        public ListItemCollection GetSafetyStockInfo()
        {
            ListItemCollection sizes = new ListItemCollection();

            sizes.Add(new ListItem("Day", "1"));
            sizes.Add(new ListItem("Percent", "2"));

            return sizes;
        }
        public ListItemCollection GetSizeInfo()
        {
            ListItemCollection sizes = new ListItemCollection();

            sizes.Add(new ListItem("IN", "1"));
            sizes.Add(new ListItem("FT", "2"));
            sizes.Add(new ListItem("MM", "3"));
            sizes.Add(new ListItem("CM", "4"));

            return sizes;
        }
        public ListItemCollection GetWeightInfo()
        {
            ListItemCollection sizes = new ListItemCollection();

            sizes.Add(new ListItem("KG", "1"));
            sizes.Add(new ListItem("GM", "2"));

            return sizes;
        }
        public ListItemCollection GetVolumeInfo()
        {
            ListItemCollection sizes = new ListItemCollection();

            sizes.Add(new ListItem("CM", "1"));

            return sizes;
        }
        public ListItemCollection GetAllUnitOfMeasurementForSelling()
        {
            ListItemCollection unitOfMeasurements = new ListItemCollection();

            object[] uoms = GetUOMlist();
            foreach (ItemUOM uom in uoms)
            {
                if (uom.IsShowInSell) unitOfMeasurements.Add(new ListItem(uom.Text, uom.Value));
            }

            return unitOfMeasurements;
        }

        public ListItemCollection GetAllUnitOfMeasurement()
        {
            ListItemCollection unitOfMeasurements = new ListItemCollection();

            object[] uoms = GetUOMlist();
            foreach (ItemUOM uom in uoms)
            {
                if (uom.IsShowInUOM) unitOfMeasurements.Add(new ListItem(uom.Text, uom.Value));
            }

            return unitOfMeasurements;
        }
    }

    class ItemUOM
    {
        private string text;
        private string value_;
        private bool isShowInSell;
        private bool isShowInUOM;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public string Value
        {
            get { return value_; }
            set { value_ = value; }
        }

        public bool IsShowInSell
        {
            get { return isShowInSell; }
            set { isShowInSell = value; }
        }

        public bool IsShowInUOM
        {
            get { return isShowInUOM; }
            set { isShowInUOM = value; }
        }

    }
}
