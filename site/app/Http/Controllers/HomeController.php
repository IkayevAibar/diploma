<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Score;
use App\user_skin;
use App\UserInformation;
use Auth;
use Illuminate\Support\Facades\DB;
class HomeController extends Controller
{
    /**
     * Create a new controller instance.
     *
     * @return void
     */
    public function __construct()
    {
        $this->middleware('auth');
    }

    /**
     * Show the application dashboard.
     *
     * @return \Illuminate\Contracts\Support\Renderable
     */
    public function index()
    {
        $checker = UserInformation
          ::select('id') // <---
          ->where('user_id', Auth::user()->id)
          ->first();
        // dd($checker);
        if($checker==null){
            $user_inf= new UserInformation();
            $user_inf->user_id = Auth::user()->id;
            $user_inf->saveOrFail();
            $user_skin= new user_skin();
            $user_skin->user_id = Auth::user()->id;
            $user_skin->saveOrFail();
        }
        $scores = DB::table('scores')->join('users', 'player_id', '=', 'users.id')->select('scores.*', 'users.name')->get();;
        // dd($myscores);
        return view('home', [
            'scores' => $scores
        ]);
    }
}
