using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Globalization;

namespace XPSParser
{
    public class ParseXPS
    {
        JBTDS.TblJBDataTable tblData = new JBTDS.TblJBDataTable();
        int count = 1, page = 0, preCount, doc = 0;

        public JBTDS.TblJBDataTable GetDataForJanataBank(string filePath)
        {
            if (filePath == "" || filePath == null) return null;
            doc = 0;
            page = 0;

            
            XpsDocument xd = new XpsDocument(filePath, System.IO.FileAccess.Read);

            IXpsFixedDocumentSequenceReader fixedDocSeqReader = xd.FixedDocumentSequenceReader;

            ICollection<IXpsFixedDocumentReader> fixedDocuments = fixedDocSeqReader.FixedDocuments;

            IEnumerator<IXpsFixedDocumentReader> enumerator = fixedDocuments.GetEnumerator();


            while (enumerator.MoveNext())
            {
                doc++;

                ICollection<IXpsFixedPageReader> fixedPages = enumerator.Current.FixedPages;

                IEnumerator<IXpsFixedPageReader> enumeratorP = fixedPages.GetEnumerator();

                while (enumeratorP.MoveNext())
                {
                    page++;

                    count = 1;

                    DataRow[] resultPre = new DataRow[0];

                    if (page > 1)
                    {
                        resultPre = tblData.Select("((numDrAmount = 0 AND numCrAmount = 0) OR numBal = 0) AND  intPage = " + (page - 1));
                    }

                    GetData(enumeratorP);

                    if (resultPre.Length > 0)
                    {
                        preCount = int.Parse(resultPre[0][1].ToString());

                        DataRow[] result = tblData.Select("dteDate is null AND numBal <> 0 AND  intPage = " + page);

                        if (result.Length > 0)
                        {
                            resultPre[0][6] = result[0][6];
                            resultPre[0][7] = result[0][7];
                            resultPre[0][8] = result[0][8];
                        }
                    }
                }
            }

            DataRow[] resultD = tblData.Select("dteDate is null");

            for (int i = 0; i < resultD.Length; i++)
            {
                tblData.Rows.Remove(resultD[i]);
            }

            return tblData;

        }

        private void GetData(IEnumerator<IXpsFixedPageReader> enumeratorP)
        {
            XmlReader _pageContentReader = enumeratorP.Current.XmlReader;


            if (_pageContentReader != null)
            {
                decimal x = 0, y = 0;
                string accNo = "";

                DateTimeFormatInfo dtf = new DateTimeFormatInfo();
                dtf.ShortDatePattern = "dd-MMM-yyyy";

                while (_pageContentReader.Read())
                {
                    if (_pageContentReader.Name == "Glyphs")
                    {
                        if (_pageContentReader.HasAttributes)
                        {
                            if (_pageContentReader.GetAttribute("UnicodeString") != null)
                            {
                                x = decimal.Parse(_pageContentReader.GetAttribute("OriginX"));
                                y = decimal.Parse(_pageContentReader.GetAttribute("OriginY"));

                                if (y >= 130 && y <= 150 && x >= 580 && x <= 590)
                                //if (y >= 110 && y <= 120 && x >= 580 && x <= 590)
                                {
                                //if (y >= 98 && y <= 120 && x >= 575 && x <= 590)
                                //{
                                    accNo = _pageContentReader.GetAttribute("UnicodeString");
                                }

                                if (y >= 195 && y <= 992 && x >= 31 && x <= 705)
                                {
                                //if (y >= 190 && y <= 975 && x >= 24 && x <= 700)
                                //{
                                    int i = Convert.ToInt32(y);
                                    DataRow[] result = tblData.Select("numY >= " + (i - 5) + " AND numY <= " + (i + 5) + " AND intPage = " + page);

                                    if (result.Length == 0)
                                    {
                                        DataRow dr = tblData.NewRow();
                                        dr[0] = page;
                                        dr[1] = count;
                                        dr[2] = y;
                                        dr[3] = DBNull.Value;
                                        dr[4] = "";
                                        dr[5] = "";
                                        dr[6] = 0;
                                        dr[7] = 0;
                                        dr[8] = 0;

                                        tblData.Rows.Add(dr);
                                        result = tblData.Select("numY >= " + (i - 5) + " AND numY <= " + (i + 5) + " AND intPage = " + page);

                                        count++;
                                    }

                                    if (x >= 31 && x <= 41)
                                    {
                                    //if (x >= 24 && x <= 41) //Date
                                    //{
                                        try { result[0][3] = Convert.ToDateTime(_pageContentReader.GetAttribute("UnicodeString"), dtf); }
                                        catch { }
                                    }
                                    else if (x >= 103 && x <= 113) // Perticular
                                    {
                                    //else if (x >= 97 && x <= 113) // Perticular
                                    //{
                                        result[0][4] = _pageContentReader.GetAttribute("UnicodeString");
                                    }
                                    else if (x >= 360 && x <= 369) //Cheque
                                    {
                                    //else if (x >= 353 && x <= 369) //Cheque
                                    //{
                                        result[0][5] = _pageContentReader.GetAttribute("UnicodeString");
                                    }
                                    else if (x >= 510 && x <= 649) //Debit
                                    {
                                        //else if (x >= 540 && x <= 649) //credit
                                        //{
                                        string str = _pageContentReader.GetAttribute("UnicodeString");
                                        try { result[0][6] = decimal.Parse(_pageContentReader.GetAttribute("UnicodeString").Replace(",", "").Replace(" ", "")); }
                                        catch { }
                                    }
                                    else if (x >= 353 && x <= 509) // CREDIT
                                    {
                                    //else if (x >= 430 && x <= 509) // debit
                                    //{
                                        string str = _pageContentReader.GetAttribute("UnicodeString");
                                        try { result[0][7] = decimal.Parse(_pageContentReader.GetAttribute("UnicodeString").Replace(",", "").Replace(" ", "")); }
                                        catch { }
                                    }
                                    
                                    else if (x >= 650 && x <= 970) //balance
                                    {
                                    //else if (x >= 649 && x <= 970) //balance
                                    //{
                                        string str = _pageContentReader.GetAttribute("UnicodeString");
                                        try { result[0][8] = decimal.Parse(_pageContentReader.GetAttribute("UnicodeString").Replace(",", "").Replace(" ", "")); }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                }


                DataRow[] resultU = tblData.Select("intPage = " + page);
                for (int i = 0; i < resultU.Length; i++)
                {
                    resultU[i][9] = accNo;
                }

            }
        }

    }

    /*public static class Tbl
    {
        public static DataTable GetTableJB()
        {
            DataTable tblData = new DataTable("tblData");

            tblData.Columns.Add(new DataColumn("intPage"));
            tblData.Columns[0].DataType = Type.GetType("System.Int32");

            tblData.Columns.Add(new DataColumn("intCount"));
            tblData.Columns[1].DataType = Type.GetType("System.Int32");

            tblData.Columns.Add(new DataColumn("numY"));
            tblData.Columns[2].DataType = Type.GetType("System.Decimal");

            tblData.Columns.Add(new DataColumn("dteDate"));
            tblData.Columns[3].DataType = Type.GetType("System.DateTime");
            tblData.Columns[3].AllowDBNull = true;

            tblData.Columns.Add(new DataColumn("strParti"));
            tblData.Columns[4].DataType = Type.GetType("System.String");

            tblData.Columns.Add(new DataColumn("strChq"));
            tblData.Columns[5].DataType = Type.GetType("System.String");

            tblData.Columns.Add(new DataColumn("numDrAmount"));
            tblData.Columns[6].DataType = Type.GetType("System.Decimal");

            tblData.Columns.Add(new DataColumn("numCrAmount"));
            tblData.Columns[7].DataType = Type.GetType("System.Decimal");

            tblData.Columns.Add(new DataColumn("numBal"));
            tblData.Columns[8].DataType = Type.GetType("System.Decimal");

            tblData.Columns.Add(new DataColumn("strAccNo"));
            tblData.Columns[9].DataType = Type.GetType("System.String");
            tblData.Columns[9].AllowDBNull = true;

            return tblData;
        }
    }*/
}
