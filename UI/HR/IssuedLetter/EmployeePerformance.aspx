<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePerformance.aspx.cs" Inherits="UI.HR.IssuedLetter.EmployeePerformance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Employee Perfomance :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />       
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/Promotionjs.js"></script>
    <style>
        .tbldecoration {width:auto; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; 
        border-radius: 5px; padding:2px; color:#006; font-size:12px; font-weight:bold;}
        .tblheader {border:0px solid #000;color: #000000; background-color:#D0D0D0; padding:5px; font:bold 13px verdana;}
        .tblrowodd {border:0px solid #000;color: #000000; background-color:#F8F8F8;}
        .tblroweven {border:0px solid #000;color: #000000; background-color:#eeeeee;}
        table { border-collapse: collapse;} 
        td { margin: 0px; padding: 1px; border:1px solid #080808; }
        .border { border: 1px solid #080808; }
        .noborders td { border:0; }
        .nobordertable table { border:0; }
    </style>
    
</head>
<body>
    <form id="frmperfomance" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate><asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

    <table style="width:auto; float:left;font-size:11px;">
    <tr class="tblheader"><td style="text-align:center;"> <u>Individual Progress Report, 2014</u><br />(Confidential)</td></tr>
    <tr class="tblroweven"><td> Employee Information : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;"><asp:Label ID="lblka1" CssClass="lbl" runat="server" Text="Employee Name :"></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtEmployee" runat="server" CssClass="txtBox" Width="370px" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:right;"><asp:Label ID="lblprimary" CssClass="lbl" runat="server" Text="Employee Code : "></asp:Label></td>
        <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Enroll No. : "></asp:Label></td>
        <td><asp:TextBox ID="txtEnroll" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblsrl" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblInterviewdate" CssClass="lbl" runat="server" Text="Joining Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtJoindate" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        </tr>

        <tr><td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
        <td><asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Employment Nature : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobtype" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Sex : "></asp:Label></td>
        <td><asp:TextBox ID="txtSex" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Remarks : "></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" BorderStyle="None" Enabled="false"></asp:TextBox></td></tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Education Information (School/College/University) : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Name Of Institute :"></asp:Label></td>
        <td><asp:TextBox ID="txtInstitute" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Degree/Profrssional : "></asp:Label></td>
        <td><asp:TextBox ID="txtDegree" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr><td style="text-align:right;"><asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Major :"></asp:Label></td>
        <td><asp:TextBox ID="txtMajor" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Passing Year : "></asp:Label></td>
        <td><asp:TextBox ID="txtPassingYear" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr style="text-align:right;"><td colspan="4"><asp:Button ID="btnEduAdd" runat="server" CssClass="nextclick" Text="Click For Add" OnClientClick="EduInfo()" OnClick="btnEduAdd_Click"></asp:Button></td></tr>
        <tr><td colspan="4" style="text-align:right;">
        <asp:GridView ID="dgvedu" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" OnRowDeleting="dgvedu_RowDeleting" AllowPaging="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Institute" SortExpression="institute">
        <ItemTemplate><asp:Label ID="lblinstitute" runat="server" Text='<%# Bind("institute") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtinstitute" runat="server" Text='<%# Bind("institute") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Degree/Professional" SortExpression="degree">
        <ItemTemplate><asp:Label ID="lbldegree" runat="server" Text='<%# Bind("degree") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtdegree" runat="server" Text='<%# Bind("degree") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Major" SortExpression="major">
        <ItemTemplate><asp:Label ID="lblmajor" runat="server" Text='<%# Bind("major") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtmajor" runat="server" Text='<%# Bind("major") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Year Of Passing" SortExpression="passingyear">
        <ItemTemplate><asp:Label ID="lblpassingyear" runat="server" Text='<%# Bind("passingyear") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtpassingyear" runat="server" Text='<%# Bind("passingyear") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" />
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Training Information (In Company/Overseas) : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;"><asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Name Of Institute :"></asp:Label></td>
        <td><asp:TextBox ID="txtTrining" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Course Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtCourse" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr><td style="text-align:right;"><asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Duration :"></asp:Label></td>
        <td><asp:TextBox ID="txtDuration" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;" colspan="2"><asp:Button ID="btnTrainAdd" runat="server" CssClass="nextclick" Text="Click For Add" 
        OnClientClick="TrainingInfo()" OnClick="btnTrainAdd_Click"></asp:Button></td></tr>

        <tr><td colspan="4" style="text-align:right;">
        <asp:GridView ID="dgvtraining" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" OnRowDeleting="dgvtraining_RowDeleting" AllowPaging="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Institute" SortExpression="trinstitute">
        <ItemTemplate><asp:Label ID="lbltrinstitute" runat="server" Text='<%# Bind("trinstitute") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txttrinstitute" runat="server" Text='<%# Bind("trinstitute") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Course" SortExpression="course">
        <ItemTemplate><asp:Label ID="lblcourse" runat="server" Text='<%# Bind("course") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtcourse" runat="server" Text='<%# Bind("course") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Duration" SortExpression="duration">
        <ItemTemplate><asp:Label ID="lblduration" runat="server" Text='<%# Bind("duration") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtduration" runat="server" Text='<%# Bind("duration") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" />
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Language and Total Experience Information : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;"><asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Bengali (%) :"></asp:Label></td>
        <td><asp:TextBox ID="txtBengali" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Ennlish (%) : "></asp:Label></td>
        <td><asp:TextBox ID="txtEnglish" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Others (%): "></asp:Label></td>
        <td><asp:TextBox ID="txtOthers" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Remarks : "></asp:Label></td>
        <td><asp:TextBox ID="txtLanRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Exp. in others company (Months) : "></asp:Label></td>
        <td><asp:TextBox ID="txtTotalExpOthersCompany" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"></td><td></td>
        </tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Review Of Performance : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;"><asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Period From:"></asp:Label></td>
        <td><asp:TextBox ID="dtePeriodFrom" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CPF" runat="server" Format="yyyy-MM-dd" TargetControlID="dtePeriodFrom"></cc1:CalendarExtender></td>
        <td style="text-align:right;"><asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Period To : "></asp:Label></td>
        <td><asp:TextBox ID="dtePeriodTo" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CPT" runat="server" Format="yyyy-MM-dd" TargetControlID="dtePeriodTo"></cc1:CalendarExtender></td>
        </tr>
    
        <tr><td style="text-align:right;"><asp:Label ID="Label22" CssClass="lbl" runat="server" Text="Challenging Task:"></asp:Label></td>
        <td><asp:TextBox ID="txtTask" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label23" CssClass="lbl" runat="server" Text="Level Of Achivement : "></asp:Label></td>
        <td><asp:TextBox ID="txtAchivement" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr><td style="text-align:right;"><asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Achive (%) :"></asp:Label></td>
        <td><asp:TextBox ID="txtAchive" runat="server" CssClass="txtBox"></asp:TextBox></td>
        <td style="text-align:right;" colspan="2"><asp:Button ID="btnAchive" runat="server" CssClass="nextclick" Text="Click For Add" 
        OnClientClick="AchiveInfo()" OnClick="btnAchiveAdd_Click"></asp:Button></td></tr>

        <tr><td colspan="4" style="text-align:right;">
        <asp:GridView ID="dgvachive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" OnRowDeleting="dgvachive_RowDeleting" AllowPaging="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Period From" SortExpression="dteprdfrom">
        <ItemTemplate><asp:Label ID="lbldteprdfrom" runat="server" Text='<%# Bind("dteprdfrom") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtdteprdfrom" runat="server" Text='<%# Bind("dteprdfrom") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
        <asp:TemplateField HeaderText="Period To" SortExpression="dteprdto">
        <ItemTemplate><asp:Label ID="lbldteprdto" runat="server" Text='<%# Bind("dteprdto") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtdteprdto" runat="server" Text='<%# Bind("dteprdto") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Challenging Task" SortExpression="ctask">
        <ItemTemplate><asp:Label ID="lblctask" runat="server" Text='<%# Bind("ctask") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtctask" runat="server" Text='<%# Bind("ctask") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Achivement" SortExpression="cachivement">
        <ItemTemplate><asp:Label ID="lblcachivement" runat="server" Text='<%# Bind("cachivement") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtcachivement" runat="server" Text='<%# Bind("cachivement") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Achive (%)" SortExpression="cachive">
        <ItemTemplate><asp:Label ID="lblcachive" runat="server" Text='<%# Bind("cachive") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtcachive" runat="server" Text='<%# Bind("cachive") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" />
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Overall Level Of Perfomance : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr style="text-align:left;"><td colspan="2"><asp:RadioButtonList ID="rdoper" runat="server" RepeatDirection="Horizontal" Font-Size="Small" Font-Bold="false">
        <asp:ListItem Text="Too soon to rate" Value="Too soon to rate"></asp:ListItem><asp:ListItem Text="Unsatisfactory" Value="Unsatisfactory"></asp:ListItem>
        <asp:ListItem Text="Satisfactory" Value="Satisfactory"></asp:ListItem><asp:ListItem Text="Good" Value="Good"></asp:ListItem>
        <asp:ListItem Text="Vary Good" Value="Very Good"></asp:ListItem><asp:ListItem Text="Outstanding" Value="Outstanding"></asp:ListItem>
        </asp:RadioButtonList></td></tr>

        <tr><td style="text-align:right;"><asp:Label ID="Label26" CssClass="lbl" runat="server" Text="When job description last update: "></asp:Label></td>
        <td><asp:TextBox ID="dteLastupdate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CLU" runat="server" Format="yyyy-MM-dd" TargetControlID="dteLastupdate"></cc1:CalendarExtender></td></tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Individual Career Planing- Assessment Of competencies : (Grading: A=55-45, B=44-35, C=34-25, D=24-0)</td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;">
        <asp:GridView ID="dgvgrading" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="9px" BackColor="White" 
        ShowFooter="True" FooterStyle-BackColor="Yellow" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="Red" DataSourceID="odsgrading">
        <Columns>
        <asp:BoundField DataField="strSl" ItemStyle-HorizontalAlign="Center" HeaderText="SL." SortExpression="strSl">
        <ItemStyle HorizontalAlign="left" Width="10px"/> </asp:BoundField>        
        <asp:BoundField DataField="strAttributes" ItemStyle-HorizontalAlign="Center" HeaderText="ATTRIBUTES" SortExpression="strAttributes">
        <ItemStyle HorizontalAlign="left" Width="120px"/>
        </asp:BoundField>	
        <asp:TemplateField HeaderText="Total marks : 55" >
        <ItemTemplate> <asp:HiddenField ID="hdngrade" runat="server" Value='<%# Eval("intGradingId") %>'/> 	
        <asp:RadioButtonList ID="rdograding" runat="server" RepeatDirection="Horizontal" Font-Size="10px" Font-Bold="false">
        <asp:ListItem Text="EXCELENT (5)" Value="5"></asp:ListItem><asp:ListItem Text="GOOD (4)" Value="4"></asp:ListItem>
        <asp:ListItem Text="SATISFACTORY (2)" Value="2"></asp:ListItem><asp:ListItem Text="UNSATISFACTORY (0)" Value="0"></asp:ListItem>
        </asp:RadioButtonList>
        </ItemTemplate>
        <FooterTemplate><asp:Label ID="lblAchievePoint" runat="server" Text="Achive Number : "></asp:Label></FooterTemplate><FooterStyle HorizontalAlign="Right" Font-Size="12px" ForeColor="Red" />
         </asp:TemplateField>

        </Columns></asp:GridView>
        <asp:ObjectDataSource ID="odsgrading" runat="server" SelectMethod="GetGradingList" TypeName="HR_BLL.IssuedLetter.EmployeeIssuedLetter"></asp:ObjectDataSource>
        </td></tr>
        </table>
    </tr>

    <tr class="tblroweven"><td> Expressed Career Goals : </td></tr>
    <tr class="tblrowodd"><td>
        <table style="width:100%; -moz-border-radius: 5px; border:1px double #666;-webkit-border-radius:5px; border-radius: 5px; padding:2px;"; >
        <tr><td style="text-align:right;"><asp:Label ID="Label24" CssClass="lbl" runat="server" Text="Short Term :"></asp:Label></td>
        <td><asp:TextBox ID="txtShortterm" runat="server" CssClass="txtBox" Width="370px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:right;"><asp:Label ID="Label30" CssClass="lbl" runat="server" Text="Long Term: "></asp:Label></td>
        <td><asp:TextBox ID="txtLongterm" runat="server" CssClass="txtBox" Width="370px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:right;"><asp:Label ID="Label25" CssClass="lbl" runat="server" Text="Willing to relocate anyunit / anywhere: "></asp:Label></td>
        <td style="text-align:left;"><asp:RadioButtonList ID="rdorelocate" runat="server" RepeatDirection="Horizontal" Font-Size="Small" Font-Bold="false">
        <asp:ListItem Text="Yes" Value="1"></asp:ListItem><asp:ListItem Text="No" Value="0"></asp:ListItem></asp:RadioButtonList></td>
        </tr>
        <tr><td style="text-align:right;"><asp:Label ID="Label27" CssClass="lbl" runat="server" Text="Preference to Work : "></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtpretowork" runat="server" CssClass="txtBox" Width="350px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        
        <tr><td style="text-align:left;" colspan="2"><asp:Label ID="Label31" CssClass="lbl" runat="server" Text="Employees comments : "></asp:Label></td></tr>
        <tr><td colspan="2"><asp:TextBox ID="txtComments" runat="server" CssClass="txtBox" Width="595px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:left;" colspan="2"><asp:Label ID="Label32" CssClass="lbl" runat="server" Text="Assessors additional comments (strength, weakness, areas for improvement and promotion potential) : "></asp:Label></td></tr>
        <tr><td colspan="2"><asp:TextBox ID="txtPotential" runat="server" CssClass="txtBox" Width="370px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:left;" colspan="2"><asp:Label ID="Label33" CssClass="lbl" runat="server" Text="Specific Development task/plans : "></asp:Label></td></tr>
        <tr><td colspan="2"><asp:TextBox ID="txtSelfdevelopment" runat="server" CssClass="txtBox" Width="595px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align:left;" colspan="2"><asp:Label ID="Label34" CssClass="lbl" runat="server" Text="Challenging task for next year (include date[year-month-day]) : "></asp:Label></td></tr>
        <tr><td colspan="2"><asp:TextBox ID="txtChaTaskTarget" runat="server" CssClass="txtBox" Width="370px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>            
        <tr><td style="text-align:left;" colspan="2">
        <asp:Label ID="Label35" CssClass="lbl" runat="server" Text="Employee Signature : "></asp:Label><asp:FileUpload ID="signature" runat="server" AllowMultiple="true" CssClass="txtBox"/></td>
        </tr>
        <tr><td colspan="2"><br /></td></tr>


        </table>
    </td></tr>

    <tr style="text-align:right;"><td><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" Text="Click For Submit" OnClientClick="Validation()" 
    OnClick="btnSubmit_Click"></asp:Button></td></tr>






</table>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
