<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemCategoryUpdate.aspx.cs" Inherits="UI.SCM.ItemCategoryUpdate" %>
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
            //alert('check');
            //debugger;
            //var objDDl = document.getElementById('ddlDept').value;
            //if(objDDl.options[objDDl.selectedIndex].value == "Select")
            //{
            //alert("Please Select Department");
            //return false;
            //}
        }
        
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
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
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    
                    <div class="tabs_container" style="text-align: left">ITEM LIST<hr />
                    </div>

                    <table>
                        <tr>

                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <td style="text-align: right">
                                <asp:Button ID="btnShowItem" runat="server" Text="Show" forecolor="Blue" OnClick="btnShowItem_Click" OnClientClick="showLoader()" />
                            </td>
                           

                        </tr>
                        

                           
                            
                               
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="20px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item ID" SortExpression="ItemID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Master ID" ItemStyle-HorizontalAlign="right" SortExpression="intMasterID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMasterID" runat="server" Text='<%# Bind("intItemMasterID") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Full Name" ItemStyle-HorizontalAlign="right" SortExpression="strItemFullName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemFullName" runat="server" Width="350px" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UoM" ItemStyle-HorizontalAlign="right" SortExpression="UoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUoM" Width="60px" runat="server" Text='<%# Bind("struom") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Type" ItemStyle-HorizontalAlign="right" SortExpression="Item Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemType" runat="server" Width="" Text='<%# Bind("strItemType") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cluster" ItemStyle-HorizontalAlign="Center" SortExpression="Cluster">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCluster" runat="server" Text='<%# Bind("MasterCluster" ) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Com. Group" ItemStyle-HorizontalAlign="right" SortExpression="Group">
                                            <ItemTemplate>
                                                <asp:Label ID="lblComGroup" runat="server"  Text='<%# Bind("MasterComGroup") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="right" SortExpression="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("MasterCategory" ) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Sub-Category" ItemStyle-HorizontalAlign="right" SortExpression="sub-Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("strsubcategory" ) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MinorCategory" ItemStyle-HorizontalAlign="right" SortExpression="Minor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMinorCat" Width="60px" runat="server" Text='<%# Bind("strMinorCategory") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="right" SortExpression="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" Width="60px" runat="server" Text='<%# Bind("iStatus") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Detalis">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDetalis" runat="server" Text="Detalis" OnClick="btnDetalis_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

                                </asp:GridView>
                            </td>
                        </tr>

                    </table>

                </div>

                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Category Update</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label22" runat="server" Text="Item Id"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtItemId" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Item Id"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label14" runat="server" Text="Item Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtItemName" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Item Name"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label12" runat="server" Text="Group"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:dropdownlist ID="ddlGroup" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Production Id"></asp:dropdownlist>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:dropdownlist ID="ddlCategory" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Quantity"></asp:dropdownlist>
                                    </div>

                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label3" runat="server" Text="SubCategory"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:dropdownlist ID="ddlSubCategory" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Quantity"></asp:dropdownlist>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="col-md-12">
                                    <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary form-control pull-right" Text="Update" OnClick="btnUpdate_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               


                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
