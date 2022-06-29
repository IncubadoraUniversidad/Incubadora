$(document).ready(function () {
    $('#btnGuardar').prop('disabled', true);
    const formControlIds = [
        '#txtNombreRecurso',
        '#txtNombrePersona',
        '#txtApellidoPaterno',
        '#txtApellidoMaterno',
        '#txtDescripcion'
    ];
    const soloLetrasRegex = /^[A-ZÁÉÍÓÚÑ\s]+$/i;
    const disableControls = (skip = 1, until) => {
        const controls = formControlIds.slice(skip, until);
        controls.forEach(controlId => {
            $(controlId).prop('disabled', true);
        });
    };
    disableControls(1, formControlIds.length);
    $('#txtNombreRecurso').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(1, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        $('#txtNombrePersona').prop('disabled', false);
        $('#btnGuardar').prop('disabled', true);
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
    });

    $('#txtNombrePersona').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(2, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(2, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        $('#txtApellidoPaterno').prop('disabled', false);
        $('#btnGuardar').prop('disabled', true);
        parentElement.classList.remove('has-error');
    });

    $('#txtApellidoPaterno').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(3, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(3, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        $('#txtApellidoMaterno').prop('disabled', false);
        $('#btnGuardar').prop('disabled', true);
        parentElement.classList.remove('has-error');
    });

    $('#txtApellidoMaterno').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            disableControls(4, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras');
            disableControls(4, 5);
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        $('#txtDescripcion').prop('disabled', false);
        $('#btnGuardar').prop('disabled', true);
        parentElement.classList.remove('has-error');
    });

    $('#txtDescripcion').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value === '' || value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#btnGuardar').prop('disabled', true);
            return;
        }
        parentElement.classList.remove('has-error');
        $('#btnGuardar').prop('disabled', false);
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