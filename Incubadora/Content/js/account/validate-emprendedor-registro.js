$(document).ready(function () {
    const soloLetrasRegex = /^[A-ZÁÉÍÓÚÑ]+$/i;
    const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    $('#btnRegistro').prop('disabled', true);
    $('#txtEmail').prop('disabled', true);
    $('#txtPassword').prop('disabled', true);
    $('#txtUsername').keyup(function () {
        const parentElement = this.parentElement;
        const value = $(this).val();
        if (value.length === 0 || value === '') {
            //parentElement.classList.add('has-error');
            //showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#btnRegistro').prop('disabled', true);
            $('#txtEmail').prop('disabled', true);
            $('#txtPassword').prop('disabled', true);
            return;
        }
        if (!soloLetrasRegex.test(value)) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo solo acepta letras sin espacios en blanco');
            $('#btnRegistro').prop('disabled', true);
            $('#txtEmail').prop('disabled', true);
            $('#txtPassword').prop('disabled', true);
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
        $('#txtEmail').prop('disabled', false);
    });

    $('#txtEmail').keyup(function () {
        const parentElement = this.parentElement;
        const value = $(this).val();
        if (value.length === 0 || value === '') {
            //parentElement.classList.add('has-error');
            //showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            $('#btnRegistro').prop('disabled', true);
            $('#txtPassword').prop('disabled', true);
            return;
        }
        if (!emailRegex.test(value)) {
            //parentElement.classList.add('has-error');
            //showInputError(parentElement.lastElementChild, 'El formato de correo electrónico no es válido');
            $('#btnRegistro').prop('disabled', true);
            $('#txtPassword').prop('disabled', true);
            return;
        }
        //parentElement.classList.remove('has-error');
        //hideInputError(parentElement.lastElementChild);
        $('#txtPassword').prop('disabled', false);
    });

    $('#txtPassword').keyup(function () {
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