$(document).ready(function () {

    $('.jaime').click(function (e) {
        e.preventDefault();
        var id = $(this).attr("id");
       // alert("T'as liké le post" + id);

        $.ajax({
            type: "POST",
            url: "/Post/Jaime",
            data: id,
            dataType: "int",
            success: function (result) {
                console.dir(result);
            },
            error: function () {
                alert("Post déja liké");
            }

        });
    });


        });