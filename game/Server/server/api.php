<?php
header("Content-Type: text/plain");
use \Firebase\JWT\JWT;
require_once "config.php";
require_once "vendor/autoload.php";
if(isset($argv))
{
  register_shutdown_function(function(){
    echo PHP_EOL;
  });
}
if(isset($argv[1]))
{
  $method=$argv[1];
}
elseif(isset($_REQUEST["method"]))
{
  $method=$_REQUEST["method"];
}
else
{
  die("Method not found.");
}
if(isset($argv))
{
  foreach($argv as $arg)
  {
    if(!preg_match("/(.+)\=(.+)/", $arg,$matches))
    {
      continue;
    }
    $_REQUEST[$matches[1]]=$matches[2];
  }
}
if(method_exists("api",$method))
{
  $f=new ReflectionMethod("api",$method);
  if(!$f->isPublic())
  {
    die("Method not found1.");
  }
  $args=[];
  foreach($f->getParameters() as $param)
  {
    if(isset($_REQUEST[$param->name]))
    {
      $args[]=$_REQUEST[$param->name];
    }
    elseif($param->isDefaultValueAvailable())
    {
      $args[]=$param->getDefaultValue();
    }
    else
    {
      http_response_code(400);
      die("Requires param ".$param->name);
    }
  }
  echo api::$method(...$args)??"";
}
else
{
  die("Method not found2.");
}
class api
{
  private static function GetDB():PDO
  {
    $db=new PDO("sqlite:database.db");
    $db->query(<<<EOF
    CREATE TABLE "Levels" ( "username" text NOT NULL, "name" text NOT NULL, "level" blob NOT NULL, PRIMARY KEY ("username", "name") )
EOF
    );
    return $db;
  }
  /**
   * @param string $auth Username (todo: JWT of username)
   * @param string $name Level name
   * @param string $conts base64-encoded contents (todo: make this binary-safe and not base64-encode)
   */
  public static function SubmitLevel(string $auth, string $name, string $conts)
  {
    $user=null;
    try
    {
      $decoded = JWT::decode($auth, AUTHENTICATION_KEY, array('HS256'));
      $user=$decoded->sub;
    }
    catch(Exception $e)
    {
      http_response_code(403);
      return; // Not allowed
    }
    $db=static::GetDB();
    $query=$db->prepare("INSERT OR REPLACE INTO Levels(username,name,level) VALUES (?,?,?)");
    $query->execute([$user,$name,$conts]);
  }
  public static function GetLevel(string $user, string $name)
  {
    $db=static::GetDB();
    $query=$db->prepare("SELECT level FROM Levels WHERE username=? AND name=?");
    $query->execute([$user,$name]);
    $result=$query->fetch();
    if(!$result)
    {
      http_response_code(404);
      return;
    }
    return $result[0];
  }
}