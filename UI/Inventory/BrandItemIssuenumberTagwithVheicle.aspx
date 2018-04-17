<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemIssuenumberTagwithVheicle.aspx.cs" Inherits="UI.Inventory.BrandItemIssuenumberTagwithVheicle" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    
    <style type="text/css">
        .auto-style1 {
            height: 61px;
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
    <div class="tabs_container"> Issue number tagging  status  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnunitid" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnEmail" runat="server"/><asp:HiddenField ID="hdnunit" runat="server"/><asp:HiddenField ID="hdnwh" runat="server"/>
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
         <tr class="tblrowodd">
      


              <td style="text-align:right" class="auto-style1"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td class="auto-style1"><asp:DropDownList ID="drdlUnitName" CssClass="ddList"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>


        <td style="text-align:right;" class="auto-style1"><asp:Label ID="lblGhatName" CssClass="lbl" runat="server" Text="Shipping point Name: "></asp:Label></td>
      
  
                    <td> <asp:DropDownList ID="drdlGhat" runat="server" CssClass="ddList" DataSourceID="odsShipping" DataTextField="strName" DataValueField="intShipPointId"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsShipping" runat="server" SelectMethod="getShippingPoint" TypeName="SAD_BLL.Customer.Report.StatementC">
                <SelectParameters>
                    <asp:SessionParameter Name="officeemail" SessionField="sesEmail" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
             </td>
        </tr>
            
            <tr>
                
             <td style="text-align:right;"><asp:Label ID="lblChallanumber" CssClass="lbl" runat="server" Text="Challan Number: "></asp:Label></td>
        <td><asp:TextBox ID="txtchallan" CssClass="txtBox" runat="server"></asp:TextBox>
             </td>
                
                    <td style="text-align:right;"><asp:Label ID="lblTagcomplete"  runat="server" Text="Taging Complete: "></asp:Label></td>
                   
                    <td><asp:RadioButtonList ID="rdbTaggingCompletestatus" runat="server" OnSelectedIndexChanged="rdbTaggingCompletestatus_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Text="NO" Value="0"></asp:ListItem>
                  
                    </asp:RadioButtonList>
                    </td>  


            </tr>

        <tr><td style="text-align:right" colspan="4"><asp:Button ID="btnShowDelvRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnShowDelvRepot_Click"  /></td></tr>
            <div>
                <table>
        <tr class="tblrowodd">
              <td colspan="3">
              <asp:GridView ID="grdvDeliveryRptwithVheicleNAME" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  OnPageIndexChanging="grdvDeliveryRptwithVheicleNAME_PageIndexChanging"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
              
              <Columns>
                    
                 
                   <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                  <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="strCustname" HeaderText="strCustname" SortExpression="strCustname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="intid" HeaderText="intID" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                  <asp:BoundField DataField="Edate" HeaderText="Date" SortExpression="Edate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                            
                         <asp:BoundField DataField="AppQuantity" HeaderText="Qnt" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                      
                       
                         <asp:BoundField DataField="strVheiclename" HeaderText="Vheicle Name" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                          <asp:BoundField DataField="strDrivername" HeaderText="Driver" SortExpression="strDrivername" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                            <asp:BoundField DataField="strDrvPhone" HeaderText="Phone" SortExpression="strDrvPhone" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       
                         <asp:BoundField DataField="strAddres" HeaderText="Address" SortExpression="strAddres" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                  <asp:TemplateField HeaderText="Issue Number" SortExpression=""> 
                       <ItemTemplate>
                         
                           <asp:TextBox ID="txtSearch" CssClass="txtBox" Width="100px" runat="server"></asp:TextBox>

                       </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
 
                <asp:TemplateField HeaderText="Det.">
                <ItemTemplate>
                <asp:Button ID="btnIssueNumberTag" runat="server" Text="Update" class="button" CommandName="complete" OnClick="btnIssueNumberTag_Click"  CommandArgument='<%# Eval("intid")+","+Eval("Edate")+","+Eval("Code")%>' /></ItemTemplate>
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

             <div>
                <table>
        <tr class="tblrowodd">
              <td colspan="3">
              <asp:GridView ID="grdvissunumbertagcomplted" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"  OnPageIndexChanging="grdvDeliveryRptwithVheicleNAME_PageIndexChanging" BorderStyle="None"  >
              
                  <AlternatingRowStyle BackColor="White" />
              
              <Columns>
                    
                  <%--Code,strCustname,intid,Edate,  AppQuantity ,strVheiclename ,strDrivername ,strDrvPhone ,strAddres--%>
                   <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                  <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="strCustname" HeaderText="strCustname" SortExpression="strCustname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="intid" HeaderText="intID" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                  <asp:BoundField DataField="Edate" HeaderText="Date" SortExpression="Edate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                            
                         <asp:BoundField DataField="AppQuantity" HeaderText="Qnt" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                      
                       
                         <asp:BoundField DataField="strVheiclename" HeaderText="Vheicle Name" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                          <asp:BoundField DataField="strDrivername" HeaderText="Driver" SortExpression="strDrivername" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                            <asp:BoundField DataField="strDrvPhone" HeaderText="Phone" SortExpression="strDrvPhone" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       
                         <asp:BoundField DataField="strAddres" HeaderText="Address" SortExpression="strAddres" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                 <asp:BoundField DataField="intBrandissunumber" HeaderText="Issunumber" SortExpression="intBrandissunumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                 
               
   
                  </Columns>
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#F7F7DE" />
                  <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
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
