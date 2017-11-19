@extends('layouts.app')

@section('title','Purchases')

@section('content')
    <div class="jumbotron" style="margin-top: -50px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xs-12">
                    <h2>Purchases</h2>
                </div>
                <div class="col-md-6 col-xs-12 text-right" style="padding: 50px 10px 20px 0;">
                    <label>Data de Início: <input type="date" name="date_i" value="2017-01-01"></label>
                    <label>Data de Fim: <input type="date" name="date_f" value="2017-12-31"></label>
                </div>
            </div>
            <div class="row">
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
                <h1>Last Purchases</h1>
            </div>
            <table id="example" class="table table-striped table-bordered text-left" cellspacing="0" width="100%">
                <thead>
                <tr>
                    <th>Supplier</th>
                    <th>Item</th>
                    <th>Price</th>
                    <th>Date</th>
                    <th>Arrived</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>Supplier 1</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 2</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 3</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 4</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 5</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 6</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 7</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 8</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 9</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 10</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                <tr>
                    <td>Supplier 11</td>
                    <td>Item xxx</td>
                    <td>23,23</td>
                    <td>2017/04/25</td>
                    <td>2017/05/01 15:33:42</td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/purchases.js') }}"></script>
@endsection