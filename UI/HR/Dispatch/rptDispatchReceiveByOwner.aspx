<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDispatchReceiveByOwner.aspx.cs" Inherits="UI.HR.Dispatch.rptDispatchReceiveByOwner" %>
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
    function DispatchSubmit() {
        document.getElementById("hdnconfirm").value = "3";
        //var confirm_value = document.createElement("INPUT");
        //confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        //if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "2"; }
        //else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();        
    }
    function ReceiveByOwner() {
        document.getElementById("hdnconfirm").value = "3";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "5"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();
    }
    </script>
    <script type="text/javascript">
    
    function ViewOwnerReceivePopup(Id) {
        window.open('rptOwnerReceivePopup.aspx?ID=' + Id, 'sub', "height=230, width=700, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
    }
 </script>

    <script type="text/javascript">    
        function Show() {
            document.getElementById("hdnconfirm").value = "3";
            //var confirm_value = document.createElement("INPUT");
            //confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            //if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
            //else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            __doPostBack();
        }
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

    <script type="text/javascript">
        function ViewConfirm(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }        
        function ClosehdnDivision() { $("#hdnDivision").fadeOut("slow"); }        
    </script>
    
    <style type="text/css"> 
    .rounds { height: 600px; width: 150px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:500%; height: 30%; margin-left:50px; margin-top: -330px; margin-right:00px; padding: 15px; overflow-y:scroll;}    
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
        <asp:HiddenField ID="hdnJobStationID" runat="server" />
        <div class="tabs_container"> DISPATCH REPORT FOR OWNER <hr /></div>
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
                <td><asp:RadioButton ID="rdoPrimaryReceive" runat="server" Checked="true" Text=" Pending" OnCheckedChanged="rdoPrimaryReceive_CheckedChanged"  AutoPostBack="true"  />
                <asp:RadioButton ID="rdoPending" runat="server" Text=" In House Receive" OnCheckedChanged="rdoPending_CheckedChanged" AutoPostBack="true" />
                <asp:RadioButton ID="rdoReceived" runat="server" Text=" Received" OnCheckedChanged="rdoReceived_CheckedChanged"  AutoPostBack="true"  />                
                </td>

                <td style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClientClick="Show()"/></td>
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

            <asp:TemplateField HeaderText="To/Receiver" SortExpression="strReceiver">
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

            <asp:TemplateField HeaderText="Receive By" SortExpression="ApproveStatus">
            <ItemTemplate><asp:Label ID="lblReceiveBy" runat="server" Text='<%# Bind("ApproveStatus") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:TemplateField>
                             
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnActionA" runat="server" class="nextclick" OnCommand="btnAction_OnCommand" CommandName="RECEIVE" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDispatchID") %>' Text="Owner Receive"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnActionB" runat="server" class="nextclick" OnCommand="btnAction_OnCommand" OnClientClick="ConfirmAll()" CommandName="PRIMARYRECEIVE" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDispatchID") %>' Text="Primary Receive"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>
        </table>
    </td></tr></table>
        
    <div id="hdnDivision" class="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">            
    <tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
    
    <tr>      
    <td style="font-weight:bold; text-align:right; "><asp:Label ID="Label3" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Employee Card No.:"></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtEmployeeCardNo" AutoPostBack="true" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" OnTextChanged="txtChanged_Click"></asp:TextBox></td> 

    <td style="font-weight:bold; text-align:right; "><asp:Label ID="lblEnroll" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Enroll :"></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtEnrollByReceiver" AutoPostBack="false" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" OnTextChanged="txtEnrollR_Click"></asp:TextBox></td> 
    </tr>

    <tr><td colspan="4" style="text-align:justify;"><hr />
    <asp:GridView ID="dgvAdd" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                
    <asp:TemplateField HeaderText="ItemId" Visible="false" ItemStyle-HorizontalAlign="right">
    <ItemTemplate><asp:Label ID="lblItemid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intItemID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                           
    <asp:TemplateField HeaderText="Item Name"><ItemTemplate>            
    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

    <asp:TemplateField HeaderText="Quantity"><ItemTemplate>            
    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

    <asp:TemplateField HeaderText="Remarks"><ItemTemplate>            
    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="175px"/></asp:TemplateField>
          
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>
    <tr class="tblroweven"><td style="text-align:right;"><asp:Button ID="btnApproveDT" runat="server" CssClass="button" Text="Receive" OnClientClick="ReceiveByOwner()" /></td></tr>
    </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
