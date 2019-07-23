<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAAprvByHR.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAAprvByHR" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

     <script type="text/javascript">
         $(document).ready(function () {
             GridviewScroll();
         });
         function GridviewScroll() {

             $('#<%=grdvBikeCarUserDetaillsHRLabel.ClientID%>').gridviewScroll({
                 width: 1025,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script>

    

      
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/getApplicantListForBikeAndCarUserBillApprove") %>',
                        data: '{"ApproverEnrol":"' + $("#hdnAreamanagerEnrol").val() + '","prefix":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) { },
                        failure: function (response) { }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });

        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
          
            var txtDteFrom = document.forms["frmpdv"]["txtFromDate"].value;
            var txtDteTo = document.forms["frmpdv"]["txtToDate"].value;;

            if (txtDteFrom == null || txtDteFrom == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtDteFrom").focus();
            }



            else if (txtDteTo == null || txtDteTo == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
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


</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
  

<%--=========================================Start My Code From Here===============================================--%>
        
               <div class="leaveApplication_container"> 
    <div class="tabs_container">  TA - DA information Approve by HR (Both Category user)  :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td colspan="2"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="Employee Name:  " ></asp:Label></td>
                                <td> <asp:TextBox ID="txtFullName" runat="server"  CssClass="txtBox"></asp:TextBox> </td>
                               


          </tr>
          <tr class="tblroweven">
<td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit :  " ></asp:Label></td>
<%--<td style="text-align:right"> <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList" DataSourceID="odsHRTADAunitPermission" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged"></asp:DropDownList>
    
    
              <asp:ObjectDataSource ID="odsHRTADAunitPermission" runat="server" SelectMethod="getHRunitPermissionforTADA" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                  </SelectParameters>
    </asp:ObjectDataSource>
    
    
              </td>--%>

  <td style="text-align:right"> <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList"  AutoPostBack="True" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged" DataSourceID="odsunitpermissionhr" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
  <asp:ObjectDataSource ID="odsunitpermissionhr" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                  </SelectParameters>
           </asp:ObjectDataSource>
    
   </td>


<td style="text-align:right"><asp:Label ID="lblAreaName" CssClass="lbl" runat="server" Text="Area:  "></asp:Label> </td>
<td style="text-align:right">
   <%-- <asp:DropDownList ID="drdlArea" CssClass="ddList" runat="server" DataSourceID="odsUNTVSArea" DataTextField="strAreaName" DataValueField="intAreaId" AutoPostBack="true"></asp:DropDownList>  
    <asp:ObjectDataSource ID="odsUNTVSArea" runat="server" SelectMethod="getHRunitvsAreaPermissionforTADA" TypeName="SAD_BLL.Customer.Report.StatementC">
        <SelectParameters>
            <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
            <asp:ControlParameter ControlID="drdlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>

    <asp:DropDownList ID="drdlArea" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsgetarea" DataTextField="strAreaName" DataValueField="intAreaId"></asp:DropDownList>  
    
    <asp:ObjectDataSource ID="odsgetarea" runat="server" SelectMethod="getAreafromUnit" TypeName="SAD_BLL.Customer.Report.StatementC">
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
    <tr class="tblrowOdd"><td> <asp:Button ID="btnShow" runat="server" Text="Show Bill Info" Width="100px" OnClick="btnShow_Click" /></td> 
    <td><asp:Button ID="btnApprove" Width="100px" runat="server" Text="Approve" OnClick="btnApprove_Click" OnClientClick = "Confirm()"/> </td>
    <td><asp:Button ID="btnStorePrint" Width="100px" runat="server" Text="Store Format" OnClick="btnStorePrint_Click"/></td>
      <td><asp:Button ID="btnExpToExcel" Width="100px" runat="server" Text="ExportToExcel" OnClick="btnExpToExcel_Click" /></td>
    </tr>


</table>               

</div>
 <div class="leaveApplication_container" style="width:100%">
              <table>        
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          

         <tr class="tblrowOdd" >
             <td colspan="4">
                 <asp:GridView ID="grdvTopShNoneBike"  runat="server"   AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdvTopShNoneBike_PageIndexChanging" PageSize="15" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                     <Columns>
                     

                         <asp:BoundField DataField="dteFromdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       

                      <asp:BoundField DataField="strNam" HeaderText="Employee  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                         <asp:BoundField DataField="strDesg" HeaderText="Desg" SortExpression="strdesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                       <asp:BoundField DataField="decmovdur" HeaderText="MovDuraion" SortExpression="decMovDuraion" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="decfare" HeaderText="Bus" SortExpression="decBus" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="decrick" HeaderText="Rick" SortExpression="decRick" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="cng" HeaderText="CNG" SortExpression="decCNG" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="train" HeaderText="Train" SortExpression="decTrain" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="boat" HeaderText="Boat" SortExpression="decBoat" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="othevh" HeaderText="Anoth.Vh." SortExpression="decAnother" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      

                      <asp:BoundField DataField="decownda" HeaderText="OwnDA" SortExpression="decOwnDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decOtherda" HeaderText="Oth.DA" SortExpression="decOtherDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dechotel" HeaderText="Hotel" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="decOtherCostAmount" HeaderText="Other Cost" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         

                      <asp:BoundField DataField="decrowtotal" HeaderText="Total " SortExpression="decrowtotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      

     
                     </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
                     <RowStyle BackColor="White" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>
             </td>
             
         </tr>  

                  <tr class="tblroweven">
            <td colspan="4">
<asp:GridView ID="GridviewTADADetaillHrlEBL" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" GridLines="None" OnPageIndexChanging="GridviewTADADetaillHrlEBL_PageIndexChanging" CellSpacing="1">
                  <Columns>
                   

                      <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    <asp:TemplateField HeaderText="From Date" SortExpression="dteFromDate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteFromdateNoBikeDet"  DataFormatString="{0:dd/MM/yyyy}" CssClass="txtBox" runat="server" Width="60" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inst. Date" SortExpression="dtIns">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdToDate"   runat="server" Value='<%# Bind("dtIns", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteInsdateNoBikeDet" DataFormatString="{0:dd/MM/yyyy}" CssClass="txtBox" runat="server" Width="60" TextMode="Date"  Text='<%# Bind("dtIns") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Width="60" TextMode="SingleLine" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strDesgNoBikeDet" CssClass="txtBox" runat="server" Width="60" TextMode="SingleLine" Text='<%# Bind("strDesg") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="FromAddress" SortExpression="strFromAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromaddr", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strFromaddrNoBikeDet" CssClass="txtBox" runat="server" Width="60" TextMode="SingleLine" Text='<%# Bind("strFromaddr") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>
                   <asp:TemplateField HeaderText="To Address" SortExpression="strToAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToadr", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strToadrNoBikeDet" CssClass="txtBox" runat="server" Width="60" TextMode="SingleLine" Text='<%# Bind("strToadr") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="Movementspots" SortExpression="strmovmentspot">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strmovmentspot", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strMovemetspotNonebikeuser" CssClass="txtBox" runat="server" Width="60" TextMode="SingleLine" Text='<%# Bind("strmovmentspot") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>
                   <asp:TemplateField HeaderText="Movement duration " SortExpression="decMov">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMove" runat="server"  Value='<%# Bind("decmovdur", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decmovdur") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                       
                         <asp:TemplateField HeaderText="Fare" SortExpression="decFare">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdFare"  runat="server" Value='<%# Bind("decfare", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtfareNoBikeDet" OnTextChanged="txtfareNoBikeDet_TextChanged"  CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decfare") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="Rick" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decrick", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecrick" OnTextChanged="txtdecrick_TextChanged"  CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decrick") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="CNG" SortExpression="cng">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdCNG" runat="server" Value='<%# Bind("cng", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtcng" OnTextChanged="txtcng_TextChanged"  CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("cng") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Other" SortExpression="decOth">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("train", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txttrain" OnTextChanged="txttrain_TextChanged"  CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("train") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="Boat" SortExpression="decBoat">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdBoat" runat="server" Value='<%# Bind("boat", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtboat" OnTextChanged="txtboat_TextChanged" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("boat") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OtherVhc." SortExpression="decRowTotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("othevh", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtothevh" OnTextChanged="txtothevh_TextChanged" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("othevh") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="Remarks" SortExpression="strsuppor">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strsuppor", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrsuppor"  CssClass="txtBox" runat="server" Width="60" TextMode="MultiLine" Text='<%# Bind("strsuppor") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>
                     

                      <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decownda", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecownda" OnTextChanged="txtdecownda_TextChanged" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decownda") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Other DA." SortExpression="decOtherda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decOtherda", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherda" OnTextChanged="txtdecOtherda_TextChanged" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decOtherda") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Hotel" SortExpression="dechotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("dechotel", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdechotel" OnTextChanged="txtdechotel_TextChanged" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("dechotel") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                     
                      <asp:TemplateField HeaderText="OtherCost" SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherCostAmount", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txthddecOtherCostAmount" OnTextChanged="txthddecOtherCostAmount_TextChanged" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decOtherCostAmount") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                     
                       <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decrowtotal", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecrowtotal" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decrowtotal") %>' AutoPostBack="true" ReadOnly="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                        <asp:TemplateField HeaderText="Contact" SortExpression="strContac">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdContact" runat="server" Value='<%# Bind("strContac", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrContac" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("strContac") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                      <asp:TemplateField HeaderText="Phone" SortExpression="strphone">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrphone" runat="server" Value='<%# Bind("strphone", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrphone" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("strphone") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                      <asp:TemplateField HeaderText="Visited Org" SortExpression="strVisitorg">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrVisitorg" runat="server" Value='<%# Bind("strVisitorg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrVisitorg" CssClass="txtBox" runat="server" Width="60" TextMode="MultiLine" Text='<%# Bind("strVisitorg") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>


                      <asp:TemplateField HeaderText="UnitID" SortExpression="UnitID">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnUnit" runat="server" Value='<%# Bind("intUnit", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtUnitid" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("intUnit") %>' AutoPostBack="true" ReadOnly="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>



                      <asp:TemplateField HeaderText="JobStaid" SortExpression="JobStaid">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdJobstation" runat="server" Value='<%# Bind("intJobstation", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtJobstation" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("intJobstation") %>' AutoPostBack="true" ReadOnly="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="Areaid" SortExpression="Areaid">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdAreaid" runat="server" Value='<%# Bind("intareadid", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtAreaID" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("intareadid") %>' AutoPostBack="true" ReadOnly="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="Enrol" SortExpression="Areaid">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdEnrol" runat="server" Value='<%# Bind("intEnrol", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtEnrol" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("intEnrol") %>' AutoPostBack="true" ReadOnly="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="60" />
                     </asp:TemplateField>




                </Columns>
                  <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                  <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                  <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                  <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#594B9C" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#33276A" />
              </asp:GridView>




            </td>


        </tr>
 <tr class="tblrowOdd" >
             <td colspan="4">
                 <asp:GridView ID="grdVTopSheetBikeCarHRLebel"  runat="server"   AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdvTopShNoneBike_PageIndexChanging" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                  
                       <asp:BoundField DataField="dteDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="dteDate" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       

                      <asp:BoundField DataField="strNamTop" HeaderText="Employee  Name" SortExpression="strNamTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       

                       <asp:BoundField DataField="decMovementDurationTop" HeaderText="MovDuraion" SortExpression="decMovementDurationTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decConsumedKmTop" HeaderText="Consumedkm" SortExpression="decConsumedKmTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                         <asp:BoundField DataField="decQntPetrolTop" HeaderText="QntPetr" SortExpression="decQntPetrolTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decCostPetrolTop" HeaderText="CostPetr" SortExpression="decCostPetrolTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decQntOctenTop" HeaderText="QntOct" SortExpression="decQntOctenTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decCostOctenTop" HeaderText="CostOct" SortExpression="decCostOctenTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decQntCarbonNitGasTop" HeaderText="QntCNG" SortExpression="decQntCarbonNitGasTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decCostCarbonNitGasTop" HeaderText="CostCng" SortExpression="decCostCarbonNitGasTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decQntLubricantTop" HeaderText="QntLubr" SortExpression="decQntLubricantTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decCostLubricant" HeaderText="CostLubr" SortExpression="decCostLubricant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>





                       <asp:BoundField DataField="decFareBusAmountTop" HeaderText="Bus" SortExpression="decFareBusAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="decFareRickshawAmountTop" HeaderText="Rick" SortExpression="decFareRickshawAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareCNGAmountTop" HeaderText="CNG" SortExpression="decFareCNGAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareTrainAmountTop" HeaderText="Train" SortExpression="decFareTrainAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareAirPlaneTop" HeaderText="AirPlane" SortExpression="decFareAirPlaneTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareOtherVheicleAmountTop" HeaderText="Anoth.Vh." SortExpression="decFareOtherVheicleAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>



                      <asp:BoundField DataField="decCostAmountMaintenaceTop" HeaderText="MntCost" SortExpression="decCostAmountMaintenaceTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFeryTollCostTop" HeaderText="FerryToll" SortExpression="decFeryTollCostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         
                         
                         
                          <asp:BoundField DataField="decDAAmountTop" HeaderText="OwnDA" SortExpression="decDAAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decDriverDACostTop" HeaderText="Oth.DA" SortExpression="decDriverDACostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decHotelBillAmountTop" HeaderText="Hotel" SortExpression="decHotelBillAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="decDriverHotelBillAmountTop" HeaderText="DrvHotel" SortExpression="decDriverHotelBillAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         
                       



                          <asp:BoundField DataField="decPhotoCopyCostTop" HeaderText="Photocopy" SortExpression="decPhotoCopyCostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCourierCostTop" HeaderText="Courier" SortExpression="decCourierCostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="decOtherBillAmountTop" HeaderText="OthCost" SortExpression="decOtherBillAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                      <asp:BoundField DataField="decRowTotalTop" HeaderText="Total " SortExpression="decrowtotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      

     
                     </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>
             </td>
             
         </tr>  

         <tr class="tblrowOdd" >
             <td colspan="10">
                 <asp:GridView ID="grdvBikeCarUserDetaillsHRLabel" runat="server" AutoGenerateColumns="False"  BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" HeaderStyle-Wrap="true" GridLines="None" OnPageIndexChanging="grdvBikeCarUserDetaillsHRLabel_PageIndexChanging">
                     <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <Columns>
                       
              
                            <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="From Date" SortExpression="dteFromdate" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="dteFromdateNoBikeDet"   CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Inst. Date" SortExpression="dteins" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField   ID="hdInsdate"   runat="server" Value='<%# Bind("dtIns", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="dteInsdateNoBikeDet"  CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dtIns") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesg", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="strDesgNoBikeDet" CssClass="txtBox" runat="server" TextMode="SingleLine" Text='<%# Bind("strDesg") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Start Time"  SortExpression="decstartt" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdstarttime" runat="server"  Value='<%# Bind("decStartTimeT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtStarTime" CssClass="txtBox" runat="server" TextMode="Number" Text='<%# Bind("decStartTimeT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="End Time"  SortExpression="decdecEndHourT" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdEndHour" runat="server"  Value='<%# Bind("decEndHourT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecEndHourT" CssClass="txtBox" runat="server" TextMode="Number" Text='<%# Bind("decEndHourT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"/>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Duration "   SortExpression="decMov" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdMovedur" runat="server"  Value='<%# Bind("decMovementDurationT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" TextMode="Number" Text='<%# Bind("decMovementDurationT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FromAddr."   SortExpression="strFromAdr" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromAddressT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrFromAddressT" CssClass="txtBox" runat="server" TextMode="SingleLine" Text='<%# Bind("strFromAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Movespots"  SortExpression="strmovmentspot" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strMovementAreaT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrMovementAreaT" CssClass="txtBox" runat="server" Text='<%# Bind("strMovementAreaT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="To Address"   SortExpression="strToAdr" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToAddressT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrToAddressT" CssClass="txtBox" runat="server" Text='<%# Bind("strToAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Night Stay"   SortExpression="strNight" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdNightstay" runat="server"  Value='<%# Bind("strNightStayT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrNightStayT" CssClass="txtBox" runat="server" TextMode="SingleLine" Text='<%# Bind("strNightStayT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="SMilage"   SortExpression="decstarmil" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                            <asp:HiddenField  ID="hdstartmilage"  runat="server" Value='<%# Bind("decStartMilageT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecStartMilageT"  CssClass="txtBox" runat="server" TextMode="Number" Text='<%# Bind("decStartMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                      
                            <asp:TemplateField HeaderText="EMilage"   SortExpression="decEndmil" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdEndmilage" runat="server" Value='<%# Bind("decEndMilageT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecEndMilageT"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decEndMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"/>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Cons." SortExpression="consumedkm" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdConsumedkm" runat="server" Value='<%# Bind("decConsumedKmT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecConsumedKmTBikeCar"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decConsumedKmT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Supporting"  SortExpression="strsuppor" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strSupportingNoT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrSupportingNoTBikeCar"  CssClass="txtBox" runat="server"   Text='<%# Bind("strSupportingNoT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="QntPetr" SortExpression="decpet" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                            <asp:HiddenField  ID="hdQpetr"  runat="server" Value='<%# Bind("decQntPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecQntPetrolTBikeCar"   CssClass="txtBox" runat="server"   Text='<%# Bind("decQntPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                      
                            <asp:TemplateField HeaderText="CostPetr" ItemStyle-Wrap="true" SortExpression="costpet" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdnCostpetr" runat="server" Value='<%# Bind("decCostPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecCostPetrolTBikeCar" OnTextChanged="txtdecCostPetrolTBikeCar_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decCostPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="QntOct"  SortExpression="decQntOcten" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdQntOcten" runat="server" Value='<%# Bind("decQntOctenT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecQntOctenTBikeCar"   CssClass="txtBox" runat="server"   Text='<%# Bind("decQntOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CostOct"  SortExpression="decCostOcten" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdCostocte" runat="server" Value='<%# Bind("decCostOctenT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecCostOctenTBikeCar" OnTextChanged="txtdecCostOctenTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  Text='<%# Bind("decCostOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

   
                            <asp:TemplateField HeaderText="QntCNG"  SortExpression="decQntCNG" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdQCNG" runat="server" Value='<%# Bind("decQntCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecQntCarbonNitGasTBikeCar"  CssClass="txtBox" runat="server"   Text='<%# Bind("decQntCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CostCNG."  SortExpression="CostCNG" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdCostcng" runat="server" Value='<%# Bind("decCostCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecCostCarbonNitGasTBikeCar" OnTextChanged="txtdecCostCarbonNitGasTBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="QntLubr"  SortExpression="decQntLubricant" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdQlubricantt" runat="server" Value='<%# Bind("decLubricantQnt", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecQntLubricantBikeCar"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decLubricantQnt") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CostLubr"  SortExpression="decCostLubricant" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdCostLubricant" runat="server" Value='<%# Bind("lubricantcost", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecCostLubricantBikeCar" OnTextChanged="txtdecCostLubricantBikeCar_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("lubricantcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Bus" SortExpression="decBus" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>

                            <asp:HiddenField  ID="hdBus"  runat="server" Value='<%# Bind("decFareBusAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareBusAmountTBikeCar" OnTextChanged="txtdecFareBusAmountTBikeCar_TextChanged"    CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareBusAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                      
                            <asp:TemplateField HeaderText="Rick" SortExpression="decRick" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decFareRickshawAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareRickshawAmountTBikeCar" OnTextChanged="txtdecFareRickshawAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareRickshawAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="TaxiCab"  SortExpression="decTaxiCab" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdtaxicab" runat="server" Value='<%# Bind("decFareCNGAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareCNGAmountTBikeCar" OnTextChanged="txtdecFareCNGAmountTBikeCar_TextChanged"    CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareCNGAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Train" SortExpression="decTrain" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("decFareTrainAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareTrainAmountTBikeCar" OnTextChanged="txtdecFareTrainAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareTrainAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Boat" SortExpression="decFareBoatAmountT" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdBoatBikeCar" runat="server" Value='<%# Bind("decFareBoatAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareBoatAmountT" OnTextChanged="txtdecFareBoatAmountT_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareBoatAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
 



                            <asp:TemplateField HeaderText="AirPlane" SortExpression="decAirPlane" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdPlane" runat="server" Value='<%# Bind("decFareAirPlaneT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareAirPlaneTBikeCar" OnTextChanged="txtdecFareAirPlaneTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareAirPlaneT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="OtherVhc." SortExpression="decOtherVhc" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("decFareOtherVheicleAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFareOtherVheicleAmountTBikeCar" OnTextChanged="txtdecFareOtherVheicleAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decFareOtherVheicleAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                  
           
                            <asp:TemplateField HeaderText="Mnt.Cost" SortExpression="decMnt" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdMntcost" runat="server" Value='<%# Bind("decCostAmountMaintenaceT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecCostAmountMaintenaceTBikeCar" OnTextChanged="txtdecCostAmountMaintenaceTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decCostAmountMaintenaceT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FerryToll." SortExpression="ferytol" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdoFerrytoll" runat="server" Value='<%# Bind("decFeryTollCostT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecFeryTollCostTBikeCar" OnTextChanged="txtdecFeryTollCostTBikeCar_TextChanged"   CssClass="txtBox" runat="server" TextMode="Number" Text='<%# Bind("decFeryTollCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>
              
                         
                         
                                   

                            <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decDAAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecDAAmountTBikeCar" OnTextChanged="txtdecDAAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decDAAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="DriverDA." SortExpression="decDriver" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decDriverDACostT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecDriverDACostTBikeCar" OnTextChanged="txtdecDriverDACostTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decDriverDACostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="OwnHot" SortExpression="decownhotel" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("decHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecHotelBillAmountTBikeCar" OnTextChanged="txtdecHotelBillAmountTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DrvHot" SortExpression="decdrivhotel" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddrivehote" runat="server" Value='<%# Bind("decDriverHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecDriverHotelBillAmountTBikeCar" OnTextChanged="txtdecDriverHotelBillAmountTBikeCar_TextChanged" CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decDriverHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                   
                            <asp:TemplateField HeaderText="PhotoC" SortExpression="decPhotocopy" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdPhotocpy" runat="server" Value='<%# Bind("decPhotoCopyCostT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecPhotoCopyCostTBikeCar" OnTextChanged="txtdecPhotoCopyCostTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decPhotoCopyCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Courier" SortExpression="decCourier" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddCourier" runat="server" Value='<%# Bind("decCourierCostT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecCourierCostTBikeCar"  OnTextChanged="txtdecCourierCostTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decCourierCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                     
                            <asp:TemplateField HeaderText="OtherCost"  SortExpression="decOtherCostAmount" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecOtherBillAmountTBikeCar" OnTextChanged="txtdecOtherBillAmountTBikeCar_TextChanged"  CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decOtherBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>

                     
                            <asp:TemplateField HeaderText="RowTotal" SortExpression="decrowtotal" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecRowTotalTBikeCar"  CssClass="txtBox" runat="server"  TextMode="Number" ReadOnly="true" Text='<%# Bind("decRowTotalT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                            </asp:TemplateField>


                                 <asp:TemplateField HeaderText="CNGCredit" SortExpression="decSupplierCNG" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecSupplierCNG" runat="server" Value='<%# Bind("decSupplierCNG", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierCNG" OnTextChanged="txtdecSupplierCNG_TextChanged" CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decSupplierCNG") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>

                     
                   <asp:TemplateField HeaderText="GasCredit" SortExpression="decSupplierGas" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecSupplierGas" runat="server" Value='<%# Bind("decSupplierGas", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierGas" OnTextChanged="txtdecSupplierGas_TextChanged" CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decSupplierGas") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="Perso.Milage" SortExpression="decPersonalMilage" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalMilage" runat="server" Value='<%# Bind("decPersonalMilage", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalMilage" OnTextChanged="txtdecPersonalMilage_TextChanged" CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decPersonalMilage") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>
                         

                  <asp:TemplateField HeaderText="MlgRate" SortExpression="decMlgRate" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecMlgRate" runat="server" Value='<%# Bind("decMlgRate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecMlgRate" OnTextChanged="txtdecMlgRate_TextChanged" CssClass="txtBox" runat="server" TextMode="Number" Text='<%# Bind("decMlgRate") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>

                         
                    


                         <asp:TemplateField HeaderText="PersoTotal" SortExpression="decPersonalTotalcost" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalTotalcost" runat="server" Value='<%# Bind("decPersonalTotalcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalTotalcost" OnTextChanged="txtdecPersonalTotalcost_TextChanged" CssClass="txtBox" runat="server"  TextMode="Number" Text='<%# Bind("decPersonalTotalcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>

                          <asp:TemplateField HeaderText="PmntType" SortExpression="PaymentType" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnPaymentType" runat="server" Value='<%# Bind("PaymentType", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtPaymentType" OnTextChanged="txtPaymentType_TextChanged" CssClass="txtBox" runat="server"  TextMode="SingleLine" Text='<%# Bind("PaymentType") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>

                     
                          <asp:TemplateField HeaderText="FuelStation" SortExpression="strFuelStationaname" HeaderStyle-HorizontalAlign="Center">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnstrFuelStationaname" runat="server" Value='<%# Bind("strFuelStationaname", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFuelStationaname" OnTextChanged="txtstrFuelStationaname_TextChanged" CssClass="txtBox" runat="server"  Text='<%# Bind("strFuelStationaname") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                     </asp:TemplateField>

                            <asp:TemplateField HeaderText="Enrol" SortExpression="intApplicantEnrol" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdApplicantenr" runat="server" Value='<%# Bind("intApplicantEnrol", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtAplEnrolBikeCar"  CssClass="txtBox" runat="server" TextMode="Number" ReadOnly="true" Text='<%# Bind("intApplicantEnrol") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                     
                            <asp:TemplateField HeaderText="Unit" SortExpression="intApplicantUnit" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hduni" runat="server" Value='<%# Bind("intApplicantUnit", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtUnitBikeCar" CssClass="txtBox" runat="server" TextMode="Number" ReadOnly="true" Text='<%# Bind("intApplicantUnit") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                     
                            <asp:TemplateField HeaderText="JobStation" SortExpression="intApplJobstation" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdJobs" runat="server" Value='<%# Bind("intApplJobstation", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtJobstatBikeCar" CssClass="txtBox" runat="server" TextMode="Number" ReadOnly="true" Text='<%# Bind("intApplJobstation") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Areaid" SortExpression="intAreaid" HeaderStyle-HorizontalAlign="Center">

                            <ItemTemplate>
                            <asp:HiddenField  ID="hdAreaid" runat="server" Value='<%# Bind("intAreaid", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtAreaID" CssClass="txtBox" runat="server" TextMode="Number" ReadOnly="true" Text='<%# Bind("intAreaid") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"/>
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
                  <tr class="tblrowOdd">

                      <td>

                           <asp:GridView ID="grdvTADAHRUnitTopsheetPrint" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdvTADAHRUnitTopsheetPrint_PageIndexChanging" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                      <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="SI" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                         <asp:BoundField DataField="strNam" HeaderText="Employee  Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="strDesg" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                          <asp:BoundField DataField="strunit" HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decRowTotalT" HeaderText="Grand Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                          <asp:BoundField DataField="strarea" HeaderText="Area" SortExpression="strarea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="intEmployeeid" HeaderText="intEmployeeid" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                         <asp:BoundField DataField="decAfterAprvbyhrgrand" HeaderText="AfterAprvByHR" SortExpression="decAfterAprvbyhrgrand" ItemStyle-HorizontalAlign="Center" />

                     </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>

                      </td>


                  </tr>

                   <tr class="tblrowodd">
                <td>
               

                    <asp:GridView ID="grdvBillMonitoringStatusHREND" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvBillMonitoringStatusHREND_PageIndexChanging" OnRowDataBound="grdvBillMonitoringStatusHREND_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Id" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmployeename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>



                            <asp:BoundField DataField="intEmployeeid" HeaderText="Employee Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                        
                      
                    
                      <asp:BoundField DataField="strSupervisor" HeaderText="Supervisor Name" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="LMAudit" HeaderText="Prev. Month Audit" SortExpression="LMAudit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="CMApplicant" HeaderText="CM Applicant" SortExpression="CMApplicant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="CMSupervisor" HeaderText="CM Supervisor" SortExpression="CMSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>



                          <asp:BoundField DataField="CMHR" HeaderText="CM HR" SortExpression="CMHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                         

                           <asp:BoundField DataField="decPersonaluseQnt"  HeaderText="Personal Qnt" SortExpression="decPersonaluseQnt" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decPersonalCost"  HeaderText="Personal Cost" SortExpression="decPersonalCost" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decAdvanceAmount"  HeaderText="Advance Amnt" SortExpression="decAdvanceAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="PayablebyHR" HeaderText="HRApproveforPay" SortExpression="PayablebyHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="PayablebyHR" HeaderText="RecvbyHR" SortExpression="PayablebyHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>



                       <asp:BoundField DataField="CMAudit"  HeaderText="CM Audit" SortExpression="CMAudit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                      
                       


                         <asp:BoundField DataField="strJobstation"  HeaderText="Job Station" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                     <asp:BoundField DataField="strArea"  HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                    <asp:BoundField DataField="strunit"  HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                 </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />


                 </asp:GridView>



                </td>


            </tr>

<tr class="tblrowodd">
                <td>
               

                    <asp:GridView ID="grdvTopareaspecific" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvTopareaspecific_PageIndexChanging" OnRowDataBound="grdvTopareaspecific_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Id" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmployeename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>



                            <asp:BoundField DataField="intEmployeeid" HeaderText="Employee Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                        
                      
                    
                      <asp:BoundField DataField="strSupervisor" HeaderText="Supervisor Name" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="LMAudit" HeaderText="Prev. Month Audit" SortExpression="LMAudit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="CMApplicant" HeaderText="CM Applicant" SortExpression="CMApplicant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="CMSupervisor" HeaderText="CM Supervisor" SortExpression="CMSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="CMHR" HeaderText="CM HR" SortExpression="CMHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                        

                           <asp:BoundField DataField="decPersonaluseQnt"  HeaderText="Personal Qnt" SortExpression="decPersonaluseQnt" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decPersonalCost"  HeaderText="Personal Cost" SortExpression="decPersonalCost" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decAdvanceAmount"  HeaderText="Advance Amnt" SortExpression="decAdvanceAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        <asp:BoundField DataField="PayablebyHR" HeaderText="HRApproveforPay" SortExpression="PayablebyHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                       <asp:BoundField DataField="CMAudit"  HeaderText="CM Audit" SortExpression="CMAudit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                        
                       



                         <asp:BoundField DataField="strJobstation"  HeaderText="Job Station" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                     <asp:BoundField DataField="strArea"  HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                    <asp:BoundField DataField="strunit"  HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                 </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />


                 </asp:GridView>



                </td>


            </tr>


 <tr class="tblrowodd">
                <td>
               


                    <asp:GridView ID="grdvAreaTopsheetHR" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvAreaTopsheetHR_PageIndexChanging" OnRowDataBound="grdvAreaTopsheetHR_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Id" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="strNam" HeaderText="Employee Name" SortExpression="strEmployeename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     <asp:BoundField DataField="strDesg" HeaderText="Desg" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decMovementDurationT" HeaderText="Duration" SortExpression="decMovementDurationT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decConsumedKmT" HeaderText="ConsumeKM" SortExpression="decConsumedKmT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                     <asp:BoundField DataField="decQntPetrolT" HeaderText=" Qnt.Petr" SortExpression="decQntPetrolT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decCostPetrolT" HeaderText="CostPet" SortExpression="decCostPetrolT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decQntOctenT" HeaderText="QntOct" SortExpression="decQntOctenT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                  
                          <asp:BoundField DataField="decCostOctenT" HeaderText="CostOct" SortExpression="decCostOctenT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntCarbonNitGasT" HeaderText="QntCNG" SortExpression="decQntCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostCarbonNitGasT" HeaderText="CostCNG" SortExpression="decCostCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decLubricantQnt" HeaderText="QntLubricant" SortExpression="decLubricantQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                       <asp:BoundField DataField="lubricantcost" HeaderText="CostLubricant" SortExpression="lubricantcost" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                          <asp:BoundField DataField="decFareBusAmountT" HeaderText="BusFare" SortExpression="decFareBusAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareRickshawAmountT" HeaderText="RickFare" SortExpression="decFareRickshawAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decFareCNGAmountT" HeaderText="TaxiCab" SortExpression="decFareCNGAmountT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareTrainAmountT" HeaderText="Train" SortExpression="decFareTrainAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareAirPlaneT" HeaderText="AirPlane" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareOtherVheicleAmountT" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostAmountMaintenaceT" HeaderText="Mnt.Cost" SortExpression="decCostAmountMaintenaceT.A" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decFeryTollCostT" HeaderText="FerryToll" SortExpression="decFeryTollCostT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decDAAmountT" HeaderText="OwnDa" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                         <asp:BoundField DataField="decDriverDACostT" HeaderText="DriverDA" SortExpression="decDriverDACostT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decHotelBillAmountT" HeaderText="OwnHotelB" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decDriverHotelBillAmountT" HeaderText="DrvHotelB" SortExpression="decDriverHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decPhotoCopyCostT" HeaderText="PhtCopy" SortExpression="decPhotoCopyCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCourierCostT" HeaderText="Courier" SortExpression="decCourierCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decOtherBillAmountT" HeaderText="Oth.Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decRowTotalT" HeaderText=" Cash Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <%--   decSupplierCNG , decSupplierGas , decPersonalMilage,  SupplierTotal,   Grand,decMlgRate ,decPersonalTotalcost--%>


                         <asp:BoundField DataField="decSupplierCNG" HeaderText="SupplierCNG" SortExpression="decSupplierCNG" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decSupplierGas" HeaderText="SupplierGas" SortExpression="decSupplierGas" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="SupplierTotal" HeaderText="SupplierTotal" SortExpression="SupplierTotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="Grand" HeaderText="Grand(cash credit)" SortExpression="Grand" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decPersonalMilage" HeaderText="PersonalMilage" SortExpression="decPersonalMilage" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decMlgRate" HeaderText="MlgRate" SortExpression="decMlgRate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decPersonalTotalcost" HeaderText="PersonalTotalcost" SortExpression="decPersonalTotalcost" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>



                 </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />


                 </asp:GridView>



                </td>


            </tr>


<tr class="tblrowodd">
                <td>
               

                    <asp:GridView ID="grdvCostAnalysis" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvTopareaspecific_PageIndexChanging" OnRowDataBound="grdvTopareaspecific_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Id" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmployeename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>



                            <asp:BoundField DataField="intEmployeeid" HeaderText="Employee Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="strEmpldesignation" HeaderText="Designation" SortExpression="strEmpldesignation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                    
                      <asp:BoundField DataField="strSupervisor" HeaderText="Supervisor Name" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                          <asp:BoundField DataField="decCMApplicant" HeaderText="Cash" SortExpression="CMApplicant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

   
                         <asp:BoundField DataField="decPersonalCost"  HeaderText="Personal Cost" SortExpression="decPersonalCost" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decCreditAmountFuelStation"  HeaderText="Credit" SortExpression="decCreditAmountFuelStation" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decTotalcost"  HeaderText="TotalCost" SortExpression="TotalCost" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decOfficialcost"  HeaderText="OfficialCost" SortExpression="officialCost" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decAdvanceAmount"  HeaderText="Advance Amnt" SortExpression="decAdvanceAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        

                       <asp:BoundField DataField="decNetpaybale"  HeaderText="NetPayable" SortExpression="Netpayable" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                 </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />


                 </asp:GridView>



                </td>


            </tr>

   </table>
 </div>



        <div>
            <table>
                 <tr class="tblrowodd">
                <td>
                  

                    <asp:GridView ID="grdvAdvanceSTATUSHR" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvAdvanceSTATUSHR_PageIndexChanging" OnRowDataBound="grdvAdvanceSTATUSHR_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <%--<asp:BoundField DataField="SL" HeaderText="Sl" SortExpression="SL" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>--%>

                          <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmplName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="intEnrol" HeaderText="Enrol" SortExpression="intEnrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="dteTourStartdate" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="FromDate" SortExpression="dteTourStartdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                         <asp:BoundField DataField="dteTourEndDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Todate" SortExpression="dteTourEndDate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                          <asp:BoundField DataField="intTotalday" HeaderText="Days" SortExpression="intTotalday" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         
 
                    
                      <asp:BoundField DataField="strMoveSport" HeaderText="Movement" SortExpression="strMoveSport" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     
                       <asp:BoundField DataField="strPurpouse" HeaderText="Purpouse" SortExpression="strPurpouse" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decAdvAmount" HeaderText="Advance" SortExpression="decAdvAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decApproveAmount"  HeaderText="SupApprove" SortExpression="decApproveAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decAproveAmountByAccount" HeaderText="AccountsApprove" SortExpression="decAproveAmountByAccount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                   </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />


                 </asp:GridView>



                </td>


            </tr>

            </table>

        </div>

          <div>
            <table>
                            <tr class="tblroweven">
                <td>
                 
                    <%--strSupervisor--%>

                    <asp:GridView ID="grdvBillMonitoring" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" OnRowDataBound="grdvBillMonitoring_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvBillMonitoring_PageIndexChanging">
                     <Columns>
                         
                         <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dteFromdate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="BillDate" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      

                      <asp:BoundField DataField="dtIns" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Insertion date" SortExpression="dtIns" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strNam" HeaderText="Employee Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="strDesg" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strSupervisor" HeaderText="Supervisor" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                     


                       <asp:BoundField DataField="decStartTimeT" HeaderText="StartT." SortExpression="decStartTimeT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decEndHourT" HeaderText="EndHour" SortExpression="decEndHourT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decMovementDurationT" HeaderText="Dur." SortExpression="decMovementDurationT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strFromAddressT" HeaderText="FromAdr" SortExpression="strFromAddressT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strMovementAreaT" HeaderText="MovementArea" SortExpression="strMovementAreaT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strToAddressT" HeaderText="To Addr." SortExpression="strToAddressT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strNightStayT" HeaderText="Night Stay" SortExpression="strNightStayT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decStartMilageT" HeaderText="Start Milage" SortExpression="decStartMilageT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decEndMilageT" HeaderText="End Milage" SortExpression="decEndMilageT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decConsumedKmT" HeaderText="Cons.KM" SortExpression="decConsumedKmT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strSupportingNoT" HeaderText="Supporting" SortExpression="strSupportingNoT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntPetrolT" HeaderText=" Qnt.Petr" SortExpression="decQntPetrolT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decCostPetrolT" HeaderText="CostPet" SortExpression="decCostPetrolT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decQntOctenT" HeaderText="QntOct" SortExpression="decQntOctenT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                  
                          <asp:BoundField DataField="decCostOctenT" HeaderText="CostOct" SortExpression="decCostOctenT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntCarbonNitGasT" HeaderText="QntCNG" SortExpression="decQntCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostCarbonNitGasT" HeaderText="CostCNG" SortExpression="decCostCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decLubricantQnt" HeaderText="QntLubricant" SortExpression="decLubricantQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                       <asp:BoundField DataField="lubricantcost" HeaderText="CostLubricant" SortExpression="lubricantcost" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                          <asp:BoundField DataField="decFareBusAmountT" HeaderText="BusFare" SortExpression="decFareBusAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareRickshawAmountT" HeaderText="RickFare" SortExpression="decFareRickshawAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decFareCNGAmountT" HeaderText="TaxiCab" SortExpression="decFareCNGAmountT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareTrainAmountT" HeaderText="Train" SortExpression="decFareTrainAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareAirPlaneT" HeaderText="AirPlane" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareOtherVheicleAmountT" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostAmountMaintenaceT" HeaderText="Mnt.Cost" SortExpression="decCostAmountMaintenaceT.A" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decFeryTollCostT" HeaderText="FerryToll" SortExpression="decFeryTollCostT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decDAAmountT" HeaderText="OwnDa" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                         <asp:BoundField DataField="decDriverDACostT" HeaderText="DriverDA" SortExpression="decDriverDACostT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decHotelBillAmountT" HeaderText="OwnHotelB" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decDriverHotelBillAmountT" HeaderText="DrvHotelB" SortExpression="decDriverHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decPhotoCopyCostT" HeaderText="PhtCopy" SortExpression="decPhotoCopyCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCourierCostT" HeaderText="Courier" SortExpression="decCourierCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decOtherBillAmountT" HeaderText="Oth.Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decRowTotalT" HeaderText="Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
  

                          <asp:BoundField DataField="decSupplierCNG" HeaderText="SupplierCNG" SortExpression="decSupplierCNG" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="decSupplierGas" HeaderText="SupplierGas" SortExpression="decSupplierGas" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decPersonalMilage" HeaderText="PersonalMilage" SortExpression="decPersonalMilage" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="SupplierTotal" HeaderText="SupplierTotal" SortExpression="SupplierTotal" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decMlgRate" HeaderText="MlgRate" SortExpression="decMlgRate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersonalTotalcost" HeaderText="PersonalTotalcost" SortExpression="decPersonalTotalcost" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" SortExpression="PaymentType" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                          <asp:BoundField DataField="strFuelStationaname" HeaderText="FuelStationaname" SortExpression="strFuelStationaname" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                     </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />

                           <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                 </asp:GridView>



                </td>


            </tr>
            </table>

        </div>

           <div>
            <table>
                            <tr class="tblroweven">
                <td>
                 
                    <%--strSupervisor--%>

                    <asp:GridView ID="grdvHRApproveMonitoring" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" OnRowDataBound="grdvHRApproveMonitoring_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvHRApproveMonitoring_PageIndexChanging">
                     <Columns>
                         
                         <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dteFromdate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="BillDate" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      

                      <asp:BoundField DataField="dtIns" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Insertion date" SortExpression="dtIns" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strNam" HeaderText="Employee Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="strDesg" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strSupervisor" HeaderText="Supervisor" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                     


                       <asp:BoundField DataField="decStartTimeT" HeaderText="StartT." SortExpression="decStartTimeT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decEndHourT" HeaderText="EndHour" SortExpression="decEndHourT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decMovementDurationT" HeaderText="Dur." SortExpression="decMovementDurationT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strFromAddressT" HeaderText="FromAdr" SortExpression="strFromAddressT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strMovementAreaT" HeaderText="MovementArea" SortExpression="strMovementAreaT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strToAddressT" HeaderText="To Addr." SortExpression="strToAddressT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strNightStayT" HeaderText="Night Stay" SortExpression="strNightStayT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decStartMilageT" HeaderText="Start Milage" SortExpression="decStartMilageT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decEndMilageT" HeaderText="End Milage" SortExpression="decEndMilageT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decConsumedKmT" HeaderText="Cons.KM" SortExpression="decConsumedKmT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strSupportingNoT" HeaderText="Supporting" SortExpression="strSupportingNoT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntPetrolT" HeaderText=" Qnt.Petr" SortExpression="decQntPetrolT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decCostPetrolT" HeaderText="CostPet" SortExpression="decCostPetrolT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decQntOctenT" HeaderText="QntOct" SortExpression="decQntOctenT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                  
                          <asp:BoundField DataField="decCostOctenT" HeaderText="CostOct" SortExpression="decCostOctenT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntCarbonNitGasT" HeaderText="QntCNG" SortExpression="decQntCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostCarbonNitGasT" HeaderText="CostCNG" SortExpression="decCostCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decLubricantQnt" HeaderText="QntLubricant" SortExpression="decLubricantQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                       <asp:BoundField DataField="lubricantcost" HeaderText="CostLubricant" SortExpression="lubricantcost" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                          <asp:BoundField DataField="decFareBusAmountT" HeaderText="BusFare" SortExpression="decFareBusAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareRickshawAmountT" HeaderText="RickFare" SortExpression="decFareRickshawAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decFareCNGAmountT" HeaderText="TaxiCab" SortExpression="decFareCNGAmountT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareTrainAmountT" HeaderText="Train" SortExpression="decFareTrainAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareAirPlaneT" HeaderText="AirPlane" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareOtherVheicleAmountT" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostAmountMaintenaceT" HeaderText="Mnt.Cost" SortExpression="decCostAmountMaintenaceT.A" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decFeryTollCostT" HeaderText="FerryToll" SortExpression="decFeryTollCostT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decDAAmountT" HeaderText="OwnDa" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                         <asp:BoundField DataField="decDriverDACostT" HeaderText="DriverDA" SortExpression="decDriverDACostT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decHotelBillAmountT" HeaderText="OwnHotelB" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decDriverHotelBillAmountT" HeaderText="DrvHotelB" SortExpression="decDriverHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decPhotoCopyCostT" HeaderText="PhtCopy" SortExpression="decPhotoCopyCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCourierCostT" HeaderText="Courier" SortExpression="decCourierCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decOtherBillAmountT" HeaderText="Oth.Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decRowTotalT" HeaderText="Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
  

                          <asp:BoundField DataField="decSupplierCNG" HeaderText="SupplierCNG" SortExpression="decSupplierCNG" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="decSupplierGas" HeaderText="SupplierGas" SortExpression="decSupplierGas" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decPersonalMilage" HeaderText="PersonalMilage" SortExpression="decPersonalMilage" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="SupplierTotal" HeaderText="SupplierTotal" SortExpression="SupplierTotal" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decMlgRate" HeaderText="MlgRate" SortExpression="decMlgRate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersonalTotalcost" HeaderText="PersonalTotalcost" SortExpression="decPersonalTotalcost" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" SortExpression="PaymentType" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                          <asp:BoundField DataField="strFuelStationaname" HeaderText="FuelStationaname" SortExpression="strFuelStationaname" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                     </Columns>


                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />

                           <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                 </asp:GridView>



                </td>


            </tr>
            </table>

        </div>


<%--=========================================End My Code From Here=================================================--%>
   <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>  
            