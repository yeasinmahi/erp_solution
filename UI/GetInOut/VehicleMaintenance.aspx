<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleMaintenance.aspx.cs" Inherits="UI.GetInOut.VehicleMaintenance" %>

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
                
    <div class="tabs_container" align="Center">Estimation From</div>
     <br>
         <br />
          <table>
             <tr>
              <td style="text-align:right;"><asp:Label ID="LblAssettype" runat="server" CssClass="lbl" Text="Asset Number :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtAssetnumber" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 

            </tr>
             <tr>
                 
                  <td style="text-align:right;"><asp:Label ID="LblVehicleReg" runat="server" CssClass="lbl" Text="Vehicle Reg No :"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlVehicle" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                    </asp:DropDownList> 

                 <td style="text-align:right;"><asp:Label ID="LblJobEntranceDte" runat="server" CssClass="lbl" Text="Job Entrance Date:"></asp:Label></td>
               <td><asp:TextBox ID="txtDteJobEntrance" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
               <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteJobEntrance"></cc1:CalendarExtender> </td>                                                       
        
       

             </tr>
             <tr>
                  <td style="text-align:right;"><asp:Label ID="LblNature" runat="server" CssClass="lbl" Text="Nature Of Vehicle :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtNature" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 
 
                  <td style="text-align:right;"><asp:Label ID="LblDeliveryDate" runat="server" CssClass="lbl" Text="Delivery Date:"></asp:Label></td>
        <td><asp:TextBox ID="TxtdteDelivery" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteDelivery"></cc1:CalendarExtender> 

             </tr>
             <tr>
                  <td style="text-align:right;"><asp:Label ID="LblModel" runat="server" CssClass="lbl" Text="Model & CC :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtModel" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 

                  <td style="text-align:right;"><asp:Label ID="LblPercentageMilege" runat="server" CssClass="lbl" Text="Percentage Milage :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtMielage" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 

             </tr>
             <tr>
                <td style="text-align:right;"><asp:Label ID="LblCompany" runat="server" CssClass="lbl" Text="Company Name :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtCompany" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 
                  
                 <td style="text-align:right;"><asp:Label ID="LblNextMilage" runat="server" CssClass="lbl" Text="Next Milage :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtNextMilage" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 

             </tr>
             <tr>
                  <td style="text-align:right;"><asp:Label ID="LblNameofuser" runat="server" CssClass="lbl" Text="Name Of User :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtNameOfUser" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 

             </tr>
             <tr>
                  <td style="text-align:right;"><asp:Label ID="LblPresetproblem" runat="server" CssClass="lbl" Text="Present Problem of vehicle :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtPresentProblem" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 

             </tr>
           </table>
          <div class="tabs_container" align="Center">Description of Necessary From</div>
         <table>
             <tr>
                    <td style="text-align:right;"><asp:Label ID="LblDteSpare" Forcolor="#00FF00" runat="server" CssClass="lbl" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" Text="Date:"></asp:Label></td>
               <td><asp:TextBox ID="TxtDteSpare" runat="server" CssClass="txtBox"></asp:TextBox>
               <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteSpare"></cc1:CalendarExtender> </td>                                                       
        
                 
                  <td style="text-align:right;"><asp:Label ID="LblParticularParts" Forcolor="#00FF00" runat="server" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" CssClass="lbl" Text="Particulers (Spare Parts) :"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlParticularParts" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                      <asp:ListItem>Employee</asp:ListItem>
                     <asp:ListItem>Supplier</asp:ListItem>
                     <asp:ListItem>Customer</asp:ListItem>
                     <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList> 

                 <td style="text-align:right;"><asp:Label ID="LblUom" runat="server" Forcolor="#00FF00" CssClass="lbl" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" Text="UOM :"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlUom" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                          <asp:ListItem>Employee</asp:ListItem>
                     <asp:ListItem>Supplier</asp:ListItem>
                     <asp:ListItem>Customer</asp:ListItem>
                     <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList> 

                
             </tr>

             <tr>
                   <td style="text-align:right;"><asp:Label ID="LblQty" runat="server"   CssClass="lbl" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" Text="Qty :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtQty" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 
                       
                  <td style="text-align:right;"><asp:Label ID="LblMaterialCost" runat="server" CssClass="lbl" Text="Material Cost :" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtMaterialCost" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 
                   <td><asp:Button ID="BtnSpare" runat="server" Text="Add" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" OnClick="BtnSpare_Click" /></td>

             </tr>
             </table>
         <table>
             <tr>
                 <td colspan="5">
<asp:GridView ID="GridView1" runat="server" Width="650" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Date" ItemStyle-Width="100" >
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("datespare") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Spare" ItemStyle-Width="450">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server"  Text='<%# Bind("ddlspare") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Uom" ItemStyle-Width="60">
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server"  Text='<%# Bind("uom") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Qty" ItemStyle-Width="90">
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cost" ItemStyle-Width="100">
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" Text='<%# Bind("mcost") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
                     </asp:GridView>
                 </td>
                 
             </tr>
         </table> 
         <table>
         <div class="tabs_container" align="Center"> 
             <caption>
                 Description of Service Charge</caption>
             </div>
         <table>
             <tr>
                  <td style="text-align:right;"><asp:Label ID="LblServiceCharge" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" runat="server" CssClass="lbl" Text="Particulars (service Charge) :"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlServiceCharge" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                      <asp:ListItem>Employee</asp:ListItem>
                     <asp:ListItem>Supplier</asp:ListItem>
                     <asp:ListItem>Customer</asp:ListItem>
                     <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList> 

                  <td style="text-align:right;"><asp:Label ID="LblChargeTk" runat="server" CssClass="lbl" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small" Text="Service Charge Taka :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="TxtChargeTk" CssClass="Textbox" Font-Bold="False" runat="server" ></asp:Textbox> 
               <td><asp:Button ID="BtnService" runat="server" Text="Add" BorderStyle="NotSet" ForeColor="#00CC00" Font-Size="small"  OnClick="BtnService_Click" /></td>


             </tr>
             </table>
             <tabl>
              <tr>
                 <td>
<asp:GridView ID="GridView2" runat="server" width="650px" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Service" ItemStyle-Width="450" >
            <ItemTemplate >
                <asp:Label ID="Label6"  runat="server" Text='<%# Bind("scharge") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ChargeTK"  ItemStyle-Width="250" >
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server" Text='<%# Bind("charge") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
                     </asp:GridView>
                 </td>
                 
             </tr>
         </table>



         <tr>
         </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
