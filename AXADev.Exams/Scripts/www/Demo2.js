$(document).ready(function () {

    $(".custom-file-input").on("change", function () {
        checkuploadfile(this);
        var fileName = $(this).val().split("\\").pop();
        $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
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