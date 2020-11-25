$(document).ready(function () {

    $('.jaime').click(function (e) {
        e.preventDefault();
        var id = $(this).attr("id");
        alert("T'as liké le post" + id);

        $.ajax({
            type: "POST",
            url: "/Post/Jaime",
            data: id,
            dataType: "int",
            success: function () {
                alert("Post liké");
            },
            error: function () {
                alert("Post déja liké");
            }

        });
    });


        });