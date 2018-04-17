<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Sales.Report.DOPrint" Codebehind="DOPrint.aspx.cs" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/Print.css" rel="stylesheet" type="text/css" />
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
    function IsGatePass(){        
        var dv = document.getElementById("gatepass").style.display;        
        if(dv == "block" || dv == "") document.getElementById("gatepass").style.display = "none";
        else document.getElementById("gatepass").style.display = "block";
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    
    <table id="btn" align="center" width="700px" style="background-color:#E0E0E0;">
        <tr>
            <td align="right" style="width:50%">
                <a href="#" onclick="Print()"><b>Print</b></a>
            </td>
            <td align="left" style="color: Blue; font-weight: bold; padding-left:20px;">
                <input id="Checkbox2" type="checkbox" onclick="IsGatePass()" checked="checked" />
                Need GatePass
            </td>
        </tr>
    </table>    
    <div id="print">        
        <table style="width:700px; text-align:left;" align="center">
            <tr>
                <td rowspan="4" align="left">
                <asp:Image ID="imgLogo" runat="server"/>
                </td>
                <td colspan="3"  style="text-align:center; font-size:17px; font-weight:bold;">
                    DELIVERY CHALLAN</td>
                <td rowspan="4" align="right">                
                    <asp:Image ID="imgCode" runat="server" Height="57px" Width="150px" />                
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:center; font-size:13px;">
                    <asp:Label ID="lblUnitName" runat="server" ></asp:Label>
                </td>
            </tr>           
            <tr>
                <td colspan="3" style="text-align:center; font-size:11px;">
                    <asp:Label ID="lblUnitAddr" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="height:30px;">
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td style="width:120px; font-size:12px; font-weight:bold;">
                                                                                Challan No</td>
                <td colspan="2" style="width:300px; font-size:12px; font-weight:bold;">
                    <asp:Label ID="lblChlNo" runat="server" ></asp:Label>
                </td>               
                <td style="width:100px;">
                                        Date</td>
                <td style="width:180px;">
                    <asp:Label ID="lblDate" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="font-size:10px; background-color:#E0E0E0;">
                <td>
                                        Customer</td>
                <td colspan="2">
                    <asp:Label ID="lblCusName" runat="server" ></asp:Label>
                </td>
                
                <td>
                                        Delivery Time</td>
                <td>
                    <asp:Label ID="lblTime" runat="server" ></asp:Label></td>
            </tr>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td>
                                        Address</td>
                <td colspan="2">
                    <asp:Label ID="lblCusAddr" runat="server" ></asp:Label>
                </td>
                
                <td>
                                        Vehicle No</td>
                <td>
                    <asp:Label ID="lblVehicle" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="font-size:10px; background-color:#E0E0E0;">
                <td>
                                        Propitor</td>
                <td colspan="2">
                    <asp:Label ID="lblCusBuyer" runat="server" ></asp:Label>
                </td>                
                <td>
                                        Driver</td>
                <td>
                    <asp:Label ID="lblDriver" runat="server" ></asp:Label></td>
            </tr>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td>
                                        Contact No</td>
                <td colspan="2">
                    <asp:Label ID="lblCusPhone" runat="server"></asp:Label>
                </td>
                <td>
                                        Contact No</td>
                <td>
                    <asp:Label ID="lblDriverPhone" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Narration:</td>
                <td colspan="4"><asp:Label ID="lblNarration" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Panel ID="Panel1" runat="server">
                    <%# sb.ToString() %>
                    <%# sbP.ToString() %>
                    <%# sbGT.ToString()%>
                    <%# sbT.ToString() %>
                    </asp:Panel>
                </td>                
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table style="width:700px; text-align:left;" align="center">
            <tr>
                <td align="left" style=" padding-top:50px; font-size:11px; width:12%">
                    Manager</td>
                <td align="center" style=" padding-top:50px; font-size:11px; width:12%">
                    Officer</td>                
                <td align="center" style=" padding-top:50px; font-size:11px; width:12%">
                    Supervisor</td>                
                <td align="center" style="padding-top:50px; font-size:11px; width:22%">
                    Driver's Signature</td>                
                <td align="right"style=" padding-top:50px; font-size:11px; width:42%">
                    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>
            </tr>
        </table>    
    </div>
    <div id="gatepass" style="page-break-before:always;">
        <table style="width: 700px; text-align: left;" align="center">
            <tr>
                <td rowspan="4" align="left">
                    <asp:Image ID="imgLogo1" runat="server" />
                </td>
                <td colspan="3" style="text-align: center; font-size: 17px; font-weight: bold;">
                    GATE PASS
                </td>
                <td rowspan="4" align="right">
                    <asp:Image ID="imgCode1" runat="server" Height="57px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-size: 13px;">
                    <asp:Label ID="lblUnitName1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-size: 11px;">
                    <asp:Label ID="lblUnitAddr1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="height: 30px;">
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr style="font-size: 10px; background-color: #F0F0FF;">
                <td style="width: 120px; font-size: 12px; font-weight: bold;">
                    Challan No
                </td>
                <td colspan="2" style="width: 300px; font-size: 12px; font-weight: bold;">
                    <asp:Label ID="lblChlNo1" runat="server"></asp:Label>
                </td>
                <td style="width: 100px;">
                    Date
                </td>
                <td style="width: 180px;">
                    <asp:Label ID="lblDate1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 10px; background-color: #E0E0E0;">
                <td>
                    Customer
                </td>
                <td colspan="2">
                    <asp:Label ID="lblCusName1" runat="server"></asp:Label>
                </td>
                <td>
                    Delivery Time
                </td>
                <td>
                    <asp:Label ID="lblTime1" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 10px; background-color: #F0F0FF;">
                <td>
                    Address
                </td>
                <td colspan="2">
                    <asp:Label ID="lblCusAddr1" runat="server"></asp:Label>
                </td>
                <td>
                    Vehicle No
                </td>
                <td>
                    <asp:Label ID="lblVehicle1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 10px; background-color: #E0E0E0;">
                <td>
                    Propitor
                </td>
                <td colspan="2">
                    <asp:Label ID="lblCusBuyer1" runat="server"></asp:Label>
                </td>
                <td>
                    Driver
                </td>
                <td>
                    <asp:Label ID="lblDriver1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: 10px; background-color: #F0F0FF;">
                <td>
                    Contact No
                </td>
                <td colspan="2">
                    <asp:Label ID="lblCusPhone1" runat="server"></asp:Label>
                </td>
                <td>
                    Contact No
                </td>
                <td>
                    <asp:Label ID="lblDriverPhone1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Narration:</td>
                <td colspan="4"><asp:Label ID="lblNarration1" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Panel ID="Panel11" runat="server">
                        <%# sb.ToString() %>
                        <%# sbP.ToString() %>
                        <%# sbGT.ToString()%>
                        <%# sbT.ToString() %>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <table style="width: 700px; text-align: left;" align="center">
            <tr>
                <td align="left" style=" padding-top:50px; font-size:11px; width:12%">
                    Manager</td>
                <td align="center" style=" padding-top:50px; font-size:11px; width:12%">
                    Officer</td>                
                <td align="center" style=" padding-top:50px; font-size:11px; width:12%">
                    Supervisor</td>                
                <td align="center" style="padding-top:50px; font-size:11px; width:22%">
                    Driver's Signature</td>                
                <td align="right"style=" padding-top:50px; font-size:11px; width:42%">
                    Receiver's Signature With Seal & Date &nbsp;&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
