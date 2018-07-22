<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductReport.aspx.cs" Inherits="UI.SCM.ProductReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />

      <script language="javascript" type="text/javascript">
            function onlyNumbers(evt) {
                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;

                if ((charCode > 57))
                    return false;
                return true;
          } 
          function ViewPopup(Id) {
            window.open('LoanScheduleDetailsN.aspx?ID=' + Id, 'sub', "height=500, width=650, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
        </script>
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
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
    <asp:HiddenField ID="hdnWHID" runat="server" /> <asp:HiddenField ID="hdnGroupID" runat="server" /><asp:HiddenField ID="hdnCategoryID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <table><tr><td>
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;">PRODUCT LIST<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="WH Name " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="lblSearchText" runat="server" Text="Product Name :" CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSearchText" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" ToolTip="Enter Full/Partial Product Name"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>
            </tr>
             <tr><td colspan="4"><hr /></td></tr>
        </table>
        </td></tr>
        <tr><td>
        <table>
           <tr><td> 
            <asp:GridView ID="dgvInvnetory"  runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Vertical"  >
                    <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns>
            <asp:TemplateField HeaderText="S/N"><ItemStyle HorizontalAlign="center"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Item ID" SortExpression="intMaterialID"><ItemTemplate>
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intMaterialID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name"   ItemStyle-HorizontalAlign="right" SortExpression="strMaterialFullName" >
            <ItemTemplate><asp:Label ID="lblItemName" runat="server"  Text='<%# Bind("strMaterialFullName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="250px"/>  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="UOM"   ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUom" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="COA ID"   ItemStyle-HorizontalAlign="right" SortExpression="intCoAID" >
            <ItemTemplate><asp:Label ID="lblCOAID" runat="server"  Text='<%# Bind("intCoAID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="COA Name"   ItemStyle-HorizontalAlign="right" SortExpression="strAccName" >
            <ItemTemplate><asp:Label ID="lblCOAName" runat="server"  Text='<%# Bind("strAccName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="COA Code"   ItemStyle-HorizontalAlign="right" SortExpression="strCode" >
            <ItemTemplate><asp:Label ID="lblCode" runat="server"  Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Origin"   ItemStyle-HorizontalAlign="right" SortExpression="strOrigin" >
            <ItemTemplate><asp:Label ID="lblOrigin" runat="server"  Text='<%# Bind("strOrigin") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="HS Code"   ItemStyle-HorizontalAlign="right" SortExpression="strHSCode" >
            <ItemTemplate><asp:Label ID="lblHSCode" runat="server"  Text='<%# Bind("strHSCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Group"   ItemStyle-HorizontalAlign="right" SortExpression="strGroupName" >
            <ItemTemplate><asp:Label ID="lblGroupName" runat="server"  Text='<%# Bind("strGroupName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Category"   ItemStyle-HorizontalAlign="right" SortExpression="strCategoryName" >
            <ItemTemplate><asp:Label ID="lblCategory" runat="server"  Text='<%# Bind("strCategoryName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Sub-Category"   ItemStyle-HorizontalAlign="right" SortExpression="strSubCategoryName" >
            <ItemTemplate><asp:Label ID="lblSubCategory" runat="server"  Text='<%# Bind("strSubCategoryName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Minor Category"   ItemStyle-HorizontalAlign="right" SortExpression="strMinorCategory" >
            <ItemTemplate><asp:Label ID="lblMinorCategory" runat="server"  Text='<%# Bind("strMinorCategory") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Plant Name"   ItemStyle-HorizontalAlign="right" SortExpression="strPlantName" >
            <ItemTemplate><asp:Label ID="lblPlantName" runat="server"  Text='<%# Bind("strPlantName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Procure Type"   ItemStyle-HorizontalAlign="right" SortExpression="strProcureType" >
            <ItemTemplate><asp:Label ID="lblProcureType" runat="server"  Text='<%# Bind("strProcureType") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Material Type"   ItemStyle-HorizontalAlign="right" SortExpression="strMaterialType" >
            <ItemTemplate><asp:Label ID="lblMaterialType" runat="server"  Text='<%# Bind("strMaterialType") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="PO Process Time"   ItemStyle-HorizontalAlign="right" SortExpression="intPOProcessTimeInDays" >
            <ItemTemplate><asp:Label ID="lblPOProcessTime" runat="server"  Text='<%# Bind("intPOProcessTimeInDays") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Delivery Time"   ItemStyle-HorizontalAlign="right" SortExpression="intVendorShipmentTimeInDays" >
            <ItemTemplate><asp:Label ID="lblDeliveryTime" runat="server"  Text='<%# Bind("intVendorShipmentTimeInDays") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Process Time"   ItemStyle-HorizontalAlign="right" SortExpression="intMaterialReceiveTimeInDays" >
            <ItemTemplate><asp:Label ID="lblProcessTime" runat="server"  Text='<%# Bind("intMaterialReceiveTimeInDays") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Lead Time"   ItemStyle-HorizontalAlign="right" SortExpression="intTotalLeadTimeInDays" >
            <ItemTemplate><asp:Label ID="lblTotalLeadTime" runat="server"  Text='<%# Bind("intTotalLeadTimeInDays") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Minimum Stock"   ItemStyle-HorizontalAlign="right" SortExpression="numMinimumStock" >
            <ItemTemplate><asp:Label ID="lblMinimumStock" runat="server"  Text='<%# Bind("numMinimumStock") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Maximum Stock"   ItemStyle-HorizontalAlign="right" SortExpression="numMaximumStock" >
            <ItemTemplate><asp:Label ID="lblMaximumStock" runat="server"  Text='<%# Bind("numMaximumStock") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Safety Stock"   ItemStyle-HorizontalAlign="right" SortExpression="numSafetyStock" >
            <ItemTemplate><asp:Label ID="lblSafetyStock" runat="server"  Text='<%# Bind("numSafetyStock") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Safety Stock"   ItemStyle-HorizontalAlign="right" SortExpression="numSafetyStock" >
            <ItemTemplate><asp:Label ID="lblSafetyStock" runat="server"  Text='<%# Bind("numSafetyStock") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Re-Order Point"   ItemStyle-HorizontalAlign="right" SortExpression="numReOrderPoint" >
            <ItemTemplate><asp:Label ID="lblReOrderPoint" runat="server"  Text='<%# Bind("numReOrderPoint") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="ABC Classification"   ItemStyle-HorizontalAlign="right" SortExpression="strABC" >
            <ItemTemplate><asp:Label ID="lblABC" runat="server"  Text='<%# Bind("strABC") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="FSN Classification"   ItemStyle-HorizontalAlign="right" SortExpression="strFSN" >
            <ItemTemplate><asp:Label ID="lblFSN" runat="server"  Text='<%# Bind("strFSN") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="ABC Classification"   ItemStyle-HorizontalAlign="right" SortExpression="strABC" >
            <ItemTemplate><asp:Label ID="lblABC" runat="server"  Text='<%# Bind("strABC") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="VDE Classification"   ItemStyle-HorizontalAlign="right" SortExpression="strVDE" >
            <ItemTemplate><asp:Label ID="lblVDE" runat="server"  Text='<%# Bind("strVDE") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="Self Life"   ItemStyle-HorizontalAlign="right" SortExpression="intSelfLifeInDays" >
            <ItemTemplate><asp:Label ID="lblSelfLife" runat="server"  Text='<%# Bind("intSelfLifeInDays") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="SDE Classification"   ItemStyle-HorizontalAlign="right" SortExpression="strSDE" >
            <ItemTemplate><asp:Label ID="lblSDE" runat="server"  Text='<%# Bind("strSDE") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            <asp:TemplateField HeaderText="HML Classification"   ItemStyle-HorizontalAlign="right" SortExpression="strHML" >
            <ItemTemplate><asp:Label ID="lblHML" runat="server"  Text='<%# Bind("strHML") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="20px"/>  </asp:TemplateField>

            </Columns>
                 <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td> 
        </tr> 
           
        </table>
        </td></tr></table>
    </div>
  
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>