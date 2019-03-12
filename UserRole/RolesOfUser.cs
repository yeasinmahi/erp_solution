using UserRole.DAL;
using UserRole.DAL.RoleTDSTableAdapters;
using UserRole.DAL.RoleModifyTDSTableAdapters;
using UserRole.DAL.RoleModifySubordinateTDSTableAdapters;
using UserRole.DAL.RoleFuncTDSTableAdapters;


/// <summary>
/// Developped By Akramul Haider
/// Copyright © akram
/// </summary>
namespace UserRole
{
    public class RolesOfUser
    {
        public RoleTDS.SprRoleGetRolesForUserDataTable GetMenuItems(string userCode)
        {
            SprRoleGetRolesForUserTableAdapter ta = new SprRoleGetRolesForUserTableAdapter();
            return ta.GetData(userCode);
        }
        public RoleModifyTDS.SprRoleGetRolesForUserForModifyDataTable GetRolesByUser(string userCode)
        {
            SprRoleGetRolesForUserForModifyTableAdapter ta = new SprRoleGetRolesForUserForModifyTableAdapter();
            return ta.GetData(userCode);
        }

        public void ModifyRoles(string userCode, string intRoleID, bool ysnEnable, string strFunc)
        {
            SprRoleUpdateRolesForUserForModifyTableAdapter ta = new SprRoleUpdateRolesForUserForModifyTableAdapter();
            ta.GetData(userCode, int.Parse(intRoleID), ysnEnable);
        }

        public RoleModifySubordinateTDS.SprRoleGetRolesForUserForModifySubordinateDataTable GetRolesByChildUser(string userCode)
        {

            SprRoleGetRolesForUserForModifySubordinateTableAdapter ta = new SprRoleGetRolesForUserForModifySubordinateTableAdapter();
            return ta.GetData(userCode);
        }
        public void ModifyRolesSubordinate(string parentUserCode, string userCode, string strFunc, bool ysnCanView, bool ysnCanInsert, bool ysnCanModify, bool ysnCanDelete, bool ysnEnable, bool ysnEnableView, bool ysnEnableInsert, bool ysnEnableModify, bool ysnEnableDelete, int intRoleID)
        {
            SprRoleUpdateRolesForUserForModifySubordinateTableAdapter ta = new SprRoleUpdateRolesForUserForModifySubordinateTableAdapter();
            ta.GetData(parentUserCode, userCode, intRoleID, ysnCanView, ysnCanInsert, ysnCanModify, ysnCanDelete, ysnEnable);
        }

        public RoleVewInsModDel GetVewInsModDelForFunction(string functionClassName, string userCode)
        {
            RoleVewInsModDel rol = new RoleVewInsModDel();
            bool? vw = false, ins = false, del = false, mod = false;

            SprRoleGetRolesForUserByFunctionTableAdapter ta = new SprRoleGetRolesForUserByFunctionTableAdapter();
            ta.GetData(userCode, functionClassName, ref vw, ref ins, ref mod, ref del);

            rol.CanDelete = (bool)del;
            rol.CanInsert = (bool)ins;
            rol.CanModify = (bool)mod;
            rol.CanView = (bool)vw;

            return rol;
        }

        public RoleFuncTDS.TblRoleFunctionDataTable GetInfoForMenuBuilder()
        {
            TblRoleFunctionTableAdapter ta = new TblRoleFunctionTableAdapter();
            return ta.GetData();
        }
        public void AddFunction(string function, string description, int parentID, string className, string image, string url, int order, bool canView, bool canInsert, bool canModify, bool canDelete)
        {
            SprRoleFunctionInsertTableAdapter ta = new SprRoleFunctionInsertTableAdapter();
            ta.GetData(function, parentID, description, canView, canInsert, canModify, canDelete, image, url, order, true, className);
        }
        public void ActiveInactive(int function, bool isActive, bool onlyForThisFunction)
        {
            SprRoleFunctionActIncTableAdapter ta = new SprRoleFunctionActIncTableAdapter();
            ta.GetData(function,isActive,onlyForThisFunction);
        }

        public int IsExixtsUniqueName(string uniqueName)
        {
            TblRoleFunctionTableAdapter ta = new TblRoleFunctionTableAdapter();
            return (int)ta.IsExistsClassName(uniqueName);
        }

    }
}
