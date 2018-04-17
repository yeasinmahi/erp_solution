<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllAchievementReportHo.aspx.cs" Inherits="UI.Dairy_HO.AllAchievementReportHo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <style type="text/css">
        .auto-style2 {
            width: 4px;
        }
        .auto-style3 {
            height: 15px;
        }
        .auto-style4 {
            width: 15%;
            height: 15px;
        }
        .auto-style5 {
            height: 15px;
            width: 4px;
        }
    </style>
         <script>
             $(document).ready(function () {
                 SearchText();
             });
             function Changed() {
                 document.getElementById('hdfSearchBoxTextChange').value = 'true';
             }
             function SearchText() {
                 $("#txtVehicleno").autocomplete({
                     source: function (request, response) {
                         $.ajax({
                             type: "POST",
                             contentType: "application/json;",
                             url: "CorpPendingView.aspx/GetAutoCompleteData",
                             data: '{"strSearchKey":"' + document.getElementById('txtVehicleno').value + '"}',
                             dataType: "json",
                             success: function (data) {
                                 response(data.d);
                             },
                             error: function (result) {

                             }
                         });
                     }
                 });
             }
    </script>

      <script>
          $(document).ready(function () {
              SearchTexts();
          });
          function Changeds() {
              document.getElementById('hdfSearchBoxTextChange').value = 'true';
          }
          function SearchTexts() {
              $("#txtdrivername").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          type: "POST",
                          contentType: "application/json;",
                          url: "CorpPendingView.aspx/GetAutoCompleteDatas",
                          data: '{"strSearchKey":"' + document.getElementById('txtdrivername').value + '"}',
                          dataType: "json",
                          success: function (data) {
                              response(data.d);
                          },
                          error: function (result) {

                          }
                      });
                  }
              });
          }
    </script>
     <script> function CloseWindow() {
     window.close();
 }

    </script>
</head>
<body>
    <form id="frmshvssls" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
       <CompositeScript>
           <Scripts>
               <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

           </Scripts>
       </CompositeScript>

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;">

    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
        <asp:HiddenField ID="HdfSearchbox" runat="server" /><asp:HiddenField ID="HdfTechnicinCode" runat="server" />
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
        <asp:HiddenField ID="hdndriver" runat="server" />
        
        
        
        
        
    <table  style="width:100%;height:2px;background-color:#e0dada">
    
    <tr class="tblroweven" > 
        
    <td style="text-align:justify;width:100%; font-size:12px; background-color:white;" " >
    
    <center>
      
    <div  id="topbox">  
      <h3 class="td">Achievement Details Report</h3>      
    </div>
        
      
       
         
        
   
            </td>
    </tr> 
    </table>
    <div style="width:100%">
        <table style="width:100%;background-color:#e0dada"  >
            <tr>
                <td style="text-align:right" class="auto-style3">
                    
                
                    </td>
                <td class="auto-style3" width="500px" style="text-align:right;">Total Number Of Working Day :</td>
   
                <td class="auto-style3" width="300px" style="text-align:right;">
                    <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                    &nbsp;</td>
                <td class="auto-style4">Area&nbsp; :

                                            </td>
                
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList1" CssClass="txtBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                    </asp:DropDownList>
                    
                   
              </td>
            


                    
                
                
                           
            <td class="auto-style5">
                <asp:Label ID="Label1" Width="200px" runat="server" Text="Label"></asp:Label>
            </td>   

               
                    
               <td style="text-align:right;" class="auto-style3"></td>
             <td class="auto-style3" >
    
                </td>
            </tr>
   <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td class="tbltd" style="text-align:right;">Working Day Spend as on Today's :</td>
   
                <td class="tbltd" style="text-align:right;">
                    <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
                    &nbsp;</td>
                <td style="width:15%" class="tbltd">Territory&nbsp; :

                                            </td>
                
                <td style="width:15%" class="tbltd">
                    <asp:DropDownList ID="DropDownList2" CssClass="txtBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1"></asp:DropDownList>
                    
                    </td>
       
            


                    
                
                
                           
            <td class="auto-style2"></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>        
  <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td class="tbltd" style="text-align:right;">Expected Sales in % against as on Today's Target : </td>
   
                <td style="text-align:right;" class="tbltd">
                    <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                    &nbsp;</td>
                <td style="width:15%" class="tbltd">Point&nbsp; :

                                            </td>
                
                <td style="width:15%" class="tbltd">
                    <asp:DropDownList ID="DropDownList3" CssClass="txtBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged1"></asp:DropDownList>
                </td>
      
            


                    
                
                
                           
            <td class="auto-style2"></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr> 
  <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;" class="tbltd">Required Working Days : </td>
   
                <td style="text-align:right;" class="tbltd">
                    <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                    &nbsp;</td>
                <td style="width:15%" class="tbltd">&nbsp;</td>
                
                <td style="width:15%" class="tbltd">
                    &nbsp;</td>
      
            


                    
                
                
                           
            <td class="auto-style2"></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>                   
     <tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;">&nbsp;</td>
                <td style="width:15%" >&nbsp;</td>
                
                <td style="width:15%" >
                    &nbsp;</td>
         
            


                    
                
                
                           
            <td class="auto-style2"></td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>
<tr>
                <td style="text-align:right" class="auto-style2">
                    
                
                    </td>
                <td style="text-align:right;" >From date :</td>
   
                <td style="text-align:right;" class="auto-style2"><asp:TextBox CssClass="calendar" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><asp:ImageButton ID="ImageButton1" ImageUrl="~/Content/images/img/cal.png" runat="server" Height="17px" Width="35px" OnClick="ImageButton1_Click" />&nbsp;</td>
                <td class="auto-style3" >
                    
                    

                    To date :
                                    
                    
                </td>
                
                <td style="text-align:right" width:15%" class="auto-style2" >
                    <asp:TextBox CssClass="calendar"  ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" ImageUrl="~/Content/images/img/cal.png" runat="server" Height="16px" Width="38px" OnClick="ImageButton2_Click" />
                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click1" style="height: 29px" />
               

                    &nbsp;</td>
            


                    
                
                
                           
            <td class="auto-style2">
                </td>   

               
                    
               <td style="text-align:right;" class="auto-style2"></td>
             <td class="auto-style2" >
    
                </td>
            </tr>
<tr style="height:15px">
                <td style="text-align:right">
                    
                
                    &nbsp;</td>
                <td style="text-align:right;"></td>
   
                <td style="text-align:right;">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="95px" OnSelectionChanged="Calendar1_SelectionChanged" Width="136px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    &nbsp;</td>
                <td style="width:15%" >
                    
                </td>
                
                <td style="width:15%" >
                    
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" OnSelectionChanged="Calendar2_SelectionChanged" Width="144px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>


                    &nbsp;</td>
            


                    
                
                
                           
            <td class="auto-style2">

                
                

                
            </td>   

               
                    
               <td style="text-align:right;">&nbsp;</td>
             <td >
    
                </td>
            </tr>
        </table>
       </center>
            
        
            
        
      </div> 
       <table class="" style="width:100%; height:auto ">
    
    <tr style="width:100%" > 
        
    <td style="text-align:justify;font-size:16px; background-color:white;" class="auto-style1">
    
    
        <p class="MsoNormal">

            <asp:GridView ID="GridView1" Width="70%" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" Font-Size="Small">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="territory" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="productid" HeaderText="productid" SortExpression="Serical" />
                    <asp:BoundField DataField="strproductname" HeaderText="strproductname" SortExpression="MLQC"  />
                    <asp:BoundField DataField="Total_Target" HeaderText="Total_Target" SortExpression="MQC" DataFormatString="{0:n0}" />
                    <asp:BoundField DataField="Target_Todate" HeaderText="Target_Todate" SortExpression="MQP" DataFormatString="{0:n0}" />
                    <asp:BoundField DataField="Total_Sales" HeaderText="Total_Sales" SortExpression="MHP" DataFormatString="{0:n0}"/>
                    <asp:BoundField DataField="Cum_Ach" HeaderText="Cum_Ach" SortExpression="CQC" DataFormatString="{0:n0}"/>
                        <asp:BoundField DataField="ADT" HeaderText="ADT" SortExpression="CQC" DataFormatString="{0:n0}"/>
                     <asp:BoundField DataField="ADS" HeaderText="ADS" SortExpression="CQC" DataFormatString="{0:n0}"/>
                         <asp:BoundField DataField="RDT" HeaderText="RDT" SortExpression="CQC" DataFormatString="{0:n0}"/>
                         <asp:BoundField DataField="LND" HeaderText="LND" SortExpression="LND" DataFormatString="{0:n0}"/>
                 
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>


          </p>
       
         
        
   
            </td>
    </tr> 
    </table>
        
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

