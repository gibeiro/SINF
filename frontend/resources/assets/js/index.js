$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/product/volume?id=A0001',
		datatype: 'application/json',
        success: function (data) {
            var table = $('#top_clients');

            $.each(data, function(index, element){
               console.log(data);
            });
        }
    });
});
