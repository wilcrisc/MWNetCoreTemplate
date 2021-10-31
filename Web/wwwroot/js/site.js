// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setTimeout(() => {
    AOS.init();
}, 120);

document.getElementById("year").innerText = new Date().getFullYear();

var preloader = document.getElementById("preloader");
window.addEventListener('load', function () {
    if (preloader != 'undefined' && preloader != null) {
        preloader.classList.add("hideLoader");
    }
})

console.log(`%c
                              ,,,,,,,,,,,,,,,,,,,
                         ,,,,.                   ,,,,
                     ,,,,                            ,,,,
                  .,,,                                  .,,,
                ,,,                                        ,,,
               ,,                                            ,,
              ,, ******.                                      ,,, *
             ,, *****************                              ,*/*
            ,,  *********************                        **///*
            ,,  ***********************               ,***////////.
            ,,  **********//************       ***///////////////*
            ,,  *************(#***********///////////((//////////,
             ,,  **************##/*/////////////##//////////////*.
             ,,   **************////////////###////////////////*,
              ,,.   **********///////////###(/////////////////*,
               ,,,    ,*******/////////####/////////////////*,,
                 ,,       ****///////####/////////////////*,,,
                  ,,,         */////####///////////////**,,,
                    ,,,        ,*//####/////////////** ,,,
                      ,,,        */###(/////////***. .,,
                        ,,        ####*********,    ,,,
                         ,,       ####             ,,
                          ,,      ####            ,,
                          ,,      ...             ,,
                          ,,,,,,,,,,,,,,,,,,,,,,,,,,
                         ,,,,,,,,,,,,,,,,,,,,,,,,,,,,
                          ,,,,,,,,,,,,,,,,,,,,,,,,,,

                          ,,,,,,,,,,,,,,,,,,,,,,,,,,,
                          ,,,,,,,,,,,,,,,,,,,,,,,,,,,
                                ,,,,,,,,,,,,,,,,

                               Mindweb eSolutions 

`, 'background: #f9f9f9 ; color: #006937');




$(document).ready(function () {

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    jQueryModalGet = (url, title) => {
        try {
            $.ajax({
                type: 'GET',
                url: url,
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#form-modal .modal-body').html(res.html);
                    $('#form-modal .modal-title').html(title);
                    $('#form-modal').modal('show');
                },
                error: function (err) {
                    console.log(err)
                    Command: toastr["error"]("Something went wrong!");
                }
            })
            //to prevent default form submit event
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalPost = form => {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {

                    $('#viewTicket').html(res.html)
                    $('#form-modal').modal('hide');

                    //if Ticket id > 0 or Ticket ID != 0
                    if (res.action) {
                        //update
                        Command: toastr["info"]("Ticket Successfully Updated");
                    } else {
                        //insert
                        Command: toastr["success"]("Ticket Successfully Inserted");
                    }
                },
                error: function (err) {
                    console.log(err)
                    Command: toastr["error"]("Something went wrong!");
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }

    jQueryModalDelete = form => {
        if (confirm('Are you sure to delete this record ?')) {
            try {
                $.ajax({
                    type: 'POST',
                    url: form.action,
                    data: new FormData(form),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        $('#viewTicket').html(res.html);
                        Command: toastr["info"]("Ticket Successfully Deleted");
                    },
                    error: function (err) {
                        console.log(err);
                        Command: toastr["error"]("Something went wrong!");
                    }
                })
            } catch (ex) {
                console.log(ex)
            }
        }
        return false;
    }

});