<?php
require_once( "RA_API.php" );
$RAConn = new RetroAchievements('coczero', 'AEwHP8tc6G9JaUweJl3zMZq2CRj2uIPV' );

$data = $RAConn->GetGameList($argv[1]);
for($i = 0; $i < count($data); $i++)
{
echo $data[$i]->Title;
echo "|";
echo $data[$i]->ID;
echo "|";
echo $data[$i]->ConsoleID;
echo "|";
echo $data[$i]->ConsoleName;
if($i != count($data) - 1)
  echo "|";
}
?>