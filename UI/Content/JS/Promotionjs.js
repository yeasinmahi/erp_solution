
function EduInfo()
{
    document.getElementById("hdnconfirm").value = "0";
    var txtInstitute = document.forms["frmperfomance"]["txtInstitute"].value;
    var txtDegree = document.forms["frmperfomance"]["txtDegree"].value;
    var txtMajor = document.forms["frmperfomance"]["txtMajor"].value;
    var txtPassingYear = document.forms["frmperfomance"]["txtPassingYear"].value;

    if (txtInstitute == null || txtInstitute == "") {
        alert("Institute Name must be filled.");
    }
    else if (txtDegree == null || txtDegree == "") {
        alert("Professional education must be filled.");
    }
    else if (txtMajor == null || txtMajor=="") {
        alert("Major subject must be filled.");
    }
    else if (txtPassingYear == null || txtPassingYear == "" || isNaN(txtPassingYear)) {
        alert("PassingYear must be filled by valid numeric.");
    }
    else {
        document.getElementById("hdnconfirm").value = "1";
    }
}

function TrainingInfo() {
    document.getElementById("hdnconfirm").value = "0";
    var txtTrining = document.forms["frmperfomance"]["txtTrining"].value;
    var txtCourse = document.forms["frmperfomance"]["txtCourse"].value;
    var txtDuration = document.forms["frmperfomance"]["txtDuration"].value;

    if (txtTrining == null || txtTrining == "") {
        alert("Trining Name must be filled.");
    }
    else if (txtCourse == null || txtCourse == "") {
        alert("Course must be filled.");
    }
    else if (txtDuration == null || txtDuration == "" || isNaN(txtDuration)) {
        alert("Course Duration must be filled by valid numeric.");
    }
    else {
        document.getElementById("hdnconfirm").value = "1";
    }
}

function AchiveInfo() {
    document.getElementById("hdnconfirm").value = "0";
    var dtePeriodFrom = document.forms["frmperfomance"]["dtePeriodFrom"].value;
    var dtePeriodTo = document.forms["frmperfomance"]["dtePeriodTo"].value;
    var txtTask = document.forms["frmperfomance"]["txtTask"].value;
    var txtAchivement = document.forms["frmperfomance"]["txtAchivement"].value;
    var txtAchive = document.forms["frmperfomance"]["txtAchive"].value;

    if (dtePeriodFrom == null || dtePeriodFrom == "") {
        alert("Period from date must be filled by valid formate (day-month-year).");
    }
    else if (dtePeriodTo == null || dtePeriodTo == "") {
        alert("Period to date must be filled by valid formate (day-month-year).");
    }
    else if (txtTask == null || txtTask == "") {
        alert("Challenging task must be filled.");
    }
    else if (txtAchivement == null || txtAchivement == "") {
        alert("Level of achivement must be filled.");
    }
    else if (txtAchive == null || txtAchive == "" || isNaN(txtAchive)) {
        alert("Achieve percentage must be filled by valid numeric.");
    }
    else {
        document.getElementById("hdnconfirm").value = "1";
    }
}

function Validation()
{
    document.getElementById("hdnconfirm").value = "0";
    var txtBengali = document.forms["frmperfomance"]["txtBengali"].value;
    var txtEnglish = document.forms["frmperfomance"]["txtEnglish"].value;
    var txtTotalExpOthersCompany = document.forms["frmperfomance"]["txtTotalExpOthersCompany"].value;    
    var dteLastupdate = document.forms["frmperfomance"]["dteLastupdate"].value;
    var txtShortterm = document.forms["frmperfomance"]["txtShortterm"].value;
    var txtLongterm = document.forms["frmperfomance"]["txtLongterm"].value;
    var txtTotalExpOthersCompany = document.forms["frmperfomance"]["txtTotalExpOthersCompany"].value;
    var txtpretowork = document.forms["frmperfomance"]["txtpretowork"].value;

    if (txtBengali == null || txtBengali == "") {
        alert("Bengali must be filled.");
    }
    else if (txtEnglish == null || txtEnglish == "") {
        alert("English must be filled.");
    }
    
    else if (dteLastupdate == null || dteLastupdate == "") {
        alert("Last update date must be filled by valid formate (day-month-year).");
    }
    else if (txtShortterm == null || txtShortterm == "") {
        alert("Short term goals must be filled.");
    }
    else if (txtLongterm == null || txtLongterm == "") {
        alert("Long term goals must be filled.");
    }
    else if (txtTotalExpOthersCompany == null || txtTotalExpOthersCompany == "" || isNaN(txtTotalExpOthersCompany)) {
        alert("Total Exp. Others Company must be filled by valid numeric.");
    }
    else if (txtpretowork == null || txtpretowork == "") {
        alert("Preference to work must be filled.");
    }
    else {
        document.getElementById("hdnconfirm").value = "1";
    }

}