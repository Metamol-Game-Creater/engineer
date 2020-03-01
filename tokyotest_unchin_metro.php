<?php
$break = '<br/>';
  try{
      $db=new PDO('mysql:dbname=danjo_kotsuapi; host=localhost; charset=utf8','root','dokko730Luci');//SQLと接続開始
      $db->exec('DELETE FROM metro_money');
      //$delete=$db->exec('DELETE FROM API_about');
      $url_string=array("Nakano","Ochiai","Takadanobaba","Waseda","Kagurazaka","Iidabashi","Kudanshita","Takebashi","Nihombashi","Kayabacho","MonzenNakacho","Kiba"
      ,"Toyocho","MinamiSunamachi","NishiKasai","Kasai","Urayasu","MinamiGyotoku","Gyotoku","Myoden","BarakiNakayama","NishiFunabashi");
    foreach ($url_string as $value) {
      $url=
      'https://api-tokyochallenge.odpt.org/api/v4/odpt:RailwayFare?odpt:operator=odpt.Operator:TokyoMetro&acl:consumerKey=ee2a7152f567cd236d76915435127ac08ac6cea740a13926b85b9d00d6e47a40'
      // これは

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
          $stmt=$db->prepare('INSERT INTO metro_money(start_station,goal_station,ICcharge,notICcharge,ICchargechild,notICchargechild)VALUES(?,?,?,?,?,?)');
          for($n=0;$n<=$day_count-1;++$n){
            $json_count=count($arr[$n]);//Timetableobject=Key Keyの中にある配列や要素の数を数えている
            for($i=0;$i<=$json_count-1;++$i){
              $stmt->bindParam(1,$arr[$n]["odpt:toStation"],PDO::PARAM_STR);//bindValueが値を入れるという意味　1→最初の？、？→station_name、odpt:station=key
              $stmt->bindParam(2,$arr[$n]["odpt:fromStation"],PDO::PARAM_STR);
              $stmt->bindParam(3,$arr[$n]["odpt:icCardFare"],PDO::PARAM_STR);
              $stmt->bindParam(4,$arr[$n]["odpt:ticketFare"],PDO::PARAM_STR);
              $stmt->bindParam(5,$arr[$n]["odpt:childIcCardFare"],PDO::PARAM_STR);
              $stmt->bindParam(6,$arr[$n]["odpt:childTicketFare"],PDO::PARAM_STR);
              $stmt->execute(); //SQLに保存

              echo "<FONT COLOR=\"RED\">駅は</FONT>".$value; "\n";
              echo"<FONT COLOR=\"RED\">駅です</FONT>{$break}";

echo "<FONT COLOR=\"BLUE\">到着予定の駅は</FONT>"; "\n";
echo $arr[$n]["odpt:toStation"]; "\n";
echo"<FONT COLOR=\"BLUE\">です</FONT>{$break}";
echo "<FONT COLOR=\"ORANGE\">それに伴うＩＣカード料金は</FONT>"; "\n";
echo $arr[$n]["odpt:icCardFare"] ; "\n";
echo"<FONT COLOR=\"ORANGE\">です</FONT>{$break}";
echo "<FONT COLOR=\"GREEN\">切符料金は</FONT>"; "\n";
echo $arr[$n]["odpt:ticketFare"] ;"\n";
echo"<FONT COLOR=\"GREEN\">です</FONT>{$break}";
echo "<FONT COLOR=\"ORANGE\">子供料金（ＩＣカード）は</FONT>"; "\n";
echo $arr[$n]["odpt:childIcCardFare"];"\n";
echo"<FONT COLOR=\"ORANGE\">です</FONT>{$break}";
echo "<FONT COLOR=\"GREEN\">子供料金（切符）は</FONT>"; "\n";
echo $arr[$n]["odpt:childTicketFare"];"\n";
echo"<FONT COLOR=\"GREEN\">です</FONT>{$break}";
echo"{$break}";

            }
          }
        }
      }
      $db=null;
    }catch(PDOException $e){
      echo "DB接続エラー:".$e->getMessage();
    }//失敗したらcatchにいく デバッグログをはさんでおくとよい
?>
