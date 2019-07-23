<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnfoundView.aspx.cs" Inherits="UI.SAD.Corporate_sales.UnfoundView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <script>
        $(document).ready(function () {
            $("#<%=txtcustomer.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("UnfoundView.aspx/GetCustomer") %>',
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
</script>

    </head>
<body>
    <form id="frmselfresign" runat="server">
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
<div>
     <table  style="width:100%;height:2px">
    
    <tr class="tblroweven" > 
        
    <td style="text-align:justify;width:100%; font-size:12px; background-color:white;" " >
    
    <div id="topbox">  
      <h3 class="td">Accounts Unfound Amount Details </h3>      
    </div>
  
         <table class="" style="width:100%; height:2px ">
    
    <tr style="width:100%" > 
        
    <td style="text-align:center;font-size:16px; background-color:white;" >
    <center>
    <table>
        <tr><td><asp:Label ID="lbldpt" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
   <td colspan="3"><asp:TextBox ID="txtcustomer" runat="server" CssClass="txtBox" style="width:500px"></asp:TextBox>
    <asp:HiddenField ID="hdfcustid" runat="server" /></tr>
        <tr>
             
            <td><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Account Id:"></asp:Label></td>
            <td><asp:TextBox ID="TextBox1" ReadOnly="true" runat="server"></asp:TextBox></td>
            <td><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Account:"></asp:Label></td>
            <td class="auto-style3"><asp:TextBox ReadOnly="true" ID="TextBox4"  runat="server"></asp:TextBox></td>
        </tr>
       
        <tr>
             <td><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Date:"></asp:Label></td>
            <td><asp:TextBox ID="TextBox2" ReadOnly="true"  runat="server" autocomplete="off"></asp:TextBox></td>
            <td><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Naration:"></asp:Label></td>
            <td class="auto-style3"><asp:TextBox ID="TextBox3" ReadOnly="true"  Width="300" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
             <td><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Input Cheque No:"></asp:Label></td>
            <td><asp:TextBox ID="TextBox5"  runat="server"></asp:TextBox></td>
              </tr>

         <tr>
           <td colspan="4"><br /><asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click1"></asp:Button>

           </td>
        </tr>
    </table>
      </center>
   
            </td>
    </tr> 
    </table>
     
        
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
