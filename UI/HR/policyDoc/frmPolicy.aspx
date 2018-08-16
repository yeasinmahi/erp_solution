<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPolicy.aspx.cs" Inherits="UI.HR.policyDoc.frmPolicy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server"> <title>.: Cash Salary Profile :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"> <%: Scripts.Render("~/Content/Bundle/jqueryJS") %> </asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <%--<link href="../../Content/CSS/Application.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "SalaryCash.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            //alert("Error");
                        }
                    });
                }
            });
        }
        function Confirm() {
            document.getElementById("hdnAction").value = "";
            var txtAccholdr = document.forms["frmcash"]["txtAccholdr"].value;
            var txtAccountNo = document.forms["frmcash"]["txtAccountNo"].value;
            var txtAmount = document.forms["frmcash"]["txtAmount"].value;

            if (txtAccholdr.length <= 0 || txtAccholdr == "" || txtAccholdr == null)
            { alert("Please enter valid account holder ."); }
            else if (txtAccountNo.length <= 0 || txtAccountNo == "" || txtAccountNo == null)
            { alert("Please enter valid account no."); }
            else if (!isDecimal(txtAmount) || txtAmount.length <= 0)
            { alert("Please enter valid amount ."); }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnAction").value = "0"; }
                else { confirm_value.value = "No"; document.getElementById("hdnAction").value = ""; }
                __doPostBack();
            }
        }
        function isDecimal(value) {return parseFloat(value) == value;} // Check Intiger values by value % 1 === 0;        
        function ConfirmDelete() {
            document.getElementById("hdndelete").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdndelete").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdndelete").value = "0"; }
        }

    </script>
</head>
<body>
    <form id="frmcash" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    <CompositeScript>
        <Scripts>
            <asp:ScriptReference name="MicrosoftAjax.js"/>
		    <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		    <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
        </Scripts>
    </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
      <div class="tabs_container"><b> CORPORATE PLOICY DOCUMENTS</b> <hr /></div>
        <asp:HiddenField ID="hdnCustid" runat="server"/> <asp:HiddenField ID="hdnSlipno" runat="server"/>  
        <asp:HiddenField ID="hdnCustname" runat="server"/>
        <table class="tbldecoration" style="width:auto; float:left;">                                  
        <tr><td>Name :<asp:Label ID="lblname" runat="server"></asp:Label></td><td colspan="2"></td> </tr> 
        <tr><td>Enroll :<asp:Label ID="lblenroll" runat="server"></asp:Label></td><td colspan="2" style="text-align:right"><asp:Button ID="btnSubmit" Font-Bold="true" runat="server" class="myButton" Text="Submit" OnClick="btnSubmit_Click"  />  </td> </tr>                       
        <tr><td colspan="3"><hr />
        <asp:GridView ID="dgvRpt" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" OnRowDataBound="dgvRpt_RowDataBound" ForeColor="Black" GridLines="Vertical" ><AlternatingRowStyle BackColor="#CCCCCC" Font-Bold="true" />
        <Columns>
        <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField> 
      
        <asp:BoundField DataField="strDepartment" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountHolder">
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField>
    
        <asp:TemplateField HeaderText="Document  Link">
        <ItemTemplate> <asp:HyperLink ID="strDocLink" HeaderText="Document  Link" runat="server" Target="_blank" Text='<%# Eval("strDocumentName") %>'
        NavigateUrl='<%# Eval("strDocLink") %>'></asp:HyperLink><ItemStyle HorizontalAlign="Right" Width="220px"/>
        </ItemTemplate> </asp:TemplateField>

        <asp:BoundField DataField="dteDocGenerate" HeaderText="Reading Date" ItemStyle-Width="800px" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}" SortExpression="strBankName">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField>
        <asp:BoundField DataField="status" HeaderText="Reading Status" ItemStyle-HorizontalAlign="Center" SortExpression="strBankBranchName">
        <ItemStyle HorizontalAlign="Left" Width="60px" /></asp:BoundField>
        <asp:BoundField DataField="ysnAcknowledged" Visible="false" HeaderText="Reading Status" ItemStyle-HorizontalAlign="Center" SortExpression="strBankBranchName">
        <ItemStyle HorizontalAlign="Left" Width="130px" /></asp:BoundField>
   
        <asp:TemplateField HeaderText="Read/Unread"> <ItemTemplate>
        <asp:HiddenField ID="hdndocid" Value='<%# Eval("intDocId") %>' runat="server" />
        <asp:HiddenField ID="hdnsatus" Value='<%# Eval("ysnAcknowledged") %>' runat="server" />
        <asp:CheckBox ID="chkStatus" runat="server" Checked='<%# Convert.ToBoolean(Eval("ysnAcknowledged")) %>'
        Text='<%# Eval("ysnAcknowledged").ToString().Equals("1") ? " Read " : "Understood & Acknowledged " %>' />
        <ItemStyle HorizontalAlign="Right" Width="130px"/> </ItemTemplate> </asp:TemplateField>


        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
        </td></tr>  
        </table>                        
    </div>
    

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
