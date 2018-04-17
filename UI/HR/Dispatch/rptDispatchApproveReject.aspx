<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDispatchApproveReject.aspx.cs" Inherits="UI.HR.Dispatch.rptDispatchApproveReject" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
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

    <script type="text/javascript">
        function ViewConfirm(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }
        function ClosehdnDivision() { $("#hdnDivision").fadeOut("slow"); }
    </script>

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
    
    <style type="text/css"> 
    .rounds { height: 600px; width: 150px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:500%; height: 30%; margin-left:50px; margin-top: -55px; margin-right:00px; padding: 15px; overflow-y:scroll;}    
    </style>

    </head>
<body>
    <form id="frmDispatchR" runat="server">        
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
    <table>
    <tr><td>
        <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDispatchID" runat="server" /> 
        <div class="tabs_container"> DISPATCH REPORT FOR SUPERVISOR <hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <%--<tr>
                <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
                <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
                <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
            </tr>--%>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblBill" CssClass="lbl" runat="server" Text="Status : "></asp:Label></td>
                <td><asp:RadioButton ID="rdoPending" runat="server" Checked="true" Text=" Pending" OnCheckedChanged="rdoPending_CheckedChanged" AutoPostBack="true" />
                <asp:RadioButton ID="rdoComplete" runat="server" Text=" Complete" OnCheckedChanged="rdoComplete_CheckedChanged"  AutoPostBack="true"  />
                <asp:RadioButton ID="rdoReject" runat="server" Text=" Reject" OnCheckedChanged="rdoReject_CheckedChanged"  AutoPostBack="true"  />
                </td>

                <td colspan="2" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>
            </tr>
        </table>
        </div>
    </td></tr>
    <tr><td>
        <table>
            <tr><td  style="text-align:justify;"><hr />
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

            <asp:TemplateField HeaderText="Sender Address" SortExpression="strStationAddress">
            <ItemTemplate><asp:Label ID="lblSenderAddress" runat="server" Text='<%# Bind("strStationAddress") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Receiver" SortExpression="strReceiver">
            <ItemTemplate><asp:Label ID="lblReceiver" runat="server" Text='<%# Bind("strReceiver") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Receiver Address" SortExpression="strAddress">
            <ItemTemplate><asp:Label ID="lblReceiverAddress" runat="server" Text='<%# Bind("strAddress") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bearer" SortExpression="strBearer">
            <ItemTemplate><asp:Label ID="lblBearer" runat="server" Text='<%# Bind("strBearer") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Vehicle No" SortExpression="strVehicleNo">
            <ItemTemplate><asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strVehicleNo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>
                           
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" OnCommand="btnAction_OnCommand" CommandName="DETAILS" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDispatchID") %>' Text="Details"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnActionA" runat="server" class="nextclick" OnClientClick="ConfirmAll()" OnCommand="btnAction_OnCommand" CommandName="APPROVE" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDispatchID") %>' Text="Approve"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="red" >
            <ItemTemplate><asp:Button ID="btnActionR" runat="server" class="nextclick" OnClientClick="ConfirmAll()" OnCommand="btnAction_OnCommand" CommandName="REJECT" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDispatchID") %>' Text="Reject"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
            
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>
        </table>
    </td></tr></table>


    <div id="hdnDivision" class="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">            
    <tr><td style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
          
    <tr><td style="text-align:justify;"><hr />
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
    </asp:GridView>
    </td></tr>
    <tr class="tblroweven"><td style="text-align:right;"><asp:Button ID="btnApproveDT" runat="server" CssClass="button" Text="Approve" OnClientClick="ConfirmAll()" OnCommand="btnAction_OnCommand" CommandName="APPROVEDT"/></td></tr>
    </table>
    </div>

    
                  






    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
