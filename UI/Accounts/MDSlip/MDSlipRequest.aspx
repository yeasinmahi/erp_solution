<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.MDSlip.MDSlipRequest" Codebehind="MDSlipRequest.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  

    <style type="text/css">
       .cln
        {
       
          
          top:100 px
         
          
        }
    </style>
    <script language="JavaScript" src="../../Content/JS/CountDown.js"></script>
    <script type="text/javascript">
    function SubmitRequest()
    {
        var e=document.getElementById('ddlUnit');
        

         var date=document.getElementById('txtFrom').value;
         var unit=e.options[e.selectedIndex].value;
         alert(unit);
         //var userID='1'
         var obj=document.getElementById('frmRequestSubmit');
         obj.action='MDSlipRequestHandler.aspx?rdate='+date+'&unit='+unit;
         obj.submit();
    }
    
    function ShowStatus(waitTime)
    {
        document.getElementById('generateButton').style.display="none";
        
        var prifixString='Your Request Have Submitted.......<br> Please Wait :';
        var fmsg='MD Slip Precess Ends....';
        StartTimeCalc(prifixString,fmsg,waitTime);
        
        
    }
    
    function VisibleCalender()
    {
        document.getElementById('Calendar1').style.display='block'
    }
    
    
    </script>
</head>
<body>
     <iframe  height="0" id="addEdit" name="addEdit" src="" width="0">
    </iframe>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
      <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table width="90%">
                        <tr>
                            <td align="left" class="PageHeader">
                                MD Slip Request
                            </td>
                            <td align="left">
                                Unit
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits"
                                    TypeName="HR_BLL.Global.Unit" 
                                    OldValuesParameterFormatString="original_{0}">
                                     <SelectParameters>
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
                                   
                            </td>
                            <td align="center">
                                Date
                                <%--<cc1:CalendarExtender ID="CalendarExtender1"  CssClass="cal_Theme1" runat="server" 
                                    ondatabinding="CalendarExtender1_DataBinding" TargetControlID="txtFrom" 
                                    >
                                </cc1:CalendarExtender>--%>
                                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                <%--<cc1:CalendarExtender CssClass="cal_Theme1"    ID="CalendarExtender1" runat="server" EnableViewState="true"
                                    Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                                </cc1:CalendarExtender>--%>
                                <%--<a href="#" onclick="VisibleCalender()">
                                <img id="imgCal_1" src="../../App_Themes/Default/images/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                 </a>--%>
                                <asp:ImageButton ID="ImageButton1" ImageUrl="../../Content/images/img/calbtn.gif" 
                                    style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;"  runat="server" 
                                    onclick="ImageButton1_Click" />
                                    <br />
                                <asp:Calendar style="position:absolute; z-index:10;" ID="Calendar1"  runat="server" 
                                    onselectionchanged="Calendar1_SelectionChanged" Visible="false"></asp:Calendar>
                                </td>
                            <td align="right">
                               <a id="generateButton"  href="#" onclick="SubmitRequest()" >
                                   <asp:Label ID="Label1" runat="server" ></asp:Label>
                               </a>
                            </td>
                            <td align="left">                                
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
    
    <div>
        <asp:Label ID="lblCountDown" runat="server"></asp:Label> 
    </div>
    
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" ondatabound="GridView1_DataBound">
            <Columns>
                <asp:BoundField DataField="dteRequestDate" HeaderText="Request Date" 
                    SortExpression="dteRequestDate" />
                <asp:BoundField DataField="strResult" HeaderText="Action" 
                    SortExpression="strResult" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetMDSlipRequestLogByUnit" 
            TypeName="BLL.Accounts.MDSlip.MDSlipLog">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="Calendar1" Name="datetime" PropertyName="SelectedDate" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
    
     <form name="frmRequestSubmit" action="" id="frmRequestSubmit" method="post" target="addEdit" style="display: none">
    </form>
</body>
</html>
