$(document).ready(function() {
    $('#example').DataTable(
        {"dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>"}
    );
} );

var ctx = document.getElementById('myPieChart').getContext('2d');
var myPieChart = new Chart(ctx,{
    type: 'pie',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Processed',
            'Recieved'
        ],
        datasets: [{
            data: [70, 30],
            backgroundColor: [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)'
            ]
        }]
    }
});

ctx = document.getElementById('myPieChart2').getContext('2d');
var myPieChart2 = new Chart(ctx,{
    type: 'pie',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Cause 1',
            'Cause 2',
            'Cause 3',
            'Cause 4'
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

