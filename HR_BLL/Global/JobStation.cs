using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR_DAL.Global;
using HR_DAL.Global.JobStationTDSTableAdapters;
using System.Web.UI.WebControls;
using HR_DAL.Reports.ReportDataTDSTableAdapters;
using HR_DAL.Reports;
using System.Data;

namespace HR_BLL.Global
{
    public class JobStation
    {

        public JobStationTDS.TblEmployeeJobStationDataTable GetAllJobStation()
        {

            TblEmployeeJobStationTableAdapter ta = new TblEmployeeJobStationTableAdapter();
            return ta.GetAllJobStationData();
        }

        public JobStationTDS.SprGetAllJobStationByLoginIdDataTable GetAllJobStationByLoginId(int? intLoginId)
        {
            //Summary    :   This function will use to get jobstation Id and name by intLoginId 
            //Author:		<Md. Golam Kibria Konock>
            //Create date: <09/06/2012>
            //Modified   :   sesUserID
            //Parameters :   intLoginId
            SprGetAllJobStationByLoginIdTableAdapter adp = new SprGetAllJobStationByLoginIdTableAdapter();
            return adp.GetAllJobStationByLoginIdData(intLoginId);
        }

        public ListItemCollection GetJobStationIdAndNameByUnitID(int? intUnitID, int? intLoginId)
        {
            //Summary    :   This function will use to get jobstation Id and name by unitid 
            //Created    :   Md. Yeasir Arafat / Mar-14-2012
            //Modified   :   
            //Parameters :   unit id

            ListItemCollection col = new ListItemCollection();

            JobStationGetAllJobStationIdAndNameByUnitIDTableAdapter objJobStationGetAllJobStationIdAndNameByUnitIDTableAdapter = new JobStationGetAllJobStationIdAndNameByUnitIDTableAdapter();
            ReportDataTDS.JobStationGetAllJobStationIdAndNameByUnitIDDataTable tbl = objJobStationGetAllJobStationIdAndNameByUnitIDTableAdapter.GetAllJobStationIdAndNameByUnitIdData(intUnitID,intLoginId);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                col.Add(new ListItem(tbl[i].strJobStationName, tbl[i].intEmployeeJobStationId.ToString()));
            }


            return col;
        }

        public DataTable GetJobStationList()
        {
            TblEmployeeJobStationTableAdapter adp = new TblEmployeeJobStationTableAdapter();
            return adp.GetJobStationList();
        }
        public DataTable GetJobStationListByUnit(int UnitId)
        {
            TblEmployeeJobStation1TableAdapter adp = new TblEmployeeJobStation1TableAdapter();
            return adp.GetJobStationByUnitID(UnitId);
        }

    }
}
