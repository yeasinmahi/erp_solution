
function ConfirmAll() {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
}

//*******************************************************

function DHReject() {
    //alert('ok');
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "2"; }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    __doPostBack();
    //ClearControls();
}



//****** Start- Resign Accept Dept. Head ********************************************************************************
function Fillcontrols(empcode, enroll, empname, designation, salary, resignDate, lastdate, lastdateuser, lastdateAuthority, separateName, reason) {
    var dd, mm, yyyy;
    var lastdateuser = new Date(lastdateuser);
    dd = lastdateuser.getDate(); mm = (lastdateuser.getMonth() + 1); yyyy = lastdateuser.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    lastdateuser = yyyy + "-" + mm + "-" + dd;

    var dde, mme, yyyye;
    var lastdateAuthority = new Date(lastdateAuthority);
    dde = lastdateAuthority.getDate(); mme = (lastdateAuthority.getMonth() + 1); yyyye = lastdateAuthority.getFullYear();
    if (dde < 10) { dde = "0" + dde; }
    if (mme < 10) { mme = "0" + mme; }
    lastdateAuthority = yyyye + "-" + mme + "-" + dde;

    var ddr, mmr, yyyyr;
    var resignDate = new Date(resignDate);
    ddr = resignDate.getDate(); mmr = (resignDate.getMonth() + 1); yyyyr = resignDate.getFullYear();
    if (ddr < 10) { ddr = "0" + ddr; }
    if (mmr < 10) { mmr = "0" + mmr; }
    resignDate = yyyyr + "-" + mmr + "-" + ddr;

    var ddl, mml, yyyyl;
    var lastdate = new Date(lastdate);
    ddl = lastdate.getDate(); mml = (lastdate.getMonth() + 1); yyyyl = lastdate.getFullYear();
    if (ddl < 10) { ddl = "0" + ddl; }
    if (mml < 10) { mml = "0" + mml; }
    lastdate = yyyyl + "-" + mml + "-" + ddl;

    document.getElementById("hdnID").value = enroll;
    document.getElementById("txtEmpCode").innerText = empcode;
    document.getElementById("txtEnroll").innerText = enroll;
    document.getElementById("txtEmpName").innerText = empname;
    document.getElementById("txtDesignation").innerText = designation;
    document.getElementById("txtSalary").innerText = salary;
    document.getElementById("txtResignationDate").innerText = resignDate;
    document.getElementById("txtLastWorkingDate").innerText = lastdate;
    document.getElementById("txtLastWorkingDateByUser").innerText = lastdateuser;
    document.getElementById("txtLastWorkingDateByAuthority").innerText = lastdateAuthority;
    document.getElementById("txtSeparateType").innerText = separateName;
    document.getElementById("txtReason").innerText = reason;
    $("#hiddenbox").fadeIn("slow");
}

function DeptHeadAccept() {
    var txtLastWorkingDateByAuthority = document.forms["frmdeptheadaccept"]["txtLastWorkingDateByAuthority"].value;
    var txtEnroll = document.forms["frmdeptheadaccept"]["txtEnroll"].value;
    //alert(txtEnroll);
    if (txtLastWorkingDateByAuthority == null || txtLastWorkingDateByAuthority == "") {
        alert("Please provide valid Date in Last office provide by Dept Head.");
    }
    else {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; __doPostBack(); }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        ClearControls();
    }
}

function ClearControls() {
    $("#hiddenbox").fadeOut("slow");
    document.getElementById("hdnconfirm").value = "0";
    document.getElementById("txtEmpCode").innerText = "";
    document.getElementById("txtEnroll").innerText = "";
    document.getElementById("txtEmpName").innerText = "";
    document.getElementById("txtDesignation").innerText = "";
    document.getElementById("txtSalary").innerText = "";
    document.getElementById("txtResignationDate").innerText = "";
    document.getElementById("txtLastWorkingDate").innerText = "";
    document.getElementById("txtLastWorkingDateByUser").innerText = "";
    document.getElementById("txtLastWorkingDateByAuthority").innerText = "";
    document.getElementById("txtSeparateType").innerText = "";
    document.getElementById("txtReason").innerText = "";
}

//****** End- Resign Accept Dept. Head ********************************************************************************

//****** Start- Resign Realize Dept. Head ********************************************************************************
function FilterControlsRealizeDeptHead(empcode, enroll, empname, designation, salary, resignDate, lastdate, lastdateuser, lastdateAuthority, separateName, reason) {
    var dd, mm, yyyy;
    var lastdateuser = new Date(lastdateuser);
    dd = lastdateuser.getDate(); mm = (lastdateuser.getMonth() + 1); yyyy = lastdateuser.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    lastdateuser = yyyy + "-" + mm + "-" + dd;

    var dde, mme, yyyye;
    var lastdateAuthority = new Date(lastdateAuthority);
    dde = lastdateAuthority.getDate(); mme = (lastdateAuthority.getMonth() + 1); yyyye = lastdateAuthority.getFullYear();
    if (dde < 10) { dde = "0" + dde; }
    if (mme < 10) { mme = "0" + mme; }
    lastdateAuthority = yyyye + "-" + mme + "-" + dde;

    var ddr, mmr, yyyyr;
    var resignDate = new Date(resignDate);
    ddr = resignDate.getDate(); mmr = (resignDate.getMonth() + 1); yyyyr = resignDate.getFullYear();
    if (ddr < 10) { ddr = "0" + ddr; }
    if (mmr < 10) { mmr = "0" + mmr; }
    resignDate = yyyyr + "-" + mmr + "-" + ddr;

    var ddl, mml, yyyyl;
    var lastdate = new Date(lastdate);
    ddl = lastdate.getDate(); mml = (lastdate.getMonth() + 1); yyyyl = lastdate.getFullYear();
    if (ddl < 10) { ddl = "0" + ddl; }
    if (mml < 10) { mml = "0" + mml; }
    lastdate = yyyyl + "-" + mml + "-" + ddl;

    document.getElementById("hdnID").value = enroll;
    document.getElementById("txtEmpCode").innerText = empcode;
    document.getElementById("txtEnroll").innerText = enroll;
    document.getElementById("txtEmpName").innerText = empname;
    document.getElementById("txtDesignation").innerText = designation;
    document.getElementById("txtSalary").innerText = salary;
    document.getElementById("txtResignationDate").innerText = resignDate;
    document.getElementById("txtLastWorkingDate").innerText = lastdate;
    document.getElementById("txtLastWorkingDateByUser").innerText = lastdateuser;
    document.getElementById("txtLastWorkingDateByAuthority").innerText = lastdateAuthority;
    document.getElementById("txtSeparateType").innerText = separateName;
    document.getElementById("txtReason").innerText = reason;
    $("#hiddenbox2").fadeIn("slow");
}

function ClearControlsRealizeDeptHead() {
    $("#hiddenbox2").fadeOut("slow");
    document.getElementById("hdnconfirm").value = "0";
    document.getElementById("txtEmpCode").innerText = "";
    document.getElementById("txtEnroll").innerText = "";
    document.getElementById("txtEmpName").innerText = "";
    document.getElementById("txtDesignation").innerText = "";
    document.getElementById("txtSalary").innerText = "";
    document.getElementById("txtResignationDate").innerText = "";
    document.getElementById("txtLastWorkingDate").innerText = "";
    document.getElementById("txtLastWorkingDateByUser").innerText = "";
    document.getElementById("txtLastWorkingDateByAuthority").innerText = "";
    document.getElementById("txtSeparateType").innerText = "";
    document.getElementById("txtReason").innerText = "";
    document.getElementById("txtDeductSalary").innerText = "";
}

function DeptHeadRealize() {
    var txtDeductSalary = document.forms["frmrealizedepthead"]["txtDeductSalary"].value;

    //if (txtDeductSalary == null || txtDeductSalary == "") {
    //    //alert("Please provide valid Date in Last office provide by Dept Head.");

    //}
    //else {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; __doPostBack(); }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    ClearControlsRealizeDeptHead();
    //}
}
//****** End- Resign Realize Dept. Head ********************************************************************************

//****** Start- Store Realize *****************************************************************************************
function FilterControlsStoreRealize(empcode, enroll, empname, designation, salary, resignDate, lastdate, lastdateuser, lastdateAuthority, separateName, reason) {
    var dd, mm, yyyy;
    var lastdateuser = new Date(lastdateuser);
    dd = lastdateuser.getDate(); mm = (lastdateuser.getMonth() + 1); yyyy = lastdateuser.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    lastdateuser = yyyy + "-" + mm + "-" + dd;

    var dde, mme, yyyye;
    var lastdateAuthority = new Date(lastdateAuthority);
    dde = lastdateAuthority.getDate(); mme = (lastdateAuthority.getMonth() + 1); yyyye = lastdateAuthority.getFullYear();
    if (dde < 10) { dde = "0" + dde; }
    if (mme < 10) { mme = "0" + mme; }
    lastdateAuthority = yyyye + "-" + mme + "-" + dde;

    var ddr, mmr, yyyyr;
    var resignDate = new Date(resignDate);
    ddr = resignDate.getDate(); mmr = (resignDate.getMonth() + 1); yyyyr = resignDate.getFullYear();
    if (ddr < 10) { ddr = "0" + ddr; }
    if (mmr < 10) { mmr = "0" + mmr; }
    resignDate = yyyyr + "-" + mmr + "-" + ddr;

    var ddl, mml, yyyyl;
    var lastdate = new Date(lastdate);
    ddl = lastdate.getDate(); mml = (lastdate.getMonth() + 1); yyyyl = lastdate.getFullYear();
    if (ddl < 10) { ddl = "0" + ddl; }
    if (mml < 10) { mml = "0" + mml; }
    lastdate = yyyyl + "-" + mml + "-" + ddl;

    document.getElementById("hdnID").value = enroll;
    document.getElementById("txtEmpCode").innerText = empcode;
    document.getElementById("txtEnroll").innerText = enroll;
    document.getElementById("txtEmpName").innerText = empname;
    document.getElementById("txtDesignation").innerText = designation;
    document.getElementById("txtSalary").innerText = salary;
    document.getElementById("txtResignationDate").innerText = resignDate;
    document.getElementById("txtLastWorkingDate").innerText = lastdate;
    document.getElementById("txtLastWorkingDateByUser").innerText = lastdateuser;
    document.getElementById("txtLastWorkingDateByAuthority").innerText = lastdateAuthority;
    document.getElementById("txtSeparateType").innerText = separateName;
    document.getElementById("txtReason").innerText = reason;
    $("#hiddenbox2").fadeIn("slow");
}

function StoreRealizeResign() {
    //var txtDeductSalary = document.forms["frmrealizedepthead"]["txtDeductSalary"].value;

    //if (txtDeductSalary == null || txtDeductSalary == "") {
    //    //alert("Please provide valid Date in Last office provide by Dept Head.");

    //}
    //else {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; __doPostBack(); }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    ClearControlsStoreRealize();
    //}
}

function ClearControlsStoreRealize() {
    $("#hiddenbox2").fadeOut("slow");
    document.getElementById("hdnconfirm").value = "0";
    document.getElementById("txtEmpCode").innerText = "";
    document.getElementById("txtEnroll").innerText = "";
    document.getElementById("txtEmpName").innerText = "";
    document.getElementById("txtDesignation").innerText = "";
    document.getElementById("txtSalary").innerText = "";
    document.getElementById("txtResignationDate").innerText = "";
    document.getElementById("txtLastWorkingDate").innerText = "";
    document.getElementById("txtLastWorkingDateByUser").innerText = "";
    document.getElementById("txtLastWorkingDateByAuthority").innerText = "";
    document.getElementById("txtSeparateType").innerText = "";
    document.getElementById("txtReason").innerText = "";
    document.getElementById("txtDeductSalary").innerText = "";
}

//****** End- Store Realize ********************************************************************************

//****** Start- Transport Realize *****************************************************************************************
function FilterControlsTransportRealizeResign(empcode, enroll, empname, designation, salary, resignDate, lastdate, lastdateuser, lastdateAuthority, separateName, reason) {
    var dd, mm, yyyy;
    var lastdateuser = new Date(lastdateuser);
    dd = lastdateuser.getDate(); mm = (lastdateuser.getMonth() + 1); yyyy = lastdateuser.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    lastdateuser = yyyy + "-" + mm + "-" + dd;

    var dde, mme, yyyye;
    var lastdateAuthority = new Date(lastdateAuthority);
    dde = lastdateAuthority.getDate(); mme = (lastdateAuthority.getMonth() + 1); yyyye = lastdateAuthority.getFullYear();
    if (dde < 10) { dde = "0" + dde; }
    if (mme < 10) { mme = "0" + mme; }
    lastdateAuthority = yyyye + "-" + mme + "-" + dde;

    var ddr, mmr, yyyyr;
    var resignDate = new Date(resignDate);
    ddr = resignDate.getDate(); mmr = (resignDate.getMonth() + 1); yyyyr = resignDate.getFullYear();
    if (ddr < 10) { ddr = "0" + ddr; }
    if (mmr < 10) { mmr = "0" + mmr; }
    resignDate = yyyyr + "-" + mmr + "-" + ddr;

    var ddl, mml, yyyyl;
    var lastdate = new Date(lastdate);
    ddl = lastdate.getDate(); mml = (lastdate.getMonth() + 1); yyyyl = lastdate.getFullYear();
    if (ddl < 10) { ddl = "0" + ddl; }
    if (mml < 10) { mml = "0" + mml; }
    lastdate = yyyyl + "-" + mml + "-" + ddl;

    document.getElementById("hdnID").value = enroll;
    document.getElementById("txtEmpCode").innerText = empcode;
    document.getElementById("txtEnroll").innerText = enroll;
    document.getElementById("txtEmpName").innerText = empname;
    document.getElementById("txtDesignation").innerText = designation;
    document.getElementById("txtSalary").innerText = salary;
    document.getElementById("txtResignationDate").innerText = resignDate;
    document.getElementById("txtLastWorkingDate").innerText = lastdate;
    document.getElementById("txtLastWorkingDateByUser").innerText = lastdateuser;
    document.getElementById("txtLastWorkingDateByAuthority").innerText = lastdateAuthority;
    document.getElementById("txtSeparateType").innerText = separateName;
    document.getElementById("txtReason").innerText = reason;
    $("#hiddenbox2").fadeIn("slow");
}

function TransportRealizeResign() {
    //var txtDeductSalary = document.forms["frmrealizedepthead"]["txtDeductSalary"].value;

    //if (txtDeductSalary == null || txtDeductSalary == "") {
    //    //alert("Please provide valid Date in Last office provide by Dept Head.");

    //}
    //else {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; __doPostBack(); }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    ClearControlsTransportRealize();
    //}
}

function ClearControlsTransportRealize() {
    $("#hiddenbox2").fadeOut("slow");
    document.getElementById("hdnconfirm").value = "0";
    document.getElementById("txtEmpCode").innerText = "";
    document.getElementById("txtEnroll").innerText = "";
    document.getElementById("txtEmpName").innerText = "";
    document.getElementById("txtDesignation").innerText = "";
    document.getElementById("txtSalary").innerText = "";
    document.getElementById("txtResignationDate").innerText = "";
    document.getElementById("txtLastWorkingDate").innerText = "";
    document.getElementById("txtLastWorkingDateByUser").innerText = "";
    document.getElementById("txtLastWorkingDateByAuthority").innerText = "";
    document.getElementById("txtSeparateType").innerText = "";
    document.getElementById("txtReason").innerText = "";
    document.getElementById("txtDeductSalary").innerText = "";
}

//****** End- Transport Realize ***************************************************************************************

//****** Start- Accounts Realize *****************************************************************************************
function FilterControlsAccountsRealizeResign(empcode, enroll, empname, designation, salary, resignDate, lastdate, lastdateuser, lastdateAuthority, separateName, reason) {
    var dd, mm, yyyy;
    var lastdateuser = new Date(lastdateuser);
    dd = lastdateuser.getDate(); mm = (lastdateuser.getMonth() + 1); yyyy = lastdateuser.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    lastdateuser = yyyy + "-" + mm + "-" + dd;

    var dde, mme, yyyye;
    var lastdateAuthority = new Date(lastdateAuthority);
    dde = lastdateAuthority.getDate(); mme = (lastdateAuthority.getMonth() + 1); yyyye = lastdateAuthority.getFullYear();
    if (dde < 10) { dde = "0" + dde; }
    if (mme < 10) { mme = "0" + mme; }
    lastdateAuthority = yyyye + "-" + mme + "-" + dde;

    var ddr, mmr, yyyyr;
    var resignDate = new Date(resignDate);
    ddr = resignDate.getDate(); mmr = (resignDate.getMonth() + 1); yyyyr = resignDate.getFullYear();
    if (ddr < 10) { ddr = "0" + ddr; }
    if (mmr < 10) { mmr = "0" + mmr; }
    resignDate = yyyyr + "-" + mmr + "-" + ddr;

    var ddl, mml, yyyyl;
    var lastdate = new Date(lastdate);
    ddl = lastdate.getDate(); mml = (lastdate.getMonth() + 1); yyyyl = lastdate.getFullYear();
    if (ddl < 10) { ddl = "0" + ddl; }
    if (mml < 10) { mml = "0" + mml; }
    lastdate = yyyyl + "-" + mml + "-" + ddl;

    document.getElementById("hdnID").value = enroll;
    document.getElementById("txtEmpCode").innerText = empcode;
    document.getElementById("txtEnroll").innerText = enroll;
    document.getElementById("txtEmpName").innerText = empname;
    document.getElementById("txtDesignation").innerText = designation;
    document.getElementById("txtSalary").innerText = salary;
    document.getElementById("txtResignationDate").innerText = resignDate;
    document.getElementById("txtLastWorkingDate").innerText = lastdate;
    document.getElementById("txtLastWorkingDateByUser").innerText = lastdateuser;
    document.getElementById("txtLastWorkingDateByAuthority").innerText = lastdateAuthority;
    document.getElementById("txtSeparateType").innerText = separateName;
    document.getElementById("txtReason").innerText = reason;
    $("#hiddenbox2").fadeIn("slow");
}

function AccountsRealizeResign() {
    //var txtDeductSalary = document.forms["frmrealizedepthead"]["txtDeductSalary"].value;

    //if (txtDeductSalary == null || txtDeductSalary == "") {
    //    //alert("Please provide valid Date in Last office provide by Dept Head.");

    //}
    //else {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; __doPostBack(); }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    ClearControlsAccountsRealize();
    //}
}

function ClearControlsAccountsRealize() {
    $("#hiddenbox2").fadeOut("slow");
    document.getElementById("hdnconfirm").value = "0";
    document.getElementById("txtEmpCode").innerText = "";
    document.getElementById("txtEnroll").innerText = "";
    document.getElementById("txtEmpName").innerText = "";
    document.getElementById("txtDesignation").innerText = "";
    document.getElementById("txtSalary").innerText = "";
    document.getElementById("txtResignationDate").innerText = "";
    document.getElementById("txtLastWorkingDate").innerText = "";
    document.getElementById("txtLastWorkingDateByUser").innerText = "";
    document.getElementById("txtLastWorkingDateByAuthority").innerText = "";
    document.getElementById("txtSeparateType").innerText = "";
    document.getElementById("txtReason").innerText = "";
    document.getElementById("txtDeductSalary").innerText = "";
}

//****** End- Accounts Realize ***************************************************************************************

//****** Start- HR Realize *****************************************************************************************
function FilterControlsHRRealizeResign(empcode, enroll, empname, designation, salary, resignDate, lastdate, lastdateuser, lastdateAuthority, separateName, reason, ysnBenifit) {
    var dd, mm, yyyy;
    var lastdateuser = new Date(lastdateuser);
    dd = lastdateuser.getDate(); mm = (lastdateuser.getMonth() + 1); yyyy = lastdateuser.getFullYear();
    if (dd < 10) { dd = "0" + dd; }
    if (mm < 10) { mm = "0" + mm; }
    lastdateuser = yyyy + "-" + mm + "-" + dd;

    var dde, mme, yyyye;
    var lastdateAuthority = new Date(lastdateAuthority);
    dde = lastdateAuthority.getDate(); mme = (lastdateAuthority.getMonth() + 1); yyyye = lastdateAuthority.getFullYear();
    if (dde < 10) { dde = "0" + dde; }
    if (mme < 10) { mme = "0" + mme; }
    lastdateAuthority = yyyye + "-" + mme + "-" + dde;

    var ddr, mmr, yyyyr;
    var resignDate = new Date(resignDate);
    ddr = resignDate.getDate(); mmr = (resignDate.getMonth() + 1); yyyyr = resignDate.getFullYear();
    if (ddr < 10) { ddr = "0" + ddr; }
    if (mmr < 10) { mmr = "0" + mmr; }
    resignDate = yyyyr + "-" + mmr + "-" + ddr;

    var ddl, mml, yyyyl;
    var lastdate = new Date(lastdate);
    ddl = lastdate.getDate(); mml = (lastdate.getMonth() + 1); yyyyl = lastdate.getFullYear();
    if (ddl < 10) { ddl = "0" + ddl; }
    if (mml < 10) { mml = "0" + mml; }
    lastdate = yyyyl + "-" + mml + "-" + ddl;

    document.getElementById("hdnID").value = enroll;
    document.getElementById("txtEmpCode").innerText = empcode;
    document.getElementById("txtEnroll").innerText = enroll;
    document.getElementById("txtEmpName").innerText = empname;
    document.getElementById("txtDesignation").innerText = designation;
    document.getElementById("txtSalary").innerText = salary;
    document.getElementById("txtResignationDate").innerText = resignDate;
    document.getElementById("txtLastWorkingDate").innerText = lastdate;
    document.getElementById("txtLastWorkingDateByUser").innerText = lastdateuser;
    document.getElementById("txtLastWorkingDateByAuthority").innerText = lastdateAuthority;
    document.getElementById("txtSeparateType").innerText = separateName;
    document.getElementById("txtReason").innerText = reason;
    document.getElementById("hdnBenifit").value = ysnBenifit;
    if (ysnBenifit == "1") { document.getElementById('CheckBox1').checked = true; } else { document.getElementById('CheckBox1').checked = false; }
    $("#hiddenbox2").fadeIn("slow");
}

function FilterControlsHRRealizeResignDoc(enroll, intID) {
    document.getElementById("hdnID").value = enroll;
    document.getElementById("hdnSeprationID").value = intID;
    $("#hiddenbox4").fadeIn("slow");
}

function ClearControlsHRRealizeDoc() {
    $("#hiddenbox4").fadeOut("slow");
}

function HRRealizeResign() {
    //var txtDeductSalary = document.forms["frmrealizedepthead"]["txtDeductSalary"].value;

    //if (txtDeductSalary == null || txtDeductSalary == "") {
    //    //alert("Please provide valid Date in Last office provide by Dept Head.");

    //}
    //else {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; __doPostBack(); }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    ClearControlsHRRealize();
    //}
}

function ClearControlsHRRealize() {
    $("#hiddenbox2").fadeOut("slow");
    document.getElementById("hdnconfirm").value = "0";
    document.getElementById("txtEmpCode").innerText = "";
    document.getElementById("txtEnroll").innerText = "";
    document.getElementById("txtEmpName").innerText = "";
    document.getElementById("txtDesignation").innerText = "";
    document.getElementById("txtSalary").innerText = "";
    document.getElementById("txtResignationDate").innerText = "";
    document.getElementById("txtLastWorkingDate").innerText = "";
    document.getElementById("txtLastWorkingDateByUser").innerText = "";
    document.getElementById("txtLastWorkingDateByAuthority").innerText = "";
    document.getElementById("txtSeparateType").innerText = "";
    document.getElementById("txtReason").innerText = "";
    document.getElementById("txtDeductSalary").innerText = "";
}

//****** End- HR Realize ***************************************************************************************


function ViewDocList(Id) {

    window.open('DocPathList.aspx?ID=' + Id, 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");

    //newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=250,width=500,top=50,left=150, close=no');
    //if (window.focus) { newwindow.focus() }
}