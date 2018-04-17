<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetBarcodeGenearator.aspx.cs" Inherits="UI.Asset.AssetBarcodeGenearator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
      function Search_dgvservice(strKey, strGV) {

          var strData = strKey.value.toLowerCase().split(" ");
          var tblData = document.getElementById(strGV);
          var rowData;
          for (var i = 1; i < tblData.rows.length; i++) {
              rowData = tblData.rows[i].innerHTML;
              var styleDisplay = 'none';
              for (var j = 0; j < strData.length; j++) {
                  if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                      styleDisplay = '';
                  else {
                      styleDisplay = 'none';
                      break;
                  }
              }
              tblData.rows[i].style.display = styleDisplay;
          }

      }
        </script>

     <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
</script>
   
   <script>
       function Print() {
           $('#showdiv').hide();
        var dv = document.getElementById("divPIPrint");
        document.getElementById('divPIPrint').style.display = "block";
        dv.getElementsByID
        dv.style.display = "block";
        dv = document.getElementById("btnprint");
        dv.style.display = "none";
        window.print();
        self.close();
        $('#showdiv').show();
    }
    //function breakeveryheader() {
    //    var thestyle = "always";
    //    for (i = 1; i < document.getElementsByTagName("div").length; i++)
    //        document.getElementsByTagName("div")[i].style.pageBreakAfter = thestyle;
    //    document.getElementById("btnprint").style.display = "none";
    //}

    </script>
    

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        .auto-style3 {
            width: 166px;
        }
        </style>
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
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
      
               
   <%-- <div class="tabs_container" align="left"  >Asset QRCode Generator</div>--%>
      <div id="showdiv">        
         <div class="tabs_container" align="Center"  >Asset QRCode Generator</div>
           <table  class="tblrowodd"   >                
            <tr><td style="text-align:right;"><asp:Label ID="LblContryOrigin"  Font-Size="Small" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
            <td class="auto-style3"><asp:DropDownList ID="DdlBillUnit"  runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="DdlBillUnit_SelectedIndexChanged"></asp:DropDownList> </td> </tr>
             
               
            <tr><td style="text-align:left;"><asp:Label ID="Label2" CssClass="lbl"  Font-Size="Small" runat="server" Text="JobStation : "></asp:Label></td>
            <td><asp:DropDownList ID="DdlJobstation" runat="server"   CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="DdlJobstation_SelectedIndexChanged"></asp:DropDownList> </td> </tr>
               
            <tr> <td style="text-align:right;"><asp:Label ID="Label1"  Font-Size="Small" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
            <td class="auto-style3"><asp:DropDownList ID="ddlType"  runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >  </asp:DropDownList> </td> </tr>
                
            <tr><td style="text-align:right"> <asp:Button ID="BtnView" runat="server" Text="View" OnClick="BtnView_Click" /></td>
                     
            <td><asp:Button ID="btnBarcodeGenerator" runat="server" Text="Barcode Generate" OnClick="btnBarcodeGenerator_Click"   /> </td>  

            </tr>
                 
            </table>
      
      
        <table>
        <tr>  <td> <asp:GridView ID="dgvGridView" runat="server"  Font-Bold="False" AutoGenerateColumns="False">               
        <Columns>
        <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>
        <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox></HeaderTemplate>
                           
        <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="AssetID"><ItemTemplate>
        <asp:Label ID="strAssetCode" runat="server" Text='<%# Eval("strAssetID") %>'></asp:Label></ItemTemplate></asp:TemplateField>
         <asp:TemplateField HeaderText="AutoID" Visible="false"><ItemTemplate>
        <asp:Label ID="lblAutoID" runat="server" Text='<%# Eval("intID") %>'></asp:Label></ItemTemplate></asp:TemplateField>                  
        <asp:BoundField DataField="strNameOfAsset" HeaderText="NameOfAsset" SortExpression="strNameOfAsset"/>
        <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
        <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />

        <asp:BoundField DataField="strAssetTypeName" HeaderText="AssetClass" SortExpression="strAssetTypeName" />
        <asp:BoundField DataField="strCategoryName" HeaderText="AssetSubClass" Visible="true" SortExpression="strCategoryName" />
        <asp:BoundField DataField="strCategoryName" HeaderText="Department"  SortExpression="strCategoryName" /> 
          
            
        <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" /> </HeaderTemplate>
        <ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate></asp:TemplateField>
        </Columns> </asp:GridView> </td> </tr>  
        </table>   
        </div>    
       
       

        <div id="divPIPrint" class="HeaderSection" style="text-align:center; border-top-left-radius:0px; margin-top:10px;">        
        <table border="0"; style="width:600px"; >         
        
        <tr style="border:none;">
        <td style="width:5px;"><a id="btnprint" href="#" style="cursor:pointer" onclick="Print()">Print</a></td>            
             
       </tr>
            <%--<tr>
                <td> <asp:Label ID="lblTitle" runat="server" ></asp:Label></td>
            </tr>--%>
           
           
        <tr class="tblrowodd"  > 
      <td ><asp:PlaceHolder ID="Placeholder5" runat="server"></asp:PlaceHolder> </td>
         
            </tr>
        </table> 
            <table>
                <tr>
                    <td>

                    </td>
                </tr>
            </table>
            
         </div>

        
       
         

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
