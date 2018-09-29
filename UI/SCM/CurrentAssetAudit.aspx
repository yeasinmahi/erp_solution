<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentAssetAudit.aspx.cs" Inherits="UI.SCM.CurrentAssetAudit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
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
                 <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Current Asset Audit" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
                 <div>
                   
                     <table class="tbldecoration" style="width:auto; float:left;">
                         <tr >

                             <td style="text-align: right;">
                                 <asp:Label ID="lblWh" CssClass="lbl" runat="server" Text="WH Name : "></asp:Label></td>
                             <td>
                                <asp:DropDownList ID="ddlWH" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"  CssClass="ddList1" Font-Bold="False" DataSourceID="ObjectDataSource1" DataTextField="strWareHoseName" DataValueField="intWHID"> </asp:DropDownList> 
                                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWHData" TypeName="SCM_DAL.BillingTDSTableAdapters.TblWHTableAdapter"></asp:ObjectDataSource>
                                 <asp:HiddenField ID="hdnwh" runat="server"/>
                             </td>
                          
                            <td style="text-align: right;"><asp:Label ID="lblItem" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>
                             <td> <asp:TextBox ID="txtItem" placeholder="Search Item" AutoCompleteType="Search" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="250px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                ServiceMethod="GetItemList" MinimumPrefixLength="1" CompletionSetCount="1"
                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                             </td>
                             <td style="text-align: right;">
                                 <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Audit Date : "></asp:Label></td>

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
                                  <asp:GridView ID="GvAuditList" runat="server" DataKeyNames="intItem" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                            <asp:TemplateField HeaderText="Item ID" SortExpression="intItem">                               
                                <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">                             
                                <ItemTemplate>
                                    <asp:Label ID="lblstrItem" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM" SortExpression="strUoM">
                              
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Open Quantity" SortExpression="monOpenQty">
                              
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("monOpenQty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Open Value" SortExpression="monOpenValue">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("monOpenValue") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Right" />
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receive Quantity" SortExpression="monRcvQty">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("monRcvQty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Receive Value" SortExpression="monRcvValue">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("monRcvValue") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Quantity" SortExpression="monIssueQty">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("monIssueQty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Value" SortExpression="Column1">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Column1") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Closing Quantity" SortExpression="Column2">                             
                                <ItemTemplate>
                                    <asp:Label ID="lblclsQty" runat="server" Text='<%# Bind("Column2") %>'></asp:Label>
                                </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Close Value" SortExpression="monCloseValue">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("monCloseValue") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location" SortExpression="strLocation">
                               
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("strLocation") %>' Width="140px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Audited Quantity" SortExpression="AuditedQty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAuditedQty" runat="server" Width="55px" ></asp:TextBox>
                                </ItemTemplate>                   
                                 <HeaderStyle Width="50px" />
                                 <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">

                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="80px" ></asp:TextBox>
                                </ItemTemplate>                   
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAllRow(this);" AutoPostBack="true" OnCheckedChanged="chkHeader_CheckedChanged"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRow" runat="server" AutoPostBack="true" OnCheckedChanged="chkRow_CheckedChanged" onclick="CheckRow(this);"/>
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
