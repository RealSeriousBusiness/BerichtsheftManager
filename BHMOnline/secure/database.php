<?php

$host = 'localhost';
$user = 'root';
$pass = '1234';
$db = 'bhm';

$con = new mysqli($host, $user, $pass, $db);

if ($con->connect_errno) {
    die('error');
}