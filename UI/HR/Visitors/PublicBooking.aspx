<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicBooking.aspx.cs" Inherits="UI.HR.Visitors.PublicBooking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtHost.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetSearchHostList") %>',
                        data: '{"bookingby":"' + $("#hdnbookingby").val() + '","searchKey":"' + request.term + '"}',
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

            $("#<%=txtGuest.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetSearchGuestList") %>',
                        data: '{"bookingby":"' + $("#hdnbookingby").val() + '","searchKey":"' + request.term + '"}',
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
            var txtHost = document.forms["frmpubbk"]["txtHost"].value;
            var txtGuest = document.forms["frmpubbk"]["txtGuest"].value;
            var txtContact = document.forms["frmpubbk"]["txtContact"].value;
            var txtAddguest = document.forms["frmpubbk"]["txtAddguest"].value;
            var txtNarration = document.forms["frmpubbk"]["txtNarration"].value;
            var txtVDate = document.forms["frmpubbk"]["txtVDate"].value;
            if (txtGuest == null || txtGuest == "") {
                alert("Guest must be filled..");
            }
            else if (txtContact == null || txtContact == "") {
                alert("Contact must be filled..");
            }
            else if (txtAddguest == null || txtAddguest == "") {
                alert("Guest address must be filled..");
            }
            else if (txtNarration == null || txtNarration == "") {
                alert("Reason must be filled..");
            }
            else if (txtVDate == null || txtVDate == "") {
                alert("Date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }


        }
    </script>
    
</head>
<body>
    <form id="frmpubbk" runat="server">
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
        <table border="0"; style="width:Auto"; >
        <tr><td colspan="4" class="tblheader">Public Visitors Information :<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnbookingby" runat="server" /></td></tr>
        <tr class="tblrowodd"> 
        <td style="text-align:right;"><asp:Label ID="lblhost" CssClass="lbl" runat="server" Text="Host-Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtHost" runat="server" CssClass="txtBox"></asp:TextBox></td>       
        <td style="text-align:right;"><asp:Label ID="lblguest" CssClass="lbl" runat="server" Text="Guest-Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtGuest" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>
        <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblContactno" CssClass="lbl" runat="server" Text="Contact No. : "></asp:Label></td>
        <td><asp:TextBox ID="txtContact" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblvstdate" CssClass="lbl" runat="server" Text="Visit Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtVDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtVDate', { 'dateFormat': 'Y-m-d' });</script></td>   
        </tr> 

        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblstart" runat="server" CssClass="lbl" Text="Start Time"></asp:Label></td>
        <td><MKB:TimeSelector ID="tpkSTime" runat="server" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
        <td style="text-align:right;"><asp:Label ID="lblend" runat="server" CssClass="lbl" Text="End Time"></asp:Label></td>
        <td><MKB:TimeSelector ID="tpkETime" runat="server" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
        </tr>

        <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblAddguest" CssClass="lbl" runat="server" Text="Guest Address : "></asp:Label></td>
        <td><asp:TextBox ID="txtAddguest" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
                   
        <td style="text-align:right;"><asp:Label ID="lblReason" CssClass="lbl" runat="server" Text="Narration : "></asp:Label></td>
        <td><asp:TextBox ID="txtNarration" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblclndr" CssClass="lbl" runat="server" Text="Add To Calendar : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlCalendr" runat="server" AutoPostBack="false" CssClass="dropdownList">
        <asp:ListItem Selected="True" Value="1">Don't add</asp:ListItem><asp:ListItem Value="2">Personal</asp:ListItem>
        <asp:ListItem Value="3">Both(G & H)</asp:ListItem></asp:DropDownList></td>
        
        <td style="text-align:center;"><asp:CheckBox ID="chkwifi" runat="server" TextAlign="Right" Text=" Need wifi  " /></td>
        <td style="text-align:right;"><asp:Button ID="btnSave" runat="server" class="nextclick" style="font-size:11px;" 
        Text="SAVE" OnClientClick = "Confirm()" OnClick="btnSave_Click" /> <asp:HiddenField ID="hdnconfirm" runat="server"/></td>
        </tr>
        <tr><td colspan="4"><div class="tblheader"> Waiting List :</div>
        <asp:GridView ID="dgvprb" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="Red" 
        BorderStyle="Solid" BorderWidth="0px" CellPadding="1" ForeColor="Black"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="VCode" SortExpression="Code" >
        <ItemTemplate><asp:Label ID="lblcd" runat="server" Text='<%# Eval("Code") %>' ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="125px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Visiting" SortExpression="DOV">
        <ItemTemplate><asp:Label ID="lblvdt" runat="server" Text='<%# Bind("DOV", "{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Guest Name" SortExpression="Visitors">
        <ItemTemplate><asp:Label ID="lblguest" runat="server" Text='<%# Bind("Visitors") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="225px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Contact" SortExpression="Contact">
        <ItemTemplate><asp:Label ID="lblphn" runat="server" Text='<%# Bind("Contact") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Host Name" SortExpression="Host" >
        <ItemTemplate><asp:Label ID="lblhst" runat="server" Text='<%# Eval("Host") %>' ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" Width="200px" /></asp:TemplateField>

        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        </table>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
