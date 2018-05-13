

function ConfirmTAX() {
    document.getElementById("ConfirmTAX").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Check this Option will stop recording any SD or VAT for this Product. Do you want to save this item as Tax exempted?")) { confirm_value.value = "Yes"; document.getElementById("ConfirmTAX").value = "1"; }
    else { confirm_value.value = "No"; document.getElementById("ConfirmTAX").value = "0"; }
}


function ConfirmAll() {
    document.getElementById("hdnconfirm").value = "0";
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
    if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
    else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
}

function PurchaseReturnConfirm() {
    document.getElementById("hdnconfirm").value = "0";
    var txtCode = document.forms["frmpurrtnrcv"]["txtCode"].value;
    var txtVehicleno = document.forms["frmpurrtnrcv"]["txtVehicleno"].value;
    if (txtCode == null || txtCode == "") {
        alert("Please enter challan no.");
    }
    else if (txtVehicleno == null || txtVehicleno == "") {
        alert("Please enter vehicleno.");
    }
    else {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }
}
function CheckSalesInValidation() {
    document.getElementById("hdnconfirm").value = "0";
    var txtTotalMemo = document.forms["frmslsinpoint"]["txtTotalMemo"].value;
    if (txtTotalMemo == null || txtTotalMemo == "" || isNaN(txtTotalMemo)) {
        alert("Please enter total memo numeric.");
    }
    else {
        document.getElementById("hdnconfirm").value = "1";
    }
}

function ViewTodayNetSales(coustomer, point) {
    window.open('../Reports/ReportOnDailySales.aspx?ENROLL=' + coustomer + '&POINT=' + point, 'sub', "height=350, width=750, scrollbars=yes, left=300, top=250, resizable=no, title=Preview");
}
function ViewTransitdetails(remarks, autoid, pointid) {
    window.open('ReportOnTransitDetails.aspx?REMARKS=' + remarks + '&AUTOID=' + autoid + '&POINT=' + pointid, 'sub', "height=250, width=450, scrollbars=yes, left=300, top=250, resizable=no, title=Preview");
}
function ViewIndentDetails(indentid, point, pointname) {
    window.open('../Reports/MReportOnIndentDetails.aspx?INDNT=' + indentid + '&POINT=' + point + '&POINTNAME=' + pointname, 'sub', "height=350, width=550, scrollbars=yes, left=300, top=250, resizable=no, title=Preview");
}

function ConfirmRegistration()
{
    document.getElementById("hdnconfirmregistration").value = "0";
    var fullname = document.forms["frmmanpowerregis"]["txtFullName"].value;
    var contactno = document.forms["frmmanpowerregis"]["txtContactNo"].value;
    var pointcode = document.forms["frmmanpowerregis"]["txtPointCode"].value;
    var peradd = document.forms["frmmanpowerregis"]["txtPermanentAddress"].value;    
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    if (day < 10) { day = "0" + day; }
    if (month < 10) { month = "0" + month; }
    now = year + "-" + month + "-" + day
    var joindate = document.forms["frmmanpowerregis"]["txtJoiningDate"].value;
    var accountno = document.forms["frmmanpowerregis"]["txtAccountNo"].value;
    var monsalary = document.forms["frmmanpowerregis"]["monSalary"].value;

    if (fullname == null || fullname == "") {
        alert("Full name must be filled.");
    }
    else if (contactno == null || contactno == "" || contactno.length > 11 || isNaN(contactno)) {
        alert("ContactNo must be filled by numeric value and max length is 11.");
    }
    else if (pointcode == null || pointcode == "") {
        alert("Code no must be filled.");
    }
    else if (peradd == null || peradd == "") {
        alert("Permanent address must be filled.");
    }
    else if (joindate == null || joindate == "") {
        alert("Joining date must be filled by valid formate (year-month-day).");
    }
    //else if (now > joindate) {
    //    alert("Joining date must be greater or equel today date.");
    //}
    else if (accountno == null || accountno == "" || accountno.length > 13 || accountno.length < 13 || isNaN(accountno)) {
        alert("Account number must be filled by 13 digit.");
    }
    else if (monsalary == null || monsalary == "" || isNaN(monsalary)) {
        alert("Total salary must be filled by numeric value.");
    }

    else {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirmregistration").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirmregistration").value = "0"; }
    }
}
function ConfirmUpdate() {
    document.getElementById("hdnconfirmupdate").value = "0";
    var fullname = document.forms["frmprofileupdate"]["txtFullName"].value;
    var contactno = document.forms["frmprofileupdate"]["txtContactNo"].value;
    var pointcode = document.forms["frmprofileupdate"]["txtPointCode"].value;
    var peradd = document.forms["frmprofileupdate"]["txtPermanentAddress"].value;
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    if (day < 10) { day = "0" + day; }
    if (month < 10) { month = "0" + month; }
    now = year + "-" + month + "-" + day
    var joindate = document.forms["frmprofileupdate"]["txtJoiningDate"].value;
    var accountno = document.forms["frmprofileupdate"]["txtAccountNo"].value;
    var monsalary = document.forms["frmprofileupdate"]["monSalary"].value;

    if (fullname == null || fullname == "") {
        alert("Full name must be filled.");
    }
    else if (contactno == null || contactno == "" || contactno.length > 11 || isNaN(contactno)) {
        alert("ContactNo must be filled by numeric value and max length is 11.");
    }
    else if (pointcode == null || pointcode == "") {
        alert("Code no must be filled.");
    }
    else if (peradd == null || peradd == "") {
        alert("Permanent address must be filled.");
    }
    else if (joindate == null || joindate == "") {
        alert("Joining date must be filled by valid formate (year-month-day).");
    }
    //else if (now > joindate) {
    //    alert("Joining date must be greater or equel today date.");
    //}
    else if (accountno == null || accountno == "" || accountno.length > 13 || accountno.length < 13 || isNaN(accountno)) {
        alert("Account number must be filled by 13 digit.");
    }
    else if (monsalary == null || monsalary == "" || isNaN(monsalary)) {
        alert("Total salary must be filled by numeric value.");
    }

    else {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirmupdate").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirmupdate").value = "0"; }
    }
}

function ViewConfirm2(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }
function ViewConfirmDispatch(id) { document.getElementById('hdnDivisionDispatch').style.visibility = 'visible'; }

function ViewConfirm(id) {
    document.getElementById('hdnDivision').style.visibility = 'visible';    
}
function ViewQRCode(id) {
    document.getElementById('hdnDivision').style.visibility = 'visible';

}
function ClosehdnDivision(sts) {
    if (sts == '1')
    {
        $("#hdnDivision").fadeOut("slow");
        document.getElementById("hdnconfirm").value = "3";
        __doPostBack();
    }
    else
    {
        alert(sts); $("#hdnDivision").fadeOut("slow");        
    }
}

function LoaderBusy() {
    $('form').live("submit", function () {
        ShowProgress();
    });
}

function ShowProgress() {
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        //var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var top = 250;
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 100);
}

function ACNoCheck() {
    var textbox = document.forms["frmauditdeptrealize"]["txtACNo"].value;
    if (textbox.trim().length >= 13) {
        return false;
    }
    else { return isNumber(event); return true; }
        
 }

 function RoutingNoCheck() {
     var textbox = document.forms["frmauditdeptrealize"]["txtRouting"].value;
     if (textbox.trim().length >= 9) {
         return false;
     }
     else { return isNumber(event); return true; }

 }
