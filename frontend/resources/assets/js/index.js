$(document).ready(function () {
    /*$.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/clientes',
        success: function (data) {
            console.log(data);
        }
    });*/
	
	$.get('http://localhost:49822/api/clientes',
            function(data) {
                console.log(data);
            });
});
