$(document).ready(function () {
    $('#nextButtonStep1').prop('disabled', true);
    $('#nextButtonStep2').prop('disabled', true);
    $('#submitButtonStep3').prop('disabled', true);
    const formControlIds = [
        '#txtNombre',
        '#txtApellidoPaterno',
        '#txtApellidoMaterno',
        '#txtCurp',
        '#txtFechaNacimiento',
        '#txtEmail',
        '#txtCalle',
        '#IdEstado',
        '#txtTelefonoFijo',
        '#txtTelefonoCelular',
        '#IntOcupacion',
        '#DatoLaboralObservaciones',
    ];
    const soloLetrasRegex = /^[A-ZÁÉÍÓÚÑ\s]+$/i;
    const curpRegex = /^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$/;
    const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const soloNumerosRegex = /^[0-9]*$/m;
    const ddlMunicipio = $('#IdMunicipio');
    const ddlColonia = $('#IdColonia');
    const ddlUnidadAcademica = $('#IdUnidadAcademica');
    const ddlCarrera = $('#IdCarrera');
    const ddlCuatrimestre = $('#IdCuatrimestre');
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
            disableControls(1, 6);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(1, 6);
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
            disableControls(2, 6);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(2, 6);
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
            disableControls(3, 6);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(3, 6);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        $('#txtCurp').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtCurp').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(4, 6);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!validateCurp(value.toUpperCase())) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'El CURP introducido no es válido');
            disableControls(4, 6);
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
            disableControls(5, 6);
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        $('#txtEmail').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtEmail').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        if (!emailRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'El email no es válido');
            $('#nextButtonStep1').prop('disabled', true);
            $('#step-2').addClass('disabled');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#nextButtonStep1').prop('disabled', false);
        $('#step-2').removeClass('disabled');
        $('#txtCalle').prop('disabled', false);
    });

    $('#txtCalle').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(7, 10);
            $('#nextButtonStep2').prop('disabled', true);
            $('#step-3').addClass('disabled');
            return;
        }
        $('#IdEstado').prop('disabled', false);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#IdEstado').change(function () {
        const idEstado = $(this).val();
        const parentElement = this.parentElement;
        ddlMunicipio.prop('disabled', true);
        ddlMunicipio.find('option').remove();
        ddlColonia.prop('disabled', true);
        ddlColonia.find('option').remove();
        $('#nextButtonStep2').prop('disabled', true);
        $('#step-3').addClass('disabled');
        if (idEstado !== '' || idEstado.length > 0) {
            getMunicipiosByEstadoId(idEstado);
            disableControls(8, 10);
            parentElement.classList.remove('has-error');
            hideInputError(parentElement.lastElementChild);
        } else {
            parentElement.classList.add('has-error');
            disableControls(8, 10);
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
        }
    });

    ddlMunicipio.change(function () {
        const idMunicipio = $(this).val();
        const parentElement = this.parentElement;
        $('#nextButtonStep2').prop('disabled', true);
        $('#step-3').addClass('disabled');
        ddlColonia.prop('disabled', true);
        if (idMunicipio === '' || idMunicipio.length === 0) {
            ddlColonia.find('option').remove();
            disableControls(8, 10);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
        } else {
            disableControls(8, 10);
            getColoniasByMunicipioId(idMunicipio);
            parentElement.classList.remove('has-error');
            hideInputError(parentElement.lastElementChild);
        }
    });

    ddlColonia.change(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        $('#nextButtonStep2').prop('disabled', true);
        $('#step-3').addClass('disabled');
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(8, 10);
        } else {
            parentElement.classList.remove('has-error');
            hideInputError(parentElement.lastElementChild);
            $('#txtTelefonoFijo').prop('disabled', false);
            $('#txtTelefonoCelular').prop('disabled', false);
        }
    });

    $('#txtTelefonoFijo').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (!soloNumerosRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta números');
            disableControls(9, 10);
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
        $('#step-3').removeClass('disabled');
        $('#nextButtonStep2').prop('disabled', false);
        $('#IntOcupacion').prop('disabled', false);
    });

    $('#IntOcupacion').change(function () {
        const idOcupacion = $(this).val();
        const parentElement = this.parentElement;
        if (idOcupacion === '' || idOcupacion.length === 0) {
            ddlUnidadAcademica.prop('disabled', true);
            ddlCarrera.prop('disabled', true);
            ddlCarrera.find('option').remove();
            ddlCuatrimestre.prop('disabled', true);
            disableControls(11, 12);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#submitButtonStep3').prop('disabled', true);
        } else if (idOcupacion === '1') {
            ddlUnidadAcademica.prop('disabled', false);
            $('#submitButtonStep3').prop('disabled', true);
            parentElement.classList.remove('has-error');
            hideInputError(parentElement.lastElementChild);
            disableControls(11, 12);
        } else {
            parentElement.classList.remove('has-error');
            hideInputError(parentElement.lastElementChild);
            ddlUnidadAcademica.prop('disabled', true);
            ddlCarrera.prop('disabled', true);
            ddlCarrera.find('option').remove();
            ddlCuatrimestre.prop('disabled', true);
            $('#submitButtonStep3').prop('disabled', true);
            $('#DatoLaboralObservaciones').prop('disabled', false);
        }
    });

    ddlUnidadAcademica.change(function () {
        const idUnidadAcademica = $(this).val();
        const parentElement = this.parentElement;
        ddlCarrera.prop('disabled', true);
        ddlCuatrimestre.prop('disabled', true);
        $('#submitButtonStep3').prop('disabled', true);
        if (idUnidadAcademica === '' || idUnidadAcademica.length === 0) {
            disableControls(11, 12);
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
        $('#submitButtonStep3').prop('disabled', true);
        if (idCarrera === '' || idCarrera.length === 0) {
            disableControls(11, 12);
            ddlCuatrimestre.prop('disabled', true);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        ddlCuatrimestre.prop('disabled', false);
    });

    ddlCuatrimestre.change(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            disableControls(11, 12);
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#submitButtonStep3').prop('disabled', true);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#submitButtonStep3').prop('disabled', false);
    });

    $('#DatoLaboralObservaciones').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        $('#strDatoLaboralObservacionesHint').text(`${$(this).val().length}/245`);
        if (value.length === 0 || value === '') {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#submitButtonStep3').prop('disabled', true);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#submitButtonStep3').prop('disabled', false);
    });

    const getMunicipiosByEstadoId = (estadoId) => {
        $.ajax({
            type: "Get",
            url: `/Municipio/GetMunicipiosByEstadoId?idEstado=${estadoId}`,
            dataType: "Json",
            success: function (data) {
                ddlMunicipio.find('option').remove();
                const defaultOption = `<option value="">Selecciona un municipio</option>`;
                ddlMunicipio.append(defaultOption);
                $.each(data, (i) => {
                    const option = `<option value="${data[i].Id}">${data[i].StrNombre}</option>`;
                    ddlMunicipio.append(option);
                });
                ddlMunicipio.prop('disabled', false);
            },
            error: function (xhr, textStatus, errorThrown) {
                //toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Campaña dice", { timeOut: 1000, closeButton: true });
                console.log(textStatus);
            }
        });
    };

    const getColoniasByMunicipioId = (municipioId) => {
        $.ajax({
            type: "Get",
            url: `/Colonia/GetColoniasByMunicipioId?idMunicipio=${municipioId}`,
            dataType: "Json",
            success: function (data) {
                ddlColonia.find('option').remove();
                const defaultOption = `<option value="">Selecciona una colonia</option>`;
                ddlColonia.append(defaultOption);
                $.each(data, (i) => {
                    const option = `<option value="${data[i].Id}">${data[i].StrNombre}</option>`;
                    ddlColonia.append(option);
                });
                ddlColonia.prop('disabled', false);
            },
            error: function (xhr, textStatus, errorThrown) {
                //toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Campaña dice", { timeOut: 1000, closeButton: true });
                console.log(textStatus);
            }
        });
    };

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

    const validateCurp = (value) => {
        const curpRegexMatch = value.match(curpRegex);
        if (curpRegexMatch === null) {
            return false;
        }
        const curpDigit = Number.parseInt(curpRegexMatch[2]);
        return curpDigit === validateCurpDigit(curpRegexMatch[1]);
    };

    const validateCurpDigit = (curp17) => {
        const diccionario = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        let lngSuma = 0.0;
        let lngDigito = 0.0;
        for (let i = 0; i < 17; i++) {
            lngSuma = lngSuma + diccionario.indexOf(curp17.charAt(i)) * (18 - i);
        }
        lngDigito = 10 - lngSuma % 10;
        if (lngDigito === 10) {
            return 0;
        }
        return lngDigito;
    }
});