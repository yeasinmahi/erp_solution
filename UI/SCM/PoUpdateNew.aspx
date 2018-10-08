<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoGenerateNew.aspx.cs" Inherits="UI.SCM.PoGenerateNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title> Po Generate</title>
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
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .padding-0{
            padding-right:0;
            padding-left:0;
        }
        .padding-right{
            padding-right:0;            
        }
        </style>
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
    
    <div class="divbody" style="padding-right:10px;">
        
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px; text-align:center; font-weight:bold; font-size:16px;">UPDATE PO <hr /></div>
            <div class="container">
                 <%--<table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">--%>
                  <table  class="tbldecoration" style="width:auto; float:left;"> 
                      
                      <tr>
                          <td><asp:Label ID="Label1" runat="server" CssClass="" Text="PO Number : " Font-Size="11px"></asp:Label></td>
                          <td><asp:TextBox ID="txtpoid" runat="server" AutoPostBack="true" CssClass="txtBox1" Font-Bold="False" Text="0"></asp:TextBox></td>
                          <td style="width:5px;"></td>
                          <td>
                              <asp:Button ID="btnShow" runat="server" AutoPostBack="false" CssClass="btn btn-info" Font-Bold="true" Height="30" OnClick="btnShow_Click" Text="Show" />
                          </td>
                          <td colspan="3"><asp:Label ID="lblSuppAddress" ForeColor="Red" Font-Size="Small" runat="server"></asp:Label></td>
                          
                         
                      </tr>
                      <tr><td colspan="6" style="height:5px;"></td></tr>
                      <tr>
                          <td style="text-align:right;">
                              <asp:Label ID="Label5" runat="server" CssClass="" Text="WH-Name : " Font-Size="11px"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <%--<asp:DropDownList ID="ddlWHPrepare" runat="server" AutoPostBack="true" CssClass="ddList" Height="24px" Font-Bold="False" OnSelectedIndexChanged="ddlWHPrepare_SelectedIndexChanged">
                              </asp:DropDownList>--%>
                              <asp:TextBox ID="txtWH" runat="server" AutoPostBack="true" CssClass="txtBox1" Font-Bold="False" Enabled="false" Text="0"></asp:TextBox>
                          </td>
                          <td><asp:Label ID="Label3" runat="server" CssClass="" ></asp:Label></td>
                          <td style="text-align:right;">
                              <asp:Label ID="Label6" runat="server" CssClass="" Text="Supplier : " Font-Size="11px"></asp:Label>
                          </td>
                        <td style="text-align:left;"><asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" placeholder="Search" CssClass="txtBox1" AutoPostBack="true" Width="300px" OnTextChanged="txtSupplier_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSupplier"
                        ServiceMethod="GetSupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                        </cc1:AutoCompleteExtender></td>
                          <%--<td style="text-align:left;">
                              <asp:DropDownList ID="ddlSuppliyer" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlSuppliyer_SelectedIndexChanged">
                              </asp:DropDownList>
                          </td>--%>
                          <td style="width:5px;"></td>
                          <td   style="text-align:left;"><asp:Button ID="btnUpdatePO" CssClass="btn btn-info" runat="server" Height="30" Font-Bold="true" Text="Update"  AutoPostBack="false" OnClick="btnUpdatePO_Click" />
                        
                        </td>
                      </tr>
                      <tr><td colspan="6" style="height:5px;"></td></tr>
                     <tr> 
                              <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="" Font-Size="11px" Text="Cost Center : "></asp:Label></td>  
                                 
                              <td style="text-align:left;">  <asp:DropDownList ID="ddlCostCenter" runat="server" AutoPostBack="false" CssClass="ddList" Height="24px" Font-Bold="False"></asp:DropDownList></td>
                              <td><asp:Label ID="Label4" runat="server" CssClass="" ></asp:Label></td>
                              <td style="text-align:right;"> <asp:Label ID="Label9" runat="server" CssClass="" Font-Size="11px" Text="Others :"></asp:Label> </td> 
                              
                              <td style="text-align:left;"> <asp:TextBox ID="txtOthers" runat="server" Text="0" AutoPostBack="false"  CssClass="txtBox1" Font-Bold="False"> </asp:TextBox> </td>
                              
                         <td style="text-align:right;">
                              <asp:Label ID="Label8" runat="server" CssClass="" Text="Transport : " Font-Size="11px"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:TextBox ID="txtTransport" runat="server" AutoPostBack="false" CssClass="txtBox1" Font-Bold="False" Text="0"></asp:TextBox>
                          </td>
                             
                      </tr>
                      <tr><td colspan="6" style="height:5px;"></td></tr>
                      <tr>
                           <td style="text-align:right;">  <asp:Label ID="Label11" runat="server" CssClass="" Font-Size="11px" Text="Currancy : "></asp:Label></td>  
                           <td style="text-align:left;">
                           <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="false" CssClass="ddList" Height="24px" Font-Bold="False"> </asp:DropDownList>
                           </td>
                            <td><asp:Label ID="Label16" runat="server" CssClass="" ></asp:Label></td>
                            <td style="text-align:right;"><asp:Label ID="Label12" Enabled="false" runat="server" CssClass="" Font-Size="11px" Text="Pay Date : "></asp:Label> </td> 
                            <td style="text-align:left;">
                            <asp:DropDownList ID="ddlDtePay" Enabled="false" runat="server" AutoPostBack="false" CssClass="ddList" Height="24px" Font-Bold="False">
                            </asp:DropDownList></td>
                            <%--<td><asp:Label ID="Label30" runat="server" CssClass="" ></asp:Label></td>--%>
                           <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Font-Size="11px" Text="Gross Discount : "></asp:Label></td>  
                              <td style="text-align:left;"><asp:TextBox ID="txtGrossDiscount" runat="server"  Text="0" AutoPostBack="false"  CssClass="txtBox1" Font-Bold="False"></asp:TextBox></td>
                              
                           
                       </tr>
                      <tr><td colspan="6" style="height:5px;"></td></tr>
                       <tr>
                        <td style="text-align:right;"> <asp:Label ID="Label14" runat="server" Font-Size="11px" CssClass="" Text="Po Date : "></asp:Label> </td> 
                        <td style="text-align:left;"><asp:TextBox ID="txtdtePo" Enabled="false" runat="server"  CssClass="txtBox1" Font-Bold="False"> 
                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdtePo"></cc1:CalendarExtender> 
                        </td>
                         <td><asp:Label ID="Label27" runat="server" CssClass="" ></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label15" runat="server" CssClass="" Font-Size="11px" Text="AIT : "></asp:Label></td> 
                        <td  style="text-align:left;"><asp:TextBox ID="txtAit" Enabled="false" runat="server" onkeyup="GetAIT(this);" Text="0" AutoPostBack="false" CssClass="txtBox1" Font-Bold="False"> 
                        </asp:TextBox></td>
                            <td style="text-align:right;"><asp:Label ID="Label13" runat="server" CssClass="" Font-Size="11px" Text="Commision : "></asp:Label></td> 
                            <td style="text-align:left;">
                            <asp:TextBox ID="txtCommosion" runat="server"  onkeyup="GetCommision(this);"  CssClass="txtBox1"  AutoPostBack="false" Font-Bold="False">
                            </asp:TextBox> </td> 
                        
                      </tr>
                      <tr>
                          <td style="height:5px;" colspan="6"></td>
                      </tr>
                      
                  </table>
                 <table>
                     <tr>
                          <td>
                              <asp:GridView ID="dgvIndentPrepare" runat="server" OnRowDeleting="dgvIndentPrepare_RowDeleting" OnRowEditing="dgvIndentPrepare_RowEditing" ShowFooter="true" DataKeyNames="intItemID" OnRowCommand="dgvIndentPrepare_RowCommand" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                  <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Item Id" SortExpression="intItemID" >
                                    <ItemTemplate> <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" />                                   
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item Name" SortExpression="strName"><ItemTemplate> 
                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="300px" />                                     
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item Specification" ItemStyle-HorizontalAlign="right" SortExpression="strDesc">
                                    <ItemTemplate> <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strSpecification") %>'></asp:Label> </ItemTemplate> <ItemStyle HorizontalAlign="Right" Width="150px" />                                    
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUom" Visible="true">
                                    <ItemTemplate> <asp:Label ID="lblUom" runat="server"   Text='<%# Bind("strUom") %>'></asp:Label> </ItemTemplate><ItemStyle HorizontalAlign="Right" />                                    
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="HSCode" ItemStyle-HorizontalAlign="right" SortExpression="strHsCode">
                                    <ItemTemplate> <asp:Label ID="lblHsCode" runat="server"   Text='<%# Bind("strHsCode") %>'></asp:Label></ItemTemplate> <ItemStyle HorizontalAlign="Left"/>                                    
                                    </asp:TemplateField> 
                                      
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="numQty">
                                    <ItemTemplate><asp:TextBox ID="txtQty" runat="server"  CssClass="txtBox"  DataFormatString="{0:0.00}"  Text='<%# Bind("numQty") %>' Width="60px"></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                    <ItemTemplate><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text='<%# Bind("monRate") %>' Width="80px"></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="VAT" SortExpression="vat">
                                    <ItemTemplate><asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text='<%# Bind("monVAT") %>' Width="80px"></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotalVAT" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="ait">
                                    <ItemTemplate><asp:TextBox ID="txtAIT" runat="server" DataFormatString="{0:0.00}" CssClass="txtBox" Width="80px" Text='<%# Bind("monAIT") %>'></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotalAIT" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="monAmount">
                                    <ItemTemplate><asp:Label ID="lblTotalVal" runat="server"   Text='<%# Bind("monAmount") %>'></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>
                                  
                                    <asp:TemplateField ShowHeader="false">
                                        <ItemTemplate>
                                            <asp:Button ID="LinkButton1" runat="server" CommandName="edit" Text="Update" ></asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField ShowHeader="false">
                                        <ItemTemplate>
                                            <asp:Button ID="LinkButton2" runat="server" CommandName="delete" Text="Delete" ></asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    </Columns>
                                  <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                              </asp:GridView> 
                          </td>
                      </tr>
                 </table>
                  <table>
                       <tr>
                          <td style="height:5px;" colspan="4"></td>
                      </tr>
                      <tr>
                          <td style="text-align:right;"><asp:Label ID="lblPartialShip" Text="Partial Shipment : " runat="server" Font-Size="11px"/></td>
                          <td><asp:DropDownList ID="ddlPartialShip" AutoPostBack="false" CssClass="ddList" Height="24px" runat="server">
                           <asp:ListItem Text="No" Value="0"></asp:ListItem><asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                           </asp:DropDownList></td> 
                          <td style="text-align:right;"><asp:Label ID="lblNoOfShip" runat="server" Text="No of Shipment : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtNoOfShipment" runat="server" CssClass="txtBox1" Text="1" /></td> 
                          
                      </tr>
                       <tr><td colspan="4" style="height:5px;"></td></tr>
                       <tr>
                          <td style="text-align:right;"><asp:Label ID="Label17" runat="server" Text="Last Shipment Date : " Font-Size="11px" /></td>
                          <td><asp:TextBox ID="txtLastShipmentDate" CssClass="txtBox1" runat="server"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender4" runat="server"  Format="yyyy-MM-dd" TargetControlID="txtLastShipmentDate">
                          </cc1:CalendarExtender></td>
                          <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="Payment terms" Font-Size="11px"/></td>
                          <td><asp:DropDownList ID="ddlPaymentTrams" AutoPostBack="false" CssClass="ddList" Height="24px" runat="server">
                          <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                          <asp:ListItem Text="Credit" Value="1"></asp:ListItem><asp:ListItem Text="Advance" Value="2"></asp:ListItem>
                          <asp:ListItem Text="Cash" Value="3"></asp:ListItem> </asp:DropDownList></td>  
                      </tr>
                       <tr><td colspan="4" style="height:5px;"></td></tr>
                       <tr>
                          <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Payment days after MRR : " Font-Size="11px" /></td>
                          <td><asp:TextBox ID="txtAfterMrrDay" CssClass="txtBox1" runat="server" Text="7" /></td> 
                          <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="No of Installment : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtNoOfInstall" CssClass="txtBox1" runat="server"  Text="1"/></td> 
                      </tr>
                       <tr><td colspan="4" style="height:5px;"></td></tr>
                       <tr>
                          <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="Installment Interval : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtIntervel" runat="server" CssClass="txtBox1"  Text="0"/></td> 
                          <td style="text-align:right;"><asp:Label ID="Label22" runat="server" Text="Delivery Destination : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtDestinationDelivery" CssClass="txtBox1" runat="server" /></td> 
                      </tr>
                       <tr><td colspan="4" style="height:5px;"></td></tr>
                      <tr>
                          <td style="text-align:right;"><asp:Label ID="Label23" runat="server" Text="No of Payment : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtNoOfPayment" runat="server" Text="0"  CssClass="txtBox1"/></td> 
                          <td style="text-align:right;"><asp:Label ID="Label24" runat="server" Text="Payment Schedule : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtPaymentSchedule" CssClass="txtBox1" runat="server" /></td> 
                      </tr>
                       <tr><td colspan="4" style="height:5px;"></td></tr>
                       <tr>
                           <td style="text-align:right;"><asp:Label ID="Label26" runat="server" Text="Warrenty (in months) : " Font-Size="11px"/></td>
                          <td><asp:TextBox ID="txtWarrenty" CssClass="txtBox1" runat="server" Text="1"/></td> 
                          <td style="text-align:right;"><asp:Label ID="Label25" runat="server" Text="Others Trems : " Font-Size="11px" /></td>
                          <td><asp:TextBox ID="txtOthersTerms" runat="server"  Width="200px" Height="50px" Text="Na" CssClass="txtBox1" TextMode="MultiLine"/></td> 
                          <td><asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Height="30" Font-Bold="true" Text="Update Other"   AutoPostBack="false" OnClick="btnUpdate_Click" /></td>
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
