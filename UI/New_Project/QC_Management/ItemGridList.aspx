<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemGridList.aspx.cs" Inherits="UI.QC_Management.ItemGridList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    
     <%--<link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />--%>
    <%--<script src="../../Content/JS/datepickr.min.js"></script>--%>
   <%-- <script src="../../Content/JS/JSSettlement.js"></script>--%> 
  <%--  <link href="jquery-ui.css" rel="stylesheet" />--%>
   <%-- <script src="jquery.min.js"></script>--%>
   <%-- <script src="jquery-ui.min.js"></script>--%>
    <script type="text/javascript">
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=1000,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ShowPopUpC(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=650,width=750,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ValidateComplete(sender, args) {
            if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>

   
      
    </style>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }



    </script>
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('HdfSearchbox').value = 'true';
        }
        function SearchText() {
            $("#txtCustomer").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "ItemAttributeAdd.aspx/GetAutoCompleteData",
                        //data: '{"strSearchKey":"' + document.getElementById('txtCustomer').value + '"}',
                        data: '{"whid":"' + $("#hdnwh").val() + '","strSearchKey":"' + document.getElementById('txtCustomer').value + '"}',
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {

                        }
                    });
                }
            });
        }
    </script>
    <style>
        textboxs {
        
        background:#f3eded;
        border-radius: 2px;
        }
        .auto-style1 {
            height: 23px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table style="width: 65%;">
                        <tr>                             
                            <td colspan="6">
                                <table style="background-color:#C0C0C0;width:65%">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style5">
                                            Unit</td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" Width="220px" runat="server" AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;width:220px">
                                            &nbsp;</td>
                                        <td>
                                           
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style2">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style7">
                                &nbsp;</td>
                            <td class="auto-style8">
                                &nbsp;</td>
                            <td align="right" class="auto-style8">
                                </td>
                            <td class="auto-style8">

                                &nbsp;</td>
                            <td class="auto-style9">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style4">
                              
                            </td>
                            <td>
                                

                                    &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5" class="auto-style1">
                                &nbsp;</td>
                           
                          
                        </tr>
                        <tr>
                            <td colspan="6" align="right" style="color:Green; height:40px; vertical-align:bottom;">    
                                &nbsp;</td>
                        </tr>
                    </table>
                    
                </div>
            </asp:Panel>
            <div style="height: 170px;">

                
                
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            
            <asp:HiddenField ID="hdnwh" runat="server" />
            <asp:HiddenField ID="HdfSearchbox" runat="server" />
            <asp:HiddenField ID="hdnCustomer" runat="server" />
            <asp:HiddenField ID="hdnattributecatagory" runat="server" />
               <table>
                   <tr>
                       <td>
            
                 <table style="background-color:lightgray">
                     <tr>
                         <td><asp:Label ID="Label6" runat="server">Item Cluster :</asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                             <asp:DropDownList ID="ddlcatagory" Width="120px"  runat="server" OnSelectedIndexChanged="ddlcatagory_SelectedIndexChanged" AutoPostBack="True">
                                                 <asp:ListItem Value="44">Finish Goods</asp:ListItem>
                                                 <asp:ListItem Value="45">Raw/Other Materials</asp:ListItem>
                                                 <asp:ListItem Value="46">Work in Process (WIP)</asp:ListItem>
                                             </asp:DropDownList>
                         </td>
                     </tr>
                        <tr>
                            <td class="auto-style1"></td>
                    
                        </tr>
                        
                        <tr>
                            <td>
                                <table>
                                
                                    
                                 </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td>


           
        
                        
                        
             <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    
            
             <asp:BoundField DataField="intItemID" HeaderText="line" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="strItemName" HeaderText="Item Name" ReadOnly="True" SortExpression="strregion"/>
            
             
           
           
            <asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intItemID") %>' />
              </ItemTemplate>
            </asp:TemplateField>
                    </Columns>
                <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                        
                                                           
                                         </td>
                        </tr>
                    </table>
                  </td>
                 
                  </tr>
                </table>


            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
            ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>


