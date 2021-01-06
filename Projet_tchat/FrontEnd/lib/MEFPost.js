$(document).ready(function () {

    $('#content_post').summernote({
        placeholder: 'Ecrire le post',
        height: 500,
        minHeight: null,
        maxHeight: null,
       

       

    });


    
 
         $.ajax({
        type: 'POST',
        url: "/Post/GetPostContent",
        dataType: 'json',
        success: function (result) {
            console.log(result);
            j = 0
           
            $(".MEFPOST").each(function () {
               
                $(this).summernote('code','');
                $(this).summernote('pasteHTML', result[j].content);
                $(this).summernote('destroy');
                document.createElement('br');
                j++
            })
        },
        error: function (e) {
           // alert("Error:Unable to load data from server");
        }
         });


});