<?php
error_reporting(0);
function adminer_object() {
  
    class AdminerSoftware extends Adminer {
      function database() {
        // database name, will be escaped by Adminer
        return 'database.db';
      }
      
      function login($login, $password) {
        // validate user submitted credentials
        return true;
      }
    }
    
    return new AdminerSoftware;
  }
  
  require "adminer-4.7.0-en.php";