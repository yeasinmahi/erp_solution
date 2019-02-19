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

    }
}
