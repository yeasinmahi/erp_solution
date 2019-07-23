<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.OfficialMovement.PublicMovement"
    EnableEventValidation="false" Codebehind="PublicMovement_.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Official Movement Application</title>
   
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAaczGkYJhz_uP1Xo03sWxYnBB7R1NXzZE&sensor=false&libraries=places&language=eng&types=establishment" type="text/javascript"></script>
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  
    
    <script type="text/javascript">
        function SearchAddressByGoogle() {
            var options = {
                componentRestrictions: { country: "bd" }
            };
            var input = document.getElementById('txtAddressDueToMovement');
            var autocomplete = new google.maps.places.Autocomplete(input, options);
        }
    </script>
    
    <script type='text/javascript'>
       
        function validateFormSpelling() {
            
            return true;
        }
    </script>
    <script type="text/javascript">
        function GotoNextFocus(ControlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode
            if (unicode == 13) {
                var control = document.getElementById(ControlName);
                if (control != null) {
                    control.focus();
                    window.event.returnValue = false
                }
            }
        }
        function KeySelected(source, eventArgs) {
            if (event.keyCode == '13') {
                var searchString = document.getElementById('txtSearchByName').value;
                var word = searchString.split(",");
                document.getElementById('hdfEmpCode').value = word[1];
            }
        }
        function CheckFromDateIsGreatterThanToDate() {

            var txtFromDate = new Date(document.getElementById('txtFromDate').value);
            var txtToDate = new Date(document.getElementById('txtToDate').value);

            if (txtFromDate > txtToDate) {
                alert('Sorry! from date cannot be gratter than to date');

                document.getElementById('txtFromDate').value = new Date().format("MM/dd/yyyy");
                document.getElementById('txtToDate').value = new Date().format("MM/dd/yyyy");
                return;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $("#txtSearchByName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "PublicMovement.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtSearchByName').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="TextboxWatermark.TextboxWatermark.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

            </Scripts>
        </CompositeScript>
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
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                            </td>
                            <td>
                                <b>Official Movement</b>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                <table>
                    <tr style="text-align: left">
                        <td style="width: 125px">
                            <asp:Label ID="Label6" runat="server" CssClass="label" Text="Search By Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchByName" runat="server" CssClass="name" AutoPostBack="true"
                                Width="200px" Height="20px"></asp:TextBox>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchByName"
                                WatermarkText="Type Employee Name Here" WatermarkCssClass="watermarked" />
                            <%--<telerik:RadAutoCompleteBox runat="server" ID="AutoCompleteBox" DropDownHeight="200px" DropDownWidth="200px" DataSourceID="odssearchapplicant" 
                                DataValueField="intEmployeeID" DataTextField="searchcomponent" TextSettings-SelectionMode="Single" LabelWidth="300px" Width="350px" Delimiter="," > 
                                </telerik:RadAutoCompleteBox >                            
                                <asp:ObjectDataSource ID="odssearchapplicant" runat="server" SelectMethod="SearchInformation" TypeName="HR_BLL.Global.AutoSearch_BLL" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" /></SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:Button ID="btnShowReport" runat="server" CssClass="button" OnClick="btnShowReport_Click"
                                    Text="Show" />--%>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 450px">
                            <fieldset>
                                <legend>Movement Information:</legend>
                                <asp:Panel ID="panMovementDetails" runat="server" ScrollBars="None" Width="100%"
                                    Height="300px">
                                    <div>
                                        <table>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label7" runat="server" Text="Select Country" CssClass="label"></asp:Label>
                                                </td>
                                                <td colspan="9">
                                                    <asp:DropDownList ID="ddlCountry" runat="server" Width="145px" DataTextField="Text"
                                                        DataValueField="Value" AutoPostBack="True" DataSourceID="ddlCountryObjectDataSource"
                                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr id="trDistrict" runat="server">
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label13" runat="server" CssClass="label" Text="Select District"></asp:Label>
                                                </td>
                                                <td colspan="9">
                                                    <asp:DropDownList ID="ddlDistrict" runat="server" DataTextField="Text" DataValueField="Value"
                                                        Width="145px" DataSourceID="ddlDistrictObjectDataSource">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDistrict"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label14" runat="server" CssClass="label" Text="Types of activities"></asp:Label>
                                                </td>
                                                <td colspan="9">
                                                    <asp:DropDownList ID="ddlTypesOfActivities" runat="server" DataTextField="Text" DataValueField="Value"
                                                        Width="145px" DataSourceID="ddlTypesOfMovementObjectDataSource">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTypesOfActivities"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label8" runat="server" Text="Description" CssClass="label" class="required"></asp:Label>
                                                </td>
                                                <td colspan="9" rowspan="2">
                                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="txt" Width="259px" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label9" runat="server" Text="Date from" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" Width="60px" autocomplete="off"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CE1" runat="server" CssClass="cal_Theme1" Format="MM/dd/yyyy"
                                                        TargetControlID="txtFromDate">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFromDate"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" CssClass="label" Text="To"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" Width="60px" autocomplete="off"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                                                        Format="MM/dd/yyyy" TargetControlID="txtToDate">
                                                    </ajaxToolkit:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtToDate"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="label" Text="Start Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <MKB:TimeSelector ID="tpkStartTime" runat="server" SelectedTimeFormat="TwentyFour">
                                                    </MKB:TimeSelector>
                                                </td>
                                                <td>
                                              
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" CssClass="label" Text="End Time"></asp:Label>
                                                </td>
                                                <td>
                                                    <MKB:TimeSelector ID="tpkEndTime" runat="server" SelectedTimeFormat="TwentyFour">
                                                    </MKB:TimeSelector>
                                                </td>
                                                <td>
                                               
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
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label10" runat="server" Text="Address" CssClass="label"></asp:Label>
                                                </td>
                                                <td colspan="9" rowspan="2">
                                                    <asp:TextBox ID="txtAddressDueToMovement" runat="server" CssClass="txt" Width="265px"
                                                        Height="36 px" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddressDueToMovement"
                                                        ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hdnApplicationID" runat="server" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td style="width: 115px">
                                                </td>
                                                <td style="width: 60px">
                                                    <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" Width="60px"
                                                        OnClick="btnAdd_Click" ValidationGroup="VG" />
                                                </td>
                                                <td style="width: 60px">
                                                    <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" Width="60px"
                                                        OnClick="btnEdit_Click" ValidationGroup="VG" />
                                                </td>
                                                <td style="width: 60px">
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Width="60px"
                                                        OnClick="btnDelete_Click" />
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                       
                                    </div>
                                </asp:Panel>
                            </fieldset>
                        </td>
                        <td style="width: 350px; height: 200px;">
                            <fieldset>
                                <legend>Personal Information:</legend>
                                <asp:Panel ID="panPersonalDetails" runat="server" ScrollBars="None" Width="100%"
                                    Height="210px">
                                    <div>
                                        <table>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label1" runat="server" Text="Name" CssClass="label"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                        BorderStyle="None" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label2" runat="server" Text="Unit" CssClass="label"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:TextBox ID="txtUnit" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                        BorderStyle="None" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label3" runat="server" Text="Department" CssClass="label"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                        BorderStyle="None" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="Label4" runat="server" Text="Designation" CssClass="label"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:TextBox ID="txtDesignation" CssClass="txt" Width="200px" runat="server" ReadOnly="True"
                                                        BorderStyle="None" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:Label ID="lblJobStatus" runat="server" Text="Job Status" CssClass="label"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:TextBox ID="txtJobStatus" runat="server" Width="200px" CssClass="txt" ReadOnly="True"
                                                        BorderStyle="None" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="dgvOfficialMovementApplication" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" DataKeyNames="intId" SkinID="sknGrid2" Width="750px"
                                DataSourceID="dgvOfficialMovementObjectDataSource" OnRowDataBound="dgvOfficialMovementApplication_RowDataBound"
                                OnSelectedIndexChanged="dgvOfficialMovementApplication_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="intId" HeaderText="Application Id" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="100px" SortExpression="intId" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Movement Type" SortExpression="strMoveType">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("strMoveType") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnMoveTypeID" runat="server" Value='<%# Bind("intMoveTypeID") %>' />
                                            <asp:HiddenField ID="hdnCountryCode" runat="server" Value='<%# Bind("strCountryCode") %>' />
                                            <asp:HiddenField ID="hdnDistrictID" runat="server" Value='<%# Bind("intDistrictID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="dteAppliedTime" HeaderText="Application Date" DataFormatString="{0:MM/dd/yyyy}"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteAppliedTime"
                                        Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dteStartTime" HeaderText="From Date" DataFormatString="{0:MM/dd/yyyy}"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteStartTime">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dteEndTime" HeaderText="To Date" DataFormatString="{0:MM/dd/yyyy}"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteEndTime">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="strReason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="150px" SortExpression="strReason">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="strAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="100px" SortExpression="strAddress">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Approve Status" SortExpression="srtApprovedStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovedStatus" runat="server" Text='<%# Bind("srtApprovedStatus") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnEditable" runat="server" Value='<%# Bind("ysnEditable") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col" style="width: 100px">
                                            Application Id
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Movement Type
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Application Date
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            From Date
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            To Date
                                        </th>
                                        <th scope="col" style="width: 150px">
                                            Reason
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Address
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Approve Status
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                 <table>
                                            <tr>
                                                <td style="width: 115px">
                                                    <asp:ObjectDataSource ID="ddlTypesOfMovementObjectDataSource" runat="server" 
                                                        SelectMethod="GetMovementTypeList" 
                                                        TypeName="HR_BLL.OfficialMovement.OfficialMovement"></asp:ObjectDataSource>
                                                </td>
                                                <td style="width: 60px">
                                                    <asp:ObjectDataSource ID="ddlDistrictObjectDataSource" runat="server" 
                                                        SelectMethod="GetDistrictList" TypeName="HR_BLL.Global.District">
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td style="width: 60px">
                                                    <asp:ObjectDataSource ID="ddlCountryObjectDataSource" runat="server" 
                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetCountryList" 
                                                        TypeName="HR_BLL.Global.Country"></asp:ObjectDataSource>
                                                </td>
                                                <td style="width: 60px">
                                                    <asp:HiddenField ID="hdfEmpCode" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:ObjectDataSource ID="dgvOfficialMovementObjectDataSource" runat="server" 
                                                        OldValuesParameterFormatString="original_{0}" 
                                                        SelectMethod="GetAllUnApprovedOfficialMovementApplicationByUserID" 
                                                        TypeName="HR_BLL.OfficialMovement.OfficialMovement">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="hdnUserID" DefaultValue="" Name="userID" 
                                                                PropertyName="Value" Type="String" />
                                                            <asp:ControlParameter ControlID="hdfEmpCode" DefaultValue="" Name="empCode" 
                                                                PropertyName="Value" Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
