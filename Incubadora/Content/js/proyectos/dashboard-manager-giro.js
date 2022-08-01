


$(document).ready(function () {
    $.ajax({
        type: "Get",
        url: "/Proyecto/GetEstadisticasEmpresarialesByGiro",
        dataType: "Json",
        success: function (data) {
            var titulos = [];
            var datos = [];
            $.each(data, function (i) {
                titulos[i] = data[i].Giro;
                datos[i] = data[i].Total;
            });
            grafica(titulos, datos);
            
         
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(textStatus);
        }
    }),

        $.ajax({
            type: "Get",
            url: "/Proyecto/Tabla",
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
        $('#TablaDatos').DataTable({
            "language": {
                search: "Buscar:",
                "url": "//cdn.datatables.net/plug-ins/1.11.3/i18n/es-mx.json"
                
            },
            "responsive": true,
            "autoWidth": false,
            
            "aaData": response,
            "aoColumns": [
                { "mData": "Nombre" },
                { "mData": "Giro" },
                {
                    "mData": "Id",
                    "render": (Id, type, full, meta) => {
                        return `<a href="#" onclick="Detalles('${Id}')" class="btn btn-sm btn-default"><i class="fas fa-eye"></i></a>`
                    }

                }
            ],
        });
    };
});





var grafica = (m, c) => {
    var ctx = document.getElementById('ChartGiro');
    var mychart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: m,
            datasets: [{
                label: '#Gráfica de Proyectos',
                data: c,
                backgroudColor: [
                    'rgba(255, 99, 132, 0.2', 'rgba(54, 162, 235, 0.2)', 'rgba(255, 206, 86, 0.2)', 'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2', 'rgba(255, 159, 64, 0.2)', 'rgba(255, 99, 132, 0.2)', 'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 99, 132, 0.2', 'rgba(75, 192, 192, 0.2)', 'rgba(153, 102, 255, 0.2)', 'rgba(255, 159, 64, 0.2)',
                    'rgba(255, 99, 132, 0.2)', 'rgba(54, 162, 235, 0.2)', 'rgba(255, 206, 86, 0.2)', 'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)', 'rgba(255, 159, 64, 0.2)', 'rgba(255, 99, 132, 0.2)', 'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)', 'rgba(75, 192, 192, 0.2)', 'rgba(153, 102, 255, 0.2)', 'rgba(255, 159, 64, 0.2)',
                    'rgba(255, 99, 132, 0.2)', 'rgba(54, 162, 235, 0.2)', 'rgba(255, 206, 86, 0.2)', 'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)', 'rgba(255, 159, 64, 0.2)', 'rgba(255, 99, 132, 0.2)', 'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)', 'rgba(75, 192, 192, 0.2)', 'rgba(153, 102, 255, 0.2)', 'rgba(255, 159, 64, 0.2)',
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)', 'rgba(54, 162, 235, 1)', 'rgba(255, 206, 86, 1)', 'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)', 'rgba(255, 159, 64, 1)', 'rgba(255, 99, 132, 1)', 'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)', 'rgba(75, 192, 192, 1)', 'rgba(153, 102, 255, 1)', 'rgba(255, 159, 64, 1)',
                    'rgba(255, 99, 132, 1)', 'rgba(54, 162, 235, 1)', 'rgba(255, 206, 86, 1)', 'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)', 'rgba(255, 159, 64, 1)',
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
};

var Detalles = (Id) => {

    var url = "/Proyecto/DetailsProject?Id=" + Id;
    $("#myModalBodyDetails").load(url, function () {
        $("#myModalDetails").modal("show");
    })
};
var ReporteGeneral = (Id) => {

    var url = "/Reporte/Proyectos";
    $("#myModalBody").load(url, function () {
        $("#myModalEdit").modal("hide");
        alert("Se ha descargado el archivo")
    })
};