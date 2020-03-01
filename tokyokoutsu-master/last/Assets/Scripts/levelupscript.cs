using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelupscript : MonoBehaviour
{
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

    public GameObject serif1;
    public GameObject serif2;
    public GameObject serif3;
    public GameObject serif4;

    public GameObject comment1;
    public GameObject comment2;
    public GameObject comment3;
    public GameObject comment4;

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
        if (stsum == 5)
        {
            comment1.SetActive(true);
            level2.SetActive(true);
            serif1.SetActive(true);
        }
        if (stsum == 10)
        {
            comment2.SetActive(true);
            level3.SetActive(true);
            serif2.SetActive(true);
        }
        if (stsum == 15)
        {
            comment3.SetActive(true);
            level4.SetActive(true);
            serif3.SetActive(true);
        }
        if (stsum == 20)
        {
            comment4.SetActive(true);
            level5.SetActive(true);
            serif4.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PushStartButton()
    {
        SceneManager.LoadScene("GuideScene");
    }
}
