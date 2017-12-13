//just something to be here to get on your nerves
Date.prototype.ymd = function() {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return '' + this.getFullYear() +"-"+ (mm>9 ? '' : '0') + mm +"-"+ (dd>9 ? '' : '0') + dd;
};


function save_processed_data(data){
    var client_data = [];
    var currentDay = 0;
	var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
		while(currentDay!=data[i].day){
			var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            client_data.push({day:currentDay, gross:0, date: date.ymd()});
            currentDay++;
        }
        client_data.push(data[i]);
        currentDay++;
    }
    return client_data;
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
    //get id of client
    var id = $('#id').attr('content');
    /**
     * Get info
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/customer/info?id='+id,
        datatype: 'application/json',
        success: function (data) {
            $('#client_name').append(data.name);
            $('#nif').append(data.taxid);
            $('#address').append(data.address);
            $('#client_code').append(data.id);
        }
    });
    /**
     * Get top products
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/customer/products?id='+id+'&limit=5',
        datatype: 'application/json',
        success: function (data) {
            $.each(data,function(index, element) {
                $('#top_products').append("<li>" + element.product + "</li>")
            });
        }
    });
    /**
     * Get cost earns and profit
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/customer/volume?id='+id,
        datatype: 'application/json',
        success: function (data) {
			growth_chart_data = save_processed_data(data);
            volume_chart(volume_by_month(growth_chart_data), 'month');
        }
    });
	
	
	$('input[type=radio]').on('change',function(){
	//val can be:  year, month, week, day
		switch($('input[type=radio]:checked').val()){
			case 'year':
				break;
			case 'month':
				volume_chart(volume_by_month(growth_chart_data), 'month');
				break;
			case 'week':
				break;
			case 'day':
				volume_chart(growth_chart_data, 'day');
				break;
		}
	});
	
});

function volume_chart(volume, type) {
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
        if (type == 'day') labels.push(element.date);
		if (type == 'month') labels.push(element.label);
        data.push(element.gross);
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

