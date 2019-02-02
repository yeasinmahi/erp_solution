<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemEnlistment.aspx.cs" Inherits="UI.Inventory.ItemEnlistment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
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

      <script>
          $(document).ready(function () {
              SearchTextemp();
          });
          function Changed() {
              document.getElementById('HdfSearchbox').value = 'true';
          }
          function SearchTextemp() {
              $("#txtItemName").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          type: "POST",
                          contentType: "application/json;",
                          url: "ItemEnlistment.aspx/GetAutoCompleteDataemp",
                          data: "{'strSearchKeyemp':'" + document.getElementById('txtItemName').value + "'}",
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


    <style type="text/css">
        .auto-style1 {
            width: 78px;
        }

        .ddList {
            height: 22px;
        }

        .auto-style6 {
            text-decoration: underline;
        }

        .auto-style7 {
            width: 28px;
        }

        .auto-style8 {
            height: 23px;
        }

        .txtBox {
        }
    </style>

</head>
<body>
    <form id="frmselfresign" runat="server">
   
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
   
<%--=========================================Start My Code From Here===============================================--%>
   <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>  
        <div class="leaveApplication_container"> 
       <div class="tabs_container"> <span class="auto-style6"><strong>
           <asp:HiddenField ID="HdfSearchbox" runat="server" />
           <asp:HiddenField ID="hdnconfirm" runat="server" />
           Item Enlistment </strong></span> <hr /></div>
        

        <table  class="tbldecoration" style="width:auto; float:left;">
        

        <tr><td colspan="4"><hr style="height: -12px" /></td></tr> 

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblItemName" runat="server" CssClass="lbl" Text="Item Base Name:"></asp:Label></td>
           <%-- <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="txtItemName1" onchange="javascript: Changed();" runat="server" CssClass="txtBox" Width="190px" 
                BackColor="#DCDADA" BorderColor="Gray" Height="17px" OnTextChanged="txtItemName_TextChanged"></asp:TextBox></td>--%>
             <td style="text-align:left;">
                 <asp:TextBox ID="txtItemName" onchange="javascript: Changed();"  runat="server" CssClass="txtBox" Width="190px" BackColor="#DCDADA" BorderColor="Gray" Height="17px" ></asp:TextBox>
             </td>
            
           
            
            <td style="text-align:right;"><asp:Label ID="lblCluster" runat="server" CssClass="lbl" Text="Cluster :"></asp:Label></td>
            <td style="text-align:left;" class="auto-style1"><asp:DropDownList ID="ddlCluster" CssClass="ddList" AutoPostBack="true" Font-Bold="False" BackColor="LightGray" BorderColor="Gray" runat="server" Width="195px" OnSelectedIndexChanged="ddlCluster_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList></td>                                      
            
            <td style="text-align:right;" class="auto-style7">&nbsp;</td> 
            <td style="text-align:right;"><asp:Label ID="lblSearch" runat="server" CssClass="lbl" Text="Search :"></asp:Label></td>
            
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox" Width="248px" Height="19px" BackColor="#EAE8E8" BorderColor="Gray" ForeColor="Black"></asp:TextBox>                                             
            <td style="text-align:right;"><asp:Button ID="btnSearch" runat="server" class="nextclick" Font-Bold="true" ForeColor="white"  Text="Search" style="background-color: gray" OnClick="btnSearch_Click" /></td>
        </tr>

          <tr>
            <td style="text-align:right;"><asp:Label ID="lblDescription" runat="server" CssClass="lbl" Text="Item Description:"></asp:Label></td>
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox" Width="190px" Height="17px" BackColor="#DCDADA" BorderColor="Gray" ></asp:TextBox></td>
            

            <td style="text-align:right;"><asp:Label ID="lblCommodity" runat="server" CssClass="lbl" Text="Commodity:"></asp:Label></td>
            <td style="text-align:left;" class="auto-style1"><asp:DropDownList ID="ddlCommodity" CssClass="ddList" Font-Bold="False" AutoPostBack="true" BackColor="LightGray" BorderColor="Gray" runat="server" Width="195px" OnSelectedIndexChanged="ddlCommodity_SelectedIndexChanged" ForeColor="Black"></asp:DropDownList></td>                                      
            <td style="text-align:right;"></td>
              <td style="text-align:right;" colspan="3"; rowspan="6" >
                <asp:ListBox ID="ListBox1" runat="server" Height="200px" Width="400px"></asp:ListBox>
              </td>
          </tr>

            <tr>
            <td style="text-align:right;"><asp:Label ID="lblPartNo" runat="server" CssClass="lbl" Text="Part/Serial:"></asp:Label></td>
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="txtPartNo" runat="server" CssClass="txtBox" Width="190px" Height="17px" BackColor="#DCDADA" BorderColor="Gray"  ></asp:TextBox></td>
            

            <td style="text-align:right;"><asp:Label ID="lblCategory" runat="server" CssClass="lbl" Text="Category :"></asp:Label></td>
            <%--<td style="text-align:left;" ><asp:DropDownList ID="ddlCategory1" CssClass="ddList" Font-Bold="False" BackColor="LightGray"
                 BorderColor="Gray" AutoPostBack="true" runat="server" Width="195px" ForeColor="Black" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList></td>                                      --%>
         <td style="text-align:left;" >



                 <asp:DropDownList ID="ddlCategory" CssClass="ddList" Font-Bold="false" BackColor="LightGray"  runat="server"  BorderColor="Gray" AutoPostBack="true" Width="195px" ForeColor="Black" 
                    OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" ></asp:DropDownList>
             </td> 

            </tr>
                <tr>        <td style="text-align:right;"><asp:Label ID="lblModel" runat="server" CssClass="lbl" Visible="True" Text="Model :"></asp:Label></td>
            <td style="text-align:left;" ><asp:TextBox ID="txtModel" runat="server" CssClass="txtBox" Width="190px" Height="17px" BackColor="#DCDADA" BorderColor="Gray"></asp:TextBox></td>  
                
                <td style="text-align:right;"><asp:Label ID="lblUoM" runat="server" CssClass="lbl" Text="UoM :"></asp:Label></td>
            <td style="text-align:left;" ><asp:DropDownList ID="ddlUoM" CssClass="ddList" Font-Bold="False" 
                BackColor="LightGray" BorderColor="Gray" runat="server" Width="195px" ForeColor="Black"></asp:DropDownList></td>  
                
                </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblBrand" runat="server" CssClass="lbl" Text="Brand :"></asp:Label></td>
            <td style="text-align:left;" ><asp:TextBox ID="txtstrBrand" runat="server" CssClass="txtBox" Width="190px" Height="17px" BackColor="#DCDADA" BorderColor="Gray"></asp:TextBox>                                                                                       
            </td>
            <td style="text-align:right;"><asp:Label ID="lblProcureType" runat="server" Visible="true" CssClass="lbl" Text="Procure Type :"></asp:Label></td>
            <td style="text-align:left;" ><asp:DropDownList ID="ddlProcureType" Visible="true" CssClass="ddList" Font-Bold="False" 
                BackColor="LightGray" BorderColor="Gray" runat="server" Width="195px" ForeColor="Black"></asp:DropDownList></td>  
                                             

        </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblOrigin" runat="server" Visible="true" CssClass="lbl" Text="Origin :"></asp:Label></td>
             <td style="text-align:left;" ><asp:TextBox ID="txtOrigin" runat="server" CssClass="txtBox" Width="190px" Height="17px" BackColor="#DCDADA" BorderColor="Gray"></asp:TextBox></td>  

            <td style="text-align:right;"><asp:Label ID="lblSpecification" runat="server" Visible="true" CssClass="lbl" Text="Specification:"></asp:Label></td>
             <td style="text-align:left;" ><asp:TextBox ID="txtSpecification" runat="server" TextMode="MultiLine" CssClass="txtBox" Width="190px" Height="17px" BackColor="#DCDADA" BorderColor="Gray"></asp:TextBox></td>   
            </tr>
                

               









                     <tr>
                    <td colspan="3" class="auto-style8">
                        
                    </td>
                

                   <td>
                    <asp:Button ID="btnSubmit" runat="server" class="nextclick" Font-Bold="true" ForeColor="white" OnClick="btnSubmit_Click" Text="Submit"  style="background-color: gray;text-align:center" BackColor="#BCBCBC" Width="84px" />
                </td>


                
               </tr>
                <tr>
                    <%--<td colspan="4">
                        <asp:GridView ID="dgvAddItem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" >
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>

                     <asp:BoundField DataField="intID" HeaderText="SL no" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="intID">
                    <ItemStyle HorizontalAlign="center" Width="40px" />
                    </asp:BoundField>

                     <asp:BoundField DataField="strName" HeaderText="Item Base Name" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
                    <ItemStyle HorizontalAlign="center" Width="200px" />
                    </asp:BoundField>

                     <asp:BoundField DataField="strDescription" HeaderText="Description" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strDescription">
                    <ItemStyle HorizontalAlign="center" Width="200px" />
                    </asp:BoundField> 
                                
                    <asp:BoundField DataField="strPartNo" HeaderText="Part No." Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strPartNo">
                    <ItemStyle HorizontalAlign="center" Width="130px" />
                    </asp:BoundField>                          

                    <asp:BoundField DataField="strBrand" HeaderText="Brand" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strBrand">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>  

                    <asp:BoundField DataField="strUoM" HeaderText="UoM" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strUoM">
                    <ItemStyle HorizontalAlign="center" Width="40px" />
                    </asp:BoundField>  

                    <asp:BoundField DataField="strCluster" HeaderText="Cluster" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strCluster">
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    </asp:BoundField>  
                                
                    <asp:BoundField DataField="strComGroupName" HeaderText="Commodity" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strComGroupName">
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    </asp:BoundField>  
                                
                                
                    <asp:BoundField DataField="strCategory" HeaderText="Category" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="strCategory">
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    </asp:BoundField>                                  
                                
                                
                                
                                                                
                                <asp:CommandField ControlStyle-Font-Bold="true" ControlStyle-ForeColor="red" ShowDeleteButton="true" />
                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                       <%-- <hr />--%>
                    </td>
                </tr>
                </Columns>
                <tr>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:gridview>

                </tr>
            </tr> 
         
                 
              
            </td>
            <tr style="background-color:lightgray">


                  <td colspan="8">
                   <hr />
                      <%-- <asp:Button ID="btnApprove" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" OnClick="btnApprove_Click" OnClientClick="ConfirmAll()" Text="Approve" style="background-color: #FFFFCC" />--%>
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

