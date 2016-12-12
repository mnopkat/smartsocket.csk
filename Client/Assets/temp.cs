using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour {
    get_adress get_adress_obj = new get_adress();
    public string temp_url = "relaxcs.by/andrewkharkov/ss";
    public string curr_url;
    void Start()
    {
        curr_url = get_adress_obj.get_adress_temp();
    }
}
