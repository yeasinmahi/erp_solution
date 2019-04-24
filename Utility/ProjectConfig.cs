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
                Path.GetFullPath(rootPath + "HR\\Data"),
                Path.GetFullPath(rootPath + "SCM\\Data"),
                Path.GetFullPath(rootPath + "SCM\\Uploads"),
                Path.GetFullPath(rootPath + "Inventory\\Data")
            };

            return folders;
        }
    }
}
