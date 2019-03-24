<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetPlanning_Requesition.aspx.cs" Inherits="UI.BudgetPlan.BudgetPlanning_Requesition" %>



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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
    <script >
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
    
     <script>
         function DetalisView(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
         function Registration(url) {
             window.location.href("BudgetDetalis_UI.aspx")
         }

         function Userview(url) {
             window.location.href("BudgetStatusViewDetalis.aspx")
         }
         function nonoperation(url) {
             window.location.href("BudgetNonOperatonStatusDetalis.aspx")
         }

      
       
         </script>
    <script type="text/javascript">
        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        }

        function ClosehdnDivision() {
           
           $("#hdnDivision").fadeOut("slow"); 
        }
    </script>
    <style type="text/css"> 
        .rounds {
            height: 50px;
            width: 50px;
           -moz-border-colors:25px;
         border-radius:25px;
 } 


         .HyperLinkButtonStyle { float:left; text-align:left; border: none; background: none; 
    color: blue; text-decoration: underline; font: normal 10px verdana;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:10%; height: 10%; margin-left:auto; margin-right:auto; padding: 20px; overflow-y:scroll; }
    </style>



    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
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
      <td><asp:HiddenField ID="hdn1" runat="server" /><asp:HiddenField ID="hdn2" runat="server" /><asp:HiddenField ID="hdn3" runat="server" />
       <asp:HiddenField ID="hdn4" runat="server" /><asp:HiddenField ID="hdn5" runat="server" /><asp:HiddenField ID="hdn6" runat="server" />
      <asp:HiddenField ID="hdn7" runat="server" /><asp:HiddenField ID="hdn8" runat="server" /><asp:HiddenField ID="hdn9" runat="server" />
       <asp:HiddenField ID="hdn10" runat="server" /><asp:HiddenField ID="hdnOpID" runat="server" /><asp:HiddenField ID="hdnOpName" runat="server" />
    
    <div class="tabs_container" align="center" >Budget Planning Requesition Form </div>
    <div class="leaveApplication_container">
           <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top" class="tblrowodd">
              <tr>
                  
                <td>  <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Click" Text="0"></asp:LinkButton>
               <asp:LinkButton ID="LinkButton2" runat="server" OnCommand="LinkButton2_Click" Text=""></asp:LinkButton>
               <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="LinkButton3_Click" Text=""></asp:LinkButton>
                      <asp:LinkButton ID="LinkButton4" runat="server" OnCommand="LinkButton4_Click" Text=""></asp:LinkButton>
               <asp:LinkButton ID="LinkButton5" runat="server" OnCommand="LinkButton5_Click" Text=""></asp:LinkButton>
               <asp:LinkButton ID="LinkButton6" runat="server" OnCommand="LinkButton6_Click" Text=""></asp:LinkButton>
             
             </td>
              </tr>
               <tr>
                   <td>
              <asp:LinkButton ID="LinkButton7" runat="server" OnCommand="LinkButton7_Click" Text=""></asp:LinkButton>
               <asp:LinkButton ID="LinkButton8" runat="server" OnCommand="LinkButton8_Click" Text=""></asp:LinkButton>
                       <asp:LinkButton ID="LinkButton9" runat="server" OnCommand="LinkButton9_Click" Text=""></asp:LinkButton>
               
               <asp:LinkButton ID="LinkButton10" runat="server" OnCommand="LinkButton10_Click" ></asp:LinkButton>
            
               </td>
                   </tr>
              
                 </table>
        <table>
                   <tr class="tblrowodd">
                       <td >
                           Project/Operation-:</td>
                     
                         <td ><strong>
                             <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="58px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="308px"></asp:ListBox>
                             </strong></td>
                   
                    <td style="text-align:right;"><asp:Button ID="BtnAddParent"  Font-Bold="true" Font-Size="Small" AutoPostback="true"  runat="server" Text="Add" OnClick="BtnAddParent_Click" ToolTip="Add Project or Operation"  />
                     </td>
                       
                           
                   </tr>
                   </table>
                    <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top" >
                    <tr>
                         <td>
                           <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="Op" AutoPostBack="true" Text="Project"  />
                       </td>
                       <td>
                           <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Op"  AutoPostBack="true"  Text="Operation" />
                       </td>
                    </tr>
                   <tr class="tblrowodd">
                       <td style="text-align:right;">
                           <asp:Label ID="Label15" runat="server" CssClass="lbl" font-size="small" Text="Operation/Project -:"></asp:Label>
                       </td>
                       <td style="text-align: left;">
                           <asp:DropDownList ID="ddlOperation" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="False" >
                           </asp:DropDownList>
                       </td>
                       <td>
                           <asp:RadioButton ID="OperationID" runat="server" AutoPostBack="true" Text="Operation" OnCheckedChanged="OperationID_CheckedChanged"  />
                       </td>
                       <td>
                           <asp:RadioButton ID="NonOperationID" runat="server" AutoPostBack="true" OnCheckedChanged="NonOperationID_CheckedChanged" Text="non Operation" />
                       </td>
                   </tr>
                   <tr>
                       <td style="text-align:right;">
                           <asp:Label ID="Label2" runat="server" CssClass="lbl" font-size="small" Text="Name of Type-:"></asp:Label>
                       </td>
                       <td style="text-align: left;">
                           <asp:DropDownList ID="DdlOpName" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="False">
                               <asp:ListItem Value="1">Supplies(Item)</asp:ListItem>
                               <asp:ListItem Value="2">Employee(Personal)</asp:ListItem>
                               <asp:ListItem Value="3">FixedAsset(Equipments)</asp:ListItem>
                               <asp:ListItem Value="4">Expanse</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td>
                           <asp:RadioButton ID="OpexID" runat="server" AutoPostBack="true" OnCheckedChanged="OpexID_CheckedChanged" Text="Opex" />
                       </td>
                       <td>
                           <asp:RadioButton ID="CapexID" runat="server" AutoPostBack="true" OnCheckedChanged="CapexID_CheckedChanged" Text="Capex" />
                       </td>
                       <tr>
                           <td style="text-align:right;">
                               <asp:Label ID="Label3" runat="server" CssClass="lbl" font-size="small" Text="Approx Amount"></asp:Label>
                           </td>
                           <td style="text-align:left;">
                               <asp:TextBox ID="TxtAmount" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                               <td style="text-align:right;">
                                   <asp:Label ID="Label4" runat="server" CssClass="lbl" font-size="small" Text="Cost Center Name -:"></asp:Label>
                               </td>
                               <td style="text-align: left;">
                                   <asp:DropDownList ID="DdlCostCenter" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="False">
                                   </asp:DropDownList>
                               </td>
                           </td>
                       </tr>
                       <tr>
                           <td></td>
                           <td></td>
                           <td></td>
                           <td>
                               <asp:Button ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" Text="ADD" />
                               <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Submit" />
                           </td>
                       </tr>
                   </tr>
              
           </table>
         
          <table>
              <caption> 
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="lblCaption" runat="server" Font-Bold="true" Font-Size="Medium" ></asp:Label>
                </td>
                <tr>
                    <td>
                        <asp:GridView ID="dgvbudget" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvbudget_RowDeleting" OnRowEditing="dgvbudget_RowEditing" OnRowCancelingEdit="dgvbudget_RowCancelingEdit" OnRowUpdating="dgvbudget_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.N">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" HeaderText="Update" />
                                <asp:TemplateField HeaderText="CostCenter">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblcostcenter" runat="server" Text='<%# Bind("costcenter") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="CostCenterID">
                                    <ItemTemplate>
                                        <asp:Label ID="LblcostcenterID" Visible="false" runat="server" Text='<%# Bind("costcenter") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operation Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LbloOpnames" runat="server" Text='<%# Bind("opname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opeid" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblopnameid" runat="server" Text='<%# Bind("opnameid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Operation Type">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbloptype" runat="server" Text='<%# Bind("optype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NameType">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblnmaetype" runat="server" autopostback="true" Text='<%# Bind("nmaetype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="NameTypeID"  Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="LblnmaetypeID" runat="server" autopostback="true" Text='<%# Bind("nametypeid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblopex" runat="server" autopostback="true" Text='<%# Bind("opex") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                
                               
                                <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FYear" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFyear" runat="server" Text='<%# Bind("fyear") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="TYear" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTyear" runat="server" Text='<%# Bind("toyear") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="July">
                                    <ItemTemplate>
                                       <asp:Label ID="lbljulyr" runat="server" Text='<%# Bind("july") %>'></asp:Label>
                                    </ItemTemplate>
                                      <EditItemTemplate><asp:TextBox ID="txtjuly" Width="75px" runat="server" Text='<%# Bind("july") %>'></asp:TextBox></EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aug">
                                    <ItemTemplate>
                                        <asp:Label ID="lblaug" runat="server" Text='<%# Bind("agust") %>'></asp:Label>
                                    </ItemTemplate>
                                      <EditItemTemplate><asp:TextBox ID="txtaug" Width="75px" runat="server" Text='<%# Bind("agust") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sep">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsep" runat="server" Text='<%# Bind("sep") %>'></asp:Label>
                                    </ItemTemplate>
                                      <EditItemTemplate><asp:TextBox ID="txtsep" Width="75px" runat="server" Text='<%# Bind("sep") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Oct">
                                    <ItemTemplate>
                                       <asp:Label ID="lbloct" runat="server" Text='<%# Bind("oct") %>'></asp:Label>
                                    </ItemTemplate>
                              <EditItemTemplate><asp:TextBox ID="txtoct" Width="75px" runat="server" Text='<%# Bind("oct") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nov">
                                    <ItemTemplate>
                                   <asp:Label ID="lblnov" runat="server" Text='<%# Bind("nov") %>'></asp:Label>
                                    </ItemTemplate>
                                  <EditItemTemplate><asp:TextBox ID="txtnov" Width="75px" runat="server" Text='<%# Bind("nov") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dec">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldec" runat="server" Text='<%# Bind("dec") %>'></asp:Label>
                                    </ItemTemplate>
                                  <EditItemTemplate><asp:TextBox ID="txtdec" Width="75px" runat="server" Text='<%# Bind("dec") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jan">
                                    <ItemTemplate>
                                         <asp:Label ID="lbljan" runat="server" Text='<%# Bind("jan") %>'></asp:Label>
                                    </ItemTemplate>
                                  <EditItemTemplate><asp:TextBox ID="txtjan" Width="75px" runat="server" Text='<%# Bind("jan") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Feb">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeb" runat="server" Text='<%# Bind("feb") %>'></asp:Label>
                                    </ItemTemplate>
                                  <EditItemTemplate><asp:TextBox ID="txtfeb" Width="75px" runat="server" Text='<%# Bind("feb") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mar">
                                    <ItemTemplate>
                                         <asp:Label ID="lblmar" runat="server" Text='<%# Bind("march") %>'></asp:Label>
                                    </ItemTemplate>
                              <EditItemTemplate><asp:TextBox ID="txtmar" Width="75px" runat="server" Text='<%# Bind("march") %>'></asp:TextBox></EditItemTemplate>
                         

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Appril">
                                    <ItemTemplate>
                                       <asp:Label ID="lblapr" runat="server" Text='<%# Bind("april") %>'></asp:Label>
                                    </ItemTemplate>
                                  <EditItemTemplate><asp:TextBox ID="txtapril" Width="75px" runat="server" Text='<%# Bind("april") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="May">
                                    <ItemTemplate>
                                     <asp:Label ID="lblmay" runat="server" Text='<%# Bind("may") %>'></asp:Label>
                                    </ItemTemplate>
                                      <EditItemTemplate><asp:TextBox ID="txtmay" Width="75px" runat="server" Text='<%# Bind("may") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jun">
                                    <ItemTemplate>
                                         <asp:Label ID="lbljun" runat="server" Text='<%# Bind("jun") %>'></asp:Label>
                                    </ItemTemplate>
                                      <EditItemTemplate><asp:TextBox ID="txtjun" Width="75px" runat="server" Text='<%# Bind("jun") %>'></asp:TextBox></EditItemTemplate>
                         
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="Clear" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </tr>
             </caption>
           </table>

            <table>
              <caption> 
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label9" runat="server" Font-Bold="true" Font-Size="Medium" ></asp:Label>
                </td>
                <tr>
                    <td>
                        <asp:GridView ID="dgvnonOperation" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvnonOperation_RowDeleting" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.N">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CostCenter">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblcostcenter" runat="server" Text='<%# Bind("costcenter") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="CostCenterID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblcostcenterID" Visible="false" runat="server" Text='<%# Bind("costcenter") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Operation Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LbloOpnames" runat="server" Text='<%# Bind("opname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Opeid" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblopnameid" runat="server" Text='<%# Bind("opnameid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Operation Type">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbloptype" runat="server" Text='<%# Bind("optype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NameType">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblnmaetype" runat="server" autopostback="true" Text='<%# Bind("nmaetype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="NameTypeID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="LblnmaetypeID" runat="server" autopostback="true" Text='<%# Bind("nametypeid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblopex" runat="server" autopostback="true" Text='<%# Bind("opex") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                              
                               
                                <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:CommandField HeaderText="Clear" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </tr>
             </caption>
           </table>
           <table>
              <caption> 
            <tr>
                <td style="text-align:left;">
                    <asp:Label ID="Label6" runat="server" Font-Bold="true" Font-Size="Medium" ></asp:Label>
                </td>
                <tr>
                    <td>
                        <asp:GridView ID="dgvUser" runat="server" AutoGenerateColumns="False" >
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.N">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="LblintID" runat="server" Text='<%# Bind("intID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CostCenter">
                                    <ItemTemplate>
                                        <asp:Label ID="Lblcostcenter" runat="server" Text='<%# Bind("strCCName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Operation Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LbloOpnames" runat="server" Text='<%# Bind("strProjectName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                               
                               
                                <asp:TemplateField HeaderText="Operation Type">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbloptype" runat="server" Text='<%# Bind("strType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("monTotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Detalis">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDetalis" runat="server" Text="Detalis" CommandName="Detalis"  CommandArgument='<%# Eval("intID")%>' OnClick="btnDetalis_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </tr>
             </caption>
           </table>
        </div>
        <div class="leaveSummary_container"> 
        <div class="tabs_container">Operation Summary :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:BoundField DataField="intID" HeaderText="ID" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="intID">
        <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:BoundField>
         
        <asp:BoundField DataField="strProjectName" HeaderText="Operation/Project" ItemStyle-HorizontalAlign="Center" SortExpression="strProjectName">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
          
            <asp:BoundField DataField="monTotalAmount" HeaderText="Total Amount" SortExpression="monTotalAmount" />
                         
            <asp:TemplateField HeaderText="Detalis"><ItemTemplate>
        <asp:Button ID="btnUserDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("intID") %>' Text="Details" OnClick="btnUserDetails_Click"   />
        </ItemTemplate><ItemStyle HorizontalAlign="Left" />

            </asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
       
    </div>

    <div id="hdnDivision" class="hdnDivision" style="width:auto;">
    <table style="width:auto; float:left; " >
        <tr>
            <td></td>
        </tr>
    <tr class="tblrowodd">
   
    <td style="text-align:right;"><asp:Label ID="lbldoc" CssClass="lbl" runat="server" Text="Name : "></asp:Label></td>
 
   <td style="text-align:left;"> <asp:TextBox ID="Txtname" Width="200" runat="server"></asp:TextBox></td>
    </tr>
  <tr class="tblrowodd"><td></td>
     <td style="text-align:left;"> <asp:Button ID="btnSaves" runat="server" BackColor="GreenYellow"  OnClick="BtnSaves_Click" Text="Save" />
        <asp:Button ID="btnCancel" runat="server"  OnClick="BtnCancel_Click" BackColor="GreenYellow" Text="Cancel" /></td>
     
      </tr>
       <tr>
           <td></td>
       </tr>
    </table>
    </div>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
