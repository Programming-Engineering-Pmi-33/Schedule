
//$("#checkUsername").on("click", function () {
//    var res = $('#image').attr('src');
//    var convert = res.replace('data:image/png;base64,', '');
//    var byte = Uint8Array.from(atob(convert), c => c.charCodeAt(0))
//    console.log(byte);
//    console.log(res);

//    $.ajax({
//        url: 'http://localhost:8888/DoOCR/',
//        type: 'Post',
//        data: res,
//        success: function (responce) {
//            var res = responce;
//            $("body").append(res);


//            console.log(res);
//        },
//        error: function () {
//            $("body").append('Something went wrong');
//        }
//    });
//});