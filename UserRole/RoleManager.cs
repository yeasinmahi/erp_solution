using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserRole.DAL;
using UserRole.DAL.RoleGroupTDSTableAdapters;

/// <summary>
/// Developped By Akramul Haider
/// Copyright © akram
/// </summary>
namespace UserRole
{
    public class RoleManager
    {
        public void AddRoleGroup(string groupName,string description)
        {
            TblRoleUserGroupTableAdapter ta = new TblRoleUserGroupTableAdapter();
            ta.InsertQuery(groupName, description);
        }
        public RoleGroupTDS.TblRoleUserGroupDataTable GetRoleGroup(bool isActive)
        {
            TblRoleUserGroupTableAdapter ta = new TblRoleUserGroupTableAdapter();
            return ta.GetData(isActive);
        }
        public void UpdateRoleGroup(string strGroupName, string strDescription, bool ysnActive, int intGroupID)
        {
            TblRoleUserGroupTableAdapter ta = new TblRoleUserGroupTableAdapter();
            ta.UpdateRole(strGroupName, strDescription, ysnActive, intGroupID);
        }
    }
}
