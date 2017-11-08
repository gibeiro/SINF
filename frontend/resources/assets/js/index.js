$(document).ready(function () {
    $.ajax({
        type: 'GET',
		headers: { 'Access-Control-Allow-Origin': '*' },
        url: 'http://localhost:49822/api/clientes',
		datatype: 'application/json',
        success: function (data) {
            console.log(data);
        }
    });
	
	/*$.get('http://localhost:49822/api/clientes',
            function(data) {
                console.log(data);
            });*/
});
