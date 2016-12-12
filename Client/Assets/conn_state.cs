using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;

public class conn_state : MonoBehaviour
{
    public string url;
    private bool chk;
    

    public bool check_conn_state()
    {
        try
        {
            get_adress temp_obj = new get_adress();
            string temp = temp_obj.get_adress_temp();
            url = "http://" + temp + "/status";
            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK) chk = true;
        }
        catch
        {
            chk = false;
        }
        return chk;
    }
    public bool check()
    {
        bool ch = false;
        ch = check_conn_state();
        if (ch)
            return true;
        else
            return false;

    }
}
