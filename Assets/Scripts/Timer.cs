using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 99;
    public Text timeText;


    //[Header("Component")]
    //public TextMeshProUGUI timerText;
    //
    //[Header("Timer Settings")]
    //public float currentTime;
    //public bool countDown;
    //
    //[Header("Limit Settings")]
    //public bool hasLimit;
    //public float timerLimit;
    //
    //[Header("Format Settings")]
    //public bool hasFormat;
    //public TimerFormats format;
    //private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();
    
    // Start is called before the first frame update
    void Start()
    {
        //timeFormats.Add(TimerFormats.Whole, "0");
        //timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        //timeFormats.Add(TimerFormats.HundrethDecimal, "0.00");
    }

    // Update is called once per frame

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);


        //currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        //
        //if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))) 
        //{
        //    currentTime = timerLimit;
        //    SetTimerText();
        //    timerText.color = Color.red;
        //    enabled = false;
        //}
        //
        //SetTimerText();
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //private void SetTimerText()
    //{
    //    timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString(); 
    //}
}

//public enum TimerFormats
//{
//    Whole,
//    TenthDecimal,
//    HundrethDecimal
//}