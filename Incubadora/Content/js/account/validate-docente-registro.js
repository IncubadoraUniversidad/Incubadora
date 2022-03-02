$(document).ready(function () {
    const formControlIds = [
        '#txtNombre',
        '#txtApellidoPaterno',
        '#txtApellidoMaterno',
        '#ddlIdSexo',
        '#txtEmail',
        '#txtUsername',
        '#txtPasswordHash'
    ];
    const soloLetrasRegex = /^[A-ZÁÉÍÓÚÑ]+$/i;
    const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    $('#btnRegistro').prop('disabled', true);

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
        if (value.length === 0 || value === '') {
            $('#btnRegistro').prop('disabled', true);
            disableControls(1, formControlIds.length);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras sin espacios en blanco');
            $('#btnRegistro').prop('disabled', true);
            disableControls(1, formControlIds.length);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#txtApellidoPaterno').prop('disabled', false);
    });

    $('#txtApellidoPaterno').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            $('#btnRegistro').prop('disabled', true);
            disableControls(2, formControlIds.length);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras sin espacios en blanco');
            $('#btnRegistro').prop('disabled', true);
            disableControls(2, formControlIds.length);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#txtApellidoMaterno').prop('disabled', false);
    });

    $('#txtApellidoMaterno').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            $('#btnRegistro').prop('disabled', true);
            disableControls(3, formControlIds.length);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras sin espacios en blanco');
            $('#btnRegistro').prop('disabled', true);
            disableControls(3, formControlIds.length);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#ddlIdSexo').prop('disabled', false);
    });

    $('#ddlIdSexo').change(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            $('#btnRegistro').prop('disabled', true);
            disableControls(4, formControlIds.length);
            return;
        }
        $('#txtEmail').prop('disabled', false);
    });

    $('#txtEmail').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            $('#btnRegistro').prop('disabled', true);
            disableControls(5, formControlIds.length);
            return;
        }
        if (!emailRegex.test(value)) {
            $('#btnRegistro').prop('disabled', true);
            disableControls(5, formControlIds.length);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#txtUsername').prop('disabled', false);
    });

    $('#txtUsername').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0 || value === '') {
            $('#btnRegistro').prop('disabled', true);
            disableControls(6, formControlIds.length);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras sin espacios en blanco');
            $('#btnRegistro').prop('disabled', true);
            disableControls(6, formControlIds.length);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#txtPasswordHash').prop('disabled', false);
    });

    $('#txtPasswordHash').keyup(function () {
        const parentElement = this.parentElement;
        const value = $(this).val();
        if (value.length === 0 || value === '') {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#btnRegistro').prop('disabled', true);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#btnRegistro').prop('disabled', false);
    });

    const showInputError = (element, message) => {
        const jqueryElement = $(element);
        jqueryElement.text(message);
        jqueryElement.show();
    };

    const hideInputError = (element) => {
        $(element).hide();
    };
});