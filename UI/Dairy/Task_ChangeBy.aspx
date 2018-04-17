<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_ChangeBy.aspx.cs" Inherits="UI.Dairy.Task_ChangeBy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
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

</script>

<script> function CloseWindow() {
     window.close();
 } </script>

<%--<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>--%>

<script>
    function FTPUpload() {
        document.getElementById("hdnconfirm").value = "2";
        __doPostBack();
    }
    function FTPUpload4() {
        document.getElementById("hdnconfirm").value = "4";
        __doPostBack();
    }
    function FTPUpload1() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();
    }
    function FTPUpload5() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "5"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();
    }
</script>
          
</head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />

    <div  runat="server" id="CheckBoxTaskFDiv">
        <table>
        <tr>
            <td><asp:CheckBox ID="cbTaskReAssing" runat="server" CssClass="lbl" ForeColor="Green" Font-Size="11px" Width="120px" Font-Bold="true" Text="Task Re-Assign" AutoPostBack="true" OnCheckedChanged="cbTaskReAssing_CheckedChanged"/></td>               
            <td style="width:40px"></td>
            <td colspan="1"><asp:Button ID="btnCancel" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Task Cancel"  OnClientClick="ConfirmAll()" OnClick="btnCancel_Click"/></td>            
        </tr>
        </table>
    </div>
        
    <div class="leaveApplication_container" runat="server" id="DeadlineChangeDiv"> <asp:HiddenField ID="hdnEnroll" runat="server" />
        
         <table class="tbldecoration" style="width:auto; float:left;">
         <tr><td colspan="6" style="font-weight:bold; font-size:13px; color:black;">DEADLINE CHANGE <hr /></td></tr>     
                        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblTaskDetails" runat="server" CssClass="lbl" Text="Task Title:"></asp:Label></td>
            <td colspan="5" style="text-align:left;"><asp:TextBox ID="txtTaskDetails" runat="server" BackColor="LightGray" CssClass="txtBox" TextMode="MultiLine" Width="590px"></asp:TextBox></td>                                                   
        </tr>  
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblDeadline" runat="server" CssClass="lbl" Text="Deadline Date:"></asp:Label></td>                
            <td><asp:TextBox ID="txtDeadline" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="170px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeadline"></cc1:CalendarExtender></td>             

           <td style="text-align:right;"><asp:Label ID="LblTime" runat="server" CssClass="lbl" Text="Time :"></asp:Label></td>
           <td><cc1:TimeSelector ID="TimeSelector1" runat="server" AllowSecondEditing="true" Width="150px"></cc1:TimeSelector></td>
            <td ></td>
            <td><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Change Deadline"  OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>        
        </tr>                                 
        
        <tr><td colspan="6" style="font-weight:bold; font-size:13px; color:black;"><hr /></td></tr>
        <tr><td colspan="6"> 
            <asp:GridView ID="dgvChangeReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="13px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
            <asp:TemplateField HeaderText="Request Date" SortExpression="dteReqDate"><ItemTemplate>            
            <asp:Label ID="lblReqDate" runat="server" Text='<%# Bind("dteReqDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Request Time" SortExpression="dteReqTime"><ItemTemplate>            
            <asp:Label ID="lblReqTime" runat="server" Text='<%# Bind("dteReqTime") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Status" SortExpression="strStatus"><ItemTemplate>            
            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("strStatus") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Change Date" SortExpression="dteChangeDate"><ItemTemplate>            
            <asp:Label ID="lblChangeDate" runat="server" Text='<%# Bind("dteChangeDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Change Time" SortExpression="dteChangeTime"><ItemTemplate>            
            <asp:Label ID="lblChangeTime" runat="server" Text='<%# Bind("dteChangeTime") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Notes" SortExpression="strNotes"><ItemTemplate>            
            <asp:Label ID="lblNotes" runat="server" Text='<%# Bind("strNotes") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="180px"/></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>

 </table>
</div>

<div class="leaveApplication_container" runat="server" id="ForwardDiv">
         <table class="tbldecoration" style="width:auto; float:left;">
         <tr><td colspan="4"><hr /></td></tr> 
         <tr><td colspan="4" style="font-weight:bold; font-size:13px; float:center;"> TASK RE-ASSIGN <hr /></td></tr>    
             
            <tr>
               <td><asp:Image ID="img" runat="server" Width="50px" Height="50px"></asp:Image></td> 
               <td><asp:CheckBox ID="cbMyTeam" runat="server" CssClass="lbl" ForeColor="Green" Font-Size="11px" Width="120px" Font-Bold="true" Text="My Team" AutoPostBack="true" OnCheckedChanged="cbMyTeam_CheckedChanged" /></td>               
           </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Task Title:"></asp:Label></td>
                <td colspan="3" style="text-align:left;"><asp:TextBox ID="txtTaskDetailsT" runat="server"  CssClass="txtBox" Width="510px"></asp:TextBox></td>                                                   
            </tr>
            <tr>                
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Assigned To :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSearchAssignedTo" runat="server"  CssClass="txtBox" Width="210px" AutoPostBack="true" OnTextChanged="txtSearchAssignedTo_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchAssignedTo"
                ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender>
                
                <asp:DropDownList ID="ddlAssignTo" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignTo_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>  
                
                <td style="text-align:right;"><asp:Label ID="lblStartDate" runat="server" CssClass="lbl" Text="Start Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtStartDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStartDate"></cc1:CalendarExtender></td>                                             
            </tr>             
             <tr>   
                 <td style="text-align:right;"><asp:Label ID="lblPriority" runat="server" CssClass="lbl" Text="Priority:"></asp:Label></td>                
                <td>
                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="false">
                    <asp:ListItem Selected="True" Value="1">High</asp:ListItem><asp:ListItem Value="2">Normal</asp:ListItem>
                    <asp:ListItem Value="3">Low</asp:ListItem>                
                    </asp:DropDownList>
                </td>           
                
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Deadline Date:"></asp:Label></td>                
                <td><asp:TextBox ID="txtDeadlineF" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeadlineF"></cc1:CalendarExtender></td>             
            </tr>
        
           <tr>
               <td style="text-align:right;"><asp:Label ID="lblRemarks" runat="server" CssClass="lbl" Text="Remarks:"></asp:Label></td>
               <td style="text-align:left;"><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   

               <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Time :"></asp:Label></td>
               <td><cc1:TimeSelector ID="TimeSelector2" runat="server" AllowSecondEditing="true"></cc1:TimeSelector></td>
            </tr>  
             
            <tr class="tblrowodd">           
                <%--<td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Document Type :"></asp:Label></td>
                <td style="text-align:left;">
                    <asp:DropDownList ID="ddlDocType" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                       
                </td>     --%>       

                <td style='text-align: right; width:120px;'>Document Upload : </td>
                <td style='text-align: center;'>
                    <asp:FileUpload ID="txtDocUpload1" runat="server" AllowMultiple="true"/>                
                </td>           
                <td style="text-align:right;"> 
                <a class="nextclick" onclick="FTPUpload4()">Add</a> </td>
            </tr>    
            <tr><td colspan="4"> 
                <asp:GridView ID="dgvDocUp1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp1_RowDeleting1">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
                <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
                <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="530px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid" >
                <ItemTemplate><asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                           
                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

                </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView></td>
            </tr>
                                       
            <tr>
                <td colspan="4"><asp:Button ID="btnForward" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Save" OnClientClick="FTPUpload5()"/></td>            
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
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            
            <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Details" OnClick="btnDetails_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>--%>

            <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
            <ItemTemplate><asp:Button ID="btnOpen" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intTaskID") %>' Text="Open" OnClick="btnOpen_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>--%>
                
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
            <asp:TemplateField HeaderText="Task Title" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strTaskTitle" >
            <ItemTemplate><asp:Label ID="lblTaskTile" runat="server" Width="200px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strTaskTitle")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Priority" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strPriority" >
            <ItemTemplate><asp:Label ID="lblPriority" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strPriority")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Status" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strStatus" >
            <ItemTemplate><asp:Label ID="lblStatus" runat="server" Width="60px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strStatus")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="% Com" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intCompletePer" >
            <ItemTemplate><asp:Label ID="lblComPer" runat="server" Width="40px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intCompletePer")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Assigned By" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="AssignBy" >
            <ItemTemplate><asp:Label ID="lblAssignBy" runat="server" Width="130px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("AssignBy")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <%--<asp:TemplateField HeaderText="Assigned To" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="AssignTo" >
            <ItemTemplate><asp:Label ID="lblAssignTo" runat="server" Width="130px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("AssignTo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>--%>
              
            <asp:TemplateField HeaderText="Start Date" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="dteStart" >
            <ItemTemplate><asp:Label ID="lblStartDate" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteStart")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Deadline" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="dteDeadline" >
            <ItemTemplate><asp:Label ID="lblDeadline" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteDeadline")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                  
            <%--<asp:TemplateField HeaderText="Complete Date" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="dteComplete" >
            <ItemTemplate><asp:Label ID="lblComDate" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteComplete")) %>'></asp:Label></ItemTemplate></asp:TemplateField>--%>
              
            <asp:TemplateField HeaderText="Remarks" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strRemarks" >
            <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strRemarks")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="intTaskID" Visible="false" ItemStyle-HorizontalAlign="left" SortExpression="intTaskID" >
            <ItemTemplate><asp:Label ID="lblTaskID" runat="server" Width="250px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intTaskID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>        
            

         </table>     
      </div>




 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
