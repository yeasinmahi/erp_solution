using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DAL.Accounts.Banking.Counter;
using DAL.Accounts.Banking.Counter.BoothSignTDSTableAdapters;
using System.Data;
using System.Threading;

namespace BLL.Accounts.Banking.Counter
{
    public static class ChqReceiveST
    {
        private static BoothSignTDS.TblBoothSignDataDataTable[] table = null;
        private static Hashtable ht = new Hashtable();
        
        private static void Inatialize()
        {

            if (table == null)
            {
                Booth bt = new Booth();
                BoothTDS.TblBoothDataTable tblBt = bt.GetAllActiveBooths();

                ht = new Hashtable();

                table = new BoothSignTDS.TblBoothSignDataDataTable[tblBt.Rows.Count];

                TblBoothSignDataTableAdapter adpCOA = new TblBoothSignDataTableAdapter();


                for (int i = 0; i < tblBt.Rows.Count; i++)
                {
                    ht.Add(tblBt[i].intId.ToString(), i);
                    table[i] = adpCOA.GetDataByBooth(tblBt[i].intId, true);
                }
            }
        }

        public static string GetBoothsDataForSIgnature(string boothID)
        {
            Inatialize();
            DataTable tbl = new DataTable();


            var rows = from tmp in table[Convert.ToInt32(ht[boothID])]//Convert.ToInt32(ht[unitID])                                                                             
                       orderby tmp.dteInsertionTime
                       select tmp;
            
            if (rows.Count() > 0)
            {
                tbl = rows.CopyToDataTable();
            }

            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows[0]["intId"].ToString();
            }
            else
            {
                return "";
            }
        }
        
        public static void ReloadBoothsDataForSIgnature(string boothID)
        {
            Inatialize();
            TblBoothSignDataTableAdapter adpCOA = new TblBoothSignDataTableAdapter();
            table[Convert.ToInt32(ht[boothID])] = adpCOA.GetDataByBooth(int.Parse(boothID), true);            
        }
    }
}
