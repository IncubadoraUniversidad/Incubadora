
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
                { "mData": "StrTelefonoCelular" },
                { "mData": "StrGrupoDescripcion" },
                { "mData": "StrPeriodoEstadia" },
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
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="Imprimir('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-print"></i></a>`

                    }

                },
            ],
        });
    };

});
var AddEditar = (Id) => {

    var url = "/Estudiante/AddEditDatosEstudiante?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var AddEliminar = (Id) => {
    var url = "/Estudiante/AddDeleteEstudiante?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var Imprimir = (Id) => {

    var url = "/Reporte/Estudiantes";
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("hide");
        alert("Se ha descargado el archivo")
    })
};
