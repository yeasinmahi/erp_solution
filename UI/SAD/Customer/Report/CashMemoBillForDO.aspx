<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashMemoBillForDO.aspx.cs" Inherits="UI.SAD.Customer.Report.CashMemoBillForDO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />   
    
    <script type="text/javascript">
        function Print() {
            document.getElementById("btnGo").hidden = true;
            document.getElementById("lblUnit").style.display = "none";
             document.getElementById("ddlUnit").hidden = true;
            document.getElementById("lblDONumber").style.display = "none";
            document.getElementById("txtDO").hidden = true;
            
            document.getElementById("BtnPrint").hidden = true;
        
                    window.print();
            self.close();
            
          
        }
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=750,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ValidateComplete(sender, args) {
            if (!confirm('Do you want to complete this voucher?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
        function Show(id) {
            var didS = 'ds' + id;
            var didH = 'dh' + id;
            document.getElementById(id).style.display = "";
            document.getElementById(didS).style.display = "none";
            document.getElementById(didH).style.display = "";
        }
        function Hide(id, did) {
            var didS = 'ds' + id;
            var didH = 'dh' + id;
            document.getElementById(id).style.display = "none";
            document.getElementById(didS).style.display = "";
            document.getElementById(didH).style.display = "none";
        }

    </script>

    <%--  <script type="text/javascript">
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("print");
            dv.style.display = "block";

            dv = document.getElementById("btn");
            dv.style.display = "none";
        }
           </script>--%>

 <%--   <script  type="text/javascript">
    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=100,toolbar=0,scrollbars=0,status=0,dir=ltr');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>--%>

<%--    <script type="text/javascript">
        function Print() {
            //document.getElementById("btnGo").hidden = true;
            //document.getElementById("btnprint").style.display = "none";
            window.print();
            self.close();
        }

    </script>--%>

    <style type="text/css">
        .hide
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
                    <br />
                    <table style="width: 400px;" align="center">
                        <tr>
                            <td>
                                <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                               <asp:Label ID="lblDONumber" runat="server" Text="D.O Number"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDO" Text="" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnGo" runat="server" Text="GO" OnClick="btnGo_Click" />
                            </td>
                           <%-- <td>
                                <asp:button id="BtnPrint" runat="server" onclientclick="javascript:CallPrint('bill');" text="Print" xmlns:asp="#unknown" />
                            </td--%>
                            
            <td align="right" style="width:50%">
                <a href="#" onclick="Print()"><b> <asp:button id="BtnPrint" runat="server"  text="Print"/></b></a>
            </td>

                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 120px;" >
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <asp:Panel ID="pnlDO" runat="server">
                <%# tempD.ToString() %>
            </asp:Panel>
            <asp:Panel ID="pnlCH" runat="server">
                <%# mainD.ToString()%>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>

</html>
