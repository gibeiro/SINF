@extends('layouts.app')

@section('title','Product')

@section('content')
    <meta id="id" content="{{$id}}">
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <h2>Categoria: <span style="font-weight: 100"> Hardware</span></h2>
                    <h2 id="product_name"></h2>
                </div>
                <div class="col-md-6 col-xs-12 text-right" style="padding: 50px 10px 20px 0;">
                    <label>Data de Início: <input type="date" id="date_i" value="2016-01-01"></label>
                    <label>Data de Fim: <input type="date" id="date_f" value="2016-12-31"></label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 30px 10px">
                        <h1 id="in_stock" style="margin: 62px 10px"></h1>
                        <p style="margin-top: 10px"><span>&boxplus;</span> In Stock</p>
                    </div>
                </div>
                <div class="col-md-3 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 30px 10px">
                        <h1 id="unit_cost" style="margin: 62px 10px"></h1>
                        <p style="margin-top: 10px"><span style="color: indianred">&euro;</span> Unit Cost</p>
                    </div>
                </div>
                <div class="col-md-3 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 30px 10px">
                        <h1 id="unit_price" style="margin: 62px 10px"></h1>
                        <p style="margin-top: 10px"><span style="color: lightgreen">&euro;</span> Unit Price</p>
                    </div>
                </div>
                <div class="col-md-3 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart4" width="50" height="50"></canvas>
                        <p>Profit Margin</p>
                    </div>
                </div>
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
                <canvas id="myLineChart2" width="400" height="400"></canvas>
            </div>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/product.js') }}"></script>
@endsection