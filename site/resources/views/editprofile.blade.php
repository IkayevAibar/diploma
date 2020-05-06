@extends('layouts.app')
    
@section('content')
<div class="container padding">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <form method="get" action=" {{{ route("edited") }}}">
                <div class="card padding">
                    <div class="card-header">Profile Information of <kbd >{{ Auth::user()->name}}</kbd></div>
                    <div class="row padding" style="margin-bottom: 20px;margin-top: 20px;">
                        <div class="col-1"></div>
                        <div class="col-4">
                            <img type="image" style="margin-bottom: 10px;" class="img-fluid rounded-circle col-12" name="img" src="https://pp.userapi.com/c850424/v850424409/b63e1/pxLYzMbdMIw.jpg?ava=1" width="500">
                            <div class="row" >
                                <label class="col-4">Source:</label>
                                <input type="text" class="col-8" name="src" id="src" value="">
                                <button type="button" class="btn btn-warning col-6" id="src-changer" style="margin: 5px; margin-left: 60px;" onclick="changesrc()" name="src-changer">Change</button>
                            </div>
                            <input type="text" class="sr-only" class="form-control" name="image" id="image" >
                            <script language="javascript">
                                document.getElementsByName('image')[0].value = document.getElementsByName('img')[0].src;
                                
                                function changesrc(params) {
                                    console.log(document.getElementsByName('image')[0].value);
                                    console.log(document.getElementsByName('img')[0].src);
                                    document.getElementsByName('img')[0].src = document.getElementsByName('src')[0].value;
                                    document.getElementsByName('image')[0].value = document.getElementsByName('src')[0].value;
                                }
                            </script>
                        </div>
                        <div class="col-1"></div>
                        <div class="col-5">
                            <div class="row">
                                <label class="col-6" for="">Name</label>
                                <input name="name" id="name" class="col-6" type="" placeholder="Your real Name..">
                            </div>
                            <div class="row">
                                <label class="col-6" for="">Surname</label>
                                <input name="surname" id="surname" class="col-6" type="" placeholder="Your Surname..">
                            </div>
                            <div class="row">
                                <label class="col-6" for="">Sex</label>
                                <select name="sex" id="sex" class="col-6" >
                                    <option value="2">Male</option>
                                    <option value="1">Female</option>
                                    <option value="0">Uni</option>
                                </select>
                            </div>
                            <div class="row">
                                <label class="col-6" for="">Country</label>
                                <input name="Country" id="Country" class="col-6" type="" placeholder="Your country..">
                            </div>
                            <div class="row">
                                <label class="col-6" for="">Date of Birth</label>
                                <input name="Birth" id="Birth" class="col-6" type="date" placeholder="Your date of birth..">
                            </div>
                            
                        
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-4"></div>
                                <label class="col-7" for="">Description</label>
                                <div class="col-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-1"></div>
                                <textarea name="Description" id="Description" class="col-10" type="" rows="6" style="resize: none;" maxlength="150" placeholder="About yourself"></textarea>
                                <div class="col-1"></div>
                            </div>
                        </div>
                        <div class="col-1"></div>
                    </div>
                    <button type="submit" class="btn btn-primary">Edit</button>
                </div>
            </div>
        </div>
    </div>
</div>
@endsection
