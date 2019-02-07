﻿function url_query(query) {
    query = query.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var expr = "[\\?&]" + query + "=([^&#]*)";
    var regex = new RegExp(expr);
    var results = regex.exec(window.location.href);
    if (results !== null) {
        return results[1];
    } else {
        return false;
    }
}
function ShowNotification(message, title, type) {
    toastr.options =
        {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-bottom-right",
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    if (type === null) {
        toastr.warning('Notification type should not be null', 'Notification Format Error');
    } else {
        if (type === "success") {
            toastr.success(message, title);
        } else if (type === "warning") {
            toastr.warning(message, title);
        }
        else if (type === "error") {
            toastr.error(message, title);
        } else {
            toastr.warning('Please provide proper type of notification', 'Notification Format Error');
        }
    }
}
function clearAll() {
    var elements = document.getElementsByTagName("input");
    for (var ii = 0; ii < elements.length; ii++) {
        if (elements[ii].type === "text") {
            elements[ii].value = "";
        } else if (elements[ii].type === "hidden") {
            elements[ii].value = null;
        } else if (elements[ii].type === "checkbox") {
            elements[ii].checked = false;
        } else if (elements[ii].type === "checkbox") {
            elements[ii].checked = false;
        }
    }
    var selectTags = document.getElementsByTagName("select");
    for (var i = 0; i < selectTags.length; i++) {
        selectTags[i].selectedIndex = 0;
    }
}
function getBool(data) {
    if (data === "true") {
        return true;
    }
    else if (data === "false") {
        return false;
    }
}
var monthNames = ["January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"];
var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

function convertDatetoString(date) {
    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();

    return day + ' ' + monthNames[monthIndex] + ' ' + year;
}
function confirmMsg() {
    return confirm("Do you want to proceed?");
}

/**
 * @param {string} divId The string
 */
function showDiv(divId) {
    var element = document.getElementById(divId);
    if (element != null) {
        element.classList.remove("hidden");
        return true;
    } else {
        console.log("The Show div function did not find your Id: " + divId + ".");
        return false;
    }
    
}
/**
 * @param {string} divId The string
 */
function hideDiv(divId) {
    var element = document.getElementById(divId);
    if (element != null) {
        element.classList.add("hidden");
        return true;
    } else {
        console.log("The Hide div function did not find your Id: " + divId + ".");
        return false;
    }
    
}
function openModal() {
    $('#myModal').modal('show');
}
function closeModal() {
    $('#myModal').modal('hide');
}
function showLoader() {
    createLoaderDiv();
    document.getElementById('loading').style.display = 'block';
}

function hideLoader() {
    document.getElementById('loading').style.display = "none";
}

function createLoaderDiv() {
    var prvDiv = document.getElementById('loading');
    if (prvDiv == null) {
        var iDiv = document.createElement('div');
        iDiv.id = 'loading';
        iDiv.className = 'loading';
        document.getElementById('UpdatePanel0').appendChild(iDiv);
    }
}

