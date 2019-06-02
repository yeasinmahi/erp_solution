<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchRequest.aspx.cs" Inherits="UI.HR.Dispatch.DispatchRequest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Dispatch Request</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   
    <script language="javascript" type="text/javascript">
        
        function Search_dgvservice(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>
                  
</head>
<body>
    <form id="frmdispatchrequest" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>--%>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>

    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnpoint" runat="server" />

    <div class="leaveApplication_container">
        <div class="tabs_container"> DISPATCH REQUEST <hr /></div>   
        <table class="tbldecoration" style="width:auto; float:left;">  
                        
            <tr class="tblroweven">
            <td colspan="4" style="color: indigo; font-weight:bold; text-align:center; font-size:18px">CONSIGNOR</td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblFName" runat="server" Text="Name :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtFName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="Unit Name :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSUnit" runat="server" CssClass="txtBox"></asp:TextBox></td>
            </tr>

            <tr>
                <td style="text-align:right;"><asp:Label ID="lblFCompanyAdd" runat="server" Text="Company Address :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSAddress" runat="server" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblFCompanyPhone" runat="server" Text="Job Station :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSJobS" runat="server" CssClass="txtBox"></asp:TextBox></td>
            </tr>

            <tr>
                <td style="text-align:right;"><asp:Label ID="lblFPhone" runat="server" Text="Mobile No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSPhone" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblFMail" runat="server" Text="Mail Address :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSMail" runat="server" CssClass="txtBox"></asp:TextBox></td>
            </tr>
            <tr><td colspan="4"><hr /></td></tr>

            <tr> 
                <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Ware House : "></asp:Label><asp:HiddenField ID="hdntype" runat="server"/></td>
                <td><asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="true" CssClass="ddList" DataSourceID="odswh" DataTextField="WH" DataValueField="intWHID" OnDataBound="ddlWH_DataBound" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>
                <asp:ObjectDataSource ID="odswh" runat="server" SelectMethod="GetWarehouseList" TypeName="HR_BLL.Global.DaysOfWeek">
                <SelectParameters><asp:SessionParameter Name="enroll" SessionField="sesUserID" Type="Int32" /><asp:ControlParameter ControlID="hdntype" Name="type" PropertyName="Value" Type="Int32" />
                </SelectParameters></asp:ObjectDataSource>
                    <asp:HiddenField ID="hdnwh" runat="server"/>
                </td>
            </tr>
            
            <tr><td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>
                <%--<td colspan="3"><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox" Width="500px" AutoPostBack="false" onchange="javascript: Changed();"></asp:TextBox>--%>
                <td colspan="3"><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="515px" ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender>
                <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
            </td></tr>

            <tr> 
                <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Quantity :"></asp:Label></td>
                <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" Width="210"></asp:TextBox></td>            

                <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" Width="210" TextMode="MultiLine" ></asp:TextBox></td>            

            </tr>
            <tr>                 
                <td colspan="4"><asp:Button ID="btnAdd" runat="server" CssClass="nextclick" Text="ADD" OnClick="btnAdd_Click"/></td>  
            </tr>
            <tr>
                <td colspan="4"> 
                <asp:GridView ID="dgvAdd" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvAdd_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                
                <asp:TemplateField HeaderText="ItemId" Visible="false" ItemStyle-HorizontalAlign="right">
                <ItemTemplate><asp:Label ID="lblItemid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("itemid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                           
                <asp:TemplateField HeaderText="Item Name"><ItemTemplate>            
                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemname") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity"><ItemTemplate>            
                <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("qty") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Remarks"><ItemTemplate>            
                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("remarks") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="175px"/></asp:TemplateField>
                                        
                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

                </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView></td>
            </tr>
            
            <tr><td colspan="4"><hr /></td></tr>
            <tr class="tblroweven">                
                <td colspan="4" style="color: indigo; font-weight:bold; text-align:center; font-size:18px">CONSIGNEE</td>
            </tr>                                                    
            <tr>  
                <td style="text-align:right;"><asp:Label ID="lblSeparateType" CssClass="lbl" runat="server" Text="Dispatch Type :"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlDispatchType" runat="server" AutoPostBack="true" CssClass="ddList" OnSelectedIndexChanged="ddlCertificateType_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Internal</asp:ListItem>
                    <asp:ListItem Value="2">External</asp:ListItem></asp:DropDownList>            
                </td>  
                
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To/Receiver :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtReceiver" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox>

                    <asp:TextBox ID="txtSearchAssignedTo" runat="server" AutoPostBack="true" CssClass="txtBox" Width="210px" Placeholder="Search By Name/Enroll/Email" OnTextChanged="txtSearchAssignedTo_TextChanged"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchAssignedTo"
                    ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>                     
                </td>                               
            </tr>  
            <tr> 
                <td style="text-align:right;">
                    <asp:Label ID="lblAddress" CssClass="lbl" runat="server" Text="Address :"></asp:Label>
                    <asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox>
                </td>  
                
                <td style="text-align:right;"><asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarksMain" runat="server" CssClass="txtBox" Width="210" TextMode="MultiLine" ></asp:TextBox></td>
            </tr>            
            <tr> 
                <td style="text-align:right;"><asp:Label ID="lblJobS" CssClass="lbl" runat="server" Text="Job Station :"></asp:Label></td>
                <td><asp:TextBox ID="txtJobS" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox></td>          
                
                <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department :"></asp:Label></td>
                <td><asp:TextBox ID="txtDept" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox></td>            
            </tr>                       
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblDesig" CssClass="lbl" runat="server" Text="Designation :"></asp:Label></td>
                <td><asp:TextBox ID="txtDesig" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox></td>

                <td colspan="4"><asp:Button ID="btnCreate" runat="server" Font-Bold="true" class="nextclick" Text="Create Dispatch Request" OnClientClick="ConfirmAll()" OnClick="btnCreate_Click"/></td>                        
            </tr>
        </table>
    </div>
    <table>
        <tr><td  style="text-align:justify;">Dispatch List :<hr />
        <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5"               
        Font-Size="10px"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="intDispatchID" SortExpression="intDispatchID" Visible="false">
        <ItemTemplate><asp:Label ID="lblDispatchID" runat="server" Text='<%# (""+Eval("intDispatchID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Date" SortExpression="CreateDate">
        <ItemTemplate><asp:Label ID="lblDate" runat="server" Width="70px" Text='<%# Bind("CreateDate") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="70px"/></asp:TemplateField>

        <%--<asp:TemplateField HeaderText="Tracking No" SortExpression="strDispatchCode">
        <ItemTemplate><asp:Label ID="lblDispatchCode" runat="server" Text='<%# Bind("strDispatchCode") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Tracking No" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strTaskTitle" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
        <HeaderTemplate>
        <asp:Label ID="lblAssignBy" runat="server" CssClass="lbl" Text="Tracking No"></asp:Label>
        <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Task Tile" runat="server"  width="150" TextMode="MultiLine"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvReport')"></asp:TextBox></HeaderTemplate>
        <ItemTemplate><asp:Label ID="lblDispatchCode" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strDispatchCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Sender" SortExpression="Sender">
        <ItemTemplate><asp:Label ID="lblSender" runat="server" Text='<%# Bind("Sender") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

        <%--<asp:TemplateField HeaderText="Sender Address" SortExpression="strStationAddress">
        <ItemTemplate><asp:Label ID="lblSenderAddress" runat="server" Text='<%# Bind("strStationAddress") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>--%>

        <asp:TemplateField HeaderText="Receiver" SortExpression="strReceiver">
        <ItemTemplate><asp:Label ID="lblReceiver" runat="server" Text='<%# Bind("strReceiver") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Receiver Address" SortExpression="strAddress">
        <ItemTemplate><asp:Label ID="lblReceiverAddress" runat="server" Text='<%# Bind("strAddress") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Bearer" SortExpression="strBearer">
        <ItemTemplate><asp:Label ID="lblBearer" runat="server" Text='<%# Bind("strBearer") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Bearer Contact No." SortExpression="strBearerContact">
        <ItemTemplate><asp:Label ID="lblBearerContact" runat="server" Text='<%# Bind("strBearerContact") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Vehicle No" SortExpression="strVehicleNo">
        <ItemTemplate><asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strVehicleNo") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Remarks" SortExpression="strRemarks">
        <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Receive By Dispatch Dept." SortExpression="ApproveStatus">
        <ItemTemplate><asp:Label ID="lblAppStatus" runat="server" Text='<%# Bind("ApproveStatus") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Delivered By Dispatch Dept." SortExpression="DispatchStatus">
        <ItemTemplate><asp:Label ID="lblDispStatus" runat="server" Text='<%# Bind("DispatchStatus") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Receive By Owner" SortExpression="OwnerReceiveStatus">
        <ItemTemplate><asp:Label ID="lblRecStatus" runat="server" Text='<%# Bind("OwnerReceiveStatus") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>
            
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td>
        </tr>
    </table>  











    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>