$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#editions-table tfoot th').each(function () {
        var title = $('#editions-table thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var table = $('#editions-table').DataTable();

    // Setup - add a text input to each footer cell
    $('#users-table tfoot th').each(function () {
        var title = $('#users-table thread th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var table = $('#users-table').DataTable();

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
				.search(this.value)
				.draw();
        });
    });
});