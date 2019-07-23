﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployeeReg.aspx.cs" Inherits="UI.HR.Employee.NewEmployeeReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: New Employee Registration :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
   
    
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  


    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
      <script type="text/javascript" src="../../Content/JS/scriptEmployeeReg.js"></script>
  
    


    </head>
<body>
    <form id="frmEmpRegistration" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
       <CompositeScript>
           <Scripts>
               <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

           </Scripts>
       </CompositeScript>

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

    <div class="divs_content_container"> 
        <div class="tabs_container"> 
            <ul class="tabs">
                <li id="1" class="active">Basic Information</li>
                <li id="2">Official Information</li>
                <li id="3">Salary Information</li>
            </ul>
            <asp:HiddenField ID="hdnField" runat="server" />
        <hr />
        </div>

         <%--=======================Employee Basic Information=================--%>  
        <div id="basicinfo">        
            <table border="0px"; style="width:Auto"; align="center" >
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label></td>
                <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblshortname" CssClass="lbl" runat="server" Text="Short-Name : "></asp:Label></td>
                <td><asp:TextBox ID="txtShortName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblNationalId" CssClass="lbl" runat="server" Text="NationalId : "></asp:Label></td>
                <td><asp:TextBox ID="txtNationalId" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblcontactno" CssClass="lbl" runat="server" Text="ContactNo : "></asp:Label></td>
                <td><asp:TextBox ID="txtContactNo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                </tr>
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblbloodgroup" CssClass="lbl" runat="server" Text="Blood-Group : "></asp:Label></td>
                <td><asp:TextBox ID="txtBloodGroup" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblfactorycode" CssClass="lbl" runat="server" Text="Card-No : "></asp:Label></td>
                <td><asp:TextBox ID="txtFactoryCode" runat="server" CssClass="txtBox"></asp:TextBox></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblgender" CssClass="lbl" runat="server" Text="Gender : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlGender" runat="server" AutoPostBack="false" CssClass="dropdownList">
                    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem><asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align:right;"><asp:Label ID="lbldayoff" CssClass="lbl" runat="server" Text="Off-Day : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlOffDay" runat="server" AutoPostBack="false" CssClass="dropdownList"
                    DataSourceID="ODSDays" DataTextField="strDayName" DataValueField="intDayOffId"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSDays" runat="server" SelectMethod="GetAllDays" TypeName="HR_BLL.Global.DaysOfWeek">
                    </asp:ObjectDataSource></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblreligion" CssClass="lbl" runat="server" Text="Religion : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReligion" runat="server" AutoPostBack="false" CssClass="dropdownList" 
                    DataSourceID="odsReligion" DataTextField="strReligionName" DataValueField="intReligionID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsReligion" runat="server" SelectMethod="GetAllReligion" 
                    TypeName="HR_BLL.Global.Religion"></asp:ObjectDataSource>
                </td>
                
                <td style="text-align:right;"><asp:Label ID="lblemail" CssClass="lbl" runat="server" Text="Office-Mail : "></asp:Label></td>
                <td><asp:TextBox ID="txtEmail" runat="server" CssClass="txtBox"></asp:TextBox></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblperadd" CssClass="lbl" runat="server" Text="Permanent-Address : "></asp:Label></td>
                <td><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblpreadd" CssClass="lbl" runat="server" Text="Present-Address : "></asp:Label></td>
                <td><asp:TextBox ID="txtPresentAddress" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
                </tr>

                <tr><td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Date Of Birth : "></asp:Label></td>
                <td><asp:TextBox ID="txtDOB" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CEB" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDOB"></cc1:CalendarExtender></td>
                <td colspan="2"><a class="nextclick" onclick="ValidationBasicInfo()"> Next Step >></a></td></tr>
            </table>            
        </div> 


        <%--=======================Employee Official Information=================--%>  
        <div id="officeinfo">
            <table border="0px"; style="width:Auto"; align="center" >
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblgroup" CssClass="lbl" runat="server" Text="Employee-Group : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlGroup" runat="server" CssClass="dropdownList" AutoPostBack="false"
                    DataSourceID="ODSEmpGroup" DataTextField="strGroupName" DataValueField="intGroupID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSEmpGroup" runat="server" SelectMethod="GetAllEmployeeGroup"
                    TypeName="HR_BLL.Global.EmployeeGroup"></asp:ObjectDataSource>
                </td>

                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
                    DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit"
                    OldValuesParameterFormatString="original_{0}"><SelectParameters>
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String"/>
                    </SelectParameters></asp:ObjectDataSource>
                </td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblstation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlJobStation" runat="server" AutoPostBack="True" CssClass="dropdownList"
                    DataSourceID="ODSJobStation" DataTextField="Text" DataValueField="value" OnSelectedIndexChanged="ddlJobStation_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSJobStation" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
                    TypeName="HR_BLL.Global.JobStation" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                    Type="Int32" /><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>

                <td style="text-align:right;"><asp:Label ID="lblstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlJobStatus" runat="server" AutoPostBack="True" CssClass="dropdownList"
                     DataSourceID="ODSJobType" DataTextField="strJobType" DataValueField="intJobTypeID" OnSelectedIndexChanged="ddlJobStatus_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSJobType" runat="server" SelectMethod="GetJobTypeByUnit"
                    TypeName="HR_BLL.Global.JobType" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                    Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                </td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lbldepartment" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="False" CssClass="dropdownList"
                    DataSourceID="ODSDepartment" DataTextField="strDepatrment" DataValueField="intDepartmentID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSDepartment" runat="server" SelectMethod="GetAllDepartment"
                    TypeName="HR_BLL.Global.Department"></asp:ObjectDataSource>                    
                </td>

                <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDesignation" runat="server" AutoPostBack="False" CssClass="dropdownList"
                    DataSourceID="ODSDesignation" DataTextField="strDesignation" DataValueField="intDesignationID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSDesignation" runat="server" SelectMethod="GetAllDesignation"
                    TypeName="HR_BLL.Global.Designation"></asp:ObjectDataSource>
                </td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblcategory" CssClass="lbl" runat="server" Text="DutyCategory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDutyCategory" runat="server" AutoPostBack="False" CssClass="dropdownList"
                    DataSourceID="ODSDutyCategory" DataTextField="strDutyCatagory" DataValueField="intDutyCatID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSDutyCategory" runat="server" SelectMethod="GetAllDutyCategory"
                    TypeName="HR_BLL.Global.DutyCategory"></asp:ObjectDataSource>                    
                </td>

                <td style="text-align:right;"><asp:Label ID="lblcontact" CssClass="lbl" runat="server" Text="Contact-Period : "></asp:Label></td>
                <td><asp:TextBox ID="txtContact" runat="server" CssClass="txtBox" Width="125px" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="lblmonth" CssClass="lbl" runat="server" Text=" (In Month)"></asp:Label>
                </td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lblsftstatus" CssClass="lbl" runat="server" Text="Shift-Status : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlShiftStatus" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlShiftStatus_SelectedIndexChanged"
                    DataSourceID="odsTeam" DataTextField="strTeamName" DataValueField="intTeamId"></asp:DropDownList>                                       
                    <asp:ObjectDataSource ID="odsTeam" runat="server" SelectMethod="GetAllTeamByStationId" 
                    TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation"><SelectParameters>
                    <asp:ControlParameter ControlID="ddlJobStation" Name="intJobStationId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>                                       
                </td>

                <td style="text-align:right;"><asp:Label ID="lblshift" CssClass="lbl" runat="server" Text="Present-Shift : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlPresentShift" runat="server" CssClass="dropdownList" DataSourceID="odsShift" DataTextField="strShiftName" 
                    DataValueField="intShiftId"></asp:DropDownList> <asp:ObjectDataSource ID="odsShift" runat="server" 
                    SelectMethod="GetShiftInformationByTeamId" TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation">
                    <SelectParameters><asp:ControlParameter ControlID="ddlShiftStatus" Name="intTeamId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
                </tr>

                <tr>
                <td style="text-align:right;">
                    <asp:Label ID="lblsuperviser" runat="server" CssClass="lbl" Text="Reporting-Boss : "></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtReportingBoss" runat="server" CssClass="txtBox"></asp:TextBox>
                </td>

                <td style="text-align:right;"><asp:Label ID="lblappointment" CssClass="lbl" runat="server" Text="Joining-Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtJoiningDate" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                    <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtJoiningDate">
                    </cc1:CalendarExtender> 
                </td>
                </tr>

                <tr>
                    <td style="text-align:right;"><asp:Label ID="lblFloorAccess" CssClass ="lbl" runat="server" Text="Floor Access :"></asp:Label></td>
                    <td style="text-align:left;"><asp:DropDownList ID="ddlFloorAccess" runat="server" CssClass="ddList"></asp:DropDownList></td>
                    <td colspan="2"><a class="nextclick" onclick="ValidationOfficialInfo()">Next Step >></a></td>
                </tr>
            </table>
        </div>    
               

        <%--==================Employee Salary Information=================--%>  
        <div id="salaryinfo">        
            <table border="0px"; style="width:Auto"; align="center" >
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblbank" CssClass="lbl" runat="server" Text="Bank-Name : "></asp:Label></td>
                <%--<td><asp:TextBox ID="txtBankName" runat="server" CssClass="txtBox"></asp:TextBox></td>--%>
                <td><asp:DropDownList ID="ddlBank" runat="server" CssClass="dropdownList" DataSourceID="odsbnk" DataTextField="strBankName" DataValueField="intID" ></asp:DropDownList>
                <asp:ObjectDataSource ID="odsbnk" runat="server" SelectMethod="GetAllBankList" TypeName="HR_BLL.Global.District"></asp:ObjectDataSource>
                </td>
                <td style="text-align:right;"><asp:Label ID="lbldistrict" CssClass="lbl" runat="server" Text="District-List : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDistrict" runat="server" CssClass="dropdownList" AutoPostBack="True" DataSourceID="odsdist" DataValueField="intDistrictID" DataTextField="strDistrict" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsdist" runat="server" SelectMethod="GetAllDistrictList" TypeName="HR_BLL.Global.District"></asp:ObjectDataSource>
                </td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblbranch" CssClass="lbl" runat="server" Text="Branch-Name : "></asp:Label></td>
                <%--<td><asp:TextBox ID="txtBranchName" runat="server" CssClass="txtBox"></asp:TextBox></td>--%>
                <td><asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropdownList" DataSourceID="odsbranch" 
                DataTextField="strBankBranchName" DataValueField="intBranchID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsbranch" runat="server" SelectMethod="GetBankBranchList" TypeName="HR_BLL.Global.District">
                <SelectParameters><asp:ControlParameter ControlID="ddlBank" Name="bankid" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="ddlDistrict" Name="distid" PropertyName="SelectedValue" Type="Int32" /></SelectParameters>
                </asp:ObjectDataSource>
                </td>
                <td style="text-align:right;"><asp:Label ID="lblaccount" CssClass="lbl" runat="server" Text="Account-No : "></asp:Label></td>
                <td><asp:TextBox ID="txtAccountNo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lbltsalary" CssClass="lbl" runat="server" Text="Total-Salary : "></asp:Label></td>
                <td><asp:TextBox ID="monSalary" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblphoto" CssClass="lbl" runat="server" Text="Employee-Photo : "></asp:Label></td>
                <td><asp:FileUpload ID="photoUpload" runat="server" CssClass="txtBox"/></td>
                </tr>
                
               <%--<tr>
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Basic-Salary : "></asp:Label></td>
                <td><asp:TextBox ID="monBasic" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>
                <td style="text-align:right;">
                    <asp:Label ID="lblpaymenttype" runat="server" CssClass="lbl" Text="Payment-Type : "></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="ddlPaymentType" runat="server" AutoPostBack="false" CssClass="dropdownList">
                        <asp:ListItem Selected="True" Value="H">Daily</asp:ListItem>
                        <asp:ListItem Value="D">Monthly</asp:ListItem>
                    </asp:DropDownList> 
                    </td>
                </tr> --%>

                <tr>
                <td style="text-align:right;"><asp:Label ID="lbldoc" CssClass="lbl" runat="server" Text="Document : "></asp:Label></td>
                <td><asp:FileUpload ID="documentUpload" runat="server" CssClass="txtBox"/></td> 
                <td style="text-align:right;"><asp:Label ID="lbldocumenttype" runat="server" CssClass="lbl" Text="Document-Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDocumentType" runat="server" AutoPostBack="false" CssClass="dropdownList">
                <asp:ListItem Selected="True" Value="Others">Others</asp:ListItem>
                <asp:ListItem Value="Tin">Tin Certificate</asp:ListItem></asp:DropDownList></td>               
                </tr> 
                <tr>
                <td colspan="4" style="text-align:right;"><a class="nextclick" onclick="ValidationSalaryInfo()">Submit</a> <a class="nextclick" onclick="ShowBasicInfo()">Cancel</a> </td>
            </table>         
        </div>

        
    </div>   

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
