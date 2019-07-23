<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExperienceupdatePublic.aspx.cs" Inherits="UI.HR.IssuedLetter.ExperienceupdatePublic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title>.: Employee Perfomance :.</title><meta http-equiv="X-UA-Compatible" content="IE=edge" />       
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %> </asp:PlaceHolder> 
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"><%: Scripts.Render("~/Content/Bundle/ProgressJs") %> </asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<webopt:BundleReference ID="bundleReference1" runat="server" Path="~/Content/Bundle/ProgressCSS"/>
    <script>
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetSearchEmployeeList") %>',
                        data: '{"enroll":"' + $("#hdnloginenroll").val() + '","station":"' + $("#hdnloginstation").val() + '","searchKey":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split('^')[0] } }))
                        }
                        //,error: function (response) { alert(response.responseText); },
                        //failure: function (response) { alert(response.responseText); }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
            }, minLength: 1
            });
        });
    </script>
</head>
<body>
    <form id="frmexpupdtpub" runat="server"><asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;"><marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div><cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <table class="tbldecoration" style="width:auto; float:left; ">
    <tr class="tblrowodd" style="font:14px bold verdana;"><td colspan="2"></td><td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Search :"></asp:Label></td>
    <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtFullName_TextChanged"></asp:TextBox>
    <asp:HiddenField ID="hdnenroll" runat="server"/><asp:HiddenField ID="hdnactionby" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
    <asp:HiddenField ID="hdnloginenroll" runat="server"/><asp:HiddenField ID="hdnloginstation" runat="server"/></td></tr>

    <tr><td colspan="4"><asp:Panel ID="pnlpersonalinformation" runat="server"><%# strinformation %></asp:Panel><br /></td></tr>
    <tr class='tblheader'><td colspan='4'>Education Information (School/College/University) : </td></tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblinst" CssClass="lbl" runat="server" Text="Name Of Institute :"></asp:Label></td>
    <td><asp:TextBox ID="txtInstitute" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbldgr" CssClass="lbl" runat="server" Text="Degree/Profrssional : "></asp:Label></td>
    <td><asp:TextBox ID="txtDegree" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="lblmjr" CssClass="lbl" runat="server" Text="Major :"></asp:Label></td>
    <td><asp:TextBox ID="txtMajor" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblpy" CssClass="lbl" runat="server" Text="Passing Year : "></asp:Label></td>
    <td><asp:TextBox ID="txtPassingYear" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class='tblrowodd'><td colspan="4" style="text-align:right;"><asp:Button ID="btnEAdd" runat="server" CssClass="button" Text="ADD" OnClick="btnEAdd_Click" /></td></tr>
    <tr class=""><td style="text-align:justify;" colspan="4">
    <asp:GridView ID="dgvedu" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvedu_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="Name Of Institute" SortExpression="inst">
    <ItemTemplate><asp:Label ID="lblinst" runat="server" Text='<%# Bind("inst") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Degree/Professional" SortExpression="degree">
    <ItemTemplate><asp:Label ID="lbldegree" runat="server" Text='<%# Bind("degree") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Major" SortExpression="major">
    <ItemTemplate><asp:Label ID="lblmajor" runat="server" Text='<%# Bind("major") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Year Of Passing" SortExpression="passingyear">
    <ItemTemplate><asp:Label ID="lblpassingyear" runat="server" Text='<%# Bind("passingyear") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>

    <tr class='tblheader'><td colspan='4'>Training Information (In Company/Overseas) : </td></tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Name Of Institute :"></asp:Label></td>
    <td><asp:TextBox ID="txtTrining" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Course Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtCourse" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Duration :"></asp:Label></td>
    <td><asp:TextBox ID="txtDuration" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;" colspan="2"><asp:Button ID="btnTAdd" runat="server" CssClass="button" Text="ADD" 
    OnClick="btnTAdd_Click"></asp:Button></td>
    </tr>
    <tr class=""><td style="text-align:justify;" colspan="4">
    <asp:GridView ID="dgvtra" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvtra_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="Name Of Institute" SortExpression="tinst">
    <ItemTemplate><asp:Label ID="lbltinst" runat="server" Text='<%# Bind("tinst") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Course Name" SortExpression="course">
    <ItemTemplate><asp:Label ID="lblcourse" runat="server" Text='<%# Bind("course") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="180px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Duration" SortExpression="duration">
    <ItemTemplate><asp:Label ID="lblduration" runat="server" Text='<%# Bind("duration") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>

    <tr class='tblheader'><td colspan='4'>Total Experience Information : </td></tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Name Of Institute :"></asp:Label></td>
    <td><asp:TextBox ID="txtCompany" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
    <td><asp:TextBox ID="txtDept" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Designation :"></asp:Label></td>
    <td><asp:TextBox ID="txtDesg" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="From Date :"></asp:Label></td>
    <td><asp:TextBox ID="txtFdate" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox><script type="text/javascript"> new datepickr('txtFdate', { 'dateFormat': 'Y-m-d' });</script></td>
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtTdate" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox><script type="text/javascript"> new datepickr('txtTdate', { 'dateFormat': 'Y-m-d' });</script></td>
    <td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Total :"></asp:Label></td>
    <td><asp:TextBox ID="txtTotal" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class='tblroweven'><td colspan="4" style="text-align:right;"><asp:Button ID="btnExAdd" runat="server" CssClass="button" 
    Text="ADD" OnClick="btnExAdd_Click" /></td></tr>
    <tr class=""><td style="text-align:justify;" colspan="4">
    <asp:GridView ID="dgvexp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvexp_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="Name Of Institute" SortExpression="exinst">
    <ItemTemplate><asp:Label ID="lblexinst" runat="server" Text='<%# Bind("exinst") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="225px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Department" SortExpression="dpt">
    <ItemTemplate><asp:Label ID="lbldpt" runat="server" Text='<%# Bind("dpt") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="90px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Designation" SortExpression="dsg">
    <ItemTemplate><asp:Label ID="lbldsg" runat="server" Text='<%# Bind("dsg") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="90px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="From" SortExpression="frm">
    <ItemTemplate><asp:Label ID="lblfrm" runat="server" Text='<%# Bind("frm") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="To" SortExpression="to">
    <ItemTemplate><asp:Label ID="lblto" runat="server" Text='<%# Bind("to") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Total" SortExpression="ttl">
    <ItemTemplate><asp:Label ID="lblttl" runat="server" Text='<%# Bind("ttl") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>

    <tr class='tblrowodd'><td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" 
    OnClick="btnSubmit_Click" /></td></tr>

    </table>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>