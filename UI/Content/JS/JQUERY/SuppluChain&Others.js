


    // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
    function isNumber(evt) {
        var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        if ((iKeyCode > 57))
            return false;        
        return true;


        //var iKeyCode = (evt.which) ? evt.which : evt.keyCode
        //if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
        //    return false;
        //return true;



        //if ((iKeyCode >= 48 && iKeyCode <= 57) || (iKeyCode == 8 || iKeyCode == 127))
    }
//function Changed(val) {
//    if (val == null || val == "" || isNaN(val) || val.length < 13 || val.length > 13) {
//        alert("Account No will be 13 digit.");
//    }
//}

function ValidationBasicInfo() {
    document.getElementById("hdnconfirm").value = "0";
    var fullname = document.forms["frmauditdeptrealize"]["txtSuppliername"].value;
    var Address = document.forms["frmauditdeptrealize"]["txtAddress"].value;
    var BussType = document.forms["frmauditdeptrealize"]["ddlBussType"].value;
    var ServiceType = document.forms["frmauditdeptrealize"]["ddlservice"].value;
    var ReprName = document.forms["frmauditdeptrealize"]["txtContactP"].value;
    var ContactPhone = document.forms["frmauditdeptrealize"]["txtPhone"].value;
    var SuppType = document.forms["frmauditdeptrealize"]["ddlSupplierType"].value;
    
    var stype = document.forms["frmauditdeptrealize"]["ddlSupplierType"].value;
    //var atpos = email.indexOf("@");
    //var dotpos = email.lastIndexOf(".");
    

    if (fullname == null || fullname == "") {
        alert("Supplier name must be filled.");
    }

    else if (Address == null || Address == "") {
        alert("Supplier Address must be filled.");
    }

    else if (BussType == null || BussType == "") {
        alert("Please Select Business Type");
    }

    else if (ServiceType == null || ServiceType == "") {
        alert("Please Select Service Type");
    }

    //else if (ReprName == null || ReprName == "") {
    //    alert("Please Input Contact Persone Name");
    //}

    //else if (ContactPhone == null || ContactPhone == "") {
    //    alert("Please Input Contact Persone Phone No.");
    //}

    else if (SuppType == null || SuppType == "") {
        alert("Please Select Supplier Type");
        }
    
  

    else if (stype != "3") {
  
        var chk = document.getElementById("chkBox1").value;
        if ((stype == "1" || stype == "2") && (chk == "on")) {
            var Payto = document.forms["frmauditdeptrealize"]["txtPayTo"].value;
            if (Payto == null || Payto == "") {
                alert("Please Input Pay to Name");
            }
            else { document.getElementById("hdnconfirm").value = "1"; }
        }

        else {
            var Payto = document.forms["frmauditdeptrealize"]["txtPayTo"].value;
            var accno = document.forms["frmauditdeptrealize"]["txtACNo"].value;
            var Routing = document.forms["frmauditdeptrealize"]["txtRouting"].value;
            var Branch = document.forms["frmauditdeptrealize"]["txtBranch"].value;

            if (Payto == null || Payto == "") {
                alert("Please Input Pay to Name");
            }

            else if (accno == null || accno == "") {
                alert("A/C No Must be Filled");
            }

            else if (Routing == null || Routing == "") {
                alert("Routing No Must be Filled");
            }

            else if (accno == "" || isNaN(accno) || accno.length < 13 || accno.length > 13) {
                alert("Account No Must be 13 digit.");

            }
            else if (Routing == "" || isNaN(Routing) || Routing.length < 9 || Routing.length > 9) {
                alert("Routing No Must be 9 digit.");
                //RadioButton1.Checked = false
            }
            else if (Branch == null || Branch == "") {
                alert("Please click the check box.");
            }
            else { document.getElementById("hdnconfirm").value = "1"; }
        }
    }
    else { document.getElementById("hdnconfirm").value = "1"; }
       
}
function CloseWindow() {
    alert('closing');
    window.close();
}

