@extends('layouts.app')

@section('title','Sales')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <h2>Sales</h2>
                </div>
                <div class="col-md-6 col-xs-12 text-right" style="padding: 50px 10px 20px 0;">
                    <label>Data de Início: <input type="date" name="date_i" value="2017-01-01"></label>
                    <label>Data de Fim: <input type="date" name="date_f" value="2017-12-31"></label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 30px 10px">
                        <h1 id="to_be_packed" style="margin: 62px 10px">24</h1>
                        <p style="margin-top: 10px"><span>&boxplus;</span> Delayed Shipments</p>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 0px 53px">
                        <canvas id="myPieChart" width="400" height="400"></canvas>
                        <p style="margin-top: 10px"><span style="color: indianred">&euro;</span> Invoices vs Shipments</p>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 30px 10px">
                        <h1 id="to_be_delivered" style="margin: 62px 10px">24</h1>
                        <p style="margin-top: 10px"><span style="color: lightgreen">&euro;</span> To Be Delivered</p>
                    </div>
                </div>
                <div class="col-md-12 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 20px;">
                        <canvas id="myLineChart" width="400" height="200"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="text-center">
                <h1>Sales</h1>
            </div>
            <table id="example" class="table table-striped table-bordered text-left" cellspacing="0" width="100%">
                <thead>
                <tr>
                    <th>Client</th>
                    <th>Type</th>
                    <th>Amount( € )</th>
                    <th>Iva ( € )</th>
                    <th>Date</th>
                    <th>Delivered</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <th>Client 1</th>
                    <th>Encomenda</th>
                    <th>1000</th>
                    <th>210</th>
                    <th>2017/03/25</th>
                    <th>Yes</th>
                </tr>
                <tr>
                    <th>Client 2</th>
                    <th>Encomenda</th>
                    <th>1000</th>
                    <th>210</th>
                    <th>2017/03/25</th>
                    <th>Yes</th>
                </tr>
                <tr>
                    <th>Client 3</th>
                    <th>Encomenda atrasada</th>
                    <th>1000</th>
                    <th>210</th>
                    <th>2017/03/25</th>
                    <th>Yes</th>
                </tr>
                <tr>
                    <th>Client 4</th>
                    <th>Fatura</th>
                    <th>1000</th>
                    <th>210</th>
                    <th>2017/03/25</th>
                    <th>Yes</th>
                </tr>
                <tr>
                    <th>Client 5</th>
                    <th>Encomenda</th>
                    <th>1000</th>
                    <th>210</th>
                    <th>2017/03/25</th>
                    <th>Yes</th>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/sales.js') }}"></script>
@endsection