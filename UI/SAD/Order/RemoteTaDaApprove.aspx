<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTaDaApprove.aspx.cs" Inherits="UI.SAD.Order.RemoteTaDaApprove" %>

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
    <div class="tabs_container"> None Bike user TA - DA information Approve   :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="Employee Name:  " ></asp:Label></td>
                                <td> <asp:TextBox ID="txtFullName" runat="server" Width="300px" CssClass="txtBox"></asp:TextBox> </td>
        
             <td style="text-align:right"><asp:Label ID="lblUnitName" CssClass="lbl" runat="server" Text="Unit:  "></asp:Label></td>
                                <td><asp:DropDownList ID="drdlUnitList" runat="server" DataSourceID="odsUnitList" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsUnitList" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
              </tr>
           
            
            
            
            <tr class="tblroweven"><td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server" DataTextField="strReportType" DataValueField="intID" DataSourceID="odsReportTypetadaApr"></asp:DropDownList>
                                    
                                   
                                    
                                    <asp:ObjectDataSource ID="odsReportTypetadaApr" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
                                        <InsertParameters>
                                            <asp:Parameter Name="strReportType" Type="String" />
                                        </InsertParameters>
                                    </asp:ObjectDataSource>
                                    
                                   
                                    
                </td>
               <td style="text-align:right"><asp:Label ID="lblUserCatg" CssClass="lbl" runat="server" Text="Emmplyee Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="drdlEmlployeetype" runat="server" DataSourceID="odsNoneCategoryuser" DataTextField="strUser Type" DataValueField="intID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsNoneCategoryuser" runat="server" SelectMethod="getNoneCategoryuserlist" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
              </td>
         </tr>

        <tr class="tblrowOdd"><td style="text-align:right" colspan="4"> <asp:Button ID="btnShow" runat="server" Text="Show Bill Info" OnClick="btnShow_Click" /></td> 
           
           

             <td style="text-align:right" ><asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" BackColor="#ffcc99" Font-Bold="true" /> </td>
        </tr>
         </table>
        </div>



          <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven"><td>
              </td>
         </tr>          

         <tr class="tblrowOdd" >
             <td>
                 <asp:GridView ID="GridView1"  runat="server"   AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="3000" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                     <Columns>
                       
                         <asp:BoundField DataField="dteFromdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       

                      <asp:BoundField DataField="strNam" HeaderText="Employee  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="Movdur" HeaderText="MovDuraion" SortExpression="decMovDuraion" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="Busfare" HeaderText="Bus" SortExpression="decBus" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="rickf" HeaderText="Rick" SortExpression="decRick" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="cngf" HeaderText="CNG" SortExpression="decCNG" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="trainf" HeaderText="Train" SortExpression="decTrain" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="boatf" HeaderText="Boat" SortExpression="decBoat" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="othvh" HeaderText="Anoth.Vh." SortExpression="decAnother" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      

                      <asp:BoundField DataField="ownda" HeaderText="OwnDA" SortExpression="decOwnDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="otherda" HeaderText="Oth.DA" SortExpression="decOtherDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="hotel" HeaderText="Hotel" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="othercost" HeaderText="Other Cost" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         

                      <asp:BoundField DataField="rowtoal" HeaderText="Total " SortExpression="decrowtotal" ItemStyle-HorizontalAlign="Center" >
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
            <td>
<asp:GridView ID="GridviewTADADetaill" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridviewTADADetaill_PageIndexChanging">
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





                      
                                <asp:TemplateField HeaderText="Inst. Date" SortExpression="dteToDate">
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
                    <asp:TextBox ID="txtfareNoBikeDet" OnTextChanged="txtfareNoBikeDet_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decfare") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="Rick" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decrick", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecrick" OnTextChanged="txtdecrick_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decrick") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="CNG" SortExpression="cng">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdCNG" runat="server" Value='<%# Bind("cng", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtcng" OnTextChanged="txtcng_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("cng") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Other" SortExpression="decOth">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("train", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txttrain" OnTextChanged="txttrain_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("train") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="Boat" SortExpression="decBoat">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdBoat" runat="server" Value='<%# Bind("boat", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtboat" OnTextChanged="txtboat_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("boat") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OtherVhc." SortExpression="decRowTotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("othevh", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtothevh" OnTextChanged="txtothevh_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("othevh") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
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
                    <asp:TextBox ID="txtdecownda" OnTextChanged="txtdecownda_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decownda") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Other DA." SortExpression="decOtherda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decOtherda", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherda" OnTextChanged="txtdecOtherda_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decOtherda") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Hotel" SortExpression="dechotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("dechotel", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdechotel" OnTextChanged="txtdechotel_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("dechotel") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                      <asp:TemplateField HeaderText="OtherCost" SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherCostAmount", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txthddecOtherCostAmount" OnTextChanged="txthddecOtherCostAmount_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decOtherCostAmount") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                       <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decrowtotal", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecrowtotal" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decrowtotal") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
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

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>