using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class get_state : MonoBehaviour {
    public Text state;
    public Button btn_on;
    public Button btn_off;
    public bool temp;

    void Start () {
        manage_state_and_btn();
    }
	
	void Update () {
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
            temp = get_socket_state();
        }
        catch
        {
            SceneManager.LoadScene("loading");
        }
        if (temp == true)
        {
            state.text = " включено";
            btn_on.enabled = false;
            btn_off.enabled = true;
        }
        else
        {
            state.text = " выключено";
            btn_on.enabled = true;
            btn_off.enabled = false;
        }
    }

    public bool get_socket_state()
    {
        get_adress temp_obj = new get_adress();
        string temp = temp_obj.get_adress_temp();
        WebRequest req = HttpWebRequest.Create("http://" + temp + "/status");
        Stream s = req.GetResponse().GetResponseStream();
        StreamReader sr = new StreamReader(s);
        string state = sr.ReadToEnd();
        sr.Close();
        if (state == "true")
            return true;
        else
            return false;
    }
}
