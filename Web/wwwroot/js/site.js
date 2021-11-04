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



