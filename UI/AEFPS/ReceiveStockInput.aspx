<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveStockInput.aspx.cs" Inherits="UI.AEFPS.ReceiveStockInput" %>
 
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

    <script src="../../Content/JS/datepickr.min.js"></script>

    <script src="../../Content/JS/JSSettlement.js"></script>

    <link href="jquery-ui.css" rel="stylesheet" />

     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

 

    <script src="jquery.min.js"></script>

    <script src="jquery-ui.min.js"></script>

 

    <script language="javascript" type="text/javascript">

        function onlyNumbers(evt) {

            var e = event || evt; // for trans-browser compatibility

            var charCode = e.which || e.keyCode;



            if ((charCode > 57))

                return false;

            return true;

        }
</script>


    <script type="text/javascript">

        function funConfirmAll() {

            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

        }

</script>

 


 

     

 

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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />

       <asp:HiddenField ID="hdnDA" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnTFare" runat="server" />

        

       <div class="tabs_container">Receive Stock From<hr /></div>

        <table>

       <tr>

           

           <td style="text-align:left;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>

            <td style="text-align:left;">

            <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"  ></asp:DropDownList>                                                                                       

           </td>

        

        

         <td style="text-align:left;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>

   

        <td style="text-align:left;" colspan="3"><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="400px"   ></asp:TextBox>

        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"

        ServiceMethod="GetFPSItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"

        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"

        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">

        </cc1:AutoCompleteExtender></td>  

            

        </tr>

        <tr>

            <td style="text-align:left;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Mrr Rate"></asp:Label></td>

            <td style="text-align:left;">

            <asp:TextBox ID="txtMrrRate" CssClass="txtBox" Font-Bold="False" Text="0" runat="server"    ></asp:TextBox>                                                                                       

           </td>

            <td style="text-align:left;" ><asp:Label ID="lblMrrNo" runat="server" CssClass="lbl" Text="Sales Price"></asp:Label></td>

            <td style="text-align:left;">

            <asp:TextBox ID="txtSalesQty" CssClass="txtBox" Font-Bold="False" Text="0"  runat="server"   ></asp:TextBox> </td>                                                                                      

              <td style="text-align:left;" ><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Receive Qty"></asp:Label></td>

            <td style="text-align:left;">

            <asp:TextBox ID="txtReceQty" CssClass="txtBox" Font-Bold="False" Text="0" runat="server"   ></asp:TextBox></td>    

            

           

        </tr>

            <tr>

<td></td>

                 

                 <td  style="text-align:left; font-size:14px; font-weight:bold;">

                  <asp:RadioButton ID="raRack" runat="server" GroupName="group"  Text=" Rack" AutoPostBack="True" OnCheckedChanged="raRack_CheckedChanged"  />

        <asp:RadioButton ID="ragodwon" runat="server" GroupName="group" Text=" Godown" AutoPostBack="True" OnCheckedChanged="ragodwon_CheckedChanged"  />

      </td> 

        <td style="text-align:right;"  ><asp:Label ID="lblRack" runat="server" CssClass="lbl" Text=" Rack Name"></asp:Label></td>

            <td style="text-align:left;"><asp:DropDownList ID="ddlRack" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px"  ></asp:DropDownList>   </td> 
            <td style="text-align:right;" colspan="2"> <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="funConfirmAll()" OnClick="btnSubmit_Click" /></td>

            </tr>
            <tr> 
                  <td style="text-align:right;"  ><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Naration"></asp:Label></td>
                  <td ><asp:TextBox ID="txtNaration" runat="server"  CssClass="txtBox"  PlaceHolder="Naration"></asp:TextBox></td>
                  <td style="text-align:right;"  ><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="TransferId"></asp:Label></td>
                  <td colspan="3"><asp:TextBox ID="txtTransferID" runat="server"  CssClass="txtBox"></asp:TextBox></td>
            </tr>

 

         <tr><td colspan="6"> 

            <asp:GridView ID="dgvReceive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  

            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDeleting="dgvGridView_RowDeleting">

            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>

            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

            

            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="itemid"><ItemTemplate>            

            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>

            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

                

               

            <asp:TemplateField HeaderText="Product Name" SortExpression="item"><ItemTemplate>            

            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>

            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

 

             <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="uom" >

            <ItemTemplate><asp:Label ID="lblUoM" runat="server"  Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>

                 <ItemStyle HorizontalAlign="Right" />

             </asp:TemplateField> 

                         

            <asp:TemplateField HeaderText="WHid" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="whid" >

            <ItemTemplate><asp:Label ID="lblWHID" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("whid") %>'  ></asp:Label></ItemTemplate>

                <ItemStyle HorizontalAlign="Right" />

            </asp:TemplateField>

             <asp:TemplateField HeaderText="Rack" ItemStyle-HorizontalAlign="right" SortExpression="rackName" >

            <ItemTemplate><asp:Label ID="lblRack" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("rackName") %>'></asp:Label></ItemTemplate>

                 <ItemStyle HorizontalAlign="Right" />

            </asp:TemplateField>

                

            <asp:TemplateField HeaderText="WH" ItemStyle-HorizontalAlign="right" SortExpression="whname" >

            <ItemTemplate><asp:Label ID="lblWhName" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("whname") %>'></asp:Label></ItemTemplate>

                <ItemStyle HorizontalAlign="Right" />

            </asp:TemplateField>

            <asp:TemplateField HeaderText="MrrRate" ItemStyle-HorizontalAlign="right" SortExpression="mrrRate" >

            <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("mrrRate") %>'></asp:Label></ItemTemplate>

                <ItemStyle HorizontalAlign="Right" />

            </asp:TemplateField>

 

            <asp:TemplateField HeaderText="SalesPrice" ItemStyle-HorizontalAlign="right" SortExpression="salesPrice" >

            <ItemTemplate><asp:Label ID="lblSalesId" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("salesPrice") %>'></asp:Label></ItemTemplate>

                <ItemStyle HorizontalAlign="Right" />

            </asp:TemplateField>  

 

             <asp:TemplateField HeaderText="ReceiveQty" ItemStyle-HorizontalAlign="right" SortExpression="receiveQty" >

            <ItemTemplate><asp:Label ID="txtQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("receiveQty"))) %>'></asp:Label></ItemTemplate>

                 <ItemStyle HorizontalAlign="Right" />

             </asp:TemplateField>

                

           <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />

 

            </Columns>

                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />

                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td>

        </tr> 

            </table>

 

        </div>

 

 

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>

    </asp:UpdatePanel>

    </form>

</body>

</html>
