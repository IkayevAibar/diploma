<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Score;
use Auth;

class ScoreController extends Controller
{
    public function index()
    {
        if (Auth::user()){
            $myscores = Score::paginate(15)->where('player_id',Auth::user()->id);
            return view('myscore', [
                'myscores' => $myscores
            ]);
        }
        return view('auth/login');
    }
}
