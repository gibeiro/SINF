@extends('layouts.app')

@section('title','Client')

@section('content')
    <meta id="id" content="{{$id}}">
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <h2 id="client_name"></h2>
            <div class="row" style="margin-top: 30px;">
                <div class="col-md-6 col-xs-12" style="padding:0; padding-right: 10px; margin-bottom: 10px;">
                    <div style="padding:0; margin: 0;">
                        <div class="col-md-12 col-xs-12">
                            <h4 style="font-weight: bold">NIF &blacktriangleright;</h4>
                            <p id="nif"></p>
                            <h4 style="font-weight: bold">Address &blacktriangleright;</h4>
                            <p id="address"></p>
                            <h4 style="font-weight: bold">Client Code &blacktriangleright;</h4>
                            <p id="client_code"></p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3>Top Products</h3>
                        </div>

                        <div class="panel-body">
                            <ol id="top_products" style="margin:0; padding:0 40px; ">
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-xs-12 text-center" style="margin-bottom: 50px;">
                <canvas id="myLineChart" width="400" height="200"></canvas>
            </div>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/client.js') }}"></script>
@endsection