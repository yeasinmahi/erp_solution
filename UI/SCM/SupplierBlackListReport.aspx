<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierBlackListReport.aspx.cs" Inherits="UI.SCM.SupplierBlackListReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Approve Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
      
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <form id="frmApproveLoanApplication" runat="server">        
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" />    
    
    <table>
    <tr><td>
        <div class="divbody" style="padding-right:10px;">
            <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="SUPPLIER BLACK LIST REPORT" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
            <table class="tbldecoration" style="width:auto; float:left;"> 
                <tr>
                    <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Supplier :" CssClass="lbl"></asp:Label></td>
                    <td><asp:TextBox ID="txtSupplier" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                    <td style="text-align:right; width:15px;"><asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                    <td style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClientClick="LoaderBusy()" OnClick="btnShow_Click"/></td>        
                </tr>
            </table>
        </div>
    <td></tr>
    <tr><td>
        <table class="tbldecoration" style="width:auto; float:left;"> 
            <tr><td><hr /></td></tr>
            <tr><td>   
                <asp:GridView ID="dgvSuppliser" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvSuppliser_RowDataBound">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                            
                <asp:TemplateField HeaderText="ID" SortExpression="intSuppMasterID">
                <ItemTemplate><asp:Label ID="lblSuppID" runat="server" Text='<%# Bind("intSuppMasterID") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Name" SortExpression="strSuppMasterName">
                <ItemTemplate><asp:Label ID="lblSuppName" runat="server" Text='<%# Bind("strSuppMasterName") %>' Width="200px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="200px"/></asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Address" SortExpression="strOrgAddress">
                <ItemTemplate><asp:Label ID="lblAddr" runat="server" Text='<%# Bind("strOrgAddress") %>' Width="300px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="300px"/></asp:TemplateField>
                                      
                <asp:BoundField DataField="strOrgMail" HeaderText="Mail" SortExpression="strOrgMail" ItemStyle-HorizontalAlign="Center" ControlStyle-Width="20px" >
                <ControlStyle Width="20px" /><ItemStyle HorizontalAlign="center" Wrap="true" Width="100px"/></asp:BoundField>
                    
                <asp:BoundField DataField="strOrgContactNo" HeaderText="Contact" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgContactNo">
                <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true" /></asp:BoundField>
                    
                <asp:BoundField DataField="strOrgFAXNo" HeaderText="Fax" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgFAXNo">
                <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true" /></asp:BoundField>
                    
                <asp:BoundField DataField="strBusinessType" HeaderText="Business" ItemStyle-HorizontalAlign="Center" SortExpression="strBusinessType">
                <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/></asp:BoundField>
                    
                <asp:BoundField DataField="strServiceType" HeaderText="Service" ItemStyle-HorizontalAlign="Center" SortExpression="strServiceType">
                <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/></asp:BoundField>                    
                    
                <asp:BoundField DataField="strBIN" HeaderText="Bin" ItemStyle-HorizontalAlign="Center" SortExpression="strBIN">
                <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/></asp:BoundField>
                    
                <asp:BoundField DataField="strTIN" HeaderText="Tin" ItemStyle-HorizontalAlign="Center" SortExpression="strTIN">
                <ItemStyle HorizontalAlign="center" Width="70px" Wrap="true"/></asp:BoundField>
                    
                <asp:BoundField DataField="strVATRegNo" HeaderText="Vat Reg." ItemStyle-HorizontalAlign="Center" SortExpression="strVATRegNo">
                <ItemStyle HorizontalAlign="center" Width="80px" Wrap="true" /></asp:BoundField>
                    
                <asp:BoundField DataField="strTradeLisenceNo" HeaderText="Trade Lic." ItemStyle-HorizontalAlign="Center" SortExpression="strTradeLisenceNo">
                <ItemStyle HorizontalAlign="center" Width="80px" Wrap="true"/></asp:BoundField>
                    
                <asp:TemplateField HeaderText="Contact Person" SortExpression="strReprName">
                <ItemTemplate><asp:Label ID="lblContactPer" runat="server" Text='<%# Bind("strReprName") %>' Width="150"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150"/></asp:TemplateField>

                <asp:BoundField DataField="strReprContactNo" HeaderText="Contact No" ItemStyle-HorizontalAlign="Center" SortExpression="strReprContactNo">
                <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/></asp:BoundField>
                   
                <asp:TemplateField HeaderText="Pay To" SortExpression="strPayToName">
                <ItemTemplate><asp:Label ID="lblPayTo" runat="server" Text='<%# Bind("strPayToName") %>' Width="180"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="180"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Supplier Type" SortExpression="strSupplierType">
                <ItemTemplate><asp:Label ID="lblSuppT" runat="server" Text='<%# Bind("strSupplierType") %>' Width="90"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="90"/></asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Enlist. Date" SortExpression="EnlistmentDate">
                <ItemTemplate><asp:Label ID="lblEnlistDate" runat="server" Text='<%# Bind("EnlistmentDate") %>' Width="80"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80"/></asp:TemplateField>
                                        
                <asp:TemplateField HeaderText="Account Name" SortExpression="strAccountName">
                <ItemTemplate><asp:Label ID="lblAccountN" runat="server" Text='<%# Bind("strAccountName") %>' Width="200"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="200"/></asp:TemplateField>
                                        
                <asp:BoundField DataField="strAccountNo" HeaderText="A/C No" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountNo">
                <ItemStyle HorizontalAlign="center" Width="110px" Wrap="true"/></asp:BoundField>
                    
                <asp:BoundField DataField="strRoutingNumber" HeaderText="Routing" ItemStyle-HorizontalAlign="Center" SortExpression="strRoutingNumber">
                <ItemStyle HorizontalAlign="center" Width="100px" Wrap="true"/></asp:BoundField>
                    
                <asp:TemplateField HeaderText="Bank Name" SortExpression="strBankName">
                <ItemTemplate><asp:Label ID="lblBank" runat="server" Text='<%# Bind("strBankName") %>' Width="150"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Branch Name" SortExpression="strBankBranchName">
                <ItemTemplate><asp:Label ID="lblBranch" runat="server" Text='<%# Bind("strBankBranchName") %>' Width="150"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Remarks" SortExpression="strBlockRemarks">
                <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strBlockRemarks") %>' Width="150"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150"/></asp:TemplateField>
                    
                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr>
        </table>
    </td></tr>
    </table>

    <div class="loading" align="center">
        <img src="../Content/images/gicon/Final-Product-2.GIF" />
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>