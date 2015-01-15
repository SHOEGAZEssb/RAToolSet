<?php
require_once( "RA_API.php" );
$RAConn = new RetroAchievements('coczero', 'AEwHP8tc6G9JaUweJl3zMZq2CRj2uIPV' );

for($i = 1; $i < count($argv); $i++)
{
$data = $RAConn->GetGameInfoExtended($argv[$i]);

echo $data->ID;
echo "|";
echo $data->Title;
echo "|";
echo $data->ConsoleID;
echo "|";
echo $data->ForumTopicID;
echo "|";
echo $data->Flags;
echo "|";
echo $data->ImageIcon;
echo "|";
echo $data->ImageTitle;
echo "|";
echo $data->ImageIngame;
echo "|";
echo $data->ImageBoxArt;
echo "|";
echo $data->Publisher;
echo "|";
echo $data->Developer;
echo "|";
echo $data->Genre;
echo "|";
echo $data->Released;
echo "|";
echo $data->IsFinal;
echo "|";
echo $data->ConsoleName;
echo "|";
echo $data->RichPresencePatch;
echo "|";
echo $data->NumAchievements;
echo "|";
echo $data->NumDistinctPlayersCasual;
echo "|";
echo $data->NumDistinctPlayersHardcore;

/*
$achArr = array($data->Achievements);
$deb = $data-Achievements;
echo "DEBUG ";
echo $deb->'1124
echo " DEBUGEND";
for($e = 0; $e < count($achArr); $e++)
{
echo $achArr[$e]->ID;
echo "|";
echo $achArr[$e]->NumAwarded; comment 
echo "|";
echo $achArr[$e]->NumAwardedHardcore;
echo "|";
echo $achArr[$e]->Title;
echo "|";
echo $achArr[$e]->Description;
echo "|";
echo $achArr[$e]->Points;
echo "|";
echo $achArr[$e]->TrueRatio;
echo "|";
echo $achArr[$e]->Author;
echo "|";
echo $achArr[$e]->DateModified;
echo "|";
echo $achArr[$e]->DateCreated;
echo "|";
echo $achArr[$e]->BadgeName;
echo "|";
echo $achArr[$e]->DisplayOrder;
echo "|";
}
echo "AchievementSectionEnd";
*/

if($i != count($argv) - 1)
  echo "|";
}
?>