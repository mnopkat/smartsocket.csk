using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net;
using System.Threading;

public class loading : MonoBehaviour
{
    conn_state conn_state_object = new conn_state();
    public Text main_text;
    public Button settings_button;
    public Button try_connect_button;
    
    void Start()
    {
        try_connect();
    }

    void Update()
    {
        try_connect();
        Thread.Sleep(240);
    } 

    public void try_connect()
    {
        if (conn_state_object.check() == true)
        {
            SceneManager.LoadScene("smartsocket");
        }
        else
        {
            main_text.text = "Ошибка соединения...";
        }
    }

    public void settigs_button_click()
    {
        SceneManager.LoadScene("settings");
    }
}