$(document).ready(function () {
    $(function () {
        $('#TxtDateOfJoin').datepicker(
            {
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:2100'
            });

    });
});

function Confirm() {
    //alert("Hello");
    var EmployeeSearch = document.getElementById("TxtEmployee").value;
    var Name = document.getElementById("TxtName").value;
    var Designation = document.getElementById("TxtDesignation").value;
    var Department = document.getElementById("TxtDepartment").value;
    var DateOfJoin = document.getElementById("TxtDateOfJoin").value;
    var UnitName = document.getElementById("TxtUnit").value;
    var JobStation = document.getElementById("TxtJobStation").value;
    var Father = document.getElementById("TxtFather").value;
    var Mother = document.getElementById("TxtMother").value;
    //var Spouse = document.getElementById("TxtSpouse").value;
    var Village = document.getElementById("TxtVillage").value;
    var PermanentPostOffice = document.getElementById("TxtPermanentPostOffice").value;
    var PermanentPoliceStation = document.getElementById("TxtPermanentPoliceStation").value;
    var PermanentDistricts = document.getElementById("TxtPermanentDistricts").value;
    var PresentPostOffice = document.getElementById("TxtPresentPostOffice").value;
    var House = document.getElementById("TxtHouse").value;
    var Road = document.getElementById("TxtRoad").value;
    var PresentPoliceStation = document.getElementById("TxtPresentPoliceStation").value;
    var PresentDistricts = document.getElementById("TxtPresentDistricts").value;

    if (EmployeeSearch == "") {
        alert("Enter Search Employee Field");
    }
    else if (Name == "") {
        alert("Enter Employees Name");
    }
    else if (Department == "") {
        alert("Enter Department Name");
    }
    else if (UnitName == "") {
        alert("Enter Unit Name");
    }
    else if (Designation == "") {
        alert("Enter Designation");
    }
    else if (DateOfJoin == "") {
        alert("Enter Joining Date");
    }
    else if (JobStation == "") {
        alert("Enter Job Station");
    }
    else if (Father=="") {
        alert("Enter Father's Name");
    }
    else if (Mother == "") {
        alert("Enter Mother's Name");
    }
    else if (Village == "") {
        alert("Enter Village Name");
    }
    else if (PermanentPostOffice == "") {
        alert("Enter Post Office Name");
    }
    else if (PermanentDistricts == "") {
        alert("Enter Districts Name");
    }
    else if (PermanentPoliceStation == "") {
        alert("Enter Police Station Name");
    }
    else if (House == "") {
        alert("Enter House No");
    }
    else if (Road == "") {
        alert("Enter Road No");
    }
    else if (PresentPostOffice == "") {
        alert("Enter Post Office Name");
    }
    else if (PresentPoliceStation == "") {
        alert("Enter Police Station Name");
        
    }
    else if (PresentDistricts == "") {
        alert("Enter Districts Name");
    }


}

function jumpToNextTextBox1() {
    if (document.form1.TxtFather.value.length >= 3) {
        document.form1.TxtFather.value = document.form1.TxtFather.value.substr(0, 3);


        document.form1.TxtMother.value = document.form1.TxtFather.value.substr(3, 1);


        document.form1.TxtMother.focus();


    }
}