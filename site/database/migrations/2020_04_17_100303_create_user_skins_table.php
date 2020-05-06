<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateUserSkinsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('user_skins', function (Blueprint $table) {
            $table->id();
            $table->integer('user_id');
            $table->integer('b1')->default("1");
            $table->integer('b2')->default("0");
            $table->integer('b3')->default("0");
            $table->integer('b4')->default("0");
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('user_skins');
    }
}
