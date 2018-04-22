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
      
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.rawgit.com/elevateweb/elevatezoom/master/jquery.elevateZoom-3.0.8.min.js"></script>
    <script type="text/javascript">
    $(function () {
    $("[id*=GridView1] img").elevateZoom({
        cursor: 'pointer',
        imageCrossfade: true,
        loadingIcon: 'loading.gif'
    });
    });
    </script>

    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 
     <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function CloseHdnDiv() {
             $("#hdnDivision").fadeOut("slow");
         }
    </script>
      <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;    width: Auto; 
    	    height: auto;
            background-color:#FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
            
          
        }
    .frame { width: 60%; height: 300px; border: 0px; }
    .frame {zoom: 0.99;-moz-transform: scale(0.99);-moz-transform-origin: 0 0;-o-transform: scale(0.99);-o-transform-origin: 0 0;
    -webkit-transform: scale(0.99);-webkit-transform-origin: 0 0}
    </style>
     
</head>

<body>

     <form id="frmaccountsrealize" runat="server"> 

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
            <td style="text-align:left" colspan="3"><asp:FileUpload ID="DocUpload" Width="300px"  runat="server"  /> 
             <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /></td>
           
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
                <asp:Button ID="btnDocView" runat="server" Text="View"   OnClick="btnDocView_Click" CommandArgument='<%# Eval("strFtpPath") %>'  /></ItemTemplate>
                    
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="Detalis">  <ItemTemplate>
                <asp:Button ID="btnDownload" runat="server" Text="Download"   OnClick="btnDownload_Click"  CommandArgument='<%# Eval("strFtpPath") %>'  /></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                
            </Columns> 
            </asp:GridView></td> 
        </tr>  
       </table> 
        <table>
            
        <asp:GridView ID="GridView1" runat="server" Width="1000px" AutoGenerateColumns="false" ShowHeader = "false">
        <Columns>
        <asp:TemplateField >
        <ItemTemplate>
        <img width="500" src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' alt="" data-zoom-image='<%# ResolveUrl(Eval("ZoomImageUrl").ToString()) %>' />
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </table>
         <table>
            <asp:Image ID="imageView" runat="server" Height="600px" Width="1000px" ImageAlign="Baseline" EnableTheming="true" />
        </table>

        </div>
           

  
<%--=========================================End My Code From Here=================================================--%>

   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
