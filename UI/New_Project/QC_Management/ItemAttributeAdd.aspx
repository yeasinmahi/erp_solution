<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemAttributeAdd.aspx.cs" Inherits="UI.QC_Management.ItemAttributAdd" %>
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
                                <table>
                                  <tr>
                                     <td>
                                      <asp:Label ID="lblItemName" runat="server">Item Name :</asp:Label>
                                       </td>
                                      <td>
                                           <asp:TextBox ID="txtitemname" runat="server" Width="180px" CssClass="textbox" ></asp:TextBox>
                                      </td>
                                      <td>
                                      <asp:Label ID="Label2" runat="server">Item Category :</asp:Label>
                               
                                       </td>
                                      <td>
                                          <asp:TextBox ID="txtcatagory" runat="server" Width="180px" CssClass="textbox" ></asp:TextBox>
                                      </td>
                                   </tr>
                                     <tr>
                                     <td>
                                      <asp:Label ID="Label3" runat="server">Item UOM :</asp:Label>
                              
                                       </td>
                                         <td> <asp:TextBox ID="txtuom" runat="server" Width="180px" CssClass="textbox" ></asp:TextBox></td>
                                      <td>
                             
                                       </td>
                                         <td>

                                     
                                         </td>
                                   </tr>
                                     <tr>
                                     <td>
                                      <asp:Label ID="Label5" runat="server">Attributes Type:</asp:Label>
                              
                                       </td>
                                         <td>

                                             <asp:RadioButton ID="RadioButton1" GroupName="Qc" AutoPostBack="true" Text="Specification" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                            <asp:RadioButton ID="RadioButton2" GroupName="Qc" AutoPostBack="true" Text="QC Test" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" />
                          
                                         </td>
                                      <td>
                                          &nbsp;</td>
                                         <td>

                                             &nbsp;</td>
                                   </tr>
                                    <tr>
                                        <td>
                                       
                                         <asp:Label ID="Label4" runat="server">Attributes :</asp:Label>
                                       </td>
                                         <td>
                                             
                                             <asp:DropDownList ID="ddlAttribute" Width="120px" runat="server"></asp:DropDownList></td>
                                      <td>
                                             </td>
                                         <td>
                                                     </td>
                                    </tr>
                                     <tr>
                                     <td>
                                       
                              <asp:Label ID="Label1" runat="server">Equepment :</asp:Label>
                                       </td>
                                         <td>
                                             <asp:RadioButton ID="RadioButton3" Text="Lab Equepment" GroupName="lab" runat="server" />



                                         </td>
                                      <td>
                                          <asp:Button ID="Button1" runat="server" BackColor="#00ccff" Text="Add" OnClick="Button1_Click" />
                                          </td>
                                         <td>
                                             <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" />
                                         </td>
                                   </tr>

                                     <tr>
                                        <td>
                                       
                                         <asp:Label ID="Label6" runat="server">Equepment Name :</asp:Label>
                                       </td>
                                         <td>
                                             
                                             <asp:DropDownList Width="120px" AutoPostBack="true" ID="ddllab" runat="server">
                                             </asp:DropDownList>
                                         </td>
                                      <td>
                                             </td>
                                         <td>
                                                     </td>
                                    </tr>
                                 </table>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td>


           
        
                        
                        
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="13px" BackColor="White" OnRowDeleting="GridView1_RowDeleting"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" >
                <AlternatingRowStyle BackColor="#CCCCCC" />

                               <Columns>

 
                                   <asp:BoundField DataField="itemAttribute"  HeaderText="itemAttribute"  />
                                   <asp:BoundField DataField="itemid"  HeaderText="itemid" SortExpression="intAccountID" />
                                   <asp:BoundField DataField="Itemmasterid" HeaderText="Itemmasterid" ReadOnly="True" SortExpression="date" />
                                   <asp:BoundField DataField="strattributecatagory" HeaderText="Attributes Category" SortExpression="strParticulars" />
                                   <asp:BoundField DataField="strlabEqptname" HeaderText="labEqptname" SortExpression="strlabEqptname" />
                                   <asp:BoundField DataField="labeqptid" HeaderText="labeqptid" SortExpression="labeqptid" />
                      
                          
                                    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" > 
                       
                                    <ControlStyle Font-Bold="True" ForeColor="Red"></ControlStyle>
                                   </asp:CommandField> 
                       
                 </Columns>
                       <FooterStyle BackColor="#FFCC99" />
                 <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                        
                                                           
                                         </td>
                        </tr>
                    </table>
                  </td>
                   <td>

<div style="background:#51b4ed;border-bottom-left-radius:5px;border-bottom-right-radius:5px;box-shadow:0px 3px 3px 0px"><h3>Item Attributes</h3>  </div>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Size="13px" BackColor="White"
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" >
                <AlternatingRowStyle BackColor="#CCCCCC" />

                               <Columns>

 
                                   <asp:BoundField DataField="strItemName"  HeaderText="Item Name"  />
                                   <asp:BoundField DataField="strattributename"  HeaderText="Attribute name" SortExpression="intAccountID" />
                                   <asp:BoundField DataField="strAttributesCatagory" HeaderText="Attributes Category" ReadOnly="True" SortExpression="date" />
                                              
                         
                       
                 </Columns>
                       <FooterStyle BackColor="#FFCC99" />
                 <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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

