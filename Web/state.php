<?php
$state = $_GET["state_temp"];

function set_state($state) {
	$fp = fopen("status", 'a');
	ftruncate($fp, 0);
	fwrite($fp, $state);
}

set_state($state);
?>