var graph_data;
var expenditure_graph_data;

var conjoined_data = [];

Date.prototype.ymd = function() {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return '' + this.getFullYear() +"-"+ (mm>9 ? '' : '0') + mm +"-"+ (dd>9 ? '' : '0') + dd;
};

function purchases_data(data){
    var volume_data = [];
    var currentDay = 0;
	var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
		while(currentDay!=data[i].day){
			var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            volume_data.push({day:currentDay, purchases:0, date: date.ymd()});
            currentDay++;
        }
        volume_data.push(data[i]);
        currentDay++;
    }
    return volume_data;
}

function expenditure_data(data){
    var volume_data = [];
    var currentDay = 0;
	var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
		while(currentDay!=data[i].day){
			var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            volume_data.push({day:currentDay, cost:0, date: date.ymd()});
            currentDay++;
        }
        volume_data.push(data[i]);
        currentDay++;
    }
    return volume_data;
}

function purchases_by_month(data){
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    var months=[];
    var currentElement=-1;
    $.each(data,function(index,element){
        var parts = element.date.split('-');
        if(newElement(months,parts[1]-1, parts[0])) {
            months.push({month: parts[1]-1, year: parts[0], purchases: element.purchases, label: LABELS[parts[1]-1]});
            currentElement++;
        }else{
            months[currentElement].purchases += element.purchases;
        }
    });
    return months;
}

function expenditures_by_month(data){
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    var months=[];
    var currentElement=-1;
    $.each(data,function(index,element){
        var parts = element.date.split('-');
        if(newElement(months,parts[1]-1, parts[0])) {
            months.push({month: parts[1]-1, year: parts[0], cost: element.cost, label: LABELS[parts[1]-1]});
            currentElement++;
        }else{
            months[currentElement].cost += element.cost;
        }
    });
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
	
    $('#example').DataTable(
        {"dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>"}
    );
    /**
     * Get volume
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/purchases/volume?from='+date_i+'&to='+date_f,
        datatype: 'application/json',
        success: function (data) {
            graph_data = purchases_data(data);			
			var temp = purchases_by_month(data);			
			for (var i = 0; i < temp.length; i++) conjoined_data.push([temp[i], 0]);
		}
    });
	
	/**
     * Get expenditure
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/purchases/expenditure?from='+date_i+'&to='+date_f,
        datatype: 'application/json',
        success: function (data) {
			expenditure_graph_data = expenditure_data(data);
			var temp = expenditures_by_month(data);
			for (var i = 0; i < conjoined_data.length; i++) conjoined_data[i] = ([conjoined_data[i][0], temp[i]]);
			growth_chart(conjoined_data, 'month');
        }
    });
	
	/**
     * Get product purchases
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/purchases/latest',
        datatype: 'application/json',
        success: function (data) {
			fillTable(data);
        }
    });
});

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
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    $.each(data, function(index,element){
        if (type == 'day') labels.push(element[0].date);
		if (type == 'month') labels.push(element[0]	.label);
        if (element[0].purchases != undefined) data_cost.push(element[0].purchases.toFixed(0));
		if (element[1].cost != undefined) data_earn.push(element[1].cost.toFixed(0) / 1000);
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
                    label: "Expenditure (in 1000s of €)",
                    data: data_earn,
                    backgroundColor: colors[1]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Purchases / Expenditure'
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


function fillTable (data){
	
    $.each(data, function(index,element){
        $('#example2 tbody').append('<tr>\n' +
            '<td>' + element.productcode + '</td>\n' +
            '<td>' + element.productname + '</td>\n' +
            '<td>' + element.quantity + '</td>\n' +
            '<td>' + element.totalcost + '</td>\n' +
            '</tr>');
    });
    $('#example2').DataTable(
        {"dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>"}
    );
	
}


