<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.SAD.SADCOA.CusManageForCOA" Codebehind="CusManageForCOA.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >

<html >
<head runat="server">
    <title>Untitled Page</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <script type="text/javascript">
    function HideDiv(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "none";
        
        //document.getElementById("hdnParent").value = '';
     }
     function ShowDiv(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "block";
        
        //document.getElementById("hdnParent").value = '';
     }
    </script>

    <style type="text/css">
        .divPopUpItem
        {
           position:absolute;
            width: 300px;
            height: 300px;
            z-index: 1;
            float:left;
            display:none;
            
            background-color: #f0f0ff;
            border: 3px outset #00367B;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    
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
        <td>Unit </td>
        <td>
        <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource3" 
            DataTextField="strUnit" DataValueField="intUnitID" 
            ondatabound="ddlUnit_DataBound" 
            onselectedindexchanged="ddlUnit_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
            SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
            <SelectParameters>
                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
      </td>
        </tr>
        <tr>
        <td>Customer Type </td>
       <td>
        <asp:DropDownList ID="ddlCusType" runat="server" 
            DataSourceID="ObjectDataSource1" DataTextField="strTypeName" 
            DataValueField="intTypeID" AutoPostBack="True" 
            onselectedindexchanged="ddlCusType_SelectedIndexChanged" 
            ondatabound="ddlCusType_DataBound">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetCustomerType" TypeName="SAD_BLL.Customer.CustomerType">
        </asp:ObjectDataSource>
       
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
    
    
    
    <div>
        
    </div>
    
 
    
    <a href="#" onclick="ShowDiv('AddClassification')">
    <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Account" />
    </a>
    
    <div>
        <asp:GridView ID="GridSub" SkinID="sknGrid1" runat="server" DataSourceID="ObjectDataSource2" 
            AutoGenerateColumns="False" DataKeyNames="intID">
            <Columns>
                <asp:TemplateField HeaderText="Type Name" SortExpression="strName">
                    <ItemTemplate>
                        <%# GetData("" + Eval("intID"),  "" + Eval("strName"))%>
                        
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Child Count" SortExpression="intChildCount">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("intChildCount") %>'></asp:Label>
                    </ItemTemplate>
                   
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Enble" SortExpression="ysnActive">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnActive") %>' 
                            Enabled="false" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            SelectMethod="GetCusManageCOAData" TypeName="SAD_BLL.Customer.CusManageForCOA">
            <SelectParameters>
                <asp:ControlParameter ControlID="hdnCusType" Name="cusType" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hdnParent" Name="parentID" 
                    PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="hdnUnit" Name="unitID" PropertyName="Value" 
                    Type="String" />
                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    
    <div id="AddClassification" class="divPopUpItem">
        <table width="100%" border="0" cellspacing="0">
            <tr>
                <td colspan="2" style="height: 50px; vertical-align: top;" align="right">
                            <input id="Button1" type="button" value="X" onclick="HideDiv('AddClassification')" />
                        </td>
            </tr>
              <tr>
                <td colspan="2">&nbsp</td>
            </tr>
            <tr>
                <td> Name</td>
                <td> 
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
              <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="add" runat="server" Text="ADD" onclick="add_Click" /></td>
            </tr>
        </table>
    </div>
    
    <asp:HiddenField ID="hdnParent" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnCusType" runat="server" />
    </form>
</body>
</html>
