<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRebate.aspx.cs" Inherits="UI.SAD.Vat.frmRebate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var Matrialname = document.forms["frmPurchase"]["txtVatItemName"].value;
            var PurDate = document.forms["frmPurchase"]["txtdate"].value;
            var txtCD = document.forms["frmPurchase"]["txtCD"].value;           
            var txtSD = document.forms["frmPurchase"]["txtSD"].value;
            var txtRD = document.forms["frmPurchase"]["txtRD"].value;
            var txtOthers = document.forms["frmPurchase"]["txtOthers"].value;
           

            if (Matrialname == null || Matrialname == "") {
                alert("Please Matrial Fill-Up !");
            }

            else if (PurDate == null || PurDate == "") {
                alert("Purchase Date Select !");
            }
            else if (txtCD == null || txtCD == "") {
                alert("Please Entry SD !");
            }

            else if (txtSD == null || txtSD == "") {
                alert("Please Entry SD !");
            }

            else if (txtRD == null || txtRD == "") {
                alert("Please Entry RD !");
            }
            else if (txtOthers == null || txtOthers == "") {
                 alert("Please Entry Others !");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>
</head>
<body>
    <form id="frmBandroll" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnbomid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="tabs_container"> REBATE ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                                   
        <tr><td>Date</td>
        <td><asp:TextBox ID="txtdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
        ID="CalendarExtender1" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td>Product Name </td>
        <td><asp:TextBox ID="txtVatItemName" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" OnTextChanged="txtItemMatrial_TextChanged" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVatItemName"
        ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender></td>
        <td>Export</td>
        <td><asp:Label ID="lblexport" runat="server"></asp:Label>Used <asp:Label ID="lblused" runat="server"></asp:Label> &nbsp UOM <asp:Label ID="lbluom" runat="server"></asp:Label></td>  
        </tr> 
        <tr><td>Delivery Order No:</td>
        <td><asp:DropDownList ID="ddlMatiral" CssClass="ddList" runat="server" OnSelectedIndexChanged="ddlMatiral_SelectedIndexChanged"></asp:DropDownList></td>
        <td>Import</td>
        <td><asp:DropDownList ID="ddlImport" CssClass="ddList" runat="server" OnSelectedIndexChanged="ddlImport_SelectedIndexChanged" ></asp:DropDownList></td>
        <td>CD</td>
        <td><asp:TextBox ID="txtCD" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        </tr>
        <tr><td>SD</td><td><asp:TextBox ID="txtSD" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>RD</td><td><asp:TextBox ID="txtRD" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>        
        <td>Others</td><td><asp:TextBox ID="txtOthers" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>                
        <td colspan="2">&nbsp;</td>                   
        </tr>
        <tr>
        <td colspan="6" style="text-align:right"><asp:Button ID="btnAdd" runat="server" Text="Add"  OnClientClick="ValidationBasicInfo()" OnClick="btnAdd_Click" /><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
        </tr>
        <tr><td colspan="6"><hr /></td></tr>          
                   
    </table>
    </td></tr>
    <tr><td>
    <table class="tbldecoration" style="width:auto; float:left;"> 
        <tr><td colspan="5" class="auto-style1">&nbsp;REPORT</td>   
        <tr><td>Product name</td>
        <td><asp:TextBox ID="txtReportVatProduct" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" OnTextChanged="txtItemMatrial_TextChanged" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtReportVatProduct"
        ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender></td>
        <td><asp:TextBox ID="txtrdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtrdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
        ID="CalendarExtender3" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />&nbsp&nbsp<asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" /></td>
        </tr> 
        </tr> 
        <tr><td colspan="5" style="text-align:right"></td>                                     
        <tr><td colspan="5"><hr /></td></tr> 
        <tr><td colspan="5"><asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvProductRpt_RowDataBound"
            >
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
            <asp:TemplateField HeaderText="Date" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("dtedate","{0:d}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
            <ItemTemplate> <asp:Label ID="lblstrMaterialName" runat="server" Text='<%# Bind("strMaterialName") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblstrUOM" runat="server" Text='<%# Bind("strUOM") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Use per unit" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monUsePerUnit","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalQty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Use" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monTotalUse","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="BoE No" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("strChallanNo","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Date" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("dteChallanDate","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Import Qty" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numQuantity","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="CD" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monCD","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="SD" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monSD","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="CR" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monRD","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Other TAX" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monOtherTax","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>


            <asp:TemplateField HeaderText="Total Duty" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monTotalDuty","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total draw back" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monTotalDrawBack","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>


            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr>  
        </tr>             
       </table>
    <table  class="tbldecoration" style="width:auto; float:left;">    
     <tr><td colspan="5" style="text-align:right"></td>                                     
     <tr><td colspan="5"><hr /></td></tr> 
     <tr><td colspan="5">
        <asp:GridView ID="dgvBrandroll" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" 
        OnRowDeleting="dgvPurchase_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
             
        <asp:TemplateField HeaderText="ID" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblintMaterial" runat="server" Text='<%# Bind("intMaterial") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="20px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Material name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrMaterial" runat="server" Text='<%# Bind("strMaterial") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="UOM" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrUOM" runat="server" Text='<%# Bind("strUOM") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Qty" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonM1Qty" runat="server" Text='<%# Bind("monM1Qty") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Total Use" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonTotalUse" runat="server" Text='<%# Bind("monTotalUse") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Import ID" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblintImportID" runat="server" Text='<%# Bind("intImportID") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Challanno" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblChallanno" runat="server" Text='<%# Bind("Challanno") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldtedate" runat="server" Text='<%# Bind("dtedate") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="ExpQty" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonExpQty" runat="server" Text='<%# Bind("monExpQty") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        
        <asp:TemplateField HeaderText="CD" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonCD" runat="server" Text='<%# Bind("monCD") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="SD" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonSD" runat="server" Text='<%# Bind("monSD") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="RD" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonRD" runat="server" Text='<%# Bind("monRD") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Other" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonOther" runat="server" Text='<%# Bind("monOther") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Total Duty" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonTotalDuty" runat="server" Text='<%# Bind("monTotalDuty") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Rebate Rate" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonRebateRate" runat="server" Text='<%# Bind("monRebateRate") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>


        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
            
        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
     </td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
