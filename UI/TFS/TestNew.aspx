<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestNew.aspx.cs" Inherits="UI.TFS.TestNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Product List Bellow Ok

        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                 <asp:TemplateField HeaderText="OK1 BOSS1">
                    <ItemTemplate>
                        <asp:Button ID="btnOK1" runat="server" Text="OK1" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OK BOSS">
                    <ItemTemplate>
                        <asp:Button ID="btnOK" runat="server" Text="OK" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="OK Save">
                    <ItemTemplate>
                        <asp:Button ID="btnOKss" runat="server" Text="Save" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
