/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 43);
/******/ })
/************************************************************************/
/******/ ({

/***/ 43:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(44);


/***/ }),

/***/ 44:
/***/ (function(module, exports) {

/**
 * Get top clients
 */
$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/clients/5',
        datatype: 'application/json',
        success: function success(data) {
            var list = $('#top_clients');
            colors = ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(100,240,100,0.7)', 'rgba(100,240,240,0.7)'];

            $.each(data, function (index, element) {
                if (index > 4) return;
                list.append("<li style='background-color: " + colors[index] + ";'>" + element.CodCliente + "</li>");
            });

            top_clients_chart(data);
        }
    });

    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/products/5',
        datatype: 'application/json',
        success: function success(data) {
            var list = $('#top_products');
            colors = ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(100,240,100,0.7)', 'rgba(100,240,240,0.7)'];

            $.each(data, function (index, element) {
                if (index > 4) return;
                list.append("<li style='background-color: " + colors[index] + ";'>" + element.DescArtigo + "</li>");
            });

            top_products_chart(data);
        }
    });
});

function top_clients_chart(clients) {
    var labels = [];
    var data = [];
    colors = ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(100,240,100,0.7)', 'rgba(100,240,240,0.7)'];
    $.each(clients, function (index, element) {
        if (index > 4) return;
        labels.push(element.CodCliente);
        data.push(element.Faturacao.toFixed(0));
    });
    var ctx = document.getElementById('myPieChart').getContext('2d');
    var myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors
            }]
        },
        options: {
            responsive: true,
            legend: {
                display: false,
                position: 'bottom'
            },
            title: {
                display: false
            }
        }
    });
}

function top_products_chart(top_products) {
    var labels = [];
    var data = [];
    colors = ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(100,240,100,0.7)', 'rgba(100,240,240,0.7)'];
    $.each(top_products, function (index, element) {
        if (index > 4) return;
        labels.push(element.DescArtigo);
        data.push(element.Faturacao.toFixed(0));
    });
    ctx = document.getElementById('myPieChart2').getContext('2d');
    var myPieChart2 = new Chart(ctx, {
        type: 'pie',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: colors
            }]
        },
        options: {
            responsive: true,
            legend: {
                display: false,
                position: 'bottom'
            },
            title: {
                display: false
            }
        }
    });
}

ctx = document.getElementById('myPieChart3');
var myPieChart3 = new Chart(ctx, {
    type: 'pie',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: ['Red', 'Yellow', 'Blue', 'Green'],
        datasets: [{
            data: [20, 50, 20, 10],
            backgroundColor: ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(100,240,100,0.7)']
        }]
    }
});

ctx = document.getElementById('myLineChart').getContext('2d');
var myLineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [{
            label: "Income Expenses",
            data: [10, 20, 30, 20, 40, 50, 60]
        }]
    },
    options: {
        responsive: true,
        title: {
            display: true,
            text: 'Income Expenses'
        },
        tooltips: {
            mode: 'index',
            intersect: false
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

ctx = document.getElementById('myGaugeChart').getContext('2d');
var randomScalingFactor = function randomScalingFactor() {
    return Math.round(Math.random() * 100);
};
var config = {
    type: 'doughnut',
    data: {
        datasets: [{
            data: [60, 100 - 60],
            backgroundColor: ['rgba(255,100,100,0.8)']
        }],
        labels: ["revenue"]
    },
    options: {
        responsive: true,
        legend: {
            position: 'top'
        },
        title: {
            display: true,
            text: 'Revenue'
        },
        animation: {
            animateScale: false,
            animateRotate: true
        },
        rotation: 1 * Math.PI,
        circumference: 1 * Math.PI,
        gaugetext: "60%"
    }
};
var myGaugeChart = new Chart(ctx, config);

Chart.pluginService.register({
    beforeDraw: function beforeDraw(chart) {
        if (chart.options.gaugetext) {
            var width = chart.chart.width,
                height = chart.chart.height,
                ctx = chart.chart.ctx;

            ctx.restore();
            var fontSize = (height / 80).toFixed(2); // was: 114
            ctx.font = fontSize + "em sans-serif";
            ctx.textBaseline = "middle";

            var text = chart.options.centertext,
                // "75%",
            textX = Math.round((width - ctx.measureText(text).width) / 2),
                textY = height / 2 - (chart.titleBlock.height - 155);

            ctx.fillText(text, textX, textY);
            ctx.save();
        } else if (chart.options.centertext) {
            var width = chart.chart.width,
                height = chart.chart.height,
                ctx = chart.chart.ctx;

            ctx.restore();
            var fontSize = (height / 80).toFixed(2); // was: 114
            ctx.font = fontSize + "em sans-serif";
            ctx.textBaseline = "middle";

            var text = chart.options.centertext,
                // "75%",
            textX = Math.round((width - ctx.measureText(text).width) / 2),
                textY = height / 2 - (chart.titleBlock.height - 15);

            ctx.fillText(text, textX, textY);
            ctx.save();
        }
    }
});

/***/ })

/******/ });