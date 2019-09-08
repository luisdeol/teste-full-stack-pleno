// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function sendAnalytics(page) {
    var routeAnalytics = 'https://localhost:5001/api/v1/comportamentos';

    var json = JSON.stringify({
        nome: page,
        browser: navigator.userAgent
    });

    console.log(json);

    $.ajax({
        url: routeAnalytics,
        type: "POST",
        data: json,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
    
        }

    })
}