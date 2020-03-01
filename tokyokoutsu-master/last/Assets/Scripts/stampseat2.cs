using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stampseat2 : MonoBehaviour
{

    public GameObject stamp1;
    public GameObject stamp2;
    public GameObject stamp3;
    public GameObject stamp4;
    public GameObject stamp5;
    public GameObject stamp6;
    public GameObject stamp7;
    public GameObject stamp8;
    public GameObject stamp9;
    public GameObject stamp10;
    public GameObject stamp11;
    public GameObject stamp12;
    public GameObject stamp13;
    public GameObject stamp14;
    public GameObject stamp15;
    public GameObject stamp16;
    public GameObject stamp17;
    public GameObject stamp18;
    public GameObject stamp19;
    public GameObject stamp20;


    // Start is called before the first frame update
    void Start()
    {
        if (Time.arri == "代々木上原")
        {
            stamp1.SetActive(true);
            PlayerPrefs.SetInt("data1", 1);
        }
        if (Time.arri == "代々木公園")
        {
            stamp2.SetActive(true);
            PlayerPrefs.SetInt("data2", 1);
        }
        if (Time.arri == "明治神宮前")
        {
            stamp3.SetActive(true);
            PlayerPrefs.SetInt("data3", 1);
        }
        if (Time.arri == "表参道")
        {
            stamp4.SetActive(true);
            PlayerPrefs.SetInt("data4", 1);
        }
        if (Time.arri == "乃木坂")
        {
            stamp5.SetActive(true);
            PlayerPrefs.SetInt("data5", 1);
        }
        if (Time.arri == "赤坂")
        {
            stamp6.SetActive(true);
            PlayerPrefs.SetInt("data6", 1);
        }
        if (Time.arri == "国会議事堂前")
        {
            stamp7.SetActive(true);
            PlayerPrefs.SetInt("data7", 1);
        }
        if (Time.arri == "霞ヶ関")
        {
            stamp8.SetActive(true);
            PlayerPrefs.SetInt("data8", 1);
        }
        if (Time.arri == "日比谷")
        {
            stamp9.SetActive(true);
            PlayerPrefs.SetInt("data9", 1);
        }
        if (Time.arri == "二重橋前")
        {
            stamp10.SetActive(true);
            PlayerPrefs.SetInt("data10", 1);
        }
        if (Time.arri == "大手町")
        {
            stamp11.SetActive(true);
            PlayerPrefs.SetInt("data11", 1);
        }
        if (Time.arri == "新御茶ノ水")
        {
            stamp12.SetActive(true);
            PlayerPrefs.SetInt("data12", 1);
        }
        if (Time.arri == "湯島")
        {
            stamp13.SetActive(true);
            PlayerPrefs.SetInt("data13", 1);
        }
        if (Time.arri == "根津")
        {
            stamp14.SetActive(true);
            PlayerPrefs.SetInt("data14", 1);
        }
        if (Time.arri == "千駄木")
        {
            stamp15.SetActive(true);
            PlayerPrefs.SetInt("data15", 1);
        }
        if (Time.arri == "西日暮里")
        {
            stamp16.SetActive(true);
            PlayerPrefs.SetInt("data16", 1);
        }
        if (Time.arri == "町屋")
        {
            stamp17.SetActive(true);
            PlayerPrefs.SetInt("data17", 1);
        }
        if (Time.arri == "北千住")
        {
            stamp18.SetActive(true);
            PlayerPrefs.SetInt("data18", 1);
        }
        if (Time.arri == "綾瀬")
        {
            stamp19.SetActive(true);
            PlayerPrefs.SetInt("data19", 1);
        }
        if (Time.arri == "北綾瀬")
        {
            stamp20.SetActive(true);
            PlayerPrefs.SetInt("data20", 1);
        }
        if (PlayerPrefs.HasKey("data1"))
        {
            stamp1.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data2"))
        {
            stamp2.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data3"))
        {
            stamp3.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data4"))
        {
            stamp4.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data5"))
        {
            stamp5.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data6"))
        {
            stamp6.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data7"))
        {
            stamp7.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data8"))
        {
            stamp8.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data9"))
        {
            stamp9.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data10"))
        {
            stamp10.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data11"))
        {
            stamp11.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data12"))
        {
            stamp12.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data13"))
        {
            stamp13.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data14"))
        {
            stamp14.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data15"))
        {
            stamp15.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data16"))
        {
            stamp16.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data17"))
        {
            stamp17.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data18"))
        {
            stamp18.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data19"))
        {
            stamp19.SetActive(true);
        }
        if (PlayerPrefs.HasKey("data20"))
        {
            stamp20.SetActive(true);
        }
    }
    public void PushStartButton()
    {
   
        int st1 = PlayerPrefs.GetInt("data1");
        int st2 = PlayerPrefs.GetInt("data2");
        int st3 = PlayerPrefs.GetInt("data3");
        int st4 = PlayerPrefs.GetInt("data4");
        int st5 = PlayerPrefs.GetInt("data5");
        int st6 = PlayerPrefs.GetInt("data6");
        int st7 = PlayerPrefs.GetInt("data7");
        int st8 = PlayerPrefs.GetInt("data8");
        int st9 = PlayerPrefs.GetInt("data9");
        int st10 = PlayerPrefs.GetInt("data10");
        int st11 = PlayerPrefs.GetInt("data11");
        int st12 = PlayerPrefs.GetInt("data12");
        int st13 = PlayerPrefs.GetInt("data13");
        int st14 = PlayerPrefs.GetInt("data14");
        int st15 = PlayerPrefs.GetInt("data15");
        int st16 = PlayerPrefs.GetInt("data16");
        int st17 = PlayerPrefs.GetInt("data17");
        int st18 = PlayerPrefs.GetInt("data18");
        int st19 = PlayerPrefs.GetInt("data19");
        int st20 = PlayerPrefs.GetInt("data20");
        int stsum = st1 + st2 + st3 + st4 + st5 + st6 + st7 + st8 + st9 + st10 + st11 + st12 + st13 + st14 + st15 + st16 + st17 + st18 + st19 + st20;
        if (stsum == 5)
        {
            SceneManager.LoadScene("LevelupScene");
        }
        else if (stsum == 10)
        {
            SceneManager.LoadScene("LevelupScene");
        }
        else if (stsum == 15)
        {
            SceneManager.LoadScene("LevelupScene");
        }
        else if (stsum == 20)
        {
            SceneManager.LoadScene("LevelupScene");
        }
        else
        {
            SceneManager.LoadScene("GuideScene");
        }
        Debug.Log(stsum);
    }
    // Update is called once per frame
    void Update()
    {

    }
}