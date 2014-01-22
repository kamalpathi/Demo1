$(document).ready(function () {
    $('#txtPwd').keyup(function (e) {
        if (e.keyCode == 13) {
            __doPostBack('btnLogin', '');
        }
    });

    $('#txtUserName').keyup(function (e) {
        if (e.keyCode == 13) {
            __doPostBack('btnLogin', '');
        }
    });


    //REgister
    $('#txtFirstName').keyup(function (e) {
        if (e.keyCode == 13) {
            __doPostBack('btnRegister', '');
        }
    });

    $('#txtLastName').keyup(function (e) {
        if (e.keyCode == 13) {
            __doPostBack('btnRegister', '');
        }
    });

    $('#txtREmailID').keyup(function (e) {
        if (e.keyCode == 13) {
            __doPostBack('btnRegister', '');
        }
    });

    $('#txtMobileNo').keyup(function (e) {
        if (e.keyCode == 13) {
            __doPostBack('btnRegister', '');
        }
    });


});