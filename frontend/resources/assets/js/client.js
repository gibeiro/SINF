$(document).ready(function () {
    //get id of client
    var id = $('#id').attr('content');
    /**
     * Get info
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/client/info?id='+id,
        datatype: 'application/json',
        success: function (data) {
            $('#client_name').append(data.NomeCliente);
            $('#nif').append(data.NumContribuinte);
            $('#address').append(data.Morada);
            $('#client_code').append(data.CodCliente);
        }
    });
    /**
     * Get top products
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/client/products?id='+id,
        datatype: 'application/json',
        success: function (data) {
            $.each(data,function(index, element) {
                $('#top_products').append("<li>" + element.DescArtigo + "</li>")
            });
        }
    });
    /**
     * Get cost earns and profit
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/client/volume?id='+id,
        datatype: 'application/json',
        success: function (data) {
            volume_chart(data);
        }
    });
});

function volume_chart(volume) {
    var labels = [];

    var data=[];
    var colors = [
        'rgba(240,100,100,0.4)',
        'rgba(240,240,100,0.4)',
        'rgba(100,100,240,0.4)',
        'rgba(100,240,100,0.4)',
        'rgba(100,240,240,0.4)'
    ];
    $.each(volume, function(index,element){
        labels.push(element.Data);
        data.push(element.TotalMerc);
    });
    console.log(data)
    ctx = document.getElementById('myLineChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "Volume",
                    data: data,
                    backgroundColor: colors[0]
                },
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Purchasing Volume'
            },
            tooltips: {
                mode: 'index',
                intersect: false,
            },
            hover: {
                mode: 'nearest',
                intersect: true
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

