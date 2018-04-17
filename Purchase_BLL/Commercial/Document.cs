using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Purchase_DAL.Commercial.DocumentTDSTableAdapters;
using Purchase_DAL.Commercial;

namespace Purchase_BLL.Commercial
{
   public  class Document
    {
       public ListItemCollection GetDocumentType()
       {
           ListItemCollection col = new ListItemCollection();
           TblCommercialDocumentTableAdapter adp = new TblCommercialDocumentTableAdapter();
           DocumentTDS.TblCommercialDocumentDataTable tbl = adp.GetDoucumentTypeData();
           for (int i = 0; i < tbl.Rows.Count; i++)
           {
               col.Add(new ListItem(tbl[i].strDocumentName, tbl[i].intDocumentID.ToString()));
           }

           return col;
       }

       public string GetImageURLForDocument(int lcID, int shipmentID, int docTypeID,int pageNumber,ref int? totalpage)
       {
           string imgURL = "";
           SprCommercialDocummentGetImagePathTableAdapter adp = new SprCommercialDocummentGetImagePathTableAdapter();
           DocumentTDS.SprCommercialDocummentGetImagePathDataTable tbl = adp.GetDocumentInagePathData(lcID, shipmentID, docTypeID,ref totalpage);

           try
           {
               imgURL = tbl[pageNumber-1].strFTPPath;
           }
           catch
           {
               imgURL = "";
           }
           return imgURL;
       }
    }
}
