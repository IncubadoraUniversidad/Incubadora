
$(document).ready(function () {
    $('#btnGuardar').prop('disabled', true);

    $('#Name').keyup(function () {
        let data = $(this).val();
        if (data == "") {
            $('#btnGuardar').prop('disabled', true);

        }
        else {
            $('#btnGuardar').prop('disabled', false);
        }
    });


    $.ajax({
        type: "Get",
        url: "/Rol/GetRoles",
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
        $('#TableRol').DataTable({
            "language": {
                search: "Buscar:",
                "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es-mx.json"
            },
            "aaData": response,
            "aoColumns": [
                { "mData": "Name" },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return '<a href="#" onclick="AddEditSolicitud(' + Id + ')" class="btn btn-sm btn-default"><i class="fas fa-user-edit"></i></a>'
                    }
                },
            ]
        });
    }

   
});