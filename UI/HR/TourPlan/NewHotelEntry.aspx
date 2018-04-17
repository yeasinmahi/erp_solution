<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewHotelEntry.aspx.cs" Inherits="UI.HR.TourPlan.NewHotelEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtHotelName = document.forms["frmdtls"]["txtHotelName"].value;
            var txtAddress = document.forms["frmdtls"]["txtAddress"].value;
            var txtPhone = document.forms["frmdtls"]["txtPhone"].value;

            if (txtHotelName == null || txtHotelName == "") { alert("Please enter Hotel Name ."); }
            else if (txtAddress == null || txtAddress == "") { alert("Please enter Address."); }
            else if (txtPhone == null || txtPhone == "") { alert("Please enter Phone."); }
            else { document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>
</head>
<body>
    <form id="frmdtls" runat="server">
  

<%--=========================================Start My Code From Here===============================================--%>

        <div class="leaveApplication_container"> 
    <div class="tabs_container"> Add a new Hotel  :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnofficeEmail" runat="server"/>
      
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    
            <tr class="tblroweven">
                <td><asp:Label ID="lblHotelName" runat="server" Text="Hotel Name"></asp:Label></td>
                <td ><asp:TextBox ID="txtHotelName"  BackColor="#ffffcc" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblAddress" runat="server" Text="Address" ></asp:Label></td>
                <td><asp:TextBox ID="txtAddress"  BackColor="#ffffcc"  runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr class="tblrowodd">
                <td><asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtPhone"  BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblDistrict"  runat="server"  Text="District"></asp:Label></td>
               <td><asp:DropDownList ID="drdlDistrict" runat="server" DataSourceID="odsTourDistrictList" DataTextField="strDistrict" DataValueField="intDistrictID" AutoPostBack="true"></asp:DropDownList>
                   <asp:ObjectDataSource ID="odsTourDistrictList" runat="server" SelectMethod="getTourDistrictName" TypeName="HR_BLL.TourPlan.TourPlanning"></asp:ObjectDataSource>
                    </td>
                     
                </tr>
               <tr class="tblroweven">
                <td><asp:Label ID="lblThanaName"  runat="server"  Text="ThanaName"></asp:Label></td>
               <td><asp:DropDownList ID="drdlThanaName" runat="server" DataSourceID="odsTourThanaName" DataTextField="strThana" DataValueField="intThanaID"></asp:DropDownList>
                   <asp:ObjectDataSource ID="odsTourThanaName" runat="server" SelectMethod="getTourThanaName" TypeName="HR_BLL.TourPlan.TourPlanning">
                       <SelectParameters>
                           <asp:ControlParameter ControlID="drdlDistrict" Name="Districtid" PropertyName="SelectedValue" Type="Int32" />
                       </SelectParameters>
                   </asp:ObjectDataSource>
                   </td>
                <td><asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarks"  BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                  
               </tr>
             <tr class="tblrowodd">
                 
                  <td>
                      <asp:Label ID="lblRegionName" runat="server" Text="Region"></asp:Label>

                  </td>
                 <td>
                     <asp:DropDownList ID="drdlRegionName" runat="server" DataSourceID="odsTourRegionforHotel" DataTextField="strRegionName" DataValueField="intRegionid"></asp:DropDownList>
                     <asp:ObjectDataSource ID="odsTourRegionforHotel" runat="server" SelectMethod="getRegionName" TypeName="HR_BLL.TourPlan.TourPlanning">
                         <SelectParameters>
                             <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                             <asp:SessionParameter Name="strOfficeEmail" SessionField="sesEmail" Type="String" />
                         </SelectParameters>
                     </asp:ObjectDataSource>
                 </td>

                

                 <td>
                     <asp:Button ID="btnTourAdd" runat="server" Text="Add" Font-Bold="true"  OnClientClick="Confirm()"  OnClick="btnTourAdd_Click"/>
                     <asp:HiddenField ID="hdnconfirm" runat="server" />
                 </td>
                  <td>
                     <asp:Button ID="btnTourSubmit" runat="server" Text="Submit" OnClick="btnTourSubmit_Click" />
                 </td>
             </tr>


            </table>
            </div>
         <div>
            <table>
                <tr class="tblroweven">
                    <td>
                          <asp:GridView ID="grdvHotelEntry" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvHotelEntry_SelectedIndexChanged" OnRowDeleting="grdvHotelEntry_RowDeleting" >
                        <Columns>
                               <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdndistrictid" runat="server" Value='<%# Bind("districtid") %>' /></ItemTemplate></asp:TemplateField> 
                            <asp:BoundField DataField="hotelname" HeaderText="HotelName" SortExpression="hotelname" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" />
                            <asp:BoundField DataField="districtid" HeaderText="districtid" SortExpression="districtid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" Visible="false" />
                            <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="thanaid" HeaderText="thanaid" SortExpression="thanaid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" Visible="false" />
                            <asp:BoundField DataField="remarks" HeaderText="remarks" SortExpression="remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="districtName" HeaderText="DistrictName" SortExpression="districtName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                             <asp:BoundField DataField="thananame" HeaderText="Thananame" SortExpression="thananame" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            
                            
                            <asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True"  />
                            
                             </Columns>
                              </asp:GridView>

                    </td>

                </tr>

            </table>

        </div>



<%--=========================================End My Code From Here=================================================--%>
    </form>
</body>
</html>