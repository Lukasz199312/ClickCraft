using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class BuildTime {

    public DateTime Date = DateTime.Now;

    public int Seconds;
    public int Minutes;
    public int Hours;
    public int Days;

    public bool active;

    public void Reload()
    {
        if(active == true)
        {
            Debug.Log(" Date BEFORE Time " + Date);
            Date = Date.AddYears(-1);
            Debug.Log(" Date Time " + Date);
        }
    }

    public void FirstInitialize()
    {
        Date = DateTime.Now;

        Date = Date.AddSeconds(Seconds);
        Date = Date.AddMinutes(Minutes);
        Date = Date.AddHours(Hours);
        Date = Date.AddDays(Days);
    }

}
