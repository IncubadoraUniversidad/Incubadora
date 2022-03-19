$(document).ready(function () {

    $('#StrNombreRecurso').keyup(function () {
        const value = $(this).val();
        const parentElement = this.parentElement;
        if (value.length === 0) {
            parentElement.classList.add('has-error');
            showInputError(parentElement.lastElementChild, 'Este campo es requerido');
            return;
        }
        parentElement.classList.remove('has-error');
        hideInputError(parentElement.lastElementChild);
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