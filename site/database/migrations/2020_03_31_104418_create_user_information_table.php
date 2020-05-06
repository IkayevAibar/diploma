<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateUserInformationTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('user_information', function (Blueprint $table) {
            $table->id();
            $table->integer('user_id');
            $table->string('name')->nullable();
            $table->string('surname')->nullable();
            $table->text('description')->nullable();
            $table->string('skin_id')->default("b1");
            $table->integer('sex')->nullable();
            $table->text('image')->nullable();
            $table->string('country')->nullable();
            $table->date('birth_date')->nullable();
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
        Schema::dropIfExists('user_information');
    }
}
