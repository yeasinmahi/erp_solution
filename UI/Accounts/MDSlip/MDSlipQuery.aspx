<%@ Page Language="C#" Theme="Theme1"  AutoEventWireup="true" Inherits="UI.Accounts.MDSlip.MDSlipQuery" Codebehind="MDSlipQuery.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html >
<head runat="server">
    <title>Untitled Page</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />    
     
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>    
     <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top; z-index:1; position:absolute;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table width="90%">
                        <tr>
                            <td align="left" class="PageHeader">
                                MD Slip
                            </td>
                            <td align="left">
                                Unit
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUnits"
                                    TypeName="HR_BLL.Global.Unit" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="center">
                                Date
                                <asp:TextBox ID="txtFrom" runat="server" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server" EnableViewState="true"
                                    Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                <asp:RadioButtonList ID="rbReceivePayment" runat="server">
                                    <asp:ListItem Selected="True" Value="RE">Receive</asp:ListItem>
                                    <asp:ListItem Value="PAY">Payment</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="left">                                
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" 
                                    Text="Show" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
    <asp:GridView ID="GridView1" SkinID="sknGrid2" runat="server" 
        AutoGenerateColumns="true" onrowdatabound="GridView1_RowDataBound">
    </asp:GridView>
    </form>
</body>
</html>
