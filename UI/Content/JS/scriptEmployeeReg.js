      
 $(document).ready(function () {
            document.getElementById("basicinfo").style.display = "block";
            document.getElementById("officeinfo").style.display = "none";
            document.getElementById("salaryinfo").style.display = "none";
            SearchText();
        });

function ShowBasicInfo() {            
    document.getElementById("officeinfo").style.display = "none";
    document.getElementById("salaryinfo").style.display = "none";
    $("#basicinfo").fadeIn("slow"); $("#1").addClass("active");
    $("#2").removeClass('active'); $("#3").removeClass('active');
}

function ShowOfficialInfo() {
    document.getElementById("basicinfo").style.display = "none";
    document.getElementById("salaryinfo").style.display = "none";
    $("#officeinfo").fadeIn("slow"); $("#2").addClass("active");
    $("#1").removeClass('active'); $("#3").removeClass('active');    
}

function ShowSalaryInfo() {
    document.getElementById("basicinfo").style.display = "none";
    document.getElementById("officeinfo").style.display = "none";
    $("#salaryinfo").fadeIn("slow"); $("#3").addClass("active");
    $("#1").removeClass('active'); $("#2").removeClass('active');
}

function SearchText() {
    $("#txtReportingBoss").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "NewEmployeeReg.aspx/GetAutoCompleteData",
                data: "{'strSearchKey':'" + document.getElementById('txtReportingBoss').value + "'}",
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

function ValidationBasicInfo() {
    var fullname = document.forms["frmEmpRegistration"]["txtFullName"].value;
    var shortname = document.forms["frmEmpRegistration"]["txtShortName"].value;
    var nationaid = document.forms["frmEmpRegistration"]["txtNationalId"].value;
    var contactno = document.forms["frmEmpRegistration"]["txtContactNo"].value;
    var factorycode = document.forms["frmEmpRegistration"]["txtFactoryCode"].value;
    var peradd = document.forms["frmEmpRegistration"]["txtPermanentAddress"].value;
    var preadd = document.forms["frmEmpRegistration"]["txtPresentAddress"].value;
    var dob = document.forms["frmEmpRegistration"]["txtDOB"].value;
    //var atpos = email.indexOf("@");
    //var dotpos = email.lastIndexOf(".");

    if (fullname == null || fullname == "") {
        alert("Full name must be filled.");
        ShowBasicInfo();
    }
    else if (shortname.length <= 0 || shortname.length > 8) {
        alert("Short name must be filled and max length is 8.");
        ShowBasicInfo();
    }
    else if (nationaid == null || nationaid == "" || nationaid.length > 15) {
        alert("NationalId must be filled and max length is 15.");
        ShowBasicInfo();
    }
    else if (contactno == null || contactno == "" || contactno.length > 11 || isNaN(contactno)) {
        alert("ContactNo must be filled by numeric value and max length is 11.");
        ShowBasicInfo();
    }
    else if (factorycode == null || factorycode == "") {
        alert("Card no must be filled.");
        ShowBasicInfo();
    }
    else if (peradd == null || peradd == "") {
        alert("Permanent address must be filled.");
        ShowBasicInfo();
    }
    else if (preadd == null || preadd == "") {
        alert("Present address must be filled.");
        ShowBasicInfo();
    }
    else if (dob == null || dob == "" ) {
        alert("Date of Birth must be filled by valid formate (year-month-day).");
        ShowBasicInfo();
    }
    else { ShowOfficialInfo(); }
}

function ValidationOfficialInfo() {
    
    var now = new Date();
    var year = now.getFullYear();
    var month = now.getMonth() + 1;
    var day = now.getDate();
    if (day < 10) { day = "0" + day; }
    if (month < 10) { month = "0" + month; }
    now = year + "-" + month + "-" + day

    //var validformat = /^\d{4}\-\d{2}\/\d{2}$/

    var joindate = document.forms["frmEmpRegistration"]["txtJoiningDate"].value;
    var reportingBoss = document.forms["frmEmpRegistration"]["txtReportingBoss"].value;

    if (reportingBoss == null || reportingBoss == "") {
        alert("Reporting Boss must be filled.");
        ShowOfficialInfo();
    }
    else if (joindate == null || joindate == "") { //|| !validformat.test(apointdate)
        alert("Joining date must be filled by valid formate (year-month-day).");
        ShowOfficialInfo();
    }
    else if (now > joindate)
    {
        alert("Joining date must be greater or equel today date.");
        ShowOfficialInfo();
    }
    else { ShowSalaryInfo(); }
}

function ValidationSalaryInfo() {

    //var bnkname = document.forms["frmEmpRegistration"]["txtBankName"].value;
    //var bnkbranch = document.forms["frmEmpRegistration"]["txtBranchName"].value;
    var accountno = document.forms["frmEmpRegistration"]["txtAccountNo"].value;
    var monsalary = document.forms["frmEmpRegistration"]["monSalary"].value;
    //var monbasic = document.forms["frmEmpRegistration"]["monBasic"].value;

    //if (bnkname == null || bnkname == "") {
    //    alert("Bank name must be filled.");
    //    ShowSalaryInfo();
    //}
    //else if (bnkbranch == null || bnkbranch == "") {
    //    alert("Bank brach must be filled.");
    //    ShowSalaryInfo();
    //}
    //else if (accountno == null || accountno == "") {
    //    alert("Account number must be filled.");
    //    ShowSalaryInfo();
    //}
    if (accountno == null || accountno == "" || isNaN(accountno) || accountno.length < 13 || accountno.length > 13) {
        alert("Account no will be 13 digit.");
    }
    else if (monsalary == null || monsalary == "" || isNaN(monsalary)) {
        alert("Total salary must be filled by numeric value.");
        ShowSalaryInfo();
    }
    //else if (monbasic == null || monbasic == "" || isNaN(monbasic)) {
    //    alert("Basic salary must be filled by numeric value.");
    //    ShowSalaryInfo();
    //}

    else {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }
}
