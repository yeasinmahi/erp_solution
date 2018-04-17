<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true"
    Inherits="UI.SAD.Customer.CustomerInfoEdit" Codebehind="CustomerInfoEdit.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <style type="text/css">
        .divPopUpItem
        {
            position: absolute;
            width: 150px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
                <table>
                    <tr>
                        <td colspan="2" style="padding-top: 20px;">
                            ADD / Edit Customer
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top: 20px;">
                           <%-- <asp:Panel ID="pnlMain" runat="server">
                            </asp:Panel>--%>
                        </td>                        
                    </tr>
                    <tr>
                        <td style="padding-top:30px;">
                            Name
                        </td>
                        <td style="padding-top:30px;">
                            <asp:TextBox ID="txtCusName" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Propitor
                        </td>
                        <td>
                            <asp:TextBox ID="txtCusPropitor" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtCusAddress" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone
                        </td>
                        <td>
                            <asp:TextBox ID="txtCusPhone" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Credit Limit
                        </td>
                        <td>
                            <asp:TextBox ID="txtCRLimit" Text="0" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>      
                    <tr>
                        <td>
                            Is Periodicle <asp:CheckBox ID="chkPeriod" runat="server"  AutoPostBack="true"
                                oncheckedchanged="chkPeriod_CheckedChanged" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtDay" Text="0" runat="server" Width="300px" Enabled="false"></asp:TextBox>
                        </td>
                        </tr>
                    
                         <tr>
                        <td>
                            Email Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                        </td>
                   
                    </tr> 
                      <tr>
                        <td>
                            VAT Registration No.
                        </td>
                        <td>
                            <asp:TextBox ID="txtVATRegstration" runat="server" Width="300px"></asp:TextBox>
                        </td>
                   
                    </tr>                    
                     <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnCusSave" runat="server" Text="Save" OnClick="btnCusSave_Click" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnL1" runat="server" />
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnSub" runat="server" />                
                <asp:HiddenField ID="hdnLevel" runat="server" Value="1" />
                <asp:HiddenField ID="hdnSubLevel" runat="server" Value="1" />
                <asp:HiddenField ID="hdnMode" runat="server" />
                <asp:HiddenField ID="hdnParent" runat="server" />
                <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                
                <asp:HiddenField ID="hdnGeoId" runat="server" />
                <asp:HiddenField ID="hdnUnitId" runat="server" />            
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
        ValidationGroup="valCom"></asp:CustomValidator>
    <asp:CustomValidator ID="cvtComPop" runat="server" ClientValidationFunction="ValidateCompletePop"
        ValidationGroup="valComPop"></asp:CustomValidator>
    </form>
</body>
</html>
