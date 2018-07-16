<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueItemByRequesition.aspx.cs" Inherits="UI.SCM.IssueItemByRequesition" %>

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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    


    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 
     <script>
         function Viewdetails(ReqId, ReqCode, dteReqDate, strDepartmentName, strReqBy, strApproveBy, intwh, DeptID, SectionID, SectionName) {
             window.open('IssueItemByRequesitionDetalis.aspx?ReqId=' + ReqId + '&ReqCode=' + ReqCode + '&dteReqDate=' + dteReqDate + '&strDepartmentName=' + strDepartmentName + '&strReqBy=' + strReqBy + '&strApproveBy=' + strApproveBy + '&intwh=' + intwh + '&DeptID=' + DeptID + '&SectionID=' + SectionID + '&SectionName=' + SectionName, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
              
         }
    </script>
   <script>
         function ViewdetailsAFBL(ReqId, ReqCode, dteReqDate, strDepartmentName, strReqBy, strApproveBy, intwh, DeptID, SectionID, SectionName) {
             window.open('IssueItemByRequesitionDetalisAFBL.aspx?ReqId=' + ReqId + '&ReqCode=' + ReqCode + '&dteReqDate=' + dteReqDate + '&strDepartmentName=' + strDepartmentName + '&strReqBy=' + strReqBy + '&strApproveBy=' + strApproveBy + '&intwh=' + intwh + '&DeptID=' + DeptID + '&SectionID=' + SectionID + '&SectionName=' + SectionName, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
              
         }
    </script>
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left: 70px;  margin-top:100px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Store Issue From<hr /></div>
         
       <table>
            <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"   ></asp:DropDownList></td>                                                                                      
           <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteFrom"></cc1:CalendarExtender></td>

            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteTo"></cc1:CalendarExtender></td> 
           
           <td style="text-align:right"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /> </td>
            </tr> 
        </table>
        <table>
           <tr><td> 
            <asp:GridView ID="dgvReq" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false"><ItemTemplate>
            <asp:Label ID="lblReqId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="SR NO" SortExpression="ReqCode"><ItemTemplate>
            <asp:Label ID="lblReqSR" runat="server" Text='<%# Bind("ReqCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="SR Date" ItemStyle-HorizontalAlign="right" SortExpression="dteReqDate" >
            <ItemTemplate><asp:Label ID="lblReqDate" runat="server"   Text='<%# Bind("dteReqDate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>

            <asp:TemplateField HeaderText="Department" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="strDepartmentName" >
            <ItemTemplate><asp:Label ID="lblDept" runat="server"  Text='<%# Bind("strDepartmentName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField> 
             
             <asp:TemplateField HeaderText="Section"   ItemStyle-HorizontalAlign="right" SortExpression="strSectionName" >
            <ItemTemplate><asp:Label ID="lblSection" runat="server"  Text='<%# Bind("strSectionName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="200px" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="DeptId" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intDeptID" >
            <ItemTemplate><asp:Label ID="lblDeptID" runat="server"  Text='<%# Bind("intDeptID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="SectionID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intSectionID" >
            <ItemTemplate><asp:Label ID="lblSectionId" runat="server"  Text='<%# Bind("intSectionID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField>  

          
            
            <asp:TemplateField HeaderText="Approve By" ItemStyle-HorizontalAlign="right" SortExpression="strApproveBy" >
            <ItemTemplate><asp:Label ID="lblIndentType" runat="server"   Text='<%# Bind("strApproveBy") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="ReqBy" ItemStyle-HorizontalAlign="right" SortExpression="strReqBy" > 
            <ItemTemplate><asp:Label ID="lblIndentBy"    runat="server"  Text='<%# Bind("strReqBy") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalis" runat="server" Text="Detalis" CommandArgument='<%#GetJSFunctionString( Eval("Id"),Eval("ReqCode"),Eval("dteReqDate"),Eval("strDepartmentName"),Eval("strReqBy"),Eval("strApproveBy"),Eval("intDeptID"),Eval("intSectionID"),Eval("strSectionName")) %>'   OnClick="btnDetalis_Click" /> </ItemTemplate> 
            </asp:TemplateField>

            </Columns>
             <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
        </tr> 
           
        </table>
        </div>
       

        </div>

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

