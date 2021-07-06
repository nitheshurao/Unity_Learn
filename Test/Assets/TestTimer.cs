using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTimer : MonoBehaviour
{
    [SerializeField] Text timer;

    public void StartTimer()
    {
        StartCoroutine(Itimer(25));
    }
    IEnumerator Itimer(float seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        TimeSpan timerTime = new TimeSpan(0, 0, seconds);
        while(timerTime.TotalSeconds> 0)
        {
           
            timer.text = (seconds - Time.deltaTime);
            yield return new WaitForSeconds(1);
            timerTime.Subtract(new TimeSpan(0,0,Time.deltaTime))
        }
        timer.text = "Timer Ended";
    }
}
