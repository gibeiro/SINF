@extends('layouts.app')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <h2 id="product_name"></h2>
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
                        <canvas id="myPieChart4" width="400" height="400"></canvas>
                        <p>Profit Margin</p>
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
                <canvas id="myLineChart2" width="400" height="400"></canvas>
            </div>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/product.js') }}"></script>
@endsection