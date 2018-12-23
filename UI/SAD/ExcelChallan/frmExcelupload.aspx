<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmExcelupload.aspx.cs" Inherits="UI.SAD.ExcelChallan.frmExcelupload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function ShowPopUp(url) {
            url = url + '&shippoint=' + document.getElementById("ddlshippoint").value + '&Office=' + document.getElementById("ddlOfficeName").value + '&enroll=' + document.getElementById("hdnEnroll").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=400,width=1200,top=70,left=50');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <script>
        function ShowPopUpCust(url) {            
            url = url + '&shipid=' + document.getElementById("ddlshippoint").value + '&offid=' + document.getElementById("ddlOfficeName").value + '&Custid=' + document.getElementById("hdnCustid").value + '&slipno=' + document.getElementById("hdnSlipno").value + '&CustName=' + document.getElementById("hdnCustname").value + '&userEnroll=' + document.getElementById("hdnEnroll").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=700,top=70,left=50');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <script type="text/javascript">
      function Search_dgvservice(strKey, strGV) {

          var strData = strKey.value.toLowerCase().split(" ");
          var tblData = document.getElementById(strGV);
          var rowData;
          for (var i = 1; i < tblData.rows.length; i++) {
              rowData = tblData.rows[i].innerHTML;
              var styleDisplay = 'none';
              for (var j = 0; j < strData.length; j++) {
                  if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                      styleDisplay = '';
                  else {
                      styleDisplay = 'none';
                      break;
                  }
              }
              tblData.rows[i].style.display = styleDisplay;
          }

      }
        </script>
</head>
<body>
    <form id="frmAutoChallProcess" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
      <div class="tabs_container"> AUTO CHALLAN <hr /></div>
        <asp:HiddenField ID="hdnCustid" runat="server"/> <asp:HiddenField ID="hdnSlipno" runat="server"/>  
        <asp:HiddenField ID="hdnCustname" runat="server"/>
        <table class="tbldecoration" style="width:auto; float:left;">                                  
        <tr class="tblrowodd">           
            <td style="text-align:right;">Shippoint Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlshippoint" runat="server"  AutoPostBack="True"></asp:DropDownList>  </td>
            <td style='text-align: right; width:120px;'>Office Name: </td>
            <td style='text-align: center;'><asp:DropDownList ID="ddlOfficeName" runat="server"></asp:DropDownList></td> 
            <td style="text-align:right;"> 
            <asp:Button ID="btnDataView" Font-Bold="true" runat="server" Text="Report" OnClick="btnDataView_Click" /> &nbsp&nbsp
            <asp:Button ID="btnViewSlip" Font-Bold="true" runat="server" Text="Loading Slip" OnClick="btnLoadingSlip_Click" />           
            </td>
         </tr>    
        <tr><td>Upload
            <a href="#" onclick="ShowPopUp('frmAutoChallan.aspx?')">           
            <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Customer" /></a>
            <asp:Button ID="btnCancel" Font-Bold="true" runat="server" Text="All Upload Cancel" OnClick="btnCancel_Click" />
            </td>
            <td>Customer Name</td>
            <td><asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox"  AutoPostBack="true"  ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtCustomer"
            ServiceMethod="CustomerSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td>
              Product Qty:<asp:TextBox ID="txtPQty" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  ></asp:TextBox>
            </td>
            <td style="text-align:left"><asp:Button ID="btnuploadSingle" Font-Bold="true" runat="server" Text="Upload" OnClick="btnuploadSingle_Click" /></td>
         </tr>                       
        <tr><td colspan="5"><hr />
            <asp:GridView ID="dgvExcelOrder" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" OnRowDataBound="dgvExcelOrder_RowDataBound" ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>  
           <asp:TemplateField HeaderText="SL.N">
            <HeaderTemplate>          
            <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvExcelOrder')"></asp:TextBox>
            </HeaderTemplate>
            <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intCustid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
            </FooterTemplate></asp:TemplateField>            
            <asp:BoundField DataField="strLine" HeaderText="line" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strregion" HeaderText="Region" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="strarea" HeaderText="Area" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="strTerritory" HeaderText="Territory" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="strPoint" HeaderText="Point" ReadOnly="True" SortExpression="Point"/>
            <asp:BoundField DataField="strName" HeaderText="strName" ReadOnly="True" SortExpression="strName"/>             
            <asp:BoundField DataField="vno" HeaderText="Vehicle No" ReadOnly="True" SortExpression="strName"/>             
               
            <asp:TemplateField HeaderText="Pending Qty" SortExpression="Pending">
            <ItemTemplate><asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("qty","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# Pendingtotal %>' /></FooterTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="View"><ItemTemplate>
            <asp:Button ID="btnexceldataview" runat="server" Text="View" CommandName="complete"  OnClick="btnExcelProductView" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")+ "^" +Eval("strName")  %>' />
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Delete"><ItemTemplate> 
            <asp:Button ID="btndelete" ForeColor="Red" runat="server" Text="Delete" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")%>' />
            </ItemTemplate> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity"><ItemTemplate>
         
            <asp:TextBox ID="txtAllQuantity" CssClass="txtBox" runat="server" Width="75px"  Text='<%# Bind("allqty","{0:n0}") %>' AutoPostBack="false"    ></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

             <asp:TemplateField HeaderText="Upload"><ItemTemplate> 
            <asp:Button ID="btnUpload" ForeColor="Blue" runat="server" Text="Upload" CommandName="complete"  OnClick="btnUpload_Click" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")+ "^" +Eval("allqty")  %>' />
            </ItemTemplate> </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

            <asp:GridView ID="dgvSlip" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>  
           
            <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intCustid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
            </FooterTemplate></asp:TemplateField>  
             <asp:BoundField DataField="strSlipNo" HeaderText="Slip No" ReadOnly="True" SortExpression="strline"/>                        
            <asp:BoundField DataField="strLine" HeaderText="line" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strregion" HeaderText="Region" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="strarea" HeaderText="Area" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="strTerritory" HeaderText="Territory" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="strPoint" HeaderText="Point" ReadOnly="True" SortExpression="Point"/>
            <asp:BoundField DataField="strName" HeaderText="strName" ReadOnly="True" SortExpression="strName"/>             
            <asp:BoundField DataField="strVno" HeaderText="Vehicle No" ReadOnly="True" SortExpression="strName"/>             
               
            <asp:TemplateField HeaderText="Pending Qty" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnSlip" value='<%# Bind("strSlipNo") %>' runat="server" /> <asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("qty","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# Pendingtotal %>' /></FooterTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="View"><ItemTemplate>
            <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="ViewSlipAll" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")+ "^" +Eval("strSlipNo") %>' />
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Delete"><ItemTemplate> 
            <asp:Button ID="btnbtnOrderDelete" ForeColor="Red" runat="server" Text="Delete" CommandName="complete"  OnClick="btnOrderDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")%>' />
            </ItemTemplate> </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </td></tr>  
       </table>                        
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
