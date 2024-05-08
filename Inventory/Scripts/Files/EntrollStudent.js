define(["jquery", "kendo"], function ($) {
    var Student = function (response, params) {
        $("#Imgprogressbar").show();
        var objWelshLangProficiency = [];
        var objFluent = { value: 1, Name: 'Fluent' };
        var objInteract = { value: 2, Name: 'Interact with other welsh speakers' };
        var objUseBasic = { value: 3, Name: 'Use basic expressions' };
        var objNone = { value: 4, Name: 'None' };
        objWelshLangProficiency.push(objFluent);
        objWelshLangProficiency.push(objInteract);
        objWelshLangProficiency.push(objUseBasic);
        objWelshLangProficiency.push(objNone);
        response.partial("Templates/EntrollStudent.handlebars").then(function () {
            var data = {};
            var lststudents = null;
            $.ajax({
                url: Commonuri + StudentGet,
                type: "Get",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $("#Imgprogressbar").hide();
                    if (data == null || (data != null && data.length == 0)) {
                        $("#diverrormsg").show();
                        $("txtsearch").css("display", "none");
                        $("#lblerrorMsg").html("No Records Found");
                        return false;
                    }
                    else {
                        $("#diverrormsg").show();
                        $("#lblerrorMsg").hide();
                        $("#txtsearch").css("display", "block");
                        lststudents = data;
                        LoadStudentGrid(data);
                    }
                },
                error: function () {
                    $("#Imgprogressbar").hide();
                    alert('Error');
                }
            });

            $("#btnEntrollStudent").unbind().click(function (p) {
                p.preventDefault();
                AddStudent(0);
            });

            function LoadStudentGrid(data) {
                $("#gridbindstudent").kendoGrid({
                    dataSource: data,
                    schema: {
                        model: {
                            fields: {
                                studentId: { type: "number" },
                                name: { type: "string" },
                                dateOfBirth: { type: "datetime" },
                                universityCourse: { type: "string" },
                                startDate: { type: "datetime" },
                                endDate: { type: "datetime" },
                                welshLanguageProficiency: { type: "number" }
                            }
                        }
                    },
                    pageable: {
                        refresh: true,
                        pageSizes: [5, 10, 20, 50],
                        pageSize: 10,
                        filterable: true,
                        buttoncount: 5,
                        sortable: true
                    },
                    sortable: {
                        mode: "single"
                    },
                    columns: [
                        {
                            field: "studentId",
                            title: "Student ID",
                            headerAttributes: {
                                style: "text-align:center;font-weight:600"
                            },
                            attributes: { "class": "some", style: "text-align:center" },
                        },
                    {
                        field: "name",
                        title: "Student Name",
                        headerAttributes: {
                            style: "text-align:center;font-weight:600"
                        },
                        attributes: { "class": "someclass", style: "text-align:center" },

                    },
                    {
                        field: "dateOfBirth",
                        title: "Date of Birth",
                        headerAttributes: {
                            style: "text-align:center;font-weight:600"
                        },
                        attributes: { "class": "someclass", style: "text-align:center" },
                        template: function (data) {
                           // var date = new Date(data.dateOfBirth),
                            //yr = date.getFullYear(),
                            //month = date.getMonth() + 1,
                            //day = date.getDate(),
                            newDate = data.dateOfBirth.split("T")[0]
                            //newDate = month + '/' + day + '/' + yr + ' ' + date.toLocaleTimeString();
                            return newDate;
                        }
                    },
                        {
                            field: "universityCourse",
                            title: "University Course",
                            headerAttributes: {
                                style: "text-align:center;font-weight:600"
                            },
                            attributes: { "class": "someclass", style: "text-align:center" },

                        },
                    {
                        field: "startDate",
                        title: "Start Date",
                        headerAttributes: {
                            style: "text-align:center;font-weight:600"
                        },
                        attributes: { "class": "someclass", style: "text-align:center" },
                        template: function (data) {
                            if (data.startDate) {
                                newDate = data.startDate.split("T")[0]
                                return newDate;
                            }
                            else {
                                return '';
                            }
                        }
                        },
                        {
                            field: "endDate",
                            title: "End Date",
                            headerAttributes: {
                                style: "text-align:center;font-weight:600"
                            },
                            attributes: { "class": "someclass", style: "text-align:center" },
                            template: function (data) {
                                if (data.endDate) {
                                    newDate = data.endDate.split("T")[0]
                                    return newDate;
                                }
                                else {
                                    return '';
                                }
                            }
                        },
                        {
                            field: "welshLanguageProficiency",
                            title: "Welsh Language Proficiency",
                            headerAttributes: {
                                style: "text-align:center;font-weight:600"
                            },
                            attributes: { "class": "some", style: "text-align:center" },
                            template: function (data) {
                                if (data.welshLanguageProficiency) {
                                    debugger
                                   var laguage = objWelshLangProficiency[data.welshLanguageProficiency-1].Name
                                    return laguage;
                                }
                                else {
                                    return '';
                                }
                            }
                        },
                    {
                        title: "Action",
                        headerAttributes: {
                            style: "text-align:center;font-weight:600"
                        },
                        attributes: { "class": "someclass", style: "text-align:center" },
                        template: function (obj) {
                            var lnkDelete = '';
                            var lnkEdit = '';
                            lnkEdit = "<a id='lnkEdit_" + obj.studentId + "' style='padding: 0px 5px;cursor: pointer;text-decoration : none'>" + " Edit" + " </a>";
                            lnkDelete = "<a id='lnkDelete_" + obj.studentId + "'style='cursor: pointer;text-decoration : none'>" + "Delete" + "</a>";
                            return lnkEdit + lnkDelete;
                        }
                    }
                    ],
                    dataBound: (function () {

                        $("a[id^=lnkEdit_]").click(function () {
                            var id = this.id.split("_")[1];
                            if (id && id > 0) {
                                EditStudent(id);
                            }
                        });

                        $("a[id^=lnkDelete_]").click(function () {
                            var confirmmsg = confirm("Are you sure you want to delete?");
                            var id = this.id.split("_")[1];
                            if (confirmmsg && id && id > 0) {
                                $.ajax({
                                    type: "delete",
                                    url: Commonuri + StudentDelete + "?id=" + id,
                                    dataType: 'json',
                                    success: function (res) {
                                        if (res) {
                                            alert("Deleted successfully");
                                        }
                                    },
                                    error: function (res) {
                                        alert(res);
                                    }
                                });
                                window.location.hash = "";
                                window.location.hash = "#/EntrollStudent";
                            }

                        });

                    })

                });
            };

            $("#txtsearch").keyup(function (p) {
                var array = [];
                debugger
                var Studentvalue = $('#txtsearch').val();
                if (Studentvalue && Studentvalue.trim() != '') {
                    $.each(lststudents, function (j, obj) {
                        if (obj.name.toLowerCase().includes(Studentvalue.toLowerCase()))
                            array.push(obj);
                        if (!isNaN(Studentvalue) && obj.studentId == Studentvalue) {
                                array.push(obj);
                        }
                    });
                    if ((array || []).length > 0) {
                        $("#gridbindstudent").show();
                        $("#diverrormsg").show();
                        LoadStudentGrid(array);
                        $("#lblerrorMsg").hide();
                    }
                    else {
                        debugger
                        $("#gridbindstudent").hide();
                        $("#diverrormsg").show();
                        $("#diverrormsg").css("display", "block");
                        $("#lblerrorMsg").css("display", "block");
                        $("#lblerrorMsg").html("No Records Found");
                    }
                }
                else {
                    window.location.hash = "";
                    window.location.hash = "#/EntrollStudent";
                }


            });

            var AddStudent = function (id) {               
                $("#Imgprogressbar").show();
                response.partial("Templates/AddStudent.handlebars").then(function (data) {
                    $("#dobDate").kendoDatePicker();
                    $("#startDate").kendoDatePicker();
                    $("#endDate").kendoDatePicker();
                    $("#WelshLangProficiency").kendoDropDownList();
                    $("#btnsubmit").click(function () {
                        if (ValidateStudentDetails()) {
                            insertorupdate(0);
                        }
                        else {
                            return false;
                        }

                    });
                    $("#btnCancel").click(function () {
                        $("#txtName").val('');
                        $("#dobDate").val('');
                        $("#txtUC").val('');
                        $("#startDate").val('');
                        $("#endDate").val('');
                        $("#WelshLangProficiency").val('1');
                        window.location.hash = "";
                        window.location.hash = "#/EntrollStudent";
                    });
                });
                $("#Imgprogressbar").hide();
            };

            function ValidateStudentDetails() {
                var isValid = true;
                if (!$("#txtName").val()) {
                    isValid = false;
                    $("#spnName").css("display", "block");
                    $("#spnName").css("color", "red");
                }
                else
                    $("#spnName").css("display", "none");

                if (!$("#txtUC").val()) {
                    isValid = false;
                    $("#spnUC").css("display", "block");
                    $("#spnUC").css("color", "red");
                }
                else
                    $("#spnUC").css("display", "none");

                if (!$("#dobDate").val()) {
                    isValid = false;
                    $("#spndobDate").css("display", "block");
                    $("#spndobDate").css("color", "red");
                }
                else
                    $("#spndobDate").css("display", "none");

                if (!$("#startDate").val()) {
                    isValid = false;
                    $("#spnstartDate").css("display", "block");
                    $("#spnstartDate").css("color", "red");
                }
                else
                    $("#spnstartDate").css("display", "none");

                if (!$("#endDate").val()) {
                    isValid = false;
                    $("#spnendDate").css("display", "block");
                    $("#spnendDate").css("color", "red");
                }
                else
                    $("#spnendDate").css("display", "none");

                return isValid;
            }

            function insertorupdate(id) {
                var obj = {
                    studentId: (id && id > 0) ? id : 0,
                    name: $("#txtName").val(),
                    dateOfBirth: $("#dobDate").val(),
                    universityCourse: $("#txtUC").val(),
                    startDate: $("#startDate").val(),
                    endDate: $("#endDate").val(),
                    welshLanguageProficiency: $("#WelshLangProficiency").val()
                }
                $.ajax({
                    url: Commonuri + StudentInsertorupdate + "?id=" + id,
                    type: "POST",
                    data: JSON.stringify(obj),
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        window.location.hash = "";
                        window.location.hash = "#/EntrollStudent";
                        $("#divsuccessmsg").show();
                        $("#diverrormsg").hide();
                        $("#lblSuccessMsg").html(data);
                        $("#divsuccessmsg").delay("500").fadeOut('slow');
                    },
                    error: function (res) {
                        $("#diverrormsg").show();
                        $("#divsuccessmsg").hide();
                        $("#lblerrorMsg").html("Unknown Error Found");
                    }

                });
            };

            var EditStudent = function (id) {
                StudentId = id;
                if (id && id > 0) {
                    $.ajax({
                        type: "GET",
                        url: Commonuri + StudentGetbyid + "?id=" + id,
                        dataType: 'json',
                        success: function (res) {
                            if (res) {
                                data = res;
                                $("#Imgprogressbar").show();
                                data.dateOfBirth = data.dateOfBirth.split("T")[0];
                                data.startDate = data.startDate.split("T")[0];
                                data.endDate = data.endDate.split("T")[0];
                                debugger
                                response.partial("Templates/AddStudent.handlebars", data).then(function () {
                                    $("#WelshLangProficiency").kendoDropDownList({
                                        dataTextField: "Name",
                                        dataValueField: "value",
                                        dataSource: objWelshLangProficiency,
                                        optionLabel: "--Select--",
                                        value: res.welshLanguageProficiency,
                                    });
                                    $("#btnsubmit").click(function () {
                                        if (ValidateStudentDetails()) {
                                            insertorupdate(StudentId);
                                        }
                                        else {
                                            return false;
                                        }
                                    });

                                    $("#btnCancel").click(function () {
                                        $("#txtName").val('');
                                        $("#dobDate").val('');
                                        $("#txtUC").val('');
                                        $("#startDate").val('');
                                        $("#endDate").val('');
                                        $("#WelshLangProficiency").val('1');
                                        window.location.hash = "";
                                        window.location.hash = "#/EntrollStudent";
                                    });

                                });
                                $("#Imgprogressbar").hide();
                            }
                        },
                        error: function (res) {
                            alert(res);
                        }
                    });
                }
            };

        });
    }
    return {
        Student: Student
    }
});


