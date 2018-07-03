<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemManagerAccounts.aspx.cs" Inherits="UI.SCM.ItemManagerAccounts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />

      <script language="javascript" type="text/javascript">
            function onlyNumbers(evt) {
                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;

                if ((charCode > 57))
                    return false;
                return true;
          } 
          function TotalLeadTime1() {
            var POTime = document.getElementById('txtPOTime').value;
              if (isNaN(POTime) == true) { POTime = 0; }
            var ShipmentTime = document.getElementById('txtDeliveryTime').value;
              if (isNaN(ShipmentTime) == true) { ShipmentTime = 0; }
            var ProcessTime = document.getElementById('txtProcessingTime').value;
              if (isNaN(ProcessTime) == true) { ProcessTime = 0; }
            var TotalTime = (POTime - ShipmentTime);
            document.getElementById('txtTotalLeadTime').value = TotalTime;
          }
          function TotalLeadTime() {
              var total = 0;
              if(document.getElementById('txtPOTime').value!='')
                {
                  total += parseFloat(document.getElementById('txtPOTime').value);
              }
              if(document.getElementById('txtDeliveryTime').value!='')
                {
                  total += parseFloat(document.getElementById('txtDeliveryTime').value);
              }
              if(document.getElementById('txtProcessingTime').value!='')
                {
                  total += parseFloat(document.getElementById('txtProcessingTime').value);
                }
            document.getElementById('txtTotalLeadTime').value = total;
          }
          function ViewDispatchPopup(Id) {
            window.open('ItemManagerAccountsPopUp.aspx?ID=' + Id, 'sub', "height=750, width=750, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
        </script>
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnWHID" runat="server" /> <asp:HiddenField ID="hdnGroupID" runat="server" /><asp:HiddenField ID="hdnCategoryID" runat="server" />
    <asp:HiddenField ID="hdnItemID" runat="server" />
        
 <%--   <div id="hdnDivision" class="hdnDivision" style="width:auto;">
        <table style="width:auto; float:left; ">            
            <tr><td style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
            <tr><td>
            <div class="leaveApplication_container">
            <table class="tbldecoration" style="width:auto; float:left;">
        
            <tr class="tblheader"><td class="tdheader" colspan="4"> ITEM APPROVE BY ACCOUNTS DEPT :</td></tr>        
            <tr class="tblheader"><td style=" height:2px; background-color:#c1bdbd;" colspan="4"> </td></tr>
            <tr ><td style="padding: 15px 0px 0px 5px;" colspan="4"> </td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblBaseName" runat="server" Text="Product Base Name " CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtBaseName" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblDescription" runat="server" Text="Description :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            </tr>        
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text="Part/Model/Serial :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPartModel" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="Brand :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtBrand" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Re-Order Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtReOrder" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Minimum Stock Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMinimum" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" onkeypress="return onlyNumbers();"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text="Maximum Order Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMaximum" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Safety Stock Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSafety" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" onkeypress="return onlyNumbers();"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="UOM :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Group :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtGroup" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="Category :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtCategory" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="Sub-Category :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSubCategory" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Minor Category :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMinorCategory" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Plant :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPlant" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>                
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Procurement Type :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPurchaseType" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="PO Processing Time (A) :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPOTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Supp. Shipment Delivery Time (B) :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDeliveryTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="Processing Time for Goods Reveips (C) :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtProcessingTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label17" runat="server" Text="Total Lead Time (A+B+C) :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtTotalLeadTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="Ordering Lot Size :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtLotSize" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Economic Order Qty. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtEOQ" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="Minimum Order Qty. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMOQ" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="SDE Classification :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSDE" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label22" runat="server" Text="HML Classification " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlHML" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="White"><asp:ListItem Selected="True" Value="1">High Cost</asp:ListItem><asp:ListItem Value="2">Medium Cost</asp:ListItem><asp:ListItem Value="3">Low Cost</asp:ListItem>
                </asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label23" runat="server" Text="VAT Applicable " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlVAT" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="White"><asp:ListItem Selected="True" Value="0">No</asp:ListItem><asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="btnApprove" runat="server" class="myButton" OnClick="btnApprove_Click" OnClientClick="ConfirmAll()" Text="Approve" /></td>
            </tr>
            </table>
            </div>
            </td></tr>
        </table>
        </div>--%>
        

        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px; width: 1844px;">
            ITEM ADD FORM <font color="red">[LEVEL-3][ACCOUNTS PART]</font><hr />
        </div>

        <table class="tbldecoration" style="width:auto; float:left;">
            <table>
                <tr><td><hr /></td></tr>
                <tr><td><asp:GridView ID="dgvItem" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="Grid" FooterStyle-BackColor="#808080" FooterStyle-Font-Bold="true" FooterStyle-Font-Size="11px" FooterStyle-ForeColor="White" FooterStyle-Height="25px" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="10px" PagerStyle-CssClass="pgr" PageSize="8" ShowFooter="false" OnRowCommand="dgvItem_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>

                                <asp:TemplateField HeaderText="S/N">
                                <ItemStyle HorizontalAlign="center" Width="15px" />
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="intAutoID" SortExpression="intAutoID" Visible="false">
                                <ItemTemplate><asp:Label ID="lblAutoID" runat="server" Text='<%# Bind("intAutoID") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Wear House" SortExpression="strWareHoseName">
                                <ItemTemplate><asp:Label ID="lblWH" runat="server" Text='<%# Bind("strWareHoseName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Base Name" SortExpression="strItemName">
                                <ItemTemplate><asp:Label ID="lblProductName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                                <ItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="right" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Part/Model/Serial" SortExpression="strPart">
                                <ItemTemplate><asp:Label ID="lblPart" runat="server" Text='<%# Bind("strPart") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="right" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Brand" SortExpression="strBrand">
                                <ItemTemplate><asp:Label ID="lblBrand" runat="server" Text='<%# Bind("strBrand") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Re-Order Level" SortExpression="numReOrderLevel">
                                <ItemTemplate><asp:Label ID="lblReOrder" runat="server" Text='<%# Eval("numReOrderLevel", "{0:0,0.00}") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Minimum Stock" SortExpression="numMinimumStock">
                                <ItemTemplate><asp:Label ID="lblMinimum" runat="server" Text='<%# Eval("numMinimumStock", "{0:0,0.00}") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Maximum Stock" SortExpression="numMaximumStock">
                                <ItemTemplate><asp:Label ID="lblMaximum" runat="server" Text='<%# Eval("numMaximumStock", "{0:0,0.00}") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Safety Stock" SortExpression="numSafetyStock">
                                <ItemTemplate><asp:Label ID="lblSafety" runat="server" Text='<%# Eval("numSafetyStock", "{0:0,0.00}") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UOM" SortExpression="strUOM">
                                <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Group Name" SortExpression="strGroupName">
                                <ItemTemplate><asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("strGroupName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Category" SortExpression="strCategoryName">
                                <ItemTemplate><asp:Label ID="lblCategory" runat="server" Text='<%# Bind("strCategoryName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sub-Category" SortExpression="strSubCategoryName">
                                <ItemTemplate><asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("strSubCategoryName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Minor Category" SortExpression="strMinorCategory">
                                <ItemTemplate><asp:Label ID="lblMinorCategory" runat="server" Text='<%# Bind("strMinorCategory") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plant Name" SortExpression="strPlantName">
                                <ItemTemplate><asp:Label ID="lblPlant" runat="server" Text='<%# Bind("strPlantName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Procurement Type" SortExpression="strPurchaseType">
                                <ItemTemplate><asp:Label ID="lblPurchase" runat="server" Text='<%# Bind("strPurchaseType") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PO Processing Time" SortExpression="intPOProcessTime">
                                <ItemTemplate><asp:Label ID="lblPOTime" runat="server" Text='<%# Bind("intPOProcessTime") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Shipment Delivery Time" SortExpression="intShipmentDeliveryTime">
                                <ItemTemplate><asp:Label ID="lblShipmentTime" runat="server" Text='<%# Bind("intShipmentDeliveryTime") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Process Time" SortExpression="intProcessingTime">
                                <ItemTemplate><asp:Label ID="lblProcessTime" runat="server" Text='<%# Bind("intProcessingTime") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Lead Time" SortExpression="intTotalLeadTime">
                                <ItemTemplate><asp:Label ID="lblTotalTime" runat="server" Text='<%# Bind("intTotalLeadTime") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ordering Lot Size" SortExpression="strOrderingLotSize">
                                <ItemTemplate><asp:Label ID="lblLotSize" runat="server" Text='<%# Bind("strOrderingLotSize") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EOQ" SortExpression="intEconomicOrderQty">
                                <ItemTemplate><asp:Label ID="lblEOQ" runat="server" Text='<%# Bind("intEconomicOrderQty") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="MOQ" SortExpression="intMinimumOrderQty">
                                <ItemTemplate><asp:Label ID="lblMOQ" runat="server" Text='<%# Bind("intMinimumOrderQty") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SDE Classification" SortExpression="strSDEClassification">
                                <ItemTemplate><asp:Label ID="lblSDE" runat="server" Text='<%# Bind("strSDEClassification") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                <ItemTemplate><asp:Button ID="btnApprove" runat="server" class="myButton" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Y" Font-Size="9px" Text="Select" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                <ItemTemplate><asp:Button ID="btnDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="D"  
                                Text="Details"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                <ItemTemplate><asp:Button ID="btnReject" runat="server" class="myButton" CommandArgument="<%# Container.DataItemIndex %>" CommandName="R" Font-Size="9px" OnClientClick="ConfirmAll()" Text="Reject" /></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <%--=========================================End My Code From Here=================================================--%>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>