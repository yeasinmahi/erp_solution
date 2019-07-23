<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseRegisterM16.aspx.cs" Inherits="UI.Vat.PurchaseRegisterM16" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Purchase Register ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtDteFrom = document.forms["frmpurchaseregister"]["txtDteFrom"].value;
            var txtDteTo = document.forms["frmpurchaseregister"]["txtDteTo"].value;

            if (txtDteFrom == null || txtDteFrom == "") {
                alert("Fromdate must be filled by valid formate (year-month-day).");
            }
            else if (txtDteTo == null || txtDteTo == "") {
                alert("Todate must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function ShowReport(frmdte, todte, matid, vatacc) {
            var url = 'PrintM16.aspx?FROMDATE=' + frmdte + '&TODATE=' + todte + '&MATID=' + matid + '&VATACC=' + vatacc;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,top=10,left=100, width=1180px');
            if (window.focus) { newwindow.focus() }
        }
    </script>


</head>
<body>
    <form id="frmpurchaseregister" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="tabs_container">Purchase Register: <asp:HiddenField ID="hdnconfirm" runat="server" /><hr />

        <table>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        <td style="text-align:right;"><asp:Label ID="lblproduct" runat="server" CssClass="lbl" Text="Vat-Material : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlMaterial" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsmaterialist"
        DataTextField="strMaterialName" DataValueField="intMaterialID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsmaterialist" runat="server" SelectMethod="GetMaterialList" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:ControlParameter ControlID="ddlVatAcc" Name="vtacc" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters></asp:ObjectDataSource>
        </td>        
        </tr>
        <tr>  
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
        </td>          
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender></td></tr>
        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnShow" runat="server" class="nextclick" style="font-size:11px;" Text="Show" OnClientClick="Confirm()" OnClick="btnShow_Click"/>
        <asp:Button ID="btnShowReport" runat="server" class="nextclick" style="font-size:11px;" Text="PrintReport" OnClientClick="Confirm()" OnClick="btnShowReport_Click"/>
        </td></tr>
        </table> </div>

    <asp:GridView ID="dgvpurchaseregister" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="11px" BackColor="White">
        <Columns>
        <asp:TemplateField HeaderText="PurchaseCode"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("PurchaseCode") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="Date_" HeaderText="Date" ItemStyle-HorizontalAlign="Center" SortExpression="Date_" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left"/></asp:BoundField>

        <asp:TemplateField HeaderText="OpeningQty"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("OpeningQty") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OpeningVal"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("OpeningVal") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        

        <asp:TemplateField HeaderText="Chalan"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("Chalan") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="ChDate" HeaderText="ChallanDate" ItemStyle-HorizontalAlign="Center" SortExpression="ChDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left"/></asp:BoundField>

        <asp:TemplateField HeaderText="SupName"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("SupName") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupAdd"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("SupAdd") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SupRegNo"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("SupRegNo") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MaterialName"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("MaterialName") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RcvQty"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("RcvQty") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WithoutSDvatValue"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("WithoutSDvatValue") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SDValue"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("SDValue") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="VatValue"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("VatValue") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IssueQty"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("IssueQty") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IssueVal"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("IssueVal") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ClosingQty"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("ClosingQty") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ClosingVal"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("ClosingVal") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        </Columns>
        </asp:GridView>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
