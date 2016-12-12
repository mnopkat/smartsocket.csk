<?php
$adress = $_GET["adress_temp"];

function set_state($adress) {
	$fp = fopen("adress", 'a');
	ftruncate($fp, 0);
	fwrite($fp, $adress);
}

set_state($adress);
?>