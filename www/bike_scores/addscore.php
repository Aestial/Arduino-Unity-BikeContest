<?php
        // Configuration
        $hostname = 'localhost';
        $username = 'root';
        $password = '';
        $database = 'race_highscores';
 
        try {
            $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
        } catch(PDOException $e) {
            echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
        }
        $sth = $dbh->prepare('INSERT INTO scores VALUES (null, :name, :score)');
        try {
            $sth->execute($_GET);
        } catch(Exception $e) {
            echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
        } 
?>