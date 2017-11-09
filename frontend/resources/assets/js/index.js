$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/client/info?id=ALCAD',
		datatype: 'application/json',
        success: function (data) {
            console.log(data);
        }
    });
});
