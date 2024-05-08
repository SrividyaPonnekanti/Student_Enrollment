define(["jquery", "sammy", "handlebars", "sammy.handlebars", "Files/UriTemplate"], function ($, sammy, Handlebars, hb, kendo) {
    var app = function () {
        var single = this;
        var Home = function () {
            var self = this;
            require(["Files/Home"], function (objHome) {
                objHome.Home(self, single);
            });
        }
        var EntrollStudent = function () {
            var self = this;
            require(["Files/EntrollStudent"], function (objStudent) {
                debugger
                objStudent.Student(self, single);
            });
        }
        this.Single = sammy("#page", function () {
            this.use(hb);
            this.get("#/Home", Home);
            this.get("#/EntrollStudent", EntrollStudent);
        });
        return this;

    }();
    $(app.Single.run("#/Home"));
});
