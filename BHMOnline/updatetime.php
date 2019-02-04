<?php

include_once 'secure/database.php';

session_start();
if(isset($_SESSION['USER']))
{
    $date = null;
    $user = $_SESSION['USER'];
    $ps = $con->prepare('SELECT lastUpdate FROM users WHERE username=?');
    $ps->bind_param('s', $user);
    $ps->execute();
    $ps->bind_result($date);
    $ps->fetch();
    $ps->close();
    if($date)
    {
        print('l' . $date);
    }
        
}
else
{
    print('you need to login to logout');
}