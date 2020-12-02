$(document).ready(function () {

    $('.fairecom').click(function (e) {
        e.preventDefault();
        var id = $(this).attr("id"); 
        var content = $("#"+id+" textarea").val();
       
       
           //  alert(content);
            // alert("T'as liké le post" + id);
        var Data = {

            content: content,
            postID : id

        };
        console.log(Data);
        $.ajax({
            type: "POST",
            url: "/Post/createpost",
            data: Data,
            dataType: "text",
            success: function () {
                location.reload();

            },
            error: function (e) {
                console.log(e);
                alert("Erreur")
            }

        });


    });

});