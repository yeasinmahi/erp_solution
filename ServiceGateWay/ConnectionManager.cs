using System.Data.SqlClient;

namespace ServiceGateWay
{
    public class ConnectionManager
    {
        protected SqlConnection Connection { get; set; }
        protected SqlCommand Command { get; set; }
        protected SqlDataReader Reader { get; set; }
        protected string Query { get; set; }

        //public ConnectionManager()
        //{
        //    Connection = new SqlConnection(GetConnectionString(DbConnectionName.Hr));
        //    Command = new SqlCommand { Connection = Connection };
        //}
        public ConnectionManager(DbConnectionName dbConnectionName)
        {
            Connection = new SqlConnection(GetConnectionString(dbConnectionName));
            Command = new SqlCommand {Connection = Connection};
        }


        public enum DbConnectionName
        {
            Inventory,
            Hr
        }
        protected string GetConnectionString(DbConnectionName dbConnectionName)
        {
            switch (dbConnectionName)
            {
                case DbConnectionName.Inventory:
                    return Properties.Settings.Default.ERP_InventoryConnectionString;
                case DbConnectionName.Hr:
                    return Properties.Settings.Default.ERP_HRConnectionString;
                default:
                    return Properties.Settings.Default.AG_GlobalConnectionString;
            }
        }
    }
}
