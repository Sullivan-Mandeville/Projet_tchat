﻿$(document).ready(function () {

    $('#send').click(function (e) {
        e.preventDefault();
        let btn = document.getElementById('send');
      
        //  alert($("#contenu_message textarea").val());
        var content = $("#contenu_message textarea").val();
 
        var Data = {

            content: content
         
        };
        if (content != null && content != " ") {

      
        console.log(Data);
        $.ajax({
            type: "POST",
            url: "/Contact/createmessage",
            data: Data,
            dataType: "text",
            success: function () {
                // location.reload();
                $('input[type="text"],textarea').val("");
                $content.val("");
              
               
            
               
           

            },
            error: function (e) {
                console.log(e);
            }

        });
        }

    });

});