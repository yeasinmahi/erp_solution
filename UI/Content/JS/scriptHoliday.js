
function Confirm()
{
    document.getElementById("hdnconfirm").value = "0";
    var fromdate = document.forms["frmholiday"]["txtFromDate"].value;
    var todate = document.forms["frmholiday"]["txtToDate"].value;

    if (fromdate == null || fromdate == "") {
        alert("From date must be filled by valid formate (year-month-day).");
    }
    else if (todate == null || todate == "") {
        alert("To date date must be filled by valid formate (year-month-day).");
    }
    else {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }

}