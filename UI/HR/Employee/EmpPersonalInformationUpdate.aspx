<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpPersonalInformationUpdate.aspx.cs" Inherits="UI.HR.Employee.EmpPersonalInformationUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
     <link href="../../Content/CSS/MyStyle.css" rel="stylesheet" />
     <%--<script src="../../Content/JS/EmpPersonalInformationUpdate.js"></script>--%>
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
 

    <script>
function Confirm() {
     
    var EmployeeSearch = document.getElementById("TxtEmployee").value;
    var Name = document.getElementById("TxtName").value;
    var Designation = document.getElementById("TxtDesignation").value;
    var Department = document.getElementById("TxtDepartment").value;
    var DateOfJoin = document.getElementById("TxtDateOfJoin").value;
    var UnitName = document.getElementById("TxtUnit").value;
    var JobStation = document.getElementById("TxtJobStation").value;
    var Father = document.getElementById("TxtFather").value;
    //var Mother = document.getElementById("TxtMother").value;
    //var Spouse = document.getElementById("TxtSpouse").value;
    var Village = document.getElementById("TxtVillage").value;
    var PermanentPostOffice = document.getElementById("TxtPermanentPostOffice").value;
    var PermanentPoliceStation = document.getElementById("TxtPermanentPoliceStation").value;
    var PermanentDistricts = document.getElementById("TxtPermanentDistricts").value;
    //var PresentPostOffice = document.getElementById("TxtPresentPostOffice").value;
    //var House = document.getElementById("TxtHouse").value;
    //var Road = document.getElementById("TxtRoad").value;
    //var PresentPoliceStation = document.getElementById("TxtPresentPoliceStation").value;
    //var PresentDistricts = document.getElementById("TxtPresentDistricts").value;

    if (EmployeeSearch == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Search Employee Field");
    }
    else if (Name == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Employees Name");
    }
    else if (Department == "") {
        alert("Enter Department Name");
    }
    else if (UnitName == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Unit Name");
    }
    else if (Designation == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Designation");
    }
    else if (DateOfJoin == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Joining Date");
    }
    else if (JobStation == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Job Station");
    }
    else if (Father=="") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Father's Name");
    }
    //else if (Mother == "") { document.getElementById("hdnConfirm").value = "0";
    //    alert("Enter Mother's Name");
    //}
    else if (Village == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Village Name");
    }
    else if (PermanentPostOffice == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Post Office Name");
    }
    else if (PermanentDistricts == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Districts Name");
    }
    else if (PermanentPoliceStation == "") { document.getElementById("hdnConfirm").value = "0";
        alert("Enter Police Station Name");
    }
    //else if (House == "") { document.getElementById("hdnConfirm").value = "0";
    //    alert("Enter House No");
    //}
    //else if (Road == "") { document.getElementById("hdnConfirm").value = "0";
    //    alert("Enter Road No");
    //}
    //else if (PresentPostOffice == "") { document.getElementById("hdnConfirm").value = "0";
    //    alert("Enter Post Office Name");
    //}
    //else if (PresentPoliceStation == "") { document.getElementById("hdnConfirm").value = "0";
    //    alert("Enter Police Station Name");
        
    //}
    //else if (PresentDistricts == "") { document.getElementById("hdnConfirm").value = "0";
    //    alert("Enter Districts Name");
    //}

     else {
                 var confirm_value = document.createElement("INPUT"); 
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

            }

}
    </script>
    <style type="text/css">
                
        
        
        
    </style>

</head>
<body>
    <form id="frmaccountsrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>


<%--=========================================Start My Code From Here===============================================--%>   
    <div class="divHeader">Update Employee Information</div>
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnConfirm" runat="server" />
   
                    <table style="width: 600px;  outline-color: blue;table-layout: auto; vertical-align: top; background-color: #DDD;" class="tblRowOdd">
                        <tr> 
                            <td style="text-align: right;" class="tdBgColor tdHeight">
                                <asp:Label ID="LblEmployee" runat="server" CssClass="lbl" Font-Size="small" Text="Search Employee:"></asp:Label>
                            </td> 
                            <td style="text-align:left; " colspan="3" class="tdBgColor tdHeight"> <asp:TextBox ID="TxtEmployee" runat="server" CssClass="txtBox" Font-Bold="False" OnTextChanged="TxtEmployee_TextChanged" Width="530px" AutoPostBack="true"  ></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TxtEmployee"
                            ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> 
 
                        </tr>
                        
                        <tr class="tblRowOdd">
                            <td class="tdHeight tdColor" style="text-align: right; " >
                                <asp:Label ID="LblName" runat="server" CssClass="lbl" Font-Size="small" Text="Name:"></asp:Label>
                            </td>
                            <td class="tdHeight tdColor" style="text-align: left; background-color:#cecece;" >
                                <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td class="tdHeight tdColor" style="text-align: right; background-color:#cecece;">
                                <asp:Label ID="LblDesignation" runat="server" CssClass="lbl" Font-Size="small" Text="Designation:"></asp:Label>
                            </td>
                            <td class="tdHeight tdColor" style="text-align: left; background-color:#cecece;">
                                <asp:TextBox ID="TxtDesignation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblRowOdd">
                            <td style="text-align: right;" class="tdBgColor tdHeight">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Size="small" Text="Department:"></asp:Label>
                            </td>
                            <td style="text-align: left;" class="tdBgColor tdHeight">
                                <asp:TextBox ID="TxtDepartment" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td style="text-align: right;" class="tdBgColor tdHeight">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Size="small" Text="Date of Join:"></asp:Label>
                            </td>
                            <td style="text-align: left;" class="tdBgColor tdHeight">
                                <asp:TextBox ID="TxtDateOfJoin" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblRowOdd">
                            <td class="tdColor tdHeight" style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Font-Size="small" Text="Unit Name:"></asp:Label>
                            </td>
                            <td class="tdColor tdHeight" style="text-align: left;">
                                <asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td class="tdColor tdHeight" style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Font-Size="small" Text="Job Station:"></asp:Label>
                            </td>
                            <td class="tdColor tdHeight" style="text-align: left;">
                                <asp:TextBox ID="TxtJobStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr class="" style="border: 0px solid #c4bcbc;">
                            <td class="tdBgColor tdHeight" style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Font-Size="small" Text="Father's Name:"></asp:Label>
                            </td>
                            <td class="tdHeight tdBgColor " style="text-align: left;" colspan="3">
                                <asp:TextBox ID="TxtFather" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <%--<td class=" tdHeight tdBgColor" style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Font-Size="small" Text="Mother's Name:"></asp:Label>
                            </td>
                            <td class="tdHeight " style="text-align: left;">
                                <asp:TextBox ID="TxtMother" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>--%>
                        </tr>
                       <%-- <tr class="" >
                            <td class="" style="text-align: right;">
                                <asp:Label ID="LblSpouse" runat="server" CssClass="lbl" Font-Size="Small" Text="Spouse Name:"></asp:Label>
                            </td>
                            <td class="" colspan="3" style="text-align: left;">
                                <asp:TextBox ID="TxtSpouse" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr class="tblRowOdd">
                            <td colspan="4" class="tdColor">
                                <p style="text-decoration: underline; font-weight:bold;">Permanent Address</p>
                            </td>
                        </tr>
                        <tr class="tblRowOdd">
                            <td class="tdHeight tdBgColor" style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Font-Size="small" Text="Village:"></asp:Label>
                            </td>
                            <td class="tdHeight tdBgColor" style="text-align: left;">
                                <asp:TextBox ID="TxtVillage" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td class="tdHeight tdBgColor" style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" CssClass="lbl" Font-Size="small" Text="Post Office:"></asp:Label>
                            </td>
                            <td class="tdHeight tdBgColor" style="text-align: left;">
                                <asp:TextBox ID="TxtPermanentPostOffice" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblRowOdd">
                            <td style="text-align: right;" class="tdColor tdHeight">
                                <asp:Label ID="Label9" runat="server" CssClass="lbl" Font-Size="small" Text="Police Station:"></asp:Label>
                            </td>
                            <td style="text-align: left;" class="tdColor tdHeight">
                                <asp:TextBox ID="TxtPermanentPoliceStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td style="text-align: right;" class="tdColor tdHeight">
                                <asp:Label ID="Label10" runat="server" CssClass="lbl" Font-Size="small" Text="District:"></asp:Label>
                            </td>
                            <td style="text-align: left;" class="tdColor tdHeight">
                                <asp:TextBox ID="TxtPermanentDistricts" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                       <%-- <tr class="tblRowOdd">
                            <td colspan="4">
                                <h4 style="text-decoration: underline;" id="presentAdd"><span>Present Address</span> </h4>
                            </td>
                        </tr>--%>
                        <%--<tr class="">
                            <td class=" " style="text-align: right;">
                                <asp:Label ID="Label11" runat="server" CssClass="lbl" Font-Size="small" Text="House:"></asp:Label>
                            </td>
                            <td class="" style="text-align: left;">
                                <asp:TextBox ID="TxtHouse" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td class="" style="text-align: right;">
                                <asp:Label ID="Label12" runat="server" CssClass="lbl" Font-Size="small" Text="Road No:"></asp:Label>
                            </td>
                            <td class="" style="text-align: left;">
                                <asp:TextBox ID="TxtRoad" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="">
                            <td class="" style="text-align: right;">
                                <asp:Label ID="Label13" runat="server" CssClass="lbl" Font-Size="small" Text="Post Office:"></asp:Label>
                            </td>
                            <td class="" style="text-align: left;">
                                <asp:TextBox ID="TxtPresentPostOffice" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                            <td class="" style="text-align: right;">
                                <asp:Label ID="Label14" runat="server" CssClass="lbl" Font-Size="small" Text="Police Station:"></asp:Label>
                            </td>
                            <td class="" style="text-align: left;">
                                <asp:TextBox ID="TxtPresentPoliceStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="">
                            <td class="" style="text-align: right;">
                                <asp:Label ID="Label15" runat="server" CssClass="lbl" Font-Size="small" Text="District:"></asp:Label>
                            </td>
                            <td class="" colspan="3" style="text-align: left;">
                                <asp:TextBox ID="TxtPresentDistricts" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr class="tblRowFooter">
                            <td colspan="4" style="text-align: right;">
                                <asp:Button ID="BtnUpdate" runat="server" CssClass="button" OnClick="BtnUpdate_Click" OnClientClick="return Confirm();" Text="Update" />
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
