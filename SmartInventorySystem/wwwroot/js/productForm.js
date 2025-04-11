$(document).ready(function () {
    $('#addProductForm').on('submit', function (e) {
        e.preventDefault(); 

        var form = $(this);
        var formData = form.serialize(); 

        $('#formMessage').html('<img src="images/spinner.gif" alt="Loading..." />');

        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: formData,
            success: function (result) {
                setTimeout(function () {
                    $('#formMessage').html('<div class="alert alert-success">Product added successfully!</div>');
                    form.trigger('reset');

                    $('#productResults').load('/ProjectManagement/Products/Search?term=');
                }, 500)
                
            },
            error: function () {
                $('#formMessage').html('<div class="alert alert-danger">Something went wrong.</div>');
            }
        });
    });
});
