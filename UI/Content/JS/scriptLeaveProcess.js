

//Employee Leave Application Approved

$(document).ready(function () {
    //document.getElementById("approvedDiv").style.display = "none";
});


function ShowApprovedDiv(appId, empCode, empName, fromDate, toDate, leaveId, leaveType, totalDays, jobType, remainingDays) {
    debugger;
    var dd, mm, yyyy;
    var frmDate = new Date(fromDate);
    dd = frmDate.getDate(); mm = (frmDate.getMonth() + 1); yyyy = frmDate.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    fromDate = yyyy + "-" + mm + "-" + dd;
    document.getElementById("txtCode").innerText = empCode;
    document.getElementById("txtEmployeeName").innerText = empName;
    document.getElementById("txtJobStatus").innerText = jobType;
    document.getElementById("txtLeaveType").innerText = leaveType;
    document.getElementById("txtDteFrom").innerText = fromDate;
    var tDate = new Date(toDate);
    dd = tDate.getDate(); mm = (tDate.getMonth() + 1); yyyy = tDate.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    toDate = yyyy + "-" + mm + "-" + dd;
    document.getElementById("txtDteTo").innerText = toDate;
    document.getElementById("txtRemainingDays").innerText = remainingDays;
    document.getElementById("hdnAppID").value = appId;
    document.getElementById("rdoWithpay").checked == false;
    document.getElementById("rdoLWP").checked == false;

    //$("#approvedDiv").fadeIn("slow");

}


function Confirm() {
    var fromdate = document.forms["frmLeaveApproveProcess"]["txtDteFrom"].value;
    var todate = document.forms["frmLeaveApproveProcess"]["txtDteTo"].value;

    if (fromdate == null || fromdate == "") {
        alert("From date must be filled by valid formate (year-month-day).");
        return false;
    }
    else if (todate == null || todate == "") {
        alert("To date must be filled by valid formate (year-month-day).");
        return false;
    }
    else if ((document.getElementById("rdoWithpay").checked == false) && (document.getElementById("rdoLWP").checked == false)) {
        alert("Please confirm paystatus...");
        return false;
    }
    else {
        return confirm("Do you want to processed this application?");
    }
}

function Reject() {
    return confirm("Do you want to reject this application?");
}