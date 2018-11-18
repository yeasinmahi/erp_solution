namespace Utility
{
    public class ProjectConfig
    {
        private static ProjectConfig _instance;
        private ProjectConfig() { }

        public static ProjectConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProjectConfig();
                }
                return _instance;
            }
        }

        public string MudulaLocalFileBasePath { get; set; }
        public string MudulaRemoteFileBasePath { get; set; }
    }
}
