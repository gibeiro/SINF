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


$(document).ready(function () {
    /**
     * Get top clients
     */
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
    /**
     * Get top products
     */
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
    /**
     * Get cost earns and profit
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/overview/growth?y=2016',
        datatype: 'application/json',
        success: function success(data) {
            growth = data;
            growth_chart(data);
            $.ajax({
                type: 'GET',
                url: 'http://localhost:49822/api/overview/growth?y=2015',
                datatype: 'application/json',
                success: function success(data) {
                    revenue_chart(growth, data);
                }
            });
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

/*ctx = document.getElementById('myPieChart3');
var myPieChart3 = new Chart(ctx,{
    type: 'pie',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Red',
            'Yellow',
            'Blue',
            'Green'
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
});*/

function growth_chart(data) {
    var labels = [];

    var data_cost = [];
    var data_earn = [];
    var data_profit = [];
    var colors = ['rgba(240,100,100,0.4)', 'rgba(240,240,100,0.4)', 'rgba(100,100,240,0.4)', 'rgba(100,240,100,0.4)', 'rgba(100,240,240,0.4)'];
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    $.each(data, function (index, element) {
        labels.push(LABELS[index]);
        data_cost.push(element.Cost.toFixed(0));
        data_earn.push(element.Earn.toFixed(0));
        data_profit.push(element.Profit.toFixed(0));
    });
    ctx = document.getElementById('myLineChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: "Profit",
                data: data_profit,
                backgroundColor: colors[2]
            }, {
                label: "Costs",
                data: data_cost,
                backgroundColor: colors[0]
            }, {
                label: "Earnings",
                data: data_earn,
                backgroundColor: colors[1]
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Growth Over Time'
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
}

function revenue_chart(growth, growth_prev) {
    ctx = document.getElementById('myGaugeChart').getContext('2d');
    rev = 0;
    rev_prev = 0;
    rev_dif = 0;
    $.each(growth, function (index, element) {
        rev += element.Earn;
    });
    $.each(growth_prev, function (index, element) {
        rev_prev += element.Earn;
    });
    rev = Math.round(rev);
    rev_prev = Math.round(rev_prev);
    rev_prev_dif = 0;
    if (rev < rev_prev) {
        rev_dif = rev_prev - rev;
    } else {
        rev_prev_dif = rev - rev_prev;
    }
    percentage = Math.round(rev * 100 / rev_prev);
    console.log(percentage);
    var config = {
        type: 'doughnut',
        data: {
            datasets: [{
                labels: ['Earnings', 'To Go'],
                data: [rev, rev_dif],
                backgroundColor: ['rgba(100,100,255,0.8)', 'rgba(255,100,100,0.8)']
            }, {
                labels: ['Last Year Earnings', 'Growth'],
                data: [rev_prev, rev_prev_dif],
                backgroundColor: ['rgba(150,150,150,0.2)', 'rgba(100,255,100,0.8)']
            }]
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
            tooltips: {
                callbacks: {
                    label: function label(tooltipItem, data) {
                        var dataset = data.datasets[tooltipItem.datasetIndex];
                        var index = tooltipItem.index;
                        return dataset.labels[index] + ': ' + dataset.data[index];
                    }
                }
            },
            rotation: 1 * Math.PI,
            circumference: 1 * Math.PI,
            gaugetext: percentage + "%"
        }
    };
    var myGaugeChart = new Chart(ctx, config);
}

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

            var text = chart.options.gaugetext,
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