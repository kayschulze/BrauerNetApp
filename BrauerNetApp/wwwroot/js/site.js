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
                    type: 'POST',
                    dataType: 'json',
                    data: $(this).serialize(),
                    success: function(result) {
                        $("#editModule").html("hiya");
                    }
    
                });
            });
        });// Write your JavaScript code.
