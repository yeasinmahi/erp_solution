<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocHistory.aspx.cs" Inherits="UI.Inventory.DocHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/Suppliercss.css" rel="stylesheet" />
    

    <%--<script>
        function SupApproval(reqsid) {
            window.open('IndentDetail.aspx?intIndent=' + reqsid, 'sub', "height=600, width=900, scrollbars=yes, left=200, top=45, resizable=no, title=Preview");
        }
    </script>--%>
    
      <script>
          function Registration(url) {
              newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
              if (window.focus) { newwindow.focus() }
          }
         </script>
    
    
    
    
    <style type="text/css">
        .auto-style32 {
            width: auto;
            float: left;
        }
    </style>
    
    
    
    
</head>
<body>
    <form id="frmauditdeptrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 40px; float: right;">&nbsp;</div></asp:Panel>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
  

       <table style="width:50%; text-align:center ">
          
              <caption>
                  <br>
                  <br>
                  <br>
                  <br>
                  <br>
                  <br></br>
                  <tr>
                      <td style="color: #109dc4; border: 2px solid #b2d0d9; border-radius: 5px;">
                          <h3><strong>My Document History<br></br>
                              </strong></h3>
                      </td>
                  </tr>
                  </br>
                                    
              </caption>
            </table>
           <table>
              <tr>
                  <td>
                      <asp:Label ID="lblDepartment" runat="server" Text="Department :"></asp:Label>
                  </td>
                  <td style="text-align: left">
                      <asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox" Width="210px" ></asp:TextBox>
<%--                                        <asp:TextBox ID="txtDepartment" runat="server" style= "width: 170px" CssClass="txtBox" readonly Text='<%# Bind("strDepatrment") %>' /></td> --%>

<%--                      <asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox>--%>
                  </td>

                  <td>
                      <asp:Label ID="lblDocType" runat="server" AutoPostBack="True" Text="Document Type :"></asp:Label>
                  </td>
                  <td>
                      <asp:DropDownList ID="ddlDT" runat="server" AutoPostBack="true" CssClass="ddList" OnSelectedIndexChanged="ddlDT_SelectedIndexChanged" style="width: 180px">
                      </asp:DropDownList>
                  </td>
                  <td class="auto-style6">
                      <asp:Button ID="btnShow" runat="server" Height="30px" OnClick="submit_Click" style="text-align: center" Text="Show" Width="117px" />
                  </td>
              </tr>
                </table>
              <table>
                  <tr class="tblroweven">
                      <td>
                           <%--<asp:GridView ID="dgvDocHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">--%>
                
                          <asp:GridView ID="dgvDocHistory" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Bold="false" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="dgvDocHistory_SelectedIndexChanged" ShowFooter="true">
                              <AlternatingRowStyle BackColor="#CCCCCC" />
                              <Columns>
                                  <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>                                
                                  <asp:BoundField DataField="intDocId" HeaderText="Doc ID" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
                                  <ItemStyle HorizontalAlign="center" Width="65px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="NARRATION" HeaderText="Details" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
                                  <ItemStyle HorizontalAlign="center" Width="65px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="strName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
                                  <ItemStyle HorizontalAlign="Left" Width="220px" />
                                  </asp:BoundField>
                                  <asp:TemplateField HeaderText="Request">
                                      <ItemTemplate>
                                          <asp:Button ID="Submit" runat="server"   CommandArgument='<%# Eval("intDocId") %>' CommandName="submit" OnClick="DocSubmit" ForeColor="red" Text="Submit" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                              </Columns>
                              <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                          </asp:GridView>
                      </td>
                  </tr>
                  <caption>
                    
                      </table>
              <br>
              <br>
        <br></br>
        <br>
        <br>
        <br></br>
        <br>
        <br>
        <br></br>
        </table>
        <%--=========================================END My Code From Here===============================================--%>
        <br></br>
        <br></br>
        <br></br>
        </br>
        </br>
        </br>
        </br>
        </br>
              </br>

         </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
