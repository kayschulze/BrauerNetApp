$(document).ready(function () {
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
            url: '@Url.Action("DisplayProject")',
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

    /*$('#edit-module').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("EditModule", "Modules")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $('#editModuleProjectResult').html("yoyo!");
            }
        });
    });*/
});
