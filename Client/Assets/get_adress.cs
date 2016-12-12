using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class get_adress : MonoBehaviour
{
    public Text adress;
    public string temp;

    void Start()
    {
        manage_state_and_btn();
    }

    void Update()
    {
        try
        {
            manage_state_and_btn();
        }
        catch
        {
            manage_state_and_btn();
        }
    }

    public void manage_state_and_btn()
    {
        try
        {
            temp = get_adress_temp();
        }
        catch
        {
            temp = "ошибка";
        }
        adress.text = temp;
    }

    public string get_adress_temp()
    {
        WebRequest req = HttpWebRequest.Create("http://relaxcs.by/andrewkharkov/ss/adress");
        Stream s = req.GetResponse().GetResponseStream();
        StreamReader sr = new StreamReader(s);
        string state = sr.ReadToEnd();
        sr.Close();
        return state;
    }
}
