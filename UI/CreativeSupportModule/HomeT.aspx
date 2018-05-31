<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeT.aspx.cs" Inherits="UI.Task_Module.HomeT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Creative Support </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <style type="text/css"> 
    .rounds { height: 500px; width: 60px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #ffffff; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:40%; height: 60%; margin-left:5px; margin-top: 120px; margin-right:50px; padding: 0px 20px 20px 20px;}    
    </style>

    <script language="javascript" type="text/javascript">       
        $("[id*=ckbAgree]").live("change", function () {
            
            if (this.checked) {
                document.getElementById('<%=btnGo.ClientID %>').style.visibility = "visible";
            }
            else {
                document.getElementById('<%=btnGo.ClientID %>').style.visibility = "Hidden";
            }
        });
        
        function ViewConfirmAgrementPage(Id) {
            window.open('AggrementPage.aspx?ID=' + Id, 'sub', "height=650, width=970, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }

        function ViewCustomerView(Id) {
            window.open('CustomerView.aspx?ID=' + Id, 'sub', "height=650, width=970, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />                 
    <div style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="2"><img src="img/Banner.png" width="100%"; height="120px" /></td></tr>            
            <tr style="text-align:center">
                <td style=" padding: 60px 0px 0px 0px"><asp:Button ID="btnCustomer" runat="server" CssClass="btnCustomer"  width=300px height=50px  Text="COUSTOMERS" Font-Bold="true" OnClick="btnCustomer_Click"/></td>  
                <td style=" padding: 60px 0px 0px 0px"><asp:Button ID="btnSupport" runat="server" CssClass="btnSupport"  width=300px height=50px Text="SUPPORTERS" Font-Bold="true" OnClick="btnSupport_Click"/></td>  
            </tr>
            
         </table>
     </div>

    <div id="hdnDivision" class="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">            
    <table class="tbldecoration" style="width:auto; float:left;">
        <tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 15px verdana;">X</a></td></tr>
        <tr><td>
        
        <tr><td>
            <p style="text-align:left; line-height: 160%; font-size:15px;">
                <span style="font:bold; font-weight:900; text-decoration:underline; padding-bottom:25px; font-size:22px;">Terms & Conditions:</span>
                <br /><span style="text-decoration:underline; font:bold; font-weight:900; text-justify:auto">Quantity:</span><span> Every single unique design will be counted as one (01) quantity. (For example, if you have
                02 different banner design which will be printed 2000 pieces then fill the Item: Banner, Quantity:02)</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">Note:</span><span> For any incomplete information (text, measurement etc.), any received job will be hold and
                the job sender will get a job hold message with explanation. In this case, job senders are requested
                to complete the information within 30 minutes, otherwise the next job on queue will be started.</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">Job Procedure:</span><span> Please collect the job code after submitting above information and wait for a while.
                You will get a mail if your job is received from this program and with completion of the job you will
                get completion message.</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">POSM & Item: </span><span> Final text & measurement are must. You may attach reference (if any) here.</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">Branding & Event:</span><span> Prior word order, PO ID & what kind (Large, Moderate & Minor) are must.</span>                 
            </p>
            </td></tr>
            <tr>
                <td>
                    <span style="font-size:35px"><asp:CheckBox ID="ckbAgree" runat="server" /></span>
                    <span style="font:bold; font-weight:900; padding-bottom:25px; font-size:22px;">I accept the terms & conditions in the agreement</span>
                </td>
                <td style="text-align:right; padding: 0px 0px 0px 0px; padding-top:18px"><asp:Button ID="btnGo" runat="server" class="myButton" style="" Text="GO >>>" ToolTip="Go To Customer Support" OnClick="btnGo_Click"/></td>                       
                <%--<td style="color:blue; font-weight:900; padding-top:20px"><a id="btnGo" href="" style="cursor:pointer; text-align:right; font-size:20px; color:blue; " onclick="">GO>>></a></td>--%>
            </tr>
        
        </table>
     </div>

    <div id="Footer" class="footer">
        <img height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" /> 
    </div>













    


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>