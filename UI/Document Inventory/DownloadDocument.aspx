<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadDocument.aspx.cs" Inherits="UI.Document_Inventory.DownloadDocument" %>

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
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
    </style>
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
    </style>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub','scrollbars=yes,toolbar=0,height=500,width=600,top=10,left=10, close=yes');
             if (window.focus) { newwindow.focus() }
         }
         </script> 

    </head>
<body>
    <form id="form1" runat="server">

<%--=========================================Start My Code From Here===============================================--%>
              
          <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
        <div id="divcontentholder"class="tabs_container" >
        <table>
        

        <tr >
              

        <td style="text-align:right;" colspan="1"><asp:Label ID="lblEnroll" CssClass="lbl" runat="server" Text="Enroll:  "></asp:Label></td>
        <td><asp:TextBox ID="txtEnroll" runat="server" CssClass="txtBox" AutoPostBack="False"  Enabled="true" OnTextChanged="txtEnroll_TextChanged" ></asp:TextBox></td>
            <td><asp:Button ID="Btnshow" runat="server" Text="Show" OnClick="Btnshow_Click" /></td>
            <td style="text-align:right;" colspan="1"><asp:Label ID="LblUnit" CssClass="lbl" runat="server" Text="Unit:  "></asp:Label></td>
          <td><asp:TextBox ID="TxtUnit" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true" ></asp:TextBox></td>
            
        </tr>
        <tr>
        <td style="text-align:right;" colspan="1"><asp:Label ID="LblEmployee" CssClass="lbl" runat="server" Text="Employee Name:  "></asp:Label></td>
        <td  colspan="2"><asp:TextBox ID="TxtEmployee" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true" ></asp:TextBox></td>
        

            <td style="text-align:right;" colspan="1"><asp:Label ID="LblDesination" CssClass="lbl" runat="server" Text="Designation:  "></asp:Label></td>
          <td><asp:TextBox ID="TxtDesignation" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true" ></asp:TextBox></td>
            
      
         </tr>   
            <tr><td colspan="6">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
              <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
          
            <asp:BoundField DataField="strFtpFilePath" HeaderText="File Path" ItemStyle-HorizontalAlign="Center" SortExpression="strFtpFilePath">
            <ItemStyle HorizontalAlign="left" Width="300px"/></asp:BoundField>

          
            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnDocDownload" class="button" runat="server" Font-Size="9px" OnClick="btnDocDownload_Click"
            CommandArgument='<%# Eval("strFtpFilePath") %>' Text="Download Document" /></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Reject">
                    <ItemTemplate>
                        <asp:Button ID="BtbDelete" runat="server" CommandArgument='<%# Eval("intDocUploadID") %>' Text="Reject" OnClick="BtbDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="intDocUploadID" HeaderText="ID" SortExpression="intDocUploadID" Visible="False" />

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>

                </td></tr>
        </table>
            <table>
                <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                        <Columns>
                             <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                            <asp:BoundField DataField="intDocUploadID" HeaderText="ID" SortExpression="intDocUploadID" Visible="False" />
                            <asp:BoundField HeaderText="Enroll" DataField="intEnroll" SortExpression="intEnroll" />
                            <asp:BoundField HeaderText="JobStationName" DataField="strJobStationName" SortExpression="strJobStationName" />
                            <asp:BoundField HeaderText="Name" DataField="strEmployeeName" SortExpression="strEmployeeName" />
                            <asp:BoundField DataField="TypeName" HeaderText="Doc Type" SortExpression="TypeName" />
                            <asp:TemplateField HeaderText="Approve">
                                <ItemTemplate>
                                    <asp:Button ID="BtnApprove" runat="server"  Text="Approve" CommandName="Approve"  CommandArgument='<%# Eval("intDocUploadID")%>' OnClick="BtnApprove_Click"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reject">
                                <ItemTemplate>
                                    <asp:Button ID="BtnReject" runat="server" Text="Reject" CommandName="Reject"  CommandArgument='<%# Eval("intDocUploadID")%>' OnClick="BtnReject_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" Text="View" CommandArgument='<%# Eval("intDocUploadID") %>' CommandName="DocType" OnClick="Button1_Click"   />
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                        </Columns>
                    </asp:GridView>
                </td>
                </tr>
                
            </table>       
    </div>
    
   <%--=========================================End My Code From Here=================================================--%>

    </form>
</body>
</html>

