<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalis_Registration_UI.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.Detalis_Registration_UI" %>


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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>   


    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
 <%-- <script> function CloseWindow() {
     window.close();      
 } </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
            //window.opener.location.href = window.opener.location.href;
        }
    }
    window.onbeforeunload = RefreshParent;
</script>    --%>

    
    <style type="text/css">
        #divFile p { 
            font:15px tahoma, arial; 
        }
        #divFile h3 { 
            font:16px arial, tahoma; 
            font-weight:bold;
        }
        .auto-style1 {
            height: 25px;
        }
        .txtBox {}
    </style>

    

          
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />        
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
    <asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnHightMilage" runat="server" />
      
        
        <div class="tabs_container">Registration <hr /></div>

        <table  class="tbldecoration" style="width:auto; ">
            <tr>
                  <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Owner Name"></asp:Label></td>
             <td style="text-align:left;"><asp:TextBox ID="TxtStrUnit" runat="server" CssClass="txtBox"   ReadOnly="true" Width="190px" ></asp:TextBox>
                </td>
            </tr>
        <tr> 
           <td style="text-align:right;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Text="Vehicle Number :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleName" runat="server" CssClass="txtBox"   ReadOnly="true" Width="398px" ></asp:TextBox>
                </td>
                  </tr
             <tr> 
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Vehicle Type :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtVehicleType" runat="server" CssClass="txtBox"   ReadOnly="true" Width="398px" ></asp:TextBox> </td>
             </tr>
           
             <tr> 
           <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Registration Date:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtRegistrationDate" runat="server" CssClass="txtBox"  ReadOnly="true" Width="190px"></asp:TextBox>
                </td>
                  </tr>
             <tr> 
           <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Total Taka:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtTolTaka" runat="server" CssClass="txtBox"   ReadOnly="true" Width="190px" ></asp:TextBox>
                </td>
                  </tr>
             <tr>
                 <td><asp:Button ID="btnApprove" Width="100px" runat="server" Text="Approve" OnClick="btnApprove_Click"/> </td>
            </tr>
            
       </table>
        <table>
            <tr><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>
               <td style="text-align:right;"> <asp:GridView ID="dgvDetalisdata" ShowFooter="true" runat="server" AutoGenerateColumns="False">
                   <Columns>
                      <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>
                       <asp:BoundField HeaderText="ServiceName" DataField="strTemplateName" SortExpression="strTemplateName" >
                        <ItemStyle Width="250px"></ItemStyle></asp:BoundField>

                       <asp:BoundField HeaderText="Taka" DataField="monTaka" SortExpression="monTaka" >
                       <ItemStyle Width="150px"></ItemStyle></asp:BoundField>
                   </Columns>
                   </asp:GridView></td>
                <caption>
                   Detalis View
                </caption>
        </table>
        </div>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
