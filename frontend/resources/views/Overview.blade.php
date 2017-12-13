@extends('layouts.app')
@section('title','Dashund Overview')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <h2>Overview</h2>
                </div>
                <div class="col-md-6 col-xs-12 text-right" style="padding: 50px 10px 20px 0;">
                    <label>Data de Início: <input type="date" id="date_i" value="2016-01-01"></label>
                    <label>Data de Fim: <input type="date" id="date_f" value="2016-12-31"></label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 20px 20%;">
                        <canvas id="myPieChart" width="200" height="200"></canvas>
                        <h3>Top Clients</h3>
                        <ol id="top_clients" style="margin:0; padding-left: 10px; padding-right: 10px;">
                        </ol>
                    </div>
                </div>
                <div class="col-md-6 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 20px 20%;">
                        <canvas id="myPieChart2" width="200" height="200"></canvas>
                        <h3>Top Products</h3>
                        <ol id="top_products" style="margin:0; padding-left: 10px; padding-right: 10px;">
                        </ol>
                    </div>
                </div>
                <!--<div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart3" width="400" height="400"></canvas>
                        <p>Relative Expenses</p>
                    </div>
                </div>-->
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-right">
                <span style="margin: 0 0 0 20px;">Sort By: </span>
                <label><input type="radio" name="gap" value="year"> Ano</label>
                <label><input type="radio" name="gap" value="month" checked> Mes</label>
                <label><input type="radio" name="gap" value="week"> Semana</label>
                <label><input type="radio" name="gap" value="day"> Dia</label>
            </div>
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