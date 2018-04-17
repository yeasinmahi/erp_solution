<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchExternalReceive.aspx.cs" Inherits="UI.HR.Dispatch.DispatchExternalReceive" %>
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
        <div class="tabs_container"> EXTERNAL DOCUMENT/SPARE PARTS RECEIVE <hr /></div>   
        <table class="tbldecoration" style="width:auto; float:left;">  
                        
            <tr class="tblroweven">
            <td colspan="4" style="color: indigo; font-weight:bold; text-align:center; font-size:18px">EMPLOYEE INFORMATION</td>
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

            <tr class="tblroweven">                
                <td colspan="4" style="color: indigo; font-weight:bold; text-align:center; font-size:18px">FROM</td>
            </tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Consignor :"></asp:Label></td>
                <td><asp:TextBox ID="txtSender" runat="server" CssClass="txtBox" Width="210"></asp:TextBox></td>

                <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Address :"></asp:Label></td>
                <td><asp:TextBox ID="txtSenderAddress" runat="server" CssClass="txtBox" Width="210"></asp:TextBox></td>
            </tr>            
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Description :"></asp:Label></td>
                <td colspan="4"><asp:TextBox ID="txtRemarksMain" runat="server" CssClass="txtBox" Width="515" TextMode="MultiLine"></asp:TextBox></td>
            </tr>

            <tr><td colspan="4"><hr /></td></tr>
            <tr class="tblroweven">                
                <td colspan="4" style="color: indigo; font-weight:bold; text-align:center; font-size:18px">CONSIGNEE</td>
            </tr>                                                    
            <tr>  
                <td style="text-align:right;"><asp:Label ID="lblSeparateType" CssClass="lbl" runat="server" Text="Dispatch Type :"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlDispatchType" runat="server" AutoPostBack="false" CssClass="ddList">
                    <asp:ListItem Selected="True" Value="2">External</asp:ListItem>
                    </asp:DropDownList>            
                </td>  
                
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To/Receiver :"></asp:Label></td>
                <td>
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
                    <asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox>
                </td>  
                
                <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department :"></asp:Label></td>
                <td><asp:TextBox ID="txtDept" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox></td> 
            </tr>            
            <tr> 
                <td style="text-align:right;"><asp:Label ID="lblJobS" CssClass="lbl" runat="server" Text="Job Station :"></asp:Label></td>
                <td><asp:TextBox ID="txtJobS" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox></td>                          

                <td style="text-align:right;"><asp:Label ID="lblDesig" CssClass="lbl" runat="server" Text="Designation :"></asp:Label></td>
                <td><asp:TextBox ID="txtDesig" runat="server" CssClass="txtBox" Width="210" ></asp:TextBox></td>
            </tr>                       
            <tr>                
                <td colspan="4"><asp:Button ID="btnCreate" runat="server" Font-Bold="true" class="nextclick" Text="Doc/Sp Receive" OnClientClick="ConfirmAll()" OnClick="btnCreate_Click"/></td>                        
            </tr>
        </table>
    </div>


    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>