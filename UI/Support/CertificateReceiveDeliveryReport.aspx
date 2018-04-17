<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificateReceiveDeliveryReport.aspx.cs" Inherits="UI.Support.CertificateReceiveDeliveryReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
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
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    
    <script language="javascript" type="text/javascript">
    function ExportDivDataToExcel() {
        var html = $("#divExport").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $("input[id$='HdnValue']").val(html);
    }
 </script>
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <form id="frmcafr" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
    <%--<br /><br /><br /><br /><br /><br /><br />--%>
    <asp:HiddenField ID="hdnEnroll" runat="server" />
    <table style="width:auto; float:left;">
    <tr><td>        
        <div class="leaveApplication_container">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style="color:black; text-align:center; font-size:18px"> CERTIFICATE RECEIVED & DELIVERY REPORT </td></tr>

        <%--<tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="false"></asp:DropDownList>                                                                                       
        </td>
        <td colspan="2" style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text=""></asp:Label></td>
        </tr>--%>

        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtFDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate"></cc1:CalendarExtender></td>  
            
        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtTDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTDate"></cc1:CalendarExtender></td>  
        </tr> 
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Report Type :"></asp:Label></td>
            <td >
                <asp:RadioButton ID="RadioButton1" Text=" All      " GroupName="SMS" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
                <asp:RadioButton ID="RadioButton2" Text=" Pending      " GroupName="SMS" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" />
                <asp:RadioButton ID="RadioButton3" Text=" Delivered" GroupName="SMS" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" />
            </td>

            <td colspan="2" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Green" Font-Bold="true" Text="Show" OnClientClick="LoaderBusy()" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr class="tblrowodd">
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnExport" runat="server" CssClass="nextclick" ForeColor="Green" Font-Bold="true" Text="Export To Excel" OnClick="btnExport_Click" OnClientClick="ExportDivDataToExcel()"/></td>   
            
        </tr>
        </table>
        </div>
    </td></tr>
    <tr><td>    
        <div id="divExport">  
        <table>  
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
                     
        <tr><td  style="text-align:justify;"><hr />
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
       
            <asp:TemplateField HeaderText="Delivery Date" ItemStyle-HorizontalAlign="center" SortExpression="dteDeliveryDate" >
            <ItemTemplate><asp:Label ID="lblDDate" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteDeliveryDate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
       
            <asp:TemplateField HeaderText="Active Status" ItemStyle-HorizontalAlign="center" SortExpression="Active" >
            <ItemTemplate><asp:Label ID="lblAStatus" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("Active")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
     
            <asp:TemplateField HeaderText="Salary Hold" ItemStyle-HorizontalAlign="center" SortExpression="SalaryHold" >
            <ItemTemplate><asp:Label ID="lblHold" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("SalaryHold")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td>
        </tr>         
        </table>
        <asp:HiddenField ID="HdnValue" runat="server" />
        </div>
    </td></tr>
    </table>

    <div class="loading" align="center">
        <%--Loading. Please wait.</hr><br />--%> 
        <%--<img src="../Content/Images/imagesCAAL9MHY.jpg" /> --%>
        <%--<img src="../Content/Images/imagesCAU8JX1Y.png" />--%>
        <%--<img src="../Content/Images/imagesCA35MWNI.png" /> --%>         
        <%--<img src="../../Content/images/gicon/loader.gif" />--%>
        <img src="../../Content/images/gicon/Final-Product-2.GIF" />
    </div>
    

    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>