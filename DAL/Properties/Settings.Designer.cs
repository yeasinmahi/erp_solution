﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_Accounts;Persist Security Info=True;User ID=" +
            "rNwUs@Ag;Password=a2sLs@Ag")]
        public string ERP_AccountsConnectionString {
            get {
                return ((string)(this["ERP_AccountsConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_HR;Persist Security Info=True;User ID=rNwUs@" +
            "Ag;Password=a2sLs@Ag")]
        public string ERP_HRConnectionString {
            get {
                return ((string)(this["ERP_HRConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_Inventory;User ID=rNwUs@Ag;Password=a2sLs@Ag" +
            "")]
        public string ERP_InventoryConnectionString {
            get {
                return ((string)(this["ERP_InventoryConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_SAD;Persist Security Info=True;User ID=rNwUs" +
            "@Ag;Password=a2sLs@Ag")]
        public string ERP_SADConnectionString {
            get {
                return ((string)(this["ERP_SADConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_VAT;User ID=rNwUs@Ag;Password=a2sLs@Ag")]
        public string ERP_VATConnectionString {
            get {
                return ((string)(this["ERP_VATConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=ERP_Payment;Persist Security Info=True;User ID=r" +
            "NwUs@Ag;Password=a2sLs@Ag")]
        public string ERP_PaymentConnectionString {
            get {
                return ((string)(this["ERP_PaymentConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ESQL;Initial Catalog=AG_Global;User ID=rNwUs@Ag;Password=a2sLs@Ag")]
        public string AG_GlobalConnectionString {
            get {
                return ((string)(this["AG_GlobalConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql3;Initial Catalog=ERP_Accounts;Persist Security Info=True;User ID" +
            "=rNwUs@Ag;Password=a2sLs@Ag")]
        public string ERP_AccountsConnectionStringEsql3 {
            get {
                return ((string)(this["ERP_AccountsConnectionStringEsql3"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql;Initial Catalog=AFBLSMSServer;Persist Security Info=True;User ID" +
            "=rNwUs@Ag;Password=a2sLs@Ag")]
        public string AFBLSMSServerConnectionString {
            get {
                return ((string)(this["AFBLSMSServerConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=esql;Initial Catalog=ERP_MIS;Persist Security Info=True;User ID=rNwUs" +
            "@Ag;Password=a2sLs@Ag")]
        public string ERP_MISConnectionString {
            get {
                return ((string)(this["ERP_MISConnectionString"]));
            }
        }
    }
}
