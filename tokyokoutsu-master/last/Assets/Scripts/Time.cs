using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class Time : MonoBehaviour
{
    Entity_Sheet1 es;
    Entity_Sheet2 es2;
    Entity_Sheet3 es3;
    public StationNameAlphabet SMA;

    public InputField Time_M;
    public InputField Time_D;
    public InputField Time_h;　
    public InputField Time_m;

    public InputField Chaku;
    public InputField Hatu;

    public static string hatu = "";
    public static string chaku = "";
    public static int ekisuu;

    public static string depa;
    public static string arri;

    /*private TouchScreenKeyboard keyboard;*/

    int start;
    int goal;

    public string ThisYear;
    public string ThisMonth ; 
    public string ThisDay ;
    public string ThisHizuke ;

    public string ThisHour ;
    public string ThisMinute ;
    public string ThisSecond = "00";
    public string ThisTime ;
    private string datetimeStr;

    private string WeekDay;
    private int Daiya; //0なら土日,1なら平日
    private int Direction=0;//0ならのぼり,1ならくだり
    private string RailDirection;

    DateTime Thisdt2;
    DateTime Ddt;
    DateTime Adt;
    TimeSpan taketime1;

    public static bool Check = true;
    public Image checkceck;
    public Text chect;

    public static string dtime;
    public static string atime;
    public static string taketime2;

    void Start()
    {
        Direction = 0;
        es2 = Resources.Load("time") as Entity_Sheet2;
        //DateTime dt2 = DateTime.FromOADate(es2.sheets[0].list[0].departure_Time);
        es3 = Resources.Load("TimeArrive") as Entity_Sheet3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Check)
        {
            checkceck.GetComponent<Image>().enabled = true;
            chect.GetComponent<Text>().enabled = true;
            Invoke("Checkkesu", 3);
        }
        else
        {
            checkceck.GetComponent<Image>().enabled = false;
            chect.GetComponent<Text>().enabled = false;
        }

        /*if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            //print("入力値: " + keyboard.text);}*/
        
    }

    public void InputTimeText() 
    {
        hatu = Hatu.text;
        chaku = Chaku.text;

        ThisYear = DateTime.Now.Year.ToString(); //"年"だけ今の年を取得
        ThisMonth = Time_M.text;
        ThisDay = Time_D.text;

        ThisMinute = Time_m.text;
        ThisHour = Time_h.text;

        ThisHizuke = ThisYear + "/" + ThisMonth + "/" + ThisDay; // 20XX/YY/ZZ

        ThisTime = ThisHour + ":" + ThisMinute + ":" + ThisSecond; // 12:12:00
        
        
    }

    /*public void SelectButton()
    {
        this.keyboard = TouchScreenKeyboard.Open("キーボードに最初に入れておくテキスト", TouchScreenKeyboardType.Default);
        //後から変更も可能
        this.keyboard.text = "キーボードに入れるテキスト";
    }*/

    public void OutputCheck()
    {
        Check = false;
        bool hatucheck = false;
        bool chakucheck = false;

        bool Mcheck = false;
        bool Dcheck = false;
        bool Hcheck = false;
        bool mcheck = false;

        int i;
        for (i = 0; i < SMA.StationJapanese.Length; i++)
        {
            if (hatu.Equals(SMA.StationJapanese[i]))
            {
                hatucheck = true;
            }


            if (chaku.Equals(SMA.StationJapanese[i]))
            {
                chakucheck = true;
            }

        }
        if(ThisMonth != "" && ThisDay != "" && ThisHour != "" && ThisMinute != "")
        {

            if (1 <= int.Parse(ThisMonth) && int.Parse(ThisMonth) <= 12)
            {
                Mcheck = true;
            }
            if (1 <= int.Parse(ThisDay) && int.Parse(ThisDay) <= 31)
            {
                Dcheck = true;
            }
            if (1 <= int.Parse(ThisHour) && int.Parse(ThisHour) <= 24)
            {
                Hcheck = true;
            }
            if (0 <= int.Parse(ThisMinute) && int.Parse(ThisMinute) <= 59)
            {
                mcheck = true;
            }

        }

        if (hatucheck && chakucheck && Mcheck && Dcheck && mcheck && Hcheck)
        {
            Check = true;
        }
       

        if (Check)
        {
            Output();
        }
        
    }
        public void Output()
    {
        
        Debug.Log(ThisHizuke);
        Debug.Log(ThisTime);
        
        DateTime Thisdt = DateTime.Parse(ThisHizuke); //DateTime型に変換
        WeekDay = Thisdt.DayOfWeek.ToString();
        Debug.Log(WeekDay);

        if (WeekDay.Equals("Saturday") | WeekDay.Equals("Sunday")) //曜日が平日か土日か
            Daiya = 0;
        else
            Daiya = 1;

        Thisdt2 = DateTime.Parse("12/30/1899 " + ThisTime); //DateTime型に変換
        Debug.Log(Thisdt2);

        int i;
        for (i = 0; i < SMA.StationJapanese.Length; i++)
        {
            if (hatu.Equals(SMA.StationJapanese[i]))
            {
                hatu = SMA.StationAlpha[i];
                Direction = 1;
                RailDirection = "odpt.RailDirection:TokyoMetro.YoyogiUehara";
            }


            if (chaku.Equals(SMA.StationJapanese[i]))
            {
                chaku = SMA.StationAlpha[i];
                Direction = 0;
                RailDirection = "odpt.RailDirection:TokyoMetro.KitaAyase";
            }

        }
        bool ExistCheck = true;

        if (Daiya == 0) //土日
        {
            double oadate0 = 1;
            int store = 0;
            DateTime Karidt = Thisdt2;
            double oadate = Karidt.ToOADate();
            Debug.Log(oadate);
            hatu = "odpt.Station:TokyoMetro.Chiyoda." + hatu;　//Excelの形式に
            chaku = "odpt.Station:TokyoMetro.Chiyoda." + chaku;
            Debug.Log("出発:" + hatu);
            Debug.Log("到着:" + chaku);


            while (ExistCheck)
            {
                for (i = 0; i < 6215; i++) //6216
                {
                    
                    if (oadate < es2.sheets[0].list[i].departure_Time && oadate0 > es2.sheets[0].list[i].departure_Time && hatu.Equals(es2.sheets[0].list[i].departure_Station) && RailDirection.Equals(es2.sheets[0].list[i].rail_direction))
                    {
                        oadate0 = es2.sheets[0].list[i].departure_Time;
                        
                        Ddt = DateTime.FromOADate(oadate0);
                        store = i;
                    }

                }

                for (i = 0; i < 6215; i++) //6216
                {
                    //同じ電車番号　
                    if (es3.sheets[0].list[i].train_number.Equals(es2.sheets[0].list[store].train_number))
                    {
                        //かつ　着が発で存在するとき(端っこは存在しない)
                        if (es3.sheets[0].list[i].arrival_Station.Equals(chaku))
                        {
                            ExistCheck = false;
                            //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //到着時刻
                            //Debug.Log(i);
                            Adt = DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time);

                        }
                        else if (chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.KitaAyase") && es2.sheets[0].list[i].departure_Station.Equals("odpt.Station:TokyoMetro.Chiyoda.Ayase"))
                        {
                            ExistCheck = false;
                            //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //到着時刻
                            Debug.Log("たし5");
                            Adt = DateTime.FromOADate(es2.sheets[0].list[i].departure_Time);
                            Adt = Adt.AddMinutes(5);

                        }
                        else if (chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.YoyogiUehara") && es2.sheets[0].list[i].departure_Station.Equals("odpt.Station:TokyoMetro.Chiyoda.YoyogiKoen"))
                        {
                            ExistCheck = false;
                            //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //到着時刻
                            Debug.Log("たし2");
                            Adt = DateTime.FromOADate(es2.sheets[0].list[i].departure_Time);
                            Adt = Adt.AddMinutes(2);

                        }
                    }
                }
                //同じ電車番号で綾瀬発があれば5分足す

                //北綾瀬-綾瀬間(sも含む)
                if ((hatu.Equals("odpt.Station:TokyoMetro.Chiyoda.KitaAyase") && chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.Ayase")) || (hatu.Equals("odpt.Station:TokyoMetro.Chiyoda.Ayase") && chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.KitaAyase")))
                {
                    oadate0 = 1;
                    for (i = 0; i < 6215; i++) //6216
                    {
                        //下から同じ電車番号　s1とか
                        if (SubstringRight(SubstringRight(es3.sheets[0].list[i].arrival_Station, 2), 2).Equals(SubstringRight(SubstringRight(chaku, 2), 2)))
                        {
                            if (es2.sheets[0].list[store].departure_Time < es3.sheets[0].list[i].arrival_Time && oadate0 >= es3.sheets[0].list[i].arrival_Time)
                            {
                                oadate0 = es3.sheets[0].list[i].arrival_Time;
                                ExistCheck = false;
                                //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //出発時刻
                                //Debug.Log(i);
                                Adt = DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time);
                            }
                        }
                    }
                }
                oadate = oadate0;
                oadate0 = 1;
                if (oadate == 1)
                {
                    Debug.Log("無理");
                    ExistCheck = false;
                }
              
            }




        }
        else if (Daiya == 1) //平日
        {
            double oadate0 = 1;
            int store = 0;
            DateTime Karidt = Thisdt2;
            double oadate = Karidt.ToOADate();
            hatu = "odpt.Station:TokyoMetro.Chiyoda." + hatu;　//Excelの形式に
            chaku = "odpt.Station:TokyoMetro.Chiyoda." + chaku;



            while (ExistCheck)
            {
                for (i = 6215; i < 13923; i++) 
                {
                    if (oadate < es2.sheets[0].list[i].departure_Time && oadate0 >= es2.sheets[0].list[i].departure_Time && hatu.Equals(es2.sheets[0].list[i].departure_Station) && RailDirection.Equals(es2.sheets[0].list[i].rail_direction))
                    {
                        oadate0 = es2.sheets[0].list[i].departure_Time;
                        //Debug.Log("出発" + DateTime.FromOADate(oadate0)); //出発時刻
                        //Debug.Log(i);
                        Ddt = DateTime.FromOADate(oadate0);
                        store = i;
                    }

                }

                for (i = 6215; i < 13923; i++)
                {
                    //同じ電車番号　
                    if (es3.sheets[0].list[i].train_number.Equals(es2.sheets[0].list[store].train_number))
                    {
                        //かつ　着が発で存在するとき(端っこは存在しない)
                        if (es3.sheets[0].list[i].arrival_Station.Equals(chaku))
                        {
                            ExistCheck = false;
                            //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //到着時刻
                            //Debug.Log(i);
                            Adt = DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time);

                        }
                        else if (chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.KitaAyase") && es2.sheets[0].list[i].departure_Station.Equals("odpt.Station:TokyoMetro.Chiyoda.Ayase"))
                        {
                            ExistCheck = false;
                            //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //到着時刻
                            Debug.Log("たし5");
                            Adt = DateTime.FromOADate(es2.sheets[0].list[i].departure_Time);
                            Adt = Adt.AddMinutes(5);

                        }
                        else if (chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.YoyogiUehara") && es2.sheets[0].list[i].departure_Station.Equals("odpt.Station:TokyoMetro.Chiyoda.YoyogiKoen"))
                        {
                            ExistCheck = false;
                            //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //到着時刻
                            Debug.Log("たし2");
                            Adt = DateTime.FromOADate(es2.sheets[0].list[i].departure_Time);
                            Adt = Adt.AddMinutes(2);

                        }
                    }
                }
                //同じ電車番号で綾瀬発があれば5分足す

                //北綾瀬-綾瀬間(sも含む)
                if ((hatu.Equals("odpt.Station:TokyoMetro.Chiyoda.KitaAyase") && chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.Ayase")) || (hatu.Equals("odpt.Station:TokyoMetro.Chiyoda.Ayase") && chaku.Equals("odpt.Station:TokyoMetro.Chiyoda.KitaAyase")))
                {
                    oadate0 = 1;
                    for (i = 0; i < 6215; i++) //6216
                    {
                        //下から同じ電車番号　s1とか
                        if (SubstringRight(SubstringRight(es3.sheets[0].list[i].arrival_Station, 2), 2).Equals(SubstringRight(SubstringRight(chaku, 2), 2)))
                        {
                            if (es2.sheets[0].list[store].departure_Time < es3.sheets[0].list[i].arrival_Time && oadate0 >= es3.sheets[0].list[i].arrival_Time)
                            {
                                oadate0 = es3.sheets[0].list[i].arrival_Time;
                                ExistCheck = false;
                                //Debug.Log("到着" + DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time)); //出発時刻
                                //Debug.Log(i);
                                Adt = DateTime.FromOADate(es3.sheets[0].list[i].arrival_Time);
                            }
                        }
                    }
                }
                oadate = oadate0;
                oadate0 = 1;
                if (oadate == 1)
                {
                    //Debug.Log("無理");
                    ExistCheck = false;
                }
            }



            
        }
        
        dtime = Ddt.ToString();
        atime = Adt.ToString();
        taketime1 = Adt - Ddt;
        taketime2 = taketime1.ToString();

        depa = Hatu.text;
        arri = Chaku.text;

        es = Resources.Load("takeuchi") as Entity_Sheet1; //エクセル呼び出し  
        for (i = 0; i < 20; i++)
        {//長さはlength取得に変更すべき
            if (depa.Equals(es.sheets[0].list[i].name))
            {
                Debug.Log("発:" + es.sheets[0].list[i].name);//発：ありましたのデバッグ表示
                start = i;//発の駅の番号を保管しておく
            }
            if (arri.Equals(es.sheets[0].list[i].name))
            {
                Debug.Log("着:" + es.sheets[0].list[i].name);//着：ありましたのデバッグ表示
                goal = i;//着の駅の番号を保管しておく
            }
        }
        if (goal > start)
        {
            ekisuu = goal - start; //駅数を算出
        }
        else
        {
            ekisuu = start - goal;
        }


            Debug.Log(dtime);
        Debug.Log(atime);
        Debug.Log("かかる時間");
        Debug.Log(taketime2);
        SceneManager.LoadScene("ResultScene");
    }


    public string SubstringRight(string target, int length)
    {
        return target.Substring(target.Length - length, length);

    }

    void Checkkesu()
    {
        Check = true;
    }

}
