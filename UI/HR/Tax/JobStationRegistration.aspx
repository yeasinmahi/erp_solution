<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobStationRegistration.aspx.cs" Inherits="UI.HR.Tax.JobStationRegistration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Job Station Registration ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtStationName = document.forms["frmstationregistration"]["txtStationName"].value;
            var txtAddress = document.forms["frmstationregistration"]["txtAddress"].value;
            var txtlongitude = document.forms["frmstationregistration"]["txtXcoordinate"].value;
            var txtLatitude = document.forms["frmstationregistration"]["txtYCoordinate"].value;

            if (txtStationName == null || txtStationName == "") {
                alert("Must be filled by valid station name.");
            }
            else if (txtAddress == null || txtAddress == "") {
                alert("Must be filled by valid station address.");
            }
            else if (txtLatitude == null || txtLatitude == "") {
                alert("Must be filled by valid latitude.");
            }
            else if (txtlongitude == null || txtlongitude == "") {
                alert("Must be filled by valid longitude.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
    </script>
</head>
<body>
    <form id="frmstationregistration" runat="server">
   <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    
        <table class="tbldecoration" style="width:auto; float:left; ">
            <tr class="tblheader"><td colspan="4"> New Job-Station Registration :</td></tr><tbody class="noborders">
            <tr class="tblrowodd"><td><asp:Label ID="lblstation" CssClass="lbl" runat="server" Text="Station-Name : "></asp:Label></td>
            <td><asp:TextBox ID="txtStationName" runat="server" CssClass="txtBox" Enabled="true" Text=""></asp:TextBox></td>
            <td><asp:Label ID="lbladdress" CssClass="lbl" runat="server" Text="Station-Address : "></asp:Label></td>
            <td><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" Enabled="true" Text=""></asp:TextBox></td>
            </tr>
            
            <tr class="tblroweven"><td><asp:Label ID="lblx" CssClass="lbl" runat="server" Text="Longitude : "></asp:Label></td>
            <td><input type="text" runat="server" id="txtXcoordinate" class="txtBox" readonly="true"/></td>
            <td><asp:Label ID="lbly" CssClass="lbl" runat="server" Text="Latitude : "></asp:Label></td>
            <td><input runat="server" type="text" id="txtYCoordinate" class="txtBox" readonly="true" /></td></tr>
            
            <tr class="tblroweven">
            <td><asp:Label ID="lblaccuracy" CssClass="lbl" runat="server" Text="Accuracy : "></asp:Label></td>
            <td><input type="text" runat="server" id="txtAccuracy" class="txtBox" readonly="true"/></td>
            <td colspan="2" style="text-align:right;"><asp:HiddenField ID="hdnconfirm" runat="server" />
            <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"></asp:Button>
            <a class="button" href="#" onclick="GetlonXlatY()">GetLocation</a>
            <script>
                function GetlonXlatY() {
                    if (navigator.geolocation) {
                        navigator.geolocation.watchPosition(showPosition, showError, {
                            enableHighAccuracy: true, maximumAge: 1000, timeout: 300000});
                    }
                    else { alert("Geolocation is not supported by this browser."); }
                }

                function showPosition(position) {
                    document.getElementById("txtXcoordinate").value = Math.round(position.coords.longitude);
                    document.getElementById("txtYCoordinate").value = Math.round(position.coords.latitude);
                    document.getElementById("txtAccuracy").value = Math.round(position.coords.accuracy);
                    //alert("Accuracy: " + position.coords.accuracy);
                    var coords = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                    var mapOptions = {
                        zoom: 15,
                        center: coords,
                        mapTypeControl: true,
                        navigationControlOptions: {
                        style: google.maps.NavigationControlStyle.SMALL
                        },
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };
                    map = new google.maps.Map( document.getElementById("mapContainer"), mapOptions );
                    var marker = new google.maps.Marker({
                        position: coords,
                        map: map,
                        title: "You are here !!!"
                    });
                }

                function showError(error) {
                    switch (error.code) {
                        case error.PERMISSION_DENIED:
                            alert("User denied the request for Geolocation.");
                            break;
                        case error.POSITION_UNAVAILABLE:
                            alert("Location information is unavailable.")
                            break;
                        case error.TIMEOUT:
                            alert("The request to get user location timed out.");
                            break;
                        case error.UNKNOWN_ERROR:
                            alert("An unknown error occurred.");
                            break;
                    }
                }
           </script>
            </td></tr> 
            <tr><td colspan="4"><div id="mapContainer" style="width:350px; height:175px; background-color:brown;"></div>
            <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
            </td></tr>
     </tbody></table>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
