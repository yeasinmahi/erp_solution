<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAdviceOfTreasuryChallan.aspx.cs" Inherits="UI.PaymentModule.ShowAdviceOfTreasuryChallan" %>
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
    <script>
 function PrintAdvice() {
            document.getElementById("btnprint").style.display = "none";
            document.getElementById("head").style.display = "none";
            document.getElementById("msg").style.display = "none";
            window.print(); self.close();
        }
    </script>
</head>
<body>
    <form id="frmaclmanatt" runat="server">
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

        <div class="leaveApplication_container"> 
        <div class="tabs_container" id="head"> Treasury challan Information :<hr /></div>
            <table id="btnprint"><tr><td colspan="2" style="text-align:right;"><asp:Button ID="btnPrintAdvice" runat="server" class="nextclick" style="font-size:12px; cursor: pointer;" 
        Text="Print Advice" OnClientClick="PrintAdvice()" /></td></tr></table>
        <table id="tblform" style="background-color: white;" >
            
            <tr style="text-align:center;">
                <td colspan="2">United Dhaka Tobacco Limited.</td>
            </tr>
            <tr style="text-align:center;">
                <td colspan="2">Akij House,198 Bir Uttam Mir Shawkat Sarak (Gulshan Link Road).Tejgaon,Dhaka-1208.</td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDescription"  runat="server"></asp:Label>
                </td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label1"  runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label2"  runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label3"  runat="server"></asp:Label>
                </td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label4"  runat="server"></asp:Label>
                </td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label5"  runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label6"  runat="server"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label7"  runat="server"></asp:Label>
                </td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="Label8"  runat="server"></asp:Label>
                </td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" >
                        <Columns>
                            <asp:BoundField DataField="rowNumber" HeaderText="Serial Number" SortExpression="rowNumber" />
                            <asp:BoundField DataField="TreasuryType" HeaderText="Treasury Type" SortExpression="TreasuryType" />
                            <asp:BoundField DataField="BeneficiaryName" HeaderText="Beneficiary Name" SortExpression="BeneficiaryName" FooterText="Total">
                            <FooterStyle ForeColor="Black" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="monAmount" HeaderText="Amount" SortExpression="monAmount" />--%>
                            <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                                <ItemTemplate><asp:Label ID="lblamount" runat="server" Text='<%# Bind("monAmount", "{0:N2}") %>'></asp:Label></ItemTemplate>                          
                                <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                              </FooterTemplate>
                             <ItemStyle HorizontalAlign="right" Width="90px"/>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                            <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("monAmount", "{0:N2}") %>'></asp:Label></ItemTemplate>
                             <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                              </FooterTemplate>
                             <ItemStyle HorizontalAlign="right" Width="90px"/>
                             </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr><tr><td colspan="2" style="height:15px;"></td></tr>
            <tr >
                <td colspan="2"><asp:Label ID="Label9" runat="server"></asp:Label></td>
            </tr><tr><td colspan="2" style="height:30px;"></td></tr>
            <tr>
                <td colspan="2">You are also requested to handover the above Bangladesh Bank cheques to Md. Robin Khandker. His specimen signature is attested below:</td>
            </tr>
            <tr><td colspan="2" style="height:30px;"></td></tr>
            <tr><td>Md. Robin Khandker</td><td>Signature</td></tr>
            <tr><td colspan="2" style="height:30px;"></td></tr>
            <tr><td colspan="2">Sincerely Yours</td></tr>
            <tr><td colspan="2">For United Dhaka Tobacco Company Ltd.</td></tr>
        </table>


        </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
