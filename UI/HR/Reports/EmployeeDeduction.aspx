<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDeduction.aspx.cs" Inherits="UI.HR.Reports.EmployeeDeduction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetSearchEmployeeList") %>',
                        data: '{"enroll":"' + $("#hdnenroll").val() + '","station":"' + $("#hdnstation").val() + '","searchKey":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) { },
                        failure: function (response) { }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });


        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtFromDate = document.forms["frmdeduction"]["txtFromDate"].value;
            var txtToDate = document.forms["frmdeduction"]["txtToDate"].value;

            if (txtFromDate == null || txtFromDate == "") {
                alert("From date must be filled by valid formate (year-month-day).");
            }
            else if (txtToDate == null || txtToDate == "") {
                alert("To date must be filled by valid formate (year-month-day).");
            }
            else { document.getElementById("hdnconfirm").value = "1";  }
        }
    </script>
</head>
<body>
    <form id="frmdeduction" runat="server">
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
    <div class="tabs_container"> Employee Deduction Information :<asp:HiddenField ID="hdnenroll" runat="server"/>
    <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
    <table style="width:auto; float:left; ">
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblfrm" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
    <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
    <td style="text-align:right;"><asp:Label ID="lblto" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
    <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td></tr>

    <tr><td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
    <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="false"></asp:TextBox></td>
    <td colspan="2"><asp:Button ID="btnShow" runat="server" class="nextclick" style="font-size:11px;" Text="SHOW" OnClick="btnShow_Click" 
    OnClientClick = "Confirm()"/> <asp:HiddenField ID="hdnconfirm" runat="server"/></td></tr>
    <tr><td colspan="4"><%--<div id="report" runat="server" style="padding:1%;"></div>
    Code, Name, Gross, Pf, Lwp, Absent_, Late, Loan, Tax, OtherDeduction--%></td></tr>
    </table>
    <div style="text-align:left; float:left; clear:both;">
    <asp:GridView ID="dgvdeduction" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderStyle="Solid" 
    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" DataSourceID="odsdd"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:BoundField DataField="Code" HeaderText="Code" ItemStyle-HorizontalAlign="Center">
    <ItemStyle HorizontalAlign="Left" Width="60px" /></asp:BoundField> 
    <asp:BoundField DataField="Name" HeaderText="Employee Name" ItemStyle-HorizontalAlign="Center">
    <ItemStyle HorizontalAlign="Left" Width="225px"/></asp:BoundField>
    <asp:BoundField DataField="Gross"  HeaderText="Gross" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="Pf"  HeaderText="PF" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="Lwp"  HeaderText="Lwp" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="Absent_"  HeaderText="Absent" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="Late"  HeaderText="Late" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="Loan"  HeaderText="Loan" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="Tax"  HeaderText="Tax" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    <asp:BoundField DataField="OtherDeduction"  HeaderText="Others" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Right" Width="65px" /></asp:BoundField>
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    <asp:ObjectDataSource ID="odsdd" runat="server" SelectMethod="GetEmployeeDeduction" TypeName="HR_BLL.Facilities.MobileFacilities">
    <SelectParameters>
        <asp:ControlParameter ControlID="txtFromDate" Name="frmdate" PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="txtToDate" Name="todate" PropertyName="Text" Type="DateTime" />
        <asp:ControlParameter ControlID="txtFullName" Name="EmployeeCode" PropertyName="Text" Type="String" />
        <asp:SessionParameter Name="loginid" SessionField="sesUserID" Type="Int32" />
    </SelectParameters>
    </asp:ObjectDataSource>
    </div>
    
  <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
