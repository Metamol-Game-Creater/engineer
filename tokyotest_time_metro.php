<?php
  try{
      $db=new PDO('mysql:dbname=danjo_kotsuapi; host=localhost; charset=utf8','root','dokko730Luci');//SQLと接続開始
      $delete=$db->exec('DELETE FROM metro_timetable');
      $url_string=array("YoyogiUehara","YoyogiKoen","MeijiJingumae","OmoteSando","Nogizaka","Akasaka","KokkaiGijidomae","Kasumigaseki","Hibiya","Nijubashimae","Otemachi","ShinOchanomizu","Yushima","Nezu","Sendaki","NishiNippori","Machiya","KitaSenju","Ayase","KitaAyase");
    foreach ($url_string as $value) {
      $url='https://api-tokyochallenge.odpt.org/api/v4/odpt:TrainTimetable?odpt:operator=odpt.Operator:TokyoMetro&acl:consumerKey=ee2a7152f567cd236d76915435127ac08ac6cea740a13926b85b9d00d6e47a40'
;
      //return;
      $json=file_get_contents($url);
      $arr=json_decode($json,true);
      if($arr==NULL){
          echo "MISS".$value;
          return;
        }else{
          $day_count=count($arr);
      //次に$timeという配列変数を作る
          $time=array();//rootがname,vagrantがpassward
          $stmt=$db->prepare('INSERT INTO metro_timetable(departure_Station,departure_Time,rail_direction,train_number,day_sp)VALUES(?,?,?,?,?)');
          for($n=0;$n<=$day_count-1;++$n){
            $json_count=count($arr[$n]["odpt:trainTimetableObject"]);//Timetableobject=Key Keyの中にある配列や要素の数を数えている
            for($i=0;$i<=$json_count-1;++$i){
              //bindValueが値を入れるという意味　1→最初の？、？→station_name、odpt:station=key
              $stmt->bindValue(1,$arr[$n]["odpt:trainTimetableObject"][$i]["odpt:departureStation"],PDO::PARAM_STR);
              $stmt->bindValue(2,$arr[$n]["odpt:trainTimetableObject"][$i]["odpt:departureTime"],PDO::PARAM_STR);
              $stmt->bindValue(3,$arr[$n]["odpt:railDirection"],PDO::PARAM_STR);
              $stmt->bindValue(4,$arr[$n]["odpt:trainNumber"],PDO::PARAM_STR);
              $stmt->bindValue(5,$arr[$n]["odpt:calendar"],PDO::PARAM_STR);
              $stmt->execute(); //SQLに保存
            }
          }
        }
      }
      $db=null;
    }catch(PDOException $e){
      echo "DB接続エラー:".$e->getMessage();
    }//失敗したらcatchにいく デバッグログをはさんでおくとよい
?>
