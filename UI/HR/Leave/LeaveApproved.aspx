<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveApproved.aspx.cs" Inherits="UI.HR.Leave.LeaveApproved" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Leave Application Process</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/updatedCss" />
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <script type="text/javascript" src="../../Content/JS/scriptLeaveProcess.js"></script>


</head>
<body>
    <form id="frmLeaveApproveProcess" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 20px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--===========================Start My Code From Here======== DataFormatString="{0:yyyy-MM-dd}"=====================--%>

                <div class="divs_content_container">
                    <div class="tabs_container">
                        Employee Leave Application Process :<hr />
                    </div>
                    <asp:HiddenField ID="hdnEmpCode" runat="server" />
                    <asp:HiddenField ID="hdnLeaveType" runat="server" />
                    <table border="0px" style="width: auto" align="center">

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblleavelist" CssClass="lbl" runat="server" Text="Select Application Type : ">
                                </asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlist" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="ddlist_SelectedIndexChanged">
                                    <asp:ListItem Text="New Application" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Approved Application" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Rejected Application" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">

                                <asp:GridView ID="dgvUPLeaveApplication" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" OnDataBinding="dgvUPLeaveApplication_DataBinding">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Code" SortExpression="strEmployeeCode" Visible="False">

                                            <ItemTemplate>
                                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("strEmployeeCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="325px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="strEmployeeName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="325px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From-Date" SortExpression="dateAppliedFromDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromDate" runat="server" Text='<%# Bind("dateAppliedFromDate", "{0:yyyy-MM-dd}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To-Date" SortExpression="dateAppliedToDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblToDate" runat="server" Text='<%# Bind("dateAppliedToDate", "{0:yyyy-MM-dd}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave Type" SortExpression="strLeaveType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("strLeaveType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave Type ID" SortExpression="intLeaveTypeID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaveTypeID" runat="server" Text='<%# Bind("intLeaveTypeID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Days" SortExpression="TotalDays">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalday" runat="server" Text='<%# Bind("TotalDays") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                        <%-- ========  visible false ===========--%>

                                        <asp:TemplateField HeaderText="strJobType" SortExpression="strJobType" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrJobType" runat="server" Text='<%# Bind("strJobType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="intRemainingDays" SortExpression="intRemainingDays" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblintRemainingDays" runat="server" Text='<%# Bind("intRemainingDays") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="intApplicationId" SortExpression="TotaintApplicationIdlDays" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblintApplicationId" runat="server" Text='<%# Bind("intApplicationId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                        <%-- ======== end visible false ===========--%>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnProcess" runat="server" CssClass="btn btn-primary btn-xs" OnClick="btnProcess_Click" Text="Process" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                                <%-- <asp:ObjectDataSource ID="odsunapproved" runat="server" SelectMethod="GetUnapprovedLeaveApplication" TypeName="HR_BLL.Leave.LeaveApplicationProcess">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlist" Name="appstatus" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>


                            </td>
                        </tr>

                    </table>
                </div>

                <%--<div id="approvedDiv">
       <table border="0px"; style="width:Auto"; align="center" >

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblcode" CssClass="lbl" runat="server" Text="Card-No : "></asp:Label></td>
        <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblemployeename" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lbljobstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobStatus" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblleavetype" CssClass="lbl" runat="server" Text="Leave-Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtLeaveType" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
       </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td>
            <asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
        </td>
        </tr>
                
        <tr>
        <td style="text-align:right;"><asp:Label ID="remaining" CssClass="lbl" runat="server" Text="Remaining-Days : "></asp:Label></td>
        <td><asp:TextBox ID="txtRemainingDays" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblappsts" CssClass="lbl" runat="server" Text="Pay-Status : "></asp:Label></td>
        <td>
            <asp:RadioButton ID="rdoWithpay" runat="server" Text="With-Pay" GroupName="PaymentStatus"/>
            <asp:RadioButton ID="rdoLWP" runat="server" Text="WithOut-Pay" GroupName="PaymentStatus"/>
        </td>      
        </tr>

        <tr>
           <td colspan="4"><hr /><asp:HiddenField ID="hdnReject" runat="server"/>
           <asp:HiddenField ID="hdnAppID" runat="server"/><a class="nextclick" onclick="HideReasonDiv()">Cancel</a> 
           <a class="nextclick" onclick="Reject()">Reject</a><a class="nextclick" onclick="Confirm()">Approved</a> 
           <asp:HiddenField ID="hdnAction" runat="server"/> <asp:HiddenField ID="hdnApproved" runat="server"/>         
       </td>
        </tr> 
              
    </table>
        <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:500px; border:0px solid red;"></iframe>
    </div>--%>
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Leave Details</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:Label ID="lblcode" CssClass="lbl" runat="server" Text="Card-No : "></asp:Label>
                                        <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:Label ID="lblemployeename" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label>
                                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:Label ID="lbljobstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label>
                                        <asp:TextBox ID="txtJobStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date :  "></asp:Label>
                                        <asp:TextBox ID="txtDteFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date  :  "></asp:Label>
                                        <asp:TextBox ID="txtDteTo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:Label ID="remaining" CssClass="lbl" runat="server" Text="Remaining-Days :  "></asp:Label>
                                        <asp:TextBox ID="txtRemainingDays" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <asp:RadioButton ID="rdoLWP" runat="server" Text="WithOut-Pay" GroupName="PaymentStatus" />
                                        <asp:RadioButton ID="rdoWithpay" runat="server" Text="With-Pay" GroupName="PaymentStatus" />
                                    </div>
                                    <asp:HiddenField ID="hdnAppID" runat="server" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="col-md-12" style="padding-bottom: 10px;">
                                    <asp:Button ID="btnApproved" CssClass="btn btn-success btn-sm" runat="server" Text="Approved" OnClick="btnApproved_Click" OnClientClick="return Confirm()" />
                                    <asp:Button ID="btnReject" CssClass="btn btn-danger btn-sm" runat="server" Text="Reject" OnClick="btnReject_Click" OnClientClick="return Reject()" />

                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 300px; border: 0px solid red;"></iframe>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>


                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnApproved" />
                <asp:PostBackTrigger ControlID="btnReject" />
                <asp:PostBackTrigger ControlID="dgvUPLeaveApplication" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
    <script>
        $(function () {

            Init();
            //ShowHideGridviewPanels();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
        });
        function Init() {
            $('#txtDteFrom').datepicker();
            $('#txtDteTo').datepicker();
        }

    </script>
</body>
</html>
