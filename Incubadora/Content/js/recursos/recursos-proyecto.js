$(document).ready(function () {

    $.ajax({
        type: "Get",
        url: `/RecursoProyecto/GetRecursos`,
        dataType: "Json",
        success: function (data) {
            BindDataTable(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Incubadora dice", { timeOut: 1000, closeButton: true });
            console.log(textStatus);
        }
    });

    var BindDataTable = (response) => {
        $('#TableEmpredndedor').DataTable({
            "language": {
                search: "Buscar:",
                "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es-mx.json"
            },
            "aaData": response,
            "aoColumns": [
                { "mData": "StrNombreRecurso" },
                { "mData": "StrNombrePersona" },
                { "mData": "StrApellidoPaterno" },
                { "mData": "StrApellidoMaterno" },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="Editar('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-user-edit"></i></a>`
                    }

                },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="Eliminar('${Id}')" class="btn btn-sm btn-danger"><i class="fas fa-trash-alt"></i></a>`
                    }

                },
            ],
        });
    };

});
const Editar = (Id) => {
    const url = `/RecursoProyecto/Edit?Id=${Id}`;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
const Eliminar = (Id) => {
    const url = `/RecursoProyecto/Delete?Id=${Id}`;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};