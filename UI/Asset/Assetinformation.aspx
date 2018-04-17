<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assetinformation.aspx.cs" Inherits="UI.Asset.Assetinformation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>

     <script>
       
         function isNumber(evt) {
             var iKeyCode = (evt.which) ? evt.which : evt.keyCode
             if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                 return false;
             return true;
         }

         function Confirm() {
             document.getElementById("hdnconfirm").value = "0";
             var txt1 = document.forms["frmpdv"]["txtdagcs"].value;
             var txt2 = document.forms["frmpdv"]["txtdagsa"].value;
             var txt3 = document.forms["frmpdv"]["txtdagrs"].value;
             var txt4 = document.forms["frmpdv"]["txtdagbrs"].value;
             if (txt1 == null || txt1 == "") {
                 alert("Four box must be filledd");
                 document.getElementById("txtdagcs").focus();
             }
           
             else {
                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                 if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                 else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
             }
         }
</script>

  <script>
        function RemoveRow(item) {
        var table = document.getElementById('GridView1');
        table.deleteRow(item.parentNode.parentNode.rowIndex);
        return false;
        }

    </script>
     <script type="text/javascript">
         $('input.required').each(function () {
             $(this).prev('label').after('*');
         });

    </script>

</head>
<body>
    <form id="frmpdv" runat="server">
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
        <div class="leaveApplication_container"> 
    <div class="tabs_container"> Asset Information update  :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/> <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
       <asp:HiddenField ID="HiddenField1" runat="server"/>
        <asp:HiddenField ID="HiddenField2" runat="server"/><asp:HiddenField ID="HiddenField3" runat="server"/><asp:HiddenField ID="HiddenField4" runat="server" />
        
        <asp:HiddenField ID="HiddenField5" runat="server"/> <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
        <hr /></div>
        <table border="0"; style="width:Auto"; > 
            <tr><td style="text-align:right"><asp:Label ID="Labeldagcs" CssClass="lbl" runat="server" Text="DAG CS:  " ></asp:Label></td>
            <td> <asp:TextBox ID="txtdagcs" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
            <td style="text-align:right"><asp:Label ID="Labeldagsa" CssClass="lbl" runat="server" Text="DAG SA:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtdagsa" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
                
            <td style="text-align:right"><asp:Label ID="Labeldagrs" CssClass="lbl" runat="server" Text="DAG RS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtdagrs" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td></tr>                
           
             <tr>
                  <td style="text-align:right"><asp:Label ID="Labeldagbrs" CssClass="lbl" runat="server" Text="DAG BRS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtdagbrs" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td> 
            <td style="text-align:right"><asp:Label ID="lblkhatiancs" CssClass="lbl" runat="server" Text="Khatian CS:  " ></asp:Label></td>
            <td> <asp:TextBox ID="txtkhatiancs" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
            <td style="text-align:right"><asp:Label ID="lblkhatiansa" CssClass="lbl" runat="server" Text="Khatian SA:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtkhatiansa" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
             <tr>
                  <td style="text-align:right"><asp:Label ID="lblkhatianrs" CssClass="lbl" runat="server" Text="Khatian RS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtkhatianrs" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
                                 
            <td style="text-align:right"><asp:Label ID="lblkhatianbrs" CssClass="lbl" runat="server" Text="Khatian BRS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtkhatianbrs" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td> 
            <td><asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick = "Confirm()" Text="Add" /></td>
            <td><asp:Button ID="btnSubmit" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click" OnClientClick = "Confirm()"/></td></tr>
           </div>  

        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td><asp:GridView ID="grdvassetinfo" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvassetinfo_RowDataBound" OnRowDeleting="grdvassetinfo_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                        
                    <Columns>
                     <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("dagcs") %>' /></ItemTemplate></asp:TemplateField> 
                    <asp:BoundField DataField="dagcs" HeaderText="DAG CS" SortExpression="dagcs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="dagsa" HeaderText="DAG SA" SortExpression="dagsa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="dagrs" HeaderText="DAG RS" SortExpression="dagrs" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                    <asp:BoundField DataField="dagbrs" HeaderText="DAG BRS" SortExpression="dagbrs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                     <asp:BoundField DataField="khatiancs" HeaderText="Khatian CS" SortExpression="khatiancs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="khatiansa" HeaderText="Khatian SA" SortExpression="khatiansa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="khatianrs" HeaderText="Khatian RS" SortExpression="khatianrs" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                    <asp:BoundField DataField="khatianbrs" HeaderText="Khatian BRS" SortExpression="khatianbrs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    
                        
                        
                        
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

                  </Columns>




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