using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arrive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
        if ((st1 != 1) && (Time.arri == "代々木上原"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st2 != 1) && (Time.arri == "代々木公園"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st3 != 1) && (Time.arri == "明治神宮前"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st4 != 1) && (Time.arri == "表参道"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st5 != 1) && (Time.arri == "乃木坂"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st6 != 1) && (Time.arri == "赤坂"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st7 != 1) && (Time.arri == "国会議事堂前"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st8 != 1) && (Time.arri == "霞ヶ関"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st9 != 1) && (Time.arri == "日比谷"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st10 != 1) && (Time.arri == "二重橋前"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st11 != 1) && (Time.arri == "大手町"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st12 != 1) && (Time.arri == "新御茶ノ水"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st13 != 1) && (Time.arri == "湯島"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st14 != 1) && (Time.arri == "根津"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st15 != 1) && (Time.arri == "千駄木"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st16 != 1) && (Time.arri == "西日暮里"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st17 != 1) && (Time.arri == "町屋"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st18 != 1) && (Time.arri == "北千住"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st19 != 1) && (Time.arri == "綾瀬"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else if ((st20 != 1) && (Time.arri == "北綾瀬"))
        {
            SceneManager.LoadScene("StampScene");
        }
        else 
        {
            SceneManager.LoadScene("GuideScene");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}