$(document).ready(function () {

    $(function () {
        $('#date').datetimepicker({
            format: 'YYYY-MM-DD',
            minDate: new Date()
        });
        $('#time').datetimepicker({
            format: 'hA'
        });
    });

});

