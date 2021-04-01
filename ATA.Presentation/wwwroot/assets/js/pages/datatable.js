var tableMain = $('#data-table-Staff').DataTable({
    "columnDefs": [{
        "targets": 3,
        "orderable": false
    }],
    "pageLength": 10
});

$(window).on( 'resize', function () {
    $('#data-table').css("width", "100%");
} );