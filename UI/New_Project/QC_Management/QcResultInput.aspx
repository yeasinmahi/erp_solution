<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QcResultInput.aspx.cs" Inherits="UI.QC_Management.QcResultInput" %>

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
  

   
      
    </style>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=700,top=50,left=200, close=no');
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
            width: 4px;
        }
        .auto-style2 {
            width: 8px;
        }
        .auto-style3 {
            width: 10px;
        }
        .auto-style4 {
            width: 11px;
        }
        .auto-style5 {
            width: 13px;
        }
        .auto-style6 {
            width: 17px;
        }
        .auto-style7 {
            width: 18px;
        }
        .auto-style8 {
            width: 20px;
        }
        .auto-style9 {
            width: 21px;
        }
        .auto-style10 {
            width: 130px;
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
                                <table style="width:65%">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style5">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
            <asp:HiddenField ID="hdnQC" runat="server" />
            <asp:HiddenField ID="hdnwh" runat="server" />
            <asp:HiddenField ID="HdfSearchbox" runat="server" />
            <asp:HiddenField ID="hdnCustomer" runat="server" />
            <asp:HiddenField ID="hdnattributecatagory" runat="server" />
               <table>
                   <tr>
                       <td>
            
                 <table style="background-color:lightgray">
                     <tr>
                         <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                             </td>
                     </tr>
                   
                        
                        <tr>
                            <td>
                                <table style="width:80%">
                                    <tr>

                                     <td >
                                         <asp:Label ID="Label2" runat="server" Text="Select Unit/Ssection: "></asp:Label>
                                     </td>
                                      
                                      <td class="auto-style10" >
                                          <asp:DropDownList ID="ddlwh" Width="120px" runat="server" OnSelectedIndexChanged="ddlwh_SelectedIndexChanged"></asp:DropDownList>

                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                   </tr>

                                     <tr>

                                     <td >
                                         <asp:Label ID="Label5" runat="server" Text="Select Catagory : "></asp:Label>
                                     </td>
                                      
                                      <td style="text-align:left" colspan="3" >
                                          <asp:RadioButton ID="RadioButton2" runat="server" GroupName="FG" Text="PO" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged" />
                                          <asp:RadioButton ID="Radiobuttoin3" runat="server" GroupName="FG" Text="Finish Goods" AutoPostBack="true" OnCheckedChanged="Radiobuttoin3_CheckedChanged" />
                                          <asp:RadioButton ID="RadioButton14" runat="server" GroupName="FG" Text="WIP" AutoPostBack="true" OnCheckedChanged="RadioButton4_CheckedChanged" />

                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                   </tr>



                                     <tr>

                                     <td >
                                         <asp:Label ID="Label3" runat="server" Text="PO Type:"></asp:Label>
                                     </td>
                                      
                                      <td class="auto-style10">
                                          <asp:DropDownList ID="ddlPOType" Width="120px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPOType_SelectedIndexChanged">
                                              <asp:ListItem Value="0">Local</asp:ListItem>
                                              <asp:ListItem Value="1">Import</asp:ListItem>
                                              <asp:ListItem Value="0">Febrication</asp:ListItem>
                                          </asp:DropDownList>

                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                   </tr>
                                  <tr>

                                     <td >
                                         <asp:Label ID="Label1" runat="server" Text="PO/Production No:"></asp:Label>
                                     </td>
                                      
                                      <td class="auto-style10">
                                          <asp:DropDownList ID="ddlpo" Width="120px" runat="server" OnSelectedIndexChanged="ddlpo_SelectedIndexChanged" AutoPostBack="True" style="height: 22px"></asp:DropDownList>

                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                   </tr>
                                     <tr>

                                     <td >
                                         <asp:Label ID="Label4" runat="server" Text="Invoice No :"></asp:Label>
                                     </td>
                                      
                                      <td class="auto-style10">
                                          <asp:DropDownList ID="ddlinvoiceno" Width="120px" runat="server" OnSelectedIndexChanged="ddlinvoiceno_SelectedIndexChanged"></asp:DropDownList>

                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                   </tr>
                                     <tr>

                                     <td >
                                         <asp:Label ID="Label6" runat="server" Text="Production No :"></asp:Label>
                                     </td>
                                      
                                      <td class="auto-style10">
                                          <asp:DropDownList ID="ddlproductionid" Width="120px" runat="server" OnSelectedIndexChanged="ddlproductionid_SelectedIndexChanged"></asp:DropDownList>

                                      </td>
                                      <td>
                                          &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                   </tr>
                                     <tr>
                                     <td >
                                         &nbsp;</td>
                                         <td class="auto-style10" >
                                             &nbsp;</td>
                                      <td>
                                          &nbsp;</td>
                                         <td>
                                             <asp:Button ID="Button2" runat="server" Text="Show" OnClick="Button2_Click" style="height: 26px" />
                                         </td>
                                   </tr>
                                 </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td>


           
        
                        
                        
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="13px" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" >
                <AlternatingRowStyle BackColor="#CCCCCC" />

                               <Columns>


                                   <asp:BoundField DataField="intitem"  HeaderText="itemid" SortExpression="intAccountID" />
                                   <asp:BoundField DataField="stritem"  HeaderText="Item Name"  />
                                   <asp:BoundField DataField="strDes" HeaderText="Des" ReadOnly="True" SortExpression="date" />
                                   <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strParticulars" />
                                   <asp:BoundField DataField="numPOQty"  HeaderText="Qty"  />
                                   <asp:BoundField DataField="monValue"  HeaderText="Value"  />
                                   <asp:BoundField DataField="monRate"  HeaderText="Rate"  />
                                   <asp:BoundField DataField="monVat"  HeaderText="Vat"  />
                                    <asp:BoundField DataField="monPreRcvQty"  HeaderText="PreRcvQty"  />
                                    <asp:BoundField DataField="ysnneedQC"  HeaderText="need QC"  />
                                   <asp:BoundField DataField="numQCQty"  HeaderText="Qc Qty"  />
                                    <asp:BoundField DataField="strLocationName"  HeaderText="Location Name"  />

                                      <asp:TemplateField HeaderText="View">
                                      <ItemTemplate>
                                      <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intitem") %>' />
                                      </ItemTemplate>
                                     </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                      <ItemTemplate>
                                      <asp:Button ID="Complete1" runat="server" Text="Report" CommandName="complete1"  OnClick="Update1" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intitem") %>' />
                                      </ItemTemplate>
                                     </asp:TemplateField>


                 </Columns>
                       <FooterStyle BackColor="#FFCC99" />
                 <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                        
                                                           
                                         </td>
                        </tr>
                    </table>
                  </td>
                   <td>

<div style=";border-bottom-left-radius:5px;border-bottom-right-radius:5px;box-shadow:0px 3px 3px 0px">  </div>




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

