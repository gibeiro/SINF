@extends('layouts.app')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <h2>Accounts Payable</h2>
            <div class="row">
                <div class="col-md-6 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart" width="400" height="300"></canvas>
                        <p>Invoice Ratio</p>
                    </div>
                </div>
                <div class="col-md-6 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart2" width="400" height="300"></canvas>
                        <p>Invoice Errors</p>
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
    <script src="{{ asset('js/accounts.js') }}"></script>
@endsection