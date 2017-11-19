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
                    <label>Data de Início: <input type="date" name="date_i" value="2017-01-01"></label>
                    <label>Data de Fim: <input type="date" name="date_f" value="2017-12-31"></label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5;">
                        <canvas id="myDonutChart" width="400" height="400"></canvas>
                        <p>Items</p>
                    </div>
                </div>
                <div class="col-md-4 col-xs-12 text-center" style="padding-right: 10px; padding-bottom: 10px">
                    <div style="background-color: #f5f5f5; padding: 10px 18px;">
                        <canvas id="turnOverChart" width="400" height="400" style="padding-right: 10px"></canvas>
                        <p style="margin-top:16px; margin-bottom: 0">Turnover</p>
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
                    <tr>
                        <td>A0001</td>
                        <td>Product 1</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0002</td>
                        <td>Product 2</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0003</td>
                        <td>Product 3</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0004</td>
                        <td>Product 4</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0005</td>
                        <td>Product 5</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0006</td>
                        <td>Product 6</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0007</td>
                        <td>Product 7</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0008</td>
                        <td>Product 8</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0009</td>
                        <td>Product 9</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0010</td>
                        <td>Product 10</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                    <tr>
                        <td>A0011</td>
                        <td>Product 11</td>
                        <td>Category</td>
                        <td>61</td>
                        <td>12</td>
                        <td>73</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
@endsection

@section('custom_js')
    <script src="{{ asset('js/inventory.js') }}"></script>
@endsection