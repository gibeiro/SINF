var ctx = document.getElementById('myDonutChart').getContext('2d');
var myPieChart = new Chart(ctx,{
    type: 'doughnut',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Items in hand',
            'To be recieved'
        ],
        datasets: [{
            data: [70, 30],
            backgroundColor: [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)',
                'rgba(100,100,240,0.7)',
                'rgba(100,240,100,0.7)'
            ]
        }]
    },
    options: {
        centertext: '100'
    }
});

ctx = document.getElementById('turnOverChart').getContext('2d');
var myPieChart2 = new Chart(ctx,{
    type: 'bar',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Red',
            'Yellow',
            'Blue',
            'Green'
        ],
        datasets: [{
            data: [20, 50, 20,10],
            backgroundColor: [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)',
                'rgba(100,100,240,0.7)',
                'rgba(100,240,100,0.7)'
            ]
        }]
    },
    options: {
        responsive: true,
        title:{
            display:true,
            text:'Income Expenses'
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
                    beginAtZero:true
                }
            }]
        }
    }
});

ctx = document.getElementById('myPieChart3').getContext('2d');
var myPieChart3 = new Chart(ctx,{
    type: 'pie',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Red',
            'Yellow',
            'Blue',
            'Green'
        ],
        datasets: [{
            data: [20, 50, 20,10],
            backgroundColor: [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)',
                'rgba(100,100,240,0.7)',
                'rgba(100,240,100,0.7)'
            ]
        }]
    }
});



Chart.pluginService.register({
    beforeDraw: function (chart) {
        if (chart.options.gaugetext) {
            var width = chart.chart.width,
                height = chart.chart.height,
                ctx = chart.chart.ctx;

            ctx.restore();
            var fontSize = (height / 80).toFixed(2); // was: 114
            ctx.font = fontSize + "em sans-serif";
            ctx.textBaseline = "middle";

            var text = chart.options.gaugetext, // "75%",
                textX = Math.round((width - ctx.measureText(text).width) / 2),
                textY = height / 2 - (chart.titleBlock.height - 155);

            ctx.fillText(text, textX, textY);
            ctx.save();
        }
        if(chart.options.centertext){
            var width = chart.chart.width,
                height = chart.chart.height,
                ctx = chart.chart.ctx;

            ctx.restore();
            var fontSize = (height / 80).toFixed(2); // was: 114
            ctx.font = fontSize + "em sans-serif";
            ctx.textBaseline = "middle";

            var text = chart.options.centertext, // "75%",
                textX = Math.round((width - ctx.measureText(text).width) / 2),
                textY = height / 2 - (chart.titleBlock.height - 15);

            ctx.fillText(text, textX, textY);
            ctx.save();
        }
    }
});

