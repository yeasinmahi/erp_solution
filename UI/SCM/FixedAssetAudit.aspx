<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FixedAssetAudit.aspx.cs" Inherits="UI.SCM.FixedAssetAudit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <script>
        function CheckValidation() { }

         function checkAllRow(objRef) {
                var GridView = objRef.parentNode.parentNode.parentNode;
                var inputList = GridView.getElementsByTagName("input");
                for (var i = 0; i < inputList.length; i++)
                {

                    var row = inputList[i].parentNode.parentNode;
                    if (inputList[i].type == "checkbox" && objRef != inputList[i])
                    {
                        if (objRef.checked) {

                            row.style.backgroundColor = "#acf0f9";
                            inputList[i].checked = true;
                        }
                        else {                      
                            row.style.backgroundColor = "white"; 
                            inputList[i].checked = false;
                        }
                    }
                }
        }

        function CheckRow(objRef) {

            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {

                row.style.backgroundColor = "#acf0f9";
            }
            else {
                row.style.backgroundColor = "white";
            }

            var GridView = row.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {

                var headerCheckBox = inputList[0];
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }

        function check() {
             var confirm_value = document.createElement("input");
        confirm_value.type = "hidden";
        confirm_value.name = "Confirm_value";
        if (confirm("Do you want to proceed?")) {
            confirm.value = "Yes";
            document.getElementById("hdnConfirm").value = "1";
        }
        else {
             confirm.value = "No";
            document.getElementById("hdnConfirm").value = "0";
            }

            //var chkRow = document.getElementById("chkRow");
            //chkRow.checked = false;
        }
       
    </script>
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
                 <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Fixed Asset Audit" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
                 <div>
                   
                     <table class="tbldecoration" style="width:auto; float:left;">
                         <tr class="">

                             <td style="text-align: right;">
                                 <asp:Label ID="lblWh" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                             <td>
                                <asp:DropDownList ID="ddlJobstation" runat="server" CssClass="ddList1" Font-Bold="False" DataSourceID="ObjectDataSource1" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"> </asp:DropDownList> 
                                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllJobStation" TypeName="SCM_DAL.InventoryTransferTDSTableAdapters.tblEmployeeJobStationTableAdapter"></asp:ObjectDataSource>
                             </td>
                           
                             <td style="text-align: right;">
                                 <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Audited Date : "></asp:Label></td>

                             <td>
                                 <asp:TextBox ID="txtAuditDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="150px"></asp:TextBox>
                                 <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtAuditDate"></cc1:CalendarExtender>
                             </td>
                             <%-- <td style="text-align: right;">
                                 <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>

                             <td>
                                 <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="150px"></asp:TextBox>
                                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>

                             </td>--%>
                              <td>
                                 <asp:Button ID="btnShow" runat="server" class="myButton" Style="font-size: 12px; cursor: pointer;" Text="Show Report" OnClientClick="CheckValidation()" OnClick="btnShow_Click"/></td>
                             <td>
                            <asp:Button ID="btnInsert" runat="server" class="myButton" Style="font-size: 12px; cursor: pointer;" Text="Submit" OnClick="btnInsert_Click" OnClientClick="check()"/>
                        </td>
                         </tr>
                       
                     </table>
                     <asp:HiddenField ID="hdnConfirm" runat="server" />
                     <table>
                         <tr>
                             <td>
                                  <asp:GridView ID="GvAuditList" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                            <asp:TemplateField HeaderText="Unit" SortExpression="strunit">                               
                                <ItemTemplate>
                                    <asp:Label ID="lblstrunit" runat="server" Text='<%# Bind("strunit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset ID" SortExpression="strAssetID">                             
                                <ItemTemplate>
                                    <asp:Label ID="lblstrAssetID" runat="server" Text='<%# Bind("strAssetID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name Of Asset" SortExpression="strNameOfAsset">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblstrNameOfAsset" runat="server" Text='<%# Bind("strNameOfAsset") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category Name" SortExpression="strCategoryName">
                              
                                <ItemTemplate>
                                    <asp:Label ID="lblstrCategoryName" runat="server" Text='<%# Bind("strCategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Type Name" SortExpression="strAssetTypeName">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblstrAssetTypeName" runat="server" Text='<%# Bind("strAssetTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Description" SortExpression="strDescriptionAsset">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblstrDescriptionAsset" runat="server" Text='<%# Bind("strDescriptionAsset") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country Origin" SortExpression="strCountryOrigin">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblstrCountryOrigin" runat="server" Text='<%# Bind("strCountryOrigin") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblstrSupplierName" runat="server" Text='<%# Bind("strSupplierName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Enroll" SortExpression="intEnroll">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblintEnroll" runat="server" Text='<%# Bind("intEnroll") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Name" SortExpression="strName">                             
                                <ItemTemplate>
                                    <asp:Label ID="lblstrName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" SortExpression="strDepatrment">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblstrDepatrment" runat="server" Text='<%# Bind("strDepatrment") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Audit" SortExpression="strAudit">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("strAudit") %>' Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Total Cost" SortExpression="TotalCost">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalCost" runat="server" Text='<%# Bind("TotalCost") %>' Width="140px"></asp:Label>
                                </ItemTemplate>
                                  <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">

                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="80px" ></asp:TextBox>
                                </ItemTemplate>                   
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAllRow(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" onclick="CheckRow(this);" />
                            </ItemTemplate>
                        </asp:TemplateField>
                                                   
                        </Columns>
                    </asp:GridView>
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

