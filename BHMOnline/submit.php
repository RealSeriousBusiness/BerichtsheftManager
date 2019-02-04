<?php

session_start();
if (isset($_SESSION['USER'])) {
    $loggedIn = $_SESSION['USER'];
    if (filter_input(INPUT_SERVER, 'REQUEST_METHOD') === 'POST') {
        include_once 'secure/database.php';
        $data = filter_input(INPUT_POST, 'BHDB');
        $timestamp = filter_input(INPUT_GET, 'DATE');
        if (strlen($data) < 5242880) { //only accept data smaller than 5mb
            $file = fopen('secure/data/' . $loggedIn . '.bin', 'w');
            fwrite($file, $data);
            fclose($file);
            $up = $con->prepare('UPDATE users SET lastUpdate=? WHERE username=?');
            $up->bind_param('ss', $timestamp, $loggedIn);
            $up->execute();
            $up->close();
            print '0';
        } else {
            print '-1';
        }
    } else {
        print '-2';
    }
}
