
function Changed() {
    document.getElementById('hdfSearchBoxTextChange').value = 'true';
}
function SearchText() {
    $("#txtEmployeeSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "LeaveApplicationPublic.aspx/GetAutoCompleteData",
                data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
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
function Submit() {

    var fromdate = document.forms["frmLeaveApplicationpublic"]["txtDteFrom"].value;
    var todate = document.forms["frmLeaveApplicationpublic"]["txtDteTo"].value;
    var reason = document.forms["frmLeaveApplicationpublic"]["txtReason"].value;
    var address = document.forms["frmLeaveApplicationpublic"]["txtAddress"].value;

    if (fromdate == null || fromdate == "") {
        alert("From date must be filled by valid formate (year-month-day).");
    }
    else if (todate == null || todate == "") {
        alert("To date must be filled by valid formate (year-month-day).");
    }
    else if (reason.length <= 0 || reason.length > 145) {
        alert("Reason must be filled.");
    }
    else if (address.length <= 0 || address.length > 145) {
        alert("Address due to leave must be filled.");
    }

    else {
        document.getElementById("hdnAction").value = "1";
        __doPostBack();
    }
}
function Update() {
    var fromdate = document.forms["frmLeaveApplicationpublic"]["txtDteFrom"].value;
    var todate = document.forms["frmLeaveApplicationpublic"]["txtDteTo"].value;
    var reason = document.forms["frmLeaveApplicationpublic"]["txtReason"].value;
    var address = document.forms["frmLeaveApplicationpublic"]["txtAddress"].value;

    if (fromdate == null || fromdate == "") {
        alert("From date must be filled by valid formate (year-month-day).");
    }
    else if (todate == null || todate == "") {
        alert("To date must be filled by valid formate (year-month-day).");
    }
    else if (reason.length <= 0 || reason.length > 145) {
        alert("Reason must be filled.");
    }
    else if (address.length <= 0 || address.length > 145) {
        alert("Address due to leave must be filled.");
    }
    else {
        document.getElementById("hdnAction").value = "2";
        __doPostBack();
    }
}



//==========================Leave Application For Personal============

function SearchAddressByGoogle() {
    var options = { componentRestrictions: { country: "bd" } };
    var input = document.getElementById('txtAddress');
    var autocomplete = new google.maps.places.Autocomplete(input, options);
}

function Confirm() {

    var fromdate = document.forms["frmLeaveApplication"]["txtDteFrom"].value;
    var todate = document.forms["frmLeaveApplication"]["txtDteTo"].value;
    var reason = document.forms["frmLeaveApplication"]["txtReason"].value;
    var address = document.forms["frmLeaveApplication"]["txtAddress"].value;

    if (fromdate == null || fromdate == "") {
        alert("From date must be filled by valid formate (year-month-day).");
    }
    else if (todate == null || todate == "") {
        alert("To date must be filled by valid formate (year-month-day).");
    }
    else if (reason.length <= 0 || reason.length > 145) {
        alert("Reason must be filled.");
    }
    else if (address.length <= 0 || address.length > 145) {
        alert("Address due to leave must be filled.");
    }
    else {
        document.getElementById("hdnAction").value = "1";
        __doPostBack();
    }
}

function UpdateControls(appId, fromDate, toDate, address, reason) {
        
        var dd, mm, yyyy;
        var frmDate = new Date(fromDate);
        dd = frmDate.getDate(); mm = (frmDate.getMonth() + 1); yyyy = frmDate.getFullYear();
        if (dd < 10) { dd = "0" + dd; }
        if (mm < 10) { mm = "0" + mm; }
        fromDate = yyyy + "-" + mm + "-" + dd;        
        document.getElementById("txtDteFrom").innerText = fromDate;//frmDate.getFullYear() + "-" + (frmDate.getMonth() + 1) + "-" + frmDate.getDate();

        var tDate = new Date(toDate);
        dd = tDate.getDate(); mm = (tDate.getMonth() + 1); yyyy = tDate.getFullYear();
        if (dd < 10) { dd = "0" + dd; }
        if (mm < 10) { mm = "0" + mm; }
        toDate = yyyy + "-" + mm + "-" + dd;
        document.getElementById("txtDteTo").innerText = toDate;//tDate.getFullYear() + "-" + (tDate.getMonth() + 1) + "-" + tDate.getDate();

        document.getElementById("txtReason").innerText = address;
        document.getElementById("txtAddress").innerText = reason;
        document.getElementById("hdnAppId").value = appId;
}

function UpdateApplication() {
    var fromdate = document.forms["frmLeaveApplication"]["txtDteFrom"].value;
    var todate = document.forms["frmLeaveApplication"]["txtDteTo"].value;
    var reason = document.forms["frmLeaveApplication"]["txtReason"].value;
    var address = document.forms["frmLeaveApplication"]["txtAddress"].value;

    if (fromdate == null || fromdate == "") {
        alert("From date must be filled by valid formate (year-month-day).");
    }
    else if (todate == null || todate == "") {
        alert("To date must be filled by valid formate (year-month-day).");
    }
    else if (reason.length <= 0 || reason.length > 145) {
        alert("Reason must be filled.");
    }
    else if (address.length <= 0 || address.length > 145) {
        alert("Address due to leave must be filled.");
    }
    else {
        document.getElementById("hdnAction").value = "2";
        __doPostBack();
    }
}

function DeleteApplication()
{
    document.getElementById("hdnAction").value = "3";
    __doPostBack();
}

function ResetControls()
{    
    document.getElementById("txtDteFrom").innerText = "";
    document.getElementById("txtDteTo").innerText = "";
    document.getElementById("txtReason").innerText = "";
    document.getElementById("txtAddress").innerText = "";
    document.getElementById("hdnAction").value = "0";
    document.getElementById("hdnAppId").value = "";
}