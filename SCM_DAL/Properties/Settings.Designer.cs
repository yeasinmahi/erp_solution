﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCM_DAL.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_Inventory;Persist Security Info=True;User ID" +
            "=sqlrw;Password=RWsql@123")]
        public string ERP_InventoryConnectionString {
            get {
                return ((string)(this["ERP_InventoryConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_HR;Persist Security Info=True;User ID=sqlrw;" +
            "Password=RWsql@123")]
        public string ERP_HRConnectionString {
            get {
                return ((string)(this["ERP_HRConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_SAD;Persist Security Info=True;User ID=sqlrw" +
            ";Password=RWsql@123")]
        public string ERP_SADConnectionString {
            get {
                return ((string)(this["ERP_SADConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql;Initial Catalog=ERP_Payment;User ID=sqlrw;Password=RWsql@123")]
        public string ERP_PaymentConnectionString {
            get {
                return ((string)(this["ERP_PaymentConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql;Initial Catalog=ERP_FTP;User ID=sqlrw;Password=RWsql@123")]
        public string ERP_FTPConnectionString {
            get {
                return ((string)(this["ERP_FTPConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_Accounts;Persist Security Info=True;User ID=" +
            "sqlrw;Password=RWsql@123")]
        public string ERP_AccountsConnectionString {
            get {
                return ((string)(this["ERP_AccountsConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql;Initial Catalog=AG_Global;User ID=sqlrw;Password=RWsql@123")]
        public string AG_GlobalConnectionString {
            get {
                return ((string)(this["AG_GlobalConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_VAT;Persist Security Info=True;User ID=sqlrw" +
            ";Password=RWsql@123")]
        public string ERP_VATConnectionString {
            get {
                return ((string)(this["ERP_VATConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql;Initial Catalog=AG_WastageMaterial;Persist Security Info=True;Us" +
            "er ID=sqlrw;Password=RWsql@123")]
        public string AG_WastageMaterialConnectionString {
            get {
                return ((string)(this["AG_WastageMaterialConnectionString"]));
            }
        }
    }
}
