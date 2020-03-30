<?php
header("Content-Type: text/plain");
use \Firebase\JWT\JWT;
require_once "config.php";
require_once "vendor/autoload.php";
echo JWT::encode(["sub"=>$_SERVER['sn'], "exp"=>date("U")+3600], AUTHENTICATION_KEY);