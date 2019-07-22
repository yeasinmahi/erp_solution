using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public class ProjectConfig
    {
        private static ProjectConfig _instance;
        private ProjectConfig() { }

        public static ProjectConfig Instance => _instance ?? (_instance = new ProjectConfig());

        public string MudulaLocalFileBasePath { get; set; }
        public string MudulaRemoteFileBasePath { get; set; }
        public List<string> GetFolderList(string rootPath)
        {
            List<string> folders = new List<string>
            {
                Path.GetFullPath(rootPath + "Accounts\\Advice\\Data"),
                Path.GetFullPath(rootPath + "Accounts\\PartyPayment\\Data"),
                Path.GetFullPath(rootPath + "Accounts\\Voucher\\Data"),
                Path.GetFullPath(rootPath + "Accounts\\Voucher\\Uploads"),
                Path.GetFullPath(rootPath + "Accounts\\Import\\Data"),

                Path.GetFullPath(rootPath + "AEFPS\\Data"),
                Path.GetFullPath(rootPath + "Asset\\Data"),
                Path.GetFullPath(rootPath + "Asset\\Uploads"),

                Path.GetFullPath(rootPath + "BudgetPlan\\Data"),
                Path.GetFullPath(rootPath + "CreativeSupportModule\\Data"),
                Path.GetFullPath(rootPath + "Dairy\\Data"),
                Path.GetFullPath(rootPath + "Dairy\\Uploads"),

                Path.GetFullPath(rootPath + "HR\\Benifit\\Data"),
                Path.GetFullPath(rootPath + "HR\\Dispatch\\Data"),
                Path.GetFullPath(rootPath + "HR\\DocumentTracking\\Data"),
                Path.GetFullPath(rootPath + "HR\\DocumentTracking\\Uploads"),
                Path.GetFullPath(rootPath + "HR\\Employee\\Upload"),
                Path.GetFullPath(rootPath + "HR\\HolidayCalendar\\Holiday"),
                Path.GetFullPath(rootPath + "HR\\Internal\\Uploads"),
                Path.GetFullPath(rootPath + "HR\\IssuedLetter\\Data"),
                Path.GetFullPath(rootPath + "HR\\KPI\\Data"),
                Path.GetFullPath(rootPath + "HR\\KPI\\Uploads"),
                Path.GetFullPath(rootPath + "HR\\Loan\\Data"),
                Path.GetFullPath(rootPath + "HR\\Penalty\\Data"),
                Path.GetFullPath(rootPath + "HR\\Reports\\Data"),
                Path.GetFullPath(rootPath + "HR\\Salary\\FileExcell"),
                Path.GetFullPath(rootPath + "HR\\Settlement\\Uploads"),
                Path.GetFullPath(rootPath + "HR\\TourPlan\\Data"),
                Path.GetFullPath(rootPath + "HR\\TourPlan\\Tour"),

                Path.GetFullPath(rootPath + "Import\\Data"),
                Path.GetFullPath(rootPath + "Inventory\\Data"),
                Path.GetFullPath(rootPath + "Libray\\SqlServerTypes"),

                Path.GetFullPath(rootPath + "MedialManagement\\Data"),
                Path.GetFullPath(rootPath + "New_Project\\QC_Management\\Uploads"),
                Path.GetFullPath(rootPath + "Other\\Data"),

                Path.GetFullPath(rootPath + "PaymentModule\\Data"),
                Path.GetFullPath(rootPath + "Personal\\Data"),
                Path.GetFullPath(rootPath + "Personal\\Uploads"),
                Path.GetFullPath(rootPath + "Projects\\Data"),

                Path.GetFullPath(rootPath + "SAD\\Consumer\\Data"),
                Path.GetFullPath(rootPath + "SAD\\Consumer\\Data"),
                Path.GetFullPath(rootPath + "SAD\\Corporate_sales\\Data"),
                Path.GetFullPath(rootPath + "SAD\\ExcelChallan\\Data"),
                Path.GetFullPath(rootPath + "SAD\\IHB\\Data"),
                Path.GetFullPath(rootPath + "SAD\\Order\\Data"),
                Path.GetFullPath(rootPath + "SAD\\Order\\Data\\CH"),
                Path.GetFullPath(rootPath + "SAD\\Order\\Data\\DO"),
                Path.GetFullPath(rootPath + "SAD\\Order\\Data\\OR"),
                Path.GetFullPath(rootPath + "SAD\\Order\\Uploads"),
                Path.GetFullPath(rootPath + "SAD\\Transfer\\Data"),
                Path.GetFullPath(rootPath + "SAD\\Vat\\Data"),

                Path.GetFullPath(rootPath + "SCM\\Data"),
                Path.GetFullPath(rootPath + "SCM\\Uploads"),

                Path.GetFullPath(rootPath + "Shop\\Data"),
                Path.GetFullPath(rootPath + "Support\\Data"),

                Path.GetFullPath(rootPath + "Transport\\Data"),
                Path.GetFullPath(rootPath + "Transport\\Uploads"),

                Path.GetFullPath(rootPath + "VAT_Management\\Data"),
                Path.GetFullPath(rootPath + "Wastage\\Data"),
                Path.GetFullPath(rootPath + "WoodPurchase\\Data"),

                Path.GetFullPath(rootPath + "Property\\Data"),
                Path.GetFullPath(rootPath + "Property\\Files"),
            };

            return folders;
        }
        public string GetFtpBaseUrl()
        {
            return "ftp://ftp.akij.net/";
        }
    }
}
