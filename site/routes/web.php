<?php

use Illuminate\Support\Facades\Route;

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
Route::get('/myscore', 'ScoreController@index')->name('myscore');
Route::get('/skins', 'UserInformationController@skinShow')->name('skin');
Route::get('/profile/{profile}', 'UserInformationController@show')->name('profile');
Route::get('/profile', 'UserInformationController@show')->name('show');
Route::get('/editprofile', 'UserInformationController@editprofile')->name('editprofile');
Route::get('/edited', 'UserInformationController@edited')->name('edited');
Route::get('/Chosen', 'UserInformationController@Chosen')->name('Chosen');


