@extends('layouts.app')

@section('title','Inventory')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <h2>Inventory</h2>
                </div>
                <div class="col-md-6 col-xs-12 text-right" style="padding: 50px 10px 20px 0;">
                    <label>Data de Início: <input type="date" id="date_i" value="2016-01-01"></label>
                    <label>Data de Fim: <input type="date" id="date_f" value="2016-12-31"></label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myDonutChart" width="400" height="400"></canvas>
                        <p>Items</p>
                    </div>
                </div>
                <div class="col-md-4 col-xs-6 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3>Low Stock Products</h3>
                        </div>

                        <div class="panel-body">
                            <ol id="top_products" style="margin:0; padding:0 40px; ">
                            </ol>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myPieChart3" width="400" height="400"></canvas>
                        <p>Product Categories</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" style="margin-bottom: 50px">
        <div class="row">
            <div class="text-center">
                <h1>Products</h1>
            </div>
            <table id="example" class="table table-striped table-bordered text-left" cellspacing="0" width="100%">
                <thead>
                <tr>
                    <th>Code</th>
                    <th>Name</th>
                    <th>Category</th>
                    <th>Stock</th>
                    <th>To Be Received</th>
                    <th>Total</th>
                </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/inventory.js') }}"></script>
@endsection