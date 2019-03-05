<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_Previous_History.aspx.cs" Inherits="UI.HR.Reports.Emp_Profile_Leave_Movement_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Previous History</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Employee Previous History" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                 <div class="col-md-4">
                                      <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:TextBox ID="txtEmpSearch" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:TextBox>
                                 </div>
                                <div class="col-md-4">
                                      <asp:Label ID="Label2" runat="server" Text="From Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" >
                                          <asp:ListItem Value="1">2012</asp:ListItem>
                                          <asp:ListItem Value="2">2013</asp:ListItem>
                                          <asp:ListItem Value="3">2014</asp:ListItem>
                                          <asp:ListItem Value="4">2015</asp:ListItem>
                                          <asp:ListItem Value="5">2016</asp:ListItem>
                                          <asp:ListItem Value="6">2017</asp:ListItem>
                                          <asp:ListItem Value="7">2018</asp:ListItem>
                                          <asp:ListItem Value="8">2019</asp:ListItem>

                                      </asp:DropDownList>
                                 </div>
                                <div class="col-md-4" style="padding-top:20px;">                                
                               
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" OnClientClick="return Validation()" Text="Show" OnClick="btnShow_Click"/>
                                
                                </div>
                            </div>
                        </div>

                    </div>
                </div>


                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
