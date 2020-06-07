<?php
    // Configuration
    $hostname = 'localhost';
    $username = 'root';
    $password = '';
    $database = 'race_highscores';
 
    try {
        $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
    } catch(PDOException $e) {
        echo '<h1>An error has occurred.</h1><pre>', $e->getMessage() ,'</pre>';
    }
 
    $sth = $dbh->query('SELECT * FROM scores ORDER BY score ASC LIMIT 5');
    $sth->setFetchMode(PDO::FETCH_ASSOC);
 
    $result = $sth->fetchAll();

    $count = 1;

    $max = $dbh->query('SELECT MAX(score) FROM scores');
    //$min->setFetchMode(PDO::FETCH_ASSOC);
 
    $maxResult = $max->fetch();
 
    if(count($result) > 0) {
        foreach($result as $r) {
            echo $count, ". ", $r['name'], "\t", $r['score'], "\n";
            $count++;
        }
        echo "MAX:", $maxResult[0];
    }
?>