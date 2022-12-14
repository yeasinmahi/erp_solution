<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetCheckReceive.aspx.cs" Inherits="UI.Asset.AssetCheckReceive" %>

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
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        </style>
    </head>
   <body>

         <script>
             function Registration(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=600,top=50,left=350, close=no');
                 if (window.focus) { newwindow.focus() }
             }
          </script>

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
   
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
   <asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="HdfTechnicinSearchbox" runat="server" /></td>
        <div class="leaveApplication_container"><table border="0"; style="width:Auto"; >
    <tr><td class="tblheader">Asset Receive :<asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnpoint" runat="server" /><asp:HiddenField ID="hdnunit" runat="server" /></td></tr>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="dgvGetpassRecieve" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.N">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID"/>
                                <asp:BoundField DataField="strAssetID" HeaderText="AssetID" SortExpression="strAssetID"/>
                                <asp:BoundField DataField="strNameOfAsset" HeaderText="AssetName" SortExpression="strNameOfAsset"/>
                                <asp:BoundField DataField="strAssetTypeName" HeaderText="AssetType" SortExpression="strAssetTypeName"/>
                                <asp:BoundField DataField="strNarration" HeaderText="Narration" SortExpression="strNarration"/>
                                <asp:BoundField DataField="fromaddress" HeaderText="FromAddress" SortExpression="fromaddress" />
                                <asp:TemplateField HeaderText="Receive">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("intID")%>' CommandName="WorkOrder" OnClick="Button1_Click" Text="Receive" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
                 </div>

               
              

                   <div class="leaveSummary_container"> 
                 <div class="tabs_container">
                     <caption>
                         Asset Receive Summary :<hr /></caption>
                       </div>
                 <td>
                      <asp:GridView ID="dgvStatus" runat="server" AutoGenerateColumns="False">
                         <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="strAssetID" HeaderText="Asset ID" SortExpression="strAssetID" />
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
                             
                         </Columns>
                     </asp:GridView>
                 </td>
                 </div>
        
             </tr>
       
         </div>




         
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>