<?php

include_once 'secure/database.php';

session_start();
if (isset($_SESSION['USER'])) {
    print('1' . $_SESSION['USER']);
} else {
    if (filter_input(INPUT_SERVER, 'REQUEST_METHOD') === 'POST') {
        $user = filter_input(INPUT_POST, 'USER');
        $pass = hash('sha256', filter_input(INPUT_POST, 'PASS'));
        $dbPass = null;

        $sm = $con->prepare("SELECT password FROM users WHERE username=?");
        $sm->bind_param("s", $user);
        $sm->execute();
        $sm->bind_result($dbPass);
        $sm->fetch();
        $sm->close();

        if ($pass === $dbPass) {
            $_SESSION['USER'] = $user;
            print('0');
        } else {
            print('-2');
        }
    }
    else{
        print('-1');
    }
}