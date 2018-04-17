<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlan_UI.aspx.cs" Inherits="UI.HR.KPI.WorkPlan_UI" %>

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
    <div class="tabs_container" align="Center" >Work Plan</div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #808080;"class="tblrowodd" >
          
           <tr  class="tblrowodd">
           <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Subject:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtSubject" runat="server" CssClass="txtBox" Width="600px" Font-Bold="False"></asp:TextBox>
          </tr>
           <tr>
               <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="Description:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtDescription" runat="server" CssClass="txtBox" Font-Bold="False" Height="75px" Width="600px" TextMode="MultiLine"></asp:TextBox>
      
           </tr>
           
           <tr>
             <td style="text-align:right;"> <asp:Label ID="Label2" font-size="small" runat="server" CssClass="lbl" Text="Attachment:"></asp:Label></td>
    
            <td><asp:FileUpload ID="UploadWpaln" runat="server" Width="457px" />
             <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
           

           </tr>
           <tr><td colspan="2"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
            <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="530px"/></asp:TemplateField>

                                              
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>
                  
         
             
           
            
             <tr>
                      
          
                
              <td></td>
                 <td style="text-align:right;">  <asp:HiddenField ID="hdnField" runat="server" />
                       <a class="nextclick" onclick="Save()">Submit</a> </td>
          
            </tr>
           </table> 
       
         
             <table>
                 <caption>
                     Work Plan Summary :<hr /></caption>
                       </div>
        </tr>
                <td>
                    <asp:GridView ID="dgvStatus" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.N">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="intAutoID" HeaderText="ID" SortExpression="intAutoID" Visible="false" />
                            <asp:BoundField DataField="strWordetalis" HeaderText="Description" SortExpression="strWordetalis">
                            <ItemStyle HorizontalAlign="Left" Width="200px" ></ItemStyle >
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Detalis">
                                <ItemTemplate>
                                    <asp:Button ID="BtnDetalisView" runat="server" CommandArgument='<%# Eval("intAutoID")%>' CommandName="Detalis" OnClick="BtnDetalisView_Click" Text="Detalis" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </td>
                </table>
                  </div>
        
     
                   
            
       
      
        
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
