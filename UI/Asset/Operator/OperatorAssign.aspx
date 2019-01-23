<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperatorAssign.aspx.cs" Inherits="UI.Asset.Operator.OperatorAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>

<head runat="server">

    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/JS/datepickr.min.js"></script>

    <script src="../../Content/JS/JSSettlement.js"></script>

    <link href="jquery-ui.css" rel="stylesheet" />

    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>

    <script src="jquery-ui.min.js"></script>
    <script language="javascript" type="text/javascript">

        function onlyNumbers(evt) {

            var e = event || evt; // for trans-browser compatibility

            var charCode = e.which || e.keyCode;

            if ((charCode > 57))

                return false;

            return true;

        }
    </script>

    <script type="text/javascript">

        function funConfirmAll() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

        }
    </script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());
        gtag('config', 'UA-125570863-1');
    </script>

<%--    <script>
        function isNumeric(num) {
            return !isNaN(num)
        }
    </script>--%>

</head>

<body>

    <form id="frmselfresign" runat="server">

        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server">

            <ContentTemplate>

                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">

                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">

                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">

    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>

                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>

                <div style="height: 100px;"></div>

                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnDA" runat="server" />
                    <div class="tabs_container">
                        Operator Assign : 
                    </div>
                    <table>
                        <tr> 
                            <td style="text-align: right;">
                            <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Asset List: "></asp:Label></td>
                            <td style="text-align: left;">
                            <asp:TextBox ID="txtAssetItem" runat="server" AutoCompleteType="Search"   OnTextChanged="TxtAsset_TextChanged" CssClass="txtBox" AutoPostBack="true" Width="450px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAssetItem"
                            ServiceMethod="GetAssetSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                            </cc1:AutoCompleteExtender>
                            </td>
                          </tr>
                        <tr>
                            <td style="text-align: right;">
                            <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Asset Location: "></asp:Label></td>
                            <td style="text-align: left;">
                            <asp:TextBox ID="txtLocation" runat="server" AutoCompleteType="Search" Enabled="false"  CssClass="txtBox" AutoPostBack="true" Width="450px"></asp:TextBox>
                        </tr>
                        <tr>
                             <td style="text-align: right;">
                            <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Employee List: "></asp:Label></td>
                            <td style="text-align: left;">
                            <asp:TextBox ID="txtEmp" runat="server" AutoCompleteType="Search" TextMode="MultiLine" CssClass="txtBox" AutoPostBack="true" Width="450px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmp"
                            ServiceMethod="GetEmployeeSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                            </cc1:AutoCompleteExtender>
                            </td>                           
                           </tr> 
                        <tr>
                            <td style="text-align: right;">
                            <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Remarks: "></asp:Label></td>
                            <td><asp:TextBox ID="txtRemarks" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="450px" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td colspan="2" style="text-align: right;">
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"  />
                             <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnAddd" runat="server" Text="Add" OnClick="btnAddd_Click" />
                                
                            </td>
                        </tr>
                        
                        </table>
                     
                     <table>
                        <tr>
                            <td> 
                                <asp:GridView ID="dgvAsset" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting"
                                   BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="25px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Asset ID" SortExpression="assetId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetId" runat="server" Text='<%# Bind("assetId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Asset Name" SortExpression="assetName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetName" runat="server" Text='<%# Bind("assetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Asset-Location" ItemStyle-HorizontalAlign="right" SortExpression="assetLocation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("assetLocation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>

                         <tr>
                            <td> 
                                <asp:GridView ID="dgvAsetiew" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                                   BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDeleting="dgvAsetiew_RowDeleting">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="25px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="ID" SortExpression="intId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("intId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Asset ID" SortExpression="assetId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetId" runat="server" Text='<%# Bind("strAssetID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Asset Name" SortExpression="assetName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetName" runat="server" Text='<%# Bind("strAssetName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Asset-Location" ItemStyle-HorizontalAlign="right" SortExpression="assetLocation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strDetalis") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" DeleteText="UnAssign" >
                                        <ControlStyle Font-Bold="True" ForeColor="Red" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
