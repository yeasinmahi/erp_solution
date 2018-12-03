<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodsBridge.aspx.cs" Inherits="UI.SCM.FinishedGoodsBridge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <style>
        .tblcls{
            border:1px solid black;

        }
        
    </style>
  <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
    gtag('config', 'UA-125570863-1');
</script>  
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
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
                <div class="leaveApplication_container">
                    <div class="tabs_container" style="text-align: left">Finished Goods Bridge<hr /></div>
                    <table>
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit Name : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="FG : "></asp:Label></td>
                            <td style="text-align: left;" colspan="3">
                                <asp:DropDownList ID="ddlFG" CssClass="ddList" Width="400px" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFG_SelectedIndexChanged" OnDataBound="ddlFG_DataBound"></asp:DropDownList></td>
                            <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblSadUOM" runat="server" CssClass="lbl" Text="SadUOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSadUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSadUOM_SelectedIndexChanged"></asp:DropDownList></td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblInvUOM" runat="server" CssClass="lbl" Text="Inv.UOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlInvUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlInvUOM_SelectedIndexChanged"></asp:DropDownList></td>
                           <td>
                               <asp:TextBox ID="txtCount" runat="server" Enabled="false" Width="30px"></asp:TextBox>
                               
                           </td>
                            <td>
                                <%--<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/>--%>
                                <asp:Button ID="btnAddFg" runat="server" Text="Add FG" CssClass="btnButton" OnClick="btnAddFg_Click" /></td>
                            
                             </tr>
                           </tr>                       
                    </table>
                    <div style="height:20px;"></div>
                    <asp:Panel ID="Panel1" runat="server">
                  <table ID="tbllist" style="border-collapse: collapse; table-layout: auto; border-spacing: 3px;" class="tblcls" runat="server">
                      <tr class="tblcls" style="">
                          <th class="tblcls"><asp:Label ID="Label1" runat="server" Text="Item Base Name"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label3" runat="server" Text="Item Description" Width="150px" ></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label4" runat="server" Text="PART/MODEL/SERIAL" Width="200px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label5" runat="server" Text="Brand"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label6" runat="server" Text="UOM" Width="80px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label7" runat="server" Text="Cluster" Width="80px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label8" runat="server" Text="Commodity" Width="100px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label9" runat="server" Text="Category" Width="90px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label10" runat="server" Text="Clus" Width="60px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label11" runat="server" Text="Group" Width="60px"></asp:Label></th>
                          <th class="tblcls"><asp:Label ID="Label12" runat="server" Text="Cat" Width="60px"></asp:Label></th>
                      </tr>
                      <tr style="text-align:center;">
                         <td class="tblcls"><asp:Label ID="lblitemBaseName" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblitemDescription" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblpart" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblbrand" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lbluom" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblcluster" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblcommodity" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblcategory" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblclus" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblgroup" runat="server" ></asp:Label></td>
                          <td class="tblcls"><asp:Label ID="lblcat" runat="server" ></asp:Label></td>
                          
                      </tr>
                     
                     
                  </table>
                    </asp:Panel>
                </div>
                 <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
