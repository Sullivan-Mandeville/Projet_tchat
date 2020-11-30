$(document).ready(function () {

    $('.fairecom').click(function (e) {
        e.preventDefault();
          
        var content = $("#contenu_comment textarea").val();
        var id = $(this).attr("id");
       // alert($("#contenu_comment textarea").val());
        //alert("T'as liké le post" + id);
        var Data = {

            content: content,
            id : id

        };
        console.log(Data);
        $.ajax({
            type: "POST",
            url: "/Post/createpost",
            data: Data,
            dataType: "JSON",
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