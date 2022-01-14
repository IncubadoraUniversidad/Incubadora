$(document).ready(function () {

    $('#btnGuardar').prop('disabled', true);

    $('#UserName').keyup(function () {
        let data = $(this).val();
        if (data == "") {
            $('#PasswordHash').prop('disabled', true);
            $('#btnGuardar').prop('disabled', true);
        }
        else {
            $('#PasswordHash').prop('disabled', false);
        }
    });
    $('#PasswordHash').keyup(function () {
        let data = $(this).val();
        if (data == "") {
            $('#btnGuardar').prop('disabled', true);
        }
        else {
            $('#btnGuardar').prop('disabled', false);
        }
    });

    //$('#btnGuardar').click(function () {
    //    var AspNetUsersVM = {};

    //    $.ajax({
    //        type: "Get",
    //        url: "/Account/Create",
    //        dataType: "Json",
    //        success: function (data) {
                
    //        },
    //        error: function (xhr, textStatus, errorThrown) {
    //            toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Incubadora dice", { timeOut: 1000, closeButton: true });
                
    //        }
    //    });

    //});

    $.ajax({
        type: "Get",
        url: "/Account/GetUsuarios",
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
                { "mData": "UserName" },
                { "mData": "AspNetRolesVM.Name" },
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