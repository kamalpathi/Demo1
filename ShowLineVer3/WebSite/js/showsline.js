//$(document).ready(function () {
    function ValidateNum(input, event) {

        var keyCode = event.which ? event.which : event.keyCode;
        if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
            return true;
        }

        return false;

    }

    function ValidateName(input, event) {
        var keyCode = event.which ? event.which : event.keyCode;
        //Small Alphabets
        if (parseInt(keyCode) >= 97 && parseInt(keyCode) <= 122) {
            return true;
        }
        //Caps Alphabets
        if (parseInt(keyCode) >= 65 && parseInt(keyCode) <= 90) {
            return true;
        }
        //Space-Return-Dot
        if (parseInt(keyCode) == 32 || parseInt(keyCode) == 13 || parseInt(keyCode) == 46) {
            return true;
        }
        input.focus();
        return false;

        //alert(keyCode);
    }
//});