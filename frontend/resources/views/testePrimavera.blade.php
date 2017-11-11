@extends('layouts.app')

@section('content')
    <table id="top_clients">
        <tr>
            <th>Cliente</th>
            <th>Faturação</th>
        </tr>

    </table>
@endsection

@section('custom_js')
    <script src="{{ asset('js/index.js') }}"></script>
@endsection