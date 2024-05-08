define(["jquery", "sammy", "handlebars", "sammy.handlebars"], function ($, sammy, Handlebars, hb) {
    var Home = function (response, params) {
        response.partial("Templates/Home.handlebars").then(function () {
            $("#EntrollStudent").click(function () {
                window.location.hash = '',
                    window.location.hash = '#/EntrollStudent';
            });
        });
    }
    return {
        Home: Home
    }

});

