<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true"
    Inherits="UI.SAD.Item.ItemManager" Codebehind="ItemManager.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .divPopUpItem
        {
            position: absolute;
            width: 300px;
            z-index: 1;
            left: 0px;
            top: 170px;
            background-color: #f0f0ff;
            border: 3px outset #00367B;
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
        var dv = document.getElementById("divPopUp_");
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
        var dv = document.getElementById("divPopUp_");
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
        var dv = document.getElementById("divPopUp_");
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
        var dv = document.getElementById("divPopUp_");
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

</head>
<body>
    <form id="form1" runat="server">
    <div id="divPopUp_" class="divPopUpItem" style="display: none; z-index: 3;">
        <table width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    <input id="btnClosePopDiv" type="button" value="X" onclick="HideDiv()" />
                </td>
            </tr>
            <tr id="trText" style="height: 40px; vertical-align: bottom;">
                <td>
                    Text
                </td>
                <td>
                    <asp:TextBox ID="txtPopText" runat="server"></asp:TextBox>
                </td>
                <td>
                    COde:<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="trLabel">
                <td>
                    Label
                </td>
                <td>
                    <asp:TextBox ID="txtPopLabel" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr style="height: 40px; vertical-align: bottom;">
                <td>
                    &nbsp;
                </td>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnLevel" runat="server" Value="1" />
                                <asp:HiddenField ID="hdnSubLevel" runat="server" Value="1" />
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnParent" runat="server" />
                                <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                                Item Type
                                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strType"
                                    DataValueField="intID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveItemType"
                                    TypeName="SAD_BLL.Item.Item">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                UNIT&nbsp;
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
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            FOR&nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="ObjectDataSource3"
                                                DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="CheckBoxList1_DataBound"
                                                RepeatDirection="Horizontal">
                                            </asp:CheckBoxList>
                                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetSalesTypeByItemType"
                                                TypeName="SAD_BLL.Sales.SalesConfig">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                        Type="String" />
                                                    <asp:ControlParameter ControlID="ddlType" Name="itemTypeID" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-top: 70px;">
                                <asp:Panel ID="pnlMain" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Items" />
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px;">
                                Produc Name Automatically Selected By Code
                            </td>
                            <td style="padding-top: 10px;">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Price Can Set From Different Module
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                    ValidationGroup="valCom" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="padding-top: 30px;">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="AVAILABLE ITEMS "
                                    CaptionAlign="Top" DataKeyNames="intID" DataSourceID="ObjectDataSource2" SkinID="sknGrid1">
                                    <Columns>
                                        <%--<asp:BoundField DataField="intID" HeaderText="intID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="intID" />
                            <asp:BoundField DataField="intUnitID" HeaderText="intUnitID" 
                                SortExpression="intUnitID" />
                            <asp:BoundField DataField="intTypeID" HeaderText="intTypeID" 
                                SortExpression="intTypeID" />
                            <asp:BoundField DataField="intLevelOneID" HeaderText="intLevelOneID" 
                                SortExpression="intLevelOneID" />--%>
                                        <asp:BoundField DataField="strProductName" HeaderText="Product Name" SortExpression="strProductName" />
                                        <%--<asp:CheckBoxField DataField="ysnActive" HeaderText="ysnActive" 
                                SortExpression="ysnActive" />
                            <asp:BoundField DataField="intDetailsCount" HeaderText="intDetailsCount" 
                                SortExpression="intDetailsCount" />--%>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveItems"
                                    TypeName="SAD_BLL.Item.Item">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnL1" Name="levelOneId" PropertyName="Value" Type="String" />
                                        <asp:ControlParameter ControlID="hdnId" Name="idList" PropertyName="Value" Type="String" />
                                        <asp:ControlParameter ControlID="hdnSub" Name="subLevelList" PropertyName="Value"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:HiddenField ID="hdnL1" runat="server" />
                                <asp:HiddenField ID="hdnId" runat="server" />
                                <asp:HiddenField ID="hdnSub" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
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
