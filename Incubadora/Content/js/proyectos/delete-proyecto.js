$(document).ready(function () {
    $('#btnEliminar').click(function () {
        let Id=$('#Id').val();
        $.ajax({
            type: "Post",
            url: '/Proyecto/EliminarProyecto?Id=' + Id,
            dataType: "Json",
            success: function (data) {
            },
            error: function (xhr, textStatus, errorThrown) {
                toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Incubadora dice", { timeOut: 1000, closeButton: true });
                console.log(textStatus);
            }
        });
    });
});