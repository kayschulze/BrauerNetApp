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

    $('#edit-module').submit(function (event) {
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
    });

    $('.display-project-modules').click(function () {
        $.ajax({
            url: '@Url.Action("DisplayModules")',
            type: 'GET',
            data: $(this).serialize(),
            dataType: 'json',

            success: function (result) {
                var hola = "<h1>Hola!</h1>";
                $('#moduleProjectResult').html(hola);
            }
        });
    });
});

            /*$('#edit-module').submit(function (event) {
                event.preventDefault();   
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: $(this).serialize(),
                    success: function(result) {
                        $("#editModuleProjectResult").html("hiya");
                    }
    
                }); 
            });
        });
});// Write your JavaScript code.*/
