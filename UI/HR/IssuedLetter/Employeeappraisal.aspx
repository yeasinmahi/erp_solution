<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employeeappraisal.aspx.cs" Inherits="UI.HR.IssuedLetter.Employeeappraisal" %>
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
                        data: '{"enroll":"' + $("#hdnloginenroll").val() + '","searchKey":"' + request.term + '"}',
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
    <form id="frmempapprisal" runat="server"><asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;"><marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div><cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <table class="tbldecoration" style="width:auto; float:left; ">
    <tr class="tblrowodd" style="font:14px bold verdana;"><td colspan="2"></td><td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Search :"></asp:Label></td>
    <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtFullName_TextChanged"></asp:TextBox><asp:HiddenField ID="hdnloginenroll" runat="server"/>
    <asp:HiddenField ID="hdnenroll" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/></td></tr>

    <tr><td colspan="4"><asp:Panel ID="pnlpersonalinformation" runat="server"><%# strinformation %></asp:Panel><br /></td></tr>
    <tr class="tblroweven"><td colspan="4"> Individual Career Planing- Assessment Of competencies : (Grading: A=55-45, B=44-35, C=34-25, D=24-0)</td></tr>
    <tr class="tblrowodd"><td colspan="4" style="text-align:left;">
    <asp:GridView ID="dgvgrading" runat="server" AutoGenerateColumns="False" Font-Size="13px" BackColor="White" DataSourceID="odsgrading">
    <Columns>
    <asp:BoundField DataField="strSl" ItemStyle-HorizontalAlign="Center" HeaderText="SL." SortExpression="strSl">
    <ItemStyle HorizontalAlign="Center" Width="50px"/> </asp:BoundField>        
    <asp:BoundField DataField="strAttributes" ItemStyle-HorizontalAlign="Center" HeaderText="ATTRIBUTES" SortExpression="strAttributes">
    <ItemStyle HorizontalAlign="left" Width="280px"/></asp:BoundField>	
    <asp:TemplateField HeaderText="Total marks : 55" >
    <ItemTemplate> <asp:HiddenField ID="hdngrade" runat="server" Value='<%# Eval("intGradingId") %>'/> 	
    <asp:RadioButtonList ID="rdograding" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" Font-Size="10px" Font-Bold="false">
    <asp:ListItem Text="EXCELENT (5)" Value="5"></asp:ListItem><asp:ListItem Text="GOOD (4)" Value="4"></asp:ListItem>
    <asp:ListItem Text="SATISFACTORY (2)" Value="2"></asp:ListItem><asp:ListItem Text="UNSATISFACTORY (0)" Value="0"></asp:ListItem>
    </asp:RadioButtonList></ItemTemplate></asp:TemplateField>

    </Columns></asp:GridView>
    <asp:ObjectDataSource ID="odsgrading" runat="server" SelectMethod="GetGradingList" TypeName="HR_BLL.IssuedLetter.EmployeeIssuedLetter"></asp:ObjectDataSource>
    </td></tr>
    <tr class="tblrowodd"><td colspan="2" style="font:bold 12px verdana; background-color:yellow; text-align:left; padding-left:25px;"><asp:Label ID="lblrcd" runat="server"></asp:Label></td>
   <td colspan="2" style="font:bold 12px verdana; background-color:yellow; text-align:right; padding-right:25px;"><asp:Label ID="lblgrdTotal" runat="server"></asp:Label></td></tr>
    <tr class="tblroweven"><td colspan="4"> Overall Level Of Perfomance : </td></tr>
    <tr class="tblrowodd"><td colspan="4" style="text-align:left;"><asp:RadioButtonList ID="rdolbl" runat="server" RepeatDirection="Horizontal" Font-Size="Small" Font-Bold="false">
    <asp:ListItem Text="Too soon to rate" Value="Too soon to rate"></asp:ListItem><asp:ListItem Text="Unsatisfactory" Value="Unsatisfactory"></asp:ListItem>
    <asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem><asp:ListItem Text="Good" Value="Good"></asp:ListItem>
    <asp:ListItem Text="Vary Good" Value="Very Good"></asp:ListItem><asp:ListItem Text="Outstanding" Value="Outstanding"></asp:ListItem>
    </asp:RadioButtonList></td></tr>


    <tr class="tblrowodd"><td colspan="4" style="font:bold 12px verdana; background-color:yellow; text-align:left; padding-left:5px;""><asp:Label ID="lblprerecord" runat="server"></asp:Label></td></tr>
    <tr class="tblroweven"><td style="text-align:right;"><asp:Label ID="lblpip" CssClass="lbl" runat="server" Text="Proposed Of Increment(%) : "></asp:Label></td>
    <td><asp:TextBox ID="txtIncPer" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblpitk" CssClass="lbl" runat="server" Text="Proposed Of Increment(Tk) : "></asp:Label></td>
    <td><asp:TextBox ID="txtIncTk" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>

    <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblpg" CssClass="lbl" runat="server" Text="Proposed Gross : "></asp:Label></td>
    <td><asp:TextBox ID="txtProGross" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblInterviewdate" CssClass="lbl" runat="server" Text="Proposed Promotion : "></asp:Label></td>
    <td><asp:TextBox ID="txtProProm" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>


    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblrmks" CssClass="lbl" runat="server" Text="Remarks : "></asp:Label></td>
    <td><asp:TextBox ID="txtComments" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
    <td colspan="2" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnSubmit_Click"/></td></tr>

    </table>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
