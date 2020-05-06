@extends('layouts.app')

@section('content')
<div class="container padding">
    <div class="row justify-content-center">
        <div class="col-md-8 "> 
            <form method="get" action=" {{{ route("Chosen") }}}">
                <div class="card padding ">
                    <div class="card-header">Skins</div>
                    <div class="row padding d-flex justify-content-center">
                        <ul class="list-unstyled col-8 align-content-between">
                            <li class="media row mx-md-n5 ">
                                <div class="col px-md-5">
                                    <img src="http://localhost/sqlconnect/skins/1.png" style="width: 250px" alt="">
                                </div>
                                <div class="media-body col px-md-5">
                                    <h5>Skin_1</h5>
                                    Cost: Free
                                    <button type="button" name="btn" onclick="bs(this)" id="b1" class="btn btn-warning btn-lg btn-block" disabled>Chosen</button>
                                </div>
                            </li>
                            <li class="media row mx-md-n5 ">
                                <div class="col px-md-5">
                                    <img src="http://localhost/sqlconnect/skins/2.png" style="width: 250px" alt="">
                                </div>
                                <div class="media-body col px-md-5">
                                    <h5>Skin_2</h5>
                                    @if($skins["b2"]==0)
                                        Cost: 20 gold
                                    @else
                                        You have this skin!
                                    @endif
                                    <label class="sr-only" for="btn">Hidden input label</label>
                                    <button type="button" name="btn" onclick="bs(this)" id="b2" class="btn btn-danger btn-lg btn-block">Choose</button>
                                </div>
                            </li>
                            <li class="media row mx-md-n5 ">
                                <div class="col px-md-5">
                                    <img src="http://localhost/sqlconnect/skins/3.png" style="width: 250px" alt="">
                                </div>
                                <div class="media-body col px-md-5">
                                    <h5>Skin_3</h5>
                                    @if($skins["b3"]==0)
                                        Cost: 50 gold
                                    @else
                                        You have this skin!
                                    @endif
                                    <label class="sr-only" for="btn">Hidden input label</label>
                                    <button type="button" name="btn" onclick="bs(this)" id="b3" class="btn btn-danger btn-lg btn-block">Choose</button>

                                </div>
                            </li>
                            <li class="media row mx-md-n5 ">
                                <div class="col px-md-5">
                                    <img src="http://localhost/sqlconnect/skins/4.png" style="width: 250px" alt="">
                                </div>
                                <div class="media-body col px-md-5">
                                    <h5>Skin_4</h5>
                                    @if($skins["b4"]==0)
                                        Cost: 100 gold
                                    @else
                                        You have this skin!
                                    @endif
                                    <label class="sr-only" for="btn">Hidden input label</label>
                                    <button type="button" onclick="bs(this);" name="btn" id="b4" class="btn btn-danger btn-lg btn-block">Choose</button>
                                    
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <input type="text" class="sr-only" class="form-control" name="skin" id="skin" value= "{{$chosen ?? ''}}" >
                <button type="submit" name="" id="" class="btn btn-primary btn-lg btn-block">Submit</button>

            </form> 
        </div>
    </div>
</div>
<script>
    var btns = document.getElementsByName("btn");
    var input =  document.getElementById("skin");
    console.log( document.getElementById("skin").value);
    btns.forEach(element => {
        if( document.getElementById("skin").value==element.id){
            element.innerHTML="Chosen";
            element.className="btn btn-warning btn-lg btn-block";
            element.disabled=true;
        }
        else{
            element.innerHTML="Choose";
            element.className="btn btn-danger btn-lg btn-block";
            element.disabled=false;
        }
    });
    function bs(param) {
        if(param.innerHTML=="Choose"){
            if(param.id=="b1"){
               changer(param);
               document.querySelector("#app > main > div > div > div > form > button").innerHTML="Submit";
            }
            else if(param.id=="b2" && ({{Auth::user()->gold}}-20>=0)){
                changer(param);
                if({{$skins["b2"]}}==0){
                    document.querySelector("#app > main > div > div > div > form > button").innerHTML="Buy and Submit";
                }
                else{
                   document.querySelector("#app > main > div > div > div > form > button").innerHTML="Submit";
                }
            }
            else if(param.id=="b3" && ({{Auth::user()->gold}}-50>=0) ){
               changer(param);
               if({{$skins["b3"]}}==0){
                document.querySelector("#app > main > div > div > div > form > button").innerHTML="Buy and Submit";
                }else{
                   document.querySelector("#app > main > div > div > div > form > button").innerHTML="Submit";
                }
            }
            else if(param.id=="b4" && ({{Auth::user()->gold}}-100>=0) ){
                changer(param);
                if({{$skins["b4"]}}==0){
                document.querySelector("#app > main > div > div > div > form > button").innerHTML="Buy and Submit";
                }
                else{
                   document.querySelector("#app > main > div > div > div > form > button").innerHTML="Submit";
                }
            }
            else{
                param.parentElement.children[1].className = "col-sm-1-12 col-form-label text-danger";
                param.parentElement.children[1].innerText = "You dont have enought gold!";
            }
            
        }
        console.log(document.getElementById("skin").value);
    }
    function changer(param){
        btns.forEach(element => {
            element.innerHTML="Choose";
            element.className="btn btn-danger btn-lg btn-block";
            element.disabled=false;
            });
        param.innerHTML="Chosen";
        param.className="btn btn-warning btn-lg btn-block";
        param.disabled=true;
        document.getElementById("skin").value=param.id;
    }
</script>

@endsection
