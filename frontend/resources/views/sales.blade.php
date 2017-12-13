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
                    <label>Data de Início: <input type="date" id="date_i" value="2016-01-01"></label>
                    <label>Data de Fim: <input type="date" id="date_f" value="2016-12-31"></label>
                </div>
            </div>
            <div class="row">
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
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
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
                    <th>Date</th>
                    <th>Delivered</th>
                </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/sales.js') }}"></script>
@endsection