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
    <style type="text/css">
        .txtBox1 {}
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
        <table><tr><td>
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;">PO Generate<hr /></div>
                    <table class="tbldecoration" style="width:auto; float:left;">
                          <tr>
                          <td style="text-align:right;">
                              <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="WH-Name"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:DropDownList ID="ddlWHPrepare" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke">
                              </asp:DropDownList>
                          </td>
                          <td style="text-align:right;">
                              <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Supplier"></asp:Label>
                          </td>
                        <td style="text-align:left;"><asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" placeholder="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtSupplier_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSupplier"
                        ServiceMethod="GetSupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                        </cc1:AutoCompleteExtender></td>
                          <%--<td style="text-align:left;">
                              <asp:DropDownList ID="ddlSuppliyer" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlSuppliyer_SelectedIndexChanged">
                              </asp:DropDownList>
                          </td>--%>
                          <td style="text-align:right;">
                              <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Transport"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:TextBox ID="txtTransport" runat="server" AutoPostBack="false" CssClass="txtBox1" BackColor="WhiteSmoke" ToolTip="Enter Full/Partial Product Name" Text="0" Width="128px"></asp:TextBox>
                          </td>
                      </tr>
                     <tr> 
                              <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="CostCenter"></asp:Label></td>  
                                 
                              <td style="text-align:left;">  <asp:DropDownList ID="ddlCostCenter" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                             
                              <td style="text-align:right;"> <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Others:"></asp:Label> </td> 
                         
                              <td style="text-align:left;"> <asp:TextBox ID="txtOthers" runat="server" Text="0" AutoPostBack="false"  CssClass="txtBox" Font-Bold="False"> </asp:TextBox> </td>
                              
                              <td style="text-align:right;"><asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Gross Discount: "></asp:Label></td>  
                              <td style="text-align:left;"><asp:TextBox ID="txtGrossDiscount" runat="server"  Text="0" AutoPostBack="false"  CssClass="txtBox1" BackColor="WhiteSmoke" ToolTip="Enter Full/Partial Product Name"></asp:TextBox></td>
                              
                      </tr>
                      <tr>
                           <td style="text-align:right;">  <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Currancy"></asp:Label></td>  
                           <td style="text-align:left;">
                           <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke"> </asp:DropDownList>
                           </td>

                            <td style="text-align:right;"><asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Pay Date: "></asp:Label> </td> 
                            <td style="text-align:left;">
                            <asp:DropDownList ID="ddlDtePay" Enabled="false" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke">
                            </asp:DropDownList></td>
                          
                            <td style="text-align:right;"><asp:Label ID="Label13" runat="server" CssClass="lbl" Text="Commision: "></asp:Label></td> 
                            <td style="text-align:left;">
                            <asp:TextBox ID="txtCommosion" runat="server"  onkeyup="GetCommision(this);"  CssClass="txtBox"  AutoPostBack="false" Font-Bold="False">
                            </asp:TextBox><asp:Button ID="btnCommision" runat="server" Text="Set commission" Visible="false" CssClass="myButtonNew" /> </td> 
                       </tr>

                       <tr>
                        <td style="text-align:right;"> <asp:Label ID="Label14" runat="server" CssClass="lbl" Text="Po Date"></asp:Label> </td> 
                        <td style="text-align:left;"><asp:TextBox ID="txtdtePo" Enabled="false" runat="server"  CssClass="txtBox" Font-Bold="False"> 
                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdtePo"></cc1:CalendarExtender> 
                        </td>
                        <td style="text-align:right;"><asp:Label ID="Label15" runat="server" CssClass="lbl" Text="AIT: "></asp:Label></td> 
                        <td  style="text-align:left;"><asp:TextBox ID="txtAit" runat="server" onkeyup="GetAIT(this);" Text="0" AutoPostBack="false" CssClass="txtBox" Font-Bold="False"> 
                        </asp:TextBox></td><td></td>
                        <td   style="text-align:left;"><asp:Button ID="btnGeneratePO" CssClass="myButtonNew" runat="server" Text="Generate PO" OnClientClick="PoGenerateCheck();" OnClick="btnGeneratePO_Click" AutoPostBack="false" />
                        
                        </td>
                      </tr>

                        <%--<tr>
                            <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="WH Name " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></td>
                            <td style="text-align:right;"><asp:Label ID="lblSearchText" runat="server" Text="Product Name :" CssClass="lbl"></asp:Label></td>
                            <td style="text-align:left;"><asp:TextBox ID="txtSearchText" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" ToolTip="Enter Full/Partial Product Name"></asp:TextBox></td>
                        </tr>
            
                        <tr>
                            <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" class="myButtonNew" Style="font-size: 12px; cursor: pointer;" Text="Show Report" OnClientClick="CheckValidation()" OnClick="btnShow_Click"/></td>
                        </tr>

                         <tr><td colspan="4"><hr /></td></tr>--%>
                    </table>
                  </div>
                 <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
