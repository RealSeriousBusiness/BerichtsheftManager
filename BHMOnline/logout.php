<?php

include_once 'secure/database.php';

session_start();
if(isset($_SESSION['USER']))
{
    unset($_SESSION['USER']);
    print('0');
}
else
{
    print('-1');
}