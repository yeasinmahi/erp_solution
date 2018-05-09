<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMushok11Print.aspx.cs" Inherits="UI.SAD.Vat.frmMushok11Print" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
   <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
    <style type="text/css">
        .auto-style2 {
            width: 204px;
        }
    </style>
</head>
<body>
    <form id="frmItemMatrialAdd" runat="server">
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
       <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
        <asp:HiddenField ID="hdnAccno" runat="server" /> 
        <asp:HiddenField ID="strDescription" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" />
        <asp:HiddenField ID="hdnUnit" runat="server" />
      
        <table  class="tbldecoration" style="width:850px; float:500px;">                           
        <tr><td colspan="6"><hr /></td></tr>   
        <tr><td colspan="6" style="text-align:center" ><b>“গনপ্রজাতন্ত্রী বাংলাদেল সরকার”</b><br />জাতীয় রাজস্ব বোর্ড,ঢাকা ।<br /></b>চালানপত্র </b> 
            <br /> বিধি-১৬(১)দ্রষ্টব্য</td>                                  
        <tr><td class="auto-style2"><asp:Label ID="lblaccName" runat="server" Width="150" Font-Size="10">ব্যবসায় প্রতিষ্টানের নাম</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblCustomer" runat="server" Width="150"></asp:Label></td>
            <td class="auto-style2"><asp:Label ID="lblChallano" runat="server" Width="150" Font-Size="10">চালান পত্রের ক্রমিক সংখা</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblChallanotxt" runat="server" Width="150"></asp:Label></td>
        </tr> 
        <tr><td class="auto-style2"><asp:Label ID="lbladdress" runat="server" Width="150" Font-Size="10" Text="ঠিকানা"></asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblAddresstxt" runat="server" Width="150"></asp:Label></td>        
            <td class="auto-style2"><asp:Label ID="lblChaldate" runat="server" Width="150" Font-Size="10" Text="চালান পত্র প্রদানের তারিখ"></asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblChallanDate" runat="server" Width="150"></asp:Label></td>           
         </tr> 
         <tr><td class="auto-style2"><asp:Label ID="lblSonakto" runat="server" Width="150" Font-Size="10" Text="">করদাতা সনাক্তকরণ সংখ্যা</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblvatno" runat="server" Width="150"></asp:Label></td>        
            <td class="auto-style2"><asp:Label ID="Label3" runat="server" Width="150" Font-Size="10" Text="চালান পত্র প্রদানের সময়"></asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblChallanDateTxt" runat="server" Width="150"></asp:Label></td>           
         </tr> 
         <tr><td class="auto-style2"><asp:Label ID="lblCustName" runat="server" Width="150" Font-Size="10" Text="">ত্রেতার নাম</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblCustNamtxt" runat="server" Width="150"></asp:Label></td>        
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>           
         </tr> 
         <tr><td class="auto-style2"><asp:Label ID="Label1" runat="server" Width="150" Font-Size="10" Text="">ঠিকানা</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblCustAdd" runat="server" Width="150"></asp:Label></td>        
            <td class="auto-style2"><asp:Label ID="Label7" runat="server" Width="180" Font-Size="10" Text="পন্য অপসারণের/অর্পণের সময়"></asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblPayDate" runat="server" Width="150"></asp:Label></td>           
         </tr> 
          <tr><td class="auto-style2"><asp:Label ID="Label5" runat="server" Width="150" Font-Size="10" Text="">করদাতা সনাক্তকরণ সংখ্যা</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblSonaktoSonka" runat="server" Width="150"></asp:Label></td>        
            <td class="auto-style2"><asp:Label ID="Label8" runat="server" Width="180" Font-Size="10" Text="প্রদানের প্রকৃত তারিখ সময়"></asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblpaytime" runat="server" Width="150"></asp:Label></td>           
         </tr> 
         <tr><td class="auto-style2"><asp:Label ID="Label6" runat="server" Width="150" Font-Size="10" Text="">পণ্যের চুড়ান্ত গন্তব্য স্থল</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblFinalAddress" runat="server" Width="150"></asp:Label></td>        
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>           
         </tr> 
        <tr><td class="auto-style2"><asp:Label ID="lblVehcile" runat="server" Width="150" Font-Size="10" Text="">যানবাহনের প্রকৃতি এবং নম্বর</asp:Label></td>
            <td>:</td>
            <td><asp:Label ID="lblVno" runat="server" Width="150"></asp:Label></td>        
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>           
         </tr> 
        <tr><td colspan="6"><hr /></td></tr>
        <tr><td colspan="6">

             <asp:GridView ID="dgvChallan" runat="server"  AutoGenerateColumns="False" OnRowDataBound="dgvChallan_RowDataBound" >          
            <Columns>  
           
          <%--  <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intCustid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
            </FooterTemplate></asp:TemplateField>  --%>
                          
            <asp:BoundField DataField="SL" HeaderText="SL" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strProductName" HeaderText="Product Name" ReadOnly="True" SortExpression="strProductName"/>
                    
            <asp:TemplateField HeaderText="Qty" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnQtyt" value='<%# Bind("monQty") %>' runat="server" /> <asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("monQty","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblQtys" runat="server" Text='<%# Qtytotal %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="monSDwithOutPrice" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnmonSDwithOutPricet" value='<%# Bind("monSDwithOutPrice") %>' runat="server" /> <asp:Label ID="lblqtyw" runat="server" Text='<%# (""+Eval("monSDwithOutPrice","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblmonSDwithOutPrice" runat="server" Text='<%# monSDwithOutPricetotal %>' /></FooterTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="monSDAmount" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnmonSDAmountt" value='<%# Bind("monSDAmount") %>' runat="server" /> <asp:Label ID="lblmonSDAmountw" runat="server" Text='<%# (""+Eval("monSDAmount","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblmonSDwithOutPrice" runat="server" Text='<%# monSDAmounttotal %>' /></FooterTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="monTotalSDAmount" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnmonTotalSDAmountt" value='<%# Bind("monTotalSDAmount") %>' runat="server" /> <asp:Label ID="lblmonTotalSDAmounts" runat="server" Text='<%# (""+Eval("monTotalSDAmount","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblmonTotalSDAmount" runat="server" Text='<%# monTotalSDAmounttotal %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="monVatAmount" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnmonVatAmount" value='<%# Bind("monVatAmount") %>' runat="server" /> <asp:Label ID="lblmonVatAmountss" runat="server" Text='<%# (""+Eval("monVatAmount","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblmonVatAmounts" runat="server" Text='<%# monVatAmounttotal %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="monTotal" SortExpression="Pending">
            <ItemTemplate><asp:HiddenField ID="hdnmonTotal" value='<%# Bind("monTotal") %>' runat="server" /> <asp:Label ID="lblmonTotalss" runat="server" Text='<%# (""+Eval("monTotal","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblmonTotalsss" runat="server" Text='<%# monTotaltotal %>' /></FooterTemplate>
            </asp:TemplateField>
           </Columns>          
           </asp:GridView>
           </td></tr>
                
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
