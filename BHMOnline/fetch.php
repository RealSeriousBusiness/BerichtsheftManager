<?php
session_start();
if(isset($_SESSION['USER']))
{
     $loggedIn = $_SESSION['USER'];
     $filename = 'secure/data/' . $loggedIn . '.bin';
     
     if(file_exists($filename))
     {
        $file = fopen($filename, 'r');
        print fread($file, filesize($filename));
        fclose($file);
     }
     else
     {
         print '-1';
     }
}