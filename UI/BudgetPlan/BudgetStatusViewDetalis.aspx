<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetStatusViewDetalis.aspx.cs" Inherits="UI.BudgetPlan.BudgetStatusViewDetalis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
    .Initial
{
  display: block;
  padding: 4px 18px 4px 18px;
  float: left;
  background: url("../Images/InitialImage.png") no-repeat right top;
  color: Black;
  font-weight: bold;
}
     .Initial:hover
     {
  color:blue;
  background:#eeeeee;
   }
     .Clicked
     {
  float: left;
  display: block;
  background:padding-box;
  padding: 4px 18px 4px 18px;
  color: Black;
  font-weight: bold;
  color:Green;
}
</style>

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 139px;
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
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <%--<div class="tabs_container" align="Center" >Maintenance Service Report </div>--%>
                  <table>
                    <tr>
                        <td style="text-align:left;"><asp:Button ID="BtnClose" BackColor="YellowGreen" runat="server" Text="Back" OnClick="BtnClose_Click"    />
                    </tr>
                      <tr>
                      <td style="text-align:left;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Medium" ></asp:Label>
                    </td>
                          </tr>
                     <caption> <td style="text-align:left;">Operation of Project Cost</td>
                   
                    <tr>
                    <td>
                    <asp:GridView ID="dgvOperation" runat="server" AutoGenerateColumns="False" >
                    <Columns>
                    <asp:TemplateField HeaderText="Sl.N">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CostCenter">
                        <ItemTemplate>
                            <asp:Label ID="Lblcostcenterd" runat="server" Text='<%# Bind("strCCName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                       
                    
                    
                    <asp:TemplateField HeaderText="Operation/Project">
                        <ItemTemplate>
                            <asp:Label ID="Lblopsubname" runat="server" Text='<%# Bind("strProjectName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                      
                    <asp:TemplateField HeaderText="Operation Type">
                        <ItemTemplate>
                            <asp:Label ID="Lbloptype" runat="server" Text='<%# Bind("Operation") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                       
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="Lblopex" runat="server" autopostback="true" Text='<%# Bind("strType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                               
                                
                               
                    <asp:TemplateField HeaderText="Total Amount">
                        <ItemTemplate>
                            <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("monTotalAmount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="July">
                        <ItemTemplate>
                            <asp:Label ID="lbljulyrs" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtjulys" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aug">
                        <ItemTemplate>
                            <asp:Label ID="lblaugs" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtaugs" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sep">
                        <ItemTemplate>
                            <asp:Label ID="lblseps" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtseps" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Oct">
                        <ItemTemplate>
                            <asp:Label ID="lblocst" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtocts" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nov">
                        <ItemTemplate>
                        <asp:Label ID="lblnovs" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtnovs" Width="75px" runat="server" Text='<%# Bind("dts") %>' DataFormatString="{0:n}"></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dec">
                        <ItemTemplate>
                            <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("dts") %>' DataFormatString="{0:n}"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtdecs" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jan">
                        <ItemTemplate>
                                <asp:Label ID="lbljans" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtjans" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Feb">
                        <ItemTemplate>
                            <asp:Label ID="lblfebs" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtfebs" Width="75px" runat="server" Text='<%# Bind("feb") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mar">
                        <ItemTemplate>
                                <asp:Label ID="lblmars" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtmars" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apr">
                        <ItemTemplate>
                            <asp:Label ID="lblaprs" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtapsril" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="May">
                        <ItemTemplate>
                            <asp:Label ID="lblmays" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtmasy" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jun">
                        <ItemTemplate>
                                <asp:Label ID="lbljuns" runat="server" Text='<%# Bind("dts") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtjuns" Width="75px" runat="server" Text='<%# Bind("dts") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    
                    </caption>
                    </table>   

                    <table>
                    <caption> <td style="text-align:left;">Chart of Project Cost</td>
                    <tr>
                    <td style="text-align:left;">
                    <asp:Label ID="lblCaption" runat="server" Font-Bold="true" Font-Size="Medium" ></asp:Label>
                    </td>
                    <tr>
                    <td>
                    <asp:GridView ID="dgvCostingsector" runat="server" AutoGenerateColumns="False" >
                    <Columns>
                    <asp:TemplateField HeaderText="Sl.N">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CostCenter">
                        <ItemTemplate>
                            <asp:Label ID="Lblcostcenter" runat="server" Text='<%# Bind("strCCName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                        
                    
                   
                    <asp:TemplateField HeaderText="Operation/Project" >
                        <ItemTemplate>
                            <asp:Label ID="Lblopsubname" runat="server" Text='<%# Bind("strProjectName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                      
                    <asp:TemplateField HeaderText="Operation Type">
                        <ItemTemplate>
                            <asp:Label ID="Lbloptype" runat="server" Text='<%# Bind("strType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NameType">
                        <ItemTemplate>
                            <asp:Label ID="Lblnmaetype" runat="server" autopostback="true" Text='<%# Bind("dd") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      
                   
                               
                                
                               
                    <asp:TemplateField HeaderText="Total Amount">
                        <ItemTemplate>
                            <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Year" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblFyear" runat="server" Text='<%# Bind("years") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       
                    <asp:TemplateField HeaderText="July">
                        <ItemTemplate>
                            <asp:Label ID="lbljulyr" runat="server" Text='<%# Bind("monJuly") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtjuly" Width="75px" runat="server" Text='<%# Bind("monJuly") %>'></asp:TextBox></EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aug">
                        <ItemTemplate>
                            <asp:Label ID="lblaug" runat="server" Text='<%# Bind("monAug") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtaug" Width="75px" runat="server" Text='<%# Bind("monAug") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sep">
                        <ItemTemplate>
                            <asp:Label ID="lblsep" runat="server" Text='<%# Bind("monSep") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtsep" Width="75px" runat="server" Text='<%# Bind("monSep") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Oct">
                        <ItemTemplate>
                            <asp:Label ID="lbloct" runat="server" Text='<%# Bind("monOct") %>'></asp:Label>
                        </ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtoct" Width="75px" runat="server" Text='<%# Bind("monOct") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nov">
                        <ItemTemplate>
                        <asp:Label ID="lblnov" runat="server" Text='<%# Bind("monNov") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtnov" Width="75px" runat="server" Text='<%# Bind("monNov") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dec">
                        <ItemTemplate>
                            <asp:Label ID="lbldec" runat="server" Text='<%# Bind("monDec") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtdec" Width="75px" runat="server" Text='<%# Bind("monDec") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jan">
                        <ItemTemplate>
                                <asp:Label ID="lbljan" runat="server" Text='<%# Bind("monJan") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtjan" Width="75px" runat="server" Text='<%# Bind("monJan") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Feb">
                        <ItemTemplate>
                            <asp:Label ID="lblfeb" runat="server" Text='<%# Bind("monFeb") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtfeb" Width="75px" runat="server" Text='<%# Bind("monFeb") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mar">
                        <ItemTemplate>
                                <asp:Label ID="lblmar" runat="server" Text='<%# Bind("monMar") %>'></asp:Label>
                        </ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtmar" Width="75px" runat="server" Text='<%# Bind("monMar") %>'></asp:TextBox></EditItemTemplate>
                         

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Appril">
                        <ItemTemplate>
                            <asp:Label ID="lblapr" runat="server" Text='<%# Bind("monApr") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate><asp:TextBox ID="txtapril" Width="75px" runat="server" Text='<%# Bind("monApr") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="May">
                        <ItemTemplate>
                            <asp:Label ID="lblmay" runat="server" Text='<%# Bind("monMay") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtmay" Width="75px" runat="server" Text='<%# Bind("monMay") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jun">
                        <ItemTemplate>
                                <asp:Label ID="lbljun" runat="server" Text='<%# Bind("monJun") %>'></asp:Label>
                        </ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="txtjun" Width="75px" runat="server" Text='<%# Bind("monJun") %>'></asp:TextBox></EditItemTemplate>
                         
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    </td>
                    </tr>
                    </tr>
                    </caption>
                    </table>      
              
                      
                  
          
          
         
          <div class="leaveSummary_container"> 
        <div class="tabs_container">Items Detalis Summary :<hr /></div> 
              
                  <asp:GridView ID="dgvItems" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="strItems" HeaderText="Items Name" SortExpression="strItems" />
                          <asp:BoundField DataField="monQty" HeaderText="Qty" SortExpression="monQty" />
                           <asp:BoundField DataField="new" HeaderText="Status" SortExpression="new" />
                          <asp:BoundField DataField="strRemarks" HeaderText="Remarks" SortExpression="strRemarks" />
                      </Columns>
                      </asp:GridView>
                  
          </div>
         
        <div class="leaveSummary_container"> 
        <div class="tabs_container">Employee Work Summary :<hr /></div> 
              
                  <asp:GridView ID="DgvPerformer" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="strEmployeeName" HeaderText="EmpName" SortExpression="strEmployeeName" />
                          <asp:BoundField DataField="strRemarks" HeaderText="Remarks" SortExpression="strRemarks" />
                           <asp:BoundField DataField="new" HeaderText="status" SortExpression="new" />
                       
                      </Columns>
                      </asp:GridView>
                  
          </div>

          <div class="leaveSummary_container"> 
        <div class="tabs_container">Tools & Equipments Summary :<hr /></div> 
              
                  <asp:GridView ID="dgvTools" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="strEquipmentsName" HeaderText="ToolsName" SortExpression="strEquipmentsName" />
                          <asp:BoundField DataField="monQty" HeaderText="Qty" SortExpression="monQty" />
                          <asp:BoundField DataField="new" HeaderText="status" SortExpression="new" />
                      </Columns>
                      </asp:GridView>
                  
          </div>
          <div class="leaveSummary_container"> 
        <div class="tabs_container">Expance Summary :<hr /></div> 
              
                  <asp:GridView ID="dgvExpance" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="strExpanceName" HeaderText="ExpanceName" SortExpression="strExpanceName" />
                          <asp:BoundField DataField="monAmount" HeaderText="Expance" SortExpression="monAmount" />
                          <asp:BoundField DataField="strRemarks" HeaderText="Remarks" SortExpression="strRemarks" />
                      </Columns>
                      </asp:GridView>
                  
          </div>
         
         
         
          
        
         
            
<%--=========================================End My Code From Here=================================================--%>
       
    </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>


