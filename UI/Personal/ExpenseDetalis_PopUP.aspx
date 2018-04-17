<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseDetalis_PopUP.aspx.cs" Inherits="UI.Personal.ExpenseDetalis_PopUP" %>
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
    <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }
         function ClosehdnDivision() {
             $("#hdnDivision").fadeOut("slow");
         }
    </script>
    <style type="text/css"> 
        .rounds {
            height:50px;
            width: 50px;
           -moz-border-colors:25px;
         border-radius:25px;
         } 
   .HyperLinkButtonStyle { float:left; text-align:left; border: none; background: none; 
    color: blue; text-decoration: underline; font: normal 10px verdana;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:100%; height:100%; margin-left:auto; margin-right:10px;margin-top:10px; padding: 20px; overflow-y:scroll; }
  
     </style>
   <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        </style>
   <style type="text/css">
        #divFile p { 
            font:15px tahoma, arial; 
        }
        #divFile h3 { 
            font:16px arial, tahoma; 
            font-weight:bold;
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
            <tr><td style="text-align:right;"><asp:Label ID="Label1" Font-Size="Medium" CssClass="lbl" Text="Cost Center Name:" runat="server"></asp:Label></td>
             <td style="text-align:right;"><asp:Label ID="Label2" Font-Size="Medium" CssClass="lbl" runat="server"></asp:Label></td> </tr>
                 
        </table>
    <%--    <table border="0">
            <tr style="border:1px solid red; text-align:center"><td style="width:455px;"><asp:Label ID="hh" runat="server"></asp:Label></td><td   style="width:475px;"><asp:Label ID="lblJul" Font-Bold="true" ForeColor="green" runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="lblAug" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="LblSep" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblOct" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="LblNov" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblDec" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblJan" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblFeb" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblMar" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblApr" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblMay" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblJun" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:100px;"><asp:Label ID="Label3" runat="server"></asp:Label></td></tr>
             <tr>
                   <td colspan="14">
                       <asp:GridView ID="DgvExpanceReport"  runat="server" AutoGenerateColumns="False"    >
                           <Columns>
                                <asp:TemplateField HeaderText="Detalis">
                                   <ItemTemplate>
                                       <asp:Button ID="btnMonthly" runat="server" Text="Detalis" CommandName="monthle"     ItemStyle-Width="100px"  />
                                   
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
        </table>--%>

        <table>
           <tr style="border:1px solid red; text-align:center"><td style="width:10px;"><asp:Label ID="Label4" runat="server"></asp:Label></td><td style="width:455px;"><asp:Label ID="hh" runat="server"></asp:Label></td><td   style="width:475px;"><asp:Label ID="lblJul" Font-Bold="true" ForeColor="green" runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="lblAug" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:400px;"><asp:Label ID="LblSep" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblOct" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="LblNov" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblDec" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblJan" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblFeb" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblMar" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblApr" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblMay" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:350px;"><asp:Label ID="lblJun" Font-Bold="true" ForeColor="green"  runat="server"></asp:Label></td><td style="width:100px;"><asp:Label ID="Label3" runat="server"></asp:Label></td></tr>
              <tr>
                   <td colspan="14">

              <asp:GridView ID="DgvExpance" runat="server"  AutoGenerateColumns="False" OnRowDataBound="ExpanceDataBound">
                <Columns>                           
               <asp:TemplateField HeaderText="Detalis"><ItemTemplate><asp:Button ID="btnDetalis" runat="server" Text="Detalis" CommandName="Detalis"   CommandArgument='<%# Eval("intCOA")%>' OnClick="btnDetalis_Click"/> </ItemTemplate> </asp:TemplateField>   
               <asp:TemplateField HeaderText="Sl.N"><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="intCOA" HeaderText="ID"  SortExpression="intCOA" />
                <asp:BoundField DataField="strCOA" HeaderText="COA" SortExpression="strCOA" />

                 <asp:BoundField DataField="bm1" HeaderText="Budget" SortExpression="bm1" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m1" HeaderText="Actual" SortExpression="m1" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm1" HeaderText="Variance" SortExpression="vm1" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm2" HeaderText="Budget" SortExpression="bm2" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m2" HeaderText="Actual" SortExpression="m2" DataFormatString="{0:N2}" />
                 <asp:BoundField DataField="vm2" HeaderText="Variance" SortExpression="vm2" DataFormatString="{0:N2}" />
                
                <asp:BoundField DataField="bm3" HeaderText="Budget" SortExpression="bm3" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m3" HeaderText="Actual" SortExpression="m3" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm3" HeaderText="Variance" SortExpression="vm3" DataFormatString="{0:N2}" />
                
                 <asp:BoundField DataField="bm4" HeaderText="Budget" SortExpression="bm4" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m4" HeaderText="Actual" SortExpression="m4" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm4" HeaderText="Variance" SortExpression="vm4" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm5" HeaderText="Budget" SortExpression="bm5" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m5" HeaderText="Actual" SortExpression="m5" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm5" HeaderText="Variance" SortExpression="vm5" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm6" HeaderText="Budget" SortExpression="bm6" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m6" HeaderText="Actual" SortExpression="m6" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm6" HeaderText="Variance" SortExpression="vm6" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm7" HeaderText="Budget" SortExpression="bm7" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m7" HeaderText="Actual" SortExpression="m7" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm7" HeaderText="Variance" SortExpression="vm7" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm8" HeaderText="Budget" SortExpression="bm8" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m8" HeaderText="Actual" SortExpression="m8" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm8" HeaderText="Variance" SortExpression="vm8" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm9" HeaderText="Budget" SortExpression="bm9" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m9" HeaderText="Actual" SortExpression="m9" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm9" HeaderText="Variance" SortExpression="vm9" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm10" HeaderText="Budget" SortExpression="bm10" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m10" HeaderText="Actual" SortExpression="m10" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm10" HeaderText="Variance" SortExpression="vm10" DataFormatString="{0:N2}" />

                <asp:BoundField DataField="bm11" HeaderText="Budget" SortExpression="bm11" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m11" HeaderText="Actual" SortExpression="m11" DataFormatString="{0:N2}" />
               <asp:BoundField DataField="vm11" HeaderText="Variance" SortExpression="vm11" DataFormatString="{0:N2}" />
                
                <asp:BoundField DataField="bm12" HeaderText="Budget" SortExpression="bm12" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="m12" HeaderText="Actual" SortExpression="m12" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="vm12" HeaderText="Variance" SortExpression="vm12" DataFormatString="{0:N2}" />
                              
                </Columns>                          
                 </asp:GridView></td></tr>
                 
        </table>
            <div id="hdnDivision" class="hdnDivision" style="width:auto;">
            <table style="width:auto; float:left; ">
            <tr class="tblrowodd"><td style="text-align:left;"><asp:Label ID="lbldetalis" CssClass="lbl" runat="server" Text="Detalis Report by CostCenter and Chart of Accounts : "></asp:Label>
            <asp:Button ID="btnDivClose" runat="server"  OnClick="btnDivClose_Click" BackColor="GreenYellow" Text="Close" /></td> </tr>
            <tr><td><asp:GridView ID="dgvDetalisdiv" runat="server"  AutoGenerateColumns="False">
                <Columns>                 
               <asp:TemplateField HeaderText="Sl.N"> <ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="dteDate" HeaderText="Date"  SortExpression="dteDate" />
                <asp:BoundField DataField="strEntryCode" HeaderText="EntryCode" SortExpression="strEntryCode" />
                <asp:BoundField DataField="strNarration" HeaderText="Narration" SortExpression="strNarration"/>
                <asp:BoundField DataField="monAmount" HeaderText="Amount" SortExpression="monAmount" DataFormatString="{0:N2}" />
               </Columns>                       
                </asp:GridView> </td> </tr> 
                 
    </table>
    </div>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
