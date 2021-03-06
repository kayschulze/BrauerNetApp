﻿$(document).ready(function () {
    $(".nav-tabs a").click(function (event) {
        event.preventDefault();
        console.log("Hi");
        $(this).tab('show');
        console.log("There");
    });

    /*$("div.module-tab-menu>div.list-group>a").click(function (e) {
        e.preventDefault();
        $(this).siblings('a.active').removeClass("active");
        $(this).addClass("active");
        var index = $(this).index();
        $("div.module-tab>div.module-tab-content").removeClass("active");
        $("div.module-tab>div.module-tab-content").eq(index).addClass("active");
    }); */

    /*$(".tab").click(function (event, moduleName) {
        console.log("Groovy");
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(moduleName).style.display = "block";
        event.currentTarget.className += " active";
    }; */

    $('#create-questor').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("Create", "QUESTORs")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newQUESTORModuleResult').html("cool!");
            }
        });
    });

    $('.display-module').click(function () {
        $.ajax({
            url: '@Url.Action("DisplayModule")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (result) {
                $('#QUESTORModuleResult').html(hola);
            }
        });
    });

    $('#edit-module').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditModule", "Modules")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#editQUESTORModuleResult').html("yoyo!");
            }
        });
    });

    $('#create-goal').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateGoal", "Goals")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newQUESTORGoalResult').html("cool!");
            }
        });
    });

    $('.display-goal').click(function () {
        $.ajax({
            url: '@Url.Action("DisplayGoal")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',

            success: function (result) {
                $('#QUESTORGoalResult').html(hola);
            }
        });
    });

    $('#edit-goal').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditGoal", "Goals")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log("Edit goal.");

                $('#editQUESTORGoalResult').html("yoyo!");
            }
        });
    });

    $('#create-module').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateModule", "Modules")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newModuleProjectResult').html("cool!");
            }
        });
    });

    $('.display-project').click(function () {
        $.ajax({
            url: '@Url.Action("ProjectDetails")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (result) {
                $('#ModuleProjectResult').html(hola);
            }
        });
    });

    $('#edit-project').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditProject", "Projects")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#editModuleProjectResult').html("yoyo!");
            }
        });
    });

    $('#create-project').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateProject", "Projects")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newModuleProjectResult').html("cool!");
            }
        });
    });

    $('#create-step').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateStep", "Steps")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newProjectStepResult').html("cool!");
            }
        });
    });

    $('.display-step').click(function () {
        $.ajax({
            url: '@Url.Action(DetailsStep")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',

            success: function (result) {
                $('#ProjectStepResult').html(hola);
            }
        });
    });

    $('#edit-step').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditStep", "Steps")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#editProjectStepResult').html("yoyo!");
            }
        });
    });

    $('#create-response').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateResponse", "Responses")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newProjectResponseResult').html("cool!");
            }
        });
    });

    $('.display-response').click(function () {
        $.ajax({
            url: '@Url.Action(DetailsResponse")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (result) {
                $('#ProjectResponseResult').html(hola);
            }
        });
    });

    $('#edit-response').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditResponse", "Responses")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#editProjectResponseResult').html("yoyo!");
            }
        });
    });

    $('#create-standard').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateStandard", "Standards")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#newProjectStandardResult').html("cool!");
            }
        });
    });

    $('.display-standard').click(function () {
        $.ajax({
            url: '@Url.Action(DetailsStandard")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',
            success: function (result) {
                $('#ProjectStandardResult').html(hola);
            }
        });
    });

    $('#edit-standard').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditStandard", "Standards")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#editProjectStandardResult').html("yoyo!");
            }
        });
    });
});
