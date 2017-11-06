
var ctx = document.getElementById('myPieChart');
var myPieChart = new Chart(ctx,{
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

ctx = document.getElementById('myPieChart2');
var myPieChart2 = new Chart(ctx,{
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

ctx = document.getElementById('myPieChart3');
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


ctx = document.getElementById('myLineChart');
var myLineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [{
            label: "Income Expenses",
            data: [
                10,20,30,20,40,50,60
            ],
            fill: false,
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
        }
    }
});

/*ctx = document.getElementById('myGaugeChart');
var myGaugeChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels:['Revenue', 'Revenue'],
        datasets: [{
            data: [60,40],
            backgroundColor:[
                'rgba(200,100,150,9)',
                'rgba(200,150,200,9)'
            ]
        }]
    },
    options: {
        rotation: -1.5*Math.PI,
        circunference: 3*Math.PI
    }
});*/


//text in center
$("#circularGaugeContainer").dxCircularGauge({
    rangeContainer: {
        offset: 10,
        ranges: [
            { startValue: 800, endValue: 1000, color: '#41A128' },
            { startValue: 1000, endValue: 1500, color: '#2DD700' }
        ]
    },
    scale: {
        startValue: 0,  endValue: 1500,
        majorTick: { tickInterval: 250 },
        label: {
            format: 'currency'
        }
    },
    title: {
        text: 'Sales MTD',
        subtitle: 'test',
        position: 'top-center'
    },
    tooltip: {
        enabled: true,
        format: 'currency',
        customizeText: function (arg) {
            return 'Current ' + arg.valueText;
        }
    },
    subvalueIndicator: {
        type: 'textCloud',
        format: 'thousands',
        text: {
            format: 'currency',
            customizeText: function (arg) {
                return 'Goal ' + arg.valueText;
            }
        }
    },
    value: 900,
    subvalues: [825]
});