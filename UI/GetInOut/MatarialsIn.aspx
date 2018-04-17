<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatarialsIn.aspx.cs" Inherits="UI.GetInOut.MatarialsIn" %>

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
        .Textbox {}
    </style>


       <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

   <%-- <%--<link href="jquery-ui.css" rel="stylesheet" />--%>
<%--    <script src="jquery-ui.min.js"></script>
    <script src="jquery.min.js"></script>--%>--%>



    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearchp").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "MatarialsIn.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearchp').value + "'}",
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
                
                
    <div class="tabs_container" align="Center">Vehicle and Materials IN</div>
         <br />
         <br />
         <table>
             <%--<tr>
                  <td style="text-align:right;"><asp:Label ID="LblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlUnit" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="false"> 
                    </asp:DropDownList> 
             </tr>--%>
             <tr>
                 <td style="text-align:right;"><asp:Label ID="Lblponumber" runat="server" CssClass="lbl" Text="Po Number :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtponumber" CssClass="Textbox" Font-Bold="False" runat="server" OnTextChanged="Txtponumber_TextChanged"></asp:Textbox> 

                 <td style="text-align:right;"><asp:Label ID="Lblchallanno" runat="server" CssClass="lbl" Text="Challan No :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtchallanno" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 
                   
                  <td style="text-align:right;"><asp:Label ID="Lblvehicle" runat="server" CssClass="lbl" Text="Vehicle No :"></asp:Label></td>
                
                  <td><asp:TextBox ID="txtEmployeeSearchp" runat="server" CssClass="Textbox" AutoPostBack="true" onchange="javascript: Changed();" ></asp:TextBox>
                <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
                        
            
                 
                 
                
                </tr>

                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Lbldrivername" runat="server" CssClass="lbl" Text="Driver Name :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtdrivername" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

                <td style="text-align:right;"><asp:Label ID="Lblcontact" runat="server" CssClass="lbl" Text="Driver Contact No :"></asp:Label></td>
                <td style="text-align:left;" ><asp:Textbox ID="Txtcomtact" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
             
                 <td style="text-align:right;"><asp:Label ID="Lblsupplier" runat="server" CssClass="lbl" Text="Supplier:"></asp:Label></td>
                 <td style="text-align:left;" >  <asp:TextBox ID="Txtsupplier" runat="server" CssClass="Textbox" Font-Bold="False"></asp:TextBox></tr>

                 
                     
              <tr>
                 
                  <td style="text-align:right;"><asp:Label ID="Lblslocation" runat="server" CssClass="lbl" Text="Supplier Location :"></asp:Label></td>
                 <td style="text-align:left;" ><asp:Textbox ID="Txtslocation" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>   

                <td style="text-align:right;"><asp:Label ID="Lblqty" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
                <td style="text-align:left;" ><asp:Textbox ID="Txtqty" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
              
                     <td style="text-align:right;"><asp:Label ID="LblUom" runat="server" CssClass="lbl" Text="UOM :"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlUome" CssClass="ddList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                    </asp:DropDownList> 
            
                </tr>

             <tr>

              <td style="text-align:right;"><asp:Label ID="Lblscaleid" runat="server" CssClass="lbl" Text="Scale ID :"></asp:Label></td>
              <td style="text-align:left;" ><asp:Textbox ID="Txtscaleid" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>

             
             <td style="text-align:right;"><asp:Label ID="Lblgrossweight" runat="server" CssClass="lbl" Text="Gross Weight:"></asp:Label></td>
             <td style="text-align:left;" ><asp:Textbox ID="txtgrossweight" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>

            <td style="text-align:right;"><asp:Label ID="Lblnetweight" runat="server" CssClass="lbl" Text="Net Weight :"></asp:Label></td>
            <td style="text-align:left;" ><asp:Textbox ID="Txtnetweight" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
            
            
             
                
            </tr>
            <tr>

        <td style="text-align:right;"><asp:Label ID="Lblmatarials" runat="server" CssClass="lbl" Text="Materials Description:"></asp:Label></td>
            <td style="text-align:left;" ><asp:Textbox ID="Txtmatarials" CssClass="Textbox" Font-Bold="False" runat="server" TextMode="MultiLine" Width="155px"></asp:Textbox>
            

            <%--    <td style="text-align:right;"><asp:Label ID="LblOthersVehicle" runat="server" CssClass="lbl" Text="Others Vehicle :"></asp:Label></td>
            <td style="text-align:left;" ><asp:Textbox ID="TxtOthersVehicle" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>--%>
         
             <td colspan="2" style="text-align:right;">
               
                   
                 <td></td></td><td><asp:Button ID="btnsubmit" runat="server" CssClass="nextclick" Text="Submit" OnClick="btnsubmit_Click"/><asp:Button ID="btnadd" runat="server" CssClass="nextclick"  Text="Add" OnClick="btnadd_Click"/></td>
             <%--<td colspan="2" style="text-align:right;"> </td>--%>
                <%--<td> <asp:Button ID="Btnshow" runat="server" Text="Show" OnClick="Btnshow_Click" /></td>--%>
            </tr>
            
        
             <tr>

           <td colspan="6" >
               <asp:GridView ID="dgv" runat="server"  AutoGenerateColumns="False" OnRowDeleting="dgv_RowDeleting" ForeColor="#333333" GridLines="None"    Font-Size="10px" >
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                       <asp:TemplateField HeaderText="Sl." ><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Ponumber">
                           <ItemTemplate>
                               <asp:Label ID="Lblpo" runat="server" Text='<%# Bind("ponumber") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Challan No">
                           <ItemTemplate>
                               <asp:Label ID="Lblcha" runat="server" Text='<%# Bind("Challanno") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Driver No">
                           <ItemTemplate>
                               <asp:Label ID="Lbldri" runat="server" Text='<%# Bind("drivername") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Vehicle">
                           <ItemTemplate>
                               <asp:Label ID="Lblceh" runat="server" Text='<%# Bind("vehicle") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Contact">
                           <ItemTemplate>
                               <asp:Label ID="Lblcon" runat="server" Text='<%# Bind("contact") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Supplier">
                           <ItemTemplate>
                               <asp:Label ID="Lblsup" runat="server" Text='<%# Bind("supplier") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Location">
                           <ItemTemplate>
                               <asp:Label ID="Lblloc" runat="server" Text='<%# Bind("location") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Qty">
                           <ItemTemplate>
                               <asp:Label ID="Lblqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="UOM">
                           <ItemTemplate>
                               <asp:Label ID="Lblref" runat="server" Text='<%# Bind("uomdata") %>'></asp:Label>
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
                       <asp:TemplateField HeaderText="Materials" >
                           <ItemTemplate>
                               <asp:Label ID="Lblmat" runat="server"   Text='<%# Bind("matarials") %>'></asp:Label>
                           </ItemTemplate>
                           <ItemStyle Font-Overline="False" Wrap="False" />
                       </asp:TemplateField>
                       <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" >
                       <ControlStyle Font-Bold="True" ForeColor="#000099" />
                       </asp:CommandField>
                   </Columns>
                   <EditRowStyle BackColor="#2461BF" />
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <RowStyle BackColor="#EFF3FB" />
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <SortedAscendingCellStyle BackColor="#F5F7FB" />
                   <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                   <SortedDescendingCellStyle BackColor="#E9EBEF" />
                   <SortedDescendingHeaderStyle BackColor="#4870BE" />
               </asp:GridView>
           </td>
       </tr>

     <tr>
         <td colspan="5"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="3" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowSorting="True">
             <Columns>
                 <asp:TemplateField HeaderText="Sl."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Driver Name">
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("strDrivername") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Vehicle No">
                     <ItemTemplate>
                         <asp:Label ID="Label3" runat="server" Text='<%# Eval("strVechileNo") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <%--<asp:TemplateField HeaderText="PO Number">--%>
                     <%--<ItemTemplate>
                         <asp:Label ID="Label4" runat="server" Text='<%# Eval("intRTGetInPO") %>'></asp:Label>
                     </ItemTemplate>--%>
                <%-- </asp:TemplateField>--%>
                 <asp:TemplateField HeaderText="Scale ID">
                     
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("strScaleId") %>'></asp:TextBox>
                     </EditItemTemplate>
                     
                     <ItemTemplate>
                         <asp:Label ID="Label5" runat="server" Text='<%# Eval("strScaleId") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Gross Weight">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("monGrossWeight") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label6" runat="server" Text='<%# Eval("monGrossWeight") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Net Weight">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("monNetWeight") %>'></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label7" runat="server" Text='<%# Eval("monNetWeight") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:CommandField DeleteText="Out" HeaderText="Out" ShowDeleteButton="True" >
                 <ControlStyle Font-Bold="True" ForeColor="#000099" />
                 </asp:CommandField>
                 <asp:CommandField HeaderText="Update" ShowEditButton="True" />
             </Columns>
             <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
             <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
             <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
             <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#594B9C" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#33276A" />
             </asp:GridView></td>
         
     </tr>
             <tr>
                 <td colspan="5">
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField></asp:TemplateField>
                             <asp:TemplateField HeaderText="ItemName">
                                 <ItemTemplate>
                                     <asp:Label ID="item" runat="server" Text='<%# Eval("strItemName") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Qty">
                                 <ItemTemplate>
                                     <asp:Label ID="qty" runat="server" Text='<%# Eval("numQty") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Uom">
                                 <ItemTemplate>
                                     <asp:Label ID="Uom" runat="server" Text='<%# Eval("strUom") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField>
                                 <HeaderTemplate>
                                    <%-- <asp:Button ID="BtnPO" runat="server" Text="PO IN" OnClick="BtnPO_Click" />--%>
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                    <%-- <asp:TextBox ID="Txtaqty" runat="server"></asp:TextBox>--%>
                                 </ItemTemplate>
                             </asp:TemplateField>
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
