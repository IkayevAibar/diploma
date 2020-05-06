@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-8"> 
            <div class="card">
                <div class="card-header">My Last Games</div>
                
                <table class="table">
                    <thead class="thead-dark">
                      <tr>
                        <th scope="col">#</th>
                        <th scope="col">Score</th>
                        <th scope="col">Time</th>
                        <th scope="col">Difficult</th>
                        <th scope="col">Played Date</th>
                      </tr>
                    </thead>
                    <tbody>
                    @if ($myscores->count() > 0)
                        @foreach ($myscores as $myscore)
                        <tr>
                            <th scope="row"></th>
                            <td>{{$myscore->score}} points</td>
                            <td>{{$myscore->time}}</td>
                            <td>{{$myscore->difficult}}</td>
                            <td>{{$myscore->created_at}}</td>
                          </tr>
                    @endforeach 
                    </tbody>
                  </table>
                @endif
                
            </div>
        </div>
    </div>
</div>
<script>
  var table = document.getElementsByTagName('table')[0],
  rows = table.getElementsByTagName('tr'),
  text = 'textContent' in document ? 'textContent' : 'innerText';

  for (var i = 1, len = rows.length; i < len; i++){
      rows[i].children[0][text] = i + ' ' + rows[i].children[0][text];
  }
</script>
@endsection
