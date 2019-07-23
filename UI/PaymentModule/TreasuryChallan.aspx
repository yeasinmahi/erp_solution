<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreasuryChallan.aspx.cs" Inherits="UI.PaymentModule.TreasuryChallan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Treasury Challan :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
        function Print() {
            document.getElementById("insertForm").style.display = "none";
            document.getElementById("head").style.display = "none";
            document.getElementById("msg").style.display = "none";
            window.print();
        }
        function ShowChallan() {
            document.getElementById("btnPrint").style.display = "block";
        }
        function Save() {
            var challanNo = document.getElementById("txtChallan").value;
            var chequeNo = document.getElementById("txtCheque").value;
            var unit = document.getElementById("ddlUnit").value;
            var challan = document.getElementById("ddlChallan").value;
            if (unit == null || unit == "") {
                alert("Please Insert Unit");
                return false;
            }
            else if (challan == null || challan == "") {
                alert("Please Insert Challan List");
                return false;
            }

            else if (challanNo == null || challanNo == "") {
                alert("Please Insert Challan No");
                return false;
            }
            else if (chequeNo == null || chequeNo == "") {
                alert("Please Insert Cheque No");
                return false;
            }
            return true;
        }

        function ShowAdvice() {
            var unit = document.getElementById("ddlUnit").value;
            var challan = document.getElementById("ddlChallan").value;
            if (unit == null || unit == "") {
                alert("Please Insert Unit");
                return false;
            }
            else if (challan == null || challan == "") {
                alert("Please Insert Challan List");
                return false;
            }
            return true;
        }



    </script>
    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url);
                return false;
            }
            return true;
        }
    </script>
    <style>
        @page {
            size: landscape;
            margin: 2cm;
            Border: none;
            
        }
         .tblborder {
             border: 1px solid black;
             border-collapse: collapse;
         }
        .tblborder td{
            padding: 5px;
        }

        .heading {
            width: 70%;
            /*height: 25px;*/
            text-align: center;
            padding-left: 320px;
        }

        .copy {
            border: 1px solid black;
            border-collapse: collapse;
            /*height: 25px;*/
            text-align: center;
            width: 85px;
        }

        .ddlwidth {
            width: 400px;
        }

        #codeTable {
            font-weight: bold
        }
        .auto-style1 {
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="frmaclmanatt" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <div class="tabs_container" id="head">Treasury challan Information :<hr />
                    </div>

                    <%-- =======Data Insert Table======= --%>
                    <div id="insertForm">
                        <table border="0" style="width: Auto">
                            <tr class="tblrowodd">
                                <td style="text-align: right;">
                                    <asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Bank Name : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                <td style="text-align: right;">
                                    <asp:Label ID="lbljobtype" CssClass="lbl" runat="server" Text="District : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDistrict" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" class="nextclick" Style="font-size: 12px; cursor: pointer;"
                                        Text="Show Challan" OnClientClick="ShowAdvice()" OnClick="btnShow_Click" /></td>
                                <td>
                                    <asp:Button ID="btnPrint" runat="server" class="nextclick" Style="font-size: 12px; cursor: pointer;"
                                        Text="Print Challan" OnClientClick="Print()" /></td>

                            </tr>
                            <tr class="tblroweven">
                                <td style="text-align: right;">
                                    <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Branch Name : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtBranch" runat="server" CssClass="txtBox"></asp:TextBox></td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Challan : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtChallan" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnShowAdvice" runat="server" class="nextclick" Style="font-size: 12px; cursor: pointer;"
                                        Text="Show Advice" OnClientClick="ShowAdvice()" OnClick="btnShowAdvice_Click" /></td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" class="nextclick" Style="font-size: 12px; cursor: pointer;"
                                        Text="Save Challan" OnClientClick="Save()" OnClick="btnSave_Click" /></td>
                            </tr>

                            <tr class="tblrowodd">
                                <td style="text-align: right;">
                                    <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Challan Date : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="dtCha" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="dtCha"></cc1:CalendarExtender>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="lbleffective" CssClass="lbl" runat="server" Text="VDate : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="dtVdate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="dtVdate"></cc1:CalendarExtender>
                                </td>
                            </tr>

                            <tr class="tblroweven">
                                <td style="text-align: right;">
                                    <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Cheque : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtCheque" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
                                <td><%--<asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="false" CssClass="dropdownList" 
                    DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit"
                    OldValuesParameterFormatString="original_{0}"><SelectParameters>
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String"/>
                    </SelectParameters></asp:ObjectDataSource>--%>
                                    <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsUnit" DataTextField="strVatAccountName" DataValueField="intVatAccountID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsUnit" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitByUserId" TypeName="HR_DAL.Payment.TreasuryChallanTDSTableAdapters.sprGetVATAccountByAccountsUserTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="intUser" SessionField="sesUserId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>


                        </table>
                        <table>
                            <tr class="tblrowodd">

                                <td style="text-align: right;">
                                    <asp:Label ID="lbldayoff" CssClass="lbl" runat="server" Text="Challan List : "></asp:Label></td>
                                <td><%--<asp:DropDownList ID="ddlChallan" runat="server" AutoPostBack="false" CssClass="dropdownList"
                    DataSourceID="ODSDays" DataTextField="strDayName" DataValueField="intDayOffId"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSDays" runat="server" SelectMethod="GetAllDays" TypeName="HR_BLL.Global.DaysOfWeek">
                    </asp:ObjectDataSource>--%>
                                    <asp:DropDownList ID="ddlChallan" runat="server" CssClass="dropdownList ddlwidth" AutoPostBack="True" DataSourceID="odsChallan" DataTextField="strTreasury" DataValueField="intAutoID"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsChallan" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetChallanDataByVatAcountId" TypeName="HR_DAL.Payment.TreasuryChallanTDSTableAdapters.TblChallanListTableAdapter">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="intVatAccountID" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--=========================== Form for print ========================--%>
                    
                  


                </div>
                <div>
                    <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
