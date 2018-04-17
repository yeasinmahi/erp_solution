<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreasaryDeposite.aspx.cs" Inherits="UI.HR.Tax.TreasaryDeposite" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Tax Treasury deposite ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtNarration = document.forms["frmtreasury"]["txtNarration"].value;
            if (txtNarration == null || txtNarration == "") {
                alert("Must be filled by valid narration.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function CompleteTreasuryDeposite(intAutoId, UnitName, TreasuryAmount) {
            document.getElementById("txtunit").innerText = UnitName;
            document.getElementById("txtTreasuryAmount").innerText = TreasuryAmount;
            document.getElementById("hdntreasuryID").value = intAutoId;
            $("#approvedDiv").fadeIn("slow");
         }
        function ConfirmComplete() {
            document.getElementById("hdncomplete").value = "0";
            var txtchallanno = document.forms["frmtreasury"]["txtchallanno"].value;
            if (txtchallanno == null || txtchallanno == "") {
                alert("Must be filled by valid challanno.");
                document.getElementById("approvedDiv").style.display = "block";
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdncomplete").value = "1"; $("#approvedDiv").fadeOut("slow"); }
                else { confirm_value.value = "No"; document.getElementById("hdncomplete").value = "0"; }
            }
        }
   </script>
</head>
<body>
    <form id="frmtreasury" runat="server">
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
    <div class="tabs_container">Treasury Deposite Information :<hr />
        <table><tr>
        <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
        DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" OnDataBound="ddlUnit_DataBound"></asp:DropDownList>
        <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="String"/></SelectParameters></asp:ObjectDataSource>
        </td>
        <td style="text-align:right;"><asp:Label ID="lbltax" CssClass="lbl" runat="server" Text="Total-Tax : "></asp:Label></td>
        <td><asp:TextBox ID="monTaxAmount" runat="server" CssClass="txtBox" Enabled="false" Text="0.00"></asp:TextBox></td>
        </tr>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblnarr" CssClass="lbl" runat="server" Text="Narration : "></asp:Label></td>
        <td><asp:TextBox ID="txtNarration" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
        <td colspan="2" style="font-size:11px;">
        <asp:RadioButtonList ID="rdocompletestatus" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdocompletestatus_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="false">Not Completed</asp:ListItem><asp:ListItem Value="true">Completed</asp:ListItem></asp:RadioButtonList> 
        </td>
        </tr>
        <tr>
        <td colspan="4" style="text-align:right;"><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdncompleteded" runat="server" />
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:10px;" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
        </td></tr>
        </table>
    </div>

        <asp:GridView ID="dgvtreasury" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" FooterStyle-HorizontalAlign="Right" 
        BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" ShowFooter="True" FooterStyle-BackColor="#99ccff" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="Blue" DataSourceID="odstreasuryinfo">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:BoundField DataField="UnitName" HeaderText="Unit-Name" ItemStyle-HorizontalAlign="Center" SortExpression="UnitName">
        <ItemStyle Width="175px" HorizontalAlign="Left"/></asp:BoundField>

        <asp:BoundField DataField="ChallanNo" HeaderText="Challan No." ItemStyle-HorizontalAlign="Center" SortExpression="ChallanNo">
        <ItemStyle Width="100px" HorizontalAlign="Left"/></asp:BoundField>

        <asp:BoundField DataField="DepositeDate" HeaderText="Deposite Date" ItemStyle-HorizontalAlign="Center" SortExpression="DepositeDate" DataFormatString="{0:yyyy-MM-dd}" FooterText="Total : " >
        <ItemStyle Width="100px" HorizontalAlign="Left"/></asp:BoundField>       
            
        <asp:BoundField DataField="TreasuryAmount" HeaderText="Amount" ItemStyle-HorizontalAlign="Center" SortExpression="TreasuryAmount" DataFormatString="{0:0.00}">
        <ItemStyle Width="100px" HorizontalAlign="Right"/></asp:BoundField> 

        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" >
        <ItemTemplate> 
        <a class="nextclick" href="#" style="cursor:pointer; font-size:10px;" onclick="<%#  CompleteTreasuryDeposite(""+Eval("intAutoId"),""+Eval("UnitName"),""+Eval("TreasuryAmount"))  %>">
        Complete</a></ItemTemplate> <ItemStyle HorizontalAlign="right" /></asp:TemplateField>                            
        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odstreasuryinfo" runat="server" SelectMethod="GetTreasuryInformation" TypeName="HR_BLL.Reports.AbsentReport">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlUnit" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="hdncompleteded" Name="status" PropertyName="Value" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    <div id="approvedDiv" style="top: 130px;left:1px;">
        <table border="1"; style="width:Auto"; align="center" >
        <tr>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Unit :"></asp:Label></td>
        <td><asp:TextBox ID="txtunit" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblamount" CssClass="lbl" runat="server" Text="Treasury-Amount :"></asp:Label></td>
        <td><asp:TextBox ID="txtTreasuryAmount" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblchallanno" CssClass="lbl" runat="server" Text="Challan No : "></asp:Label></td>
        <td><asp:TextBox ID="txtchallanno" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;" colspan="2">
        <asp:HiddenField ID="hdntreasuryID" runat="server"/><asp:HiddenField ID="hdncomplete" runat="server" />
        <asp:Button ID="btnComplete" runat="server" class="nextclick" style="font-size:10px;" Text="Complete" OnClientClick="ConfirmComplete()" OnClick="btnComplete_Click"/> 
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
