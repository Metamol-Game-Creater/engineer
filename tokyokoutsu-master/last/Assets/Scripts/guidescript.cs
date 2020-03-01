using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guidescript : MonoBehaviour
{
    public GameObject content1;
    public GameObject content2;
    public GameObject content3;
    public GameObject content4;
    public GameObject content5;
    public GameObject content6;
    public GameObject content7;
    public GameObject content8;
    public GameObject content9;
    public GameObject content10;
    public GameObject content11;
    public GameObject content12;
    public GameObject content13;
    public GameObject content14;
    public GameObject content15;
    public GameObject content16;
    public GameObject content17;
    public GameObject content18;
    public GameObject content19;
    public GameObject content20;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    // Start is called before the first frame update
    void Start()
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

        if (Time.arri == "代々木上原")
        {
            content1.SetActive(true);
        }
        if (Time.arri == "代々木公園")
        {
            content2.SetActive(true);
        }
        if (Time.arri == "明治神宮前")
        {
            content3.SetActive(true);
        }
        if (Time.arri == "表参道")
        {
            content4.SetActive(true);
        }
        if (Time.arri == "乃木坂")
        {
            content5.SetActive(true);
        }
        if (Time.arri == "赤坂")
        {
            content6.SetActive(true);
        }
        if (Time.arri == "国会議事堂前")
        {
            content7.SetActive(true);
            PlayerPrefs.SetInt("data7", 1);
        }
        if (Time.arri == "霞ヶ関")
        {
            content8.SetActive(true);
        }
        if (Time.arri == "日比谷")
        {
            content9.SetActive(true);
        }
        if (Time.arri == "二重橋前")
        {
            content10.SetActive(true);
        }
        if (Time.arri == "大手町")
        {
            content11.SetActive(true);
        }
        if (Time.arri == "新御茶ノ水")
        {
            content12.SetActive(true);
        }
        if (Time.arri == "湯島")
        {
            content13.SetActive(true);
        }
        if (Time.arri == "根津")
        {
            content14.SetActive(true);
        }
        if (Time.arri == "千駄木")
        {
            content15.SetActive(true);
        }
        if (Time.arri == "西日暮里")
        {
            content16.SetActive(true);
        }
        if (Time.arri == "町屋")
        {
            content17.SetActive(true);
        }
        if (Time.arri == "北千住")
        {
            content18.SetActive(true);
        }
        if (Time.arri == "綾瀬")
        {
            content19.SetActive(true);
        }
        if (Time.arri == "北綾瀬")
        {
            content20.SetActive(true);
        }
        if ((stsum >= 5) && (stsum <= 9))
        {
            level2.SetActive(true);
        }
        else if ((stsum >= 10) && (stsum <= 14))
        {
            level3.SetActive(true);
        }
        else if ((stsum >= 15) && (stsum <= 19))
        {
            level4.SetActive(true);
        }
        else if (stsum == 20)
        {
            level5.SetActive(true);
        }
        else
        {
            level1.SetActive(true);
        }
        Debug.Log(stsum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PushStartButton()
    {
        SceneManager.LoadScene("ByeByeScene");
    }
}
