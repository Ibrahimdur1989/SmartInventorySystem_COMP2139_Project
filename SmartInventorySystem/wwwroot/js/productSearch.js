$(document).ready(function () {
    $('#searchBox').on('keyup', function () {
        var term = $(this).val();

        $('#loader').show(); // show spinner

        $.ajax({
            url: '/ProjectManagement/Products/Search',
            data: { term: term },
            success: function (partialView) {
                $('#productResults').html(partialView);
            },
            complete: function () {
                $('#loader').hide(); // hide spinner
            }
        });
    });
});
