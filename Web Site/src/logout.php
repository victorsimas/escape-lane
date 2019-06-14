<?php
    session_start();
    if(isset($_SESSION["name"])){
        unset($_SESSION["name"]);
        unset($_SESSION["id"]);	
        header("location ../prime.html");	
    }
    header("location: ../contact.html");
?>