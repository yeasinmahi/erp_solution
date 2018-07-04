<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBudgetVSRevenue.aspx.cs" Inherits="UI.Revenue.frmBudgetVSRevenue" %>
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
     <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var txtCreditqty = document.forms["frmCreditnote"]["txtCreditqty"].value;
            var txtWithoutSDVAT = document.forms["frmCreditnote"]["txtWithoutSDVAT"].value;
          
            var txtSD = document.forms["frmCreditnote"]["txtSD"].value;
            var txtVat = document.forms["frmCreditnote"]["txtVAT"].value;
            var txtSurcharge = document.forms["frmCreditnote"]["txtSurcharge"].value;
           // var m11others = document.forms["frmCreditnote"]["lblM11Vat"].value;

            if (txtCreditqty == null || txtCreditqty == "") {
                alert("Please Fill-Up Qty !");
            }

            else if (txtWithoutSDVAT == null || txtWithoutSDVAT == "") {
                alert("Purchase Fill-up  Without SD VAT !");
            }
            else if (txtSD == null || txtSD == "") {
                alert("Please Fill-up  SD !");
            }

            else if (txtVat == null || txtVat == "") {
                alert("Please Fill-up VAT !");
            }

            else if (txtSurcharge == null || txtSurcharge == "") {
                alert("Please Fill-up Surcharge!");
            }
          
            
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
    <script type="text/javascript">
      $("[id*=lblsd]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {

              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var m11 = parseFloat($("[id*=lblM11]", row).val());
                  var surCharge = parseFloat($("[id*=lblSurCharge]", row).val());
                  var sd = parseFloat($(this).val());
                
                   $("[id*=lblDecrateOthervat]", row).html((m11- sd-surCharge));
              }
          } else {
              $(this).val('');
          }
        });
         $("[id*=lblSurCharge]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {

              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var sd = parseFloat($("[id*=lblsd]", row).val());
                  var m11 = parseFloat($("[id*=lblM11]", row).val());
                  var surCharge = parseFloat($(this).val());
              
                  $("[id*=lblDecrateOthervat]", row).html((m11- sd-surCharge));
              }
          } else {
              $(this).val('');
          }
        });
         $("[id*=lblvat]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {

              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var m11 = parseFloat($("[id*=lblM11]", row).val());              
                  var vat = parseFloat($(this).val());               
                   $("[id*=Decratevat]", row).html((m11- vat));
              }
          } else {
              $(this).val('');
          }
        });
   </script> 
    <style type="text/css">
        .auto-style2 {
            height: 17px;
        }
        .ddllist {}
        .auto-style3 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="frmCreditnote" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnCustid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnitemid" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> </div>

    <table>
     <tr><td style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
     <tr><td style="text-align:center; padding: 0px 0px 10px 0px;" class="auto-style3"><asp:Label ID="lblHeading" runat="server" Text="Revenue Budget VS Revenue" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr><tr><td>
     <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Main Head </td>
        <td><asp:DropDownList ID="ddlMainHead" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlMainHead_SelectedIndexChanged"></asp:DropDownList></td>
        <td>Company</td>
        <td></td>
        <td>&nbsp;</td>
        <td><asp:DropDownList ID="ddlyear" runat="server"></asp:DropDownList></td>
     </tr> 
     <tr><td class="auto-style2">2nd Head </td>
        <td class="auto-style2"><asp:DropDownList ID="ddl2ndHead" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddl2ndHead_SelectedIndexChanged"></asp:DropDownList></td>
        <td class="auto-style2">Line</td>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style2">
            &nbsp;</td>
        <td class="auto-style2">&nbsp;</td>
     </tr>
     <tr><td> 3rd Head</td>
            <td><asp:DropDownList ID="ddlregion" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlregion_SelectedIndexChanged" Height="16px"></asp:DropDownList> </td>
            <td>Region</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
    </tr>
         <tr><td> 4th Head</td>
            <td><asp:DropDownList ID="ddlArea" CssClass="ddllist" runat="server"  AutoPostBack="True"></asp:DropDownList> </td>
            <td>Area</td>
            <td>&nbsp;</td>
           
            <td>&nbsp;</td>
             <td><asp:Button ID="btnAdd" runat="server"  class="myButton" OnClick="btnAdd_Click1" Text="Show" /></td>
    </tr>
   
   
    </table>
        
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td style="text-align:right"></td>                                     
     <tr><td><hr /></td></tr> 
     <tr><td>
        <asp:GridView ID="dgvRpt"  runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="true">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Productid" Visible="false" SortExpression="Productid"><ItemTemplate>
        <asp:Label ID="lblProductid" runat="server"  Text='<%# Bind("pid") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
        </FooterTemplate></asp:TemplateField>
         
        <asp:TemplateField HeaderText="Product Code" SortExpression="itemid"><ItemTemplate>
        <asp:Label ID="lblstrProductNames" runat="server" Text='<%# Bind("pname") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

     
        <asp:TemplateField HeaderText="Jan Budget" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("jan","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lbljsQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("jans","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Feb" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblfebQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("feb","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrfebQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("febs","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="March" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblMarQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("Mar","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrMarQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("Mars","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      

        <asp:TemplateField HeaderText="April" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblAprilQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("april","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrAprilQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("aprils","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      

        <asp:TemplateField HeaderText="May" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblMayQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("may","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrMayQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("mays","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>


        <asp:TemplateField HeaderText="June" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblJuneQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("june","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrJuneQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("junes","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      

        <asp:TemplateField HeaderText="July" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblJulyQuantity"  runat="server" Width="75px" TextMode="Number" Text='<%# Bind("july","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
         <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrJulyQuantity"  runat="server" Width="75px" TextMode="Number" Text='<%# Bind("julys","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Aug" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblAugQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("aug","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrAugQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("augs","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        
        <asp:TemplateField HeaderText="Sep" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblSepQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("sep","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrSepQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("seps","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      

        <asp:TemplateField HeaderText="Oct" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblOctQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("oct","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrOctQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("octs","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Nov" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblNovQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("nov","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
         <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrNovQuantity"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("novs","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Dec" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblDecQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("dec","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
     
        <asp:TemplateField HeaderText="Revenue" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblrDecQuantity" runat="server" Width="60px" TextMode="Number" Text='<%# Bind("decs","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
     

        <asp:TemplateField HeaderText="Total" SortExpression="itemid"><ItemTemplate>
        <asp:Label ID="lblTotalqty" runat="server" Text='<%# Bind("total","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/><FooterTemplate><asp:Label ID="lblPending" runat="server"  /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Revenue" SortExpression="itemid"><ItemTemplate>
        <asp:Label ID="lblTotalqty" runat="server" Text='<%# Bind("totals","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="100px"/><FooterTemplate><asp:Label ID="lblPending" runat="server"  /></FooterTemplate></asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </td></tr>  
    </tr>             
    </table>
    </td></tr></table>
        
    </div>
<table>
          
        </table>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
