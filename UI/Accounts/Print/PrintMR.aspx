<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Print.PrintMR" Codebehind="PrintMR.aspx.cs" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Print Money Receipt</title>

     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/printCSS" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <script type="text/javascript">        
    function Print(){        
        Show();
        window.print();
        self.close();
    }
    function Show(){
        var dv = document.getElementById("print");
        dv.style.display = "block";
        
        dv = document.getElementById("btn");
        dv.style.display = "none"; 
    }    
    </script>

    <style type="text/css">
        table.sample
        {
            border-width: 1px;
            border-spacing: 0px;
            border-style: solid;
            border-color: #CCCCCC;
        }
        table.sample th
        {
            border-width: 1px;
            border-style: solid;
            border-color: #CCCCCC;
        }
        table.sample td
        {
            border-width: 1px;
            border-style: solid;
            border-color: #CCCCCC;
        }
        .company
        {
            font-family: Verdana;
            font-size: 16px;
            font-weight: bold;
        }
        .address
        {
            font-family: Verdana;
            font-size: 11px;                        
        }        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="btn" style="text-align: center; width:750px; position:absolute; z-index:1; top:5px; left:20px;">
        <a href="#" onclick="Print()"><b>Print</b></a>
    </div>
    <div id="print" style="position:absolute; top:0px;">
        <div>
            <table style="height: 283px; width: 700px;">
                <tr>
                    <td rowspan="3" valign="top">                        
                        <asp:Image ID="imgLogo" runat="server"/>
                        <br />
                        <br />
                        &nbsp;&nbsp; &nbsp;<img src="Images/Acc.png" />
                    </td>
                    <td valign="top" style="height: 70px; text-align: center;">
                        <b>MONEY RECEIPT</b>
                        <br />
                        <br />
                        <asp:Label ID="lblCompany" CssClass="company" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblAddress" CssClass="address" runat="server"></asp:Label>
                    </td>
                    <td valign="top" style="height: 70px; text-align: right;">
                        <asp:Image ID="Image1" runat="server" Height="57px" Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td width="86%" valign="top" colspan="2">
                        <table width="100%" class="sample">
                            <tr style="height: 25px">
                                <td width="50px;" bgcolor="#CCCCCC">
                                    MR No.
                                </td>
                                <td style="width: 325px;">
                                    <asp:Label ID="lblMR" Font-Bold="true" runat="server"></asp:Label>
                                </td>
                                <td style="width: 50px;" bgcolor="#CCCCCC">
                                    Date
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblDD" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblMM" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="lblYY" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 40px; vertical-align:top;">
                                <td colspan="6" style="width:700px;">
                                    Receive With Thanks From:
                                    <asp:Label ID="lblReceiveFrom" Font-Bold="true" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblNarr" Font-Size="10px" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 30px; vertical-align:top;">
                                <td colspan="2">
                                    <asp:Label ID="lblPayThrough" runat="server"></asp:Label>
                                </td>
                                <td bgcolor="#CCCCCC">
                                    Amount
                                </td>
                                <td colspan="3" style="text-align: right; width:200px;">
                                    <asp:Label ID="lblAmount" Font-Bold="true" runat="server"></asp:Label>
                                </td>
                            </tr>                            
                            <tr style="height: 40px; vertical-align:top;">
                                <td colspan="6">
                                    Amount in Words :
                                    <asp:Label ID="lblInWords" Font-Bold="true" runat="server"></asp:Label>
                                </td>
                            </tr>                            
                        </table>
                    </td>                    
                </tr>
                <tr>
                    <td valign="bottom" colspan="2">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style=" padding-top:15px;">
                            <tr style=" height:40px; vertical-align:bottom; text-align:center;">
                                <td>
                                    _________
                                </td>
                                <td>                                    
                                    ___________                        
                                </td>
                                <td>
                                    _____________
                                </td>
                                <td>
                                    __________
                                </td>
                                <td>
                                    _____________
                                </td>
                                <td>
                                    ________
                                </td>
                            </tr>
                            <tr style="height: 25px;font-size:9px; vertical-align:top; text-align:center;">
                                <td>
                                    Prepared By</td>
                                <td>                                    
                                    Reviewed By</td>
                                <td>
                                    Authorised Signatory<br />Akij Group
                                </td>
                                <td>
                                    Authorised Signatory<br />Akij Group
                                </td>
                                <td>
                                    Authorised Signatory<br />Akij Group
                                </td>
                                <td>
                                    Payee
                                </td>
                            </tr>
                        </table>
                    </td>                    
                </tr>
                <tr><td style="height:30px;"> </td></tr>
                <tr>
                    <td rowspan="3" valign="top">
                        <asp:Image ID="imgLogo1" runat="server"/>
                        <br />
                        <br />
                        &nbsp;&nbsp; &nbsp;<img src="Images/Dep.png" />
                    </td>
                    <td valign="top" style="height: 70px; text-align: center;">
                        <b>MONEY RECEIPT</b>
                        <br />
                        <br />
                        <asp:Label ID="lblCompany1" CssClass="company" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblAddress1" CssClass="address" runat="server"></asp:Label>
                    </td>
                    <td valign="top" style="height: 70px; text-align: right;">
                        <asp:Image ID="Image2" runat="server" Height="57px" Width="196px" />
                    </td>
                </tr>                
                <tr>
                    <td width="86%" valign="top" colspan="2">
                        <table width="100%" class="sample">
                            <tr style="height: 25px">
                                <td width="50px;" bgcolor="#CCCCCC">
                                    MR No.
                                </td>
                                <td style="width: 325px;">
                                    <asp:Label ID="lblMR1" Font-Bold="true" runat="server"></asp:Label>
                                </td>
                                <td style="width: 50px;" bgcolor="#CCCCCC">
                                    Date
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblDD1" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label ID="lblMM1" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="lblYY1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 40px; vertical-align:top;">
                                <td colspan="6"  style="width:700px;">
                                    Receive With Thanks From:
                                    <asp:Label ID="lblReceiveFrom1" Font-Bold="true" runat="server"></asp:Label>
                                    <br />                                    
                                    <asp:Label ID="lblNarr1" Font-Size="10px" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 30px">
                                <td colspan="2">
                                    <asp:Label ID="lblPayThrough1" runat="server"></asp:Label>
                                </td>
                                <td bgcolor="#CCCCCC">
                                    Amount
                                </td>
                                <td colspan="3" style="text-align: right; width:200px;">
                                    <asp:Label ID="lblAmount1" Font-Bold="true" runat="server"></asp:Label>
                                </td>
                            </tr>                            
                            <tr style="height: 40px; vertical-align:top;">
                                <td colspan="6">
                                    Amount in Words :
                                    <asp:Label ID="lblInWords1" Font-Bold="true" runat="server"></asp:Label>
                                </td>
                            </tr>                            
                        </table>
                    </td>                    
                </tr>
                <tr>
                    <td valign="bottom" colspan="2">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="padding-top:15px;">
                            <tr style=" height:40px; vertical-align:bottom; text-align:center;">
                                <td>
                                    _________
                                </td>
                                <td>                                    
                                    ___________                        
                                </td>
                                <td>
                                    _____________
                                </td>
                                <td>
                                    __________
                                </td>
                                <td>
                                    _____________
                                </td>
                                <td>
                                    ________
                                </td>
                            </tr>
                            <tr style="height: 25px;font-size:9px; vertical-align:top; text-align:center;">
                                <td>
                                    Prepared By</td>
                                <td>                                    
                                    Reviewed By</td>
                                <td>
                                    Authorised Signatory<br />Akij Group
                                </td>
                                <td>
                                    Authorised Signatory<br />Akij Group
                                </td>
                                <td>
                                    Authorised Signatory<br />Akij Group
                                </td>
                                <td>
                                    Payee
                                </td>
                            </tr>
                        </table>
                    </td>                    
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>