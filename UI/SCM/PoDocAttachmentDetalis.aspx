<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoDocAttachmentDetalis.aspx.cs" Inherits="UI.SCM.PoDocAttachmentDetalis" %>

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
      
   

    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 

  
     
</head>

<body>

     <form id="frmaccountsrealize" runat="server">
   <%--<asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>


<%--=========================================Start My Code From Here===============================================--%>

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
    
       <div class="tabs_container" style="text-align:left">PO Attachemnt  From<hr /></div> 
       <table style="width:700px">
        <tr> 
        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Unit Name:"></asp:Label></td>
        <td  style="text-align:left;"><asp:Label ID="lblUnit" CssClass="lbl"  Font-Bold="true"   runat="server"></asp:Label></td>                                                                                      
         
        <td  style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Bill Amount:"></asp:Label></td>
        <td style="text-align:left;"><asp:Label ID="lblBillAmount" CssClass="lbl" Font-Bold="true"   runat="server"></asp:Label></td>  
        <td  style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="PO ID"></asp:Label></td>
        <td style="text-align:left;"><asp:Label ID="lblPoId" CssClass="lbl" Font-Bold="true"   runat="server"></asp:Label></td>  

        <td  style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Bill ID:"></asp:Label></td>
        <td style="text-align:left;"><asp:Label ID="lblBillId" CssClass="lbl" Font-Bold="true"   runat="server"></asp:Label></td>
        <td  style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Bill Reg No:"></asp:Label></td>
        <td style="text-align:left;"><asp:Label ID="lblBillReg" CssClass="lbl" Font-Bold="true"   runat="server"></asp:Label></td>  
            
        </tr> 
        </table>
        <table style="width:600px">
           <tr>
            <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="File Group:"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlFileGroup" runat="server" CssClass="ddList"> 
            </asp:DropDownList></td> 
            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="Note :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtNote" runat="server"  CssClass="txtBox" Width="300px"></asp:TextBox></td> 
            </tr>
            <tr>
            <td style="text-align:right;"><asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Attachment :"></asp:Label></td>
            <td style="text-align:left" colspan="2"><asp:FileUpload ID="DocUpload" Width="300px"  runat="server"  /></td>
            <td><asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /></td>
           
           </tr>
      
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvDocument" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="600px"  
                CssClass="GridViewStyle">            
                <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
                <asp:TemplateField HeaderText="DocID" SortExpression="intFileID"><ItemTemplate>
                <asp:Label ID="lblDocId" runat="server" Width="60px" Text='<%# Bind("intFileID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="File Group" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strFileName" >
                <ItemTemplate><asp:Label ID="lblFileName" runat="server" Width="130px"  Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

                <asp:TemplateField HeaderText="Document Note" ItemStyle-HorizontalAlign="right" SortExpression="strRemarks" >
                <ItemTemplate><asp:Label ID="lblNote" runat="server"  Width="150px" Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="File Path" ItemStyle-HorizontalAlign="right" SortExpression="strFtpPath" >
                <ItemTemplate><asp:Label ID="lblFilePath" runat="server" Width="70px"  Text='<%# Bind("strFtpPath") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="Detalis">  <ItemTemplate>
                <asp:Button ID="btnDownload" runat="server" Text="Download"   OnClick="btnDownload_Click"  CommandArgument='<%# Eval("strFtpPath") %>'  /></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            </Columns> 
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
