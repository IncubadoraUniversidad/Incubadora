$(document).ready(function () {
    //$('#btnGuardar').prop('disabled', true);

    //$('#FechaInicio').keyup(function () {
    //    let data = $(this).val();
    //    if (data == "") {
    //        $('#btnGuardar').prop('disabled', true);

    //    }
    //    else {
    //        $('#btnGuardar').prop('disabled', false);
    //    }
    //});
$('#idSubmodulo').change(function () {
    const idSubmodulo = $(this).val();
    $('#idSesiones').prop('disabled', true);
    $('#idSesiones').find('option').remove();
    if (idSubmodulo !== '' || idSubmodulo.length > 0) {
        getSesionesBySubModuloId(idSubmodulo);
    }
});
    const getSesionesBySubModuloId = (submoduloId) => {
        $.ajax({
            type: "Get",
            url: `/Calendarizacion/GetSesionesBySubModuloId?idSubmodulo=${submoduloId}`,
            dataType: "Json",
            success: function (data) {
                $('#idSesiones').find('option').remove();
                const defaultOption = `<option value="">Selecciona una opcion</option>`;
                $('#idSesiones').append(defaultOption);
                $.each(data, (i) => {
                    const option = `<option value="${data[i].Id}">${data[i].StrValor}</option>`;
                    $('#idSesiones').append(option);
                });
                $('#idSesiones').prop('disabled', false);
            },
            error: function (xhr, textStatus, errorThrown) {
                //toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Campaña dice", { timeOut: 1000, closeButton: true });
                console.log(textStatus);
            }
        });
    };
});