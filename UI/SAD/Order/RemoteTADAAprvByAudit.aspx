<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAAprvByAudit.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAAprvByAudit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />



    <script src="../../../../Content/JS/datepickr.min.js"></script>

    

      
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





</script>


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
    <div class="tabs_container">  TA - DA information Approve by Audit (Both Category user)  :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="Employee Name:  " ></asp:Label></td>
                                <td> <asp:TextBox ID="txtFullName" runat="server" Width="300px" CssClass="txtBox"></asp:TextBox> </td>
        

             <td style="text-align:right"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Unit:  " ></asp:Label></td>
              <td>
              <asp:DropDownList ID="drdulUnit" runat="server" Height="16px" DataSourceID="odsUnitn" DataTextField="strUnit" DataValueField="intUnitID">
               </asp:DropDownList>
                  <asp:ObjectDataSource ID="odsUnitn" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                  </td>

          </tr>
          
    <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label>
               
    </td>
                               
    <td>
    <asp:DropDownList ID="ddlUserType" runat="server" Height="16px" DataTextField="strUser Type" DataValueField="intID" DataSourceID="odsustype">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="odsustype" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRmtUserCatg" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAUserTypeTableAdapter">
    <InsertParameters>
    <asp:Parameter Name="strUser_Type" Type="String" />
    </InsertParameters>
    </asp:ObjectDataSource>
    </td>
    <td style="text-align:right"><asp:Label ID="lblReportType" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
    <td>
    <asp:DropDownList ID="drdlReportType" runat="server" DataSourceID="odsRptType" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsRptType" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
    <InsertParameters>
    <asp:Parameter Name="strReportType" Type="String" />
    </InsertParameters>
    </asp:ObjectDataSource>
    </td>
  
               
    </tr>
    <tr class="tblrowOdd"><td style="text-align:right"> <asp:Button ID="btnShow" runat="server" Text="Show Bill Info" OnClick="btnShow_Click" /></td> 
    <td style="text-align:right" ><asp:Button ID="btenExporttoexcel" runat="server" Text="Save"  Font-Bold="true" OnClick="btenExporttoexcel_Click"/> </td>
      <td style="text-align:right" ><asp:Button ID="btnAnalysis" runat="server" Text="Analysis" BackColor="#66ff99" Font-Bold="true" OnClick="btnAnalysis_Click" /> </td>
       <td style="text-align:right" ><asp:Button ID="btnApprove" runat="server" Text="Approve" BackColor="#ffcc99" Font-Bold="true" OnClick="btnApprove_Click" /> </td>
          </tr>

     <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          

         <tr class="tblrowOdd" >
             <td colspan="4">
                 <asp:GridView ID="grdvTopShNoneBikeForAudit"  runat="server"   AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
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
                     <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
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
<asp:GridView ID="GridvDetNonBikeUserAuditleb" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical" ForeColor="Black">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                   

                      <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                  


                                <asp:TemplateField HeaderText="From Date" SortExpression="dteFromDate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteFromdateNoBikeDet"  DataFormatString="{0:dd/MM/yyyy}" CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>





                      
                                <asp:TemplateField HeaderText="Inst. Date" SortExpression="dtIns">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdToDate"   runat="server" Value='<%# Bind("dtIns", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteInsdateNoBikeDet" DataFormatString="{0:dd/MM/yyyy}" CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dtIns") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>



                    

                     <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>




                        <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strDesgNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strDesg") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="FromAddress" SortExpression="strFromAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromaddr", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strFromaddrNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strFromaddr") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="To Address" SortExpression="strToAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToadr", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strToadrNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strToadr") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>



                        <asp:TemplateField HeaderText="Movementspots" SortExpression="strmovmentspot">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strmovmentspot", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strMovemetspotNonebikeuser" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strmovmentspot") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

  
                        <asp:TemplateField HeaderText="Movement duration " SortExpression="decMov">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMove" runat="server"  Value='<%# Bind("decmovdur", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decmovdur") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       
                         <asp:TemplateField HeaderText="Fare" SortExpression="decFare">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdFare"  runat="server" Value='<%# Bind("decfare", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtfareNoBikeDet" OnTextChanged="txtfareNoBikeDet_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decfare") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="Rick" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decrick", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecrick"  OnTextChanged="txtdecrick_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decrick") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="CNG" SortExpression="cng">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdCNG" runat="server" Value='<%# Bind("cng", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtcng"  CssClass="txtBox" OnTextChanged="txtcng_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("cng") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Other" SortExpression="decOth">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("train", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txttrain"   CssClass="txtBox" OnTextChanged="txttrain_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("train") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="Boat" SortExpression="decBoat">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdBoat" runat="server" Value='<%# Bind("boat", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtboat"  CssClass="txtBox" OnTextChanged="txtboat_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("boat") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OtherVhc." SortExpression="decRowTotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("othevh", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtothevh" CssClass="txtBox" OnTextChanged="txtothevh_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("othevh") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="Remarks" SortExpression="strsuppor">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strsuppor", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrsuppor"  CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strsuppor") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                     

                      <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decownda", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecownda"  CssClass="txtBox" OnTextChanged="txtdecownda_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decownda") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Other DA." SortExpression="decOtherda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decOtherda", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherda"  CssClass="txtBox" OnTextChanged="txtdecOtherda_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decOtherda") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Hotel" SortExpression="dechotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("dechotel", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdechotel"  CssClass="txtBox" OnTextChanged="txtdechotel_TextChanged" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("dechotel") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                      <asp:TemplateField HeaderText="OtherCost" SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherCostAmount", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txthddecOtherCostAmount" OnTextChanged="txthddecOtherCostAmount_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decOtherCostAmount") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                       <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decrowtotal", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecrowtotal" CssClass="txtBox" ReadOnly="true" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decrowtotal") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                        <asp:TemplateField HeaderText="Contact" SortExpression="strContac">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdContact" runat="server" Value='<%# Bind("strContac", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrContac" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("strContac") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                      <asp:TemplateField HeaderText="Phone" SortExpression="strphone">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrphone" runat="server" Value='<%# Bind("strphone", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrphone" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("strphone") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                      <asp:TemplateField HeaderText="Visited Org" SortExpression="strVisitorg">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrVisitorg" runat="server" Value='<%# Bind("strVisitorg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrVisitorg" CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strVisitorg") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                      <asp:TemplateField HeaderText="UnitID" SortExpression="intUnitID">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnUnit" runat="server" Value='<%# Bind("intUnit", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtUnitid" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("intUnit") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>



                      <asp:TemplateField HeaderText="JobStaid" SortExpression="intJobStaid">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdJobstation" runat="server" Value='<%# Bind("intJobstation", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtJobstation" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("intJobstation") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>






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
             <td colspan="4">
                 <asp:GridView ID="grdVTopSheetBikeCarAuditLebel"  runat="server"   AutoGenerateColumns="False" AllowPaging="True"  PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
             <td colspan="4">
                 <asp:GridView ID="grdvBikeCarUserDetaillsAuditLabel" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" HeaderStyle-Wrap="true" GridLines="None">
                     <AlternatingRowStyle BackColor="PaleGoldenrod" />
                     <Columns>
                       
             

                         <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

  <asp:TemplateField HeaderText="From Date" SortExpression="dteFromdate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteFromdateNoBikeDet"   CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Inst. Date" SortExpression="dteins">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdInsdate"   runat="server" Value='<%# Bind("dtIns", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteInsdateNoBikeDet"  CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dtIns") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
 <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strDesgNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strDesg") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="decStartTimeT" SortExpression="decstartt">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdstarttime" runat="server"  Value='<%# Bind("decStartTimeT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtStarTime" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decStartTimeT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="decEndHourT" SortExpression="decdecEndHourT">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndHour" runat="server"  Value='<%# Bind("decEndHourT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndHourT" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decEndHourT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Movement duration " SortExpression="decMov">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovedur" runat="server"  Value='<%# Bind("decMovementDurationT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decMovementDurationT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="FromAddress" SortExpression="strFromAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFromAddressT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strFromAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="Movementspots" SortExpression="strmovmentspot">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strMovementAreaT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrMovementAreaT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strMovementAreaT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>




 <asp:TemplateField HeaderText="To Address" SortExpression="strToAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrToAddressT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strToAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="NightStay" SortExpression="strNight">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdNightstay" runat="server"  Value='<%# Bind("strNightStayT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrNightStayT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strNightStayT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="startMilage" SortExpression="decstarmil">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdstartmilage"  runat="server" Value='<%# Bind("decStartMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecStartMilageT"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decStartMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="EndMilage" SortExpression="decEndmil">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndmilage" runat="server" Value='<%# Bind("decEndMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndMilageT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decEndMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="Consumedkm" SortExpression="consumedkm">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdConsumedkm" runat="server" Value='<%# Bind("decConsumedKmT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecConsumedKmTBikeCar"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decConsumedKmT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="Supporting" SortExpression="strsuppor">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strSupportingNoT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrSupportingNoTBikeCar"  CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strSupportingNoT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="QntPetrol" SortExpression="decpet">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdQpetr"  runat="server" Value='<%# Bind("decQntPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntPetrolTBikeCar"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decQntPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="CostPetrol" SortExpression="costpet">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnCostpetr" runat="server" Value='<%# Bind("decCostPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostPetrolTBikeCar" OnTextChanged="txtdecCostPetrolTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntOcten" SortExpression="decQntOcten">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdQntOcten" runat="server" Value='<%# Bind("decQntOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntOctenTBikeCar"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decQntOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="CostOcten" SortExpression="decCostOcten">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdCostocte" runat="server" Value='<%# Bind("decCostOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostOctenTBikeCar" OnTextChanged="txtdecCostOctenTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="QntCNG" SortExpression="decQntCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQCNG" runat="server" Value='<%# Bind("decQntCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntCarbonNitGasTBikeCar"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decQntCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CostCNG." SortExpression="CostCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostcng" runat="server" Value='<%# Bind("decCostCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostCarbonNitGasTBikeCar" OnTextChanged="txtdecCostCarbonNitGasTBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntLubricant" SortExpression="decQntLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQlubricantt" runat="server" Value='<%# Bind("decLubricantQnt", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntLubricantBikeCar"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decLubricantQnt") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CostLubricant." SortExpression="decCostLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostLubricant" runat="server" Value='<%# Bind("lubricantcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostLubricantBikeCar" OnTextChanged="txtdecCostLubricantBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("lubricantcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>












  <asp:TemplateField HeaderText="Bus" SortExpression="decBus">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdBus"  runat="server" Value='<%# Bind("decFareBusAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBusAmountTBikeCar" OnTextChanged="txtdecFareBusAmountTBikeCar_TextChanged"    CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareBusAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="Rick" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decFareRickshawAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareRickshawAmountTBikeCar" OnTextChanged="txtdecFareRickshawAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareRickshawAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="TaxiCab" SortExpression="decTaxiCab">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdtaxicab" runat="server" Value='<%# Bind("decFareCNGAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareCNGAmountTBikeCar" OnTextChanged="txtdecFareCNGAmountTBikeCar_TextChanged"    CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareCNGAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Train" SortExpression="decTrain">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("decFareTrainAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareTrainAmountTBikeCar" OnTextChanged="txtdecFareTrainAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareTrainAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="AirPlane" SortExpression="decAirPlane">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPlane" runat="server" Value='<%# Bind("decFareAirPlaneT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareAirPlaneTBikeCar" OnTextChanged="txtdecFareAirPlaneTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareAirPlaneT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OtherVhc." SortExpression="decOtherVhc">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("decFareOtherVheicleAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareOtherVheicleAmountTBikeCar" OnTextChanged="txtdecFareOtherVheicleAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareOtherVheicleAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                  
           
            <asp:TemplateField HeaderText="Mnt.Cost" SortExpression="decMnt">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdMntcost" runat="server" Value='<%# Bind("decCostAmountMaintenaceT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostAmountMaintenaceTBikeCar" OnTextChanged="txtdecCostAmountMaintenaceTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostAmountMaintenaceT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="FerryToll." SortExpression="ferytol">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdoFerrytoll" runat="server" Value='<%# Bind("decFeryTollCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFeryTollCostTBikeCar" OnTextChanged="txtdecFeryTollCostTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFeryTollCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
              
                         
                         
                                   

                      <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decDAAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDAAmountTBikeCar" OnTextChanged="txtdecDAAmountTBikeCar_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decDAAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Driver DA." SortExpression="decDriver">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decDriverDACostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverDACostTBikeCar" OnTextChanged="txtdecDriverDACostTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decDriverDACostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Own Hotel" SortExpression="decownhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("decHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecHotelBillAmountTBikeCar" OnTextChanged="txtdecHotelBillAmountTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Driver Hotel" SortExpression="decdrivhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddrivehote" runat="server" Value='<%# Bind("decDriverHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverHotelBillAmountTBikeCar" OnTextChanged="txtdecDriverHotelBillAmountTBikeCar_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decDriverHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Photocopy" SortExpression="decPhotocopy">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPhotocpy" runat="server" Value='<%# Bind("decPhotoCopyCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPhotoCopyCostTBikeCar" OnTextChanged="txtdecPhotoCopyCostTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPhotoCopyCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Courier" SortExpression="decCourier">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddCourier" runat="server" Value='<%# Bind("decCourierCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCourierCostTBikeCar"  OnTextChanged="txtdecCourierCostTBikeCar_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCourierCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                     
                      <asp:TemplateField HeaderText="OtherCost"  SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherBillAmountTBikeCar" OnTextChanged="txtdecOtherBillAmountTBikeCar_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decOtherBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                       <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecRowTotalTBikeCar"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decRowTotalT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Enrol" SortExpression="intApplicantEnrol">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdApplicantenr" runat="server" Value='<%# Bind("intApplicantEnrol", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtAplEnrolBikeCar"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("intApplicantEnrol") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                     
                      <asp:TemplateField HeaderText="Unit" SortExpression="intApplicantUnit">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hduni" runat="server" Value='<%# Bind("intApplicantUnit", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtUnitBikeCar" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("intApplicantUnit") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                       <asp:TemplateField HeaderText="JobStation" SortExpression="intApplJobstation">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdJobs" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtJobstatBikeCar" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("intApplJobstation") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
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
                 </asp:GridView>
             </td>
             
         </tr>  

</table>               

</div>
            <div>
                <table>
                    <tr>
                        <td>
                         <asp:GridView ID="grdvAnalysisAudit" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdvAnalysisAudit_PageIndexChanging" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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

                          <asp:BoundField DataField="strarea" HeaderText="Area" SortExpression="strarea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                        

                          <asp:BoundField DataField="intEmployeeid" HeaderText="intEmployeeid" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                         <asp:BoundField DataField="PrevMonByAudit" HeaderText="PrevMonByAudit" SortExpression="PrevMonByAudit" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="aprvbySupervisorCurrentMonth" HeaderText="CurrentMbySupervisor" SortExpression="aprvbySupervisorCurrentMonth" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="aprvbyHRCurrentMonth" HeaderText="CurrentMbyHR" SortExpression="aprvbyHRCurrentMonth" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="aprvByAuditCurrentMonth" HeaderText="CurrentMbyAudit" SortExpression="aprvByAuditCurrentMonth" ItemStyle-HorizontalAlign="Center" />








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


                </table>


            </div>

</div>







        <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
