           <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingMRR.aspx.cs" Inherits="UI.SCM.PendingMRR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />

    <script>
        function Viewdetails(MrrId) {
            window.open('MrrStatementDetalis.aspx?MrrId=' + MrrId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
        }
    </script>
    <script>
        function DocViewdetails(MrrId) {
            window.open('MrrDocAttachmentPopUp.aspx?MrrId=' + MrrId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
        }

        function validation() {
        }

        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url);
                return false;
            }
            return true;
        }

        $(document).ready(function () {
            document.getElementById("approvedDiv").style.display = "none";
        });
        function ShowDetailsDiv(poid) {
            document.getElementById("hdnpoid").value = poid;
            document.getElementById("lblpo").innerText = "PO. No: " + poid;
            $("#approvedDiv").fadeIn("slow");
            $("#DetailsGrid").fadeOut("slow");
        }
        function HideReasonDiv(msg) {
            $("#approvedDiv").fadeOut("slow");
            $("#DetailsGrid").fadeIn("slow");
            document.getElementById("hdnpoid").value = "";            
            if (msg.length > 0)
            { alert(msg); }
        }
        function ConfirmAll() {
            document.getElementById("hdnconf").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?"))
            {
                confirm_value.value = "Yes";
                document.getElementById("hdnconf").value = "1";
            }
            else {
                confirm_value.value = "No";
                document.getElementById("hdnconf").value = "0";
            }
        }

    </script>
</head>

<body>

    <form id="frmselfresign" runat="server">
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
               <%-- <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>--%>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <div class="tabs_container" style="text-align: center">
                        Pending MRR<hr />
                    </div>

                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlDept" Enabled="true" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                    <asp:ListItem>Local</asp:ListItem>
                                    <asp:ListItem>Fabrication</asp:ListItem>
                                    <asp:ListItem>Import</asp:ListItem>
                                </asp:DropDownList></td>
                            
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
                                </cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="MRR No: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMrrNo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                            <td style="text-align: right">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Type: "></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlType" Enabled="true" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                <asp:ListItem Value="QC">QC</asp:ListItem>
                                                <asp:ListItem Value="Costing">Costing</asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                <asp:Button ID="btnStatement" runat="server" Text="Show" OnClick="btnStatement_Click" OnClientClick="showLoader()" />
                            </td>

                           
                            <td></td>
                            <td></td>
                            <td></td>
                            <td style="text-align: right">
                                <asp:Button ID="btnMRRSDetail" runat="server" Text="Statement" OnClick="btnMRRSDetail_Click" OnClientClick="return validation();" ForeColor="Blue" Visible="false" />
                            </td>
                        </tr>
                    </table>

                    <div id="DetailsGrid">

                   
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnSelectedIndexChanged="dgvIndent_SelectedIndexChanged"
                                    OnRowDataBound="dgvIndent_RowDataBound">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="20px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MRR ID" SortExpression="intMrr">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMrrId" runat="server" Text='<%# Bind("intMRRID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MRR Date" ItemStyle-HorizontalAlign="right" SortExpression="dteMrr">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldteMrr" Width="60px" runat="server" Text='<%# Bind("dteLastActionTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO ID" ItemStyle-HorizontalAlign="right" SortExpression="intPo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPo" runat="server" Text='<%# Bind("intpoid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Challan" ItemStyle-HorizontalAlign="right" SortExpression="strExtnlReff">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChallan" runat="server" Width="" Text='<%# Bind("strExtnlReff") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Challan Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteChallanDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChallanDate" runat="server" Text='<%# Bind("dteChallanDate","{0:dd/MM/yyyy}" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-HorizontalAlign="right" SortExpression="strSupp">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupp" runat="server" Width="150px" Text='<%# Bind("strSupplierName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Missing Cost" ItemStyle-HorizontalAlign="right" SortExpression="missingCost">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMissingCost" runat="server" Width="150px" Text='<%# Bind("missingCost") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>


                                        <%--<asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strRemarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" Width="60px" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>--%>

                                        <%--<asp:TemplateField HeaderText="Detalis">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAttachment" runat="server" Text="Attachment" OnClick="btnAttachment_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>


                                        <asp:TemplateField HeaderText="Detalis">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDetalis" runat="server" Text="Detalis" OnClientClick="showLoader()" OnClick="btnDetalis_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Complete">
                                            <ItemTemplate>
                                                <asp:Button ID="btnComplete" runat="server" Text="Complete" OnClientClick="showLoader()" OnClick="btnComplete_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfShipmentID" runat="server" Value='<%# Eval("intShipmentID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfUnitID" runat="server" Value='<%# Eval("intUnitID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfLocationID" runat="server" Value='<%# Eval("intLocationID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfItemID" runat="server" Value='<%# Eval("intItemID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfReceiveQnt" runat="server" Value='<%# Eval("numReceiveQty") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

                                </asp:GridView>
                            </td>
                        </tr>

                    </table>
                     </div>
                </div> 
                <%--ending leave container--%>

                <div id="approvedDiv">
                       <table border="0"; style="width:Auto"; >
                        <tr><td><asp:Label ID="lblpo" runat="server" Font-Bold="true"></asp:Label><br />
                        <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                        <asp:TemplateField HeaderText="Item No." SortExpression="intItemID">
                        <ItemTemplate><asp:Label ID="lblitmno" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
                                             
                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
                        <ItemTemplate><asp:Label ID="lblitem" runat="server" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="250px" /></asp:TemplateField>

                        <asp:BoundField DataField="strSpecificationDetail" HeaderText="Specification" ItemStyle-HorizontalAlign="Center" SortExpression="strSpecificationDetail">
                        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:BoundField>

                        <asp:TemplateField HeaderText="PO Quantity" SortExpression="numQty">
                        <ItemTemplate><asp:Label ID="lblpoqnty" runat="server" Text='<%# Bind("numPOQty", "{0:0}") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="MRR Quantity" SortExpression="MrrQty">
                        <ItemTemplate><asp:Label ID="lblmrrqnty" runat="server" Text='<%# Bind("MrrQty", "{0:0}") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Value" SortExpression="monBDTTotal">
                        <ItemTemplate><asp:Label ID="lblmonBDTTotal" runat="server" Text='<%# Bind("monBDTTotal", "{0:00}") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Location ID." SortExpression="intLocationID" Visible="false">
                        <ItemTemplate><asp:Label ID="lblLocationId" runat="server" Text='<%# Bind("intLocationID") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Unit ID." SortExpression="intUnitID" Visible="false">
                        <ItemTemplate><asp:Label ID="lblintUnitID" runat="server" Text='<%# Bind("intUnitID") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Checking">
                        <ItemTemplate><asp:TextBox ID="txtChkQuantity" CssClass="txtBox" runat="server" TextMode="Number" Width="100px"></asp:TextBox></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate><asp:TextBox ID="txtRemarks" CssClass="txtBox" runat="server" Width="100px"></asp:TextBox></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Proceed"><EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" Checked="false"/></EditItemTemplate>
                        <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" Checked="false"/></ItemTemplate><ItemStyle HorizontalAlign="Center"/></asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>            
                        </td></tr>
                        <tr><td style="text-align:right;"><asp:HiddenField ID="hdnpoid" runat="server"/><asp:HiddenField ID="hdnmrrid" runat="server"/><asp:HiddenField ID="hdnItemId" runat="server"/><asp:HiddenField ID="hdnconf" runat="server"/><a class="nextclick" onclick="HideReasonDiv('')">Cancel</a>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td></tr>
                        </table>
                    </div>
                <%--ending approve div--%>
                
                <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

