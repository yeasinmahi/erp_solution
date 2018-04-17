<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpJobDescription_UI.aspx.cs" Inherits="UI.HR.KPI.EmpJobDescription_UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }


         </script> 
   
   

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
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
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>






<%--=========================================Start My Code From Here===============================================--%>
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center" >Routine Job Description</div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #808080;"class="tblrowodd" >
          
           <tr  class="tblrowodd">
           <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Enroll:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtEnroll" runat="server" CssClass="txtBox" Width="500px" AutoPostBack="true" Font-Bold="False" OnTextChanged="TxtEnroll_TextChanged" ></asp:TextBox>
         <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtEnroll"
            ServiceMethod="GetEmployeeName" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>
               <asp:HiddenField ID="HiddenEmpCode" runat="server" /></td>
              
              
              
           </tr>
            
           <tr>
         <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="Description:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtDescription" runat="server" CssClass="txtBox" Font-Bold="False"  Width="500px" TextMode="MultiLine"></asp:TextBox>
      
           </tr>
           <tr>
         <td style="text-align:right;"> <asp:Label ID="Label1" runat="server" font-size="small" CssClass="lbl" Text="Weight%:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtWeight" runat="server" CssClass="txtBox" Font-Bold="False"  Width="500px" ></asp:TextBox>
      
           </tr>
           <tr>
                <td style="text-align:right;"></td>
                 <td style="text-align:right;"> 
                     <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                   <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
           </tr>
           
         
          
            <tr><td colspan="2"> 
            <asp:GridView ID="dgvEmpView" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" ShowFooter="True" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
           
             <asp:TemplateField HeaderText="ID"  ><ItemTemplate>            
            <asp:Label ID="lblAutoID" runat="server" Text='<%# Bind("intAutoID") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>    
                 <asp:TemplateField HeaderText="Name" Visible="false" ><ItemTemplate>            
            <asp:Label ID="lblenroll" runat="server" Text='<%# Bind("strEmployeeName") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px">  </ItemStyle></asp:TemplateField>

            <asp:TemplateField HeaderText="JobDescription" ><ItemTemplate>            
            <asp:Label ID="lblFileName"  runat="server" Text='<%# Bind("strDescription") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="350px"> </ItemStyle></asp:TemplateField>
                <asp:TemplateField HeaderText="Weight" ><ItemTemplate>            
            <asp:TextBox ID="Txtweight" Width="50px" runat="server" Text='<%# Bind("decWeight") %>' ></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField>

                                              
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>
              
           </table> 
       
         
           
        
     
                   
            
       
      
        
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

