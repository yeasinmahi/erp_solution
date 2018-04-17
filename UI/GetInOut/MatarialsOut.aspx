<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatarialsOut.aspx.cs" Inherits="UI.GetInOut.MatarialsOut" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>    
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .nextclick {
            height: 26px;
        }
    </style>
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
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
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
                
    <div class="tabs_container" align="Center">Matarials Out</div>

    <table>
         <tr>
                 <td style="text-align:right;"><asp:Label ID="Lblgetpass" runat="server" CssClass="lbl" Text="Get pass No :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtgetpass" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

                 <td style="text-align:right;"><asp:Label ID="Lblitem" runat="server" CssClass="lbl" Text="Item Name :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtitem" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

                 <td style="text-align:right;"><asp:Label ID="Lblqty" runat="server" CssClass="lbl" Text="Quentity :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtqty" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

                 <td style="text-align:right;"><asp:Label ID="Lbldriver" runat="server" CssClass="lbl" Text="Driver Name :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtdriver" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

                 <td style="text-align:right;"><asp:Label ID="Lblmobaile" runat="server" CssClass="lbl" Text="Mobaile No :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtmobaile" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
        </tr>
       <tr>
                 <td style="text-align:right;"><asp:Label ID="Lbldestination" runat="server" CssClass="lbl" Text="Destination:"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtdestination" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
                      
                 <td style="text-align:right;"><asp:Label ID="Lbltype" runat="server" CssClass="lbl" Text="Out Type :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:DropDownList ID="Ddltype" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList> 

                <td style="text-align:right;"><asp:Label ID="Lblscaleid" runat="server" CssClass="lbl" Text="Scale Id :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtscaleid" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>

                <td style="text-align:right;"><asp:Label ID="Lblgrossweight" runat="server" CssClass="lbl" Text="Gross Weight:"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtgrossweight" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>

                <td style="text-align:right;"><asp:Label ID="Lblnetweight" runat="server" CssClass="lbl" Text="Net Weight:"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="txtnetweight" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>

             <td colspan="4" style="text-align:right;"> <asp:Button ID="btnadd" runat="server" CssClass="nextclick" Text="Add" OnClick="btnadd_Click"/></td>
             <td style="text-align:right;"> <asp:Button ID="btnsubmit" runat="server" CssClass="nextclick" Text="Submit" OnClick="btnsubmit_Click"/></td>
          </tr>



         <tr>

           <td colspan="10">
               <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgv_RowDeleting">
                   <Columns>
                       <asp:TemplateField HeaderText="Sl."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Getpass">
                           <ItemTemplate>
                               <asp:Label ID="Lblpo" runat="server" Text='<%# Bind("ponumber") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Item">
                           <ItemTemplate>
                               <asp:Label ID="Lblcha" runat="server" Text='<%# Bind("Challanno") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Qty">
                           <ItemTemplate>
                               <asp:Label ID="Lbldri" runat="server" Text='<%# Bind("drivername") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Deiver Name">
                           <ItemTemplate>
                               <asp:Label ID="Lblceh" runat="server" Text='<%# Bind("vehicle") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Mobaile">
                           <ItemTemplate>
                               <asp:Label ID="Lblcon" runat="server" Text='<%# Bind("contact") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Destination">
                           <ItemTemplate>
                               <asp:Label ID="Lblsup" runat="server" Text='<%# Bind("supplier") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Out type">
                           <ItemTemplate>
                               <asp:Label ID="Lblloc" runat="server" Text='<%# Bind("location") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Scale Id">
                           <ItemTemplate>
                               <asp:Label ID="Lblsca" runat="server" Text='<%# Bind("scaleid") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="G weight">
                           <ItemTemplate>
                               <asp:Label ID="Lblgwe" runat="server" Text='<%# Bind("grossweight") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Net Weight">
                           <ItemTemplate>
                               <asp:Label ID="Lblnet" runat="server" Text='<%# Bind("netweight") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                   </Columns>
               </asp:GridView>
           </td>
       </tr>





    </table>





                 
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

