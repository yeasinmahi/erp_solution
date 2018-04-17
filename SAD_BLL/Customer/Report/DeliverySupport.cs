﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAD_DAL.Customer.Report;
using SAD_DAL.Customer.Report.DeliverySupportTDSTableAdapters;

namespace SAD_BLL.Customer.Report
{
    public class DeliverySupport
    {

        public DeliverySupportTDS.SprCustomerServiceDODataTable InfoByDO(
                    string strCode,
                    string intUnitID,
                    string intUserID,
                    ref long? intID,

                    ref DateTime? dteDate,
                    ref DateTime? dteDateReq,

                    ref string strInsertedBy,
                    ref DateTime? dteInsertionTime,
                    ref string strModifieddBy,
                    ref DateTime? dteModificationTime,

                    ref bool? ysnSOCompleted,
                    ref string strSOCompletedBy,
                    ref DateTime? dteSOComplitionTime,

                    ref bool? ysnDOCompleted,
                    ref string strDOCompletedBy,
                    ref DateTime? dteDOComplitionTime,

                    ref string strSaleOffice,
                    ref string strShipPoint,

                    ref string strCustomer,
                    ref string strPhone,
                    ref string strDisPointName,
                    ref string strContactAt,
                    ref string strContactPhone,
                    ref string strAddress,
                    ref string strOther,

                    ref decimal? monTotalAmount,
                    ref decimal? numReqQnty,
                    ref decimal? numApprQnty,

                    ref string strExtra,
                    ref decimal? monExtAmount,
                    ref string strCharge,
                    ref decimal? monChargeAmount,
                    ref string strIncentive,
                    ref decimal? monIncentiveAmount,

                    ref string strCurrency,

                    ref string strLogistic,
                    ref string strStatus
            )
        {
            SprCustomerServiceDOTableAdapter ta = new SprCustomerServiceDOTableAdapter();
            return ta.GetData(strCode,
                    int.Parse(intUnitID),
                     int.Parse(intUserID),
                   ref intID,

                   ref dteDate,
                   ref dteDateReq,

                   ref strInsertedBy,
                   ref dteInsertionTime,
                   ref strModifieddBy,
                   ref dteModificationTime,

                   ref ysnSOCompleted,
                   ref strSOCompletedBy,
                   ref dteSOComplitionTime,

                   ref ysnDOCompleted,
                   ref strDOCompletedBy,
                   ref dteDOComplitionTime,

                   ref strSaleOffice,
                   ref strShipPoint,

                   ref strCustomer,
                   ref strPhone,
                   ref strDisPointName,
                   ref strContactAt,
                   ref strContactPhone,
                   ref strAddress,
                   ref strOther,

                   ref monTotalAmount,
                   ref numReqQnty,
                   ref numApprQnty,

                   ref strExtra,
                   ref monExtAmount,
                   ref strCharge,
                   ref monChargeAmount,
                   ref strIncentive,
                   ref monIncentiveAmount,

                   ref strCurrency,

                   ref strLogistic,
                   ref strStatus);
        
        
        
        }

        public DeliverySupportTDS.SprCustomerServiceDODetailsDataTable InfoByDODetails(
            string id,
            string userID,
            
            ref string strChallanNo,
            ref string strTripNo,
            ref bool? ysnCompleted,

            ref string strVehicle,
            ref string strLogistic,
            ref DateTime? dteInTime,                    
            ref DateTime? dteOutTime,

            ref string strDriver,
            ref string strContact,
            ref string strDrNid,
            ref string strHealper,

            ref string strUom,
            ref decimal? numEmpty,
            ref decimal? numLoaded,
            ref decimal? numCapacity,
            ref DateTime? dteWgtIn,
            ref DateTime? dteWgtOut
            )
        {
            SprCustomerServiceDODetailsTableAdapter ta = new SprCustomerServiceDODetailsTableAdapter();
            return ta.GetData(long.Parse(id), int.Parse(userID), ref strChallanNo
                , ref strTripNo, ref ysnCompleted, ref strVehicle, ref strLogistic
                , ref dteInTime, ref dteOutTime, ref strDriver,ref strContact,ref strDrNid
                , ref strHealper, ref strUom, ref numEmpty, ref numLoaded, ref numCapacity
                , ref dteWgtIn, ref dteWgtOut);
            
        }
    }
}