using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Time : MonoBehaviour
{
    Entity_Sheet2 es2;
    public StationNameAlphabet SMA;

    public InputField Time_M;
    public InputField Time_D;
    public InputField Time_h;　
    public InputField Time_m;　

    string hatu = "代々木上原";
    string chaku = "北綾瀬";

    public string ThisYear;
    public string ThisMonth; 
    public string ThisDay;
    public string ThisHizuke;

    public string ThisHour;
    public string ThisMinute;
    public string ThisSecond = "00";
    public string ThisTime;
    private string datetimeStr;

    private string WeekDay;
    private int Daiya; //0なら土日,1なら平日
    private int Direction;//0ならのぼり,1ならくだり
    private string RailDirection;

    void Start()
    {
        es2 = Resources.Load("time") as Entity_Sheet2;
        Debug.Log(es2.sheets[0].list[0].departure_Time);

        DateTime dt2 = DateTime.FromOADate(es2.sheets[0].list[0].departure_Time);
        Debug.Log(dt2);
        Debug.Log(dt2.Hour + ":" + dt2.Minute + ":" +dt2.Second);
        Debug.Log(dt2.DayOfWeek);

        Debug.Log(es2.sheets[0].list[1].departure_Station);
        Debug.Log(es2.sheets[0].list[1].train_number);

        DateTime dt3 = DateTime.FromOADate(es2.sheets[0].list[1].departure_Time);
        DateTime dt4 = DateTime.FromOADate(es2.sheets[0].list[2].departure_Time);
        Debug.Log(dt4 - dt3);

        int i;
        for(i = 0; i < SMA.StationJapanese.Length; i++)
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
        Debug.Log(chaku);
        Debug.Log(hatu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputTimeText() 
    {
        ThisYear = DateTime.Now.Year.ToString(); //"年"だけ今の年を取得
        ThisMonth = Time_M.text;
        ThisDay = Time_D.text;
        Debug.Log(ThisYear);
        Debug.Log(ThisDay);
        Debug.Log(ThisMonth);


        //ThisHizuke = ThisYear + "/" + ThisMonth + "/" + ThisDay; // 20XX/YY/ZZ
        ThisHizuke = "2019/11/09"; // 20XX/YY/ZZ
        Debug.Log(ThisHizuke);

        ThisTime = ThisHour + ":" + ThisMinute + ":" + ThisSecond; // 12:12:00
        ThisTime = "12/30/1899 12:12:00"; 
        Debug.Log(ThisTime);
        DateTime Thisdt2 = DateTime.Parse(ThisTime); //DateTime型に変換

        DateTime Thisdt = DateTime.Parse(ThisHizuke); //DateTime型に変換
        WeekDay = Thisdt.DayOfWeek.ToString();
        Debug.Log(WeekDay);
        if (WeekDay.Equals("Saturday") | WeekDay.Equals("Sunday"))
            Daiya = 0;
        else
            Daiya = 1;
        int i;
        bool ExistCheck = false;
        if(Daiya == 0)
        {
            double oadate0 = 1;
            int store = 0;
            DateTime Karidt = Thisdt2;
            double oadate = Karidt.ToOADate();
            hatu = "odpt.Station:TokyoMetro.Chiyoda." + hatu;
            chaku = "odpt.Station:TokyoMetro.Chiyoda." + chaku;
            Debug.Log(Thisdt2);
            Debug.Log(hatu);

            for (i = 0; i < 6215; i++) //6216
            {
                //Debug.Log(DateTime.FromOADate(es2.sheets[0].list[i].departure_Time));
                if (oadate < es2.sheets[0].list[i].departure_Time && oadate0 >= es2.sheets[0].list[i].departure_Time && hatu.Equals(es2.sheets[0].list[i].departure_Station) && RailDirection.Equals(es2.sheets[0].list[i].rail_direction))
                {
                    oadate0 = es2.sheets[0].list[i].departure_Time;
                    Debug.Log(DateTime.FromOADate(oadate0)); //出発時刻
                    Debug.Log(i);
                    store = i;
                }
                
            }
            int trainnum = 0;
            for (i = 0; i < 6215; i++) //6216
            {
                //同じ電車番号　
                if(es2.sheets[0].list[i].train_number.Equals(es2.sheets[0].list[store].train_number))
                {
                    trainnum++;
                    //かつ　着が発で存在するとき(端っこは存在しない)
                    if (es2.sheets[0].list[i].departure_Station.Equals(chaku))
                    {
                        Debug.Log(DateTime.FromOADate(es2.sheets[0].list[i].departure_Time)); //出発時刻
                        Debug.Log(i);
                        oadate0 = es2.sheets[0].list[i].departure_Time - oadate0;
                    }
                }
            }

            if(trainnum == 19)
            {

            }

            Debug.Log(DateTime.FromOADate(oadate0).Minute);
            }
    }

    void exam()
    {
        
    }
}
