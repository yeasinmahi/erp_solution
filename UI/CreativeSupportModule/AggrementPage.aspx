<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AggrementPage.aspx.cs" Inherits="UI.CreativeSupportModule.AggrementPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. AGREEMENT </title>
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

    <script>
        <%--$("[id*=ckbAgree]").live("change", function () {

            if (this.checked) {
                //document.getElementById('<%=btnGo.ClientID %>').style.visibility = "visible";
                document.getElementById("btnGo").disabled = true;
            }
            else {
                //document.getElementById('<%=btnGo.ClientID %>').style.visibility = "Hidden";
                document.getElementById("btnGo").disabled = false;
            }
        });--%>

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
    <asp:HiddenField ID="hdnJobID" runat="server" /><asp:HiddenField ID="hdnJobStatusID" runat="server" />            
    <div style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
        <table class="tbldecoration" style="width:auto; float:left; padding-bottom:15px;">
            <tr><td colspan="5"><img src="img/Banner.png" width="950px"; height="120px" /></td></tr> 
         </table>
    </div>
    <div style="text-align:center; padding-top:40px;"> <span style="font-size:20px; text-align:center; font-weight:bold;"> Terms & Conditions </span></div>
    <div class="divbody" style="margin-left:50px; margin-right:50px; margin-top:5px; padding-left:15px;">

        <table class="tbldecoration" style="width:auto; float:left;">
            
        <tr><td colspan="2">            
            <p style="text-align:left; line-height: 160%; font-size:15px; text-align:justify;">
                <span style="text-decoration:underline; font:bold; font-weight:900">Job Procedure:</span><span> Please collect the job code after submitting below information and get your job code from the supporters’ view. You will get a mail when your job is received by any supporter of job receiving status and with completion of the job you will get the completion message.</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">POSM & Item: </span><span> Final text & measurement are must. You may attach reference (if any) here. You can submit maximum 03 items in one Job Order at once.</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900; ">Quantity:</span><span> Every single unique design will be counted as one (01) quantity. (For example, if you have 02 different banner design which will be printed 2000 pieces then fill the Item: Banner, Quantity:02)</span> 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">Branding & Event:</span><span> Prior job type (Large, Moderate & Minor), PO ID & work order are must.</span>                 
                <br /><span style="text-decoration:underline; font:bold; font-weight:900">Note:</span><span> For any incomplete information (text, measurement etc.), any received job will be hold and the job sender will get a job hold message with explanation. In this case, job senders are requested to complete the information within 30 minutes, otherwise the next job on queue will be started automatically. With the completion of each job you’ll get feedback message. Your standard time for any feedback is 24 hours. </span>                 
            </p>
            </td></tr>
            <tr>
                <td>
                    <span style="font-size:35px"><asp:CheckBox ID="ckbAgree" runat="server" /></span>
                    <span style="font:bold; font-weight:900; font-size:22px;">I accept the terms & conditions in the agreement</span>
                </td>
                <td style="text-align:right; padding: 0px 0px 0px 0px; padding-top:30px; padding-bottom:20px;"><asp:Button ID="btnGo" runat="server" class="myButton" style="" Text="GO >>>" ToolTip="Go To Customer Support" OnClick="btnGo_Click"/></td>                       
                <%--<td style="color:blue; font-weight:900; padding-top:20px"><a id="btnGo" href="" style="cursor:pointer; text-align:right; font-size:20px; color:blue; " onclick="">GO>>></a></td>--%>
            </tr>
        
        </table>

    </div>

    <div >
        <img style="padding-top:40px" height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" /> 
    </div>
   

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>