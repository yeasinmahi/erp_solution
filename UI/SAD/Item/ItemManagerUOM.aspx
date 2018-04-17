<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true"
    Inherits="UI.SAD.Item.ItemManagerUOM" Codebehind="ItemManagerUOM.aspx.cs" %>

<!DOCTYPE html >
<html >
<head runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
     function DDLChange(ddlID, lblID)
     {
        var ddl = document.getElementById(ddlID);
        for(var i=0;i<ddl.options.length; i++){
            if(ddl.options[i].value == ddl.options.value){                
            if(document.getElementById("pnlBOM"))document.getElementById(lblID).innerText = ddl.options[i].innerText;                
            if(ddl.id == "ddlSell")document.getElementById("lblUOM").innerText = "Add unit " + ddl.options[i].innerText + " for UOM";
            }
        }
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 500px;">
        <tr>
            <td>
                Item Catagory :
                <asp:DropDownList ID="ddlCatagory" runat="server" DataSourceID="ObjectDataSource1"
                    DataTextField="strCatagoryName" DataValueField="intID" OnDataBound="ddlCatagory_DataBound"
                    OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetItemCatagory"
                    TypeName="WebERP_BLL_DAL.BLL.Item.ItemManager"></asp:ObjectDataSource>
            </td>
        </tr> 
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSellingUOM" runat="server">
                    <asp:Label ID="lblSellUOM" runat="server" Text="Label"></asp:Label>
                    &nbsp;:
                    <asp:DropDownList ID="ddlSell" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Text"
                        DataValueField="Value" ondatabound="ddlSell_DataBound">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllUnitOfMeasurementForSelling"
                        TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement"></asp:ObjectDataSource>
                        
                    <br /><br />
                    <asp:Label ID="lblUOM" runat="server" Text="Label"></asp:Label>
                </asp:Panel>
            </td>
        </tr>        
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td><asp:RadioButtonList ID="rdoUOM" runat="server" OnSelectedIndexChanged="rdoUOM_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="True" DataSourceID="ObjectDataSource3"
                    DataTextField="Text" DataValueField="Value" OnDataBound="rdoUOM_DataBound">
                </asp:RadioButtonList>
                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetAllUnitOfMeasurement"
                    TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSize" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Width
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource5"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetSizeInfo"
                                    TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Height
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="ObjectDataSource5"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Thickness
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="ObjectDataSource5"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlWeight" runat="server">
                    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList4" runat="server" 
                        DataSourceID="ObjectDataSource6" DataTextField="Text" DataValueField="Value">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
                        SelectMethod="GetWeightInfo" TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement">
                    </asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlVolume" runat="server">
                    <asp:TextBox ID="txtVolume" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList5" runat="server" 
                        DataSourceID="ObjectDataSource7" DataTextField="Text" DataValueField="Value">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" 
                        SelectMethod="GetVolumeInfo" TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement">
                    </asp:ObjectDataSource>
                </asp:Panel>
            </td>
        </tr>                  
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Panel ID="pnlBOM" runat="server">
                    Bill Of Material In:
                    <asp:DropDownList ID="ddlBOM" runat="server" DataSourceID="ObjectDataSource4" DataTextField="Text"
                        DataValueField="Value" ondatabound="ddlBOM_DataBound">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetAllUnitOfMeasurementForBOM"
                        TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="rdoUOM" Name="selectedUOM" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br /><br />
                    Per Selling <asp:Label ID="lblSell" runat="server" Text="Label"></asp:Label> = <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> <asp:Label ID="lblBOM" runat="server" Text="Label"></asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>        
        <tr>
            <td>
            <asp:Panel ID="pnlRawOther" runat="server">
            <table>
            <tr>
            <td>Lead Time</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            <td>
                 Day
                </td>
            </tr>            
            <tr>
            <td>EOQ</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            <td>                
                </td>
            </tr>
            <tr>
            <td>Safety Stock</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:DropDownList ID="DropDownList6" runat="server" 
                    DataSourceID="ObjectDataSource8" DataTextField="Text" DataValueField="Value">
                </asp:DropDownList>
                </td>
            </tr>
            </table>
            </asp:Panel>
            </td>
        </tr>  
        <tr>
            <td style="height: 10px;">
            </td>
        </tr>        
        <tr>
            <td>
            <asp:Panel ID="pnlFG" runat="server">
            <table>
            <tr>
            <td>Safety Stock</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            <td>
                <asp:DropDownList ID="DropDownList8" runat="server" 
                    DataSourceID="ObjectDataSource8" DataTextField="Text" DataValueField="Value">
                </asp:DropDownList>
                </td>
            </tr>
            </table>
            </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" 
        SelectMethod="GetSafetyStockInfo" TypeName="WebERP_BLL_DAL.BLL.Item.UnitOfMesurement">
    </asp:ObjectDataSource>
    </form>
</body>
</html>
