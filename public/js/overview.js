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


var ctx = document.getElementById('myPieChart');
var myPieChart = new Chart(ctx, {
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

ctx = document.getElementById('myPieChart2');
var myPieChart2 = new Chart(ctx, {
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

ctx = document.getElementById('myLineChart');
var myLineChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["January", "February", "March", "April", "May", "June", "July"],
        datasets: [{
            label: "Income Expenses",
            data: [10, 20, 30, 20, 40, 50, 60],
            fill: false
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
        }
    }
});

/*ctx = document.getElementById('myGaugeChart');
var myGaugeChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels:['Revenue', 'Revenue'],
        datasets: [{
            data: [60,40],
            backgroundColor:[
                'rgba(200,100,150,9)',
                'rgba(200,150,200,9)'
            ]
        }]
    },
    options: {
        rotation: -1.5*Math.PI,
        circunference: 3*Math.PI
    }
});*/

//text in center
$("#circularGaugeContainer").dxCircularGauge({
    rangeContainer: {
        offset: 10,
        ranges: [{ startValue: 800, endValue: 1000, color: '#41A128' }, { startValue: 1000, endValue: 1500, color: '#2DD700' }]
    },
    scale: {
        startValue: 0, endValue: 1500,
        majorTick: { tickInterval: 250 },
        label: {
            format: 'currency'
        }
    },
    title: {
        text: 'Sales MTD',
        subtitle: 'test',
        position: 'top-center'
    },
    tooltip: {
        enabled: true,
        format: 'currency',
        customizeText: function customizeText(arg) {
            return 'Current ' + arg.valueText;
        }
    },
    subvalueIndicator: {
        type: 'textCloud',
        format: 'thousands',
        text: {
            format: 'currency',
            customizeText: function customizeText(arg) {
                return 'Goal ' + arg.valueText;
            }
        }
    },
    value: 900,
    subvalues: [825]
});

/***/ })

/******/ });