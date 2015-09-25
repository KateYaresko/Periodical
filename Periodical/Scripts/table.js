$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#editions-table tfoot th').each(function () {
        var title = $('#editions-table thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var table = $('#editions-table').DataTable();

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
				.search(this.value)
				.draw();
        });
    });

    // Setup - add a text input to each footer cell
    $('#users-table tfoot th').each(function () {
        var title = $('#users-table thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var usersTable = $('#users-table').DataTable();

    // Apply the search
    usersTable.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
				.search(this.value)
				.draw();
        });
    });

    // Setup - add a text input to each footer cell
    $('#categories-management-table tfoot th').each(function () {
        var title = $('#categories-management-table thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var catTable = $('#categories-management-table').DataTable();

    // Apply the search
    catTable.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
				.search(this.value)
				.draw();
        });
    });

    // Setup - add a text input to each footer cell
    $('#editions-management-table tfoot th').each(function () {
        var title = $('#editions-management-table thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var edTable = $('#editions-management-table').DataTable();

    // Apply the search
    edTable.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
				.search(this.value)
				.draw();
        });
    });

    // Setup - add a text input to each footer cell
    $('#articles-management-table tfoot th').each(function () {
        var title = $('#articles-management-table thead th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var artTable = $('#articles-management-table').DataTable();

    // Apply the search
    artTable.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            that
				.search(this.value)
				.draw();
        });
    });
});