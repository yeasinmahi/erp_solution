<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Receive.aspx.cs" Inherits="UI.Dairy.Milk_Receive" %>
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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function Add() {
            var a, b, c, d, e, f, g, h, i, j;
            a = parseFloat(document.getElementById("txtQty").value);
            if (isNaN(a) == true) {
                a = 0;
            }           
            var c = parseFloat(document.getElementById("txtRate").value);
            if (isNaN(c) == true) {
                c = 0;
            }         
            var g = parseFloat(document.getElementById("hdnFTP").value);
            if (isNaN(g) == true) {
                g = 0;
            }
            var h = parseFloat(document.getElementById("hdnCmComm").value);
            if (isNaN(h) == true) {
                h = 0;
            }
            
            document.getElementById("txtFatKgs").value = (a / 100 * g).toFixed(2);
            document.getElementById("txtBillAmount").value = (a * c).toFixed(2);
            document.getElementById("txtCMCommition").value = (a * h).toFixed(2);
            document.getElementById("txtGrandTotal").value = ((a * c) + (a * h)).toFixed(2);
                       
            document.getElementById("txtFatKgs").readOnly = true;
            document.getElementById("txtRate").readOnly = true;
            document.getElementById("txtBillAmount").readOnly = true;
            document.getElementById("txtCMCommition").readOnly = true;
            document.getElementById("txtGrandTotal").readOnly = true;
        }
</script>
                  
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
        <div class="tabs_container"> MILK RECEIVE FROM <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">        
        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblReceiveDate" runat="server" CssClass="lbl" Text="Receive Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtReceiveDate" runat="server" AutoPostBack="false" CssClass="txtBox" BorderColor="DimGray" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReceiveDate"></cc1:CalendarExtender></td> 

            <td style="text-align:right;"><asp:Label ID="lblPONo" runat="server" CssClass="lbl" Text="PO No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPONo" runat="server"  BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr>    
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblAlcoholTest" runat="server" CssClass="lbl" Text="Alcohol Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAlcoholTest" runat="server"  BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr>        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblChillingCenter" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlChillingCenter" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChillingCenter_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblCLR" runat="server" CssClass="lbl" Text="CLR :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCLR" runat="server" onkeypress="return onlyNumbers();" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr>
        <tr>
            <%--<td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Supplier Name & Code :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchSupp" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchSupp"
                                     ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                 <asp:HiddenField ID="hdfEmpCode" runat="server" /></td>--%>

            <td style="text-align:right;"><asp:Label ID="lblSupplierCode" runat="server" CssClass="lbl" Text="Supplier Code :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlSupplierCode" BorderColor="DimGray"  CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlSupplierCode_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblTemperature" runat="server" CssClass="lbl" Text="Temperature :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtTemperature" runat="server" onkeypress="return onlyNumbers();" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr>
       
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblSupplierName" runat="server" CssClass="lbl" Text="Supplier Name :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSupplierName" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="lblLactoReading" runat="server" CssClass="lbl" Text="Lacto Reading :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtLactoReading" runat="server" onkeypress="return onlyNumbers();" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblMorEve" runat="server" CssClass="lbl" Text="Morning/Evening:"></asp:Label></td>                
            <td>
                <asp:DropDownList ID="ddlMonEve" runat="server" BorderColor="DimGray"  CssClass="ddList" Font-Bold="false" AutoPostBack="false">
                <asp:ListItem Selected="True" Value="1">Morning</asp:ListItem><asp:ListItem Value="2">Evening</asp:ListItem>                
                </asp:DropDownList>
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblColourTest" runat="server" CssClass="lbl" Text="Colour Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtColourTest" runat="server" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQty" runat="server" BorderColor="DimGray" onkeypress="return onlyNumbers();" MaxLength="10" onKeyUp="javascript:Add();"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="lblAcidityTest" runat="server" CssClass="lbl" Text="Acidity Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAcidityTest" runat="server" BorderColor="DimGray" onkeypress="return onlyNumbers();" CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFatPercentage" runat="server" CssClass="lbl" Text="Fat Percentage :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFatPercentage" BorderColor="DimGray"  CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlFatPercentage_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblFormalinTest" runat="server" CssClass="lbl" Text="Formalin Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFormalinTest" runat="server" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>            
            <td style="text-align:right;"><asp:Label ID="lblFatKgs" runat="server" CssClass="lbl" Text="Fat Kgs :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFatKgs" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   
            
            <td style="text-align:right;"><asp:Label ID="lblSodaTest" runat="server" CssClass="lbl" Text="Soda Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSodaTest" runat="server" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblRate" runat="server" CssClass="lbl" Text="Rate :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtRate" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray" Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="lblSaltTest" runat="server" CssClass="lbl" Text="Salt Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSaltTest" runat="server" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblBillAmount" runat="server" CssClass="lbl" Text="Bill Amount :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtBillAmount" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   
            
            <td style="text-align:right;"><asp:Label ID="lblSugarTest" runat="server" CssClass="lbl" Text="Sugar Test :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSugarTest" runat="server" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblCMCommition" runat="server" CssClass="lbl" Text="CM Commition :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCMCommition" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="lblCOB" runat="server" CssClass="lbl" Text="COB :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCOB" runat="server" BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr>
        <tr>  
            <td style="text-align:right;"><asp:Label ID="lblGrandTotal" runat="server" CssClass="lbl" Text="Grand Total :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtGrandTotal" runat="server" BorderColor="DimGray"  CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   
         
            <td colspan="2"  style="text-align:left;"><asp:Button ID="btnReceive" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit"  OnClientClick="ConfirmAll()" OnClick="btnReceive_Click"/></td>            
        </tr>
        
    </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
