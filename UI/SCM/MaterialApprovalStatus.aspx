<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialApprovalStatus.aspx.cs" Inherits="UI.SCM.MaterialApprovalStatus" %>

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
        
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> PRODUCT ENLISHMENT STATUS <font color="Green"></font><hr />
        </div>

        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td>
                    <table class="tbldecoration" style="width:auto; float:left; border:solid"><tr>
                       
                       <td style="text-align:center;"><asp:Label ID="Label1" runat="server" Text="WH Name " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span><asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Button ID="btnShow" runat="server" Text="Show" class="myButtonGrey" Width="100px" OnClick="btnShow_Click" />
                        </td>
                    </tr></table>
                </td>
            </tr>
            <tr><td>
                <table>
                <tr><td><hr /></td></tr>
                <tr><td><asp:GridView ID="dgvItem" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="Grid" FooterStyle-BackColor="#808080" FooterStyle-Font-Bold="true" FooterStyle-Font-Size="11px" FooterStyle-ForeColor="White" FooterStyle-Height="25px" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="10px" PagerStyle-CssClass="pgr" PageSize="8" ShowFooter="false">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>

                                <asp:TemplateField HeaderText="S/N">
                                <ItemStyle HorizontalAlign="center" Width="15px" />
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="intAutoID" SortExpression="intAutoID" Visible="true">
                                <ItemTemplate><asp:Label ID="lblAutoID" runat="server" Text='<%# Bind("intAutoID") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Product Base Name" SortExpression="strItemName">
                                <ItemTemplate><asp:Label ID="lblProductName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                                <ItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Part" SortExpression="strPart">
                                <ItemTemplate><asp:Label ID="lblPart" runat="server" Text='<%# Bind("strPart") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Model" SortExpression="strModel">
                                <ItemTemplate><asp:Label ID="lblModel" runat="server" Text='<%# Bind("strModel") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Serial" SortExpression="strSerial">
                                <ItemTemplate><asp:Label ID="lblSerial" runat="server" Text='<%# Bind("strSerial") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Specifiaction" SortExpression="strSpecifiaction">
                                <ItemTemplate><asp:Label ID="lblSerial" runat="server" Text='<%# Bind("strSpecifiaction") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
               

                                <asp:TemplateField HeaderText="UOM" SortExpression="strUOM">
                                <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                   
                                 <asp:TemplateField HeaderText="Origin" SortExpression="strOrigin">
                                <ItemTemplate><asp:Label ID="lblSerial" runat="server" Text='<%# Bind("strOrigin") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>


                                
                                 <asp:TemplateField HeaderText="HSCode" SortExpression="strHSCode">
                                <ItemTemplate><asp:Label ID="lblSerial" runat="server" Text='<%# Bind("strHSCode") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>


                                
                                 <asp:TemplateField HeaderText="Purchase Type" SortExpression="strPurchaseType">
                                <ItemTemplate><asp:Label ID="lblSerial" runat="server" Text='<%# Bind("strPurchaseType") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                 
                                 <asp:TemplateField HeaderText="Product Full Name" SortExpression="strMaterialFullName">
                                <ItemTemplate><asp:Label ID="lblSerial" runat="server" Text='<%# Bind("strMaterialFullName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Group Name" SortExpression="strGroupName">
                                <ItemTemplate><asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("strGroupName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Category" SortExpression="strCategoryName">
                                <ItemTemplate><asp:Label ID="lblCategory" runat="server" Text='<%# Bind("strCategoryName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sub-Category" SortExpression="strSubCategoryName">
                                <ItemTemplate><asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("strSubCategoryName") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="Status" SortExpression="Procuament">
                                <ItemTemplate><asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("Procuament") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" SortExpression="Finance">
                                <ItemTemplate><asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("Finance") %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </td></tr>
            <%--=========================================End My Code From Here=================================================--%>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
