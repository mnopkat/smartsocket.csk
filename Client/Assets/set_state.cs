using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class set_state : MonoBehaviour {
    public Text state;

    void Start()
    {
        
    }
    public void status_on() {
        _set_state(true);
    }

    public void status_off()
    {
        _set_state(false);
    }

    public static bool _set_state(bool temp)
    {
        get_adress temp_obj = new get_adress();
        string data = "";
        if (temp == true)
            data = "true";
        else
            data = "false";
        string temp1 = temp_obj.get_adress_temp();
        WebRequest req = HttpWebRequest.Create("http://" + temp1 + "/state.php?state_temp=" + data);
        Stream s = req.GetResponse().GetResponseStream();
        return true;
    }

}
