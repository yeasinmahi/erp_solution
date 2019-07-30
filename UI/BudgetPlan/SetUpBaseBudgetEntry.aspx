<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetUpBaseBudgetEntry.aspx.cs" Inherits="UI.BudgetPlan.SetUpBaseBudgetEntry" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <script src="../../../../Content/JS/datepickr.min.js"></script>
  <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
        <script>
            function sum() {
                 var txtJuly = parseFloat(document.getElementById('txtJuly').value);
             
            var txtAugest = parseFloat(document.getElementById('txtAugest').value);
            
            var txtSpetmeber = parseFloat(document.getElementById('txtSpetmeber').value);
             
            var txtOctober = parseFloat(document.getElementById('txtOctober').value);
             
            var txtNovember = parseFloat(document.getElementById('txtNovember').value);
             
            var txtDecember = parseFloat(document.getElementById('txtDecember').value);

            var txtjan =parseFloat (document.getElementById('txtjan').value);
          
            var txtFeb = parseFloat(document.getElementById('txtFeb').value);
             
            var txtMarch = parseFloat(document.getElementById('txtMarch').value);
            
           
            var txtApril = parseFloat(document.getElementById('txtApril').value);

           
            var txtMay = parseFloat(document.getElementById('txtMay').value);
             
            var txtJune = parseFloat(document.getElementById('txtJune').value);
             
           
            
                var tot = document.getElementById('txtTotal').value;
                var prate=document.getElementById('txtProductRate').value;

                var result =  parseFloat(txtJuly*prate) + parseFloat(txtAugest*prate)
                  + parseFloat(txtSpetmeber*prate) + parseFloat(txtOctober*prate) + parseFloat(txtNovember*prate)+ parseFloat(txtDecember * prate)
                  +  parseFloat(txtjan * prate) + parseFloat(txtFeb * prate) + parseFloat(txtMarch * prate) + parseFloat(txtApril * prate)
                    + parseFloat(txtMay * prate) + parseFloat(txtJune * prate)
                var result = result.toFixed(2);

                var qnt = parseFloat(txtJuly) + parseFloat(txtAugest) + parseFloat(txtSpetmeber) + parseFloat(txtOctober)+ parseFloat(txtNovember)
                  + parseFloat(txtDecember)+ parseFloat(txtjan) + parseFloat(txtFeb) + parseFloat(txtMarch) + parseFloat(txtApril)
                    + parseFloat(txtMay) + parseFloat(txtJune)
                var qnt = qnt.toFixed(2);


            //alert(result);

            if (!isNaN(result)) {
                document.getElementById('txtTotal').value = result;
                 document.getElementById('txtBudgetQnt').value = qnt;
            }


        }
    </script>

      <script>
            function sumPromotion() {
                 var txtJulyPromo = parseFloat(document.getElementById('txtJulyPromo').value);
             
            var txtAugestPromo = parseFloat(document.getElementById('txtAugestPromo').value);
            
            var txtSpetmeberPromo = parseFloat(document.getElementById('txtSeptemberPromo').value);
             
            var txtOctoberPromo = parseFloat(document.getElementById('txtOctoberPromo').value);
             
            var txtNovemberPromo = parseFloat(document.getElementById('txtNovemberPromo').value);
             
            var txtDecemberPromo = parseFloat(document.getElementById('txtDecemberPromo').value);

            var txtJanuaryPromo =parseFloat (document.getElementById('txtJanuaryPromo').value);
          
            var txtFebPromo = parseFloat(document.getElementById('txtFebruaryPromo').value);
             
            var txtMarchPromo = parseFloat(document.getElementById('txtMarchPromo').value);
            
           
            var txtAprilPromo = parseFloat(document.getElementById('txtAprilPromo').value);

           
            var txtMayPromo = parseFloat(document.getElementById('txtMayPromo').value);
             
            var txtJunePromo = parseFloat(document.getElementById('txtJunePromo').value);
             
           
            
                var totPromo = document.getElementById('txtTotal').value;
                var prate=document.getElementById('txtProductRate').value;

                var result =  parseFloat(txtJulyPromo*prate) + parseFloat(txtAugestPromo*prate)
                  + parseFloat(txtSpetmeberPromo*prate) + parseFloat(txtOctoberPromo*prate) + parseFloat(txtNovemberPromo*prate)+ parseFloat(txtDecemberPromo * prate)
                  +  parseFloat(txtJanuaryPromo * prate) + parseFloat(txtFebPromo * prate) + parseFloat(txtMarchPromo * prate) + parseFloat(txtAprilPromo * prate)
                         + parseFloat(txtMayPromo*prate) + parseFloat(txtJunePromo*prate)

                var qnt = parseFloat(txtJulyPromo) + parseFloat(txtAugestPromo) + parseFloat(txtSpetmeberPromo) + parseFloat(txtOctoberPromo)+ parseFloat(txtNovemberPromo)
                  + parseFloat(txtDecemberPromo)+ parseFloat(txtJanuaryPromo) + parseFloat(txtFebPromo) + parseFloat(txtMarchPromo) + parseFloat(txtAprilPromo)
                         + parseFloat(txtMayPromo) + parseFloat(txtJunePromo) 


            //alert(result);

            if (!isNaN(result)) {
                document.getElementById('txtTotalamntPromo').value = result;
                 document.getElementById('txtQntPromo').value = qnt;
            }


        }
    </script>
    
    
    <script>
           function Confirm() {
               document.getElementById("hdnconfirm").value = "0";

               var txtProduct = document.getElementById("txtProduct").value;
                var txtJuly = document.getElementById("txtJuly").value;
            var txtAugest= document.getElementById("txtAugest").value;

            var txtjan = document.getElementById("txtjan").value;
            var txtFeb= document.getElementById("txtFeb").value;

               if (txtProduct == null || txtProduct == '') {
                   alert("Product can not be empty");
                   document.getElementById("txtProduct").focus();
               }
                else if (txtJuly == null || txtJuly == '') {
                   alert("July qnt can not be empty");
                   document.getElementById("txtJuly").focus();
               }

                    else if (txtAugest == null || txtAugest == '') {
                   alert("Augest qnt can not be empty");
                   document.getElementById("txtAugest").focus();
               }




               else if (txtjan == null || txtjan == '') {
                   alert("January qnt can not be empty");
                   document.getElementById("txtjan").focus();
               }
               else if (txtFeb == null || txtFeb == '') {
                   alert("February qnt can not be empty");
                   document.getElementById("txtFeb").focus();
               }

             


               else {

                   var confirm_value = document.createElement("INPUT");
                   confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                   if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                   else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
               }
          }
      
    </script>

    <script type="text/css">
          #content
{
    position: absolute;
    top: 110px;
    left: 350px;
    width: 765px;
    height: 605px;
}

#content label
{
    display:inline;
    float:left;
    margin-right:4px;
    vertical-align:top;
}
      </script>

    <script type="text/javascript">
        function Validation() {
            var txtProduct = document.getElementById("txtProduct").value;
              var txtJuly = document.getElementById("txtJuly").value;
            var txtAugest= document.getElementById("txtAugest").value;

            var txtjan = document.getElementById("txtjan").value;
            var txtFeb= document.getElementById("txtFeb").value;

            if (txtProduct == null || txtProduct == '') {
                alert("Product can not be empty");
                return false;
            }

             if (txtJuly == null || txtJuly == '') {
                   alert("July qnt can not be empty");
                   document.getElementById("txtJuly").focus();
               }

                     if (txtAugest == null || txtAugest == '') {
                   alert("Augest qnt can not be empty");
                   document.getElementById("txtAugest").focus();
               }

            if (txtjan == null || txtjan == '') {
                alert("January qnt can not be empty");
                return false;
            }
              if (txtFeb == null || txtFeb == '') {
                alert("February qnt can not be empty");
                return false;
            }


            return true;
        }
    </script>


</head>
<body>
    <form id="frmshvssls" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
             <div class="tabs_container">Budget Entry (Operational Set up Basis)<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/> <asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
        <hr /></div>
        
        <div>
        <table>
            <tr>
                  <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "> </asp:Label>
                   

                         
                         <td>
                 <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            
            </td>
                  <td><asp:Label ID="lblcustype" runat="server" CssClass="lbl" Text="Budget Type"></asp:Label> </td>
                    <td> <asp:DropDownList ID="ddlBudgetType" runat="server" AutoPostBack="True" DataSourceID="odsBudgetType" DataTextField="strBudgetType" DataValueField="intBudgetTypeID" OnSelectedIndexChanged="ddlBudgetType_SelectedIndexChanged" > </asp:DropDownList> 
                        <asp:ObjectDataSource ID="odsBudgetType" runat="server" SelectMethod="GetBudgetType" TypeName="Budget_BLL.Budget.Budget_Entry_BLL"></asp:ObjectDataSource>
                      </td>


            </tr>
        
            <tr class="tblrowodd">
                  <td>
                     <asp:Label ID="lblRowItem" runat="server" CssClass="lbl" Text="Row Item"></asp:Label>
                 </td>
         
                  <td> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
                                <asp:HiddenField ID="hdnProduct" runat="server" />
                        
                                <asp:HiddenField ID="hdnProductText" runat="server" />
                                <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"
                                    AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>

                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                    ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
               <%--       <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
            ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>--%>
                            </td>  

                 <td><asp:Label ID="lblSalesOffice" runat="server" CssClass="lbl" Text="Sales Office"></asp:Label> </td>
                    <td> <asp:DropDownList ID="ddlSlaesOffice" runat="server" AutoPostBack="True" DataSourceID="odsSalesOffice" DataTextField="strName" DataValueField="intSalesOffId"> </asp:DropDownList> 
                        <asp:ObjectDataSource ID="odsSalesOffice" runat="server" SelectMethod="GetSalesOffice" TypeName="SAD_BLL.Global.SalesOffice">
                            <SelectParameters>
                                <asp:SessionParameter Name="userId" SessionField="sesUserId" Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                  </td>

            </tr>
            <tr>
                 <td><asp:Label ID="lblRegion" runat="server" CssClass="lbl" Text="Region"></asp:Label> </td>
                    <td> <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="True" DataSourceID="odsRegionidd" DataTextField="strText" DataValueField="intID"> </asp:DropDownList> 
                       
                        <asp:ObjectDataSource ID="odsRegionidd" runat="server" SelectMethod="GetRegion" TypeName="SAD_BLL.Sales.SalesConfig">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitd" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                       
                 </td>
                <%--DataSourceID="odsGetArea" DataTextField="strText" DataValueField="intID"--%>
                 <td><asp:Label ID="lblArea" runat="server" CssClass="lbl" Text="Area"></asp:Label> </td>
                    <td> <asp:DropDownList ID="drdlArea" runat="server" AutoPostBack="True" DataSourceID="odsarea" DataTextField="strText" DataValueField="intID"> </asp:DropDownList> 
                        
                     
                        
                        <asp:ObjectDataSource ID="odsarea" runat="server" SelectMethod="GetArea" TypeName="SAD_BLL.Sales.SalesConfig">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitd" PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="ddlRegion" Name="regionid" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                     
                        
                 </td>
            </tr>
            <tr>
                 <td><asp:Label ID="lblProductLine" runat="server" CssClass="lbl" Text="Product Line"></asp:Label> </td>
                    <td> <asp:DropDownList ID="drdlPrdouctLine" runat="server" AutoPostBack="True" DataSourceID="odsPrdLine" DataTextField="strFGGroup" DataValueField="intFGGroupid"> </asp:DropDownList> 
                        <asp:ObjectDataSource ID="odsPrdLine" runat="server" SelectMethod="GetPrdLine" TypeName="SAD_BLL.Sales.SalesConfig">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitd" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                 </td>
            <td style="text-align:right;"><asp:Label ID="lblCostCenter" runat="server" CssClass="lbl" Text="Cost Center :"></asp:Label></td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlCostCenter" CssClass="ddList" AutoPostBack="True" Font-Bold="False" runat="server" DataSourceID="odscostcenterunit" DataTextField="strCCName" DataValueField="intCostCenterID"></asp:DropDownList>                                                                                       
              
                <asp:ObjectDataSource ID="odscostcenterunit" runat="server" SelectMethod="GetUnitvsCostecenter" TypeName="Budget_BLL.Budget.Budget_Entry_BLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
              
            </td>
            </tr>
            <tr>
            <td style="text-align:right;"><asp:Label ID="lblYear" runat="server" CssClass="lbl" Text="Year:"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlYear" CssClass="ddList" Font-Bold="False" Width="120px" runat="server" DataSourceID="odsGetYR" DataTextField="strYearList" DataValueField="intYear"></asp:DropDownList>                                                                       
                <asp:ObjectDataSource ID="odsGetYR" runat="server" SelectMethod="GetYearList" TypeName="Budget_BLL.Budget.Budget_Entry_BLL"></asp:ObjectDataSource>
            </td>

               <td style="text-align:right;"><asp:Label ID="lbProudctRate" runat="server" CssClass="lbl" Text="Product Rate:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtProductRate" runat="server"></asp:TextBox>
            </td>

            </tr>
            </div>
        <div id="content">
            <table>
                <tr>
                       <td><asp:Label ID="lblJuly" runat="server" CssClass="lbl" Text="July:"></asp:Label><br /> 
                           <asp:TextBox ID="txtJuly" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox></td>
                <td></td>
                <td><label> Augest<br /> <asp:TextBox ID="txtAugest" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox> </label></td>
               <td></td>

                <td> <label> September<br /> <asp:TextBox ID="txtSpetmeber" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><label> October<br /><asp:TextBox ID="txtOctober" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>
                <td> <label> November<br /> <asp:TextBox ID="txtNovember" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><label> December<br /> <asp:TextBox ID="txtDecember" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>

                <td> <label> January<br /> <asp:TextBox ID="txtjan" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><label> February<br /> <asp:TextBox ID="txtFeb" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"   CssClass="txtBox"></asp:TextBox> </label></td>
               <td></td>

                <td> <label> March<br /> <asp:TextBox ID="txtMarch" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><label> April<br /> <asp:TextBox ID="txtApril" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px"  onkeyup="sum();" CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>
                     <td> <label> May<br /> <asp:TextBox ID="txtMay" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><label> June<br /> <asp:TextBox ID="txtJune" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();" CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>
                

             
                <td><label> Qnt<br /> <asp:TextBox ID="txtBudgetQnt" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();" Enabled="false"  CssClass="txtBox"></asp:TextBox> </label></td>
                    
                    <td></td>
                <td><label> Amount<br /> <asp:TextBox ID="txtTotal" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sum();" Enabled="false"  CssClass="txtBox"></asp:TextBox> </label></td>
                      
                </tr>

                   <tr>
                       <td> <asp:Label ID="lblJulyProm" runat="server" CssClass="lbl" Text="July:"></asp:Label><br /> <asp:TextBox ID="txtJulyPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><asp:Label ID="lblAugprom" runat="server" CssClass="lbl" Text="Aug(Prom):"></asp:Label><br /> <asp:TextBox ID="txtAugestPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox> </label></td>
               <td></td>

                <td><asp:Label ID="lblSepprom" runat="server" CssClass="lbl" Text="Sep(Prom):"></asp:Label><br /> <asp:TextBox ID="txtSeptemberPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><asp:Label ID="lblOctprom" runat="server" CssClass="lbl" Text="Oct(Prom):"></asp:Label><br /><asp:TextBox ID="txtOctoberPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>
                <td> <asp:Label ID="lblNovprom" runat="server" CssClass="lbl" Text="Nov(Prom):"></asp:Label><br /> <asp:TextBox ID="txtNovemberPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><asp:Label ID="lblDecprom" runat="server" CssClass="lbl" Text="Dec(Prom):"></asp:Label><br /> <asp:TextBox ID="txtDecemberPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>

                <td> <asp:Label ID="lblJanuaryprom" runat="server" CssClass="lbl" Text="Jan(Prom):"></asp:Label><br /> <asp:TextBox ID="txtJanuaryPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><asp:Label ID="lblFebprom" runat="server" CssClass="lbl" Text="Feb(Prom):"></asp:Label><br /> <asp:TextBox ID="txtFebruaryPromo" runat="server" Font-Bold="true" ForeColor="#ff0000"  AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"   CssClass="txtBox"></asp:TextBox> </label></td>
               <td></td>

                <td><asp:Label ID="lblMarchprom" runat="server" CssClass="lbl" Text="March(Prom):"></asp:Label><br /> <asp:TextBox ID="txtMarchPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><asp:Label ID="lblAprilprom" runat="server" CssClass="lbl" Text="April(Prom):"></asp:Label><br /> <asp:TextBox ID="txtAprilPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px"  onkeyup="sumPromotion();" CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>
                     <td> <asp:Label ID="lblMayprom" runat="server" CssClass="lbl" Text="May(Prom):"></asp:Label><br /> <asp:TextBox ID="txtMayPromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();"  CssClass="txtBox"></asp:TextBox></label> </td>
                <td></td>
                <td><asp:Label ID="lblJuneprom" runat="server" CssClass="lbl" Text="June(Prom):"></asp:Label><br /> <asp:TextBox ID="txtJunePromo" runat="server" Font-Bold="true" ForeColor="#ff0000" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();" CssClass="txtBox"></asp:TextBox> </label></td>
                    <td></td>
                

             
                <td><asp:Label ID="lblPromQnt" runat="server" CssClass="lbl" Text="Qnt(Prom):"></asp:Label><br /> <asp:TextBox ID="txtQntPromo" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();" Enabled="false"  CssClass="txtBox"></asp:TextBox> </label></td>
                    
                    <td></td>
                <td><asp:Label ID="lblPromTotal" runat="server" CssClass="lbl" Text="Amount(Prom):"></asp:Label><br /> <asp:TextBox ID="txtTotalamntPromo" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" Width="65px" onkeyup="sumPromotion();" Enabled="false"  CssClass="txtBox"></asp:TextBox> </label></td>
                      
                </tr>


                    </table>
</div>
        <div>
  
                 
            <tr>
                  <td colspan="4">
                          <asp:Button ID="btnADD" runat="server" Text="Add" CssClass="button" OnClientClick = "Confirm()" OnClick="btnADD_Click"/>
                      <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClientClick = "Confirm()" OnClick="btnSubmit_Click" />
                  </td>
            </tr>
          


           </table>
             </div>

          <div>
              <table>
                  <tr>

                  

                          <asp:GridView ID="grdvSetupBaseBudget" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnRowDeleting="grdvSetupBaseBudget_RowDeleting" OnRowDataBound="grdvSetupBaseBudget_RowDataBound"  >
                        <Columns>
                               <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                                <asp:HiddenField ID="hdnitemid" runat="server" Value='<%# Eval("itemid") %>' />
                                <asp:HiddenField ID="hdnsalesofficeid" runat="server" Value='<%# Eval("salesofficeid") %>' />
                                <asp:HiddenField ID="hdnregionid" runat="server" Value='<%# Eval("regionid") %>' />
                                <asp:HiddenField ID="hdnareaid" runat="server" Value='<%# Eval("areaid") %>' />
                                <asp:HiddenField ID="hdnprdlineid" runat="server" Value='<%# Eval("prdlineid") %>' />
                                <asp:HiddenField ID="hdncostcneteid" runat="server" Value='<%# Eval("costcneteid") %>' />
                                <asp:HiddenField ID="hdnyrid" runat="server" Value='<%# Eval("yrid") %>' /></ItemTemplate></asp:TemplateField> 
                             <asp:BoundField DataField="prdname" HeaderText="ProductName" SortExpression="prdname" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            <asp:BoundField DataField="july" HeaderText="July" SortExpression="july" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="augest" HeaderText="Augest" SortExpression="augest" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="september" HeaderText="September" SortExpression="september" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="october" HeaderText="October" SortExpression="october" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="november" HeaderText="November" SortExpression="november" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="december" HeaderText="December" SortExpression="december" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="january" HeaderText="January" SortExpression="january" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="february" HeaderText="February" SortExpression="february" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="march" HeaderText="March" SortExpression="march" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="april" HeaderText="April"  SortExpression="april" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="may" HeaderText="May" SortExpression="may" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="june" HeaderText="June" SortExpression="june" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

                            <asp:BoundField DataField="totqnt" HeaderText="TotalQnt" SortExpression="totqnt" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="totAmount" HeaderText="TotalAmount" SortExpression="totAmount" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>

                              <asp:BoundField DataField="julyPromotion" HeaderText="JulyProm"  SortExpression="july" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="augestPromotion" HeaderText="AugestProm" SortExpression="augest" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="septemberPromotion" HeaderText="SeptemberProm" SortExpression="september" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="octoberPromotion" HeaderText="OctoberProm" SortExpression="october" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="novemberPromotion" HeaderText="NovemberProm" SortExpression="november" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="decemberPromotion" HeaderText="DecemberProm" SortExpression="december" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="januaryPromotion" HeaderText="JanuaryProm" SortExpression="january" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="februaryPromotion" HeaderText="FebruaryProm" SortExpression="february" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="marchPromotion" HeaderText="MarchProm" SortExpression="march" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="aprilPromotion" HeaderText="AprilProm"  SortExpression="april" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="mayPromotion" HeaderText="MayProm" SortExpression="may" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="junePromotion" HeaderText="JuneProm" SortExpression="june" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                           
                             <asp:BoundField DataField="totPromqnt" HeaderText="TotalPromQnt" SortExpression="totPromqnt" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="totPromAmnt" HeaderText="TotalPromAmount" SortExpression="totPromAmnt" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>




                          
                            <asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True"  />
                        



                        </Columns>




                    </asp:GridView>

                  </tr>
              </table>
          </div>
       
     
 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

