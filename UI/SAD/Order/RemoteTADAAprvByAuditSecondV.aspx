<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAAprvByAuditSecondV.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAAprvByAuditSecondV" %>

<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
    <script src="../../Content/JS/gridviewscroll.min.js"></script>
    <script src="../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../Content/JS/JQUERY/jquery.min.js"></script>
    <script src="../../Content/JS/datepickr.min.js"></script>
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="../../Content/CSS/jquery-ui.css" rel="stylesheet" />
    



    <script>
        function Registration() {
        window.open('TADATopsheetForSingleEmployee.aspx', 'sub', "scrollbars=yes,toolbar=0,height=650,width=2048,top=5,left=0, resizable=yes, title=Preview");
       
        }
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";

            var txtDteFrom = document.forms["frmpdv"]["txtFromDate"].value;
            var txtDteTo = document.forms["frmpdv"]["txtToDate"].value;;

            if (txtDteFrom == null || txtDteFrom == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtDteFrom").focus();
            }



            else if (txtDteTo == null || txtDteTo == "") {
                alert("To date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtDteTo").focus();
            }

            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
    
</script>
   

     <script>
        function openpageforAuditDetapprove() {
            var mine = window.open('Order/TADATopsheetForSingleEmployee.aspx', '', "height=400, width=1000, scrollbars=yes, left=150, top=80, toolbar=0,resizable=no, title=Preview");
            if (mine) { alert(''); var popupblock = false; }
            else { alert(''); var popupblock = true; }
            mine.close();
        }
    </script>
    <script>
    function ViewConfirm(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }
    function CheckAll(Checkbox) {
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvForAuditBillChecking.ClientID %>");
        for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
            GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
       </script>
    <script  type="text/javascript">
   

    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }  
</script>
        <script type="text/javascript">
       
        function gridviewScroll() {
            $('#<%=grdvForAuditBillChecking.ClientID%>').gridviewScroll({
                 width:1100,
                 height: 360,
                 
                 freezesize: 6
             });
        } 
        function PostBack() {
             
            __doPostBack();
        }
    </script>


    <style type="text/css">
    .GridviewScrollHeader TH, .GridviewScrollHeader TD 
    { 
    padding: 5px; 
    font-weight: bold; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #EFEFEF; 
    text-align: left; 
    vertical-align: bottom; 
    } 
    .GridviewScrollItem TD 
    { 
    padding: 5px; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
    } 
    .GridviewScrollPager  
    { 
    border-top: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
    } 
    .GridviewScrollPager TD 
    { 
    padding-top: 3px; 
    font-size: 14px; 
    padding-left: 5px; 
    padding-right: 5px; 
    } 
    .GridviewScrollPager A 
    { 
    color: #666666; 
    }
    .GridviewScrollPager SPAN

    {

    font-size: 16px;

    font-weight: bold;

    }
    </style>  

</head>
<body>
    <form id="frmpdv" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
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
        
               <div class="leaveApplication_container"> 
    <div class="tabs_container">  TA - DA information Approve by Audit (Both Category user)  :
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td colspan="2"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="Employee Name:  " ></asp:Label></td>
                                <td> <asp:TextBox ID="txtFullName" runat="server"  CssClass="txtBox"></asp:TextBox> </td>
                               


          </tr>
          <tr class="tblroweven">
<td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit :  " ></asp:Label></td>
<%--<td style="text-align:right"> <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList" DataSourceID="odsUNitb" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="True"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsUNitb" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
    
              </td>--%>


<td style="text-align:right"> <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsuntaudit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
  
     
    
              <asp:ObjectDataSource ID="odsuntaudit" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                  </SelectParameters>
    </asp:ObjectDataSource>
  <asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
     
    
              </td>


<td style="text-align:right"><asp:Label ID="lblAreaName" CssClass="lbl" runat="server" Text="Area:  "></asp:Label> </td>
<td style="text-align:right">
    <%--<asp:DropDownList ID="drdlArea" CssClass="ddList" runat="server" DataSourceID="odsUnitVsAreaN" DataTextField="strAreaName" DataValueField="intAreaId"></asp:DropDownList>  
    
              <asp:ObjectDataSource ID="odsUnitVsAreaN" runat="server" SelectMethod="getAreaNameHR" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="drdlUnit" Name="UNIT" PropertyName="SelectedValue" Type="Int32" />
                  </SelectParameters>
    </asp:ObjectDataSource>--%>
    
    <asp:DropDownList ID="drdlArea" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsgetareafromu" DataTextField="strAreaName" DataValueField="intAreaId"></asp:DropDownList>  
    




              <asp:ObjectDataSource ID="odsgetareafromu" runat="server" SelectMethod="getAreafromUnit" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:ControlParameter ControlID="drdlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                  </SelectParameters>
    </asp:ObjectDataSource>
    



   



              
    



   



              </td>       
          </tr>
    <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label>
               
    </td>
                               
    <td style="text-align:right">
    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="ddList" DataTextField="strUser Type" DataValueField="intID" AutoPostBack="true" DataSourceID="odsustype" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="odsustype" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRmtUserCatg" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAUserTypeTableAdapter">
    <InsertParameters>
    <asp:Parameter Name="strUser_Type" Type="String" />
    </InsertParameters>
    </asp:ObjectDataSource>
    </td>
    <td style="text-align:right"><asp:Label ID="lblReportType" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
    <td>
    <asp:DropDownList ID="drdlReportType" CssClass="ddList" runat="server" DataSourceID="odsRptType" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsRptType" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
    <InsertParameters>
    <asp:Parameter Name="strReportType" Type="String" />
    </InsertParameters>
    </asp:ObjectDataSource>
    </td>
  
    </tr>
    <tr class="tblrowOdd"><td colspan="3"> <asp:Button ID="btnShow" runat="server" Text="Show Bill Info" Width="100px" OnClick="btnShow_Click" /></td> 
    <td><asp:Button ID="btnApprove" Width="100px" runat="server" Text="Approve" OnClick="btnApprove_Click"  OnClientClick="openpageforAuditDetapprove" /> </td>
      <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click"/></td>
    </tr>


</table>               

</div>
        <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven"><td>
              </td>
         </tr>          
                   <tr class="tblrowodd">
                <td>
          

                    <asp:GridView ID="grdvForAuditBillChecking" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvForAuditBillChecking_PageIndexChanging" OnRowDataBound="grdvForAuditBillChecking_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>

                            <asp:TemplateField><HeaderTemplate>    
                            <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                            </HeaderTemplate>  
                            <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>

                        
                         
                        <asp:TemplateField HeaderText="Enrol" SortExpression="intEmployeeid">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdintEmployeeid" runat="server"  Value='<%# Bind("intEmployeeid", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtintEmployeeid" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("intEmployeeid") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job station" SortExpression="strJobstation">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdstrJobstation" runat="server"  Value='<%# Bind("strJobstation", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrJobstation" CssClass="txtBox" runat="server" Width="50" TextMode="SingleLine" Text='<%# Bind("strJobstation") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesignation", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrDesignation" CssClass="txtBox" runat="server" Width="75" TextMode="SingleLine" Text='<%# Bind("strDesignation") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="75" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmployeename">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdstrEmployeename" runat="server"  Value='<%# Bind("strEmployeename", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrEmployeename" CssClass="txtBox" runat="server" Width="100" TextMode="SingleLine" Text='<%# Bind("strEmployeename") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="100" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LM Audit" SortExpression="LMAudit">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdLMAudit" runat="server"  Value='<%# Bind("LMAudit", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtLMAudit" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("LMAudit") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CM Appl." SortExpression="CMAppli">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdCMApplir" runat="server"  Value='<%# Bind("CMAppli", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtCMAppli" CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("CMAppli") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();" AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Grand Total" SortExpression="CMHR">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdCMHR" runat="server"  Value='<%# Bind("CMHR", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtCMHR" CssClass="txtBox" OnTextChanged="txtCMHR_TextChanged" runat="server"  TextMode="Number" Text='<%# Bind("CMHR") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();" AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Stand Mlg" SortExpression="idealm">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdidealm" runat="server"  Value='<%# Bind("idealm", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtidealm" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("idealm") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cons. Mlg" SortExpression="conskmM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdconskmM" runat="server"  Value='<%# Bind("conskmM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtconskmM" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("conskmM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="T F.Qnt" SortExpression="qntM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdqntM" runat="server"  Value='<%# Bind("qntM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtqntM" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("qntM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Fuel Cost" SortExpression="fuelM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdfuelM" runat="server"  Value='<%# Bind("fuelM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtfuelM" CssClass="txtBox" runat="server" OnTextChanged="txtfuelM_TextChanged" Width="35" TextMode="Number" Text='<%# Bind("fuelM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CostRatio" SortExpression="CostRation">
                            <ItemTemplate>

                            <asp:HiddenField  ID="hdmcost"  runat="server" Value='<%# Bind("mcost", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtmcost"  CssClass="txtBox" runat="server" Width="35"  Text='<%# Bind("mcost") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Prsnt" SortExpression="Prsnt">
                            <ItemTemplate>

                            <asp:HiddenField  ID="hdPrsnt"  runat="server" Value='<%# Bind("Prsnt", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtPrsnt"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("Prsnt") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave" SortExpression="leave">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdleave" runat="server" Value='<%# Bind("leave", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtleave"    CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("leave") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Own da" SortExpression="owndaM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdowndaM" runat="server" Value='<%# Bind("owndaM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtowndaM"  OnTextChanged="txtowndaM_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("owndaM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Drv DA" SortExpression="drvDAM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hddrvDAM" runat="server" Value='<%# Bind("drvDAM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdrvDAM" OnTextChanged="txtdrvDAM_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("drvDAM") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Own hot" SortExpression="ownhotM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdownhotM"  runat="server" Value='<%# Bind("ownhotM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtownhotM" OnTextChanged="txtownhotM_TextChanged"   CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("ownhotM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Drv hotel" SortExpression="drvhotelM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hddrvhotelM" runat="server" Value='<%# Bind("drvhotelM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdrvhotelM" OnTextChanged="txtdrvhotelM_TextChanged"   CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("drvhotelM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bus" SortExpression="busM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdbusM" runat="server" Value='<%# Bind("busM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtbusM" OnTextChanged="txtbusM_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("busM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rick" SortExpression="rickM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdrickM" runat="server" Value='<%# Bind("rickM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="rickM" OnTextChanged="rickM_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("rickM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Taxi" SortExpression="cngM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdcngM" runat="server" Value='<%# Bind("cngM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtcngM"  OnTextChanged="txtcngM_TextChanged" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("cngM") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Train" SortExpression="trainM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdtrainM" runat="server" Value='<%# Bind("trainM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txttrainM" OnTextChanged="txttrainM_TextChanged"   CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("trainM") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Boat" SortExpression="boatM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdboatM" runat="server" Value='<%# Bind("boatM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtboatM"  CssClass="txtBox" OnTextChanged="txtboatM_TextChanged" runat="server" Width="35" TextMode="Number" Text='<%# Bind("boatM") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Air" SortExpression="airM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdairM" runat="server" Value='<%# Bind("airM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtairM" OnTextChanged="txtairM_TextChanged"   CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("airM") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OthvhC" SortExpression="othvhM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdothvhM"  runat="server" Value='<%# Bind("othvhM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtothvhM" OnTextChanged="txtothvhM_TextChanged"    CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("othvhM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Photco" SortExpression="photcoM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdphotcoM" runat="server" Value='<%# Bind("photcoM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtphotcoM" OnTextChanged="txtphotcoM_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("photcoM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cour" SortExpression="courM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdcourM" runat="server" Value='<%# Bind("courM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtcourM" OnTextChanged="txtcourM_TextChanged"    CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("courM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mntc" SortExpression="mntcM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdmntcM" runat="server" Value='<%# Bind("mntcM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtmntcM" OnTextChanged="txtmntcM_TextChanged"   CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("mntcM") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ferry Toll" SortExpression="ferrytM">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdferrytM" runat="server" Value='<%# Bind("ferrytM", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtferrytM" OnTextChanged="txtferrytM_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("ferrytM") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ohte Bill" SortExpression="decOtherbill">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddecOtherbill" runat="server" Value='<%# Bind("decOtherbill", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecOtherbill" OnTextChanged="txtdecOtherbill_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("decOtherbill") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="cashFuel" SortExpression="decCashFuelandOil">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdcashFuel" runat="server" Value='<%# Bind("decCashFuelandOil", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtcashOilcng" OnTextChanged="txtcashOilcng_TextChanged"  CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("decCashFuelandOil") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
               
                         <asp:TemplateField HeaderText="PMlgCost" SortExpression="decPersonalCost">
                              <ItemTemplate>
                              <asp:HiddenField ID="hddecPersonalCost" runat="server" Value='<%# Bind("decPersonalCost", "{0:0.0}") %>'></asp:HiddenField>
                             <asp:TextBox ID="txtPersonalMlgCost" OnTextChanged="txtPersonalMlgCost_TextChanged" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("decPersonalCost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />

                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Advacne" SortExpression="decAdvanceAmount">
                              <ItemTemplate>
                              <asp:HiddenField ID="hddecAdvanceAmount" runat="server" Value='<%# Bind("decAdvanceAmount", "{0:0.0}") %>'></asp:HiddenField>
                             <asp:TextBox ID="txtAdvanceAmount" OnTextChanged="txtAdvanceAmount_TextChanged" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("decAdvanceAmount") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />

                         </asp:TemplateField>
                          

                         <asp:TemplateField HeaderText="Det.">
             <ItemTemplate>
             <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intEmployeeid") %>' /></ItemTemplate>
             </asp:TemplateField>  

           
                    <asp:TemplateField HeaderText="ID" SortExpression="Id">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdId" runat="server"  Value='<%# Bind("Id", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtintId" CssClass="txtBox" runat="server" Width="15" TextMode="Number" Text='<%# Bind("Id") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="15" />
                    </asp:TemplateField>
     
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                         <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>



                </td>


            </tr>
                  </table>
</div>
              
         




    </table>
                            </div>




        <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>  
            