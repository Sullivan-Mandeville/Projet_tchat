﻿$(document).ready(function () {

    $('#send').click(function (e) {
        e.preventDefault();
        //  alert($("#contenu_message textarea").val());
        var content = $("#contenu_message textarea").val();
 
        var Data = {

            content: content
         
        };
        console.log(Data);
        $.ajax({
            type: "POST",
            url: "/Contact/createmessage",
            data: Data,
            dataType: "text",
            success: function () {
                location.reload();

            },
            error: function (e) {
                console.log(e);
            }

        });
      

    });

});