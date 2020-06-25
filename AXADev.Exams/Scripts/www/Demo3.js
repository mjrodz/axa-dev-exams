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

    $(document).on('submit', '#frmResumeSend', ResumeSendSubmit);
});

function ResumeSendSubmit() {
    var file = $("#file").val();
    if (file === "") {
        alert("Please select a file first to proceed");
        return false;
    }
    return true;
}


function checkuploadfile(me) {
    var ext = $(me).val().split('.').pop().toLowerCase();

    if (($.inArray(ext, ['pdf']) == -1) && ($(me).val() != "")) {
        $(me).val(null);
        alert("File must be a PDF document.");
    }

}