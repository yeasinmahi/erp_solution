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
    <style>
        .tblborder {
            border: 1px solid black;
            border-collapse: collapse;
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
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
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
                                    <asp:TextBox ID="dtCha" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                                    <script type="text/javascript"> new datepickr('dtCha', { 'dateFormat': 'Y-m-d' });</script>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="lbleffective" CssClass="lbl" runat="server" Text="VDate : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="dtVdate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                                    <script type="text/javascript"> new datepickr('dtVdate', { 'dateFormat': 'Y-m-d' });</script>
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

                    <table style="width: 100%; background-color: white;">
                        <tr>
                            <td colspan="6" style="font-size: 24px; font-weight: bold; text-align: center;">চালান ফরম</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="heading" style="font-size: 16px; font-weight: bold">টি, আর ফরম নং ৬ (এস,আর ৩৭ দ্রষ্টব্য)</td>
                            <td class="copy">১ম(মূল)কপি</td>
                            <td class="copy">২য় কপি</td>
                            <td class="copy">৩য় কপি</td>
                        </tr>
                        <%--<tr>
                            <td colspan="6" style="padding-bottom: 10px;"></td>
                        </tr>--%>
                        <tr>
                            <td style="text-align: right; width: 100px" >চালান  নং : </td>
                            <td>
                                <asp:Label ID="lblChallanNo" runat="server" Text="" Visible="true"></asp:Label></td>
                            <td style="text-align: right;">
                                তারিখ : <asp:Label ID="lblChallanDate" runat="server"></asp:Label>
                            </td>
                            <td colspan="3">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="padding-bottom: 10px;"></td>
                        </tr>
                        <tr>
                            <td colspan="6">বাংলাদেশ ব্যাংক/ সোনালী ব্যাংকের ....................ঢাকা..................জেলার.......................মহাখালী........................শাখায় টাকা জমা দেওয়ার চালান</td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 10px;"></td>
                        </tr>
                    </table>
                    <table style="width: 100%; background-color: white;" id="codeTable">
                        <tr>
                            <td style="width: 80px;">কোড নং</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">1</td>
                            <td style="width: 5px;"></td>
                            <td class="tblborder" style="text-align: center; width: 20px;">1</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">1</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">3</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">3</td>
                            <td style="width: 5px;"></td>
                            <td class="tblborder" style="text-align: center; width: 20px;">0</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">0</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">0</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">6</td>
                            <td style="width: 5px;"></td>
                            <td class="tblborder" style="text-align: center; width: 20px;">0</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">3</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">1</td>
                            <td class="tblborder" style="text-align: center; width: 20px;">1</td>
                            <td style="text-align: center;"></td>
                        </tr>
                        <tr>
                            <td colspan="18" style="height: 15px;"></td>
                        </tr>
                    </table>

                    <table class="tblborder" style="width: 100%; background-color: white;">

                        <tr style="text-align: center">
                            <td class="tblborder" colspan="4">জমা প্রদানকারী কর্তৃক পূরণ করিতে হইবে</td>
                            <td class="tblborder" colspan="2">টাকার অংক</td>
                            <td class="tblborder" rowspan="2">বিভাগের নাম এবং চালানের পৃষ্ঠাংকনকারী কর্মকর্তার নাম, পদবী ও দপ্তর।*</td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="tblborder">যাহার মারফত প্রদত্ত হইল তাহার নাম ও ঠিকানা।</td>
                            <td class="tblborder">যে ব্যক্তির/প্রতিষ্ঠানের পক্ষ হইতে টাকা প্রদত্ত হইল তাহার নাম, পদবী ও ঠিকানা।</td>
                            <td class="tblborder">কি বাবদ জমা দেওয়া হইল তাহার বিবরণ।</td>
                            <td class="tblborder">মুদ্রা ও নোটের বিবরণ/ ড্রাফট,পে-অর্ডার ও চেকের বিবরণ।</td>
                            <td class="tblborder">টাকা</td>
                            <td class="tblborder">পয়সা</td>
                        </tr>
                        <tr style="text-align: center; color: black;">
                            <td class="tblborder">
                                <asp:Label ID="lblDepositorName" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder">
                                <asp:Label ID="lblDepositorAdd" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder">
                                <asp:Label ID="lblvat" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder">
                                <asp:Label ID="lblcheque" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder">
                                <asp:Label ID="lblTaka" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder">
                                <asp:Label ID="lblPoisha" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder">
                                <asp:Label ID="lbl" runat="server" Text="Label" Visible="false"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="tblborder"></td>
                            <td class="tblborder"></td>
                            <td class="tblborder"></td>
                            <td class="tblborder" style="text-align: right;">মোট টাকা</td>
                            <td class="tblborder" style="font-weight: bold">
                                <asp:Label ID="lblTotalTaka" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder" style="font-weight: bold">
                                <asp:Label ID="lblTotalPoisha" runat="server" Visible="true"></asp:Label></td>
                            <td class="tblborder"></td>
                        </tr>
                        <tr style="height: 40px;">
                            <td style="border-left: 1px solid black; border-bottom: 1px solid black;">টাকা (কথায়)</td>
                            <td colspan="3" style="border-right: 1px solid black; border-bottom: 1px solid black;">
                                <asp:Label ID="lblMoney" runat="server" Visible="true"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: center; border-top: 1px solid black;"></td>
                        </tr>
                        <tr>
                            <td style="border-left: 1px solid black; border-bottom: 1px solid black;">টাকা পাওয়া গেল</td>
                            <td colspan="3" style="height: 40px; border-right: 1px solid black; border-bottom: 1px solid black;"></td>
                            <td colspan="3" style="text-align: center;">ম্যানেজার</td>
                        </tr>
                        <tr>
                            <td>তারিখ : </td>
                            <td colspan="3">
                                <asp:Label ID="lblDate" runat="server" Visible="true"></asp:Label></td>
                            <td colspan="3" style="text-align: center;">বাংলাদেশ ব্যাংক/ সোনালী ব্যাংক</td>
                        </tr>
                    </table>
                    <table style="background-color: white; width: 100%;">
                        <tr>
                            <td>নোট : ১। সংশ্লিষ্ট দপ্তরের সহিত যোগাযোগ করিয়া সঠিক কোড নম্বর জানিয়া লইবেন।</td>
                        </tr>
                        <tr>
                            <td style="padding-left: 40px;">২। * যে সকল ক্ষেত্রে কর্মকর্তা কর্তৃক পৃষ্ঠাংকন প্রয়োজন, সে সকল ক্ষেত্রে প্রযোজ্য হইবে। </td>
                        </tr>
                    </table>







                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
