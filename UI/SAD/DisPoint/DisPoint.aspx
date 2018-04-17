<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1" Inherits="UI.SAD.DisPoint.DisPoint" Codebehind="DisPoint.aspx.cs" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css"/> 
    <style type="text/css">
        .divPopUpGeoCss
        {
            position: absolute;
            width: 400px;
            z-index: 5;
            left: 50px;
            top: 170px;
            background-color: #f0f0ff;
            border: 3px outset #00367B;
            display: none;
        }
    </style>
    <script type="text/javascript">

        var type;

        function SetValue(level, subLevel) {
            var dv = document.getElementById("hdnLevel");
            dv.value = level;

            dv = document.getElementById("hdnSubLevel");
            dv.value = subLevel;

            dv = document.getElementById("txtPopLabel");
            dv.value = "";

            dv = document.getElementById("txtPopText");
            dv.value = "";

            Parent(level, subLevel);
        }
        function ShowDiv(level, subLevel) {
            type = 1; //SB
            var dv = document.getElementById("divPopUpGeo");
            dv.style.display = "block";

            dv = document.getElementById("trLabel");
            dv.style.display = "block";

            dv = document.getElementById("trText");
            dv.style.display = "block";

            dv = document.getElementById("btnPopSubmit");
            dv.value = "Add Sub";

            dv = document.getElementById("hdnMode");
            dv.value = "sub";

            SetValue(level, subLevel);
        }
        function ShowDivWithoutLabel(level, subLevel) {
            type = 2; //AD   
            var dv = document.getElementById("divPopUpGeo");
            dv.style.display = "block";

            dv = document.getElementById("trLabel");
            dv.style.display = "none";

            dv = document.getElementById("trText");
            dv.style.display = "block";

            dv = document.getElementById("btnPopSubmit");
            dv.value = "Add New";

            dv = document.getElementById("hdnMode");
            dv.value = "new";

            SetValue(level, subLevel);
            return;
        }
        function ShowDivWithoutText(level, subLevel) {
            type = 3; //LB
            var dv = document.getElementById("divPopUpGeo");
            dv.style.display = "block";

            dv = document.getElementById("trText");
            dv.style.display = "none";

            dv = document.getElementById("trLabel");
            dv.style.display = "block";

            dv = document.getElementById("btnPopSubmit");
            dv.value = "Modify";

            dv = document.getElementById("hdnMode");
            dv.value = "mod";

            SetValue(level, subLevel);
        }

        function HideDiv() {
            var dv = document.getElementById("divPopUpGeo");
            dv.style.display = "none";

            dv = document.getElementById("txtPopText");
            dv.value = "";

            dv = document.getElementById("txtPopLabel");
            dv.value = "";

            SetValue(0, 0);
        }

        function Unit(val) {
            var dv = document.getElementById("trUnit");
            dv.style.display = val;
        }

        function Parent(level, subLevel) {
            if (level != 0 && level != 1) {
                document.getElementById("hdnParent").value = document.getElementById("ddl" + (level - 1) + "_1").options.value;
            }
            else if (level == 1) {
                document.getElementById("hdnParent").value = "";
            }
        }

        function DDLChange(ddlID) {
            document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;
        }
    </script>
    <script type="text/javascript">
        function ValidateCompletePop(sender, args) {
            //SB || LB
            if (type == 1 || type == 3) {
                if (document.getElementById("txtPopLabel").value == '') {
                    alert('Label not be blank');
                    args.IsValid = false;
                    isProceed = false;
                }
            }
            //SB || AD
            if (type == 1 || type == 2) {
                if (document.getElementById("txtPopText").value == '') {
                    alert('Test not be blank');
                    args.IsValid = false;
                    isProceed = false;
                }
                else if (document.getElementById("txtCode").value == '') {
                    alert('Code not be blank');
                    args.IsValid = false;
                    isProceed = false;
                }
            }
        }
        function ValidateComplete(sender, args) {
            if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
    <script type="text/javascript">
        function ShowDivCus(id) {
            var dv = document.getElementById(id);
            dv.style.display = "block";

            //document.getElementById("hdnParent").value = '';
        }
        function HideDivCus(id) {
            var dv = document.getElementById(id);
            dv.style.display = "none";

            //document.getElementById("hdnParent").value = '';
        }
        function ShowPopUp(url) {
            url = url + '&unt=' + document.getElementById("ddlUnit").value + '&type=' + document.getElementById("ddlCusType").value + '&so=' + document.getElementById("ddlSo").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=500,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
       <CompositeScript>
           <Scripts>
               <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
           </Scripts>
       </CompositeScript>

        
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 220px; float: right;">
                    <table>
                        <tr>
                            <td style="width: 120px;">
                                Unit
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="ods1"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td rowspan="5">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sales Office
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" OnDataBound="ddlSo_DataBound"
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOffice" TypeName="SAD_BLL.Global.SalesOffice"
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Type
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                    OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                                    TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px" OnTextChanged="txtCus_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoActive" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="true" Selected="True">Active</asp:ListItem>
                                    <asp:ListItem Value="false">Inactive</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <a href="#" onclick="ShowPopUp('DisPointEdit.aspx?')">
                                    <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Distribution Point" />
                                </a>
                            </td>
                            <td align="left">
                                <asp:Button ID="Button1" runat="server" Text="Reload" OnClick="Button1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table style="background: #E0E0E0">
                                    <tr>
                                        <td rowspan="2" style="background-color: #A0A0A0">
                                            Search
                                        </td>
                                        <td>
                                            ID:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                                        </td>
                                        <td rowspan="2" style="background-color: #A0A0A0">
                                            <asp:Button ID="btnSearchID" runat="server" Text="Search" OnClick="btnSearchID_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Name:
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnDisPoint" runat="server" />
                                            <asp:TextBox ID="txtDis" runat="server" AutoCompleteType="Search" Width="350px"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtDis"
                                                ServiceMethod="GetDisPointList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 230px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" SkinID="sknGrid1" Caption="Distribution Point List" runat="server"
                            AutoGenerateColumns="False" DataKeyNames="intDisPointId" DataSourceID="ObjectDataSource1"
                            AllowPaging="True" AllowSorting="True" PageSize="30">
                            <Columns>
                                <asp:BoundField DataField="intDisPointId" HeaderText="ID" SortExpression="intDisPointId"
                                    ReadOnly="True" />
                                <asp:BoundField DataField="strName" HeaderText="Point Name" SortExpression="strName" />
                                <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="strAddress" />
                                <asp:BoundField DataField="strContactPerson" HeaderText="Contact Person" SortExpression="strContactPerson" />
                                <asp:BoundField DataField="strContactNo" HeaderText="Contact No" SortExpression="strContactNo" />
                                <asp:BoundField DataField="strLogisticVariable" HeaderText="Logistic Variable" SortExpression="strLogisticVariable" />
                                <asp:BoundField DataField="strPriceVariable" HeaderText="Price Variable" SortExpression="strPriceVariable" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#" onclick="ShowPopUp('SetPriceVar.aspx?id=<%# Eval("intDisPointId") %>&var=<%# Eval("intPriceCatagory") %>')"
                                            class="link">Price Var</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#" onclick="ShowPopUp('SetLogisVar.aspx?id=<%# Eval("intDisPointId") %>&var=<%# Eval("intLogisticCatagory") %>')"
                                            class="link">Logis Var</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#" onclick="ShowPopUp('DisPointEdit.aspx?id=<%# Eval("intDisPointId") %>')"
                                            class="link">Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
                            TypeName="SAD_BLL.DisPoint.DisPointInfo" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="hdnCustomer" Name="customerId" PropertyName="Value"
                                    Type="String" />
                                <asp:ControlParameter ControlID="rdoActive" Name="isEnable" PropertyName="SelectedValue"
                                    Type="Boolean" />
                                <asp:ControlParameter ControlID="hdnDisPoint" Name="disPointId" PropertyName="Value"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
        ValidationGroup="valCom"></asp:CustomValidator>
    <asp:CustomValidator ID="cvtComPop" runat="server" ClientValidationFunction="ValidateCompletePop"
        ValidationGroup="valComPop"></asp:CustomValidator>
      
    </form>
</body>
</html>
