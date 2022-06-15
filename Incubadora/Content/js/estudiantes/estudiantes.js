
$(document).ready(function () {

    $.ajax({
        type: "Get",
        url: `/Estudiante/GetEstudiantes`,
        dataType: "Json",
        success: function (data) {
            BindDataTable(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Campaña dice", { timeOut: 1000, closeButton: true });
            console.log(textStatus);
        }
    });

    var BindDataTable = (response) => {
        $('#TableEstudiante').DataTable({
            "language": {
                search: "Buscar:",
                "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es-mx.json"
            },
            "aaData": response,
            "aoColumns": [
                { "mData": "StrNombre" },
                { "mData": "StrApellidoPaterno" },
                { "mData": "StrApellidoMaterno" },
                { "mData": "FechaNacimiento" },
                { "mData": "TelefonoDomainModel.StrTelefonoCelular" },
                { "mData": "GrupoDomainModel.StrValor" },
                { "mData": "PeriodoEstadiaDomainModel.StrValor" },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="AddEditar('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-user-edit"></i></a>`
                    }

                },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="AddEliminar('${Id}')" class="btn btn-sm btn-danger"><i class="fas fa-trash-alt"></i></a>`
                    }

                },
            ],
        });
    };

});
var AddEditar = (Id) => {

    var url = "/Emprendedor/AddEditDatosProyectoEmprendedor?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var AddEliminar = (Id) => {
    var url = "/Proyecto/AddDeleteProyectoEmprendedor?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
