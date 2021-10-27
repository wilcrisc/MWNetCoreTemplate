// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("year").innerText = new Date().getFullYear();
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
                    if (res.isValid) {
                        $('#viewTicket').html(res.html)
                        $('#form-modal').modal('hide');
                    }
                },
                error: function (err) {
                    console.log(err)
                }
            })
            return false;
        } catch (ex) {
            console.log(ex)
        }
    }


});