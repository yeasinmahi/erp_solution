<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADATourAdvance.aspx.cs" Inherits="UI.SAD.Order.RemoteTADATourAdvance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>

     <script>

         function isNumber(evt) {
             var iKeyCode = (evt.which) ? evt.which : evt.keyCode
             if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                 return false;

             return true;
         }

  function RemoveRow(item) {
            var table = document.getElementById('GridView1');
            table.deleteRow(item.parentNode.parentNode.rowIndex);
            return false;
        }

  </script>

     <script type="text/javascript">
         $(document).ready(function () {
             SearchText();
         });
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtFullName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "RemoteTADATourAdvance.aspx/GetAutoCompleteDataForTADA",
                         data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert("Error");
                         }
                     });
                 }
             });
         }


    </script>





   

    <script type="text/javascript">

        $('input.required').each(function () {

            $(this).prev('label').after('*');

        });



    </script>



</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>

<%--=========================================Start My Code From Here===============================================--%>
          <div class="leaveApplication_container"> 
    <div class="tabs_container"> TA - DA Tour Advance Form  :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnaplenr" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblrowOdd">
        <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label> </td>
            <td>
                <asp:RadioButtonList ID="rdbUserOption" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbUserOption_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Own" Value="0"></asp:ListItem>
                    <asp:ListItem Selected="True"  Text="Other" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
           
            <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
           <td> <asp:TextBox ID="txtFullName" runat="server"  CssClass="txtBox"></asp:TextBox> </td>

             </tr>


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Tour Start Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate"  placeholder="Click for date" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox> <span style="color:red">*</span>
        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Tour  End Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate"  placeholder="Click For date" runat="server" CssClass="txtBox" AutoPostBack="false" Enabled="true" autocomplete="off"></asp:TextBox> <span style="color:red">*</span>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>       
    
             </tr>
 <tr class="tblrowOdd">
      <td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="Tour Start From:  " ></asp:Label></td>
       <td> <asp:TextBox ID="txtFromAddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
  <td style="text-align:right"><asp:Label ID="lblMovementArea" CssClass="lbl" runat="server" Text="Tours Area:  " ></asp:Label></td>                 
          <td> <asp:TextBox ID="txtMovementArea" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
 </tr>

         <tr class="tblroweven">
          
             <td style="text-align:right"><asp:Label ID="lblTourPurpouse" CssClass="lbl" runat="server" Text="Purpose of journey:  " ></asp:Label></td>   
              <td> <asp:TextBox ID="txtTourPurpouse" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
               <td style="text-align:right"><asp:Label ID="lblTotal" runat="server" CssClass="lbl" Text=" Advance amount :  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtTotal" runat="server"  AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
             
         </tr>
           </div>  
           
            <div class="leaveApplication_container">
                
             <tr class="tblrowOdd">
                 <td>
                     <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                 </td>
                 <td>
                     <asp:Button ID="btnSubmit" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click1" />
                 </td>
             </tr>
             </table>


           


    </div>   
        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    



                   
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        
                        <Columns>
                            <asp:BoundField DataField="BillDateFrom" HeaderText="From Date" SortExpression="dteFromDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                           <asp:BoundField DataField="BillDateTo" HeaderText="To Date" SortExpression="dteTodate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="fromAddress" HeaderText="From Addr." SortExpression="strForm" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="movementAddress" HeaderText="Moved Area" SortExpression="strMove" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="tourPurpouse" HeaderText="Purpouse" SortExpression="tourPurpouse" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="totalcost" HeaderText="Total Advance" SortExpression="tourPurpouse" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="applicantEnrol" HeaderText="AplEnrol" SortExpression="applicantEnrol" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

                        



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