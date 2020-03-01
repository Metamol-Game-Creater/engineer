using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class byebyescript : MonoBehaviour
{
    public GameObject[] randomserif;

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

        randomserif[Random.Range(0, randomserif.Length)].SetActive(true);
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
        SceneManager.LoadScene("HomeScene");
    }
}
