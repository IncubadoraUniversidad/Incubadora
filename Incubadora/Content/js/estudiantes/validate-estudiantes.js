$(document).ready(function () {
    $('#nextButtonStep1').prop('disabled', true);
    $('#nextButtonStep2').prop('disabled', true);
    $('#nextButtonStep3').prop('disabled', true);
    $('#submitButtonStep4').prop('disabled', true);
    const formControlIds = [
        '#txtNombre',
        '#txtApellidoPaterno',
        '#txtApellidoMaterno',
        '#txtFechaNacimiento',
        '#txtTelefonoFijo',
        '#txtTelefonoCelular',
        '#IdUnidadAcademica',
        '#IdGrupo',
        '#StrGrupoDescripcion',
        '#IdPeriodoEstadia',
        '#txtNombreemprendimiento',
        '#txtDescripcion',
        '#IdStatus',
        '#IdCarrera'
    ];
    const soloLetrasRegex = /^[A-ZÁÉÍÓÚÑ\s]+$/i;
    const soloNumerosRegex = /^[0-9]*$/m;
    const ddlGrupo = $('#IdGrupo');
    const ddlPeriodoEstadia = $('#IdPeriodoEstadia');
    const ddlUnidadAcademica = $('#IdUnidadAcademica');
    const ddlCarrera = $('#IdCarrera');
    const ddlStatus = $('#IdStatus');
    const disableControls = (skip = 1, until) => {
        const controls = formControlIds.slice(skip, until);
        controls.forEach(controlId => {
            $(controlId).prop('disabled', true);
        });
    };
    disableControls(1, formControlIds.length);

    $('#txtNombre').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(1, 4);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(1, 4);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        $('#txtApellidoPaterno').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtApellidoPaterno').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(2, 4);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(2, 4);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        $('#txtApellidoMaterno').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtApellidoMaterno').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(3, 4);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(3, 4);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        $('#txtFechaNacimiento').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtFechaNacimiento').change(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#nextButtonStep1').prop('disabled', false);
        $('#step-2').removeClass('disabled');
        $('#txtTelefonoFijo').prop('disabled', false);
    });

    $('#txtTelefonoFijo').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (!soloNumerosRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta números');
            disableControls(5, 6);
            $('#nextButtonStep2').prop('disabled', true);
            $('#step-3').addClass('disabled');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#txtTelefonoCelular').prop('disabled', false);
    });

    $('#txtTelefonoCelular').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#nextButtonStep2').prop('disabled', true);
            $('#step-3').addClass('disabled');
            return;
        }
        if (!soloNumerosRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta números');
            $('#nextButtonStep2').prop('disabled', true);
            $('#step-3').addClass('disabled');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        ddlUnidadAcademica.prop('disabled', false);
        ddlCarrera.prop('disabled', true);
        ddlCarrera.find('option').remove();
        $('#step-3').removeClass('disabled');
        $('#nextButtonStep2').prop('disabled', false);
    });

    ddlUnidadAcademica.change(function () {
        const idUnidadAcademica = $(this).val();
        const parentElement = this.parentElement;
        ddlCarrera.prop('disabled', true);
        if (idUnidadAcademica === '' || idUnidadAcademica.length === 0) {
            disableControls(8, 11);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
        } else {
            parentElement.classList.remove('has-error');
            hideInputError(parentElement.lastElementChild);
            getCarrerasByUnidadAcademicaId(idUnidadAcademica);
        }
    });

    ddlCarrera.change(function () {
        const idCarrera = $(this).val();
        const parentElement = this.parentElement;
        if (idCarrera === '' || idCarrera.length === 0) {
            disableControls(8, 11);
            ddlCuatrimestre.prop('disabled', true);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        ddlGrupo.prop('disabled', false);
    });

    ddlGrupo.change(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            disableControls(8, 11);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#StrGrupoDescripcion').prop('disabled', false);
    });

    $('#StrGrupoDescripcion').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(9, 11);
            $('#nextButtonStep3').prop('disabled', true);
            $('#step-3').addClass('disabled');
            return;
        }
        ddlPeriodoEstadia.prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    ddlPeriodoEstadia.change(function () {
        const idPeriodoEstadia = $(this).val();
        const parentElement = this.parentElement;
        if (idPeriodoEstadia.length === 0 || idPeriodoEstadia === '') {
            disableControls(10, 11);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#step-3').removeClass('disabled');
        $('#nextButtonStep3').prop('disabled', false);
        $('#txtNombreemprendimiento').prop('disabled', false);
    });

    $('#txtNombreemprendimiento').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(12, 14);
            $('#submitButtonStep4').prop('disabled', true);
            $('#step-4').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(12, 14);
            $('#submitButtonStep4').prop('disabled', true);
            $('#step-4').addClass('disabled');
            return;
        }
        $('#txtDescripcion').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtDescripcion').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(13, 14);
            $('#submitButtonStep4').prop('disabled', true);
            $('#step-4').addClass('disabled');
            return;
        }
        ddlStatus.prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    ddlStatus.change(function () {
        const idStatus = $(this).val();
        const parentElement = this.parentElement;
        if (idStatus.length === 0 || idStatus === '') {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#submitButtonStep4').prop('disabled', true);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#submitButtonStep4').prop('disabled', false);
    });

    const getCarrerasByUnidadAcademicaId = (unidadAcademicaId) => {
        $.ajax({
            type: "Get",
            url: `/Carrera/GetCarrerasByUnidadAcademicaId?unidadAcademicaId=${unidadAcademicaId}`,
            dataType: "Json",
            success: function (data) {
                ddlCarrera.find('option').remove();
                const defaultOption = `<option value="">Selecciona una carrera</option>`;
                ddlCarrera.append(defaultOption);
                $.each(data, (i) => {
                    const option = `<option value="${data[i].Id}">${data[i].StrValor}</option>`;
                    ddlCarrera.append(option);
                });
                ddlCarrera.prop('disabled', false);
            },
            error: function (xhr, textStatus, errorThrown) {
                //toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Campaña dice", { timeOut: 1000, closeButton: true });
                console.log(textStatus);
            }
        });
    };

    const showInputError = (element, message) => {
        const jqueryElement = $(element);
        jqueryElement.text(message);
        jqueryElement.show();
    };

    const hideInputError = (element) => {
        $(element).hide();
    };
});