<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Auth::routes();

Route::get('/home', 'HomeController@index')->name('home');
Route::get('/overview', function(){
    return view('overview');
});
Route::get('/inventory', function(){
    return view('inventory');
});
Route::get('/accounts', function(){
    return view('accountsPayable');
});
Route::get('/product', function(){
    return view('product');
});
Route::get('/client/{id}', function($id){
    return view('client',compact('id'));
});
Route::get('/purchases', function(){
    return view('purchases');
});
Route::get('/sales', function(){
    return view('sales');
});
Route::get('/teste', function(){
    return view('testePrimavera');
});
