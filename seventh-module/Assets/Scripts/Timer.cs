using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool Reset = false;
    public TMP_Text timer;
    private float start_timer;


    // Start is called before the first frame update
    void Start()
    {
        start_timer = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - start_timer;
        string minutes = ((int) t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");

        timer.text = minutes + ":" + seconds;
        if(Reset){
            start_timer = t;
            minutes = seconds = "00";
            timer.text = minutes + ":" + seconds;
            Reset = false;
        }
    }
}
