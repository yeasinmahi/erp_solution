using System.Data;
using System.Data.SqlClient;

namespace ServiceGateWay
{
    public class ItemDal : ConnectionManager
    {
        public ItemDal() :base(DbConnectionName.Inventory)
        {
            
        }

        public void GetItems()
        {

            Query = "select * from ERP_Inventory.dbo.tblItemList";
            Command.CommandText = Query;
            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    string a = Reader["intItemID"].ToString();
                    string b = Reader["strItemName"].ToString();
                }
            }

            finally
            {
                Reader?.Close();

                Connection.Close();
            }
        }

        public void InsertItem(DataTable dt)
        {
            using (SqlBulkCopy copy = new SqlBulkCopy(Connection))
            {
                copy.ColumnMappings.Add(0, 0);
                copy.ColumnMappings.Add(1, 1);
                copy.ColumnMappings.Add(2, 2);
                copy.ColumnMappings.Add(3, 3);
                copy.ColumnMappings.Add(4, 4);
                copy.DestinationTableName = "Censis";
                copy.WriteToServer(dt);
            }
        }


    }
}
