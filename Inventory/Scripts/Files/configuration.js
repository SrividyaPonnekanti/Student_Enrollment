var objReqConfig = new Object();
objReqConfig.baseUrl = "Scripts/";
objReqConfig.paths = {
    jquery: 'jquery.min',
    sammy: 'sammy-0.7.5',
    handle: 'handlebars.min',
    boots: 'bootstrap.min',
    kendo: 'kendo.all.min'
}
objReqConfig.shim = {
    'sammy': {
        deps: ['jquery'],
        exports: 'Sammy'
    },
    'sammy.handlebars': {
        deps: ['handlebars']
    },
}
requirejs.config(objReqConfig);
require(["Files/App"], function () { });

