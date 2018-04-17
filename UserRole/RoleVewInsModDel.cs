using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Developped By Akramul Haider
/// Copyright © akram
/// </summary>
namespace UserRole
{
    public class RoleVewInsModDel
    {
        bool canInsert;
        bool canView;
        bool canModify;
        bool canDelete;

        public bool CanInsert
        {
            get { return canInsert; }
            set { canInsert = value; }
        }

        public bool CanView
        {
            get { return canView; }
            set { canView = value; }
        }

        public bool CanModify
        {
            get { return canModify; }
            set { canModify = value; }
        }

        public bool CanDelete
        {
            get { return canDelete; }
            set { canDelete = value; }
        } 
    }
}
