<?php

if (filter_input(INPUT_SERVER, 'REQUEST_METHOD') === 'POST') {
    include_once 'secure/database.php';

    $user = filter_input(INPUT_POST, 'USER');
    $mail = filter_input(INPUT_POST, 'MAIL');
    $pass = filter_input(INPUT_POST, 'PASS');

    if ($user && preg_match("/[^ ]+@[^ ]+[.][^ ]{2,}/", $mail) && $pass) {
        $res = null;
        $sm = $con->prepare('SELECT username FROM users WHERE username = ? OR email = ?');
        $sm->bind_param('ss', $user, $pass);
        $sm->execute();
        $sm->bind_result($res);
        $sm->fetch();
        $sm->close();
        if (!$res) {
            $addUser = $con->prepare('INSERT INTO users(username, email, password) VALUES(?, ?, ?)');
            $addUser->bind_param('sss', $user, $mail, hash('sha256', $pass));
            $addUser->execute();
            $addUser->close();
            print '0';
        } else {
            print '-2';
        }
    } else {
        print '-1';
    }
}