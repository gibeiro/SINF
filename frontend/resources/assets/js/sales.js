var revenue_chart_data;
var volume_chart_data;

//just something to be here to get on your nerves
Date.prototype.ymd = function() {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return '' + this.getFullYear() +"-"+ (mm>9 ? '' : '0') + mm +"-"+ (dd>9 ? '' : '0') + dd;
};


function save_processed_revenue_data(data){
    var growth_data = [];
    var currentDay = 0;
    var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
        while(currentDay!=data[i].day){
            var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            console.log(date);
            growth_data.push({day:currentDay, gross:0, date: date.ymd()});
            currentDay++;
        }
        growth_data.push(data[i]);
        currentDay++;
    }
    return growth_data;
}

function revenue_by_month(data){
    console.log("GROWTH_BY_MONTH");
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August","September","October","November","December"];
    var months=[];
    var currentElement=-1;
    $.each(data,function(index,element){
        var parts = element.date.split('-');
        if(newElement(months,parts[1]-1, parts[0])) {
            months.push({month: parts[1]-1, year: parts[0], netsale: element.gross, label: LABELS[parts[1]-1]});
            currentElement++;
        }else{
            months[currentElement].gross += element.gross;
        }
    });
    console.log(months);
    return months;
}

function save_processed_volume_data(data){
    var growth_data = [];
    var currentDay = 0;
    var date_parts = $('#date_i').val().split('-');
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
        while(currentDay!=data[i].day){
            var date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
            date.setDate(first_date.getDate()+currentDay);
            console.log(date);
            growth_data.push({day:currentDay, sales:0, date: date.ymd()});
            currentDay++;
        }
        growth_data.push(data[i]);
        currentDay++;
    }
    return growth_data;
}

function volume_by_month(data){
    console.log("GROWTH_BY_MONTH");
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

function newElement(array, month, year){
    for(var i=0;i<array.length;i++){
        if(array[i].month == month && array[i].year == year){
            return false;
        }
    }
    return true;
}

$(document).ready(function () {
    /**
     * Get cost earns and profit
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/sales/latest?limit=10',
        datatype: 'application/json',
        success: function (data) {
            last_sales_table(data);
        }
    });

    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/sales/volume?from=' + $('#date_i').val() + '&to=' + $('#date_f').val(),
        datatype: 'application/json',
        success: function (data) {
            volume_chart_data = save_processed_volume_data(data);
            volume_chart(volume_by_month(volume_chart_data));
        }
    });

    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/sales/revenue?from=' + $('#date_i').val() + '&to=' + $('#date_f').val(),
        datatype: 'application/json',
        success: function (data) {
            revenue_chart_data = save_processed_revenue_data(data);
            revenue_chart(revenue_by_month(revenue_chart_data));
        }
    });

    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/sales/categories',
        datatype: 'application/json',
        success: function (data) {
            categories_chart(data)
        }
    });

    $('input[type=radio]').on('change',function(){
        //val can be:  year, month, week, day
        switch($('input[type=radio]:checked').val()){
            case 'year':
                break;
            case 'month':
                revenue_chart(revenue_by_month(revenue_chart_data), 'month');
                volume_chart(volume_by_month(volume_chart_data), 'month');
                break;
            case 'week':
                break;
            case 'day':
                revenue_chart(revenue_chart_data, 'day');
                volume_chart(volume_chart_data, 'day');
                break;
        }
    });
});

function volume_chart(data, type) {

    var labels = [];
    var data_earn = [];
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
        data_earn.push(element.sales.toFixed(0));
    });
    ctx = document.getElementById('volumeChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "Sales",
                    data: data_earn,
                    backgroundColor: colors[1]
                }
            ]
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

function revenue_chart(data, type) {

    var labels = [];

    var data_earn = [];
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
        data_earn.push(element.gross.toFixed(0));
    });
    ctx = document.getElementById('revenueChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "Revenue",
                    data: data_earn,
                    backgroundColor: colors[1]
                }
            ]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Sales Revenue'
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

function categories_chart(data) {
    ctx = document.getElementById('myPieChart').getContext('2d');
    var labels = [];
    var data = [];
    $.each(data,function(index,element){
        labels.push(element.category);
        data.push(element.gross);
    });
    var myPieChart4 = new Chart(ctx, {
        type: 'pie',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: [
                    'rgba(240,100,100,0.7)',
                    'rgba(240,240,100,0.7)'
                ]
            }]
        }
    });
}

function last_sales_table(data){
    $.each(data, function(index,element){
        $('#example tbody').append('<tr>\n' +
            '<th>' + element.customer + '</th>\n' +
            '<th>' + element.type + '</th>\n' +
            '<th>' + element.gross + '</th>\n' +
            '<th>' + element.date + '</th>\n' +
            '<th>' + element.status + '</th>\n' +
            '</tr>');
    });
    $('#example').DataTable(
        {"dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>"}
    );
}