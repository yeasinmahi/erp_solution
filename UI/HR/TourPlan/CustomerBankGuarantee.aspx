<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBankGuarantee.aspx.cs" Inherits="UI.HR.TourPlan.CustomerBankGuarantee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script>
       
        function ConfirmforShow() {
            var fromdate = document.getElementById("txtFormDate").value;
            var todate = document.getElementById("txtToDate").value;
            var bgno = document.getElementById("TxtBGNo").value;
            var amount = document.getElementById("TxtAmount").value;

            if (fromdate == null || fromdate == "") {
                alert("Insert Issue Date");
                return false;
            }
            else if (todate == null || todate == "") {
                alert("Insert Expire Date");
                return false;
            }
            else if (bgno == null || bgno == "") {
                alert("Insert BG No");
                return false;
            }
            else if (amount == null || amount == "") {
                alert("Insert Amount");
                return false;
            }
            return true;
        }

        function Confirmforadd() { 

        }
    </script>
    <style>
        .divHeader{
            background-color: #9bb4dd;
             border: 0px solid #000;
            text-align: center;
            color: #fff;
            width: 700px;
            height: 25px;
         font-weight: bold;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                <div>
                    <div class="divHeader">Customer Bank Gaurantee</div>
                    <table style="width: 700px;  outline-color: blue;table-layout: auto; vertical-align: top; background-color: #DDD;" class="tblRowOdd">
                        <tr >
                            <td style="text-align:right;">
                                <asp:Label ID="Label1" runat="server" Text="Issue Date:" CssClass="lbl"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtFormDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Expire Date:"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                        </tr>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Unit:"></asp:Label></td>
                            <td><asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true"></asp:DropDownList>

                                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetData" TypeName="HR_DAL.Global.UnitTDSTableAdapters.SprGetUnitTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="intUserID" SessionField="sesUserID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                            </td>
                            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Sales Office:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlSalesOffice" runat="server" AutoPostback="True"  CssClass="dropdownList" DataSourceID="odsSalesOffice" DataTextField="strName" DataValueField="intId"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSalesOffice" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSalesOfficeByUnitId" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblSalesOfficeTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            
                        </tr>
                         <tr>
                             <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Customer Name:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlCustomerName" runat="server" autoPostback="True"  CssClass="dropdownList" DataSourceID="odsCustomerName" DataTextField="strname" DataValueField="intCusID"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsCustomerName" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerNameBySalesOfficeId" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblCustomerTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlSalesOffice" Name="intSalesId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Bank Name:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlBank" runat="server" autoPostback="True"  CssClass="dropdownList" DataSourceID="odsBankName" DataTextField="strBankName" DataValueField="intID"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsBankName" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBank" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblBankNameTableAdapter"></asp:ObjectDataSource>
                             </td>
                            
                        </tr>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Branch Name:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlBranch" runat="server" autoPostback="True"  CssClass="dropdownList" DataSourceID="odsBranchName" DataTextField="strBankBranchName" DataValueField="intBranchID"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsBranchName" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetBranchByBankID" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblBankBranchNameTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlBank" Name="intBankID" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                             </td>
                             <td style="text-align:right;"><asp:Label ID="Label10" CssClass="lbl" runat="server" Text="District Name:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlDistrict" runat="server" autoPostback="True"  CssClass="dropdownList" DataSourceID="odsDistrictName" DataTextField="strDistrict" DataValueField="intDistrictID"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsDistrictName" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDistrictByBranchID" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblDistrictTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlBranch" Name="intBranchID" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                             </td>
                        </tr>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="BG No:"></asp:Label></td>
                            <td><asp:TextBox ID="TxtBGNo" runat="server" CssClass="txtBox" Width="170px"  ></asp:TextBox></td>
                            <td style="text-align:right;"><asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Amount:"></asp:Label></td>
                            <td><asp:TextBox ID="TxtAmount" runat="server" CssClass="txtBox" Width="170px"  ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align:right;">
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" BackColor="#ffff99" OnClientClick = "ConfirmforShow()" Text="Show" CssClass="button" />
                                </td>
                        </tr>
                       
                    </table>
                    <table>
                         <tr>
                            <td>
                                <asp:GridView ID="GVCustDetails" runat="server" AutoGenerateColumns="False" DataKeyNames="intCusID" DataSourceID="odsgv">
                                    <Columns>
                                        <asp:BoundField DataField="strname" HeaderText="Customer Name" SortExpression="strname" />
                                        <asp:BoundField DataField="intCusID" HeaderText="Customer Id" InsertVisible="False" ReadOnly="True" SortExpression="intCusID" />
                                        <asp:BoundField DataField="Territroy" HeaderText="Territroy" SortExpression="Territroy" />
                                        <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                                        <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsgv" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerInfo" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblCustomerInfoTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="DdlCustomerName" Name="intCustId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>

                             <td>
                                 <asp:GridView ID="GVCustList" CssClass="form-control" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                            CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="GVCustList_RowDeleting">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        <asp:HiddenField ID="hdncustomerid" runat="server" Value='<%# Bind("custId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Id" SortExpression="title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcustId" runat="server" Text='<%# Bind("custId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Id" SortExpression="fname">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbankid" runat="server" Text='<%# Bind("bankId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Id" SortExpression="lname">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbranchid" runat="server" Text='<%# Bind("branchId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="District" SortExpression="districtId">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldistrictId" runat="server" Text='<%# Bind("districtId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BGNo" SortExpression="date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBGNo" runat="server" Text='<%# Bind("BGNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Issue Date" SortExpression="address">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfromdate" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Expire date" SortExpression="country">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltodate" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Amount" SortExpression="thana">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:TemplateField>                              
                               
                                <asp:TemplateField HeaderText="Insert By" SortExpression="postOffice">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInsertBy" runat="server" Text='<%# Bind("InsertBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                </asp:TemplateField>

                                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                             </td>
                            
                    
                      </tr>    
                      
                        <tr>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" BackColor="#ffff99" OnClientClick = "Confirmforadd()" Text="Add" CssClass="button" />
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" BackColor="#ffff99" Text="Submit" CssClass="button" />
                            </td> 
                        </tr>
                    </table>

                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
