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
/******/ 	return __webpack_require__(__webpack_require__.s = 38);
/******/ })
/************************************************************************/
/******/ ({

/***/ 38:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(39);


/***/ }),

/***/ 39:
/***/ (function(module, exports) {

$(document).ready(function () {

	var date_i = $('#date_i').val();
	var date_f = $('#date_f').val();

	/**
     * Get product sales
     */
	$.ajax({
		type: 'GET',
		url: 'http://localhost:49822/api/inventory/products',
		datatype: 'application/json',
		success: function success(data) {
			inHandToBeReceived(data);
			fillTable(data);
		}
	});

	/**
     * Get product groups
     */
	$.ajax({
		type: 'GET',
		url: 'http://localhost:49822/api/inventory/groups',
		datatype: 'application/json',
		success: function success(data) {
			productGroups(data);
		}
	});

	/**
     * Get low stocks
     */
	$.ajax({
		type: 'GET',
		url: 'http://localhost:49822/api/inventory/lowstock',
		datatype: 'application/json',
		success: function success(data) {
			lowStock(data);
		}
	});
});

function inHandToBeReceived(data) {

	var inHand = 0;
	var toBeReceived = 0;

	for (var i = 0; i < data.length; i++) {
		inHand += data[i].stock;
		toBeReceived += data[i].to_receive;
	}

	var percent = 100*(toBeReceived / inHand).toFixed(2);

	var ctx = document.getElementById('myDonutChart').getContext('2d');
	var myPieChart = new Chart(ctx, {
		type: 'doughnut',
		data: {
			// These labels appear in the legend and in the tooltips when hovering different arcs
			labels: ['Items in hand', 'To be recived'],
			datasets: [{
				data: [inHand, toBeReceived],
				backgroundColor: ['rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(100,240,100,0.7)']
			}]
		},
		options: {
			centertext: percent + '%'
		}
	});
}

function lowStock(data) {
	for (var i = 0; i < data.length; i++) {
		$('#top_products').append("<li>" + data[i].code + " | " + data[i].total + "</li>");
	}
}

var productGroups = function productGroups(groupdata) {

	var labels = [];
	var groups = [];

	for (var i = 0; i < groupdata.length; i++) {
		labels.push(groupdata[i].group);
		groups.push(groupdata[i].total);
	}
	ctx = document.getElementById('myPieChart3').getContext('2d');
	var myPieChart3 = new Chart(ctx, {
		type: 'pie',
		data: {
			// These labels appear in the legend and in the tooltips when hovering different arcs
			labels: labels,

			datasets: [{
				data: groups,
				backgroundColor: ['rgba(240,120,100,0.7)', 'rgba(200,240,100,0.7)', 'rgba(100,100,200,0.7)', 'rgba(100,240,100,0.7)', 'rgba(240,100,100,0.7)', 'rgba(220,240,100,0.7)', 'rgba(00,100,240,0.7)', 'rgba(240,100,100,0.7)', 'rgba(240,240,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(40,100,100,0.7)', 'rgba(100,100,240,0.7)', 'rgba(240,100,100,0.7)']
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
};

function fillTable(data) {

	$.each(data, function (index, element) {
		$('#example tbody').append('<tr>\n' + '<td>' + element.code + '</td>\n' + '<td>' + element.name + '</td>\n' + '<td>' + element.category + '</td>\n' + '<td>' + element.stock + '</td>\n' + '<td>' + element.to_receive + '</td>\n' + '<td>' + element.total + '</td>\n' + '</tr>');
	});
	$('#example').DataTable({ "dom": "<'row'<'col-sm-6'l><'col-sm-6'f>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-5'i><'col-sm-7'p>>" });
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