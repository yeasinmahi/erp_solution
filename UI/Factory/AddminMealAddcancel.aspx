<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddminMealAddcancel.aspx.cs" Inherits="UI.Factory.AddminMealAddcancel" %>
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
      
        .auto-style5 {
            width: 190px;
        }
      
        .auto-style6 {
            width: 11px;
            height: 38px;
        }
        .auto-style8 {
            height: 38px;
        }
        .auto-style9 {
            width: 67px;
            height: 38px;
        }
      
        .auto-style10 {
            height: 34px;
        }
      
        .auto-style11 {
            height: 38px;
            width: 215px;
        }
        .auto-style12 {
            width: 215px;
        }
      
        .auto-style13 {
            width: 151px;
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
             document.getElementById('HdfSearchbox').value = 'true';
         }
         function SearchText() {
             $("#txtCustomer").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "AutoChallan.aspx/GetAutoCompleteData",
                         data: '{"strSearchKey":"' + document.getElementById('txtCustomer').value + '"}',
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
                                <table style="background-color:#C0C0C0;width:65%">
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;" class="auto-style5">
                                            Unit Name
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" Width="220px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShip_SelectedIndexChanged1" >
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
<td align="right" class="auto-style11">
                                From
                                <asp:TextBox ID="txtFrom" Enabled="false" CssClass="txtbox" runat="server" OnTextChanged="txtFrom_TextChanged1"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="yyyy/MM/dd"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender><img id="imgCal_1" src="../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />  
                            
                            </td>
                            <td class="auto-style8">
                                <asp:HiddenField ID="hdntodate" runat="server" /> To
                                <asp:TextBox ID="txtTo" Enabled="false"  runat="server" CssClass="txtbox" OnTextChanged="txtTo_TextChanged1"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="yyyy/MM/dd"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                
                                <img id="imgCal_2" src="../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                               



                            </td>
                            <td class="auto-style9">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp
                            </td>
                            <td align="right" class="auto-style12">
                              
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
            <asp:HiddenField ID="hdnTo" runat="server" />
            <asp:HiddenField ID="HdfSearchbox" runat="server" />
            <asp:HiddenField ID="hdnCustomer" runat="server" />
            <table class="">
                <tr>
                    <td class="auto-style10">
                        <asp:RadioButton ID="RadioButton1" AutoPostBack="true" GroupName="Cancel" Text="Cancel" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
                        <asp:RadioButton ID="RadioButton2" AutoPostBack="true" GroupName="Cancel" Text="Guest Indent" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" />
                        <asp:RadioButton ID="RadioButton3" AutoPostBack="true" GroupName="Cancel" Text="E-Regular Indent" runat="server" OnCheckedChanged="RadioButton3_CheckedChanged" />
                    </td>
                    <td rowspan="3">
                        &nbsp;<asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                
             <asp:BoundField DataField="dtedate"  DataFormatString="{0:d}"  HeaderText="Date" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="qty" HeaderText="qty" ReadOnly="True" SortExpression="strregion"/>
                         <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="strregion"/>
                 
              <%--<asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("Custid") %>' />
              </ItemTemplate>
            </asp:TemplateField>--%>
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
                     <td  rowspan="3" class="auto-style13" >
                         <br />
                           <br />  <br />
                           <br />
                           <br />
                           <br />
                          <br />
                          <br />
                          <br />
                          <br />
                         &nbsp;<asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                
        
             <asp:BoundField DataField="strMenu" HeaderText="strMenu" ReadOnly="True" SortExpression="strregion"/>
                       
                 
              <%--<asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("Custid") %>' />
              </ItemTemplate>
            </asp:TemplateField>--%>
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
                         
                         
                         </diV>
                    </td>
                    
                </tr>
                <tr>
                    <td class="auto-style10"><asp:Label ID="Label1" runat="server" Text="">Employee Enroll :</asp:Label>
                        <asp:TextBox ID="TextBox1" CssClass="txtBox" runat="server"></asp:TextBox><br /><asp:Label ID="Label2" runat="server" Text="">Meal Qty :</asp:Label>
                        <asp:TextBox ID="TextBox2" CssClass="txtBox" runat="server"></asp:TextBox>

                        <asp:Button ID="btnShow" runat="server" Text="Submit" OnClick="btnShow_Click" />    </td>
                    
                </tr>
                <tr>
                    <td>
                    <h3>    &nbsp;</h3> 
                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                
             <asp:BoundField DataField="intEnroll" HeaderText="Enroll" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="strEmployeeName" HeaderText="Employee" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="monQty" HeaderText="Meal Qty" DataFormatString="{0:n0}" ReadOnly="True" SortExpression="strregion"/>
             <asp:BoundField DataField="monDiscount" DataFormatString="{0:n0}" HeaderText="Disctount" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="monEmployeeContribute" DataFormatString="{0:n0}" HeaderText="Employee Contribute" ReadOnly="True" SortExpression="strregion"/>
              <asp:BoundField DataField="monPerMealPrice" DataFormatString="{0:n0}" HeaderText="Per Meal Price" ReadOnly="True" SortExpression="strregion"/>
             <asp:BoundField DataField="EmployeeMealCost"  DataFormatString="{0:n0}" HeaderText="Meal Cost" ReadOnly="True" SortExpression="strregion"/>
                         <asp:BoundField DataField="TotalMealCost" DataFormatString="{0:n0}" HeaderText="TotalMealCost" ReadOnly="True" SortExpression="strregion"/>
                 
                 
              <%--<asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("Custid") %>' />
              </ItemTemplate>
            </asp:TemplateField>--%>
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

                    <h4>    &nbsp;</h4>
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                
             <asp:BoundField DataField="intenroll" HeaderText="Enroll" ReadOnly="True" SortExpression="strline"/>
             <asp:BoundField DataField="dtedate" HeaderText="Date" ReadOnly="True" DataFormatString="{0:d}" SortExpression="strregion"/>
                 
              <%--<asp:TemplateField HeaderText="View">
              <ItemTemplate>
              <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="Update" OnClientClick="Registration" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("Custid") %>' />
              </ItemTemplate>
            </asp:TemplateField>--%>
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

