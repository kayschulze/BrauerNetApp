$(document).ready(function () {
    $('#create-module').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("CreateModule", "Modules")',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log("hey");

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
                console.log("hey");

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
                var hola = "<h1>Hola!</h1>"
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
