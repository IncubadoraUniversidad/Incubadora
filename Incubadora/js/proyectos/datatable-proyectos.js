$(document).ready(function () {
    $.ajax({
        type: "Get",
        url: '/Proyecto/GetProyectoGeneral',
        dataType: 'Json',
        success: function (data) {
            console.log(data);
            BindDataTable(data);
        },
        error: function (xhr, textStatus, errorThrow) {
            console.log(textStatus);
        }
    });

    var BindDataTable = (response) => {
        $('#TablaProyectos').DataTable({
            "language": {
                search: "Buscar:",
                "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es.mx.json"
            },
            "responsive": true,
            "destroy": true,
            "autoWidth": false,
            "aaData": response,
            "aoColums": [
                { "mData": "StrNombre" },
                { "mData": "StrNombreEmpresa" },
                { "mData": "IdGiro" },
                { "mData": "StrDescripcion" },
                { "mData": "IdFase" },
                { "mData": "IntConstituidaLegal" },
                { "mData": "StrObservaciones" },

            ],
        });
    };
});