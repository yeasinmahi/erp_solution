$(document).ready(function () {    
    SearchText();
});
function Changed() {
    document.getElementById('hdfSearchBoxTextChange').value = 'true';
}
function SearchText() {
    $("#txtEmployeeSearch").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "UpdateEmployeeProfile.aspx/GetAutoCompleteData",
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

function CheckValidation() {

    var searchname = document.forms["frmEmpUpdate"]["txtEmployeeSearch"].value;
    var fullname = document.forms["frmEmpUpdate"]["txtFullName"].value;
    var contactp = document.forms["frmEmpUpdate"]["txtContact"].value;
    var contactno = document.forms["frmEmpUpdate"]["txtContactNo"].value;
    var peradd = document.forms["frmEmpUpdate"]["txtPermanentAddress"].value;
    var preadd = document.forms["frmEmpUpdate"]["txtPresentAddress"].value;
    var dob = document.forms["frmEmpUpdate"]["txtDOB"].value;
    //var atpos = email.indexOf("@");
    //var dotpos = email.lastIndexOf(".");
    //var bnkname = document.forms["frmEmpUpdate"]["txtBankName"].value;
    //var bnkbranch = document.forms["frmEmpUpdate"]["txtBranchName"].value;
    var accountno = document.forms["frmEmpUpdate"]["txtAccountNo"].value;
    var monsalary = document.forms["frmEmpUpdate"]["monSalary"].value;
    var monbasic = document.forms["frmEmpUpdate"]["monBasic"].value;
    var boss = document.forms["frmEmpUpdate"]["txtReportingBoss"].value;
    if (searchname == null || searchname == "") {
        alert("Employee searchbox must be filled.");
    }
    else if (fullname == null || fullname == "") {
        alert("Full name must be filled.");
    }
    //else if (email == null || email == "" || atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) {
    //    alert("Email address must be filled by valid formate.");
    //}
    else if (contactp == null || contactp == "" || contactp.length > 5 || isNaN(contactp)) {
        alert("Contact period must be filled by numeric value.");
    }
    else if (accountno == null || accountno == "" || isNaN(accountno) || accountno.length < 13 || accountno.length > 13) {
        alert("Account no will be 13 digit.");
    }
    //else if (bnkname == null || bnkname == "") {
    //    alert("Bank name must be filled.");
    //}
    //else if (bnkbranch == null || bnkbranch == "") {
    //    alert("Bank brach must be filled.");
    //}
    //else if (accountno == null || accountno == "") {
    //    alert("Account number must be filled.");
    //}
    else if (monsalary == null || monsalary == "" || isNaN(monsalary)) {
        alert("Total salary must be filled by numeric value.");
    }
    else if (monbasic == null || monbasic == "" || isNaN(monbasic)) {
        alert("Basic salary must be filled by numeric value.");
    }
    else if (contactno == null || contactno == "" || contactno.length > 11 || isNaN(contactno)) {
        alert("ContactNo must be filled by numeric value and max length is 11.");
    }
    else if (peradd == null || peradd == "") {
        alert("Permanent address must be filled.");
    }
    else if (preadd == null || preadd == "") {
        alert("Present address must be filled.");
    }
    else if (boss == null || boss == "") {
        alert("Supervisor must be filled.");
    }
    else {
        document.getElementById("hdnAction").value = "1";
        __doPostBack();
    }

}