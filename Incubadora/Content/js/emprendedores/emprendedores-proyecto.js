
$(document).ready(function () {

   $.ajax({
        type: "Get",
        url: '/Emprendedor/GetEmprendedoresProyectos',
        dataType: "Json",
       success: function (data) {
            console.log(data);
            BindDataTable(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            toastr.error("No se pudo procesar la información de forma correcta, intenta de nuevo por favor", "Campaña dice", { timeOut: 1000, closeButton: true });
            console.log(textStatus);
        }
    });

    var BindDataTable = (response) => {
        $('#TableEmpredndedor').DataTable({
            "language": {
                search: "Buscar:",
                "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es-mx.json"
            },
            "aaData": response,
            "aoColumns": [
                { "mData": "StrNombre" },
                { "mData": "StrNombreEmpresa" },
                { "mData": "EmprendedorDomainModel.StrNombre" },
                { "mData": "EmprendedorDomainModel.StrApellidoPaterno" },
                { "mData": "EmprendedorDomainModel.StrApellidoMaterno" },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="AddRecurso('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-user-plus"></i></a>`
                    }

                },
                {
                    "mData": "Id",
                    "render": (Id ,type, full, meta) => {  ///, type, full, meta
                        return `<a href="#" onclick="AddEditar('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-user-edit"></i></a>`
                    }
                    
                },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="AddEliminar('${Id}')" class="btn btn-sm btn-danger"><i class="fas fa-trash-alt"></i></a>`
                    }

                },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="Imprimir('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-print"></i></a>`

                    }

                },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="Exportar('${Id}')" class="btn btn-sm btn-default" id="btnExportar"><i class="fas fa-file-download"></i></a>`

                    }

                },
            ],
        });
    };
  
});
var AddRecurso = (Id) => {

    var url = "/RecursoProyecto/Edit?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var AddEditar = (Id) => {

    var url = "/Emprendedor/AddEditDatosProyectoEmprendedor?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var AddEliminar = (Id) => {
    var url = "/Proyecto/AddDeleteProyectoEmprendedor?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var Imprimir = (Id) => {

    var url = "/Reporte/Imprimir?Id=" + Id;
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("show");
    })
};
var Exportar = (Id) => {

    //var url = "/Proyecto/Exporta?Id=" + Id;
    //window.open(url)

    $("#btnExportar").click(function (event) {
        event.preventDefault();
        var request = new XMLHttpRequest();

        request.responseType = "blob";
        request.open("GET", "/Proyecto/Exporta?Id=" + Id);
        ///request.open("GET", "/Impresion/Reporte?idMovilizador=" + id);
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getUTCDate();
        var hour = d.getHours();
        var minutes = d.getMinutes();
        var seconds = d.getSeconds();
        var output = d.getFullYear() +
            (month < 10 ? '0' : '') + month +
            (day < 10 ? '0' : '') + day +
            (hour < 10 ? '0' : '') + hour +
            (minutes < 10 ? '0' : '') + minutes +
            (seconds < 10 ? '0' : '') + seconds;
        request.onload = function () {
            var url = window.URL.createObjectURL(this.response);
            var a = document.createElement("a");
            document.body.appendChild(a);
            a.href = url;
            a.download = this.response.name || "Incubadora" + output;
            a.click();
        }
        request.send();
    });
};