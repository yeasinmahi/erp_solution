<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Loan.aspx.cs" Inherits="UI.SAD.Corporate_sales.Claim_Settlement.Vehicle_Loan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>

<script>
    $(document).ready(function () {
        $("#<%=txtcustomer.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Vehicle_Loan.aspx/GetCustomer") %>',
                        data: '{"customer":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('^')[0],
                                    val: item.split('^')[1]

                                }
                            }))
                        },
                        error: function (response) { alert('Error'); },
                        failure: function (response) { alert('fail'); }
                    });
                },

                select: function (e, i) {
                    e.preventDefault()
                    $("[id$=hdfcustid]").val(i.item.val);
                },
                minLength: 2
            });
    });

    $(document).ready(function () {
        $("#<%=txtvehicle.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Vehicle_Loan.aspx/GetLoanCustomer") %>',
                        data: '{"customer":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('^')[0],
                                    val: item.split('^')[1]

                                }
                            }))
                        },
                        error: function (response) { alert('Error'); },
                        failure: function (response) { alert('fail'); }
                    });
                },

                select: function (e, i) {
                    e.preventDefault()
                    $("[id$=hdncustvehicleid]").val(i.item.val);
                },
                minLength: 2
            });
        });



</script>


    <script type="text/javascript">
        function validate() {
            var txtdistributor = document.getElementById('<%=txtcustomer.ClientID %>').value;
            if (txtdistributor == "") {
                alert("Please Select Customer");
                document.getElementById("<%=txtcustomer.ClientID%>").focus();
                return false;
            }
            var ddlcategory = document.getElementById('<%=txtvehicle.ClientID%>').value;
            if (ddlcategory == 0) {
                alert("Please Select Vehicle");
                document.getElementById("<%=txtvehicle.ClientID%>").focus();
                return false;
            }

            var dt = document.getElementById('<%=txtHOvrDate.ClientID%>').value;
            if (dt == 0) {
                alert("Please Select Product");
                document.getElementById("<%=txtHOvrDate.ClientID%>").focus();
                return false;
            }

            var rtv = document.getElementById('<%=txtvclprc.ClientID%>').value;
            if (rtv == 0) {
                alert("Please input Useful Life");
                document.getElementById("<%=txtvclprc.ClientID%>").focus();
                return false;
            }

            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtvclprc.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtvclprc.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please input only numeric data");
                    document.getElementById("<%=txtvclprc.ClientID%>").focus();
                    return false;
                }
            }

            var txtproduct = document.getElementById('<%=txtuselif.ClientID%>').value;
            if (txtproduct == 0) {
                alert("Please input month of usefulness");
                document.getElementById("<%=txtuselif.ClientID%>").focus();
                return false;
            }

            var txtqty = document.getElementById('<%=txtloanmnt.ClientID%>').value;
            if (txtqty == "") {
                alert("Please input loan payment month");
                document.getElementById("<%=txtloanmnt.ClientID%>").focus();
                return false;
            }
            }
            </script>

<style>.hidden {display:none}</style>

<style>.lap
 {display:none;
z-index:0
    
}</style>
</head>
<body>
    <form id="frmrtn" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
  <%--  <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"><table border="0"; style="width:Auto"; >
    <tr><td colspan="4" class="tblroweven">Vehicle Loan :</td></tr>
    <tr class="tblroweven">     
    <td style="text-align:right;" ><asp:Label ID="lbldpt" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
    <td colspan="5"><asp:TextBox ID="txtcustomer" runat="server" CssClass="txtBox" style="width:500px"></asp:TextBox>
    <asp:HiddenField ID="hdfcustid" runat="server" />
    </td>  
    </tr>
        <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblvehicle" CssClass="lbl" runat="server" Text="Vehicle Name : "></asp:Label></td>  
        <td colspan="5"><asp:TextBox ID="txtvehicle" runat="server"  CssClass="txtBox" AutoPostBack="true" Width="400px" ></asp:TextBox><asp:HiddenField ID="hdncustvehicleid" runat="server" />
    </td>

    </tr>

    <tr class='tblroweven'>
    <td style="text-align:right;"><asp:Label ID="lblchno" CssClass="lbl" runat="server" Text="Vehicle Chesis No. : "></asp:Label></td>
    <td><asp:TextBox ID="txtchno" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblmodelno" CssClass="lbl" runat="server" Text="Model No : "></asp:Label></td>
    <td><asp:TextBox ID="txtmodelnno" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblHOvrDate" CssClass="lbl" runat="server" Text="Handover Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtHOvrDate" runat="server" CssClass="txtBox"></asp:TextBox><script type="text/javascript"> new datepickr('txtHOvrDate', { 'dateFormat': 'Y-m-d' });</script></td>
    </tr>
        <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblvclprc" CssClass="lbl" runat="server" Text="Vehicle Price : "></asp:Label></td>
    <td><asp:TextBox ID="txtvclprc" runat="server" CssClass="txtBox" OnTextChanged="txtvclprc_TextChanged" AutoPostBack="true"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbluselif" CssClass="lbl" runat="server" Text="Vehicle Useful Life (Month) : "></asp:Label></td>
    <td><asp:TextBox ID="txtuselif" runat="server" CssClass="txtBox" OnTextChanged="txtuselif_TextChanged" AutoPostBack="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblloanmnt" CssClass="lbl" runat="server" Text="Loan Period (Month) : "></asp:Label></td>
    <td><asp:TextBox ID="txtloanmnt" runat="server" CssClass="txtBox" OnTextChanged="txtloanmnt_TextChanged"  AutoPostBack="true"></asp:TextBox></td>
    </tr>

        <tr class='tblroweven'>
        <td style="text-align:right;"><asp:Label ID="lbldwnpay" CssClass="lbl" runat="server" Text="Down Payment : "></asp:Label></td>
            <td><asp:TextBox ID="txtdwnpay" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtdwnpay_TextChanged"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbldepm" CssClass="lbl" runat="server" Text="Depriciation (Monthly) : "></asp:Label></td>
    <td><asp:TextBox ID="txtdepm" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblemi" CssClass="lbl" runat="server" Text="Equated Monthly Installment : "></asp:Label></td>
    <td><asp:TextBox ID="txtemi" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblremarks" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
    <td colspan="5"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="300px"></asp:TextBox></td></tr>

    <tr class='tblroweven'><td colspan="6" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click" OnClientClick="return validate()" /></td></tr>
    </table></div>   
    
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
