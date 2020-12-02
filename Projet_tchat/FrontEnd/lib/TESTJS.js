$(document).ready(function () {
    $('#content_post').summernote({
        placeholder: 'Ecrire le post',
        height: 150,
        minHeight: null,
        maxHeight: null,



    });

    $.ajax({
        type: 'POST',
        url: "/Post/GetPostByIDUser",
        dataType: 'json',
        success: function (result) {
            console.log(result);
            j = 0

            $(".USPOST").each(function () {

                $(this).summernote('code', '');
                $(this).summernote('pasteHTML', result[j].content);
                $(this).summernote('destroy');
                j++
            })
        },
        error: function (e) {
            alert("Error:Unable to load data from server");
        }
    });




});