<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoRegisterReport.aspx.cs" Inherits="UI.SCM.PoRegisterReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">

    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />

    <link href="../Content/CSS/GridView.css" rel="stylesheet" />

    <style type="text/css">
        .rounds {
            height: 80px;
            width: 30px;
            -moz-border-colors: 25px;
            border-radius: 25px;
        }

        .HyperLinkButtonStyle {
            float: right;
            text-align: left;
            border: none;
            background: none;
            color: blue;
            text-decoration: underline;
            font: normal 10px verdana;
        }

        .hdnDivision {
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 100%;
            height: 100%;
            margin-left: 70px;
            margin-top: 00px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }
    </style>
    <script>
        function ViewBillDetailsPopup(Id) {
            window.open('../PaymentModule/BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }

        function Viewdetails(Id) {
            window.open('../PaymentModule/IndentViewDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }



        function ViewdetailsMrr(Id) {
            window.open('../PaymentModule/MRRDetailsView.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=220, close=no');
            if (window.focus) { newwindow.focus() }
        }


        function Confirm() {
            var fromdate = document.getElementById("txtDteFrom").value;
            var todate = document.getElementById("txtdteTo").value;
            if (fromdate == null || fromdate == "") {
                alert("Insert From Date");
                return false;
            }
            else if (todate == null || todate == "") {
                alert("Insert To Date");
                return false;
            }
            else {
                return true;
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
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <div class="tabs_container" style="text-align: center;font-size:16px;" ><u>PO  REGISTER</u><hr />
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Department:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                    <asp:ListItem Text="Local"></asp:ListItem>
                                    <asp:ListItem Text="Import"></asp:ListItem>
                                    <asp:ListItem Text="Fabrication"></asp:ListItem>
                                </asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Indent: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtIndent" runat="server" CssClass="txtBox" Width="150px"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="PO: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPO" runat="server" CssClass="txtBox" Width="150px"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="MRR: " ></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMrr" runat="server" CssClass="txtBox"  Width="160px"></asp:TextBox></td>
                            <td style="text-align: right">
                            <td style="text-align: left">
                                <asp:Button ID="btnSearch" runat="server" forecolor="blue" Text="Search"  OnClick="btnSearch_Click" />
                            </td>

                        </tr>

                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" Height="16px"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="View By: "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="ddList">
                                    <asp:ListItem Text="Indent" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="PO" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="MRR" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="NO PO" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="NO MRR" Value="5"></asp:ListItem>
                                </asp:DropDownList></td>


                            <td style="text-align: right;">
                                <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDteFrom" runat="server" Width="100px" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
                                </cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtdteTo" runat="server" Width="100px" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="text-align: right">
                            <td style="text-align: left">
                                <asp:Button ID="btnShow" runat="server" Text="Show" forecolor="blue"  OnClick="btnShow_Click" OnClientClick="return Confirm()" />
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvStatement" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowCommand="dgvStatement_RowCommand">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="30px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UNIT" SortExpression="unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnit" runat="server" Width="60px" Text='<%# Bind("unit") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="right" SortExpression="dwhteSrDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" Width="85px" runat="server" Text='<%# Bind("wh") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="IndentNo" ItemStyle-HorizontalAlign="right" SortExpression="indent">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblIndentNo" runat="server" OnClick="lblIndentNo_Click" Text='<%# Bind("indent") %>'></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Indent Date" ItemStyle-HorizontalAlign="right" SortExpression="indDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIndentDate" runat="server" Width="60px" Text='<%# Bind("indDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Approve Date" ItemStyle-HorizontalAlign="right" SortExpression="appDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInApproveDate" runat="server" Width="60px" Text='<%# Bind("appDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Due date" ItemStyle-HorizontalAlign="right" SortExpression="dueDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDueDate" runat="server" Width="60px" Text='<%# Bind("dueDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO NO" ItemStyle-HorizontalAlign="right" SortExpression="po">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblPoNos" runat="server" OnClick="lblPoNos_Click" Text='<%# Bind("po") %>'></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO Date" ItemStyle-HorizontalAlign="right" SortExpression="poDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoDate" runat="server" Width="60px" Text='<%# Bind("poDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO Value" ItemStyle-HorizontalAlign="right" SortExpression="POValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoValue" runat="server" Width="60px" Text='<%# Bind("POValue") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MRR NO" ItemStyle-HorizontalAlign="right" SortExpression="mrr">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblMrrNo" runat="server" Width="52px" OnClick="lblMrrNo_Click" Text='<%# Bind("mrr") %>'></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MRR Date" ItemStyle-HorizontalAlign="right" SortExpression="mrrDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMrrDate" runat="server" Width="60px" Text='<%# Bind("mrrDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="JV" ItemStyle-HorizontalAlign="right" SortExpression="Jv">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJV" runat="server" Width="100px" DataFormatString="{0:0.00}" Text='<%# Bind("Jv") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Supplier" ItemStyle-HorizontalAlign="right" SortExpression="sup">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupplier" runat="server" Width="100px" Text='<%# Bind("sup") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO Prepare By" ItemStyle-HorizontalAlign="right" SortExpression="emp" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoPrepareBy" runat="server" Width="120px" Text='<%# Bind("emp") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Registration No" ItemStyle-HorizontalAlign="right" SortExpression="RegNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("RegNo") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Bill No" ItemStyle-HorizontalAlign="right" SortExpression="billno">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblBillNo" runat="server" OnClick="lblBillNo_Click" Text='<%# Bind("billno") %>'></asp:LinkButton></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pay Date" ItemStyle-HorizontalAlign="right" SortExpression="paydate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPayDate" runat="server" Width="60px" Text='<%# Bind("paydate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pay Amount" ItemStyle-HorizontalAlign="right" SortExpression="PayAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPayAmount" runat="server" Text='<%# Bind("PayAmount") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="Show Detail" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnShowPoNo" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="ViewPo"  
            Text="Po No"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                <asp:TemplateField HeaderText="Show Detail" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnShowMRRNo" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="ViewMRR"  
            Text="MRR No"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                <asp:TemplateField HeaderText="Show Detail" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnShowBillNo" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="ViewBill"  
            Text="Bill No"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

                                </asp:GridView>
                            </td>
                        </tr>

                    </table>

                    <%-- <table>
           <tr><td> 
            <asp:GridView ID="dgvStatement" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="UNIT" SortExpression="unit"><ItemTemplate>
            <asp:Label ID="lblUnit" runat="server" Width="75px" Text='<%# Bind("unit") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Location"   ItemStyle-HorizontalAlign="right" SortExpression="dwhteSrDate" >
            <ItemTemplate><asp:Label ID="lblLocation" Width="60px" runat="server"  Text='<%# Bind("wh") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="IndentNo"   ItemStyle-HorizontalAlign="right" SortExpression="indent" >
            <ItemTemplate><asp:Label ID="lblIndentNo" runat="server"  Text='<%# Bind("indent") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Indent Date"   ItemStyle-HorizontalAlign="right" SortExpression="indDate" >
            <ItemTemplate><asp:Label ID="lblIndentDate" runat="server" Width="60px"  Text='<%# Bind("indDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Approve Date" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblInApproveDate" runat="server"   Text='<%# Bind("appDate","{0: dd-MM-YYYY}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Due date" ItemStyle-HorizontalAlign="right" SortExpression="dueDate" >
            <ItemTemplate><asp:Label ID="lblDueDate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dueDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
           
            <asp:TemplateField HeaderText="PO NO" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="po" >
            <ItemTemplate><asp:Label ID="lblPoNos" runat="server"  Text='<%# Bind("po") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PO Date"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblPoDate" runat="server"  Text='<%# Bind("poDate","{0:dd-MM-YYYY}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>    

            <asp:TemplateField HeaderText="MRR NO"   ItemStyle-HorizontalAlign="right" SortExpression="mrr" >
            <ItemTemplate><asp:Label ID="lblMrrNo" runat="server" Width="60px"  Text='<%# Bind("mrr") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="MRR Date" ItemStyle-HorizontalAlign="right" SortExpression="mrrDate" >
            <ItemTemplate><asp:Label ID="lblMrrDate" runat="server"   Text='<%# Bind("mrrDate","{0: dd-MM-YYYY}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="JV" ItemStyle-HorizontalAlign="right" SortExpression="JV" >
            <ItemTemplate><asp:Label ID="lblJV" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("JV") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Supplier" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="sup" >
            <ItemTemplate><asp:Label ID="lblSupplier" runat="server"  Text='<%# Bind("sup") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PO PrepareBy"   ItemStyle-HorizontalAlign="right" SortExpression="emp" >
            <ItemTemplate><asp:Label ID="lblPoPrepareBy" runat="server"  Text='<%# Bind("emp") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
        </tr> 
           
        </table>--%>
                </div>
                </div> 
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
