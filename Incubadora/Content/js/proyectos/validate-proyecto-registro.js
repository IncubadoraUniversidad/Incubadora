$(document).ready(function () {
    const rowParent = $('#stepper-step-3');
    $('#addRecurso').click(function () {
        const rowElements = rowParent.find("div.row");
        rowElements[rowElements.length - 1].after($.parseHTML(getFormGroup().trim())[0]);
    });

    $('#btnGuardar').click(function (e) {
        e.preventDefault();
        $(this).prop('disabled', true);
        registrarProyecto(getProyectoViewModelObject());
    });

    $('#IntConstituidaLegal').change(function () {
        $('#StrObservaciones').prop('disabled', ($(this).val() !== '4'));
    });

    const getFormGroup = () => {
        const formGroup = `
            <div class="row margin-bottom">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="">Nombre del recurso</label>
                        <input class="form-control" placeholder="Nombre del recurso" required />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="">Descripción del recurso</label>
                        <input class="form-control" placeholder="Descripción del recurso" required />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="">Nombre de la persona que lo aporta</label>
                        <input class="form-control" placeholder="Nombre de la persona" required />
                    </div>
                </div>
                <div class="col-md-12">
                    <button type="button" class="btn btn-danger btn-sm" onclick="onFormGroupDelete(this)">Eliminar</button>
                </div>
            </div>
        `;
        return formGroup;
    };

    const registrarProyecto = (data) => {
        $.ajax({
            type: "Post",
            url: `/Proyecto/Registro`,
            dataType: "Json",
            data,
            success: function (resp) {
                $('#btnGuardar').prop('disabled', false);
                toastr.success("El proyecto se registró correctamente", "Ok", { closeButton: true, timeOut: 2500 });
            },
            error: function (xhr, textStatus, errorThrown) {
                $('#btnGuardar').prop('disabled', false);
                toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Error", { closeButton: true, timeOut: 2500 });
                console.log(textStatus);
            }
        });
    };

    const getProyectoViewModelObject = () => {
        const serviciosUniversitarios = [];
        $('#ServiciosUniversitarios').val().forEach(id => {
            serviciosUniversitarios.push({
                IdServicio: id,
            });
        });
        const recursosProyectos = [];
        rowParent.find("div.row").each(function (index) {
            recursosProyectos.push({
                StrValor: this.children[0].children[0].children[1].value,
                StrDescripcion: this.children[1].children[0].children[1].value,
                StrNombrePersona: this.children[2].children[0].children[1].value,
            });
        });
        const proyectoVM = {
            StrNombre: $('#StrNombre').val(),
            StrNombreEmpresa: $('#StrNombreEmpresa').val(),
            IdGiro: $('#IdGiro').val(),
            StrDescripcion: $('#StrDescripcion').val(),
            IdFase: $('#IdFase').val(),
            IntConstituidaLegal: $('#IntConstituidaLegal').val(),
            StrObservaciones: $('#IntConstituidaLegal').val() === '4' ? $('#StrObservaciones').val() : null,
            StrRFC: $('#StrRFC').val(),
            DtFechaRegistro: $('#DtFechaRegistro').val(),
            ServiciosUniversitariosVM: serviciosUniversitarios,
            RecursosProyectosVM: recursosProyectos,
        };
        return proyectoVM;
    };
});

function onFormGroupDelete(element) {
    console.log(element.parentElement.parentElement);
    element.parentElement.parentElement.remove();
}