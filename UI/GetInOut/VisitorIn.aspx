<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorIn.aspx.cs" Inherits="UI.GetInOut.VisitorIn" %>

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
        .ddList {}
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
                
    <div class="tabs_container" align="Center">Vissitor IN Out</div>
     <br>
         <br />
    <table>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Lblname" runat="server" CssClass="lbl" Text="Name :"></asp:Label></td>
             <td style="text-align:left;" ><asp:Textbox ID="Txtname" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

        <td style="text-align:right;"><asp:Label ID="Lbltype" runat="server" CssClass="lbl" Text="VisitorType :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:DropDownList ID="Ddltype" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                     <asp:ListItem>Employee</asp:ListItem>
                     <asp:ListItem>Supplier</asp:ListItem>
                     <asp:ListItem>Customer</asp:ListItem>
                     <asp:ListItem>Others</asp:ListItem>
                     </asp:DropDownList> 


        <td style="text-align:right;"><asp:Label ID="Lblenroll" runat="server" CssClass="lbl" Text="Enroll Number :"></asp:Label></td>
          <td style="text-align:left;" ><asp:Textbox ID="Txtenroll" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>

            

          
        
        </tr>

       <tr>
             

           <td style="text-align:right;"><asp:Label ID="Lblcontact" runat="server" CssClass="lbl" Text="Contact Number :"></asp:Label></td>
          <td style="text-align:left;" ><asp:Textbox ID="Txtcontact" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 
           <td style="text-align:right;"><asp:Label ID="Lblwhere" runat="server" CssClass="lbl" Text="From Where :"></asp:Label></td>
           <td style="text-align:left;" ><asp:Textbox ID="Txtwhere" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

          <td style="text-align:right;"><asp:Label ID="Lblobjective" runat="server" CssClass="lbl" Text="Objective :"></asp:Label></td>
          <td style="text-align:left;" ><asp:Textbox ID="Txtobjective" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
               
           
       </tr>
        <tr>
       
         
           <td style="text-align:right;"><asp:Label ID="Lbltransporttype" runat="server" CssClass="lbl" Text="Transport Type :"></asp:Label></td>
                 <td style="text-align:right;" ><asp:DropDownList ID="Ddltransport" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="Ddltransport_SelectedIndexChanged" > 
                     <asp:ListItem>By Road</asp:ListItem>
                     <asp:ListItem>Vehicle</asp:ListItem>
                    
                     </asp:DropDownList> 


        <td style="text-align:right;"><asp:Label ID="Lblarea" runat="server" CssClass="lbl" Text="Visited Area:"></asp:Label></td>
        <td style="text-align:left;" ><asp:Textbox ID="Txtarea" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
    
        <td style="text-align:right;"><asp:Label ID="Lblcontactperson" runat="server" CssClass="lbl" Text="Contact person :"></asp:Label></td>
          <td style="text-align:left;" ><asp:Textbox ID="Txtcontactperson" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>       

        </tr>
        <tr>
             <td style="text-align:right;"><asp:Label ID="Lblvehicle" runat="server" CssClass="lbl" Text="Vehicle No :"></asp:Label></td>
            <td style="text-align:left;" ><asp:Textbox ID="Txtvehicle" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

          <td colspan="4" style="text-align:right;"> <asp:Button ID="btnsave" runat="server" CssClass="nextclick" Text="Save" OnClick="btnsave_Click"/></td>

        </tr>
        <tr>
            <td colspan="5"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting">
                <Columns>

                    <asp:TemplateField HeaderText="Visitor ID"><ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("intId") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("strName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("strType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Number">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("strContact") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("strarea") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Person">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("strContactPerson") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField DeleteText="OUT" HeaderText="Submit" ShowDeleteButton="True" />
                </Columns>
                </asp:GridView></td>
         
        </tr>
    </table>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

