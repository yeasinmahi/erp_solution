<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.SAD.Logistic.VehiclePriceVarChange" Codebehind="VehiclePriceVarChange.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
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
     
    function SetValue(level, subLevel){    
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
    function ShowDiv(level, subLevel){   
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
    function ShowDivWithoutLabel(level, subLevel){ 
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
    function ShowDivWithoutText(level, subLevel){    
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
    
     function HideDiv()
     {
        var dv = document.getElementById("divPopUpGeo");
        dv.style.display = "none";  
        
        /*dv = document.getElementById("txtPopText");
        dv.value = "";
        
        dv = document.getElementById("txtPopLabel");
        dv.value = "";
        
        SetValue(0,0); */                           
     }     
     
     function Unit(val)
     {
        var dv = document.getElementById("trUnit");
        dv.style.display = val;
     }
     
     function Parent(level, subLevel)
     {        
        if(level != 0 && level != 1){        
        document.getElementById("hdnParent").value = document.getElementById("ddl"+(level-1)+"_1").options.value;
        }
        else if(level == 1){        
        document.getElementById("hdnParent").value = "";
        }
     }

     function DDLChange(ddlID) {
    
         document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;
         //document.getElementById("lblError").innerHTML = ' ';  
     }
    </script>

    <script type="text/javascript">
    function ValidateCompletePop(sender, args){
    if(document.getElementById("txtPopText").value == ''){
            alert('Group name not be blank');
            args.IsValid = false;
            isProceed = false;
        }        
    }
    function ValidateComplete(sender, args){        
        if(!confirm('Do you want to continue?')){            
            args.IsValid = false;
            isProceed = false;
        }
    }
    </script>

    <script type="text/javascript">
    function ShowDivCus(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "block";
        
        //document.getElementById("hdnParent").value = '';
     }
     function HideDivCus(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "none";
        
        //document.getElementById("hdnParent").value = '';
     }
     function ShowPopUp(url){        
        newwindow = window.open(url,'sub','scrollbars=yes,toolbar=0,height=550,width=500,top=70,left=220');
        if (window.focus) {newwindow.focus()}
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="divPopUpGeo" class="divPopUpGeoCss">
        <table width="100%">
            <tr>                
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    <input id="btnClosePopDiv" type="button" value="X" onclick="HideDiv()" />
                </td>
            </tr>
            <tr id="trText" style="height: 40px; vertical-align: bottom;">
                <td>
                    Group Name
                </td>
                <td>
                    <asp:TextBox ID="txtPopText" runat="server"></asp:TextBox>
                </td>               
            </tr>            
            <tr style="height: 40px; vertical-align: bottom;">               
                <td>
                </td>
                <td align="right">
                    <asp:Button ID="btnPopSubmit" runat="server" Text="Button" OnClick="btnPopSubmit_Click"
                        ValidationGroup="valComPop" />
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 200px; float: right;">
                    <table>
                        <tr>
                            <td style="width: 120px;">
                                UNIT
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" 
                                    OnDataBound="ddlUnit_DataBound" 
                                    onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                 <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" onselectedindexchanged="rdoType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">Freight</asp:ListItem>
                                    <asp:ListItem>Gain</asp:ListItem>
                                    <asp:ListItem>Gain By Group</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                        <td>
                            Ship Point
                        </td>
                        <td>                            
                            <asp:DropDownList ID="ddlShip" runat="server" DataSourceID="ObjectDataSource4"
                                DataTextField="strName" DataValueField="intShipPointId">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint"
                                TypeName="SAD_BLL.Global.ShipPoint" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td></td>
                        </tr>
                        <tr>
                            <td>
                                Select
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoSelect" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoSelect_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True">All</asp:ListItem>
                                    <asp:ListItem>Vhl Type</asp:ListItem>
                                    <asp:ListItem>Reg. No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td></td>
                        </tr>
                        <asp:Panel ID="pnlType" Visible="false" runat="server">
                            <tr>
                                <td>
                                    Type
                                </td>
                                <td>
                                    <div style="height: 75px; width: 500px; overflow: auto">
                                        <asp:CheckBoxList ID="chkType" runat="server" DataSourceID="odsVhlType" DataTextField="strType"
                                            DataValueField="intTypeId">
                                        </asp:CheckBoxList>
                                    </div>
                                    <asp:ObjectDataSource ID="odsVhlType" runat="server" SelectMethod="GetVhlType" TypeName="LOGIS_BLL.Vehicle"
                                        OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td></td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlVhl" Visible="false" runat="server">
                            <tr>
                                <td>
                                    Vehicle
                                </td>
                                <td>
                                    <div style="height: 75px; width: 500px; overflow: auto">
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="ObjectDataSource1"
                                            DataTextField="strRegNo" DataValueField="intID">
                                        </asp:CheckBoxList>
                                    </div>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetVehicleList" TypeName="LOGIS_BLL.Vehicle">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td></td>
                            </tr>
                        </asp:Panel>                                                
                        <tr>
                            <td>
                                Product
                            </td>
                            <td>
                                 <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                    ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td></td>
                        </tr>                        
                        <asp:Panel ID="pnlGroup" Visible="false" runat="server">
                            <tr>
                                <td>
                                    Group
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGroup" runat="server" DataSourceID="ObjectDataSource2" 
                                        DataTextField="strName" DataValueField="intGroupId">
                                    </asp:DropDownList>
                                    <a href="#" onclick="ShowDivCus('divPopUpGeo')">
                                        <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Account" />
                                    </a>
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                        SelectMethod="GetGroupByUnit" TypeName="LOGIS_BLL.VehicleVarLogisGainGroup">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unit" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                </td>
                                <td></td>
                            </tr>
                        </asp:Panel>
                    </table>
                </div>
                <asp:HiddenField ID="hdnL1" runat="server" />
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnSub" runat="server" />
                <asp:HiddenField ID="hdnGeoId" runat="server" />
                <asp:HiddenField ID="hdnLevel" runat="server" Value="1" />
                <asp:HiddenField ID="hdnSubLevel" runat="server" Value="1" />
                <asp:HiddenField ID="hdnMode" runat="server" />
                <asp:HiddenField ID="hdnParent" runat="server" />
                <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
            </asp:Panel>
            <div style="height: 210px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table width="100%">
                <tr>
                    <td>
                        <asp:Panel ID="pnlMain" runat="server">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    Start
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                        ID="CalendarExtender1" runat="server" EnableViewState="true">
                                    </cc1:CalendarExtender>
                                    <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                        width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                                <td>
                                    End
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                                        ID="CalendarExtender2" runat="server" EnableViewState="true">
                                    </cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                        width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblUom" runat="server" Text="UOM"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUOM" runat="server" DataSourceID="odsUOM" DataTextField="strUOM"
                                        DataValueField="intID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsUOM" runat="server" SelectMethod="GetUOMList" TypeName="SAD_BLL.Item.ItemUnitOfMeasurement"
                                        OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    Currency
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ObjectDataSource3"
                                        DataTextField="strCurrency" DataValueField="intID">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCurrencyInfo"
                                        TypeName="SAD_BLL.Item.Currency"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td>
                                                Value</td>
                                            <td>
                                                <asp:TextBox ID="txtPrice" runat="server">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                3rd Party Value</td>
                                            <td>
                                                <asp:TextBox ID="txtPartyPrice" runat="server">0</asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Set Value" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
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
