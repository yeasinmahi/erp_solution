﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ProjectConfig
    {
        private static ProjectConfig instance;
        private ProjectConfig() { }

        public static ProjectConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectConfig();
                }
                return instance;
            }
        }

        public string MudulaLocalFileBasePath { get; set; }
        public string MudulaRemoteFileBasePath { get; set; }
    }
}