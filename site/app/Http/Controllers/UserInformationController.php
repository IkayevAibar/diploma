<?php

namespace App\Http\Controllers;
use App\UserInformation;
use App\User;
use App\user_skin;
use Auth;
use Illuminate\Support\Facades\DB;
use Illuminate\Http\Request;

class UserInformationController extends Controller
{
    public function index(Request $request, UserInformation $score )
    {

        if(Auth::user()){
            $user_inf = DB::table('user_information')->where('id',Auth::user()->id)->get();
            return view('profile',[
                "user_inf"=>$user_inf[0],
            ]);
        }
        return view('auth/login');
    }
    public function show($id){
        $user = User::findOrFail($id);
        $user_inf = UserInformation::findOrFail($id);
        return view('profile',
        [
            'user_inf'=>$user_inf,
            'nickname'=>$user->name

        ]);
    }
    public function editprofile()
    {
        return view("editprofile");
    }
    public function skinShow()
    {
        if(Auth::user()){
            $skins = DB::table('user_skins')->where('user_id', Auth::user()->id)->select("*")->get();
            $chosen = DB::table('user_information')->where('user_id', Auth::user()->id)->select("skin_id")->get();
            return view("skins",
        [
            'chosen'=>$chosen[0]->skin_id,
            'skins'=>["b1"=>$skins[0]->b1,"b2"=>$skins[0]->b2,"b3"=>$skins[0]->b3,"b4"=>$skins[0]->b4]
        ]);
        }
        return view("auth/login");
    }
    public function Chosen(Request $request)
    {
        // dd($request->skin);
        $affected=-1;
        $error=true;
        $gold = Auth::user()->gold;
        $skins = DB::table('user_skins')->where('user_id', Auth::user()->id)->select("*")->get();

        if($request->skin=="b1" && $skins[0]->b1==1){
            $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
            ->update(['skin_id' => $request->skin ]);
        }
        else if($request->skin=="b2" && $skins[0]->b2==1){
            $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
            ->update(['skin_id' => $request->skin ]);
        }
        else if($request->skin=="b3" && $skins[0]->b3==1){
            $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
            ->update(['skin_id' => $request->skin ]);
        }
        else if($request->skin=="b4" && $skins[0]->b4==1){
            $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
            ->update(['skin_id' => $request->skin ]);
        }
        else{
            if($request->skin=="b2" && $skins[0]->b2==0 && $gold>20){
                $affected = DB::table('users')
                    ->where('id', 1)
                    ->decrement('gold', 20);
                $skin_update = DB::table('user_skins')->where('user_id', Auth::user()->id)
                    ->update(['b2' => 1 ]);
                $gold_update = DB::table('users')->where('id', Auth::user()->id)
                    ->update(['gold' => $gold-20 ]);
                $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
                    ->update(['skin_id' => $request->skin ]);
            }
            else if($request->skin=="b3" && $skins[0]->b3==0 && $gold>50){
                $affected = DB::table('users')
                    ->where('id', 1)
                    ->decrement('gold', 50);
                $skin_update = DB::table('user_skins')->where('user_id', Auth::user()->id)
                    ->update(['b3' => 1 ]);
                $gold_update = DB::table('users')->where('id', Auth::user()->id)
                    ->update(['gold' => $gold-50 ]);
                $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
                    ->update(['skin_id' => $request->skin ]);
            }
            else if($request->skin=="b4" && $skins[0]->b4==0 && $gold>100){
                $affected = DB::table('users')
                    ->where('id', 1)
                    ->decrement('gold', 100);
                $skin_update = DB::table('user_skins')->where('user_id', Auth::user()->id)
                    ->update(['b4' => 1 ]);
                $gold_update = DB::table('users')->where('id', Auth::user()->id)
                    ->update(['gold' => $gold-100 ]);
                $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
                    ->update(['skin_id' => $request->skin ]);
            }
            else{
                $error=true;
                $user_inf_update = DB::table('user_information')->where('user_id', Auth::user()->id)
                ->update(['skin_id' => 'b1' ]);
            }
        }   
        $skin_ = DB::table('user_information')->where('user_id', Auth::user()->id)->select("skin_id")->get();
        if($error == false){
            return view("skins",[
                'chosen'=>$skin_[0]->skin_id,
                'skins'=>["b1"=>$skins[0]->b1,"b2"=>$skins[0]->b2,"b3"=>$skins[0]->b3,"b4"=>$skins[0]->b4]

            ]);
        }
        else{
            return view("skins",[
                'chosen'=>$skin_[0]->skin_id,
                'error_message'=>"not enough gold",
                'skins'=>["b1"=>$skins[0]->b1,"b2"=>$skins[0]->b2,"b3"=>$skins[0]->b3,"b4"=>$skins[0]->b4]
            ]);
        }
    }
    
    public function edited(Request $request)
    {
        $user_inf = DB::table('user_information')->where('user_id', Auth::user()->id)->update([
            'name' => $request["name"],
            'surname' => $request["surname"],
            'image' => $request["image"],
            'sex' => $request["sex"],
            'country' => $request["Country"],
            'birth_date' => $request["Birth"],
            'description' => $request["Description"]
        ]);
        $user_inf = DB::table('user_information')->where('user_id',Auth::user()->id)->get();;
        return view('profile',
        [
            'user_inf'=>$user_inf[0],
        ]);
    }
}
