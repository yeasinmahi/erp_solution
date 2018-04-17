<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteGhatTransferChallan.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RemoteGhatTransferChallan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
 
    
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
    <div class="tabs_container"> Point to Point Transfer status :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnEmail" runat="server"/>
        <hr /></div>
                   <div>
        <table border="0"; style="width:Auto"; >    
        


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
                     <tr class="tblrowodd">
                  
                 <td style="text-align:right;">
                     <asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label>

                 </td>
                  <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                                                DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits"
                                                TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                  <td>
                             <asp:Label ID="lblRpttype" CssClass="lbl" runat="server" Text="Rpt. Type"></asp:Label>
                         </td>
                  <td>
                             <asp:DropDownList ID="ddlrpttype" runat="server" OnSelectedIndexChanged="ddlrpttype_SelectedIndexChanged">
                                 <asp:ListItem Selected="True" Text="Detaills" Value="1"></asp:ListItem>
                                  <asp:ListItem  Text="TopSheet" Value="2"></asp:ListItem>
                                 <asp:ListItem  Text="Item vs Specific Point" Value="3"></asp:ListItem>
                                 <asp:ListItem  Text="Item vs All Point" Value="4"></asp:ListItem>
                                  <asp:ListItem  Text="Vheicle vs Single Point" Value="5"></asp:ListItem>
                                 <asp:ListItem  Text="Vheicle vs all Point" Value="6"></asp:ListItem>
                                  <asp:ListItem  Text="DR(Topsheet) Single Point" Value="7"></asp:ListItem>
                                  <asp:ListItem  Text="DR(Topsheet) All Point" Value="8"></asp:ListItem>
                                 <asp:ListItem  Text="DR(Details) Single Point" Value="13"></asp:ListItem>
                                  <asp:ListItem  Text="DR(Details) All Point" Value="14"></asp:ListItem>

                             </asp:DropDownList>
                         </td>
        </tr>
        </td>
          

         <tr class="tblrowodd">
    

          <td style="text-align:right;">
                                         <asp:Label ID="lblFromPoint" CssClass="lbl" runat="server" Text="From Point"></asp:Label>
                                        </td>
          <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                DataTextField="strName" DataValueField="intShipPointId" 
                                                ondatabound="ddlShip_DataBound" 
                                                onselectedindexchanged="ddlShip_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetShipPoint"
                                                TypeName="SAD_BLL.Global.ShipPoint" 
                                                OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
          <td style="text-align:right;">
                                          <asp:Label ID="lblToPoint" CssClass="lbl" runat="server" Text="To Point"></asp:Label>
                                        </td>
          <td>
                                            <asp:DropDownList ID="drdltoshippoint" runat="server" AutoPostBack="True" DataSourceID="odsToshipPoint" DataTextField="strName"
                                                DataValueField="intShipPointId" OnDataBound="drdltoshippoint_DataBound" OnSelectedIndexChanged="drdltoshippoint_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsToshipPoint" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                           
                                        </td>



        </tr>
   

        <tr><td style="text-align:right" colspan="4"><asp:Button ID="btnGhatReport" runat="server" Text="Show" CssClass="button" OnClick="btnGhatReport_Click"  /></td></tr>
           </table>
          </div>
        

       
<div>
           <table>
        <tr class="tblrowodd">
             <td>
                 <asp:GridView ID="grdvTopSheet" runat="server" AutoGenerateColumns="False"  CellPadding="4" Width="100%" PageSize="10000" ShowFooter="true" AllowPaging="True" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" GridLines="Vertical" ForeColor="Black" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" OnPageIndexChanging="grdvTopSheet_PageIndexChanging" BorderWidth="1px">

                                            <AlternatingRowStyle BackColor="White" />
                     <%--dteInsertionTime,strCode,numPieces,strVehicleRegNo,strSupplier,strAddress,intSalesOffId,intShipPointIdFROM,strfpoint,strTopoint--%>
                                            <Columns>
                                               <asp:TemplateField HeaderText="Sl"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                                
                                                  <asp:BoundField DataField="strfpoint" HeaderText="From Point" SortExpression="strfpoint" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="numPieces" HeaderText="Qnt." SortExpression="numPieces" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                
                                             
                                                 <asp:BoundField DataField="strTopoint" HeaderText="To Point" SortExpression="strTopoint" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                            </Columns>


                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" /></asp:GridView>

                  </td>
              </tr>

           </table>
           </div>

<div>
           <table>
        <tr class="tblrowodd">
             <td>
                 <asp:GridView ID="grdvForItemcodevsSpecificPoint" runat="server" AutoGenerateColumns="False"  CellPadding="3" Width="100%" PageSize="10000" AllowPaging="True" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" BackColor="White" ShowFooter="True" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical" >
                     <%--dteInsertionTime,strCode,numPieces,strVehicleRegNo,strSupplier,strAddress,intSalesOffId,intShipPointIdFROM,strfpoint,strTopoint,itemid , converteditemcode ,stritemname--%>
                                            <AlternatingRowStyle BackColor="#DCDCDC" />
                                            <Columns>
                                               <asp:TemplateField HeaderText="Sl"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                                 <asp:BoundField DataField="dteInsertionTime" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="dteInsertionTime">
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strCode" HeaderText="Challan" SortExpression="strCode" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strVehicleRegNo" HeaderText="VehicleRegNo" SortExpression="strVehicleRegNo" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="strfpoint" HeaderText="From Point" SortExpression="strfpoint" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strTopoint" HeaderText="To Point" SortExpression="strTopoint" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="itemid" HeaderText="Item ID" SortExpression="itemid" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>

                                                

                                                 <asp:BoundField DataField="converteditemcode" HeaderText="Item Code" SortExpression="converteditemcode" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="stritemname" HeaderText="Item Name" SortExpression="stritemname" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>


                                                 <asp:BoundField DataField="numPieces" HeaderText="Qnt." SortExpression="numPieces" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 
                                                


                                              

                                            </Columns>


                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#000065" /></asp:GridView>

                  </td>
              </tr>

           </table>
           </div>
       
<div>
           <table>
        <tr class="tblrowodd">
             <td>
                 <asp:GridView ID="grdvTransportvsPoint" runat="server" AutoGenerateColumns="False"  CellPadding="3" Width="100%" PageSize="10000" AllowPaging="True" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" BackColor="White" ShowFooter="True" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical" >
                     
                                            <AlternatingRowStyle BackColor="#DCDCDC" />
                                            <Columns>
                                               <asp:TemplateField HeaderText="Sl"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                                 <asp:BoundField DataField="dteInsertionTime" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="dteInsertionTime"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strCode" HeaderText="Challan" SortExpression="strCode" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strVehicleRegNo" HeaderText="VehicleRegNo" SortExpression="strVehicleRegNo" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="strfpoint" HeaderText="From Point" SortExpression="strfpoint" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strTopoint" HeaderText="To Point" SortExpression="strTopoint" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                


                                                 <asp:BoundField DataField="numPieces" HeaderText="Qnt." SortExpression="numPieces" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 
                                                


                                              

                                            </Columns>


                                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
                                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#000065" /></asp:GridView>

                  </td>
              </tr>

           </table>
           </div>

<div>
           <table>
        <tr class="tblrowodd">
             <td>
                 <asp:GridView ID="grdvDRSummerySpecificPoint" runat="server" AutoGenerateColumns="False"  CellPadding="4" Width="100%" PageSize="10000" AllowPaging="True" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" BackColor="White" ShowFooter="True" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" >
                   
            <Columns>
                <asp:TemplateField HeaderText="Sl"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                                
                <asp:BoundField DataField="itemname" HeaderText="Item Name" SortExpression="strCode" ControlStyle-Width="40%" >
                    <ControlStyle Width="40%" />
                </asp:BoundField>
                <asp:BoundField DataField="intprductid" HeaderText="ItemID" SortExpression="strVehicleRegNo" ControlStyle-Width="10%" >
                    <ControlStyle Width="10%" />
                </asp:BoundField>

                <asp:BoundField DataField="detectionofcode" HeaderText="ItemCode" SortExpression="strfpoint" ControlStyle-Width="40%" >
                    <ControlStyle Width="40%" />
                </asp:BoundField>
                    <asp:BoundField DataField="opendingdoqnt" HeaderText="OP UND Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                                                

                    <asp:BoundField DataField="decdoqnt" HeaderText=" D.O Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                    <asp:BoundField DataField="decchallanqnt" HeaderText=" Challan Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                    <asp:BoundField DataField="numresqntbyso" HeaderText="Present Und Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                <asp:BoundField DataField="strtopoint" HeaderText="Point Name" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>


            </Columns>


            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle ForeColor="#003399" BackColor="White" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" /></asp:GridView>

            </td>
            </tr>

            </table>
           </div>
<div>
           <table>
        <tr class="tblrowodd">
             <td>
                 <asp:GridView ID="grdvDRSummeryDetaills" runat="server" AutoGenerateColumns="False"  CellPadding="3" Width="100%" PageSize="10000" AllowPaging="True" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" BackColor="#DEBA84" ShowFooter="True" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"  CellSpacing="2" >
                   
            <Columns>
                <asp:TemplateField HeaderText="Sl"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                   
                <asp:BoundField DataField="dtedate" HeaderText="InsertionDate"  SortExpression="dtedate" DataFormatString="{0:dd-MM-yyyy}" ControlStyle-Width="67%" >
                    <ControlStyle Width="67%" />
                </asp:BoundField>
                <asp:BoundField DataField="donumber" HeaderText="DR N.O" SortExpression="donumber" ControlStyle-Width="10%" >
                    <ControlStyle Width="10%" />
                </asp:BoundField>



                <asp:BoundField DataField="itemname" HeaderText="Item Name" SortExpression="strCode" ControlStyle-Width="40%" >
                    <ControlStyle Width="40%" />
                </asp:BoundField>
                <asp:BoundField DataField="intprductid" HeaderText="ItemID" SortExpression="strVehicleRegNo" ControlStyle-Width="10%" >
                    <ControlStyle Width="10%" />
                </asp:BoundField>

                <asp:BoundField DataField="detectionofcode" HeaderText="ItemCode" SortExpression="strfpoint" ControlStyle-Width="40%" >
                    <ControlStyle Width="40%" />
                </asp:BoundField>
                  
                                                

                    <asp:BoundField DataField="decdoqnt" HeaderText=" D.O Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                    <asp:BoundField DataField="decchallanqnt" HeaderText=" Challan Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                    <asp:BoundField DataField="numresqntbyso" HeaderText="Present Und Qnt" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>

                <asp:BoundField DataField="strtopoint" HeaderText="Point Name" SortExpression="strTopoint" ControlStyle-Width="13%" >

                    <ControlStyle Width="10%" />
                </asp:BoundField>


            </Columns>


            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" /></asp:GridView>

            </td>
            </tr>

            </table>
           </div>

<div>
           <table>
        <tr class="tblrowodd">
             <td>
                 <asp:GridView ID="grdtransferdet" runat="server" AutoGenerateColumns="False"  CellPadding="3" Width="100%" PageSize="10000" AllowPaging="false" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" GridLines="Vertical" ForeColor="Black" BackColor="White" ShowFooter="true" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" >

                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                   
                                            <Columns>
                                               <asp:TemplateField HeaderText="Sl"><ItemTemplate><%#Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                                                 <asp:BoundField DataField="dteInsertionTime" HeaderText="Date" SortExpression="dteInsertionTime"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strCode" HeaderText="Challan" SortExpression="strCode" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="numPieces" HeaderText="Qnt." SortExpression="numPieces" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="strVehicleRegNo" HeaderText="VehicleRegNo" SortExpression="strVehicleRegNo" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <%--<asp:BoundField DataField="strSupplier" HeaderText="Supplier" SortExpression="strSupplier" ControlStyle-Width="10%" >
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>


                                                <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="strAddress"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strfpoint" HeaderText="From Point" SortExpression="strfpoint" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strTopoint" HeaderText="To Point" SortExpression="strTopoint" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>--%>

                                            </Columns>


                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            <RowStyle />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" /></asp:GridView>

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