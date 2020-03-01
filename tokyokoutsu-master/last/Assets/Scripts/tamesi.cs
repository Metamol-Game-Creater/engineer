using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　//追加（長田）
using UnityEngine.SceneManagement;　//追加（正直いらん）（長田）
using System; //追加（長田）
using System.IO;　//追加（長田）

public class tamesi : MonoBehaviour
{
    //オブジェクトとの結び付け（長田）
    public Text st;
    public Text go;
    public Text num;
    public Text dtime;
    public Text atime;
    public Text taketime;

    // Start is called before the first frame update
    void Start()
    {
        //Testで代入した内容を当てはめてる（長田）
        st.text = Time.depa;
        go.text = Time.arri;
        num.text = Time.ekisuu.ToString();
        dtime.text = Time.dtime.Substring(11, 5);
        atime.text = Time.atime.Substring(11, 5);
        taketime.text = Time.taketime2.Substring(3, 2) + "分";
        

    }
    public void PushStartButton()
    {
        SceneManager.LoadScene("ConfirmScene");
    }
    public void PushReturnButton()
    {
        SceneManager.LoadScene("FormScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
