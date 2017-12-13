var growth_chart_data;
var myLineChart;
//just something to be here to get on your nerves
Date.prototype.ymd = function() {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return '' + this.getFullYear() +"-"+ (mm>9 ? '' : '0') + mm +"-"+ (dd>9 ? '' : '0') + dd;
};


function save_processed_data(data){
    var growth_data = [];
    var currentDay = 0;
	var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
		while(currentDay!=data[i].day){
			var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
			console.log(date);
            growth_data.push({day:currentDay, netsale:0, date: date.ymd()});
            currentDay++;
        }
        growth_data.push(data[i]);
        currentDay++;
    }
    return growth_data;
}

function growth_by_month(data){
	console.log("GROWTH_BY_MONTH");
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    var months=[];
    var currentElement=-1;
    $.each(data,function(index,element){
        var parts = element.date.split('-');
        if(newElement(months,parts[1]-1, parts[0])) {
            months.push({month: parts[1]-1, year: parts[0], netsale: element.netsale, label: LABELS[parts[1]-1]});
            currentElement++;
        }else{
            months[currentElement].netsale += element.netsale;
        }
    });
	console.log(months);
    return months;
}

function newElement(array, month, year){
    for(var i=0;i<array.length;i++){
        if(array[i].month == month && array[i].year == year){
            return false;
        }
    }
    return true;
}

$(document).ready(function () {
    var date_i = $('#date_i').val();
    var date_f = $('#date_f').val();
    /**
     * Get top clients
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/clients?limit=5',
        datatype: 'application/json',
        success: function (data) {
            var list = $('#top_clients');
            colors = [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)',
                'rgba(100,100,240,0.7)',
                'rgba(100,240,100,0.7)',
                'rgba(100,240,240,0.7)'
            ];

            $.each(data, function(index, element){
                if(index > 4) return;
                list.append("<li style='background-color: " + colors[index] + ";'><a href='"+$('meta[name=base_url]').attr('content') + "/client/" + element.id + "'>"+ element.name +"</a></li>");
            });
            top_clients_chart(data);
        }
    });
    /**
     * Get top products
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/products?limit=5',
        datatype: 'application/json',
        success: function (data) {
            var list = $('#top_products');
            colors = [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)',
                'rgba(100,100,240,0.7)',
                'rgba(100,240,100,0.7)',
                'rgba(100,240,240,0.7)'
            ];

            $.each(data, function(index, element){
                if(index > 4) return;
                list.append("<li style='background-color: " + colors[index] + ";'><a href='"+$('meta[name=base_url]').attr('content') + "/product/" + element.name + "'>"+ element.name +"</a></li>");
            });
            top_products_chart(data);
        }
    });
    /**
     * Get cost earns and profit
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/growth?from=' + date_i + '&to=' + date_f,
        datatype: 'application/json',
        success: function (data) {
            growth_chart_data = save_processed_data(data);
			growth_chart(growth_by_month(growth_chart_data), 'month');
            //growth_chart(growth_chart_data);
        }
    });

    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/revenue?year=' + date_f.split('-')[0],
        datatype: 'application/json',
        success: function (data) {
            revenue_chart(data.current,data.previous);
        }
    });
	
	$('input[type=radio]').on('change',function(){
	//val can be:  year, month, week, day
		switch($('input[type=radio]:checked').val()){
			case 'year':
				break;
			case 'month':
                var data_temp = growth_by_month(growth_chart_data);
                var type='month';
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

                $.each(data_temp, function(index,element){
                    if (type == 'day') labels.push(element.date);
                    if (type == 'month') labels.push(element.label);
                    data_earn.push(element.netsale.toFixed(0));
                });

                removeData(myLineChart);
                addData(myLineChart,labels,data_earn);
				break;
			case 'week':
				break;
			case 'day':
                var data_temp = growth_chart_data;
                var type='day';
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

                $.each(data_temp, function(index,element){
                    if (type == 'day') labels.push(element.date);
                    if (type == 'month') labels.push(element.label);
                    data_earn.push(element.netsale.toFixed(0));
                });

                removeData(myLineChart);
                addData(myLineChart,labels,data_earn);
				break;
		}
	});

	$('input[type=date]').on('change',function(){
	    var date_i = $('#date_i').val();
	    var date_f= $('#date_f').val();
        $.ajax({
            type: 'GET',
            url: 'http://localhost:49822/api/overview/growth?from=' + date_i + '&to=' + date_f,
            datatype: 'application/json',
            success: function (data) {
                growth_chart_data = save_processed_data(data);
                var data_temp = growth_by_month(growth_chart_data);
                var type='month';
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

                $.each(data_temp, function(index,element){
                    if (type == 'day') labels.push(element.date);
                    if (type == 'month') labels.push(element.label);
                    data_earn.push(element.netsale.toFixed(0));
                });

                removeData(myLineChart);
                addData(myLineChart,labels,data_earn);
            }
        });
    })
});

function removeData(chart) {
    while(chart.data.labels.length != 0){
        chart.data.labels.pop();
    }
    while(chart.data.datasets[0].data.length != 0) {
        chart.data.datasets[0].data.pop();
    }
    chart.update();
}

function addData(chart, labels, data) {
    for(var i=0;i<labels.length;i++)
    {
        chart.data.labels.push(labels[i]);
    }
    for(var i=0;i<data.length;i++)
    {
        chart.data.datasets[0].data.push(data[i]);
    }
    chart.update();
}

function top_clients_chart(clients){
    var labels= [];
    var data = [];
    colors = [
        'rgba(240,100,100,0.7)',
        'rgba(240,240,100,0.7)',
        'rgba(100,100,240,0.7)',
        'rgba(100,240,100,0.7)',
        'rgba(100,240,240,0.7)'
    ];
    $.each(clients, function(index, element){
        if(index > 4) return;
        labels.push(element.name);
        data.push(element.gross.toFixed(0));
    });
    var ctx = document.getElementById('myPieChart').getContext('2d');
    var myPieChart = new Chart(ctx,{
        type: 'pie',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors
            }]
        },
        options: {
            responsive: true,
            legend: {
                display: false,
                position: 'bottom',
            },
            title: {
                display: false
            }
        }
    });

}

function top_products_chart(top_products) {
    var labels = [];
    var data = [];
    colors = [
        'rgba(240,100,100,0.7)',
        'rgba(240,240,100,0.7)',
        'rgba(100,100,240,0.7)',
        'rgba(100,240,100,0.7)',
        'rgba(100,240,240,0.7)'
    ];
    $.each(top_products, function (index, element) {
        if (index > 4) return;
        labels.push(element.name);
        data.push(element.gross.toFixed(0));
    });
    ctx = document.getElementById('myPieChart2').getContext('2d');
    var myPieChart2 = new Chart(ctx, {
        type: 'pie',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors
            }]
        },
        options: {
            responsive: true,
            legend: {
                display: false,
                position: 'bottom',
            },
            title: {
                display: false
            }
        }
    });
}


function growth_chart(data, type) {
	
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
	
    $.each(data, function(index,element){
        if (type == 'day') labels.push(element.date);
		if (type == 'month') labels.push(element.label);
        data_earn.push(element.netsale.toFixed(0));
    });
    ctx = document.getElementById('myLineChart').getContext('2d');
    myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "Net Sales",
                    data: data_earn,
                    backgroundColor: colors[1]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Growth Over Time'
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

function revenue_chart(rev, rev_prev) {
    ctx = document.getElementById('myGaugeChart').getContext('2d');
    rev = Math.round(rev);
    rev_prev = Math.round(rev_prev);
    var config = {
        type: 'bar',
        data: {
            datasets: [
                {
                    label: "Previous Year",
                    data: [
                        rev_prev,
                    ],
                    backgroundColor: [
                        'rgba(100,100,255,0.8)'
                    ]
                },
                {
                    label: "This Year",
                    data: [
                        rev,
                    ],
                    backgroundColor: [
                        'rgba(255,100,100,0.8)'
                    ]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Revenue'
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
    };
    var myGaugeChart = new Chart(ctx, config);
}

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
        }else if(chart.options.centertext){
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

