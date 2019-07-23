<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Discipline_Main.aspx.cs" Inherits="UI.Dairy.Discipline_Main" %>
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

</script>
    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
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
</script>

<script>
    function DocListView(reqsid) {
        window.open('TaskDocView.aspx?intID=' + reqsid, 'sub', "height=600, width=900, scrollbars=yes, left=150, top=50, resizable=no, title=Preview");
    }
</script>

<%--<script> function CloseWindow() {
     window.close();
 } </script>--%>

<%--<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>--%>
                  
</head>
<body>
    <form id="frmselfresign" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
        <div class="tabs_container"> DISCIPLINE ENTRY <hr /></div>

         <table class="tbldecoration" style="width:auto; float:left;">     
             
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Employee Name :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtEmployeeName"
            ServiceMethod="GetSearchEmployee" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            
            <td style="text-align:right;"><asp:Label ID="lblCaseName" runat="server" CssClass="lbl" Text="Case Name :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCaseName" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td> 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblDescription" runat="server" CssClass="lbl" Text="Description :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDescription" runat="server"  CssClass="txtBox" TextMode="MultiLine" Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Created By :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCreatedBy" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCreatedBy"
            ServiceMethod="GetSearchEmployee" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
        </tr>
        <tr>            
            <td style="text-align:right;"><asp:Label ID="lblCreatedOn" runat="server" CssClass="lbl" Text="Created On :"></asp:Label></td>                
            <td><asp:TextBox ID="txtCreatedOn" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtCreatedOn"></cc1:CalendarExtender></td>                          

            <td style="text-align:right;"><asp:Label ID="lblDeadline" runat="server" CssClass="lbl" Text="Deadline :"></asp:Label></td>                
            <td><asp:TextBox ID="txtDeadline" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeadline"></cc1:CalendarExtender></td>             
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblStatus" runat="server" CssClass="lbl" Text="Status:"></asp:Label></td>                
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ddList" Font-Bold="false">
                <asp:ListItem Selected="True" Value="1">Open</asp:ListItem><asp:ListItem Value="2">In Progress</asp:ListItem>
                <asp:ListItem Value="3">Completed</asp:ListItem>         
                </asp:DropDownList>
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblAction" runat="server" CssClass="lbl" Text="Action :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlAction" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>
        </tr>
        <tr class="tblrowodd"> 
            <td style='text-align: right; width:120px;'>Document Upload : </td>
            <td style='text-align: center;'>
                <asp:FileUpload ID="txtDocUpload" runat="server" AllowMultiple="true"/>                
            </td> <asp:HiddenField ID="hdnField" runat="server" />            
            <td style="text-align:right;"> 
            <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
        </tr>    
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
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
            <td colspan="4"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit" OnClientClick="FTPUpload1()"/></td>                        
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
             
            <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="left" SortExpression="strEmployeeName" >
            <ItemTemplate><asp:Label ID="lblEmployeeName" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strEmployeeName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Created By" ItemStyle-HorizontalAlign="left" SortExpression="strCreatedByName" >
            <ItemTemplate><asp:Label ID="lblCreatedBy" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strCreatedByName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
             
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="left" SortExpression="strAction" >
            <ItemTemplate><asp:Label ID="lblAction" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strAction")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
             
            <asp:TemplateField HeaderText="Case" ItemStyle-HorizontalAlign="left" SortExpression="strCase" >
            <ItemTemplate><asp:Label ID="lblCase" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strCase")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                 
            <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="left" SortExpression="strDescription" >
            <ItemTemplate><asp:Label ID="lblDescription" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strDescription")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Created On" ItemStyle-HorizontalAlign="center" SortExpression="dteCreatedOn" >
            <ItemTemplate><asp:Label ID="lblCreatedOn" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteCreatedOn")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Deadline" ItemStyle-HorizontalAlign="center" SortExpression="dteDeadline" >
            <ItemTemplate><asp:Label ID="lblDeadline" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteDeadline")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="left" SortExpression="strStatus" >
            <ItemTemplate><asp:Label ID="lblStatus" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strStatus")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Document View" >
            <ItemTemplate><asp:Button ID="btnDocVew" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDisciplineID") %>' Text="Document View" OnClick="btnDocVew_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
              
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
