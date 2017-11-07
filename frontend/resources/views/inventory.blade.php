@extends('layouts.app')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <h2>Inventory</h2>
            <div class="row">
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myDonutChart" width="400" height="400"></canvas>
                        <p>Items</p>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="turnOverChart" width="400" height="400" style="padding-right: 10px"></canvas>
                        <p>Turnover</p>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart3" width="400" height="400"></canvas>
                        <p>Relative number of products</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row text-center">
            <h1>KPI TABLE</h1>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/inventory.js') }}"></script>
@endsection