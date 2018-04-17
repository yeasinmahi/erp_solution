<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoDocAttachment.aspx.cs" Inherits="UI.SCM.PoDocAttachment" %>

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
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>
     
  <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function ClosehdnDivision() {

             $("#hdnDivision").fadeOut("slow");
         }
</script>

    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 

   <script>
        function Viewdetails(unit, PoId, BillAmount, BillId, BillCode) {
            window.open('PoDocAttachmentDetalis.aspx?unit=' + unit + '&PoId=' + PoId + '&BillAmount=' + BillAmount + '&BillId=' + BillId + '&BillCode=' + BillCode , 'sub', "scrollbars=yes,toolbar=0,height=500,width=700,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
        }
    </script>
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: white; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left:50px;  margin-top:130px; margin-right:00px; padding: 15px; overflow-y:scroll; }

        
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
    
       <div class="tabs_container" style="text-align:left">PO Approval  From<hr /></div>
         
       <table>
        <tr> 
        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>                                                                                      
         
        <td  style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>     
        </tr> 
           <tr>
            <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteFrom"></cc1:CalendarExtender></td>

            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteTo"></cc1:CalendarExtender></td> 
           </tr>
        <tr>                                                                                                        
        <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="PO Issuer"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlPoUser" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnPoNoShow" runat="server" Text="Show" CssClass="btnButton"  />
        </td>  
        <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Suppliyer"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlSupplier" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
          </asp:DropDownList>
        <asp:Button ID="btnPoUserShow" runat="server" Text="Show" OnClick="btnPoUserShow_Click"     />
        </td> 
      </tr> 
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvPO" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="600px"  
                CssClass="GridViewStyle">            
                <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
                <asp:TemplateField HeaderText="BillId" SortExpression="intBill"><ItemTemplate>
                <asp:Label ID="lblBillId" runat="server" Width="60px" Text='<%# Bind("intBill") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Bill Reg No" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="intPOID" >
                <ItemTemplate><asp:Label ID="lblBillCode" runat="server" Width="130px"  Text='<%# Bind("strBillCode") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

                <asp:TemplateField HeaderText="Party Name" ItemStyle-HorizontalAlign="right" SortExpression="dtePODate" >
                <ItemTemplate><asp:Label ID="lblParty" runat="server"  Width="150px" Text='<%# Bind("strParty") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Bill No" ItemStyle-HorizontalAlign="right" SortExpression="strBill" >
                <ItemTemplate><asp:Label ID="lblBill" runat="server" Width="70px"  Text='<%# Bind("strBill") %>'></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="Bill Date" ItemStyle-HorizontalAlign="right" SortExpression="dtrBillDate" >
                <ItemTemplate><asp:Label ID="lblBillDate" runat="server" Width="70px"  Text='<%# Bind("dtrBillDate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Rcv Date" ItemStyle-HorizontalAlign="right" SortExpression="dteRcvDate" >
                <ItemTemplate><asp:Label ID="lblRcvDate" runat="server"  Width="70px"  Text='<%# Bind("dteRcvDate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
                <asp:TemplateField HeaderText="Bill Amount" ItemStyle-HorizontalAlign="right" SortExpression="monBillAmount" >
                <ItemTemplate><asp:Label ID="lblmonBillAmount" runat="server" Width="90px"  Text='<%# Bind("monBillAmount","{0:n2}") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="Of Attachment" ItemStyle-HorizontalAlign="right"  Visible="false"  SortExpression="intAttachment" >
                <ItemTemplate><asp:Label ID="lblIntAttachement"   runat="server"   Text='<%# Bind("intAttachment") %>'  ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 

                <asp:TemplateField HeaderText="Audit Status" ItemStyle-HorizontalAlign="right"   SortExpression="strAuditStatus" >
                <ItemTemplate><asp:Label ID="lblAuditStatus"   runat="server" Width="80px"  Text='<%# Bind("strAuditStatus") %>'  ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 
             
                 <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="right"   SortExpression="dteAuditDate" >
                <ItemTemplate><asp:Label ID="lblAuditDate"   runat="server" Width="70px"  Text='<%# Bind("dteAuditDate","{0:dd-MM-yyyy}") %>'  ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 

                 <asp:TemplateField HeaderText="Appropve Amount" ItemStyle-HorizontalAlign="right"   SortExpression="monApproveAmount" >
                <ItemTemplate><asp:Label ID="lblApprovAmmount"   runat="server" Width="70px"  Text='<%# Bind("monApproveAmount","{0:n2}") %>'  ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="Pay Date" ItemStyle-HorizontalAlign="right"   SortExpression="dtePayDate" >
                <ItemTemplate><asp:Label ID="lblPayDate"   runat="server"  Width="70px" Text='<%# Bind("dtePayDate","{0:dd-MM-yyyy}") %>'  ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="PO ID" ItemStyle-HorizontalAlign="right"  SortExpression="intPO" >
                <ItemTemplate><asp:Label ID="lblPoId" Width="70px"  runat="server" Text='<%# Bind("intPO") %>'   ></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="Detalis">  <ItemTemplate>
                <asp:Button ID="btnDetalis" runat="server" Text="Detalis"  OnClick="btnDetalis_Click"    /></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            </Columns> 
            </asp:GridView></td> 
        </tr>  
       </table> 
        </div>

    <div id="hdnDivision"  class="hdnDivision"   style="width:auto; background-color:white; height:500px;"> 

             <table>
                 <tr>
                     <td colspan="2"></td><td></td>
                     <td style="text-align:right; font-size:medium" >Akij Food & Beverage</td>
                 </tr>
                 <tr>
                      <td colspan="2"></td><td></td>
                     <td  style="text-align:right">73, Dilkusa C/A 1000 Dhaka</td>
                 </tr>
                 <tr>
                     
                     <td> Purchase Order</td>
                     <td><asp:TextBox ID="txtPoNumbers" runat="server" CssClass="txtBox" ></asp:TextBox><asp:Button ID="btnPoShowByView" CssClass="btnButton"    runat="server" Text="Show" /></td>
                 </tr> 
              </table>
             <table style="border-color:black; border-radius:10px; border:1px solid blue;">
                  <tr>
                      <td style="text-align:left">Suppliyer</td>
                      <td style="text-align:left">Ship TO</td>
                      <td style="text-align:left">Bill To</td>
                  </tr>
                  <tr>
                      <td style="text-align:left"><asp:Label ID="lblSuppliyers" runat="server"></asp:Label></td>                     
                      <td style="text-align:left"><asp:Label ID="lblShipTo" Width="250px" runat="server"></asp:Label></td>
                      <td style="text-align:left"><asp:Label ID="lblBillTo"  Width="250px" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                       <td style="text-align:left">Email:</td> 
                  </tr>
                  <tr>
                      <td style="text-align:left"><asp:Label ID="lblSupEmail" Width="250px" runat="server"></asp:Label></td> 
                  </tr>
                  <tr>
                       <td style="text-align:left">Attn:</td> 
                  </tr>
                  <tr>
                      <td style="text-align:left"><asp:Label ID="lblAtten" Width="250px" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left">Phone:</td>
                  </tr>
                  <tr>
                      <td style="text-align:left"><asp:Label ID="lblPhone" Width="250px" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left">Address:</td>
                  </tr>
                  <tr>
                      <td style="text-align:left"><asp:Label ID="lblSuppAddress" Width="300px" runat="server"></asp:Label></td>
                  </tr> 
              </table>
             <table>
             <tr><td></td></tr>
             <tr> 
             <td><asp:GridView ID="dgvPoDetalis" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
             BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
             <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
                <asp:TemplateField HeaderText="Item Name" SortExpression="strName"><ItemTemplate>
                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>
                
                <asp:TemplateField HeaderText="Description" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strSpecification" >
                <ItemTemplate><asp:Label ID="lblDescription" runat="server"  Text='<%# Bind("strSpecification") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" Width="180px"/>  </asp:TemplateField>  

                <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
                <ItemTemplate><asp:Label ID="lblUom" runat="server"   Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Shipment" ItemStyle-HorizontalAlign="right" SortExpression="intShipmentSL" >
                <ItemTemplate><asp:Label ID="lblShipment" runat="server"   Text='<%# Bind("intShipmentSL") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
                <ItemTemplate><asp:Label ID="lblnumQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="monRate" >
                <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monRate") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
                <asp:TemplateField HeaderText="Vat" ItemStyle-HorizontalAlign="right" SortExpression="monVAT" >
                <ItemTemplate><asp:Label ID="lblVat" runat="server"   Text='<%# Bind("monVAT") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="monAIT" >
                <ItemTemplate><asp:Label ID="lblAIT" runat="server" Text='<%# Bind("monAIT") %>'   ></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="monAmount" >
                <ItemTemplate><asp:Label ID="lblPoTotalAmount" runat="server"  Text='<%# Bind("monAmount") %>'    ></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

            </Columns>
            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /> 
            </asp:GridView></td> 
        </tr>  
            <tr><td></td> </tr> 
            <tr> <td></td></tr>
                    
                 
              </table>
             <table>
                  <tr>
                      <td style="text-align:left;border: 1px solid black;">Partial Shipment</td>
                      <td style="text-align:left;border: 1px solid black;"><asp:Label ID="lblPartialShip" Width="100px" runat="server"></asp:Label></td>
                      <td style="text-align:right;border: 1px solid black">Trnsport Charge:</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblTransportCharge" Width="100px" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid black">No of Shipment</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblNoShipment" Width="100px" runat="server"></asp:Label></td>
                      <td style="text-align:right;border: 1px solid black">Others Charge:</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblOthersCharge" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid black">Last Shipment Date</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lbllastShipmentDate" Width="100px" runat="server"></asp:Label></td>
                      <td style="text-align:right;border: 1px solid black">Gross Disscount:</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblGrossDis" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid black">Payment terms</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblPaymentTrems" runat="server"  ></asp:Label></td>
                      <td style="text-align:right;border: 1px solid black">Comission:</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblComission" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid black">Payment days after MRR (days)</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblPaymentDaysMrr" runat="server"></asp:Label></td>
                      <td style="text-align:right;border: 1px solid black">Grand Total:</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblGrandTotal" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid black">No of Installment</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblNoOfInstallment" runat="server"></asp:Label></td>
                  </tr> 
                  <tr>
                      <td style="text-align:left;border: 1px solid black">Installment Interval (Days)</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblIntervelDay" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid black">Warrenty after delivery (months)</td>
                      <td style="text-align:left;border: 1px solid black"><asp:Label ID="lblDeliveryMonth" runat="server"></asp:Label></td>
                  </tr>                  
              </table> 
         </div> 
<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
