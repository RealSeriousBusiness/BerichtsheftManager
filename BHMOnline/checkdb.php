<?php

include_once 'secure/database.php';

$res = $con->query('SELECT ID, username, email, password, lastUpdate FROM users');

if($res){
     print('Database table seems to be working and is created.');  
}
else
{//looks like the db hasnt created yet
    if($con->query('CREATE TABLE users(ID int NOT NULL AUTO_INCREMENT, username VARCHAR(50) NOT NULL, email VARCHAR(128) NOT NULL, password VARCHAR(128) NOT NULL, lastUpdate DATETIME, PRIMARY KEY (ID));') === TRUE)
    {
        print('Database table users created.');
    }
    else
    {
        print('Error');
    }
}

