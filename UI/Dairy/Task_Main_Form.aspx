<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_Main_Form.aspx.cs" Inherits="UI.Dairy.Task_Main_Form" %>
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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   
<script language="javascript" type="text/javascript">
    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }

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

<script>
    function NewTask(reqsid) {
        window.open('Daily_Task.aspx?intID=' + reqsid, 'sub', "height=500, width=850, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
    }

    function UpdateTask(reqsid) {
        window.open('Task_Update_Forward.aspx?intID=' + reqsid, 'sub', "height=550, width=830, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
    }

    function TaskDetails(reqsid) {
        window.open('Task_Details_Report.aspx?intID=' + reqsid, 'sub', "height=400, width=850, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
    }

    function DeadlineChange(reqsid) {
        window.open('Task_ChangeBy.aspx?intID=' + reqsid, 'sub', "height=550, width=700, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
    }
    function DocListView(reqsid) {
        window.open('Task_MyDocView.aspx?intID=' + reqsid, 'sub', "height=450, width=800, scrollbars=yes, left=100, top=50, resizable=no, title=Preview");
        //window.open('Task_DocDownAndView.aspx?intID=' + reqsid, 'sub', "height=650, width=930, scrollbars=yes, left=150, top=50, resizable=no, title=Preview");        
    }
    function TaskComplete(reqsid) {
        window.open('TaskComplete.aspx?intID=' + reqsid, 'sub', "height=180, width=550, scrollbars=yes, left=50, top=300, resizable=no, title=Preview");
    }

</script>

<%--<script>$(document).ready(function () {
    document.getElementById("hiddenbox").style.display = "none";
});</script>--%>
                  
    <style type="text/css">
        .auto-style1 {
            height: 54px;
        }
        .auto-style2 {
            width: 5px;
            height: 54px;
        }
    </style>
                  
</head>
<body>
    <form id="frmtask" runat="server">        
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

    <div class="leaveApplication_container"><asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
        
    <div class="tabs_container"> TASK LIST <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;"> 
            <%--<tr>
                <td><asp:Image ID="img" runat="server" Width="50px" Height="50px"></asp:Image></td>
            </tr>--%>
            <tr>                
                <td class="auto-style1"><asp:Image ID="img" runat="server" Width="50px" Height="50px"></asp:Image></td>
                <td class="auto-style2"></td>
                <td class="auto-style1"><asp:CheckBox ID="cbMyTeam" runat="server" CssClass="lbl" ForeColor="Green" Font-Size="11px" Width="120px" Font-Bold="true" Text="My Team" AutoPostBack="true" OnCheckedChanged="cbMyTeam_CheckedChanged" /></td>
                <td colspan="3" class="auto-style1"><asp:Button ID="btnNewTask" runat="server" ForeColor="Blue" Font-Size="11px" Font-Bold="true" class="nextclick" Text="New Task" OnClick="btnNewTask_Click"/></td>                
                
                <%--<td colspan="1"><asp:Button ID="btnPicUpload" runat="server" ForeColor="Blue" Font-Size="11px" Font-Bold="true" class="nextclick" Text="Picture Upload" OnClick="btnPicUpload_Click"/></td>--%>

            </tr>
            
            
            <tr style="border-color:darkslategrey">
                
                <td><asp:RadioButton ID="rdoAssignedBy" runat="server" Checked="true" Text="My Task" ForeColor="Green" Font-Size="11px" Width="120px" Font-Bold="true" OnCheckedChanged="rdoAssignedBy_CheckedChanged" AutoPostBack="true"/></td> 
                
                <td style="width:5px"></td>

                <td style="text-align:right;"><asp:Label ID="lblAssignBy" runat="server" ForeColor="Green" Font-Size="11px" Font-Bold="true" CssClass="lbl" Text="Assigned By:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtAssignBy" runat="server"  CssClass="txtBox" AutoPostBack="true" Width="210px" OnTextChanged="txtAssignBy_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtAssignBy"
                ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender>
                                
                <asp:DropDownList ID="ddlTeamM1" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTeamM1_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            
                </td>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" ForeColor="Green" Font-Size="11px" Font-Bold="true" CssClass="lbl" Text="All Task To:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtAllTask" runat="server"  CssClass="txtBox" AutoPostBack="true" Width="210px" OnTextChanged="txtAllTask_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtAllTask"
                ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender>

                <asp:DropDownList ID="ddlTeamM3" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTeamM3_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
                
            </tr>

            <tr>
                <td><asp:RadioButton ID="rdoAssignedTo" runat="server" Text="Assigned By Me" ForeColor="Green" Font-Size="11px" Font-Bold="true" OnCheckedChanged="rdoAssignedTo_CheckedChanged" AutoPostBack="true"/></td>                                
                <td style="width:5px"></td>

                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" ForeColor="Green" Font-Size="11px" Font-Bold="true" Text="Assigned To:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSearchAssignedTo" runat="server"  CssClass="txtBox" AutoPostBack="true" Width="210px" OnTextChanged="txtSearchAssignedTo_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchAssignedTo"
                ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender>

                <asp:DropDownList ID="ddlTeamM2" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTeamM2_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>

                <td style="text-align:right;"><asp:Label ID="lblReportType" runat="server" CssClass="lbl" Font-Size="11px" ForeColor="Green" Font-Bold="true" Text="Category :"></asp:Label></td>
                <td style="text-align:left;">
                    <asp:DropDownList ID="ddlReportType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="true" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="1">Tasks Due</asp:ListItem><asp:ListItem Value="2">Completed Tasks</asp:ListItem>
                    <asp:ListItem Value="3">Overdue Tasks</asp:ListItem><asp:ListItem Value="4">Daily Progress</asp:ListItem> 
                    <asp:ListItem Value="5">Previous Day Progress</asp:ListItem><asp:ListItem Value="6">Last 7 Days Progress</asp:ListItem>
                    <asp:ListItem Value="7">Next Day Overdue Task List</asp:ListItem><asp:ListItem Value="8">All Tasks</asp:ListItem>              
                    </asp:DropDownList>                                                                                       
                </td>
            </tr>
            
        </table>
    </div>

    
    <div id="divInventory">      
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
            <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvReport_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>   
            <%--<asp:TemplateField HeaderText="SL.N"><HeaderTemplate>  
            <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox></HeaderTemplate>                     
            <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="AssetID"><ItemTemplate>
            <asp:Label ID="strAssetCode" runat="server" Text='<%# Eval("strAssetID") %>'></asp:Label></ItemTemplate></asp:TemplateField>--%>
                
                         
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Details" OnClick="btnDetails_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnOpen" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Open" OnClick="btnOpen_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Assign By Photo" SortExpression="strPhoto" >
            <ItemTemplate ><asp:Image ID="img" runat="server" ImageUrl ='<%# Eval("strPhoto") %>' height="40px" Width="40px" /></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="90px"/></asp:TemplateField>--%>
            
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
            <asp:TemplateField HeaderText="Task Title" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strTaskTitle" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
            <HeaderTemplate>
            <asp:Label ID="lblAssignBy" runat="server" CssClass="lbl" Text="Task Title"></asp:Label>
            <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Task Tile" runat="server"  width="200" TextMode="MultiLine"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvReport')"></asp:TextBox></HeaderTemplate>
            <ItemTemplate><asp:Label ID="lblTaskTile" runat="server" Width="200px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strTaskTitle")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Priority" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strPriority" >
            <ItemTemplate><asp:Label ID="lblPriority" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strPriority")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Status" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strStatus" >
            <ItemTemplate><asp:Label ID="lblStatus" runat="server" Width="60px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strStatus")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <%--<asp:TemplateField HeaderText="% Com" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intCompletePer" >
            <ItemTemplate><asp:Label ID="lblComPer" runat="server" Width="40px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intCompletePer")) %>'></asp:Label>
            <a class="nextclick" style="Font-Size:10px; color:green" href="#" onclick="<%#  FilterControls(""+Eval("intTaskID"),""+Eval("intTaskID")) %>">Complete</a>
            </ItemTemplate></asp:TemplateField>--%>

            <%--<asp:TemplateField HeaderText="% Com" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intCompletePer" >
            <ItemTemplate><asp:Label ID="lblComPer" runat="server" Width="40px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intCompletePer")) %>'></asp:Label>
            <asp:Button ID="btnComplete" runat="server" class="nextclick" style="cursor:pointer; font-size:11px; color:blue;"
            href="#"  OnClick='<%#  FilterControls(""+Eval("marks"),""+Eval("intTaskID")) %>' Text="Complete"/>
            </ItemTemplate></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="% Com" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intCompletePer" >
            <ItemTemplate><asp:Label ID="lblComPer" runat="server" Width="40px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intCompletePer")) %>'></asp:Label>
            <asp:Button ID="btnComplete" runat="server" class="nextclick" style="cursor:pointer; font-size:11px; color:blue;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Complete" OnClick="btnComplete_Click"/>
            </ItemTemplate></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><a class="nextclick" style="Font-Size:10px; color:green" href="#" onclick="<%#  FilterControls(""+Eval("intApplicationID"),""+Eval("Amount")) %>">Complete</a>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>--%>
                              
            <%--<ItemTemplate><asp:Button ID="btnDocVew" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Document View" OnClick="btnDocVew_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" />--%>
                
            <asp:TemplateField HeaderText="Assigned By" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="AssignBy" >
            <ItemTemplate><asp:Label ID="lblAssignBy" runat="server" Width="130px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("AssignBy")) %>'></asp:Label>
            </ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Assigned To" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="AssignTo" >
            <ItemTemplate><asp:Label ID="lblAssignTo" runat="server" Width="130px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("AssignTo")) %>'></asp:Label>
            </ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Start Date" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="dteStart" >
            <ItemTemplate><asp:Label ID="lblStartDate" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteStart")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Deadline" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="dteDeadline" >
            <ItemTemplate><asp:Label ID="lblDeadline" runat="server" Width="80px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteDeadline")) %>'></asp:Label>
            <asp:Button ID="btnDchangeReq" runat="server" class="nextclick" style="cursor:pointer; font-size:11px; color:blue; align-items:center;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Change" OnClick="btnDchangeReq_Click"/>
            </ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Complete Date" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="dteComplete" >
            <ItemTemplate><asp:Label ID="lblComDate" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteComplete")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Remarks" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strRemarks" >
            <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strRemarks")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="intTaskID" Visible="false" ItemStyle-HorizontalAlign="left" SortExpression="intTaskID" >
            <ItemTemplate><asp:Label ID="lblTaskID" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intTaskID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Document View" >
            <ItemTemplate><asp:Button ID="btnDocVew" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Document View" OnClick="btnDocVew_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField HeaderText="WP" Visible="false" ItemStyle-HorizontalAlign="left" SortExpression="WorkPlanCount" >
            <ItemTemplate><asp:Label ID="lblWP" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("WorkPlanCount")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="CompPer" Visible="false" ItemStyle-HorizontalAlign="left" SortExpression="CompletePer" >
            <ItemTemplate><asp:Label ID="lblComp" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("CompletePer")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="DReq" Visible="false" ItemStyle-HorizontalAlign="left" SortExpression="DReqCheck" >
            <ItemTemplate><asp:Label ID="lblDReq" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("DReqCheck")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="StatusForColor" Visible="false" ItemStyle-HorizontalAlign="left" SortExpression="StatusForColor" >
            <ItemTemplate><asp:Label ID="lblStatusForColor" runat="server" Width="130px" Text='<%# (""+Eval("StatusForColor")) %>'></asp:Label>
            </ItemTemplate></asp:TemplateField>
                            
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>        

         </table>     
      </div>

        <%--<div id="hiddenbox"><asp:HiddenField ID="hdnID" runat="server" /><asp:HiddenField ID="hdnConfirmAppMarks" runat="server" />
        <table style="width:Auto";>
            
            <tr>
            <td style=" text-align:right; "><asp:Label ID="lblCustN" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Propost Marks :"></asp:Label></td>
            <td style=" text-align:left; "><asp:Label ID="lblCustName" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
                  
            <td style="text-align:right;"><asp:Label ID="lblamount" CssClass="lbl"  Font-Bold="true" Font-Size="11px" runat="server" Text="Approve Marks : "></asp:Label></td>
            <td><asp:TextBox ID="txtApproveMarks" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" MaxLength="3" ></asp:TextBox></td>

            
            </tr>

            <tr>
                <td style="text-align:right;" colspan="2">            
                    <a class="nextclick" onclick="Approved()">Approve</a>            
                </td>
                <td style="text-align:right;" colspan="2">   
                    <a class="nextclick" style="text-align:left;" onclick="ClearControls()">Close</a>
                </td> 

            </tr>


        </table>
        </div>--%>


 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>