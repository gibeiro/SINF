@extends('layouts.app')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <h2>Overview</h2>
            <div class="row">
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart" width="400" height="400"></canvas>
                        <h3>Top Clients</h3>
                        <ol id="top_clients" style="margin:0; padding-left: 50px; padding-right: 50px;">
                        </ol>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart2" width="400" height="400"></canvas>
                        <h3>Top Products</h3>
                        <ol id="top_products" style="margin:0; padding-left: 50px; padding-right: 50px;">
                        </ol>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart3" width="400" height="400"></canvas>
                        <p>Relative Expenses</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-xs-12 text-center" style="margin-bottom: 50px;">
                <canvas id="myLineChart" width="400" height="400"></canvas>
            </div>
            <div class="col-md-6 col-xs-12 text-center" style="margin-bottom: 50px;">
                <canvas id="myGaugeChart" width="400" height="400"></canvas>
            </div>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/overview.js') }}"></script>
@endsection