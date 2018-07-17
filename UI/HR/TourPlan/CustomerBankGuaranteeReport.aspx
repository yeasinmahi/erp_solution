<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBankGuaranteeReport.aspx.cs" Inherits="UI.HR.TourPlan.CustomerBankGauranteeReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../Content/CSS/MyStyle.css" rel="stylesheet" />--%>
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 700px;
            table-layout: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                <div>
                    
                    <table style="vertical-align: top; background-color: #DDD;" class="auto-style1">
                        <tr>
                            <td style="text-align:right;">
                                <asp:Label ID="Label1" runat="server" Text="Issue Date:" CssClass="lbl"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtFormDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Expire Date:"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" BackColor="#ffff99"  Text="Show Report"  />
                            </td>
                        </tr>
                    </table>
                    <div class="divHeader" style="padding-top:8px;padding-bottom:8px;padding-left:5px;">
                        <asp:Label ID="lbltitle" runat="server" Text="Customer Bank Guarantee Report: "></asp:Label>
                    </div>
                    
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GVList" runat="server" AutoGenerateColumns="False" DataKeyNames="intID" DataSourceID="odsGVList">
                        <Columns>
                            <asp:TemplateField HeaderText="SL.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:BoundField DataField="intID" HeaderText="intID" InsertVisible="False" ReadOnly="True" SortExpression="intID" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="strName" HeaderText="Customer Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="strText" HeaderText="Territroy" SortExpression="strText" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strText1" HeaderText="Area" SortExpression="strText1" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strText2" HeaderText="Region" SortExpression="strText2" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strName1" HeaderText="Sales Office" SortExpression="strName1" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strBankName" HeaderText="Bank Name" SortExpression="strBankName" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strBranchName" HeaderText="Branch Name" SortExpression="strBranchName" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strLienNo" HeaderText="Lien No" SortExpression="strLienNo" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="monBGAmount" HeaderText="Amount" SortExpression="monBGAmount" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Column1" HeaderText="Issue Date" ReadOnly="True" SortExpression="Column1" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Column2" HeaderText="Expire Date" ReadOnly="True" SortExpression="Column2" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Column3" HeaderText="Duration" ReadOnly="True" SortExpression="Column3" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="strEmployeeName" HeaderText="Employee Name" SortExpression="strEmployeeName" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="Column4" HeaderText="Insert Date" ReadOnly="True" SortExpression="Column4" ItemStyle-HorizontalAlign="Center"/>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsGVList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerBankGauranteeList" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.CustomerBankGauranteeListTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtFormDate" Name="dteFromDate" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtToDate" Name="dteToDate" PropertyName="Text" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                    
                </div>

        <%----=========================================End My Code From Here=================================================--%>

            </ContentTemplate>
         </asp:UpdatePanel>
        
    </form>
</body>
</html>
