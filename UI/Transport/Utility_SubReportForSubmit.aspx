<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Utility_SubReportForSubmit.aspx.cs" Inherits="UI.Transport.Utility_SubReportForSubmit" %>
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
   
<script language="javascript" type="text/javascript">
    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }
    function Add() {
        var a, b;
        a = parseFloat(document.getElementById("txtGovFee").value);
        if (isNaN(a) == true) {
            a = 0;
        }
        var b = parseFloat(document.getElementById("txtIncidentalCost").value);
        if (isNaN(b) == true) {
            b = 0;
        }        
        document.getElementById("txtTotalCost").value = (a + b).toFixed(0);
        document.getElementById("txtTotalCost").readOnly = true;       
    }
</script>

<script>
    function FTPUpload() {
        document.getElementById("hdnconfirm").value = "2";
        __doPostBack();
    }
    function FTPUpload1() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();
    }
</script>

<script> function CloseWindow() {
     window.close();
 } </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>

</head>
<body>
    <form id="frmselfresign" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>    
<%--=========================================Start My Code From Here===============================================--%>
    <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox"  Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White" ></asp:TextBox>        
        <div class="leaveApplication_container"> 
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
        <asp:HiddenField ID="hdnDieselPerKMOutStation" runat="server" /><asp:HiddenField ID="hdnCNGPerKMOutStation" runat="server" />
        
        <div class="tabs_container"> SUB REPORT FOR SUBMIT <hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">        
              
        <tr>            
            <td style="text-align:right;"><asp:Label ID="lblLicenseno" runat="server" CssClass="lbl" Text="License/App No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtLicenseNo" runat="server" TextMode="MultiLine" CssClass="txtBox" Width="190px"></asp:TextBox></td>

            <td style="text-align:right;"><asp:Label ID="lblSubmitedDate" runat="server" CssClass="lbl" Text="Submite Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtSubmitedDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="110px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="txtSubmitedDate"></cc1:CalendarExtender></td>              
                   
            <td style="text-align:right;"><asp:Label ID="lblValidFromDate" runat="server" CssClass="lbl" Text="Valid From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtValidFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="110px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtValidFromDate"></cc1:CalendarExtender></td>               
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblValidToDate" runat="server" CssClass="lbl" Text="Valid To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtValidToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtValidToDate"></cc1:CalendarExtender></td>  
            
            <td style="text-align:right;"><asp:Label ID="lblExpireDate" runat="server" CssClass="lbl" Text="Expire Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtExpireDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="110px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtExpireDate"></cc1:CalendarExtender></td>                                

            <td style="text-align:right;"><asp:Label ID="lblNextSubmitedDate" runat="server" CssClass="lbl" Text="Next Submite Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtNextSubmitedDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="110px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtNextSubmitedDate"></cc1:CalendarExtender></td>                                
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblGovFee" runat="server" CssClass="lbl" Text="Gov-Fee :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtGovFee" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              
    
            <td style="text-align:right;"><asp:Label ID="lblIncidentalCost" runat="server" CssClass="lbl" Text="Incidental Cost :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtIncidentalCost" runat="server" CssClass="txtBox" Width="110px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              
            
            <td style="text-align:right;"><asp:Label ID="lblTotalCost" runat="server" CssClass="lbl" Text="Total Cost:"></asp:Label></td>
            <td style="text-align:left; color:grey;"><asp:TextBox ID="txtTotalCost" runat="server" CssClass="txtBox"  BackColor="LightGray" BorderColor="Gray" Width="110px"></asp:TextBox></td>                                                                                                    
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblRemarks" runat="server" CssClass="lbl" Text="Remarks :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="txtBox" Width="190px"></asp:TextBox></td>

            <td colspan="4"><asp:Button ID="btnSubmit" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" OnClientClick="FTPUpload1()" Text="Submit"/></td>
        </tr>


        <tr><td colspan="6"><hr /></td></tr>             
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Document Upload:<hr /></td></tr>       
        <tr class="tblrowodd">           
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Document Type :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDocType" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                       
            </td>            

            <td style='text-align: right; width:120px;'>Document Upload : </td>
            <td style='text-align: center;'>
                <asp:FileUpload ID="txtDocUpload" runat="server" AllowMultiple="true"/>                
            </td> <asp:HiddenField ID="hdnField" runat="server" />            
            <td style="text-align:right;"> 
            <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
        </tr>    
        <tr><td colspan="10"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
            <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="530px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid" >
            <ItemTemplate><asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                           
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>

         </table>
    </div>

        <%--=========================================End My Code From Here=================================================--%>
       
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
