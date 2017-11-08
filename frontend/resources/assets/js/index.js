$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/clientes',
        success: function (data) {
            console.log(data);
        }
    });
});
