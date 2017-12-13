var growth_chart_data;
var volume_chart_data;

Date.prototype.ymd = function() {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return '' + this.getFullYear() +"-"+ (mm>9 ? '' : '0') + mm +"-"+ (dd>9 ? '' : '0') + dd;
};


function volume_processed_data(data){
    var volume_data = [];
    var currentDay = 0;
	var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
		while(currentDay!=data[i].day){
			var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            volume_data.push({day:currentDay, gross:0, date: date.ymd()});
            currentDay++;
        }
        volume_data.push(data[i]);
        currentDay++;
    }
    return volume_data;
}

function save_processed_data(data){
    var volume_data = [];
    var currentDay = 0;
	var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
		while(currentDay!=data[i].day){
			var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            volume_data.push({day:currentDay, sales:0, date: date.ymd()});
            currentDay++;
        }
        volume_data.push(data[i]);
        currentDay++;
    }
    return volume_data;
}

function sales_by_month(data){
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    var months=[];
    var currentElement=-1;
    $.each(data,function(index,element){
        var parts = element.date.split('-');
        if(newElement(months,parts[1]-1, parts[0])) {
            months.push({month: parts[1]-1, year: parts[0], sales: element.sales, label: LABELS[parts[1]-1]});
            currentElement++;
        }else{
            months[currentElement].sales += element.sales;
        }
    });
	console.log(months);
    return months;
}

function volume_by_month(data){
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    var months=[];
    var currentElement=-1;
    $.each(data,function(index,element){
        var parts = element.date.split('-');
        if(newElement(months,parts[1]-1, parts[0])) {
            months.push({month: parts[1]-1, year: parts[0], gross: element.gross, label: LABELS[parts[1]-1]});
            currentElement++;
        }else{
            months[currentElement].gross += element.gross;
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
    //get id of product
    var id = $('#id').attr('content');
    /**
     * Get product info
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/product/info?id='+id,
        datatype: 'application/json',
        success: function (data) {
            $('#product_name').append(data.description);
            $('#category').append(data.group);
            $('#in_stock').append(data.stk);
            $('#unit_cost').append(data.pcm);
            $('#unit_price').append(data.pvp);
            profit_chart(data);
        }
    });

    /**
     * Get product sales
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/product/sales?id='+id+'&from='+date_i+'&to='+date_f,
        datatype: 'application/json',
        success: function (data) {
			growth_chart_data = save_processed_data(data);
            sales_volume_chart(sales_by_month(growth_chart_data), 'month');
        }
    });
	
	/**
     * Get product volume
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/product/volume?id='+id+'&from='+date_i+'&to='+date_f,
        datatype: 'application/json',
        success: function (data) {
			volume_chart_data = volume_processed_data(data);
            volume_chart(volume_by_month(volume_chart_data), 'month');
        }
    });
	
	
	$('input[type=radio]').on('change',function(){
	//val can be:  year, month, week, day
		switch($('input[type=radio]:checked').val()){
			case 'year':
				break;
			case 'month':
				volume_chart(volume_by_month(volume_chart_data), 'month');
				sales_volume_chart(sales_by_month(growth_chart_data), 'month');
				break;
			case 'week':
				break;
			case 'day':
				volume_chart(volume_chart_data, 'day');
				sales_volume_chart(growth_chart_data, 'day');
				break;
		}
	});

});

function profit_chart(product) {
    profit = (product.pvp - product.pcm).toFixed(2);
    ctx = document.getElementById('myPieChart4').getContext('2d');
    var myPieChart4 = new Chart(ctx, {
        type: 'doughnut',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: [
                'Cost',
                'Price',
            ],
            datasets: [{
                data: [product.pcm, product.pvp],
                backgroundColor: [
                    'rgba(240,100,100,0.7)',
                    'rgba(240,240,100,0.7)'
                ]
            }]
        },
        options: {
            centertext: profit,
            cutoutPercentage : 80
        }
    });
}

function sales_volume_chart(volume, type) {
    labels=[];
    data=[];
    var colors = [
        'rgba(240,100,100,0.4)',
        'rgba(240,240,100,0.4)',
        'rgba(100,100,240,0.4)',
        'rgba(100,240,100,0.4)',
        'rgba(100,240,240,0.4)'
    ];
	
	
    $.each(volume, function(index,element){
        if (type == 'day') labels.push(element.date);
		if (type == 'month') labels.push(element.label);
        data.push(element.sales);
    });
	
	
    ctx = document.getElementById('myLineChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: "Sales",
                data: data,
                backgroundColor:colors[0]
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Sales Volume'
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

function volume_chart(volume, type) {
    labels=[];
    data=[];
    var colors = [
        'rgba(240,100,100,0.4)',
        'rgba(240,240,100,0.4)',
        'rgba(100,100,240,0.4)',
        'rgba(100,240,100,0.4)',
        'rgba(100,240,240,0.4)'
    ];
	
    $.each(volume, function(index,element){
        if (type == 'day') labels.push(element.date);
		if (type == 'month') labels.push(element.label);
        data.push(element.gross);
    });
	
    ctx = document.getElementById('myLineChart2').getContext('2d');
    var myLineChart2 = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: "Profit",
                data: data,
                backgroundColor:colors[0]
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Profit Over Time'
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

