$(document).ready(function () {

    $('#login').click(function () {

        var data_user = { "log_username": $("#login-username").val(), "log_password": $("#login-password").val() };

        $.ajax({
            type: "POST",
            url: "/Login",
            data: data_user,
            dataType: "text",
            success: function () {
                console.log("OKOKOKOKOKOKOKOK");
            }

        });

    });
});
