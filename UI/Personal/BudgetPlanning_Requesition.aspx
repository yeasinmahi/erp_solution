<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetPlanning_Requesition.aspx.cs" Inherits="UI.Personal.BudgetPlanning_Requesition" %>



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
       
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtPartsSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "IssueAssetMaintenance.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtPartsSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }

    </script>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
         </script> 
   
   

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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center" >Budget Requesition From </div>
   
           <table style="width:750px; outline-color:blue;table-layout:auto;vertical-align: top" class="tblrowodd" >
             <tr  class="tblrowodd">
                  <td style="text-align:right;"> <asp:Label ID="Label8" font-size="small" runat="server" CssClass="lbl" Text="Select Operation -:"></asp:Label></td>
    
                  <td>
                      <asp:RadioButton ID="RadioButton3" Text="Exixting" runat="server" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged" />
                   
                      <asp:RadioButton ID="RadioButton4" Text="NewItem Name" runat="server" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged" />

                  </td>   

           
       
                 <td style="text-align:right;"> <asp:Label ID="Label5"  ForeColor="Green" font-size="small" runat="server" CssClass="lbl" ></asp:Label></td>
                 </tr>
               
               
                <tr  class="tblrowodd">
                  <td style="text-align:right;"> <asp:Label ID="Label1" font-size="small" runat="server" CssClass="lbl" Text="Name of Operation -:"></asp:Label></td>
    
       <td style="text-align:left;"> <asp:TextBox ID="TxtOperationName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
         
           
       </td>

                  <td>
                      <asp:RadioButton ID="OperationID" Text="Operation" runat="server" AutoPostBack="true" OnCheckedChanged="OperationID_CheckedChanged" /></td>
                  <td>
                      <asp:RadioButton ID="NonOperationID" Text="non Operation" runat="server" AutoPostBack="true" OnCheckedChanged="NonOperationID_CheckedChanged" />

                  </td>
                    </tr>
               <tr>
                         <td style="text-align:right;"> <asp:Label ID="Label2" font-size="small" runat="server" CssClass="lbl" Text="Name of Type-:"></asp:Label></td>
    
       <td style="text-align: left;">
                     <asp:DropDownList ID="DdlOpName" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True">
                      <asp:ListItem>Employee</asp:ListItem>
                     <asp:ListItem>Supplyer</asp:ListItem>
                         <asp:ListItem>Equipments</asp:ListItem>
                         <asp:ListItem>Expanse</asp:ListItem>
                   
                     </asp:DropDownList>

           
       </td>  
                  <td>
                      <asp:RadioButton ID="OpexID" Text="Opex" runat="server" AutoPostBack="true" OnCheckedChanged="OpexID_CheckedChanged" /></td>
                      <td><asp:RadioButton ID="CapexID" Text="Capex" runat="server" AutoPostBack="true" OnCheckedChanged="CapexID_CheckedChanged" />

                  </td
               </tr>
               <tr>
            <td style="text-align:right;"> <asp:Label ID="Label6" font-size="small" runat="server" CssClass="lbl" Text="Name:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="Txtname" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                   <td>
                      <asp:RadioButton ID="RadioButton1" Text="Exixting" runat="server" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged" /></td>
                   <td>
                      <asp:RadioButton ID="RadioButton2" Text="NewItem Name" runat="server" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged" />

                  </td>
                  
                   <td>

                   </td>
               </tr>
               <tr>
                   
         
              <td style="text-align:right;"> <asp:Label ID="Label7" font-size="small" runat="server" CssClass="lbl" Text="Quantity-:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtQty" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
         
                <td style="text-align:right;"> <asp:Label ID="Label3" font-size="small" runat="server" CssClass="lbl" Text="Amount"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtAmount" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox> 
               </tr>
               <tr>
                    <td style="text-align:right;"> <asp:Label ID="Label4" font-size="small" runat="server" CssClass="lbl" Text="Cost Center Name -:"></asp:Label></td>
    
                  <td style="text-align: left;">
                     <asp:DropDownList ID="DdlCostCenter" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True">
                      <asp:ListItem>HR & Administration</asp:ListItem>
                     <asp:ListItem>Accounts</asp:ListItem>
                       <asp:ListItem>Audit</asp:ListItem>
                         

                   
                     </asp:DropDownList>
                   <td></td><td>
                       <asp:Button ID="BtnAdd" runat="server" Text="ADD" OnClick="BtnAdd_Click"  />
                            
                   
                       <asp:Button ID="Button2" runat="server" Text="Submit" />
                            </td>
           
               </tr>
           </Table>
         
          <table>
              
            <tr>
                <td>
                    <asp:GridView ID="dgvbudget" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvbudget_RowDeleting">
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
                                  <ItemStyle Width="70px"></ItemStyle></asp:TemplateField>
                             <asp:TemplateField HeaderText="Operation Name">
                                  <ItemTemplate>
                                      <asp:Label ID="LbloOpnames" runat="server" Text='<%# Bind("opname") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Operation Type">
                                  <ItemTemplate>
                                      <asp:Label ID="Lbloptype" runat="server" Text='<%# Bind("optype") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="NameType">
                                  <ItemTemplate>
                                      <asp:Label ID="Lblnmaetype" runat="server"  autopostback="true" Text='<%# Bind("nmaetype") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Type">
                                  <ItemTemplate>
                                      <asp:Label ID="Lblopex" runat="server"  autopostback="true" Text='<%# Bind("opex") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText = "Name">
                        <ItemTemplate>
                            <asp:Label ID="QcpersonaN" runat="server" Text='<%# Bind("name") %>' ></asp:Label>
                             </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Item">
                                  <ItemTemplate>
                                      <asp:Label ID="lblexisting" runat="server" Text='<%# Bind("existing") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Qty">
                                  <ItemTemplate>
                                      <asp:Label ID="Lblqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                  <ItemTemplate>
                                      <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:CommandField HeaderText="Clear" ShowDeleteButton="True" />
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