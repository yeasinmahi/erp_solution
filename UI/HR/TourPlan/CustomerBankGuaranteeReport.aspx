<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBankGuaranteeReport.aspx.cs" Inherits="UI.HR.TourPlan.CustomerBankGauranteeReport" %>
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
            var fromdate = document.getElementById("txtFromDate").value;
            var todate = document.getElementById("txtToDate").value;
           

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
                    
                  <table style="width: 700px; table-layout: auto; vertical-align: top; background-color: #DDD;">
                        <tr>
                            <td style="text-align: right;"><asp:Label ID="Label1" runat="server" Text="From Date:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFromDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td style="text-align: right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="To Date:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl"  runat="server" Text="Category:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DdlReport" runat="server" CssClass="dropdownList" Width="100" >
                                    <asp:ListItem Value="1">Report</asp:ListItem>
                                    <asp:ListItem Value="2">Update</asp:ListItem>
                                    <asp:ListItem Value="3">Delete</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td></td>

                            <td><asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" OnClientClick = "return ConfirmforShow()" BackColor="#ffff99" Text="Show Report" /></td>
                        </tr>
                    </table>
                    <div class="divHeader" style="padding-top:8px;padding-bottom:8px;padding-left:5px;">
                        <asp:Label ID="lbltitle" runat="server" Text="Customer Bank Guarantee Report: "></asp:Label>
                    </div>                   

                    <table>
                        <%-- Grid View for showing list of data --%>
                        <tr>
                            <td>
                                <asp:GridView ID="GVList" runat="server" AutoGenerateColumns="False" DataKeyNames="intpkid">
                                  
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intpkid" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="intpkid" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="strcustname" HeaderText="Customer Name" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="territory" HeaderText="Territroy" SortExpression="territory" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="region" HeaderText="Region" SortExpression="region" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="salesoff" HeaderText="Sales Office" SortExpression="salesoff" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="bankname" HeaderText="Bank Name" SortExpression="bankname" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="branchname" HeaderText="Branch Name" SortExpression="branchname" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="lienno" HeaderText="Lien No" SortExpression="lienno" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="bgamount" HeaderText="Amount" SortExpression="bgamount" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="bgstartdate" HeaderText="Issue Date" ReadOnly="True" SortExpression="bgstartdate" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="bgenddate" HeaderText="Expire Date" ReadOnly="True" SortExpression="bgenddate" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="durationyr" HeaderText="Duration" ReadOnly="True" SortExpression="durationyr" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="strinsertby" HeaderText="Employee Name" SortExpression="strinsertby" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="insertdate" HeaderText="Insert Date" ReadOnly="True" SortExpression="insertdate" ItemStyle-HorizontalAlign="Center"/>
                                   </Columns>
                                </asp:GridView>
                  
                            </td>
                           
                             
                        </tr>
                        <%-- Grid View for update data--%>
                        <tr>
                             <td>
                                <asp:GridView ID="GVUpdate" runat="server" AutoGenerateColumns="False" DataKeyNames="intpkid" OnRowEditing="GVUpdate_RowEditing" OnRowUpdating="GVUpdate_RowUpdating" OnRowCancelingEdit="GVUpdate_RowCancelingEdit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="intpkid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("intpkid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Name" SortExpression="strcustname">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtstrcustname" runat="server" Text='<%# Bind("strcustname") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("strcustname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Territroy" SortExpression="territory">
                                          
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("territory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Area" SortExpression="area">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("area") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Region" SortExpression="region">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("region") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Office" SortExpression="salesoff">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("salesoff") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Name" SortExpression="bankname">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtBankName" runat="server" Text='<%# Bind("bankname") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("bankname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Name" SortExpression="branchname">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtbranchname" runat="server" Text='<%# Bind("branchname") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("branchname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lien No" SortExpression="lienno">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtlienno" runat="server" Text='<%# Bind("lienno") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("lienno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" SortExpression="bgamount">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtbgamount" runat="server" Text='<%# Bind("bgamount") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("bgamount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Issue Date" SortExpression="bgstartdate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtbgstartdate" runat="server" Text='<%# Bind("bgstartdate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("bgstartdate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Expire Date" SortExpression="bgenddate">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtbgenddate" runat="server" Text='<%# Bind("bgenddate") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("bgenddate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Duration" SortExpression="durationyr">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("durationyr") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="strinsertby">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("strinsertby") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Insert Date" SortExpression="insertdate">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("insertdate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField>  
                                            <ItemTemplate>  
                                                <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />
                                                
                                            </ItemTemplate>  
                                            <EditItemTemplate>  
                                                <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                                            </EditItemTemplate>  
                                        </asp:TemplateField>--%>
                                        <asp:CommandField ShowEditButton="true" />  
                                   </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <%-- Grid View for delete data --%>
                        <tr>
                            <td>
                                <asp:GridView ID="GVDelete" DataKeyNames="intpkid" runat="server" OnRowDeleting="GVDelete_RowDeleting" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="intpkid">
                                           <ItemTemplate>
                                                <asp:Label ID="lblintpkid" runat="server" Text='<%# Bind("intpkid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Name" SortExpression="strcustname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrcustname" runat="server" Text='<%# Bind("strcustname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Territroy" SortExpression="territory">
                                           <ItemTemplate>
                                                <asp:Label ID="lblterritory" runat="server" Text='<%# Bind("territory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Area" SortExpression="area">
                                            <ItemTemplate>
                                                <asp:Label ID="lblarea" runat="server" Text='<%# Bind("area") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Region" SortExpression="region">
                                            <ItemTemplate>
                                                <asp:Label ID="lblregion" runat="server" Text='<%# Bind("region") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Office" SortExpression="salesoff">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsalesoff" runat="server" Text='<%# Bind("salesoff") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Name" SortExpression="bankname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbankname" runat="server" Text='<%# Bind("bankname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Name" SortExpression="branchname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbranchname" runat="server" Text='<%# Bind("branchname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lien No" SortExpression="lienno">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllienno" runat="server" Text='<%# Bind("lienno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" SortExpression="bgamount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbgamount" runat="server" Text='<%# Bind("bgamount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Issue Date" SortExpression="bgstartdate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbgstartdate" runat="server" Text='<%# Bind("bgstartdate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Expire Date" SortExpression="bgenddate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbgenddate" runat="server" Text='<%# Bind("bgenddate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Duration" SortExpression="durationyr">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldurationyr" runat="server" Text='<%# Bind("durationyr") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="strinsertby">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrinsertby" runat="server" Text='<%# Bind("strinsertby") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Insert Date" SortExpression="insertdate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinsertdate" runat="server" Text='<%# Bind("insertdate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="true" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    
                </div>

        <%----=========================================End My Code From Here=================================================--%>

            </ContentTemplate>
         </asp:UpdatePanel>
        
    </form>
</body>
</html>
