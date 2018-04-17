<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierProfile.aspx.cs" Inherits="UI.Inventory.SupplierProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <%--<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />--%>
   <%-- <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />--%>
    <link href="../Content/CSS/Suppliercss.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>

    
    <style type="text/css">
        .auto-style23 {
            color: #6600CC;
            width: 1755px;
            text-decoration: underline;
        }
    </style>
    
</head>
<body>
    <form id="frmauditdeptrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hfcustomerid" runat="server" /> 
   
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%" Height="28px">
    <div id="navbar"  style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 12px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 0px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

<%--<table>--%>

        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
        <asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
        <asp:HiddenField ID="hdnEnrollUnit" runat="server" />
        
         <h1 class="auto-style23">Akij Group</h1>
        <h1 class="auto-style23">Supplier Profile</h1>
        <hr />

    <tr><td class="auto-style2">
        
            
 </td>
<%--</Table>--%>
                        <td>
                </td>
        <td>
            </td>

        <td class="auto-style20">
                        <asp:Label ID="Label1" runat="server" Text="Search Supplier :"></asp:Label>
                    </td>

                <%--<td style="text-align:right;"><asp:Label ID="lblSupplierName" runat="server" CssClass="lbl" Text="Supplier Name :"></asp:Label></td>--%>
                <td style="text-align:left;"><asp:TextBox ID="txtSupplierSearch" runat="server" CssClass="long" Height="22px" Width="200px"></asp:TextBox></td> 

                <%--<td style="text-align:right;">
                <asp:Label ID="lblCustomerSearch" CssClass="lbl" runat="server" Text="Buyer/Applicant : "></asp:Label>
                <asp:HiddenField ID="hdnstation" runat="server" /><asp:HiddenField ID="hdnEnroll1" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /></td>
                <td><asp:TextBox ID="txtCustomerSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>http://html-color-codes.info/

                <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td> --%>                                                                                                                   

            <%--<td class="auto-style4">
                <asp:TextBox ID="txtCustomerSearch" runat="server" AutoPostBack="true" BorderStyle="Ridge" CssClass="long" Height="22px" Width="216px"></asp:TextBox>
            </td>--%>
            <tr>



      
    </tr>
        <td>

        </td>
        <asp:Button ID="submit" runat="server" Height="30px" OnClick="submit_Click" style="text-align: center" Text="Show" Width="153px" />
        <table>

     </table>
<br />

    <tr>

       
        <td>

<%--            <asp:GridView ID="dgvReport1" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" CellPadding="2" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" style="margin-left: 1px" >
               <AlternatingRowStyle BackColor="#D8D8D8"/>
            <Columns> --%>

            <asp:GridView ID="dgvReport1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" Font-Bold="False" 
            Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" GridLines="None" ShowFooter="True" CellSpacing="1" OnRowDataBound="dgvReport1_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="intSuppMasterID" HeaderText="ID"  ItemStyle-HorizontalAlign="Center" SortExpression="intSuppMasterID">
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="strSuppMasterName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="strSuppMasterName">
                    <ItemStyle HorizontalAlign="center" Width="300px"  Wrap="true"/>
                    </asp:BoundField>

                    <asp:BoundField DataField="strOrgAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgAddress">
                    <ItemStyle HorizontalAlign="center" Width="250px" Wrap="true"/>
                        <%--<ItemStyle HorizontalAlign="Left" Width="250px"/>--%>
                    </asp:BoundField>
                   <%-- <asp:BoundField DataField="strOrgMail" HeaderText="Mail" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20px" SortExpression="strOrgMail">
                    <ItemStyle HorizontalAlign="center" Width="20px" />
                    </asp:BoundField>--%>

                 <asp:BoundField DataField="strOrgMail" HeaderText="Mail" SortExpression="strOrgMail" ItemStyle-HorizontalAlign="Center" ControlStyle-Width="20px" >
                 <%--<ControlStyle Width="30px" />--%>
                     <ControlStyle Width="20px" />
                     <ItemStyle HorizontalAlign="center" Wrap="true" Width="100px"/>

                     <%--<ItemStyle HorizontalAlign="center" Width="150px" Wrap="true"/>
                <HeaderStyle Width="30px" Wrap="true" />
                <ItemStyle  Wrap="true"></ItemStyle>--%>
                </asp:BoundField>


                    <asp:BoundField DataField="strOrgContactNo" HeaderText="Contact" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgContactNo">
                    <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true" />
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgFAXNo" HeaderText="Fax" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgFAXNo">
                    <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true" />
                       <%-- <ItemStyle HorizontalAlign="Left" Width="70px"/>--%>
                    </asp:BoundField>
                    <asp:BoundField DataField="strBusinessType" HeaderText="Business" ItemStyle-HorizontalAlign="Center" SortExpression="strBusinessType">
                    <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/>
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="strServiceType" HeaderText="Service" ItemStyle-HorizontalAlign="Center" SortExpression="strServiceType">
                    <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/>
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="strBIN" HeaderText="Bin" ItemStyle-HorizontalAlign="Center" SortExpression="strBIN">
                    <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strTIN" HeaderText="Tin" ItemStyle-HorizontalAlign="Center" SortExpression="strTIN">
                    <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strVATRegNo" HeaderText="Vat Reg." ItemStyle-HorizontalAlign="Center" SortExpression="strVATRegNo">
                    <ItemStyle HorizontalAlign="center" Width="80px" Wrap="true" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strTradeLisenceNo" HeaderText="Trade Lic." ItemStyle-HorizontalAlign="Center" SortExpression="strTradeLisenceNo">
                    <ItemStyle HorizontalAlign="center" Width="80px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strReprName" HeaderText="Contact Person" ItemStyle-HorizontalAlign="Center" SortExpression="strReprName">
                    <ItemStyle HorizontalAlign="center" Width="120px" Wrap="true" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strReprContactNo" HeaderText="Contact No" ItemStyle-HorizontalAlign="Center" SortExpression="strReprContactNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strPayToName" HeaderText="PayTo" ItemStyle-HorizontalAlign="Center" SortExpression="strPayToName">
                    <ItemStyle HorizontalAlign="center" Width="180px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strSupplierType" HeaderText="Supplier Type" ItemStyle-HorizontalAlign="Center" SortExpression="strSupplierType">
                    <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="EnlistmentDate" HeaderText="Enlist. Date" ItemStyle-HorizontalAlign="Center" SortExpression="EnlistmentDate">
                    <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/>

                    </asp:BoundField>
                    <asp:BoundField DataField="strAccountName" HeaderText="Account Name" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountName">
                    <ItemStyle HorizontalAlign="center" Width="200px" Wrap="true"/>
                  
                    </asp:BoundField>
                    <asp:BoundField DataField="strAccountNo" HeaderText="A/C No" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountNo">
                    <ItemStyle HorizontalAlign="center" Width="110px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strRoutingNumber" HeaderText="Routing" ItemStyle-HorizontalAlign="Center" SortExpression="strRoutingNumber">
                    <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="strBankName" HeaderText="Bank" ItemStyle-HorizontalAlign="Center" SortExpression="strBankName">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strBankBranchName" HeaderText="Branch"  ItemStyle-HorizontalAlign="Center" SortExpression="strBankBranchName">
                    <ItemStyle HorizontalAlign="center" Width="150px" Wrap="true" />
                    </asp:BoundField>

<%--                    <asp:TemplateField HeaderText="Complete">
             <ItemTemplate>
             <asp:Button ID="Complete" runat="server" Text="Approve" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("strOrgMail") %>' /></ItemTemplate>
             </asp:TemplateField> --%>



<%--                    sm.intSuppMasterID,strSuppMasterName, strOrgAddress, strOrgMail, strOrgContactNo, strOrgFAXNo, strBusinessType, strServiceType, strBIN, strTIN, strVATRegNo, strTradeLisenceNo, 
                    strReprName, strReprContactNo, strPayToName,strAccountName,af.strAccountNo,qbi.strRoutingNumber,qbi.strBankName,qbi.strBankBranchName--%>


                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
        </td>
    </tr>
    </tr>
        </table>
      
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>