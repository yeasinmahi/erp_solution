<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesOrderReport.aspx.cs" Inherits="UI.SAD.Corporate_sales.SalesOrderReport" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
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

    <script src="../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            GridviewScroll();
        });
        function GridviewScroll() {

            $('#no').gridviewScroll({
                width: 1725,
                height: 840,
                startHorizontal: 0,
                wheelstep: 10,
                barhovercolor: "#3399FF",
                barcolor: "#3399FF"
            });
        }
    </script>



    </head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>--%>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>--%>
    <%--<div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
 
    <table style="width:70%">
          <tr  class="tblroweven"> 
             <td style="color:green;flex-align:center; font-family:Calibri;font-size:18px" class="tdr"  >
                 <b>Corporate Sales Report</b></td>
    </tr> 
      </table>   
    <table  style="width:100%;height:2px">
    
    <tr class="tblroweven" > 
        
    <td style="text-align:justify;width:100%; font-size:12px; background-color:white;" " >
    
   
      
       </td>
    </tr> 
    </table>
    <div style="width:100%">
     
   
      </div> 
   <table class="" style="width:100%; height:2px ">
    
     <tr style="width:100%" > 
     <td style="text-align:center;font-size:16px; background-color:white;" >
       <table class="" style="width:676px; float:left; margin-right: 0px;">
            <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style14"><asp:Label ID="Label4"  runat="server" Text="Report Category :" Font-Bold="True" Font-Names="Calibri" Font-Size="15px"></asp:Label></td>
               <td class="auto-style11"><asp:DropDownList BackColor="#f2f2f2" CssClass="txtBox" ID="ddlcategory" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                   <asp:ListItem Value="">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Sales Report</asp:ListItem>
                   <asp:ListItem Value="2">Order Report</asp:ListItem>
                   </asp:DropDownList> </td>
               <td style="text-align:right;" class="auto-style6">&nbsp;</td>
               <td class="auto-style3">&nbsp;</td>
           </tr>
          <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style15">&nbsp;</td>
               <td class="auto-style12"><asp:RadioButton ID="rbntdaily" GroupName="SalesReport" AutoPostBack="true" Text="Daily Sales/Order" runat="server" OnCheckedChanged="rbntdaily_CheckedChanged"  />
              <asp:HiddenField ID="hdnAreanumber" runat="server" />
               </td>
               <td style="text-align:right;" class="auto-style7">    </td>
               <td class="auto-style4"><asp:RadioButton ID="rbntdatewise" GroupName="SalesReport" AutoPostBack="true" Text="Datewise Wise Sales/Order" runat="server" OnCheckedChanged="rbntdatewise_CheckedChanged"  />
                <asp:HiddenField ID="hdnDatewise" runat="server" /></td>    
           </tr>

           
            <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style14"><asp:Label ID="Label1"  runat="server" Text="Area Name :" Font-Bold="True" Font-Names="Calibri" Font-Size="15px"></asp:Label></td>
               <td class="auto-style11"><asp:DropDownList BackColor="#f2f2f2" CssClass="txtBox" ID="ddlarea" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlarea_SelectedIndexChanged"> <asp:ListItem Value="0" Text="Select" /> <asp:ListItem Value="2" Text="Dhaka" /></asp:DropDownList> </td>
             <td colspan="2" />
           </tr>
           <tr class="tblroweven">
              <td style="text-align:right;" class="auto-style6"><asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Names="Calibri" Text="Territory Name :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style3"><asp:DropDownList AutoPostBack="true" BackColor="#f2f2f2" ID="ddlTerritory" CssClass="txtBox"  runat="server" OnSelectedIndexChanged="ddlTerritory_SelectedIndexChanged"><asp:ListItem Value="0" Text="Select" /><asp:ListItem Value="3" Text="Territory" /></asp:DropDownList></td>
               <td colspan="2" />

           </tr>
            <tr class="tblroweven">
                <td style="text-align:right;" class="auto-style15"><asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Names="Calibri" Text="Point :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style12"> <asp:DropDownList ID="ddlpoint" BackColor="#f2f2f2" CssClass="txtBox"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpoint_SelectedIndexChanged"><asp:ListItem Value="0" Text="Select" /><asp:ListItem Value="4" Text="Point" /></asp:DropDownList> </td>
                <td colspan="2" />

            </tr>
           <tr class="tblroweven">
               <td style="text-align:right;" class="auto-style2"><asp:Label ID="Label6" Font-Bold="true" Font-Names="Calibri" runat="server" Text="From Date :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style13"><asp:TextBox ID="txtfromdate" Font-Bold="true" Width="150px" BackColor="#f2f2f2" CssClass="txtBox" runat="server" autocomplete="off" ></asp:TextBox>
                   <script type="text/javascript"> new datepickr('txtfromdate', { 'dateFormat': 'Y-m-d' });</script>
               </td>
               <td style="text-align:right;" class="auto-style8"><asp:Label ID="Label9" Font-Bold="true" Font-Names="Calibri" runat="server" Text="To Date :" Font-Size="15px"></asp:Label></td>
               <td class="auto-style5"><asp:TextBox ID="txttodate" Font-Bold="true" Width="150px"  BackColor="#f2f2f2" CssClass="txtBox" runat="server" autocomplete="off" ></asp:TextBox>
                   <script type="text/javascript"> new datepickr('txttodate', { 'dateFormat': 'Y-m-d' });</script>
               </td>
           </tr>
            
           <tr >
               <td colspan="4" style="text-align:right;" class="auto-style1">    

                   <div> <asp:Button ID="Button1" Font-Bold="true" Font-Names="Calibri" Font-Size="15px" BackColor="White" runat="server" Text="Show" OnClick="Button1_Click" /></div> </td>
           </tr>
           
       </table>


     </td>

     </tr> 
       <tr>
 
           <td>
                       <asp:GridView ID="dgvtrgtArea" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="Row No"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

                <asp:TemplateField HeaderText="Area" SortExpression="SL"><ItemTemplate>                  
                 <asp:HiddenField ID="hdarea1" runat="server" Value='<%# Eval("strPointName") %>' /><asp:HiddenField ID="hdarea2" runat="server" Value='<%# Eval("strPointName") %>' />
                 <asp:Label ID="lblarea" runat="server" Text='<%# Bind("strPointName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO LIGHT 250 ML CAN" SortExpression="MLQC"><ItemTemplate>                  
                 <asp:HiddenField ID="hdmlqc1" runat="server" Value='<%# Eval("MLQC","{0:n0}") %>' /><asp:HiddenField ID="hfmlqc2" runat="server" Value='<%# Eval("MLQC") %>' />
                 <asp:Label ID="lbmlqc" runat="server" Text='<%# Bind("mlqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO 250 ML CAN" SortExpression="mqc"><ItemTemplate>
                 <asp:HiddenField ID="hdmqc1" runat="server" Value='<%# Eval("mqc","{0:n0}") %>' /><asp:HiddenField ID="hdmqc2" runat="server" Value='<%# Eval("mqc") %>' />
                 <asp:Label ID="lbmqc" runat="server" Text='<%# Bind("mqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="MOJO 250 ML PET" SortExpression="mqp"><ItemTemplate>
                <asp:HiddenField ID="hdmqp1" runat="server" Value='<%# Eval("mqp","{0:n0}") %>' /><asp:HiddenField ID="hdmqp2" runat="server" Value='<%# Eval("mqp") %>' />
                <asp:Label ID="lbmqp" runat="server" Text='<%# Bind("mqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="MOJO 500 ML PET" SortExpression="mhp"><ItemTemplate>
                <asp:HiddenField ID="hdmhp1" runat="server" Value='<%# Eval("mhp","{0:n0}") %>' /><asp:HiddenField ID="hdmhp2" runat="server" Value='<%# Eval("mhp") %>' />
                <asp:Label ID="lbmhp" runat="server" Text='<%# Bind("mhp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="CLEMON 250 ML CAN" SortExpression="cqc"><ItemTemplate>
                <asp:HiddenField ID="hdcqc1" runat="server" Value='<%# Eval("cqc","{0:n0}") %>' /><asp:HiddenField ID="hdcqc2" runat="server" Value='<%# Eval("cqc") %>' />
                <asp:Label ID="lbcqc" runat="server" Text='<%# Bind("cqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="CLEMON 250 ML PET" SortExpression="cqp"><ItemTemplate>
                <asp:HiddenField ID="hdcqp1" runat="server" Value='<%# Eval("cqp","{0:n0}") %>' /><asp:HiddenField ID="hdcqp2" runat="server" Value='<%# Eval("cqp") %>' />
                <asp:Label ID="lbcqp" runat="server" Text='<%# Bind("cqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 500 ML PET" SortExpression="chp"><ItemTemplate>
                <asp:HiddenField ID="hdchp1" runat="server" Value='<%# Eval("chp","{0:n0}") %>' /><asp:HiddenField ID="hdchp2" runat="server" Value='<%# Eval("chp") %>' />
                <asp:Label ID="lbchp" runat="server" Text='<%# Bind("chp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="TWING 250 ML PET" SortExpression="tqp"><ItemTemplate>
                <asp:HiddenField ID="hdtqp1" runat="server" Value='<%# Eval("tqp","{0:n0}") %>' /><asp:HiddenField ID="hdtqp2" runat="server" Value='<%# Eval("tqp") %>' />
                <asp:Label ID="lbtqp" runat="server" Text='<%# Bind("tqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="TWING 500 ML PET" SortExpression="thp" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdthp1" runat="server" Value='<%# Eval("thp","{0:n0}") %>' /><asp:HiddenField ID="bhthp2" runat="server" Value='<%# Eval("thp") %>' />
                <asp:Label ID="lbthp" runat="server" Text='<%# Bind("thp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML CAN" SortExpression="sqc"><ItemTemplate>
                <asp:HiddenField ID="hdsqc1" runat="server" Value='<%# Eval("sqc","{0:n0}") %>' /><asp:HiddenField ID="hdsqc2" runat="server" Value='<%# Eval("sqc") %>' />
                <asp:Label ID="lbsqc" runat="server" Text='<%# Bind("sqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 250 ML PET" SortExpression="fmqp"><ItemTemplate>
                <asp:HiddenField ID="hdfmqp1" runat="server" Value='<%# Eval("FQP","{0:n0}") %>' /><asp:HiddenField ID="hdfmqp2" runat="server" Value='<%# Eval("FQP") %>' />
                <asp:Label ID="lbfmqp" runat="server" Text='<%# Bind("FQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 500 ML PET" SortExpression="fmhp"><ItemTemplate>
                <asp:HiddenField ID="hdfmhp1" runat="server" Value='<%# Eval("FHP","{0:n0}") %>' /><asp:HiddenField ID="hdfmhp2" runat="server" Value='<%# Eval("FHP") %>' />
                <asp:Label ID="lbfmhp" runat="server" Text='<%# Bind("FHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FRUTIKA MANGO 1000 ML PET" SortExpression="fmop"><ItemTemplate>
                <asp:HiddenField ID="hdfmop1" runat="server" Value='<%# Eval("FOP","{0:n0}") %>' /><asp:HiddenField ID="hdfmop2" runat="server" Value='<%# Eval("FOP") %>' />
                <asp:Label ID="lbfmop" runat="server" Text='<%# Bind("FOP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="FRUTIKA RED GRAPE 250 ML PET" SortExpression="frgqp"><ItemTemplate>
                <asp:HiddenField ID="hdfrgqp1" runat="server" Value='<%# Eval("FRGQP","{0:n0}") %>' /><asp:HiddenField ID="hdfrgqp2" runat="server" Value='<%# Eval("FRGQP") %>' />
                <asp:Label ID="lbfrgqp" runat="server" Text='<%# Bind("FRGQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(16)" SortExpression="uhth16"><ItemTemplate>
                <asp:HiddenField ID="hduhth161" runat="server" Value='<%# Eval("FFHT16","{0:n0}") %>' /><asp:HiddenField ID="hduhth162" runat="server" Value='<%# Eval("FFHT16") %>' />
                <asp:Label ID="lbuhth16" runat="server" Text='<%# Bind("FFHT16","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(8)" SortExpression="uhth8"><ItemTemplate>
                <asp:HiddenField ID="hduhth81" runat="server" Value='<%# Eval("FFHT","{0:n0}") %>' /><asp:HiddenField ID="hduhth82" runat="server" Value='<%# Eval("FFHT") %>' />
                <asp:Label ID="lbuhth8" runat="server" Text='<%# Bind("FFHT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="FARM FRESH GHEE 200 ML TIN COTA" SortExpression="ffg2"><ItemTemplate>                  
                 <asp:HiddenField ID="hdffg21" runat="server" Value='<%# Eval("FGQ","{0:n0}") %>' /><asp:HiddenField ID="hfffg22" runat="server" Value='<%# Eval("FGQ") %>' />
                 <asp:Label ID="lbffg2" runat="server" Text='<%# Bind("FGQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH GHEE 450 ML TIN COTA" SortExpression="ffg4"><ItemTemplate>
                 <asp:HiddenField ID="hdffg41" runat="server" Value='<%# Eval("FGH","{0:n0}") %>' /><asp:HiddenField ID="hdffg42" runat="server" Value='<%# Eval("FGH") %>' />
                 <asp:Label ID="lbffg4" runat="server" Text='<%# Bind("FGH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="FARM FRESH GHEE 900 ML TIN COTA" SortExpression="ffg9"><ItemTemplate>
                <asp:HiddenField ID="hdffg91" runat="server" Value='<%# Eval("FGO","{0:n0}") %>' /><asp:HiddenField ID="hdffg92" runat="server" Value='<%# Eval("FGO") %>' />
                <asp:Label ID="lbffg9" runat="server" Text='<%# Bind("FGO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="CHEESE PUFFS CRACKERS 22 GM" SortExpression="cp"><ItemTemplate>
                <asp:HiddenField ID="hdcp1" runat="server" Value='<%# Eval("cps","{0:n0}") %>' /><asp:HiddenField ID="hdcp2" runat="server" Value='<%# Eval("cps") %>' />
                <asp:Label ID="lbcp" runat="server" Text='<%# Bind("cps","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="MOJO 1000 ML PET" SortExpression="mop"><ItemTemplate>
                <asp:HiddenField ID="hdmop1" runat="server" Value='<%# Eval("mop","{0:n0}") %>' /><asp:HiddenField ID="hdmop2" runat="server" Value='<%# Eval("mop") %>' />
                <asp:Label ID="lbmop" runat="server" Text='<%# Bind("mop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MOJO 2000 ML PET" SortExpression="mtp"><ItemTemplate>
                <asp:HiddenField ID="hdmtp1" runat="server" Value='<%# Eval("mtp","{0:n0}") %>' /><asp:HiddenField ID="hdmtp2" runat="server" Value='<%# Eval("mtp") %>' />
                <asp:Label ID="lbmtp" runat="server" Text='<%# Bind("mtp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="LEMU 250 ML CAN" SortExpression="lqc"><ItemTemplate>
                <asp:HiddenField ID="hdlqc1" runat="server" Value='<%# Eval("lqc","{0:n0}") %>' /><asp:HiddenField ID="hdlqc2" runat="server" Value='<%# Eval("lqc") %>' />
                <asp:Label ID="lblqc" runat="server" Text='<%# Bind("lqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="LEMU 250 ML PET" SortExpression="lqp"><ItemTemplate>
                <asp:HiddenField ID="hdlqp1" runat="server" Value='<%# Eval("lqp","{0:n0}") %>' /><asp:HiddenField ID="hdlqp2" runat="server" Value='<%# Eval("lqp") %>' />
                <asp:Label ID="lblqp" runat="server" Text='<%# Bind("lqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="CLEMON 1000 ML PET" SortExpression="cop" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdcop1" runat="server" Value='<%# Eval("cop","{0:n0}") %>' /><asp:HiddenField ID="bhcop2" runat="server" Value='<%# Eval("cop") %>' />
                <asp:Label ID="lbcop" runat="server" Text='<%# Bind("cop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 2000 ML PET" SortExpression="ctp"><ItemTemplate>
                <asp:HiddenField ID="hdctp1" runat="server" Value='<%# Eval("ctp","{0:n0}") %>' /><asp:HiddenField ID="hdctp2" runat="server" Value='<%# Eval("ctp") %>' />
                <asp:Label ID="lbctp" runat="server" Text='<%# Bind("ctp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML PET" SortExpression="sqp"><ItemTemplate>
                <asp:HiddenField ID="hdsqp1" runat="server" Value='<%# Eval("sqp","{0:n0}") %>' /><asp:HiddenField ID="hdsqp2" runat="server" Value='<%# Eval("sqp") %>' />
                <asp:Label ID="lbsqp" runat="server" Text='<%# Bind("sqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="WILD BREW 250 ML CAN" SortExpression="wbqc"><ItemTemplate>
                <asp:HiddenField ID="hdwbqc1" runat="server" Value='<%# Eval("wqc","{0:n0}") %>' /><asp:HiddenField ID="hdwbqc2" runat="server" Value='<%# Eval("wqc") %>' />
                <asp:Label ID="lbwbqc" runat="server" Text='<%# Bind("wqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="AAFI MANGO 250 ML PET" SortExpression="amqp"><ItemTemplate>
                <asp:HiddenField ID="hdamqp1" runat="server" Value='<%# Eval("AMQ","{0:n0}") %>' /><asp:HiddenField ID="hdamqp2" runat="server" Value='<%# Eval("AMQ") %>' />
                <asp:Label ID="lbamqp" runat="server" Text='<%# Bind("AMQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="AAFI MANGO 500 ML PET" SortExpression="amhp"><ItemTemplate>
                <asp:HiddenField ID="hdamhp1" runat="server" Value='<%# Eval("amh","{0:n0}") %>' /><asp:HiddenField ID="hdamhp2" runat="server" Value='<%# Eval("amh") %>' />
                <asp:Label ID="lbamhp" runat="server" Text='<%# Bind("amh","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="AAFI MANGO 1000 ML PET" SortExpression="amop"><ItemTemplate>
                <asp:HiddenField ID="hdamop1" runat="server" Value='<%# Eval("amo","{0:n0}") %>' /><asp:HiddenField ID="hdamop2" runat="server" Value='<%# Eval("amo") %>' />
                <asp:Label ID="lbamop" runat="server" Text='<%# Bind("amo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                                                                                                                                  

                <asp:TemplateField HeaderText="LITTLE FRUTIKA 125 ML BRICK" SortExpression="lfb"><ItemTemplate>
                <asp:HiddenField ID="hdlfb1" runat="server" Value='<%# Eval("FLT","{0:n0}") %>' /><asp:HiddenField ID="hdlfb2" runat="server" Value='<%# Eval("FLT") %>' />
                <asp:Label ID="lblfb" runat="server" Text='<%# Bind("FLT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="SPA 500 ML PET" SortExpression="spfp"><ItemTemplate>
                <asp:HiddenField ID="hdspfp1" runat="server" Value='<%# Eval("SPHP","{0:n0}") %>' /><asp:HiddenField ID="hdspfp2" runat="server" Value='<%# Eval("SPHP") %>' />
                <asp:Label ID="lbspfp" runat="server" Text='<%# Bind("SPHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="SPA 1500 ML PET" SortExpression="spohp"><ItemTemplate>                  
                 <asp:HiddenField ID="hdspohp1" runat="server" Value='<%# Eval("SPFP","{0:n0}") %>' /><asp:HiddenField ID="hfspohp2" runat="server" Value='<%# Eval("SPFP") %>' />
                 <asp:Label ID="lbspohp" runat="server" Text='<%# Bind("SPFP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPA 250 ML PET" SortExpression="spqp"><ItemTemplate>
                 <asp:HiddenField ID="hdspqp1" runat="server" Value='<%# Eval("spqp","{0:n0}") %>' /><asp:HiddenField ID="hdspqp2" runat="server" Value='<%# Eval("spqp") %>' />
                 <asp:Label ID="lbspqp" runat="server" Text='<%# Bind("SPQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="PASTURIZED MILK 1000 ML" SortExpression="pmo"><ItemTemplate>
                <asp:HiddenField ID="hdpmo1" runat="server" Value='<%# Eval("pmo","{0:n0}") %>' /><asp:HiddenField ID="hdpmo2" runat="server" Value='<%# Eval("pmo") %>' />
                <asp:Label ID="lbpmo" runat="server" Text='<%# Bind("pmo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="PASTURIZED MILK 500 ML" SortExpression="PM5M"><ItemTemplate>
                <asp:HiddenField ID="hdpmh1" runat="server" Value='<%# Eval("PM5M","{0:n0}") %>' /><asp:HiddenField ID="hdpmh2" runat="server" Value='<%# Eval("PM5M") %>' />
                <asp:Label ID="lbpmh" runat="server" Text='<%# Bind("PM5M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="PASTURIZED MILK 200 ML" SortExpression="pmq"><ItemTemplate>
                <asp:HiddenField ID="hdpmq1" runat="server" Value='<%# Eval("PM2M","{0:n0}") %>' /><asp:HiddenField ID="hdpmq2" runat="server" Value='<%# Eval("PM2M") %>' />
                <asp:Label ID="lbpmq" runat="server" Text='<%# Bind("PM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MANGO MILK 200 ML" SortExpression="mmq"><ItemTemplate>
                <asp:HiddenField ID="hdmmq1" runat="server" Value='<%# Eval("MM2M","{0:n0}") %>' /><asp:HiddenField ID="hdmmq2" runat="server" Value='<%# Eval("MM2M") %>' />
                <asp:Label ID="lbmmq" runat="server" Text='<%# Bind("MM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CHOCOLATE MILK 200 ML" SortExpression="CM2M"><ItemTemplate>
                <asp:HiddenField ID="hdcmq1" runat="server" Value='<%# Eval("CM2M","{0:n0}") %>' /><asp:HiddenField ID="hdcmq2" runat="server" Value='<%# Eval("CM2M") %>' />
                <asp:Label ID="lbcmq" runat="server" Text='<%# Bind("CM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SOUR) 500 GM BOX" SortExpression="ysq"><ItemTemplate>
                <asp:HiddenField ID="hdysq1" runat="server" Value='<%# Eval("FFYSRH","{0:n0}") %>' /><asp:HiddenField ID="hdysq2" runat="server" Value='<%# Eval("FFYSRH") %>' />
                <asp:Label ID="lbysq" runat="server" Text='<%# Bind("FFYSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 500 GM BOX" SortExpression="ystq" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdystq1" runat="server" Value='<%# Eval("FFYSH","{0:n0}") %>' /><asp:HiddenField ID="bhystq2" runat="server" Value='<%# Eval("FFYSH") %>' />
                <asp:Label ID="lbystq" runat="server" Text='<%# Bind("FFYSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 100 GM CUP" SortExpression="yst1"><ItemTemplate>
                <asp:HiddenField ID="hdyst11" runat="server" Value='<%# Eval("FFYS1","{0:n0}") %>' /><asp:HiddenField ID="hdyst12" runat="server" Value='<%# Eval("FFYS1") %>' />
                <asp:Label ID="lbyst1" runat="server" Text='<%# Bind("FFYS1","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SWEET) 500 GM BOX" SortExpression="ylfsth"><ItemTemplate>
                <asp:HiddenField ID="hdylfsth1" runat="server" Value='<%# Eval("FFYLFSH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsth2" runat="server" Value='<%# Eval("FFYLFSH") %>' />
                <asp:Label ID="lbylfsth" runat="server" Text='<%# Bind("FFYLFSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SOUR) 500 GM BOX" SortExpression="ylfsh"><ItemTemplate>
                <asp:HiddenField ID="hdylfsh1" runat="server" Value='<%# Eval("FFYLFSRH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsh2" runat="server" Value='<%# Eval("FFYLFSRH") %>' />
                <asp:Label ID="lbylfsh" runat="server" Text='<%# Bind("FFYLFSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="BUTTER 200 GM" SortExpression="BT2"><ItemTemplate>
                <asp:HiddenField ID="hdbtq1" runat="server" Value='<%# Eval("BT2","{0:n0}") %>' /><asp:HiddenField ID="hdbtq2" runat="server" Value='<%# Eval("BT2") %>' />
                <asp:Label ID="lbbtq" runat="server" Text='<%# Bind("BT2","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="BUTTER KG" SortExpression="bto"><ItemTemplate>
                <asp:HiddenField ID="hdbto1" runat="server" Value='<%# Eval("BTO","{0:n0}") %>' /><asp:HiddenField ID="hdbto2" runat="server" Value='<%# Eval("BTO") %>' />
                <asp:Label ID="lbbto" runat="server" Text='<%# Bind("BTO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="GHEE KG" SortExpression="gheekg"><ItemTemplate>
                <asp:HiddenField ID="hdgheekg1" runat="server" Value='<%# Eval("GHO","{0:n0}") %>' /><asp:HiddenField ID="hdgheekg2" runat="server" Value='<%# Eval("GHO") %>' />
                <asp:Label ID="lbgheekg" runat="server" Text='<%# Bind("GHO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>
           
           
                 <%--<asp:TemplateField HeaderText="Amount" SortExpression="itemname"><ItemTemplate>
                <asp:HiddenField ID="hdAmount1" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' /><asp:HiddenField ID="hdAmount2" runat="server" Value='<%# Eval("Amount") %>' />
                <asp:Label ID="lbAmount" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>--%>
           
                      </Columns>
                 <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
          
               
                       <asp:GridView ID="dgvTerritory" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="Row No"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

               <asp:TemplateField HeaderText="PointID" SortExpression="intPointID"><ItemTemplate>                  
                 <asp:HiddenField ID="hdintPointID1" runat="server" Value='<%# Eval("intPointID") %>' /><asp:HiddenField ID="intPointID2" runat="server" Value='<%# Eval("intPointID") %>' />
                 <asp:Label ID="lbintPointID" runat="server" Text='<%# Bind("intPointID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>
                <asp:TemplateField HeaderText="Point" SortExpression="strPointName"><ItemTemplate>                  
                 <asp:HiddenField ID="hdstrPointName1" runat="server" Value='<%# Eval("strPointName") %>' /><asp:HiddenField ID="hdstrPointName2" runat="server" Value='<%# Eval("strPointName") %>' />
                 <asp:Label ID="lbstrPointName" runat="server" Text='<%# Bind("strPointName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO LIGHT 250 ML CAN" SortExpression="MLQC"><ItemTemplate>                  
                 <asp:HiddenField ID="hdmlqc1" runat="server" Value='<%# Eval("MLQC","{0:n0}") %>' /><asp:HiddenField ID="hfmlqc2" runat="server" Value='<%# Eval("MLQC") %>' />
                 <asp:Label ID="lbmlqc" runat="server" Text='<%# Bind("mlqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO 250 ML CAN" SortExpression="mqc"><ItemTemplate>
                 <asp:HiddenField ID="hdmqc1" runat="server" Value='<%# Eval("mqc","{0:n0}") %>' /><asp:HiddenField ID="hdmqc2" runat="server" Value='<%# Eval("mqc") %>' />
                 <asp:Label ID="lbmqc" runat="server" Text='<%# Bind("mqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="MOJO 250 ML PET" SortExpression="mqp"><ItemTemplate>
                <asp:HiddenField ID="hdmqp1" runat="server" Value='<%# Eval("mqp","{0:n0}") %>' /><asp:HiddenField ID="hdmqp2" runat="server" Value='<%# Eval("mqp") %>' />
                <asp:Label ID="lbmqp" runat="server" Text='<%# Bind("mqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="MOJO 500 ML PET" SortExpression="mhp"><ItemTemplate>
                <asp:HiddenField ID="hdmhp1" runat="server" Value='<%# Eval("mhp","{0:n0}") %>' /><asp:HiddenField ID="hdmhp2" runat="server" Value='<%# Eval("mhp") %>' />
                <asp:Label ID="lbmhp" runat="server" Text='<%# Bind("mhp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="CLEMON 250 ML CAN" SortExpression="cqc"><ItemTemplate>
                <asp:HiddenField ID="hdcqc1" runat="server" Value='<%# Eval("cqc","{0:n0}") %>' /><asp:HiddenField ID="hdcqc2" runat="server" Value='<%# Eval("cqc") %>' />
                <asp:Label ID="lbcqc" runat="server" Text='<%# Bind("cqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="CLEMON 250 ML PET" SortExpression="cqp"><ItemTemplate>
                <asp:HiddenField ID="hdcqp1" runat="server" Value='<%# Eval("cqp","{0:n0}") %>' /><asp:HiddenField ID="hdcqp2" runat="server" Value='<%# Eval("cqp") %>' />
                <asp:Label ID="lbcqp" runat="server" Text='<%# Bind("cqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 500 ML PET" SortExpression="chp"><ItemTemplate>
                <asp:HiddenField ID="hdchp1" runat="server" Value='<%# Eval("chp","{0:n0}") %>' /><asp:HiddenField ID="hdchp2" runat="server" Value='<%# Eval("chp") %>' />
                <asp:Label ID="lbchp" runat="server" Text='<%# Bind("chp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="TWING 250 ML PET" SortExpression="tqp"><ItemTemplate>
                <asp:HiddenField ID="hdtqp1" runat="server" Value='<%# Eval("tqp","{0:n0}") %>' /><asp:HiddenField ID="hdtqp2" runat="server" Value='<%# Eval("tqp") %>' />
                <asp:Label ID="lbtqp" runat="server" Text='<%# Bind("tqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="TWING 500 ML PET" SortExpression="thp" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdthp1" runat="server" Value='<%# Eval("thp","{0:n0}") %>' /><asp:HiddenField ID="bhthp2" runat="server" Value='<%# Eval("thp") %>' />
                <asp:Label ID="lbthp" runat="server" Text='<%# Bind("thp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML CAN" SortExpression="sqc"><ItemTemplate>
                <asp:HiddenField ID="hdsqc1" runat="server" Value='<%# Eval("sqc","{0:n0}") %>' /><asp:HiddenField ID="hdsqc2" runat="server" Value='<%# Eval("sqc") %>' />
                <asp:Label ID="lbsqc" runat="server" Text='<%# Bind("sqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 250 ML PET" SortExpression="fmqp"><ItemTemplate>
                <asp:HiddenField ID="hdfmqp1" runat="server" Value='<%# Eval("FQP","{0:n0}") %>' /><asp:HiddenField ID="hdfmqp2" runat="server" Value='<%# Eval("FQP") %>' />
                <asp:Label ID="lbfmqp" runat="server" Text='<%# Bind("FQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 500 ML PET" SortExpression="fmhp"><ItemTemplate>
                <asp:HiddenField ID="hdfmhp1" runat="server" Value='<%# Eval("FHP","{0:n0}") %>' /><asp:HiddenField ID="hdfmhp2" runat="server" Value='<%# Eval("FHP") %>' />
                <asp:Label ID="lbfmhp" runat="server" Text='<%# Bind("FHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FRUTIKA MANGO 1000 ML PET" SortExpression="fmop"><ItemTemplate>
                <asp:HiddenField ID="hdfmop1" runat="server" Value='<%# Eval("FOP","{0:n0}") %>' /><asp:HiddenField ID="hdfmop2" runat="server" Value='<%# Eval("FOP") %>' />
                <asp:Label ID="lbfmop" runat="server" Text='<%# Bind("FOP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="FRUTIKA RED GRAPE 250 ML PET" SortExpression="frgqp"><ItemTemplate>
                <asp:HiddenField ID="hdfrgqp1" runat="server" Value='<%# Eval("FRGQP","{0:n0}") %>' /><asp:HiddenField ID="hdfrgqp2" runat="server" Value='<%# Eval("FRGQP") %>' />
                <asp:Label ID="lbfrgqp" runat="server" Text='<%# Bind("FRGQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(16)" SortExpression="uhth16"><ItemTemplate>
                <asp:HiddenField ID="hduhth161" runat="server" Value='<%# Eval("FFHT16","{0:n0}") %>' /><asp:HiddenField ID="hduhth162" runat="server" Value='<%# Eval("FFHT16") %>' />
                <asp:Label ID="lbuhth16" runat="server" Text='<%# Bind("FFHT16","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(8)" SortExpression="uhth8"><ItemTemplate>
                <asp:HiddenField ID="hduhth81" runat="server" Value='<%# Eval("FFHT","{0:n0}") %>' /><asp:HiddenField ID="hduhth82" runat="server" Value='<%# Eval("FFHT") %>' />
                <asp:Label ID="lbuhth8" runat="server" Text='<%# Bind("FFHT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="FARM FRESH GHEE 200 ML TIN COTA" SortExpression="ffg2"><ItemTemplate>                  
                 <asp:HiddenField ID="hdffg21" runat="server" Value='<%# Eval("FGQ","{0:n0}") %>' /><asp:HiddenField ID="hfffg22" runat="server" Value='<%# Eval("FGQ") %>' />
                 <asp:Label ID="lbffg2" runat="server" Text='<%# Bind("FGQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH GHEE 450 ML TIN COTA" SortExpression="ffg4"><ItemTemplate>
                 <asp:HiddenField ID="hdffg41" runat="server" Value='<%# Eval("FGH","{0:n0}") %>' /><asp:HiddenField ID="hdffg42" runat="server" Value='<%# Eval("FGH") %>' />
                 <asp:Label ID="lbffg4" runat="server" Text='<%# Bind("FGH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="FARM FRESH GHEE 900 ML TIN COTA" SortExpression="ffg9"><ItemTemplate>
                <asp:HiddenField ID="hdffg91" runat="server" Value='<%# Eval("FGO","{0:n0}") %>' /><asp:HiddenField ID="hdffg92" runat="server" Value='<%# Eval("FGO") %>' />
                <asp:Label ID="lbffg9" runat="server" Text='<%# Bind("FGO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="CHEESE PUFFS CRACKERS 22 GM" SortExpression="cp"><ItemTemplate>
                <asp:HiddenField ID="hdcp1" runat="server" Value='<%# Eval("cps","{0:n0}") %>' /><asp:HiddenField ID="hdcp2" runat="server" Value='<%# Eval("cps") %>' />
                <asp:Label ID="lbcp" runat="server" Text='<%# Bind("cps","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="MOJO 1000 ML PET" SortExpression="mop"><ItemTemplate>
                <asp:HiddenField ID="hdmop1" runat="server" Value='<%# Eval("mop","{0:n0}") %>' /><asp:HiddenField ID="hdmop2" runat="server" Value='<%# Eval("mop") %>' />
                <asp:Label ID="lbmop" runat="server" Text='<%# Bind("mop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MOJO 2000 ML PET" SortExpression="mtp"><ItemTemplate>
                <asp:HiddenField ID="hdmtp1" runat="server" Value='<%# Eval("mtp","{0:n0}") %>' /><asp:HiddenField ID="hdmtp2" runat="server" Value='<%# Eval("mtp") %>' />
                <asp:Label ID="lbmtp" runat="server" Text='<%# Bind("mtp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="LEMU 250 ML CAN" SortExpression="lqc"><ItemTemplate>
                <asp:HiddenField ID="hdlqc1" runat="server" Value='<%# Eval("lqc","{0:n0}") %>' /><asp:HiddenField ID="hdlqc2" runat="server" Value='<%# Eval("lqc") %>' />
                <asp:Label ID="lblqc" runat="server" Text='<%# Bind("lqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="LEMU 250 ML PET" SortExpression="lqp"><ItemTemplate>
                <asp:HiddenField ID="hdlqp1" runat="server" Value='<%# Eval("lqp","{0:n0}") %>' /><asp:HiddenField ID="hdlqp2" runat="server" Value='<%# Eval("lqp") %>' />
                <asp:Label ID="lblqp" runat="server" Text='<%# Bind("lqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="CLEMON 1000 ML PET" SortExpression="cop" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdcop1" runat="server" Value='<%# Eval("cop","{0:n0}") %>' /><asp:HiddenField ID="bhcop2" runat="server" Value='<%# Eval("cop") %>' />
                <asp:Label ID="lbcop" runat="server" Text='<%# Bind("cop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 2000 ML PET" SortExpression="ctp"><ItemTemplate>
                <asp:HiddenField ID="hdctp1" runat="server" Value='<%# Eval("ctp","{0:n0}") %>' /><asp:HiddenField ID="hdctp2" runat="server" Value='<%# Eval("ctp") %>' />
                <asp:Label ID="lbctp" runat="server" Text='<%# Bind("ctp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML PET" SortExpression="sqp"><ItemTemplate>
                <asp:HiddenField ID="hdsqp1" runat="server" Value='<%# Eval("sqp","{0:n0}") %>' /><asp:HiddenField ID="hdsqp2" runat="server" Value='<%# Eval("sqp") %>' />
                <asp:Label ID="lbsqp" runat="server" Text='<%# Bind("sqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="WILD BREW 250 ML CAN" SortExpression="wbqc"><ItemTemplate>
                <asp:HiddenField ID="hdwbqc1" runat="server" Value='<%# Eval("wqc","{0:n0}") %>' /><asp:HiddenField ID="hdwbqc2" runat="server" Value='<%# Eval("wqc") %>' />
                <asp:Label ID="lbwbqc" runat="server" Text='<%# Bind("wqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="AAFI MANGO 250 ML PET" SortExpression="amqp"><ItemTemplate>
                <asp:HiddenField ID="hdamqp1" runat="server" Value='<%# Eval("AMQ","{0:n0}") %>' /><asp:HiddenField ID="hdamqp2" runat="server" Value='<%# Eval("AMQ") %>' />
                <asp:Label ID="lbamqp" runat="server" Text='<%# Bind("AMQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="AAFI MANGO 500 ML PET" SortExpression="amhp"><ItemTemplate>
                <asp:HiddenField ID="hdamhp1" runat="server" Value='<%# Eval("amh","{0:n0}") %>' /><asp:HiddenField ID="hdamhp2" runat="server" Value='<%# Eval("amh") %>' />
                <asp:Label ID="lbamhp" runat="server" Text='<%# Bind("amh","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="AAFI MANGO 1000 ML PET" SortExpression="amop"><ItemTemplate>
                <asp:HiddenField ID="hdamop1" runat="server" Value='<%# Eval("amo","{0:n0}") %>' /><asp:HiddenField ID="hdamop2" runat="server" Value='<%# Eval("amo") %>' />
                <asp:Label ID="lbamop" runat="server" Text='<%# Bind("amo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                                                                                                                                  

                <asp:TemplateField HeaderText="LITTLE FRUTIKA 125 ML BRICK" SortExpression="lfb"><ItemTemplate>
                <asp:HiddenField ID="hdlfb1" runat="server" Value='<%# Eval("FLT","{0:n0}") %>' /><asp:HiddenField ID="hdlfb2" runat="server" Value='<%# Eval("FLT") %>' />
                <asp:Label ID="lblfb" runat="server" Text='<%# Bind("FLT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="SPA 500 ML PET" SortExpression="spfp"><ItemTemplate>
                <asp:HiddenField ID="hdspfp1" runat="server" Value='<%# Eval("SPHP","{0:n0}") %>' /><asp:HiddenField ID="hdspfp2" runat="server" Value='<%# Eval("SPHP") %>' />
                <asp:Label ID="lbspfp" runat="server" Text='<%# Bind("SPHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="SPA 1500 ML PET" SortExpression="spohp"><ItemTemplate>                  
                 <asp:HiddenField ID="hdspohp1" runat="server" Value='<%# Eval("SPFP","{0:n0}") %>' /><asp:HiddenField ID="hfspohp2" runat="server" Value='<%# Eval("SPFP") %>' />
                 <asp:Label ID="lbspohp" runat="server" Text='<%# Bind("SPFP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPA 250 ML PET" SortExpression="spqp"><ItemTemplate>
                 <asp:HiddenField ID="hdspqp1" runat="server" Value='<%# Eval("spqp","{0:n0}") %>' /><asp:HiddenField ID="hdspqp2" runat="server" Value='<%# Eval("spqp") %>' />
                 <asp:Label ID="lbspqp" runat="server" Text='<%# Bind("SPQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="PASTURIZED MILK 1000 ML" SortExpression="pmo"><ItemTemplate>
                <asp:HiddenField ID="hdpmo1" runat="server" Value='<%# Eval("pmo","{0:n0}") %>' /><asp:HiddenField ID="hdpmo2" runat="server" Value='<%# Eval("pmo") %>' />
                <asp:Label ID="lbpmo" runat="server" Text='<%# Bind("pmo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="PASTURIZED MILK 500 ML" SortExpression="PM5M"><ItemTemplate>
                <asp:HiddenField ID="hdpmh1" runat="server" Value='<%# Eval("PM5M","{0:n0}") %>' /><asp:HiddenField ID="hdpmh2" runat="server" Value='<%# Eval("PM5M") %>' />
                <asp:Label ID="lbpmh" runat="server" Text='<%# Bind("PM5M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="PASTURIZED MILK 200 ML" SortExpression="pmq"><ItemTemplate>
                <asp:HiddenField ID="hdpmq1" runat="server" Value='<%# Eval("PM2M","{0:n0}") %>' /><asp:HiddenField ID="hdpmq2" runat="server" Value='<%# Eval("PM2M") %>' />
                <asp:Label ID="lbpmq" runat="server" Text='<%# Bind("PM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MANGO MILK 200 ML" SortExpression="mmq"><ItemTemplate>
                <asp:HiddenField ID="hdmmq1" runat="server" Value='<%# Eval("MM2M","{0:n0}") %>' /><asp:HiddenField ID="hdmmq2" runat="server" Value='<%# Eval("MM2M") %>' />
                <asp:Label ID="lbmmq" runat="server" Text='<%# Bind("MM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CHOCOLATE MILK 200 ML" SortExpression="CM2M"><ItemTemplate>
                <asp:HiddenField ID="hdcmq1" runat="server" Value='<%# Eval("CM2M","{0:n0}") %>' /><asp:HiddenField ID="hdcmq2" runat="server" Value='<%# Eval("CM2M") %>' />
                <asp:Label ID="lbcmq" runat="server" Text='<%# Bind("CM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SOUR) 500 GM BOX" SortExpression="ysq"><ItemTemplate>
                <asp:HiddenField ID="hdysq1" runat="server" Value='<%# Eval("FFYSRH","{0:n0}") %>' /><asp:HiddenField ID="hdysq2" runat="server" Value='<%# Eval("FFYSRH") %>' />
                <asp:Label ID="lbysq" runat="server" Text='<%# Bind("FFYSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 500 GM BOX" SortExpression="ystq" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdystq1" runat="server" Value='<%# Eval("FFYSH","{0:n0}") %>' /><asp:HiddenField ID="bhystq2" runat="server" Value='<%# Eval("FFYSH") %>' />
                <asp:Label ID="lbystq" runat="server" Text='<%# Bind("FFYSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 100 GM CUP" SortExpression="yst1"><ItemTemplate>
                <asp:HiddenField ID="hdyst11" runat="server" Value='<%# Eval("FFYS1","{0:n0}") %>' /><asp:HiddenField ID="hdyst12" runat="server" Value='<%# Eval("FFYS1") %>' />
                <asp:Label ID="lbyst1" runat="server" Text='<%# Bind("FFYS1","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SWEET) 500 GM BOX" SortExpression="ylfsth"><ItemTemplate>
                <asp:HiddenField ID="hdylfsth1" runat="server" Value='<%# Eval("FFYLFSH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsth2" runat="server" Value='<%# Eval("FFYLFSH") %>' />
                <asp:Label ID="lbylfsth" runat="server" Text='<%# Bind("FFYLFSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SOUR) 500 GM BOX" SortExpression="ylfsh"><ItemTemplate>
                <asp:HiddenField ID="hdylfsh1" runat="server" Value='<%# Eval("FFYLFSRH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsh2" runat="server" Value='<%# Eval("FFYLFSRH") %>' />
                <asp:Label ID="lbylfsh" runat="server" Text='<%# Bind("FFYLFSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="BUTTER 200 GM" SortExpression="BT2"><ItemTemplate>
                <asp:HiddenField ID="hdbtq1" runat="server" Value='<%# Eval("BT2","{0:n0}") %>' /><asp:HiddenField ID="hdbtq2" runat="server" Value='<%# Eval("BT2") %>' />
                <asp:Label ID="lbbtq" runat="server" Text='<%# Bind("BT2","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="BUTTER KG" SortExpression="bto"><ItemTemplate>
                <asp:HiddenField ID="hdbto1" runat="server" Value='<%# Eval("BTO","{0:n0}") %>' /><asp:HiddenField ID="hdbto2" runat="server" Value='<%# Eval("BTO") %>' />
                <asp:Label ID="lbbto" runat="server" Text='<%# Bind("BTO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="GHEE KG" SortExpression="gheekg"><ItemTemplate>
                <asp:HiddenField ID="hdgheekg1" runat="server" Value='<%# Eval("GHO","{0:n0}") %>' /><asp:HiddenField ID="hdgheekg2" runat="server" Value='<%# Eval("GHO") %>' />
                <asp:Label ID="lbgheekg" runat="server" Text='<%# Bind("GHO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>
           
           
                <%-- <asp:TemplateField HeaderText="Amount" SortExpression="itemname"><ItemTemplate>
                <asp:HiddenField ID="hdAmount1" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' /><asp:HiddenField ID="hdAmount2" runat="server" Value='<%# Eval("Amount") %>' />
                <asp:Label ID="lbAmount" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
                     --%>
                      </Columns>
                 <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>




                       <asp:GridView ID="dgvPoint" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="Row No"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

               <asp:TemplateField HeaderText="PointID" SortExpression="intPointID"><ItemTemplate>                  
                 <asp:HiddenField ID="hdintPointID1" runat="server" Value='<%# Eval("intPointID") %>' /><asp:HiddenField ID="intPointID2" runat="server" Value='<%# Eval("intPointID") %>' />
                 <asp:Label ID="lbintPointID" runat="server" Text='<%# Bind("intPointID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>
                <asp:TemplateField HeaderText="Point" SortExpression="strPointName"><ItemTemplate>                  
                 <asp:HiddenField ID="hdstrPointName1" runat="server" Value='<%# Eval("strPointName") %>' /><asp:HiddenField ID="hdstrPointName2" runat="server" Value='<%# Eval("strPointName") %>' />
                 <asp:Label ID="lbstrPointName" runat="server" Text='<%# Bind("strPointName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO LIGHT 250 ML CAN" SortExpression="MLQC"><ItemTemplate>                  
                 <asp:HiddenField ID="hdmlqc1" runat="server" Value='<%# Eval("MLQC","{0:n0}") %>' /><asp:HiddenField ID="hfmlqc2" runat="server" Value='<%# Eval("MLQC") %>' />
                 <asp:Label ID="lbmlqc" runat="server" Text='<%# Bind("mlqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO 250 ML CAN" SortExpression="mqc"><ItemTemplate>
                 <asp:HiddenField ID="hdmqc1" runat="server" Value='<%# Eval("mqc","{0:n0}") %>' /><asp:HiddenField ID="hdmqc2" runat="server" Value='<%# Eval("mqc") %>' />
                 <asp:Label ID="lbmqc" runat="server" Text='<%# Bind("mqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="MOJO 250 ML PET" SortExpression="mqp"><ItemTemplate>
                <asp:HiddenField ID="hdmqp1" runat="server" Value='<%# Eval("mqp","{0:n0}") %>' /><asp:HiddenField ID="hdmqp2" runat="server" Value='<%# Eval("mqp") %>' />
                <asp:Label ID="lbmqp" runat="server" Text='<%# Bind("mqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="MOJO 500 ML PET" SortExpression="mhp"><ItemTemplate>
                <asp:HiddenField ID="hdmhp1" runat="server" Value='<%# Eval("mhp","{0:n0}") %>' /><asp:HiddenField ID="hdmhp2" runat="server" Value='<%# Eval("mhp") %>' />
                <asp:Label ID="lbmhp" runat="server" Text='<%# Bind("mhp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="CLEMON 250 ML CAN" SortExpression="cqc"><ItemTemplate>
                <asp:HiddenField ID="hdcqc1" runat="server" Value='<%# Eval("cqc","{0:n0}") %>' /><asp:HiddenField ID="hdcqc2" runat="server" Value='<%# Eval("cqc") %>' />
                <asp:Label ID="lbcqc" runat="server" Text='<%# Bind("cqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="CLEMON 250 ML PET" SortExpression="cqp"><ItemTemplate>
                <asp:HiddenField ID="hdcqp1" runat="server" Value='<%# Eval("cqp","{0:n0}") %>' /><asp:HiddenField ID="hdcqp2" runat="server" Value='<%# Eval("cqp") %>' />
                <asp:Label ID="lbcqp" runat="server" Text='<%# Bind("cqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 500 ML PET" SortExpression="chp"><ItemTemplate>
                <asp:HiddenField ID="hdchp1" runat="server" Value='<%# Eval("chp","{0:n0}") %>' /><asp:HiddenField ID="hdchp2" runat="server" Value='<%# Eval("chp") %>' />
                <asp:Label ID="lbchp" runat="server" Text='<%# Bind("chp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="TWING 250 ML PET" SortExpression="tqp"><ItemTemplate>
                <asp:HiddenField ID="hdtqp1" runat="server" Value='<%# Eval("tqp","{0:n0}") %>' /><asp:HiddenField ID="hdtqp2" runat="server" Value='<%# Eval("tqp") %>' />
                <asp:Label ID="lbtqp" runat="server" Text='<%# Bind("tqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="TWING 500 ML PET" SortExpression="thp" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdthp1" runat="server" Value='<%# Eval("thp","{0:n0}") %>' /><asp:HiddenField ID="bhthp2" runat="server" Value='<%# Eval("thp") %>' />
                <asp:Label ID="lbthp" runat="server" Text='<%# Bind("thp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML CAN" SortExpression="sqc"><ItemTemplate>
                <asp:HiddenField ID="hdsqc1" runat="server" Value='<%# Eval("sqc","{0:n0}") %>' /><asp:HiddenField ID="hdsqc2" runat="server" Value='<%# Eval("sqc") %>' />
                <asp:Label ID="lbsqc" runat="server" Text='<%# Bind("sqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 250 ML PET" SortExpression="fmqp"><ItemTemplate>
                <asp:HiddenField ID="hdfmqp1" runat="server" Value='<%# Eval("FQP","{0:n0}") %>' /><asp:HiddenField ID="hdfmqp2" runat="server" Value='<%# Eval("FQP") %>' />
                <asp:Label ID="lbfmqp" runat="server" Text='<%# Bind("FQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 500 ML PET" SortExpression="fmhp"><ItemTemplate>
                <asp:HiddenField ID="hdfmhp1" runat="server" Value='<%# Eval("FHP","{0:n0}") %>' /><asp:HiddenField ID="hdfmhp2" runat="server" Value='<%# Eval("FHP") %>' />
                <asp:Label ID="lbfmhp" runat="server" Text='<%# Bind("FHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FRUTIKA MANGO 1000 ML PET" SortExpression="fmop"><ItemTemplate>
                <asp:HiddenField ID="hdfmop1" runat="server" Value='<%# Eval("FOP","{0:n0}") %>' /><asp:HiddenField ID="hdfmop2" runat="server" Value='<%# Eval("FOP") %>' />
                <asp:Label ID="lbfmop" runat="server" Text='<%# Bind("FOP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="FRUTIKA RED GRAPE 250 ML PET" SortExpression="frgqp"><ItemTemplate>
                <asp:HiddenField ID="hdfrgqp1" runat="server" Value='<%# Eval("FRGQP","{0:n0}") %>' /><asp:HiddenField ID="hdfrgqp2" runat="server" Value='<%# Eval("FRGQP") %>' />
                <asp:Label ID="lbfrgqp" runat="server" Text='<%# Bind("FRGQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(16)" SortExpression="uhth16"><ItemTemplate>
                <asp:HiddenField ID="hduhth161" runat="server" Value='<%# Eval("FFHT16","{0:n0}") %>' /><asp:HiddenField ID="hduhth162" runat="server" Value='<%# Eval("FFHT16") %>' />
                <asp:Label ID="lbuhth16" runat="server" Text='<%# Bind("FFHT16","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(8)" SortExpression="uhth8"><ItemTemplate>
                <asp:HiddenField ID="hduhth81" runat="server" Value='<%# Eval("FFHT","{0:n0}") %>' /><asp:HiddenField ID="hduhth82" runat="server" Value='<%# Eval("FFHT") %>' />
                <asp:Label ID="lbuhth8" runat="server" Text='<%# Bind("FFHT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="FARM FRESH GHEE 200 ML TIN COTA" SortExpression="ffg2"><ItemTemplate>                  
                 <asp:HiddenField ID="hdffg21" runat="server" Value='<%# Eval("FGQ","{0:n0}") %>' /><asp:HiddenField ID="hfffg22" runat="server" Value='<%# Eval("FGQ") %>' />
                 <asp:Label ID="lbffg2" runat="server" Text='<%# Bind("FGQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH GHEE 450 ML TIN COTA" SortExpression="ffg4"><ItemTemplate>
                 <asp:HiddenField ID="hdffg41" runat="server" Value='<%# Eval("FGH","{0:n0}") %>' /><asp:HiddenField ID="hdffg42" runat="server" Value='<%# Eval("FGH") %>' />
                 <asp:Label ID="lbffg4" runat="server" Text='<%# Bind("FGH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="FARM FRESH GHEE 900 ML TIN COTA" SortExpression="ffg9"><ItemTemplate>
                <asp:HiddenField ID="hdffg91" runat="server" Value='<%# Eval("FGO","{0:n0}") %>' /><asp:HiddenField ID="hdffg92" runat="server" Value='<%# Eval("FGO") %>' />
                <asp:Label ID="lbffg9" runat="server" Text='<%# Bind("FGO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="CHEESE PUFFS CRACKERS 22 GM" SortExpression="cp"><ItemTemplate>
                <asp:HiddenField ID="hdcp1" runat="server" Value='<%# Eval("cps","{0:n0}") %>' /><asp:HiddenField ID="hdcp2" runat="server" Value='<%# Eval("cps") %>' />
                <asp:Label ID="lbcp" runat="server" Text='<%# Bind("cps","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="MOJO 1000 ML PET" SortExpression="mop"><ItemTemplate>
                <asp:HiddenField ID="hdmop1" runat="server" Value='<%# Eval("mop","{0:n0}") %>' /><asp:HiddenField ID="hdmop2" runat="server" Value='<%# Eval("mop") %>' />
                <asp:Label ID="lbmop" runat="server" Text='<%# Bind("mop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MOJO 2000 ML PET" SortExpression="mtp"><ItemTemplate>
                <asp:HiddenField ID="hdmtp1" runat="server" Value='<%# Eval("mtp","{0:n0}") %>' /><asp:HiddenField ID="hdmtp2" runat="server" Value='<%# Eval("mtp") %>' />
                <asp:Label ID="lbmtp" runat="server" Text='<%# Bind("mtp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="LEMU 250 ML CAN" SortExpression="lqc"><ItemTemplate>
                <asp:HiddenField ID="hdlqc1" runat="server" Value='<%# Eval("lqc","{0:n0}") %>' /><asp:HiddenField ID="hdlqc2" runat="server" Value='<%# Eval("lqc") %>' />
                <asp:Label ID="lblqc" runat="server" Text='<%# Bind("lqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="LEMU 250 ML PET" SortExpression="lqp"><ItemTemplate>
                <asp:HiddenField ID="hdlqp1" runat="server" Value='<%# Eval("lqp","{0:n0}") %>' /><asp:HiddenField ID="hdlqp2" runat="server" Value='<%# Eval("lqp") %>' />
                <asp:Label ID="lblqp" runat="server" Text='<%# Bind("lqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="CLEMON 1000 ML PET" SortExpression="cop" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdcop1" runat="server" Value='<%# Eval("cop","{0:n0}") %>' /><asp:HiddenField ID="bhcop2" runat="server" Value='<%# Eval("cop") %>' />
                <asp:Label ID="lbcop" runat="server" Text='<%# Bind("cop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 2000 ML PET" SortExpression="ctp"><ItemTemplate>
                <asp:HiddenField ID="hdctp1" runat="server" Value='<%# Eval("ctp","{0:n0}") %>' /><asp:HiddenField ID="hdctp2" runat="server" Value='<%# Eval("ctp") %>' />
                <asp:Label ID="lbctp" runat="server" Text='<%# Bind("ctp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML PET" SortExpression="sqp"><ItemTemplate>
                <asp:HiddenField ID="hdsqp1" runat="server" Value='<%# Eval("sqp","{0:n0}") %>' /><asp:HiddenField ID="hdsqp2" runat="server" Value='<%# Eval("sqp") %>' />
                <asp:Label ID="lbsqp" runat="server" Text='<%# Bind("sqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="WILD BREW 250 ML CAN" SortExpression="wbqc"><ItemTemplate>
                <asp:HiddenField ID="hdwbqc1" runat="server" Value='<%# Eval("wqc","{0:n0}") %>' /><asp:HiddenField ID="hdwbqc2" runat="server" Value='<%# Eval("wqc") %>' />
                <asp:Label ID="lbwbqc" runat="server" Text='<%# Bind("wqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="AAFI MANGO 250 ML PET" SortExpression="amqp"><ItemTemplate>
                <asp:HiddenField ID="hdamqp1" runat="server" Value='<%# Eval("AMQ","{0:n0}") %>' /><asp:HiddenField ID="hdamqp2" runat="server" Value='<%# Eval("AMQ") %>' />
                <asp:Label ID="lbamqp" runat="server" Text='<%# Bind("AMQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="AAFI MANGO 500 ML PET" SortExpression="amhp"><ItemTemplate>
                <asp:HiddenField ID="hdamhp1" runat="server" Value='<%# Eval("amh","{0:n0}") %>' /><asp:HiddenField ID="hdamhp2" runat="server" Value='<%# Eval("amh") %>' />
                <asp:Label ID="lbamhp" runat="server" Text='<%# Bind("amh","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="AAFI MANGO 1000 ML PET" SortExpression="amop"><ItemTemplate>
                <asp:HiddenField ID="hdamop1" runat="server" Value='<%# Eval("amo","{0:n0}") %>' /><asp:HiddenField ID="hdamop2" runat="server" Value='<%# Eval("amo") %>' />
                <asp:Label ID="lbamop" runat="server" Text='<%# Bind("amo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                                                                                                                                  

                <asp:TemplateField HeaderText="LITTLE FRUTIKA 125 ML BRICK" SortExpression="lfb"><ItemTemplate>
                <asp:HiddenField ID="hdlfb1" runat="server" Value='<%# Eval("FLT","{0:n0}") %>' /><asp:HiddenField ID="hdlfb2" runat="server" Value='<%# Eval("FLT") %>' />
                <asp:Label ID="lblfb" runat="server" Text='<%# Bind("FLT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="SPA 500 ML PET" SortExpression="spfp"><ItemTemplate>
                <asp:HiddenField ID="hdspfp1" runat="server" Value='<%# Eval("SPHP","{0:n0}") %>' /><asp:HiddenField ID="hdspfp2" runat="server" Value='<%# Eval("SPHP") %>' />
                <asp:Label ID="lbspfp" runat="server" Text='<%# Bind("SPHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="SPA 1500 ML PET" SortExpression="spohp"><ItemTemplate>                  
                 <asp:HiddenField ID="hdspohp1" runat="server" Value='<%# Eval("SPFP","{0:n0}") %>' /><asp:HiddenField ID="hfspohp2" runat="server" Value='<%# Eval("SPFP") %>' />
                 <asp:Label ID="lbspohp" runat="server" Text='<%# Bind("SPFP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPA 250 ML PET" SortExpression="spqp"><ItemTemplate>
                 <asp:HiddenField ID="hdspqp1" runat="server" Value='<%# Eval("spqp","{0:n0}") %>' /><asp:HiddenField ID="hdspqp2" runat="server" Value='<%# Eval("spqp") %>' />
                 <asp:Label ID="lbspqp" runat="server" Text='<%# Bind("SPQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="PASTURIZED MILK 1000 ML" SortExpression="pmo"><ItemTemplate>
                <asp:HiddenField ID="hdpmo1" runat="server" Value='<%# Eval("pmo","{0:n0}") %>' /><asp:HiddenField ID="hdpmo2" runat="server" Value='<%# Eval("pmo") %>' />
                <asp:Label ID="lbpmo" runat="server" Text='<%# Bind("pmo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="PASTURIZED MILK 500 ML" SortExpression="PM5M"><ItemTemplate>
                <asp:HiddenField ID="hdpmh1" runat="server" Value='<%# Eval("PM5M","{0:n0}") %>' /><asp:HiddenField ID="hdpmh2" runat="server" Value='<%# Eval("PM5M") %>' />
                <asp:Label ID="lbpmh" runat="server" Text='<%# Bind("PM5M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="PASTURIZED MILK 200 ML" SortExpression="pmq"><ItemTemplate>
                <asp:HiddenField ID="hdpmq1" runat="server" Value='<%# Eval("PM2M","{0:n0}") %>' /><asp:HiddenField ID="hdpmq2" runat="server" Value='<%# Eval("PM2M") %>' />
                <asp:Label ID="lbpmq" runat="server" Text='<%# Bind("PM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MANGO MILK 200 ML" SortExpression="mmq"><ItemTemplate>
                <asp:HiddenField ID="hdmmq1" runat="server" Value='<%# Eval("MM2M","{0:n0}") %>' /><asp:HiddenField ID="hdmmq2" runat="server" Value='<%# Eval("MM2M") %>' />
                <asp:Label ID="lbmmq" runat="server" Text='<%# Bind("MM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CHOCOLATE MILK 200 ML" SortExpression="CM2M"><ItemTemplate>
                <asp:HiddenField ID="hdcmq1" runat="server" Value='<%# Eval("CM2M","{0:n0}") %>' /><asp:HiddenField ID="hdcmq2" runat="server" Value='<%# Eval("CM2M") %>' />
                <asp:Label ID="lbcmq" runat="server" Text='<%# Bind("CM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SOUR) 500 GM BOX" SortExpression="ysq"><ItemTemplate>
                <asp:HiddenField ID="hdysq1" runat="server" Value='<%# Eval("FFYSRH","{0:n0}") %>' /><asp:HiddenField ID="hdysq2" runat="server" Value='<%# Eval("FFYSRH") %>' />
                <asp:Label ID="lbysq" runat="server" Text='<%# Bind("FFYSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 500 GM BOX" SortExpression="ystq" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdystq1" runat="server" Value='<%# Eval("FFYSH","{0:n0}") %>' /><asp:HiddenField ID="bhystq2" runat="server" Value='<%# Eval("FFYSH") %>' />
                <asp:Label ID="lbystq" runat="server" Text='<%# Bind("FFYSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 100 GM CUP" SortExpression="yst1"><ItemTemplate>
                <asp:HiddenField ID="hdyst11" runat="server" Value='<%# Eval("FFYS1","{0:n0}") %>' /><asp:HiddenField ID="hdyst12" runat="server" Value='<%# Eval("FFYS1") %>' />
                <asp:Label ID="lbyst1" runat="server" Text='<%# Bind("FFYS1","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SWEET) 500 GM BOX" SortExpression="ylfsth"><ItemTemplate>
                <asp:HiddenField ID="hdylfsth1" runat="server" Value='<%# Eval("FFYLFSH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsth2" runat="server" Value='<%# Eval("FFYLFSH") %>' />
                <asp:Label ID="lbylfsth" runat="server" Text='<%# Bind("FFYLFSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SOUR) 500 GM BOX" SortExpression="ylfsh"><ItemTemplate>
                <asp:HiddenField ID="hdylfsh1" runat="server" Value='<%# Eval("FFYLFSRH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsh2" runat="server" Value='<%# Eval("FFYLFSRH") %>' />
                <asp:Label ID="lbylfsh" runat="server" Text='<%# Bind("FFYLFSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="BUTTER 200 GM" SortExpression="BT2"><ItemTemplate>
                <asp:HiddenField ID="hdbtq1" runat="server" Value='<%# Eval("BT2","{0:n0}") %>' /><asp:HiddenField ID="hdbtq2" runat="server" Value='<%# Eval("BT2") %>' />
                <asp:Label ID="lbbtq" runat="server" Text='<%# Bind("BT2","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="BUTTER KG" SortExpression="bto"><ItemTemplate>
                <asp:HiddenField ID="hdbto1" runat="server" Value='<%# Eval("BTO","{0:n0}") %>' /><asp:HiddenField ID="hdbto2" runat="server" Value='<%# Eval("BTO") %>' />
                <asp:Label ID="lbbto" runat="server" Text='<%# Bind("BTO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="GHEE KG" SortExpression="gheekg"><ItemTemplate>
                <asp:HiddenField ID="hdgheekg1" runat="server" Value='<%# Eval("GHO","{0:n0}") %>' /><asp:HiddenField ID="hdgheekg2" runat="server" Value='<%# Eval("GHO") %>' />
                <asp:Label ID="lbgheekg" runat="server" Text='<%# Bind("GHO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
           
                 <%--<asp:TemplateField HeaderText="Amount" SortExpression="itemname"><ItemTemplate>
                <asp:HiddenField ID="hdAmount1" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' /><asp:HiddenField ID="hdAmount2" runat="server" Value='<%# Eval("Amount") %>' />
                <asp:Label ID="lbAmount" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>--%>
                     
                      </Columns>
                 <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
     
               



    
                       <asp:GridView ID="dgvNational" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="Row No"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

               <asp:TemplateField HeaderText="PointID" SortExpression="intPointID"><ItemTemplate>                  
                 <asp:HiddenField ID="hdintPointID1" runat="server" Value='<%# Eval("intPointID") %>' /><asp:HiddenField ID="intPointID2" runat="server" Value='<%# Eval("intPointID") %>' />
                 <asp:Label ID="lbintPointID" runat="server" Text='<%# Bind("intPointID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>
                <asp:TemplateField HeaderText="Point" SortExpression="strPointName"><ItemTemplate>                  
                 <asp:HiddenField ID="hdstrPointName1" runat="server" Value='<%# Eval("strPointName") %>' /><asp:HiddenField ID="hdstrPointName2" runat="server" Value='<%# Eval("strPointName") %>' />
                 <asp:Label ID="lbstrPointName" runat="server" Text='<%# Bind("strPointName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO LIGHT 250 ML CAN" SortExpression="MLQC"><ItemTemplate>                  
                 <asp:HiddenField ID="hdmlqc1" runat="server" Value='<%# Eval("MLQC","{0:n0}") %>' /><asp:HiddenField ID="hfmlqc2" runat="server" Value='<%# Eval("MLQC") %>' />
                 <asp:Label ID="lbmlqc" runat="server" Text='<%# Bind("mlqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO 250 ML CAN" SortExpression="mqc"><ItemTemplate>
                 <asp:HiddenField ID="hdmqc1" runat="server" Value='<%# Eval("mqc","{0:n0}") %>' /><asp:HiddenField ID="hdmqc2" runat="server" Value='<%# Eval("mqc") %>' />
                 <asp:Label ID="lbmqc" runat="server" Text='<%# Bind("mqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="MOJO 250 ML PET" SortExpression="mqp"><ItemTemplate>
                <asp:HiddenField ID="hdmqp1" runat="server" Value='<%# Eval("mqp","{0:n0}") %>' /><asp:HiddenField ID="hdmqp2" runat="server" Value='<%# Eval("mqp") %>' />
                <asp:Label ID="lbmqp" runat="server" Text='<%# Bind("mqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="MOJO 500 ML PET" SortExpression="mhp"><ItemTemplate>
                <asp:HiddenField ID="hdmhp1" runat="server" Value='<%# Eval("mhp","{0:n0}") %>' /><asp:HiddenField ID="hdmhp2" runat="server" Value='<%# Eval("mhp") %>' />
                <asp:Label ID="lbmhp" runat="server" Text='<%# Bind("mhp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="CLEMON 250 ML CAN" SortExpression="cqc"><ItemTemplate>
                <asp:HiddenField ID="hdcqc1" runat="server" Value='<%# Eval("cqc","{0:n0}") %>' /><asp:HiddenField ID="hdcqc2" runat="server" Value='<%# Eval("cqc") %>' />
                <asp:Label ID="lbcqc" runat="server" Text='<%# Bind("cqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="CLEMON 250 ML PET" SortExpression="cqp"><ItemTemplate>
                <asp:HiddenField ID="hdcqp1" runat="server" Value='<%# Eval("cqp","{0:n0}") %>' /><asp:HiddenField ID="hdcqp2" runat="server" Value='<%# Eval("cqp") %>' />
                <asp:Label ID="lbcqp" runat="server" Text='<%# Bind("cqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 500 ML PET" SortExpression="chp"><ItemTemplate>
                <asp:HiddenField ID="hdchp1" runat="server" Value='<%# Eval("chp","{0:n0}") %>' /><asp:HiddenField ID="hdchp2" runat="server" Value='<%# Eval("chp") %>' />
                <asp:Label ID="lbchp" runat="server" Text='<%# Bind("chp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="TWING 250 ML PET" SortExpression="tqp"><ItemTemplate>
                <asp:HiddenField ID="hdtqp1" runat="server" Value='<%# Eval("tqp","{0:n0}") %>' /><asp:HiddenField ID="hdtqp2" runat="server" Value='<%# Eval("tqp") %>' />
                <asp:Label ID="lbtqp" runat="server" Text='<%# Bind("tqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="TWING 500 ML PET" SortExpression="thp" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdthp1" runat="server" Value='<%# Eval("thp","{0:n0}") %>' /><asp:HiddenField ID="bhthp2" runat="server" Value='<%# Eval("thp") %>' />
                <asp:Label ID="lbthp" runat="server" Text='<%# Bind("thp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML CAN" SortExpression="sqc"><ItemTemplate>
                <asp:HiddenField ID="hdsqc1" runat="server" Value='<%# Eval("sqc","{0:n0}") %>' /><asp:HiddenField ID="hdsqc2" runat="server" Value='<%# Eval("sqc") %>' />
                <asp:Label ID="lbsqc" runat="server" Text='<%# Bind("sqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 250 ML PET" SortExpression="fqp"><ItemTemplate>
                <asp:HiddenField ID="hdfmqp1" runat="server" Value='<%# Eval("FQP","{0:n0}") %>' /><asp:HiddenField ID="hdfmqp2" runat="server" Value='<%# Eval("FQP") %>' />
                <asp:Label ID="lbfmqp" runat="server" Text='<%# Bind("FQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 500 ML PET" SortExpression="fmhp"><ItemTemplate>
                <asp:HiddenField ID="hdfmhp1" runat="server" Value='<%# Eval("FHP","{0:n0}") %>' /><asp:HiddenField ID="hdfmhp2" runat="server" Value='<%# Eval("FHP") %>' />
                <asp:Label ID="lbfmhp" runat="server" Text='<%# Bind("FHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FRUTIKA MANGO 1000 ML PET" SortExpression="fmop"><ItemTemplate>
                <asp:HiddenField ID="hdfmop1" runat="server" Value='<%# Eval("FOP","{0:n0}") %>' /><asp:HiddenField ID="hdfmop2" runat="server" Value='<%# Eval("FOP") %>' />
                <asp:Label ID="lbfmop" runat="server" Text='<%# Bind("FOP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="FRUTIKA RED GRAPE 250 ML PET" SortExpression="frgqp"><ItemTemplate>
                <asp:HiddenField ID="hdfrgqp1" runat="server" Value='<%# Eval("FRGQP","{0:n0}") %>' /><asp:HiddenField ID="hdfrgqp2" runat="server" Value='<%# Eval("FRGQP") %>' />
                <asp:Label ID="lbfrgqp" runat="server" Text='<%# Bind("FRGQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(16)" SortExpression="uhth16"><ItemTemplate>
                <asp:HiddenField ID="hduhth161" runat="server" Value='<%# Eval("FFHT16","{0:n0}") %>' /><asp:HiddenField ID="hduhth162" runat="server" Value='<%# Eval("FFHT16") %>' />
                <asp:Label ID="lbuhth16" runat="server" Text='<%# Bind("FFHT16","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(8)" SortExpression="uhth8"><ItemTemplate>
                <asp:HiddenField ID="hduhth81" runat="server" Value='<%# Eval("FFHT","{0:n0}") %>' /><asp:HiddenField ID="hduhth82" runat="server" Value='<%# Eval("FFHT") %>' />
                <asp:Label ID="lbuhth8" runat="server" Text='<%# Bind("FFHT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="FARM FRESH GHEE 200 ML TIN COTA" SortExpression="ffg2"><ItemTemplate>                  
                 <asp:HiddenField ID="hdffg21" runat="server" Value='<%# Eval("FGQ","{0:n0}") %>' /><asp:HiddenField ID="hfffg22" runat="server" Value='<%# Eval("FGQ") %>' />
                 <asp:Label ID="lbffg2" runat="server" Text='<%# Bind("FGQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH GHEE 450 ML TIN COTA" SortExpression="ffg4"><ItemTemplate>
                 <asp:HiddenField ID="hdffg41" runat="server" Value='<%# Eval("FGH","{0:n0}") %>' /><asp:HiddenField ID="hdffg42" runat="server" Value='<%# Eval("FGH") %>' />
                 <asp:Label ID="lbffg4" runat="server" Text='<%# Bind("FGH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="FARM FRESH GHEE 900 ML TIN COTA" SortExpression="ffg9"><ItemTemplate>
                <asp:HiddenField ID="hdffg91" runat="server" Value='<%# Eval("FGO","{0:n0}") %>' /><asp:HiddenField ID="hdffg92" runat="server" Value='<%# Eval("FGO") %>' />
                <asp:Label ID="lbffg9" runat="server" Text='<%# Bind("FGO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="CHEESE PUFFS CRACKERS 22 GM" SortExpression="cp"><ItemTemplate>
                <asp:HiddenField ID="hdcp1" runat="server" Value='<%# Eval("cps","{0:n0}") %>' /><asp:HiddenField ID="hdcp2" runat="server" Value='<%# Eval("cps") %>' />
                <asp:Label ID="lbcp" runat="server" Text='<%# Bind("cps","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="MOJO 1000 ML PET" SortExpression="mop"><ItemTemplate>
                <asp:HiddenField ID="hdmop1" runat="server" Value='<%# Eval("mop","{0:n0}") %>' /><asp:HiddenField ID="hdmop2" runat="server" Value='<%# Eval("mop") %>' />
                <asp:Label ID="lbmop" runat="server" Text='<%# Bind("mop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MOJO 2000 ML PET" SortExpression="mtp"><ItemTemplate>
                <asp:HiddenField ID="hdmtp1" runat="server" Value='<%# Eval("mtp","{0:n0}") %>' /><asp:HiddenField ID="hdmtp2" runat="server" Value='<%# Eval("mtp") %>' />
                <asp:Label ID="lbmtp" runat="server" Text='<%# Bind("mtp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="LEMU 250 ML CAN" SortExpression="lqc"><ItemTemplate>
                <asp:HiddenField ID="hdlqc1" runat="server" Value='<%# Eval("lqc","{0:n0}") %>' /><asp:HiddenField ID="hdlqc2" runat="server" Value='<%# Eval("lqc") %>' />
                <asp:Label ID="lblqc" runat="server" Text='<%# Bind("lqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="LEMU 250 ML PET" SortExpression="lqp"><ItemTemplate>
                <asp:HiddenField ID="hdlqp1" runat="server" Value='<%# Eval("lqp","{0:n0}") %>' /><asp:HiddenField ID="hdlqp2" runat="server" Value='<%# Eval("lqp") %>' />
                <asp:Label ID="lblqp" runat="server" Text='<%# Bind("lqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="CLEMON 1000 ML PET" SortExpression="cop" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdcop1" runat="server" Value='<%# Eval("cop","{0:n0}") %>' /><asp:HiddenField ID="bhcop2" runat="server" Value='<%# Eval("cop") %>' />
                <asp:Label ID="lbcop" runat="server" Text='<%# Bind("cop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 2000 ML PET" SortExpression="ctp"><ItemTemplate>
                <asp:HiddenField ID="hdctp1" runat="server" Value='<%# Eval("ctp","{0:n0}") %>' /><asp:HiddenField ID="hdctp2" runat="server" Value='<%# Eval("ctp") %>' />
                <asp:Label ID="lbctp" runat="server" Text='<%# Bind("ctp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML PET" SortExpression="sqp"><ItemTemplate>
                <asp:HiddenField ID="hdsqp1" runat="server" Value='<%# Eval("sqp","{0:n0}") %>' /><asp:HiddenField ID="hdsqp2" runat="server" Value='<%# Eval("sqp") %>' />
                <asp:Label ID="lbsqp" runat="server" Text='<%# Bind("sqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="WILD BREW 250 ML CAN" SortExpression="wbqc"><ItemTemplate>
                <asp:HiddenField ID="hdwbqc1" runat="server" Value='<%# Eval("wqc","{0:n0}") %>' /><asp:HiddenField ID="hdwbqc2" runat="server" Value='<%# Eval("wqc") %>' />
                <asp:Label ID="lbwbqc" runat="server" Text='<%# Bind("wqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="AAFI MANGO 250 ML PET" SortExpression="amqp"><ItemTemplate>
                <asp:HiddenField ID="hdamqp1" runat="server" Value='<%# Eval("AMQ","{0:n0}") %>' /><asp:HiddenField ID="hdamqp2" runat="server" Value='<%# Eval("AMQ") %>' />
                <asp:Label ID="lbamqp" runat="server" Text='<%# Bind("AMQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="AAFI MANGO 500 ML PET" SortExpression="amhp"><ItemTemplate>
                <asp:HiddenField ID="hdamhp1" runat="server" Value='<%# Eval("amh","{0:n0}") %>' /><asp:HiddenField ID="hdamhp2" runat="server" Value='<%# Eval("amh") %>' />
                <asp:Label ID="lbamhp" runat="server" Text='<%# Bind("amh","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="AAFI MANGO 1000 ML PET" SortExpression="amop"><ItemTemplate>
                <asp:HiddenField ID="hdamop1" runat="server" Value='<%# Eval("amo","{0:n0}") %>' /><asp:HiddenField ID="hdamop2" runat="server" Value='<%# Eval("amo") %>' />
                <asp:Label ID="lbamop" runat="server" Text='<%# Bind("amo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                                                                                                                                  

                <asp:TemplateField HeaderText="LITTLE FRUTIKA 125 ML BRICK" SortExpression="lfb"><ItemTemplate>
                <asp:HiddenField ID="hdlfb1" runat="server" Value='<%# Eval("FLT","{0:n0}") %>' /><asp:HiddenField ID="hdlfb2" runat="server" Value='<%# Eval("FLT") %>' />
                <asp:Label ID="lblfb" runat="server" Text='<%# Bind("FLT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="SPA 500 ML PET" SortExpression="spfp"><ItemTemplate>
                <asp:HiddenField ID="hdspfp1" runat="server" Value='<%# Eval("SPHP","{0:n0}") %>' /><asp:HiddenField ID="hdspfp2" runat="server" Value='<%# Eval("SPHP") %>' />
                <asp:Label ID="lbspfp" runat="server" Text='<%# Bind("SPHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="SPA 1500 ML PET" SortExpression="spohp"><ItemTemplate>                  
                 <asp:HiddenField ID="hdspohp1" runat="server" Value='<%# Eval("SPFP","{0:n0}") %>' /><asp:HiddenField ID="hfspohp2" runat="server" Value='<%# Eval("SPFP") %>' />
                 <asp:Label ID="lbspohp" runat="server" Text='<%# Bind("SPFP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPA 250 ML PET" SortExpression="spqp"><ItemTemplate>
                 <asp:HiddenField ID="hdspqp1" runat="server" Value='<%# Eval("spqp","{0:n0}") %>' /><asp:HiddenField ID="hdspqp2" runat="server" Value='<%# Eval("spqp") %>' />
                 <asp:Label ID="lbspqp" runat="server" Text='<%# Bind("SPQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="PASTURIZED MILK 1000 ML" SortExpression="pmo"><ItemTemplate>
                <asp:HiddenField ID="hdpmo1" runat="server" Value='<%# Eval("pmo","{0:n0}") %>' /><asp:HiddenField ID="hdpmo2" runat="server" Value='<%# Eval("pmo") %>' />
                <asp:Label ID="lbpmo" runat="server" Text='<%# Bind("pmo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="PASTURIZED MILK 500 ML" SortExpression="PM5M"><ItemTemplate>
                <asp:HiddenField ID="hdpmh1" runat="server" Value='<%# Eval("PM5M","{0:n0}") %>' /><asp:HiddenField ID="hdpmh2" runat="server" Value='<%# Eval("PM5M") %>' />
                <asp:Label ID="lbpmh" runat="server" Text='<%# Bind("PM5M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="PASTURIZED MILK 200 ML" SortExpression="pmq"><ItemTemplate>
                <asp:HiddenField ID="hdpmq1" runat="server" Value='<%# Eval("PM2M","{0:n0}") %>' /><asp:HiddenField ID="hdpmq2" runat="server" Value='<%# Eval("PM2M") %>' />
                <asp:Label ID="lbpmq" runat="server" Text='<%# Bind("PM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MANGO MILK 200 ML" SortExpression="mmq"><ItemTemplate>
                <asp:HiddenField ID="hdmmq1" runat="server" Value='<%# Eval("MM2M","{0:n0}") %>' /><asp:HiddenField ID="hdmmq2" runat="server" Value='<%# Eval("MM2M") %>' />
                <asp:Label ID="lbmmq" runat="server" Text='<%# Bind("MM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CHOCOLATE MILK 200 ML" SortExpression="CM2M"><ItemTemplate>
                <asp:HiddenField ID="hdcmq1" runat="server" Value='<%# Eval("CM2M","{0:n0}") %>' /><asp:HiddenField ID="hdcmq2" runat="server" Value='<%# Eval("CM2M") %>' />
                <asp:Label ID="lbcmq" runat="server" Text='<%# Bind("CM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SOUR) 500 GM BOX" SortExpression="ysq"><ItemTemplate>
                <asp:HiddenField ID="hdysq1" runat="server" Value='<%# Eval("FFYSRH","{0:n0}") %>' /><asp:HiddenField ID="hdysq2" runat="server" Value='<%# Eval("FFYSRH") %>' />
                <asp:Label ID="lbysq" runat="server" Text='<%# Bind("FFYSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 500 GM BOX" SortExpression="ystq" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdystq1" runat="server" Value='<%# Eval("FFYSH","{0:n0}") %>' /><asp:HiddenField ID="bhystq2" runat="server" Value='<%# Eval("FFYSH") %>' />
                <asp:Label ID="lbystq" runat="server" Text='<%# Bind("FFYSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 100 GM CUP" SortExpression="yst1"><ItemTemplate>
                <asp:HiddenField ID="hdyst11" runat="server" Value='<%# Eval("FFYS1","{0:n0}") %>' /><asp:HiddenField ID="hdyst12" runat="server" Value='<%# Eval("FFYS1") %>' />
                <asp:Label ID="lbyst1" runat="server" Text='<%# Bind("FFYS1","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SWEET) 500 GM BOX" SortExpression="ylfsth"><ItemTemplate>
                <asp:HiddenField ID="hdylfsth1" runat="server" Value='<%# Eval("FFYLFSH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsth2" runat="server" Value='<%# Eval("FFYLFSH") %>' />
                <asp:Label ID="lbylfsth" runat="server" Text='<%# Bind("FFYLFSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SOUR) 500 GM BOX" SortExpression="ylfsh"><ItemTemplate>
                <asp:HiddenField ID="hdylfsh1" runat="server" Value='<%# Eval("FFYLFSRH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsh2" runat="server" Value='<%# Eval("FFYLFSRH") %>' />
                <asp:Label ID="lbylfsh" runat="server" Text='<%# Bind("FFYLFSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="BUTTER 200 GM" SortExpression="BT2"><ItemTemplate>
                <asp:HiddenField ID="hdbtq1" runat="server" Value='<%# Eval("BT2","{0:n0}") %>' /><asp:HiddenField ID="hdbtq2" runat="server" Value='<%# Eval("BT2") %>' />
                <asp:Label ID="lbbtq" runat="server" Text='<%# Bind("BT2","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="BUTTER KG" SortExpression="bto"><ItemTemplate>
                <asp:HiddenField ID="hdbto1" runat="server" Value='<%# Eval("BTO","{0:n0}") %>' /><asp:HiddenField ID="hdbto2" runat="server" Value='<%# Eval("BTO") %>' />
                <asp:Label ID="lbbto" runat="server" Text='<%# Bind("BTO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="GHEE KG" SortExpression="gheekg"><ItemTemplate>
                <asp:HiddenField ID="hdgheekg1" runat="server" Value='<%# Eval("GHO","{0:n0}") %>' /><asp:HiddenField ID="hdgheekg2" runat="server" Value='<%# Eval("GHO") %>' />
                <asp:Label ID="lbgheekg" runat="server" Text='<%# Bind("GHO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>
           
                 <%--<asp:TemplateField HeaderText="Amount" SortExpression="itemname"><ItemTemplate>
                <asp:HiddenField ID="hdAmount1" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' /><asp:HiddenField ID="hdAmount2" runat="server" Value='<%# Eval("Amount") %>' />
                <asp:Label ID="lbAmount" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>--%>
                     
                      </Columns>
                 <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>           
                
     
               
               
    
                       <asp:GridView ID="dgvdate" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                     <asp:TemplateField HeaderText="Row No"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

               <asp:TemplateField HeaderText="Date" SortExpression="intPointID" ControlStyle-Width="80px" ><ItemTemplate>                  
                 <asp:HiddenField ID="hdintPointID1" runat="server" Value='<%# Eval("intPointID") %>' /><asp:HiddenField ID="intPointID2" runat="server" Value='<%# Eval("intPointID") %>' />
                 <asp:Label ID="lbintPointID" runat="server" Text='<%# Bind("intPointID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="260px"/></asp:TemplateField>

               <%-- <asp:TemplateField HeaderText="Point" SortExpression="strPointName"><ItemTemplate>                  
                 <asp:HiddenField ID="hdstrPointName1" runat="server" Value='<%# Eval("strPointName") %>' /><asp:HiddenField ID="hdstrPointName2" runat="server" Value='<%# Eval("strPointName") %>' />
                 <asp:Label ID="lbstrPointName" runat="server" Text='<%# Bind("strPointName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>--%>

                 <asp:TemplateField HeaderText="MOJO LIGHT 250 ML CAN" SortExpression="MLQC"><ItemTemplate>                  
                 <asp:HiddenField ID="hdmlqc1" runat="server" Value='<%# Eval("MLQC","{0:n0}") %>' /><asp:HiddenField ID="hfmlqc2" runat="server" Value='<%# Eval("MLQC") %>' />
                 <asp:Label ID="lbmlqc" runat="server" Text='<%# Bind("mlqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="MOJO 250 ML CAN" SortExpression="mqc"><ItemTemplate>
                 <asp:HiddenField ID="hdmqc1" runat="server" Value='<%# Eval("mqc","{0:n0}") %>' /><asp:HiddenField ID="hdmqc2" runat="server" Value='<%# Eval("mqc") %>' />
                 <asp:Label ID="lbmqc" runat="server" Text='<%# Bind("mqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="MOJO 250 ML PET" SortExpression="mqp"><ItemTemplate>
                <asp:HiddenField ID="hdmqp1" runat="server" Value='<%# Eval("mqp","{0:n0}") %>' /><asp:HiddenField ID="hdmqp2" runat="server" Value='<%# Eval("mqp") %>' />
                <asp:Label ID="lbmqp" runat="server" Text='<%# Bind("mqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="MOJO 500 ML PET" SortExpression="mhp"><ItemTemplate>
                <asp:HiddenField ID="hdmhp1" runat="server" Value='<%# Eval("mhp","{0:n0}") %>' /><asp:HiddenField ID="hdmhp2" runat="server" Value='<%# Eval("mhp") %>' />
                <asp:Label ID="lbmhp" runat="server" Text='<%# Bind("mhp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="CLEMON 250 ML CAN" SortExpression="cqc"><ItemTemplate>
                <asp:HiddenField ID="hdcqc1" runat="server" Value='<%# Eval("cqc","{0:n0}") %>' /><asp:HiddenField ID="hdcqc2" runat="server" Value='<%# Eval("cqc") %>' />
                <asp:Label ID="lbcqc" runat="server" Text='<%# Bind("cqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="CLEMON 250 ML PET" SortExpression="cqp"><ItemTemplate>
                <asp:HiddenField ID="hdcqp1" runat="server" Value='<%# Eval("cqp","{0:n0}") %>' /><asp:HiddenField ID="hdcqp2" runat="server" Value='<%# Eval("cqp") %>' />
                <asp:Label ID="lbcqp" runat="server" Text='<%# Bind("cqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 500 ML PET" SortExpression="chp"><ItemTemplate>
                <asp:HiddenField ID="hdchp1" runat="server" Value='<%# Eval("chp","{0:n0}") %>' /><asp:HiddenField ID="hdchp2" runat="server" Value='<%# Eval("chp") %>' />
                <asp:Label ID="lbchp" runat="server" Text='<%# Bind("chp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="TWING 250 ML PET" SortExpression="tqp"><ItemTemplate>
                <asp:HiddenField ID="hdtqp1" runat="server" Value='<%# Eval("tqp","{0:n0}") %>' /><asp:HiddenField ID="hdtqp2" runat="server" Value='<%# Eval("tqp") %>' />
                <asp:Label ID="lbtqp" runat="server" Text='<%# Bind("tqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="TWING 500 ML PET" SortExpression="thp" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdthp1" runat="server" Value='<%# Eval("thp","{0:n0}") %>' /><asp:HiddenField ID="bhthp2" runat="server" Value='<%# Eval("thp") %>' />
                <asp:Label ID="lbthp" runat="server" Text='<%# Bind("thp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML CAN" SortExpression="sqc"><ItemTemplate>
                <asp:HiddenField ID="hdsqc1" runat="server" Value='<%# Eval("sqc","{0:n0}") %>' /><asp:HiddenField ID="hdsqc2" runat="server" Value='<%# Eval("sqc") %>' />
                <asp:Label ID="lbsqc" runat="server" Text='<%# Bind("sqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 250 ML PET" SortExpression="fmqp"><ItemTemplate>
                <asp:HiddenField ID="hdfmqp1" runat="server" Value='<%# Eval("FQP","{0:n0}") %>' /><asp:HiddenField ID="hdfmqp2" runat="server" Value='<%# Eval("FQP") %>' />
                <asp:Label ID="lbfmqp" runat="server" Text='<%# Bind("FQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FRUTIKA MANGO 500 ML PET" SortExpression="fmhp"><ItemTemplate>
                <asp:HiddenField ID="hdfmhp1" runat="server" Value='<%# Eval("FHP","{0:n0}") %>' /><asp:HiddenField ID="hdfmhp2" runat="server" Value='<%# Eval("FHP") %>' />
                <asp:Label ID="lbfmhp" runat="server" Text='<%# Bind("FHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FRUTIKA MANGO 1000 ML PET" SortExpression="fmop"><ItemTemplate>
                <asp:HiddenField ID="hdfmop1" runat="server" Value='<%# Eval("FOP","{0:n0}") %>' /><asp:HiddenField ID="hdfmop2" runat="server" Value='<%# Eval("FOP") %>' />
                <asp:Label ID="lbfmop" runat="server" Text='<%# Bind("FOP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="FRUTIKA RED GRAPE 250 ML PET" SortExpression="frgqp"><ItemTemplate>
                <asp:HiddenField ID="hdfrgqp1" runat="server" Value='<%# Eval("FRGQP","{0:n0}") %>' /><asp:HiddenField ID="hdfrgqp2" runat="server" Value='<%# Eval("FRGQP") %>' />
                <asp:Label ID="lbfrgqp" runat="server" Text='<%# Bind("FRGQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(16)" SortExpression="uhth16"><ItemTemplate>
                <asp:HiddenField ID="hduhth161" runat="server" Value='<%# Eval("FFHT16","{0:n0}") %>' /><asp:HiddenField ID="hduhth162" runat="server" Value='<%# Eval("FFHT16") %>' />
                <asp:Label ID="lbuhth16" runat="server" Text='<%# Bind("FFHT16","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="FARM FRESH UHT 500 ML(8)" SortExpression="uhth8"><ItemTemplate>
                <asp:HiddenField ID="hduhth81" runat="server" Value='<%# Eval("FFHT","{0:n0}") %>' /><asp:HiddenField ID="hduhth82" runat="server" Value='<%# Eval("FFHT") %>' />
                <asp:Label ID="lbuhth8" runat="server" Text='<%# Bind("FFHT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="FARM FRESH GHEE 200 ML TIN COTA" SortExpression="ffg2"><ItemTemplate>                  
                 <asp:HiddenField ID="hdffg21" runat="server" Value='<%# Eval("FGQ","{0:n0}") %>' /><asp:HiddenField ID="hfffg22" runat="server" Value='<%# Eval("FGQ") %>' />
                 <asp:Label ID="lbffg2" runat="server" Text='<%# Bind("FGQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH GHEE 450 ML TIN COTA" SortExpression="ffg4"><ItemTemplate>
                 <asp:HiddenField ID="hdffg41" runat="server" Value='<%# Eval("FGH","{0:n0}") %>' /><asp:HiddenField ID="hdffg42" runat="server" Value='<%# Eval("FGH") %>' />
                 <asp:Label ID="lbffg4" runat="server" Text='<%# Bind("FGH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="FARM FRESH GHEE 900 ML TIN COTA" SortExpression="ffg9"><ItemTemplate>
                <asp:HiddenField ID="hdffg91" runat="server" Value='<%# Eval("FGO","{0:n0}") %>' /><asp:HiddenField ID="hdffg92" runat="server" Value='<%# Eval("FGO") %>' />
                <asp:Label ID="lbffg9" runat="server" Text='<%# Bind("FGO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="CHEESE PUFFS CRACKERS 22 GM" SortExpression="cp"><ItemTemplate>
                <asp:HiddenField ID="hdcp1" runat="server" Value='<%# Eval("cps","{0:n0}") %>' /><asp:HiddenField ID="hdcp2" runat="server" Value='<%# Eval("cps") %>' />
                <asp:Label ID="lbcp" runat="server" Text='<%# Bind("cps","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="MOJO 1000 ML PET" SortExpression="mop"><ItemTemplate>
                <asp:HiddenField ID="hdmop1" runat="server" Value='<%# Eval("mop","{0:n0}") %>' /><asp:HiddenField ID="hdmop2" runat="server" Value='<%# Eval("mop") %>' />
                <asp:Label ID="lbmop" runat="server" Text='<%# Bind("mop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MOJO 2000 ML PET" SortExpression="mtp"><ItemTemplate>
                <asp:HiddenField ID="hdmtp1" runat="server" Value='<%# Eval("mtp","{0:n0}") %>' /><asp:HiddenField ID="hdmtp2" runat="server" Value='<%# Eval("mtp") %>' />
                <asp:Label ID="lbmtp" runat="server" Text='<%# Bind("mtp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="LEMU 250 ML CAN" SortExpression="lqc"><ItemTemplate>
                <asp:HiddenField ID="hdlqc1" runat="server" Value='<%# Eval("lqc","{0:n0}") %>' /><asp:HiddenField ID="hdlqc2" runat="server" Value='<%# Eval("lqc") %>' />
                <asp:Label ID="lblqc" runat="server" Text='<%# Bind("lqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="LEMU 250 ML PET" SortExpression="lqp"><ItemTemplate>
                <asp:HiddenField ID="hdlqp1" runat="server" Value='<%# Eval("lqp","{0:n0}") %>' /><asp:HiddenField ID="hdlqp2" runat="server" Value='<%# Eval("lqp") %>' />
                <asp:Label ID="lblqp" runat="server" Text='<%# Bind("lqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="CLEMON 1000 ML PET" SortExpression="cop" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdcop1" runat="server" Value='<%# Eval("cop","{0:n0}") %>' /><asp:HiddenField ID="bhcop2" runat="server" Value='<%# Eval("cop") %>' />
                <asp:Label ID="lbcop" runat="server" Text='<%# Bind("cop","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CLEMON 2000 ML PET" SortExpression="ctp"><ItemTemplate>
                <asp:HiddenField ID="hdctp1" runat="server" Value='<%# Eval("ctp","{0:n0}") %>' /><asp:HiddenField ID="hdctp2" runat="server" Value='<%# Eval("ctp") %>' />
                <asp:Label ID="lbctp" runat="server" Text='<%# Bind("ctp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPEED 250 ML PET" SortExpression="sqp"><ItemTemplate>
                <asp:HiddenField ID="hdsqp1" runat="server" Value='<%# Eval("sqp","{0:n0}") %>' /><asp:HiddenField ID="hdsqp2" runat="server" Value='<%# Eval("sqp") %>' />
                <asp:Label ID="lbsqp" runat="server" Text='<%# Bind("sqp","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="WILD BREW 250 ML CAN" SortExpression="wbqc"><ItemTemplate>
                <asp:HiddenField ID="hdwbqc1" runat="server" Value='<%# Eval("wqc","{0:n0}") %>' /><asp:HiddenField ID="hdwbqc2" runat="server" Value='<%# Eval("wqc") %>' />
                <asp:Label ID="lbwbqc" runat="server" Text='<%# Bind("wqc","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="AAFI MANGO 250 ML PET" SortExpression="amqp"><ItemTemplate>
                <asp:HiddenField ID="hdamqp1" runat="server" Value='<%# Eval("AMQ","{0:n0}") %>' /><asp:HiddenField ID="hdamqp2" runat="server" Value='<%# Eval("AMQ") %>' />
                <asp:Label ID="lbamqp" runat="server" Text='<%# Bind("AMQ","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="AAFI MANGO 500 ML PET" SortExpression="amhp"><ItemTemplate>
                <asp:HiddenField ID="hdamhp1" runat="server" Value='<%# Eval("amh","{0:n0}") %>' /><asp:HiddenField ID="hdamhp2" runat="server" Value='<%# Eval("amh") %>' />
                <asp:Label ID="lbamhp" runat="server" Text='<%# Bind("amh","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="AAFI MANGO 1000 ML PET" SortExpression="amop"><ItemTemplate>
                <asp:HiddenField ID="hdamop1" runat="server" Value='<%# Eval("amo","{0:n0}") %>' /><asp:HiddenField ID="hdamop2" runat="server" Value='<%# Eval("amo") %>' />
                <asp:Label ID="lbamop" runat="server" Text='<%# Bind("amo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                                                                                                                                  

                <asp:TemplateField HeaderText="LITTLE FRUTIKA 125 ML BRICK" SortExpression="lfb"><ItemTemplate>
                <asp:HiddenField ID="hdlfb1" runat="server" Value='<%# Eval("FLT","{0:n0}") %>' /><asp:HiddenField ID="hdlfb2" runat="server" Value='<%# Eval("FLT") %>' />
                <asp:Label ID="lblfb" runat="server" Text='<%# Bind("FLT","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="SPA 500 ML PET" SortExpression="spfp"><ItemTemplate>
                <asp:HiddenField ID="hdspfp1" runat="server" Value='<%# Eval("SPHP","{0:n0}") %>' /><asp:HiddenField ID="hdspfp2" runat="server" Value='<%# Eval("SPHP") %>' />
                <asp:Label ID="lbspfp" runat="server" Text='<%# Bind("SPHP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                     <asp:TemplateField HeaderText="SPA 1500 ML PET" SortExpression="spohp"><ItemTemplate>                  
                 <asp:HiddenField ID="hdspohp1" runat="server" Value='<%# Eval("SPFP","{0:n0}") %>' /><asp:HiddenField ID="hfspohp2" runat="server" Value='<%# Eval("SPFP") %>' />
                 <asp:Label ID="lbspohp" runat="server" Text='<%# Bind("SPFP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="SPA 250 ML PET" SortExpression="spqp"><ItemTemplate>
                 <asp:HiddenField ID="hdspqp1" runat="server" Value='<%# Eval("spqp","{0:n0}") %>' /><asp:HiddenField ID="hdspqp2" runat="server" Value='<%# Eval("spqp") %>' />
                 <asp:Label ID="lbspqp" runat="server" Text='<%# Bind("SPQP","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px"/></asp:TemplateField> 

                <asp:TemplateField HeaderText="PASTURIZED MILK 1000 ML" SortExpression="pmo"><ItemTemplate>
                <asp:HiddenField ID="hdpmo1" runat="server" Value='<%# Eval("pmo","{0:n0}") %>' /><asp:HiddenField ID="hdpmo2" runat="server" Value='<%# Eval("pmo") %>' />
                <asp:Label ID="lbpmo" runat="server" Text='<%# Bind("pmo","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 
                                                            
                <asp:TemplateField HeaderText="PASTURIZED MILK 500 ML" SortExpression="PM5M"><ItemTemplate>
                <asp:HiddenField ID="hdpmh1" runat="server" Value='<%# Eval("PM5M","{0:n0}") %>' /><asp:HiddenField ID="hdpmh2" runat="server" Value='<%# Eval("PM5M") %>' />
                <asp:Label ID="lbpmh" runat="server" Text='<%# Bind("PM5M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                 <asp:TemplateField HeaderText="PASTURIZED MILK 200 ML" SortExpression="pmq"><ItemTemplate>
                <asp:HiddenField ID="hdpmq1" runat="server" Value='<%# Eval("PM2M","{0:n0}") %>' /><asp:HiddenField ID="hdpmq2" runat="server" Value='<%# Eval("PM2M") %>' />
                <asp:Label ID="lbpmq" runat="server" Text='<%# Bind("PM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField> 

                     <asp:TemplateField HeaderText="MANGO MILK 200 ML" SortExpression="mmq"><ItemTemplate>
                <asp:HiddenField ID="hdmmq1" runat="server" Value='<%# Eval("MM2M","{0:n0}") %>' /><asp:HiddenField ID="hdmmq2" runat="server" Value='<%# Eval("MM2M") %>' />
                <asp:Label ID="lbmmq" runat="server" Text='<%# Bind("MM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="CHOCOLATE MILK 200 ML" SortExpression="CM2M"><ItemTemplate>
                <asp:HiddenField ID="hdcmq1" runat="server" Value='<%# Eval("CM2M","{0:n0}") %>' /><asp:HiddenField ID="hdcmq2" runat="server" Value='<%# Eval("CM2M") %>' />
                <asp:Label ID="lbcmq" runat="server" Text='<%# Bind("CM2M","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

               <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SOUR) 500 GM BOX" SortExpression="ysq"><ItemTemplate>
                <asp:HiddenField ID="hdysq1" runat="server" Value='<%# Eval("FFYSRH","{0:n0}") %>' /><asp:HiddenField ID="hdysq2" runat="server" Value='<%# Eval("FFYSRH") %>' />
                <asp:Label ID="lbysq" runat="server" Text='<%# Bind("FFYSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 500 GM BOX" SortExpression="ystq" HeaderStyle-Width="30px"><ItemTemplate>
                <asp:HiddenField ID="hdystq1" runat="server" Value='<%# Eval("FFYSH","{0:n0}") %>' /><asp:HiddenField ID="bhystq2" runat="server" Value='<%# Eval("FFYSH") %>' />
                <asp:Label ID="lbystq" runat="server" Text='<%# Bind("FFYSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT (SWEET) 100 GM CUP" SortExpression="yst1"><ItemTemplate>
                <asp:HiddenField ID="hdyst11" runat="server" Value='<%# Eval("FFYS1","{0:n0}") %>' /><asp:HiddenField ID="hdyst12" runat="server" Value='<%# Eval("FFYS1") %>' />
                <asp:Label ID="lbyst1" runat="server" Text='<%# Bind("FFYS1","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SWEET) 500 GM BOX" SortExpression="ylfsth"><ItemTemplate>
                <asp:HiddenField ID="hdylfsth1" runat="server" Value='<%# Eval("FFYLFSH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsth2" runat="server" Value='<%# Eval("FFYLFSH") %>' />
                <asp:Label ID="lbylfsth" runat="server" Text='<%# Bind("FFYLFSH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                 <asp:TemplateField HeaderText="FARM FRESH YOGHURT(LOW FAT SOUR) 500 GM BOX" SortExpression="ylfsh"><ItemTemplate>
                <asp:HiddenField ID="hdylfsh1" runat="server" Value='<%# Eval("FFYLFSRH","{0:n0}") %>' /><asp:HiddenField ID="hdylfsh2" runat="server" Value='<%# Eval("FFYLFSRH") %>' />
                <asp:Label ID="lbylfsh" runat="server" Text='<%# Bind("FFYLFSRH","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>

                      <asp:TemplateField HeaderText="BUTTER 200 GM" SortExpression="BT2"><ItemTemplate>
                <asp:HiddenField ID="hdbtq1" runat="server" Value='<%# Eval("BT2","{0:n0}") %>' /><asp:HiddenField ID="hdbtq2" runat="server" Value='<%# Eval("BT2") %>' />
                <asp:Label ID="lbbtq" runat="server" Text='<%# Bind("BT2","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                        <asp:TemplateField HeaderText="BUTTER KG" SortExpression="bto"><ItemTemplate>
                <asp:HiddenField ID="hdbto1" runat="server" Value='<%# Eval("BTO","{0:n0}") %>' /><asp:HiddenField ID="hdbto2" runat="server" Value='<%# Eval("BTO") %>' />
                <asp:Label ID="lbbto" runat="server" Text='<%# Bind("BTO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>


                             <asp:TemplateField HeaderText="GHEE KG" SortExpression="gheekg"><ItemTemplate>
                <asp:HiddenField ID="hdgheekg1" runat="server" Value='<%# Eval("GHO","{0:n0}") %>' /><asp:HiddenField ID="hdgheekg2" runat="server" Value='<%# Eval("GHO") %>' />
                <asp:Label ID="lbgheekg" runat="server" Text='<%# Bind("GHO","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>
           
           
                 <%--<asp:TemplateField HeaderText="Amount" SortExpression="itemname"><ItemTemplate>
                <asp:HiddenField ID="hdAmount1" runat="server" Value='<%# Eval("Amount","{0:n0}") %>' /><asp:HiddenField ID="hdAmount2" runat="server" Value='<%# Eval("Amount") %>' />
                <asp:Label ID="lbAmount" runat="server" Text='<%# Bind("Amount","{0:n0}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:TemplateField>
                     --%>
                      </Columns>
                 <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"  />
                          
                </asp:GridView>          
               
               
                         </td>
       </tr>
   </table>

    <%--=========================================End My Code From Here=================================================--%>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
