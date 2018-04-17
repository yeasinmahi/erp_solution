<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificateReceive.aspx.cs" Inherits="UI.Support.CertificateReceive" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   
    <script language="javascript" type="text/javascript">
        
        function Search_dgvservice(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }

        }

    </script>
                  
</head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>--%>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
    
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnUnit" runat="server" /> 
    <table>
        <tr><td>
            <div class="leaveApplication_container">
            <div class="tabs_container"> CERTIFICATE RECEIVED & DELIVERY ENTRY FORM <hr /></div>     
            <asp:HiddenField ID="hdnEnrollUnit" runat="server" /> 

            <table class="tbldecoration" style="width:auto; float:left;">    
   
            <tr class="tblroweven">    
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Employee Search :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSearchAssignedTo" runat="server" AutoPostBack="true"  CssClass="txtBox" OnTextChanged="txtSearchAssignedTo_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchAssignedTo"
                ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender>                 
            </tr> 

            <tr class="tblheader"><td colspan="4">Employee Information :</td></tr>
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Supervisor Name : "></asp:Label></td>
                <td><asp:TextBox ID="txtSupervisorName" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>
               
                <td style="text-align:right;"><asp:Label ID="lblSupervisorDesignation" CssClass="lbl" runat="server" Text="Supervisor Designation : "></asp:Label></td>
                <td><asp:TextBox ID="txtSupervisorDesignation" BackColor="LightGray" runat="server" CssClass="txtBox" Enabled="true" ReadOnly="true" ></asp:TextBox></td>               
            </tr>

            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="lblEmpCode" CssClass="lbl" runat="server" Text="Employee Code : "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpCode" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>  
          
                <td style="text-align:right;"><asp:Label ID="lblBasic" CssClass="lbl" runat="server" Text="Basic Salary : "></asp:Label></td>
                <td><asp:TextBox ID="txtBasic" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>               
            </tr>
         
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="lblEmpEnroll" CssClass="lbl" runat="server" Text="Enroll : "></asp:Label></td>
                <td><asp:TextBox ID="txtEmpEnroll" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       

                <td style="text-align:right;"><asp:Label ID="lblGross" CssClass="lbl" runat="server" Text="Gross Salary : "></asp:Label></td>
                <td><asp:TextBox ID="txtGross" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>
                               
            </tr> 
        
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="lblName" CssClass="lbl" runat="server" Text="Employee Name : "></asp:Label></td>
                <td><asp:TextBox ID="txtName" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>

                <td style="text-align:right;"><asp:Label ID="lblJoiningDate" CssClass="lbl" runat="server" Text="Joining Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtJoiningDate" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>                     
            </tr>  
        
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
                <td><asp:TextBox ID="txtDesignation" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       

                <td style="text-align:right; "><asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                <td><asp:TextBox ID="txtJobStation" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       
            </tr> 
       
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                <td><asp:TextBox ID="txtDept" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>

                 <td style="text-align:right;"><asp:Label ID="lblContact" CssClass="lbl" runat="server" Text="Phone No. : "></asp:Label></td>
                <td><asp:TextBox ID="txtPhoneNo" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       
            </tr>
        
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="lblSeparateType" CssClass="lbl" runat="server" Text="Certificate Type : "></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlCertificateType" runat="server" AutoPostBack="true" CssClass="ddList" Width="218">
                    <asp:ListItem Selected="True" Value="1">Secendary</asp:ListItem>
                    <asp:ListItem Value="2">Higher Secendary</asp:ListItem>
                    <asp:ListItem Value="3">Diploma</asp:ListItem>
                    <asp:ListItem Value="4">Bachelors</asp:ListItem>
                    <asp:ListItem Value="5">Masters</asp:ListItem>
                    <asp:ListItem Value="6">Others</asp:ListItem>
                    </asp:DropDownList>            
                </td>

                <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Certificate Serial No. : "></asp:Label></td>
                <td><asp:TextBox ID="txtCertificateSerial" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>                
            </tr>    
       
            <tr class="tblroweven">  
                <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Registration No. : "></asp:Label></td>
                <td><asp:TextBox ID="txtRegNo" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
        
                <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Roll No. : "></asp:Label></td>
                <td><asp:TextBox ID="txtRollNo" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>                
            </tr>  
            <tr class="tblroweven"> 
                <td style="text-align:right;"><asp:Label ID="lblRecDate" runat="server" CssClass="lbl" Text="Received Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtRecDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtRecDate"></cc1:CalendarExtender></td>                                
        
                <td style="text-align:right;"><asp:Label ID="lblDelDate" runat="server" CssClass="lbl" Text="Delivery Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtDeliveryDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeliveryDate"></cc1:CalendarExtender></td>                                               
            </tr> 
            <tr class="tblroweven">
                <td colspan="4"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="  Save  " OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click" /></td>                        
            </tr>

            </table>    
            </div>
    </td></tr>
    <tr><td>
            <table>
            <tr><td colspan="6" style="font-weight:bold; font-size:11px;">CERTIFICATE RECEIVE REPORT<hr /></td></tr>
            <tr><td> 
                <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>       
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
         
                <asp:TemplateField HeaderText="Reff No." ItemStyle-HorizontalAlign="left" SortExpression="ReffNo" >
                <ItemTemplate><asp:Label ID="lblReffNo" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("ReffNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
         
                <asp:TemplateField HeaderText="Enroll" ItemStyle-HorizontalAlign="center" SortExpression="intEmployeeID" >
                <ItemTemplate><asp:Label ID="lblEnroll" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intEmployeeID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
         
                <asp:TemplateField HeaderText="Employee Code" ItemStyle-HorizontalAlign="left" SortExpression="strEmployeeCode" >
                <ItemTemplate><asp:Label ID="lblEmpCode" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strEmployeeCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                  
                <asp:TemplateField HeaderText="Search" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strEmployeeName" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
                <HeaderTemplate><asp:Label ID="lblAssignBy" runat="server" CssClass="lbl" Text="Employee Name" Font-Bold="true" Font-Size="10px"></asp:Label>
                <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Employee" runat="server"  width="160" placeholder="Search Employee" onkeyup="Search_dgvservice(this, 'dgvReport')"></asp:TextBox>        
                </HeaderTemplate>
                <ItemTemplate><asp:Label ID="lblTaskTile" runat="server" Width="160px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strEmployeeName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
          
                <asp:TemplateField HeaderText="Designation" ItemStyle-HorizontalAlign="left" SortExpression="strDesignation" >
                <ItemTemplate><asp:Label ID="lblDesig" runat="server" Width="130px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strDesignation")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
        
                <asp:TemplateField HeaderText="Department" ItemStyle-HorizontalAlign="left" SortExpression="strDepatrment" >
                <ItemTemplate><asp:Label ID="lblDept" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strDepatrment")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
      
                <asp:TemplateField HeaderText="Job Station" ItemStyle-HorizontalAlign="left" SortExpression="strJobStationName" >
                <ItemTemplate><asp:Label ID="lblJobS" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strJobStationName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Joining Date" ItemStyle-HorizontalAlign="center" SortExpression="dteJoiningDate" >
                <ItemTemplate><asp:Label ID="lblJDate" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteJoiningDate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
         
                <asp:TemplateField HeaderText="Phone No." ItemStyle-HorizontalAlign="left" SortExpression="strContactNo1" >
                <ItemTemplate><asp:Label ID="lblPhone" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strContactNo1")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
    
                <asp:TemplateField HeaderText="Certificate Type" ItemStyle-HorizontalAlign="left" SortExpression="strCerfificate" >
                <ItemTemplate><asp:Label ID="lblCType" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strCerfificate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
          
                <asp:TemplateField HeaderText="CSerial" ItemStyle-HorizontalAlign="left" SortExpression="strCertificateSerialNo" >
                <ItemTemplate><asp:Label ID="lblCSerial" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strCertificateSerialNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
         
                <asp:TemplateField HeaderText="Reg No." ItemStyle-HorizontalAlign="left" SortExpression="strRegNo" >
                <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strRegNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
          
                <asp:TemplateField HeaderText="Roll No." ItemStyle-HorizontalAlign="left" SortExpression="strRollNo" >
                <ItemTemplate><asp:Label ID="lblRollNo" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strRollNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
          
                <asp:TemplateField HeaderText="Received Date" ItemStyle-HorizontalAlign="center" SortExpression="dteReceivedDate" >
                <ItemTemplate><asp:Label ID="lblRDate" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteReceivedDate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
       
                <asp:TemplateField HeaderText="Delivery Date" Visible="false" ItemStyle-HorizontalAlign="center" SortExpression="dteDeliveryDate" >
                <ItemTemplate><asp:Label ID="lblDDate" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteDeliveryDate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
       
                <asp:TemplateField HeaderText="Active Status" ItemStyle-HorizontalAlign="center" SortExpression="Active" >
                <ItemTemplate><asp:Label ID="lblAStatus" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("Active")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
     
                <asp:TemplateField HeaderText="Salary Hold" ItemStyle-HorizontalAlign="center" SortExpression="SalaryHold" >
                <ItemTemplate><asp:Label ID="lblHold" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("SalaryHold")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
         
                </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
            </td></tr>
            </table>

    </td></tr>
    </table>











    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>