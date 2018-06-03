﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceReceive.aspx.cs" Inherits="UI.SCM.ServiceReceive" %>

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
    

    <script type="text/javascript"> 

        $("[id*=txtReceiveQty]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });

        $("[id*=txtReceiveQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var poqty = parseFloat($("[id*=lblPoQty]", row).html());
                    var monValue = parseFloat($("[id*=lblValue]", row).html());
                    var preReceQty = parseFloat($("[id*=lblPreviousReceive]", row).html());
                    var receQty = parseFloat($(this).val()).toFixed(4);
                    var rtotal = parseFloat(monValue / poqty * receQty);
                    var remain = parseFloat(poqty - preReceQty)
                    if (remain >= receQty) {
                        $("[id*=lblMrrValue]", row).html(rtotal.toFixed(4));
                       
                    }
                    else {
                        $("[id*=txtReceiveQty]", row).val('0');
                        alert('Please Receive Qty Grather then Po Qty');
                    }
                    

                }
            } else {
                $(this).val('');
            } 

        });
         
        function MrrGenerateCheck() {
            
            var e = document.getElementById("ddlPo");
            var Po = e.options[e.selectedIndex].value; 
            var challan = document.getElementById("txtChallan").value;
            var challanDate = document.getElementById("txtdteChallan").value;
            var vatChallan = document.getElementById("txtVatChallan").value;
            var vatAmount = document.getElementById("txtVatAmount").value;

            if ($.trim(Po) == 0 || $.trim(Po) == "" || $.trim(Po) == null || $.trim(Po) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please select Po'); }
            else if ($.trim(challan) == 0 || $.trim(challan) == "" || $.trim(challan) == null || $.trim(challan) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please set Challan No'); }
            else if ($.trim(challanDate) == 0 || $.trim(challanDate) == "" || $.trim(challanDate) == null || $.trim(challanDate) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please select Challan Date'); }
           // else if ($.trim(vatChallan) == 0 || $.trim(vatChallan) == "" || $.trim(vatChallan) == null || $.trim(vatChallan) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please set vatChallan number'); }
            else if ($.trim(vatAmount) == "" || $.trim(vatAmount) == null || $.trim(vatAmount) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please set Vat Amount'); }
             
            else if ($.trim(challanDate).length < 3 || $.trim(challanDate) == "" || $.trim(challanDate) == null || $.trim(challanDate) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please set  Challan  Date'); }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 

            
                 
            }
         

        }
    </script> 

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
    color: White;
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
    .auto-style1 {
        width: 819px;
    }
</style> 
     <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
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
    <div id="divControl" class="divPopUp2" style="width: 100%;  height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConversion" runat="server" /><asp:HiddenField ID="hdnShipment" runat="server" /> 
         <asp:HiddenField ID="hdnPO" runat="server" /> <asp:HiddenField ID="hdnUnitName" runat="server" /> <asp:HiddenField ID="hdnWHId" runat="server" /> 
         <asp:HiddenField ID="hdnWHName" runat="server" />  <asp:HiddenField ID="hdnConfirm" runat="server" />  
               <table style=" border-width: 1px; border-color: #666; border-style: solid">  
                        <tr style="text-align:center"> 
                        <td colspan="3" style="text-align:right"><asp:Label ID="lblUnit"  Text="Ware House" runat="server" /></td> 
                        <td colspan="3" style="text-align:left"><asp:DropDownList ID="ddlWH" Font-Bold="true" runat="server" CssClass="txtBox" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td> 
                        </tr> 
                        <tr>
                        <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="PO Type"></asp:Label></td> 
                        <td style="text-align:left;"> <asp:DropDownList ID="ddlPoType" CssClass="ddList" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="ddlPoType_SelectedIndexChanged"></asp:DropDownList></td>   
                        <td style="text-align:right;"><asp:Label ID="lblItem" CssClass="lbl" runat="server" Text="Select-PO: "></asp:Label></td>
                        <td><asp:TextBox ID="txtPoNo"   Width="300px"  CssClass="txtBox"  Font-Size="Small"  runat="server"></asp:TextBox></td>  
                        <td>Invoice No</td>
                        <td><asp:DropDownList ID="ddlInvoice" CssClass="ddList"     AutoPostBack="true" Font-Size="Small"  runat="server"></asp:DropDownList></td>
                        </tr>  
                        <tr>
                        <td>Challan/BOL</td>
                        <td><asp:TextBox ID="txtChallan" runat="server" CssClass="txtBox"></asp:TextBox></td>
                        <td style="text-align:right">Challan Date</td>
                       <td style="text-align:left;"><asp:TextBox ID="txtdteChallan" Width="300px"  runat="server"  CssClass="txtBox" Font-Bold="False"> 
                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteChallan"></cc1:CalendarExtender> 
                        </td>
                        <td>Vat Challan</td>
                        <td><asp:TextBox ID="txtVatChallan" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                        </tr>
                        <tr>
                        <td>Vat Amount</td>
                        <td><asp:TextBox ID="txtVatAmount" runat="server" CssClass="txtBox"></asp:TextBox></td>
                       
                         <td style="text-align:right"  colspan="4"  ><asp:Button ID="btnShow" Font-Bold="true" runat="server" Text="Show" OnClick="btnShow_Click" /><asp:Button ID="btnSaveMrr" Text="Save SRR" Font-Bold="true" runat="server" OnClientClick="MrrGenerateCheck();" OnClick="btnSaveMrr_Click" /></td>

                       
                        </tr>
                        <tr> 
                        <td colspan="4"><asp:Label ID="lblSuppliyer" runat="server"  ></asp:Label><asp:Label ID="lblSuppliuerID" Visible="false" runat="server"  ></asp:Label><asp:Label ID="lblCurrency" runat="server"></asp:Label>
                        <asp:Label ID="lblConversion" runat="server"> </asp:Label><asp:Label ID="lblPoIssueBy" Visible="false" runat="server"></asp:Label></td>
                        </tr>
                    </table> 
             
               <table>
                    <tr>
                    <td style="font-style:normal">MRR No:</td> <td style="font-weight: bold;"><asp:Label ID="lblMrrNo" Font-Size="Medium" ForeColor="Red"  runat="server"></asp:Label></td>
                    <td>MRR Date:</td> <td style="font-weight: bold;"><asp:Label ID="lblMrrDate"  runat="server"></asp:Label></td> 
                    <td>PO total Vat:</td> <td style="font-weight: bold;"><asp:Label ID="lblPoTotal"  runat="server"></asp:Label></td>
                    <td>Product Cost:</td>
                    <td style="font-weight: bold;"><asp:Label ID="lblProductCost"  runat="server"></asp:Label></td>
                    <td>Transport Cost:</td>
                    <td style="font-weight: bold;"><asp:Label ID="lblTransportCost"  runat="server"></asp:Label></td>
                    <td>Other Cost:</td>
                    <td style="font-weight: bold;"><asp:Label ID="lblOtherCost"  runat="server"></asp:Label></td>
                    <td>Discount:</td>
                    <td style="font-weight: bold;"><asp:Label ID="lblDiscount"  runat="server"></asp:Label></td>
                    </tr>
               </table>
               <table>
                        <tr> 
                        <td> 
                        <asp:GridView ID="dgvMrr" runat="server" AutoGenerateColumns="False"  Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  OnRowDataBound="Mrr_RowDataBound" 
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" > 
                        <AlternatingRowStyle BackColor="#CCCCCC" /> 
                        <Columns> 
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>  
                         
                        <asp:TemplateField HeaderText="ItemId" SortExpression="intItem"><ItemTemplate> 
                        <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItem") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="ItemName" ItemStyle-HorizontalAlign="right" SortExpression="strItem" > 
                        <ItemTemplate><asp:Label ID="lblItemName" runat="server"  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="left" Width="350px" /> </asp:TemplateField>  

                         <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="right" Visible="true" SortExpression="strDes" > 
                        <ItemTemplate><asp:Label ID="lblDescription" runat="server"  Text='<%# Bind("strDes") %>'  ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="300px" /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" Visible="true" SortExpression="strUom" > 
                        <ItemTemplate><asp:Label ID="lblUom" runat="server"  Text='<%# Bind("strUom") %>'  ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="PO Qty" ItemStyle-HorizontalAlign="right" SortExpression="numPoQty" > 
                        <ItemTemplate><asp:Label ID="lblPoQty" runat="server"   Text='<%# Bind("numPoQty","{0:n2}") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" />  </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="monRate" > 
                        <ItemTemplate><asp:Label ID="lblRate"  Width="50px" runat="server"  Text='<%# Bind("monRate","{0:n2}") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>  
                            
                        <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="monValue" > 
                        <ItemTemplate><asp:Label ID="lblValue" runat="server"    Text='<%# Bind("monValue","{0:n2}") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Vat" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="monVat" > 
                        <ItemTemplate><asp:Label ID="lblVat" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monVat" ) %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" /> </asp:TemplateField>  

                        <asp:TemplateField HeaderText="QC Passed" ItemStyle-HorizontalAlign="right" SortExpression="numQcQty" > 
                        <ItemTemplate><asp:Label ID="lblQcPassedQty" runat="server"    Text='<%# Bind("numQcQty","{0:n2}") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" />  </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Previous Receive" ItemStyle-HorizontalAlign="right" Visible="true" SortExpression="monPreRecvQty" > 
                        <ItemTemplate><asp:Label ID="lblPreviousReceive" runat="server"   Text='<%# Bind("monPreRecvQty","{0:n2}" ) %>'  ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" /></asp:TemplateField> 

                         <asp:TemplateField HeaderText="YsnQC" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="ysnNeedQc" > 
                        <ItemTemplate><asp:Label ID="lblYsnQc" runat="server"   Text='<%# Bind("ysnNeedQc") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" />  </asp:TemplateField> 

                       
 
                       

                        <asp:TemplateField HeaderText="Receive Qty" ItemStyle-HorizontalAlign="right" SortExpression="RecQty" > 
                        <ItemTemplate><asp:TextBox ID="txtReceiveQty" CssClass="txtBox" Width="60px" runat="server"  Text='<%# Bind("RecQty") %>'></asp:TextBox></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="MRR Value" ItemStyle-HorizontalAlign="right" > 
                        <ItemTemplate><asp:Label ID="lblMrrValue"   Width="50px" runat="server"  ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Batch no" ItemStyle-HorizontalAlign="right" > 
                        <ItemTemplate><asp:TextBox ID="txtBatchNo" CssClass="txtBox"  Width="50px" runat="server"  ></asp:TextBox></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField> 
                       
                        <asp:TemplateField HeaderText="Expire Date" ItemStyle-HorizontalAlign="right"  >
                        <ItemTemplate><asp:TextBox ID="txtExpireDate" runat="server" Width="80px"    CssClass="txtBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server"   TargetControlID="txtExpireDate">
                        </cc1:CalendarExtender> </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Manufacturing Date" ItemStyle-HorizontalAlign="right"  >
                        <ItemTemplate><asp:TextBox ID="txtManufacturingDate" runat="server" Width="80px"    CssClass="txtBox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server"   Format="yyyy-MM-dd" TargetControlID="txtManufacturingDate">
                        </cc1:CalendarExtender> </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Previous Location ID" Visible="false" ItemStyle-HorizontalAlign="right" > 
                        <ItemTemplate><asp:HiddenField ID="hdnPreviLocationId"     runat="server"  value='<%# Bind("intLocationId") %>' ></asp:HiddenField></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left"  /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Previous Location" ItemStyle-HorizontalAlign="right" > 
                        <ItemTemplate><asp:Label ID="lblPLocation"   Width="50px" runat="server"  Text='<%# Bind("strLocationName") %>' ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left"  /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Present Location" ItemStyle-HorizontalAlign="right" SortExpression="strLocationName" > 
                        <ItemTemplate><asp:DropDownList ID="ddlStoreLocation" runat="server"   Font-Size="Small"   DataSourceID="ObjectDataSourceLocation" DataTextField="strName" DataValueField="Id"></asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSourceLocation" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMrrReceiveData" TypeName="SCM_DAL.MrrReceiveTDSTableAdapters.SprMrrReceiveTableAdapter">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="10" Name="intType" Type="Int32" />
                                    <asp:Parameter DefaultValue="" Name="xmlData" Type="Object" />
                                    <asp:ControlParameter ControlID="ddlWH" Name="intWh" PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlPo" Name="intPOId" PropertyName="SelectedValue" Type="Int32" />
                                    <asp:Parameter DefaultValue="2018-01-01" Name="dteDate" Type="DateTime" />
                                    <asp:Parameter DefaultValue="0" Name="intEnroll" Type="Int32" />
                                    <asp:Parameter DefaultValue="" Direction="InputOutput" Name="msg" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server"></asp:SqlDataSource>
                            </ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right"   /> </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right"   > 
                        <ItemTemplate><asp:TextBox ID="txtRemarks" runat="server" Width="50px" DataFormatString="{0:0.00}"  ></asp:TextBox></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Wrap="true" />  </asp:TemplateField> 
                           
                        </Columns> 
                        <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" /> 
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /> 
                        </asp:GridView>
                        </td>
                    </tr>
                </table>
                 
            </div>
         
    
              
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>