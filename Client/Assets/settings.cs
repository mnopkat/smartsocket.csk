using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour {
    public Text current_adress_tx;
    public Text default_adress_tx;
    temp default_adress_tx_obj = new temp();
    set_adress set_adress_obj = new set_adress();

    void Start()
    {
        default_adress_tx.text = default_adress_tx_obj.temp_url;
    }

    public void go_back_loading()
    {
        SceneManager.LoadScene("loading");
    }
    
    public void defaut_settings()
    {
        string temp = default_adress_tx_obj.temp_url;
        set_adress_obj._set_state(temp);
    }
}
