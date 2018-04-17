<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransportSet.aspx.cs" Inherits="UI.SAD.AutoChallan.TransportSet" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    
    
    
    
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







    <style type="text/css">
        .hide
        {
            display: none;
        }
        .auto-style1 {
            width: 11px;
        }
        .auto-style2 {
            width: 31px;
        }
        .auto-style3 {
            width: 67px;
        }
      
        .auto-style4 {
            width: 88px;
        }
      
        .auto-style5 {
            width: 190px;
        }
      
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
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtVehicleno").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "TransportSet.aspx/GetAutoCompleteData",
                         data: '{"strSearchKey":"' + document.getElementById('txtVehicleno').value + '"}',
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


     <script>
         $(document).ready(function () {
             SearchTexts();
         });
         function Changeds() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchTexts() {
             $("#txtdrivername").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "TransportSet.aspx/GetAutoCompleteDatas",
                         data: '{"strSearchKey":"' + document.getElementById('txtdrivername').value + '"}',
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
                        <table style="background-color: #C0C0C0; width: 65%">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td style="width: 30px;"></td>
                                <td class="auto-style5" style="text-align: right;">Ship Point </td>
                                <td>
                                    <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShip_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 30px;"></td>
                                <td style="text-align: right; width: 220px">Sales Office </td>
                                <td>
                                    <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSo_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 30px;"></td>
                                <td class="auto-style2" style="text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; </td>
                    <td align="right" class="auto-style4">From </td>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server" Enabled="false" Height="22px" OnTextChanged="txtFrom_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />

                        <asp:RadioButton ID="RadioButton1" GroupName="vehicleprogram" Text="Pending" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged1" /><asp:RadioButton GroupName="vehicleprogram" Text="Vehicle Report" AutoPostBack="true" ID="RadioButton2" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged1" />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" style="height: 26px" Text="Show" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; </td>
                    <td align="right" class="auto-style4"></td>
                    <td></td>
                    <td align="right">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" colspan="6" style="color: Green; height: 40px; vertical-align: bottom;">
                        <asp:HiddenField ID="hdnReport" runat="server" />
                    </td>
                </tr>
            </table>
                </div>
            </asp:Panel>
            <div style="height: 170px;">
   
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            
            <asp:HiddenField ID="hdnFrom" runat="server" />
            
            <asp:HiddenField ID="HdfTechnicinCode" runat="server" />
            <asp:HiddenField ID="hdnvehicle" runat="server" />
            <asp:HiddenField ID="hdnsuplier" runat="server" />

            <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
            <asp:HiddenField ID="hdndriversearchBox" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Vehicle No     :</asp:Label>&nbsp &nbsp
                       
                    </td>
                    <td>    <asp:TextBox ID="txtVehicleno" onchange="javascript: Changed();"  runat="server" CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                   </td>
                </tr>
                <tr>
                    <td>
                          <asp:Label ID="Label2" runat="server" Text="Label">Driver Name:</asp:Label>
                      </td>
                    <td>
                           <asp:TextBox ID="txtdrivername"  onchange="javascript: Changeds();"   runat="server" CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" OnTextChanged="txtVehicle1_TextChanged"></asp:TextBox>

                   
                    </td>
                </tr>
                  <tr>
                    <td>
                          <asp:Label ID="Label3" runat="server" Text="Label">Mobile No:</asp:Label>
                           </td>
                      <td>
                           <asp:TextBox ID="txtmobileno" onchange="javascript: Changed();"  runat="server" CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                
                      </td>
                </tr>
                 <tr>
                    <td>
                      <asp:Label ID="Label4" runat="server" Text="Label">Vehicle Owner:</asp:Label>
                    </td>
                      <td>
                          <asp:RadioButton ID="RadioButton3" Text="Company" AutoPostBack="true" GroupName="company" runat="server" OnCheckedChanged="RadioButton3_CheckedChanged" /><asp:RadioButton AutoPostBack="true" GroupName="company"  ID="RadioButton4" Text="3rd Party" runat="server" OnCheckedChanged="RadioButton4_CheckedChanged" />

                        <asp:Button ID="Button3" runat="server" Text="Submit" OnClick="Button2_Click1" style="height: 26px" />
                
                      </td>
                </tr>
                  <tr>
                    <td>
                      <asp:Label ID="Label5" runat="server" Text="Label">Vehicle Owner Name:</asp:Label>
                    </td>
                      <td>
                          <asp:TextBox ID="txtVehicleSuplier" runat="server"></asp:TextBox>
                
                      </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
                     BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black"   GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" Font-Names="Calibri">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                  <asp:TemplateField>   
                      <HeaderTemplate>    
                          <asp:CheckBox ID="chkAllSelect" runat="server" onclick="CheckAll(this);" />   
                       </HeaderTemplate>   
                       <ItemTemplate>   
                          <asp:CheckBox ID="chkSelect" runat="server" />   
                       </ItemTemplate>   
                   </asp:TemplateField> 


               <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("Custid") %>'></asp:Label></ItemTemplate>
              <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
              </FooterTemplate></asp:TemplateField>
            
             <asp:BoundField DataField="strline" HeaderText="line" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="strregion" HeaderText="Region" ReadOnly="True" SortExpression="strregion"/>
             <asp:BoundField DataField="strarea" HeaderText="Area" ReadOnly="True" SortExpression="strarea"/>
             <asp:BoundField DataField="strTerritory" HeaderText="Territory" ReadOnly="True" SortExpression="strTerritory"/>
             <asp:BoundField DataField="Point" HeaderText="Point" ReadOnly="True" SortExpression="Point"/>
             <asp:BoundField DataField="strName" HeaderText="strName" ReadOnly="True" SortExpression="strName"/>
              
             <asp:TemplateField HeaderText="Pending Qty" SortExpression="Pending">
             <ItemTemplate><asp:Label ID="lblPending" runat="server" Text='<%# (""+Eval("Pending","{0:n0}")) %>'></asp:Label></ItemTemplate>
             <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# Pendingtotals %>' /></FooterTemplate></asp:TemplateField>
<asp:BoundField DataField="StrVehicleno" HeaderText="Vehicle no" ReadOnly="True" SortExpression="strName"/>

         
          

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


           
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black"   GridLines="Vertical"  Font-Names="Calibri">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                <asp:TemplateField>   
                      <HeaderTemplate>    
                          <asp:CheckBox ID="chkAllSelect" runat="server" onclick="CheckAll(this);" />   
                       </HeaderTemplate>   
                       <ItemTemplate>   
                          <asp:CheckBox ID="chkSelect" runat="server" />   
                       </ItemTemplate>   
                   </asp:TemplateField> 


                          <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("Custid") %>'></asp:Label></ItemTemplate>
              <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
              </FooterTemplate></asp:TemplateField>
            
             <asp:BoundField DataField="strName" HeaderText="Cust Name" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="StrVehicleno" HeaderText="Vehicle No" ReadOnly="True" SortExpression="strregion"/>
             <asp:BoundField DataField="strDrivername" HeaderText="Driver name" ReadOnly="True" SortExpression="strarea"/>
             <asp:BoundField DataField="strmobileno" HeaderText="mobile no" ReadOnly="True" SortExpression="strTerritory"/>
          

            <asp:TemplateField HeaderText="Delete">
              <ItemTemplate>
              <asp:Button ID="Complete1" runat="server" Text="Delete" CommandName="complete"  OnClick="Updates1" OnClientClick="Registration" Font-Bold="true" BackColor="#cfcfcf"   CommandArgument='<%# Eval("Custid") %>' />
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
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
            ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
