<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierApproval.aspx.cs" Inherits="UI.Inventory.SupplierApproval" %>
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

   


    <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function ClosehdnDivision() {

             $("#hdnDivision").fadeOut("slow");
         }
    </script>
      <script type="text/javascript">
    
       function Confirm() {
           document.getElementById("hdnconfirm").value = "0";
           var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
               if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
               else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
           }
       
</script>


        <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px;
           
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left:100px;  margin-top:100px; margin-right:400px; padding: 15px; overflow-y:scroll; }
        </style>
     

</head>
<body>
    <form id="frmauditdeptrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%" Height="18px">
    <div id="navbar"  style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 20px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 25px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
         <asp:HiddenField ID="hdnconfirm" runat="server" />
                
           <table>
                <%--<tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:initial; color:red; font:bold 10px verdana;">X</a></td></tr>--%>           
               <tr>

                     <td>
                  <asp:GridView ID="dgvSuppRequest" Width="1500px" runat="server" AutoGenerateColumns="False" BackColor="White" BorderStyle="None"  BorderWidth="1px" CellPadding="3" Font-Bold="False" Font-Size="11px" style="text-align: center; background-color: #8CD7FB;" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ShowFooter="True" BorderColor="#999999"   >
                      <AlternatingRowStyle BackColor="#DCDCDC" />
                  <Columns>
                    <asp:BoundField DataField="intSuppMasterID" HeaderText="ID" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="intSuppMasterID">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strSuppMasterName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="strReffNo">
                    <ItemStyle HorizontalAlign="center" Width="300px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgAddress">
                    <ItemStyle HorizontalAlign="center" Width="350px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgMail" HeaderText="Mail" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgMail">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgContactNo" HeaderText="Contact" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgContactNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgFAXNo" HeaderText="Fax" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgFAXNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strBusinessType" HeaderText="Business" ItemStyle-HorizontalAlign="Center" SortExpression="strBusinessType">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strServiceType" HeaderText="Service" ItemStyle-HorizontalAlign="Center" SortExpression="strServiceType">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strBIN" HeaderText="Bin" ItemStyle-HorizontalAlign="Center" SortExpression="strBIN">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strTIN" HeaderText="Tin" ItemStyle-HorizontalAlign="Center" SortExpression="strTIN">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strVATRegNo" HeaderText="VatR" ItemStyle-HorizontalAlign="Center" SortExpression="strVATRegNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strTradeLisenceNo" HeaderText="Trade Lic" ItemStyle-HorizontalAlign="Center" SortExpression="strTradeLisenceNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strReprName" HeaderText="CP Name" ItemStyle-HorizontalAlign="Center" SortExpression="strReprName">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strPayToName" HeaderText="PayTo" ItemStyle-HorizontalAlign="Center" SortExpression="strPayToName">
                    <ItemStyle HorizontalAlign="center" Width="200px" />
                    </asp:BoundField>
<%--                    <asp:BoundField DataField="strSupplierType" HeaderText="SType" ItemStyle-HorizontalAlign="Center" SortExpression="strSupplierType">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="dteEnlistmentDate" HeaderText="Enlist Date" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd}"  SortExpression="dteEnlistmentDate">
                    <ItemStyle HorizontalAlign="center" Width="110px" />
                    </asp:BoundField>
<%--                    <asp:BoundField DataField="dteLastActionTime" HeaderText="LastAct" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastActionTime">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>--%>
<%--                    <asp:BoundField DataField="ysnActive" HeaderText="Active" ItemStyle-HorizontalAlign="Center" SortExpression="ysnActive">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>--%>
                   <%-- <asp:BoundField DataField="Request_By" HeaderText="Request By" ItemStyle-HorizontalAlign="Center" SortExpression="Request_By">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>--%>

                        <asp:BoundField DataField="Request_By" HeaderText="Request By" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="Request_By">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>

<%--                    <asp:BoundField DataField="strShortName" HeaderText="ShortN" ItemStyle-HorizontalAlign="Center" SortExpression="strShortName">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>--%>
<%--                    <asp:BoundField DataField="intMasterSupplierType" HeaderText="Type" ItemStyle-HorizontalAlign="Center" SortExpression="intMasterSupplierType">
                    <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="intPreferedInstrument" HeaderText="Inst." ItemStyle-HorizontalAlign="Center" SortExpression="intPreferedInstrument">
                    <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="strACNO" HeaderText="A/C No" ItemStyle-HorizontalAlign="Center" SortExpression="strACNO">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strRoutingNo" HeaderText="Routing" ItemStyle-HorizontalAlign="Center" SortExpression="strRoutingNo">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="strBank" HeaderText="Bank" ItemStyle-HorizontalAlign="Center" SortExpression="strBank">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="strBranch" HeaderText="Branch" ItemStyle-HorizontalAlign="Center" SortExpression="strBranch">
                    <ItemStyle HorizontalAlign="center" Width="120px" />
                    </asp:BoundField>

                   <%-- <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><a class="button" style="Font-Size:10px; color:green" href="#" onclick="<%#  FilterControls(""+Eval("strSuppMasterName"),""+Eval("strOrgAddress"),""+Eval("strOrgMail"),""+
                    Eval("strOrgContactNo"),""+Eval("strOrgFAXNo"),""+Eval("strBusinessType"),""+Eval("strServiceType"),""+Eval("strBIN"),""+
                    Eval("strTIN"),""+Eval("strVATRegNo"),""+Eval("strTradeLisenceNo"),""+Eval("strReprName"),""+Eval("strPayToName"),""+Eval("strSupplierType")) %>">Approved</a></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>--%>
                    
                    <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                    <asp:Button ID="brnEdits" runat="server" Text="Edit" CommandName="complete" ForeColor="Blue" OnClick="Edit_Click" CommandArgument='<%# Eval("intSuppMasterID") %>' /></ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Approve">
                    <ItemTemplate>
                    <asp:Button ID="Approve" runat="server" Text="Approve" ForeColor="Green"  CommandName="complete1" OnClick="Approve_Click" CommandArgument='<%# Eval("intSuppMasterID") %>' /></ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Reject">
                    <ItemTemplate>
                    <asp:Button ID="Reject" runat="server" Text="Reject"  ForeColor="red" CommandName="complete2" OnClick="Complete2_Click" CommandArgument='<%# Eval("intSuppMasterID") %>' /></ItemTemplate>
                    </asp:TemplateField> 

                    <%--                strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, strReprName, 
                strPayToName, strSupplierType, dteEnlistmentDate, dteLastActionTime, ysnActive,intRequestBy,strShortName,intMasterSupplierType,intPreferedInstrument,strACNO, 
                strRoutingNo, strBank, strBranch--%>
                </Columns>
                      <FooterStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" Height="20px"/>
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="#FFFFFF" />
                      <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                      <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                      <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#F1F1F1" />
                      <SortedAscendingHeaderStyle BackColor="#0000A9" />
                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                      <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView></td></tr></table>

     </div>
       <%--  class="hdnDivision" --%>
         
                <div id="hdnDivision" class="hdnDivision"  style="width:800px; ">
                <table style="width:auto;  float:left; " >   
                <%--<tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:initial; color:red; font:bold 10px verdana;">X</a></td></tr>--%>           
                <tr><td style="text-align:justify;" colspan="4"><hr />
                    <caption>
                        <br />
                        <br />
                        <br />
                        <h1 class="auto-style30">New Supplier Enlistment</h1>
                        <fieldset class="row2">
                            <legend 10pt;="" font-size:="" style="color: #3399FF"><span class="auto-style20">Details</span> </legend>
                            <table style="height:auto">
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="lblSupname" runat="server" CssClass="lbl" Text="Supplier Name :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtSuppliername" runat="server" AutoPostBack="true" BackColor="white" BorderColor="Gray" BorderStyle="Ridge" CssClass="txtBox" OnTextChanged="txtSuppliername_TextChanged" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Contact :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtContactNo" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Address :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtAddress" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Fax No :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtFax" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Email :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtemail" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" ForeColor="Blue" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="BIN :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtBin" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Vat Reg. :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtVatReg" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="TIN :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtTin" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Trade License :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtTradeLicn" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="lblCategory" runat="server" CssClass="lbl" Text="Business Type :"></asp:Label>
                                    </td>
                                    <td class="auto-style1" style="text-align:left;">
                                        <asp:DropDownList ID="ddlBussType" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="ddList" Font-Bold="False" ForeColor="Black" Width="195px">
                                            <asp:ListItem>Proprietorship</asp:ListItem>
                                            <asp:ListItem>Partnership</asp:ListItem>
                                            <asp:ListItem>Company</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Contact Person :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtContactP" runat="server" BackColor="white" TextMode="Number" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Service Type :"></asp:Label>
                                    </td>
                                    <td class="auto-style1" style="text-align:left;">
                                        <asp:DropDownList ID="ddlservice" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="ddList" Font-Bold="False" ForeColor="Black" Width="195px">
                                            <asp:ListItem>Agent</asp:ListItem>
                                            <asp:ListItem>Dealer</asp:ListItem>
                                            <asp:ListItem>Retailer</asp:ListItem>
                                            <asp:ListItem>OEM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label13" runat="server" CssClass="lbl" Text="Phone No :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtPhone" runat="server" BackColor="white" BorderColor="Gray" TextMode="Number" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label7" runat="server" CssClass="lbl" Visible="false" Text="Supplier Type :"></asp:Label>
                                    <asp:Label ID="lblPOType" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="P.O Type:"></asp:Label>
                                    </td>
                                    <td class="auto-style1"style="font-weight:bold; text-align:right; color:#0b6016;">
                                        <asp:DropDownList ID="ddlSupplierType" runat="server" Visible="false" AutoPostBack="true" BackColor="Lightgray" BorderColor="Gray" CssClass="ddList" Font-Bold="False" ForeColor="Black" OnSelectedIndexChanged="ddlSupplierType_SelectedIndexChanged" Width="195px">
                                            <asp:ListItem Value="1">Local Purchase</asp:ListItem>
                                            <asp:ListItem Value="2">Local Fabrication</asp:ListItem>
                                            <asp:ListItem Value="3">Foreign Purchase</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblPOTypevalue" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label>
                                    </td>
                 <%--<td style="font-weight:bold; text-align:right; color:#0b6016;"></td>
                <td style="font-weight:bold; text-align:left; color:#3369ff;"></td>     --%>       


                                </tr>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Short Name :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtShortName" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Enlishment Date :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtEnlishmentDate" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Font-Bold="True" ForeColor="#006600" style="text-align: center" Width="190px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSubmitForeign" runat="server" ForeColor="Blue" Height="25px" OnClick="submit_ClickForeign" OnClientClick="ValidationBasicInfo()" style="text-align: center; background-color: #8CD7FB;" Text="Submit" Width="105px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btn" runat="server" ForeColor="Blue" Height="10px"  style="text-align: center" Visible="false" Text="Approve"  Width="110px" />
                                    </td>
                                    <td style="font-weight: 700; font-size: x-small">
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEnlishmentDate">
                                        </cc1:CalendarExtender>
                                        <asp:CheckBox ID="chkBox1" runat="server" Visible="false" AutoPostBack="false" OnCheckedChanged="chkBox1_CheckedChanged" style="color: #3333FF" Text="Temporary Supplier" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset><br />
                        <fieldset class="row2">
                            <legend id="legend1" style="font-size: 10pt; color: #3399FF;"><span class="auto-style20"> <asp:Label ID="Labelotherinformation" runat="server" CssClass="lbl" Text="Other Information"></asp:Label></span> </legend><%--<div id="Divinfo" runat="server">           --%>
                            <table>
                                <tr>
                                    <td style="text-align:right;">
                                        <asp:Label ID="lblpayto" runat="server" CssClass="lbl" Text="Pay To Name :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtPayTo" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    </td>
                                    <td style="text-align:right;">
                                        <asp:Label ID="lblrouting" runat="server" CssClass="lbl" Text="Routing :"></asp:Label>
                                    </td>
                                    <td class="auto-style5" style="text-align:left;">
                                        <asp:TextBox ID="txtRouting" runat="server" BackColor="Lightyellow" BorderColor="Gray" CssClass="txtBox" TextMode="Number" ForeColor="#990000" style="text-align:center" Width="120px"></asp:TextBox>
                                        <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" style="font-weight: 700; color: #0000FF" Text="Check" />
                                    </td>
                                    <tr>
                                        <td style="text-align:right;">
                                            <asp:Label ID="lblAcNo" runat="server" CssClass="lbl" Text="A C Number :"></asp:Label>
                                        </td>
                                        <td class="auto-style5" style="text-align:left;">
                                            <asp:TextBox ID="txtACNo" runat="server" BackColor="white" BorderColor="Gray" TextMode="Number" CssClass="txtBox" Width="190px"></asp:TextBox>
                                        </td>
                                        <td style="text-align:right;">
                                            <asp:Label ID="lblbank" runat="server" CssClass="lbl" Text="Bank :"></asp:Label>
                                        </td>
                                        <td class="auto-style5" style="text-align:left;">
                                            <asp:TextBox ID="txtBank" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right;">
                                            <asp:Label ID="lblbankid" runat="server" CssClass="lbl" Text="Bank ID :"></asp:Label>
                                        </td>
                                        <td class="auto-style5" style="text-align:left;">
                                            <asp:TextBox ID="txtBankId" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="true" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                        </td>
                                        <td style="text-align:right;">
                                            <asp:Label ID="lblbranch" runat="server" CssClass="lbl" Text="Branch :"></asp:Label>
                                        </td>
                                        <td class="auto-style5" style="text-align:left;">
                                            <asp:TextBox ID="txtBranch" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right;">
                                            <asp:Label ID="lbldistrictid" runat="server" CssClass="lbl" Text="District ID :"></asp:Label>
                                        </td>
                                        <td class="auto-style5" style="text-align:left;">
                                            <asp:TextBox ID="txtDistrictId" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                        </td>
                                        <td style="text-align:right; width:auto;">
                                            <asp:Label ID="lblbranchid" runat="server" CssClass="lbl" Text="Branch ID :"></asp:Label>
                                        </td>
                                        <td class="auto-style5" style="text-align:left;">
                                            <asp:TextBox ID="txtBranchId" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                        </td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hid" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnTempory" runat="server" ForeColor="Blue" Height="30px" OnClick="btnTempory_Click" style="text-align: center" Text="Insert Temporary" Width="140px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button3" runat="server" ForeColor="Blue" Height="30px" OnClick="submitTempory_Click" OnClientClick="ValidationBasicInfo()" style="text-align: center; background-color: #8CD7FB;" Text="Submit" Width="110px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnForign" runat="server" ForeColor="Blue" Height="29px"  style="text-align: center" Text="Insert Master (Foreign)" Width="135px" OnClick="btnForign_Click" />
                                        </td>
                                    </tr>
                                   <%-- OnClick="submit_ClickforignDump"--%>
                                    <tr>
                                       
                                            <td>
                                                <asp:Button ID="Button1" runat="server" ForeColor="Blue" Height="30px" style="text-align: center; background-color: #8CD7FB;" Text="Submit" Width="130px" OnClick="Button1_Click" />
                                            </td>
                                           <td class="auto-style6">
                                                <asp:Button ID="btnApprove" runat="server" ForeColor="Blue" Height="28px"  style="text-align: center" Text="Approve" visible="false" Width="110px" />
                                                &nbsp;</td>
                                     
                                        <td class="auto-style6">
                                            <asp:Button ID="btnMaster" runat="server"  ForeColor="Blue" Height="30px"  style="text-align: center" Text="Insert Master (Local)" Width="140px" OnClick="btnMaster_Click" OnClientClick="Confirm()" />
                                      
                                             </td>
                                        <td>     <asp:Button ID="btnclose" runat="server" ForeColor="Blue" Height="30px"  style="text-align: center" Text="Close" Width="140px" OnClick="btnClose_Click" />
                                        </td>
                                    </tr>
                              
                            </table>
                        </fieldset>
                    </caption>
    </div>

           
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>