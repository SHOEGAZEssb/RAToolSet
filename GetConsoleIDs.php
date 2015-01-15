<?php
require_once( "RA_API.php" );
$RAConn = new RetroAchievements('coczero', 'AEwHP8tc6G9JaUweJl3zMZq2CRj2uIPV' );

$data = $RAConn->GetConsoleIDs();
for($i = 0; $i < count($data); $i++)
{
echo $data[$i]->ID;
echo "|";
echo $data[$i]->Name;
if($i != count($data) - 1)
  echo "|";
  
}
?>