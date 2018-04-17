<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpanceReport_UI.aspx.cs" Inherits="UI.Personal.ExpanceReport_UI" %>


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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

  
    


  
    <script>
        function Viewdetails(costid, strName,  stryear) {
            window.open('ExpenseDetalis_PopUP.aspx?costid=' + costid + '&strName=' + strName + '&stryear=' + stryear, 'sub', "scrollbars=yes,toolbar=0,height=500,width=800,top=100,left=300, resizable=yes, title=Preview");
        }
    </script>

    
    <style type="text/css">
        #divFile p { 
            font:15px tahoma, arial; 
        }
        #divFile h3 { 
            font:16px arial, tahoma; 
            font-weight:bold;
        }
        .auto-style1 {
            height: 25px;
        }
        .txtBox {}
    </style>

    
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />        
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
    <asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnHightMilage" runat="server" />
      
       
        <div class="tabs_container">Budget Variance Report<hr /></div>

        <table>
           <tr>
               <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
                <td><asp:DropDownList ID="DDlType" runat="server"  CssClass="dropdownList" AutoPostBack="True">
                    <asp:ListItem>Monthly</asp:ListItem><asp:ListItem>Quarterly</asp:ListItem> 
                    </asp:DropDownList> </td>
             <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Year : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlYear" runat="server"  CssClass="dropdownList" AutoPostBack="True">
                    <asp:ListItem>2016</asp:ListItem><asp:ListItem>2017</asp:ListItem><asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem><asp:ListItem>2020</asp:ListItem><asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem><asp:ListItem>2023</asp:ListItem><asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem><asp:ListItem>2026</asp:ListItem><asp:ListItem>2027</asp:ListItem>
                    <asp:ListItem>2028</asp:ListItem><asp:ListItem>2029</asp:ListItem><asp:ListItem>2030</asp:ListItem>
                   
                    </asp:DropDownList> </td>
               <td> <asp:Button ID="BtnShow" runat="server" Text="Show" OnClick="BtnShow_Click" /></td>
               
           </tr>
     
              
              
        </table>
        <table border="0">
            <tr style="border:1px solid red; text-align:center"><td style="width:455px;"><asp:Label ID="hh" runat="server"></asp:Label></td><td   style="width:475px;"><asp:Label ID="lblJul" Font-Bold="true" ForeColor="green" runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="lblAug" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="LblSep" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblOct" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="LblNov" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblDec" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblJan" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblFeb" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblMar" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblApr" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblMay" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblJun" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:100px;"><asp:Label ID="Label3" runat="server"></asp:Label></td></tr>
             <tr>
                   <td colspan="14">
                       <asp:GridView ID="DgvExpance"  runat="server" AutoGenerateColumns="False"    >
                           <Columns>
                                <asp:TemplateField HeaderText="Detalis">
                                   <ItemTemplate>
                                       <asp:Button ID="btnMonthly" runat="server" Text="Detalis" CommandName="monthle"   CommandArgument='<%#GetJSFunctionString( Eval("intCostCenter"),Eval("strAccountName")) %>' OnClick="btnMonthlyD_Click" ItemStyle-Width="100px"  />
                                   
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sl.N" >
                                   <ItemTemplate ><ItemStyle Width="100px"></ItemStyle>
                                       <%# Container.DataItemIndex + 1 %>
                                   </ItemTemplate>
                               </asp:TemplateField>
                              
                               
                               <asp:BoundField DataField="intCostCenter" HeaderText="ID"  SortExpression="intCostCenter" >  <ItemStyle Width="55px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="strAccountName" HeaderText="CostCenter" SortExpression="strAccountName"   > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget1" HeaderText="Budget" SortExpression="monBudget1" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount1" HeaderText="Actual" SortExpression="monAmount1" DataFormatString="{0:N2}"> <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var1" HeaderText="Variance" SortExpression="var1" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                              <asp:BoundField DataField="monBudget2" HeaderText="Budget" SortExpression="monBudget2" DataFormatString="{0:N2}"> <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount2" HeaderText="Actual" SortExpression="monAmount2" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var2" HeaderText="Variance" SortExpression="var2" DataFormatString="{0:N2}"> <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                          <asp:BoundField DataField="monBudget3" HeaderText="Budget" SortExpression="monBudget3" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount3" HeaderText="Actual" SortExpression="monAmount3" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var3" HeaderText="Variance" SortExpression="var3" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget4" HeaderText="Budget" SortExpression="monBudget4" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount4" HeaderText="Actual" SortExpression="monAmount4" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var4" HeaderText="Variance" SortExpression="var4" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget5" HeaderText="Budget" SortExpression="monBudget5" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount5" HeaderText="Actual" SortExpression="monAmount5" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var5" HeaderText="Variance" SortExpression="var5" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                          <asp:BoundField DataField="monBudget6" HeaderText="Budget" SortExpression="monBudget6" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount6" HeaderText="Actual" SortExpression="monAmount6" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var6" HeaderText="Variance" SortExpression="var6" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget7" HeaderText="Budget" SortExpression="monBudget7" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount7" HeaderText="Actual" SortExpression="monAmount7" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var7" HeaderText="Variance" SortExpression="var7" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>

                               <asp:BoundField DataField="monBudget8" HeaderText="Budget" SortExpression="monBudget8" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount8" HeaderText="Actual" SortExpression="monAmount8" DataFormatString="{0:N2}"> <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var8" HeaderText="Variance" SortExpression="var8" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget9" HeaderText="Budget" SortExpression="monBudget9" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount9" HeaderText="Actual" SortExpression="monAmount9" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var9" HeaderText="Variance" SortExpression="var9" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget10" HeaderText="Budget" SortExpression="monBudget10" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount10" HeaderText="Actual" SortExpression="monAmount10" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var10" HeaderText="Variance" SortExpression="var10" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>

                               <asp:BoundField DataField="monBudget11" HeaderText="Budget" SortExpression="monBudget11" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount11" HeaderText="Actual" SortExpression="monAmount11" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var11" HeaderText="Variance" SortExpression="var11" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="monBudget12" HeaderText="Budget" SortExpression="monBudget12" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="monAmount12" HeaderText="Actual" SortExpression="monAmount12" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="var12" HeaderText="Variance" SortExpression="var12" DataFormatString="{0:N2}"  > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                              
                              
                           </Columns>
                           
                       </asp:GridView>
                   </td>
               </tr>
        </table>
       <table>
             <table border="0">
            <tr style="border:1px solid red; text-align:center"><td style="width:400px;"><asp:Label ID="Label4" runat="server"></asp:Label></td><td style="width:475px;"><asp:Label ID="lbl1Q" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="lbl2Q" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="lbl3Q" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lbl4Q" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:200px;"><asp:Label ID="Lbldet" runat="server"></asp:Label></td></tr>
             <tr>
                   <td colspan="6">
                       <asp:GridView ID="dgvQarter" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#9AD6ED" HeaderStyle-ForeColor="#636363"   >
                           <Columns>
                               <asp:TemplateField HeaderText="Sl.N">
                                   <ItemTemplate><ItemStyle Width="100px"></ItemStyle>
                                       <%# Container.DataItemIndex + 1 %>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:BoundField DataField="intCostCenter" HeaderText="ID"  SortExpression="intCostCenter" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="strAccountName" HeaderText="CostCenter" SortExpression="strAccountName" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="budgetQ1" HeaderText="Budget" SortExpression="budgetQ1" DataFormatString="{0:N2}"> <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="expQ1" HeaderText="Actual" SortExpression="expQ1" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="varQ1" HeaderText="Variance" SortExpression="varQ1" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                              <asp:BoundField DataField="budgetQ2" HeaderText="Budget" SortExpression="budgetQ2" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="expQ2" HeaderText="Actual" SortExpression="expQ2" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="varQ2" HeaderText="Variance" SortExpression="varQ2" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                          <asp:BoundField DataField="budgetQ3" HeaderText="Budget" SortExpression="budgetQ3" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="expQ3" HeaderText="Actual" SortExpression="expQ3" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="varQ3" HeaderText="Variance" SortExpression="varQ3" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="budgetQ4" HeaderText="Budget" SortExpression="budgetQ4" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                <asp:BoundField DataField="expQ4" HeaderText="Actual" SortExpression="expQ4" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               <asp:BoundField DataField="varQ4" HeaderText="Variance" SortExpression="varQ4" DataFormatString="{0:N2}" > <ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                               
                              
                               <asp:TemplateField HeaderText="Detalis">
                                   <ItemTemplate>
                                       <asp:Button ID="btnQD" runat="server" Text="Detalis" CommandName="Quarter"  CommandArgument='<%#GetJSFunctionString( Eval("intCostCenter"),Eval("strAccountName")) %>' OnClick="btnQarterLy_Click"  />
                                   </ItemTemplate>
                               </asp:TemplateField>
                               
                               
                           </Columns>
                           <HeaderStyle BackColor="#9AD6ED" ForeColor="#636363" />
                       </asp:GridView>
                   </td>
               </tr>
        </table>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
