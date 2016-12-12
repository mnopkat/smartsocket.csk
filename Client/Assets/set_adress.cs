using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class set_adress : MonoBehaviour
{
    public InputField new_url;

    public void new_adress()
    {
        string temp = new_url.text;
        if (temp != "" || temp != " ")
            _set_state(temp);
    }

    public  bool _set_state(string temp)
    {
        string data = temp;
        WebRequest req = HttpWebRequest.Create("http://relaxcs.by/andrewkharkov/ss/adress.php?adress_temp=" + data);
        Stream s = req.GetResponse().GetResponseStream();
        return true;
    }
}
