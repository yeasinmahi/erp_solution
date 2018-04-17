<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.SAD.Customer.CustomerInfo2" Codebehind="CustomerInfo2.aspx.cs" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <style type="text/css">
        .divPopUpGeoCss
        {
            position: absolute;
            width:400px;
            z-index: 5;
            left: 50px;
            top: 170px;
            background-color: #f0f0ff;
            border: 3px outset #00367B;
            display:none;
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
        
        dv = document.getElementById("txtPopText");
        dv.value = "";
        
        dv = document.getElementById("txtPopLabel");
        dv.value = "";
        
        SetValue(0,0);                            
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
     
     function DDLChange(ddlID)
     {     
        document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;        
     }
    </script>

    <script type="text/javascript">
    function ValidateCompletePop(sender, args){
        //SB || LB
        if(type==1 || type==3){
            if(document.getElementById("txtPopLabel").value == ''){
                alert('Label not be blank');
                args.IsValid = false;
                isProceed = false;
            }
        }
        //SB || AD
        if(type==1 || type==2){
            if(document.getElementById("txtPopText").value == ''){
                alert('Test not be blank');
                args.IsValid = false;
                isProceed = false;
            }
            else if(document.getElementById("txtCode").value == ''){
                alert('Code not be blank');
                args.IsValid = false;
                isProceed = false;
            }
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
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table>                        
                        <tr>
                            <td style="width: 120px;">
                                Unit
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="ods1"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td rowspan="3">
                                <%--<asp:Panel ID="pnlMain" runat="server">
                                </asp:Panel>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sales Office
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" 
                                    ondatabound="ddlSo_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOffice"
                                    TypeName="SAD_BLL.Global.SalesOffice" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                            PropertyName="SelectedValue" Type="String" />
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
                                    DataTextField="strTypeName" DataValueField="intTypeID" 
                                    ondatabound="ddlCusType_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDO2"
                                    TypeName="SAD_BLL.Customer.CustomerType" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSo" Name="soId" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>                        
                        <tr>
                            <td align="left" style="padding-top: 20px;">
                                <a href="#" onclick="ShowPopUp('CustomerInfoEdit.aspx?')">
                                    <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Customer" />
                                </a>
                            </td>
                            <td align="left" style="padding-top: 20px;">
                                <asp:Button ID="Button1" runat="server" Text="Reload" onclick="Button1_Click" />
                            </td>
                        </tr>
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
            <div style="height: 150px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" SkinID="sknGrid1" Caption="Customer List" runat="server"
                            AutoGenerateColumns="False" DataKeyNames="intCusID" DataSourceID="ObjectDataSource1">
                            <Columns>
                                <asp:TemplateField HeaderText="Customer ID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# GetEncodedDigit(Eval("intCusID")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                <asp:BoundField DataField="strName" HeaderText="Customer Name" 
                                    SortExpression="strName" />
                                <asp:BoundField DataField="strPropitor" HeaderText="Propitor Name" 
                                    SortExpression="strPropitor" />
                                <asp:BoundField DataField="strAddress" HeaderText="Address" 
                                    SortExpression="strAddress" />
                                <asp:BoundField DataField="strPhone" HeaderText="Contact No" 
                                    SortExpression="strPhone" />
                                <asp:BoundField DataField="monCreditLimit" HeaderText="Credit Limit" 
                                    SortExpression="monCreditLimit" />
                                 <asp:BoundField DataField="ysnPeriodicleCrLim" HeaderText="Is Periodicle" 
                                    SortExpression="ysnPeriodicleCrLim" />
                                <asp:BoundField DataField="intDaysOfCrLim" HeaderText="Days Limit" 
                                    SortExpression="intDaysOfCrLim" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#" onclick="ShowPopUp('SetPriceVar.aspx?id=<%# Eval("intCusID") %>&var=<%# Eval("intPriceCatagory") %>')"
                                                class="link">Price Var</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#" onclick="ShowPopUp('SetLogisVar.aspx?id=<%# Eval("intCusID") %>&var=<%# Eval("intLogisticCatagory") %>')"
                                                class="link">Logis Var</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="#" onclick="ShowPopUp('CustomerInfoEdit.aspx?id=<%# Eval("intCusID") %>')"
                                                class="link">Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCustomerInfo"
                            TypeName="SAD_BLL.Customer.CustomerInfo" 
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="hdnGeoId" Name="geoID" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="ddlCusType" Name="typeID" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlSo" Name="salesOffId" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
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
