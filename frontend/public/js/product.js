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
/******/ 	return __webpack_require__(__webpack_require__.s = 42);
/******/ })
/************************************************************************/
/******/ ({

/***/ 42:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(43);


/***/ }),

/***/ 43:
/***/ (function(module, exports) {

/*  /api/product/list
    /api/product/get?id=codigo
    /api/product/volume?id=?&y=?*/

$(document).ready(function () {
    //get id of product
    var id = $('#id').attr('content');
    /**
     * Get product info
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/product/get?id=' + id,
        datatype: 'application/json',
        success: function success(data) {
            $('#product_name').append(data.DescArtigo);
            $('#category').append(data.Categoria);
            $('#in_stock').append(data.STKAtual);
            $('#unit_cost').append(data.PCM);
            $('#unit_price').append(data.PVP);
            profit_chart(data);
        }
    });

    /**
     * Get product volume
     */
    $.ajax({
        type: 'GET',
        url: 'http://localhost:49822/api/product/volume?id=' + id,
        datatype: 'application/json',
        success: function success(data) {
            sales_volume_chart(data);
            profit_volume_chart(data);
        }
    });
});

/*var ctx = document.getElementById('myPieChart').getContext('2d');
var myPieChart = new Chart(ctx,{
    type: 'doughnut',
    data: {
        // These labels appear in the legend and in the tooltips when hovering different arcs
        labels: [
            'Items in hand',
            'To be recieved'
        ],
        datasets: [{
            data: [70, 30],
            backgroundColor: [
                'rgba(240,100,100,0.7)',
                'rgba(240,240,100,0.7)',
                'rgba(100,100,240,0.7)',
                'rgba(100,240,100,0.7)'
            ]
        }]
    },
    options: {
        centertext: '100'
    }
});

ctx = document.getElementById('myPieChart2').getContext('2d');
var myPieChart2 = new Chart(ctx,{
    type: 'bar',
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
    },
    options: {
        responsive: true,
        title:{
            display:true,
            text:'Income Expenses'
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
                    beginAtZero:true
                }
            }]
        }
    }
});

ctx = document.getElementById('myPieChart3').getContext('2d');
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

function profit_chart(product) {
    profit = (product.PVP - product.PCM).toFixed(2);
    ctx = document.getElementById('myPieChart4').getContext('2d');
    var myPieChart4 = new Chart(ctx, {
        type: 'doughnut',
        data: {
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: ['Cost', 'Price'],
            datasets: [{
                data: [product.PCM, product.PVP],
                backgroundColor: ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)']
            }]
        },
        options: {
            centertext: profit,
            cutoutPercentage: 80
        }
    });
}

function sales_volume_chart(volume) {
    labels = [];
    data = [];
    var colors = ['rgba(240,100,100,0.4)', 'rgba(240,240,100,0.4)', 'rgba(100,100,240,0.4)', 'rgba(100,240,100,0.4)', 'rgba(100,240,240,0.4)'];
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    $.each(volume, function (index, element) {
        labels.push(LABELS[index]);
        data.push(element.Sales);
    });
    ctx = document.getElementById('myLineChart').getContext('2d');
    var myLineChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: "Sales",
                data: data,
                backgroundColor: colors[0]
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Sales Volume'
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

function profit_volume_chart(volume) {
    labels = [];
    data = [];
    var colors = ['rgba(240,100,100,0.4)', 'rgba(240,240,100,0.4)', 'rgba(100,100,240,0.4)', 'rgba(100,240,100,0.4)', 'rgba(100,240,240,0.4)'];
    LABELS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    $.each(volume, function (index, element) {
        labels.push(LABELS[index]);
        data.push(element.Profit.toFixed(2));
    });
    ctx = document.getElementById('myLineChart2').getContext('2d');
    var myLineChart2 = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: "Profit",
                data: data,
                backgroundColor: colors[0]
            }]
        },
        options: {
            responsive: true,
            title: {
                display: true,
                text: 'Profit Over Time'
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
        }
        if (chart.options.centertext) {
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