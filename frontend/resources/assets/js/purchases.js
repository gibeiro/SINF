
$(document).ready(function () {
    $('#example').DataTable(
        {"dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>"}
    );
    /**
     * Get cost earns and profit
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/growth?y=2016',
        datatype: 'application/json',
        success: function (data) {
            growth = data;
            growth_chart(data);
        }
    });
});

function growth_chart(data) {
    var labels = [];

    var data_cost = [];
    var data_earn = [];
    var data_profit = [];
    var colors = [
        'rgba(240,100,100,0.4)',
        'rgba(240,240,100,0.4)',
        'rgba(100,100,240,0.4)',
        'rgba(100,240,100,0.4)',
        'rgba(100,240,240,0.4)'
    ];
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    $.each(data, function(index,element){
        labels.push(LABELS[index]);
        data_cost.push(element.Cost.toFixed(0));
        data_earn.push(element.Earn.toFixed(0));
        data_profit.push(element.Profit.toFixed(0));
    });
    ctx = document.getElementById('myLineChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "Purchases",
                    data: data_cost,
                    backgroundColor: colors[0]
                },
                {
                    label: "Budget",
                    data: data_earn,
                    backgroundColor: colors[1]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Purchases / Budget'
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


