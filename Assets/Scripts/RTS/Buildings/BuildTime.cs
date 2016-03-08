using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class BuildTime : I_Resource {

    public DateTime Date = DateTime.Now;
    public TimeSpan span;

    public int Seconds;
    public int Minutes;
    public int Hours;
    public int Days;
    public float DropChance = 1;

    public bool active;

    private Sprite sprite;

    public void Reload()
    {
        if(active == true)
        {
            Debug.Log(" |||||||||||||||||||| Date BEFORE Time " + Date);
            Date = Date.AddYears(-1);
            Debug.Log(" Date Time " + Date);
        }
    }

    public void FirstInitialize()
    {
        Date = DateTime.Now;
        DateTime Date2 = DateTime.Now; ;

        Debug.Log("Seconds: " + Seconds);
        Debug.Log("Minutes: " + Minutes);
        Debug.Log("Hours: " + Hours);

        Date2 = Date2.AddSeconds(Seconds);
        Date2 = Date2.AddMinutes(Minutes);
        Date2 = Date2.AddHours(Hours);
        Date2 = Date2.AddDays(Days);

        span = Date2 - Date;

        Debug.Log("DAte1: " + Date);
        Debug.Log("DAte2: " + Date2);
        Debug.Log("span: " + span);
    }

    public void addMilliseconds(double mili)
    {
        //Debug.Log("Mili: " + mili);
       // Debug.Log("Before: " + Date);
        //Date = Date.AddMilliseconds(mili);
        span = span.Add(new TimeSpan(0,0,0,0, (int)mili ));
       // Debug.Log("After: " + Date);
    }

    public void SubtractMilliseconds(double mili)
    {
        //Debug.Log("Mili: " + mili);
        // Debug.Log("Before: " + Date);
        //Date = Date.AddMilliseconds(mili);
        span = span.Subtract(new TimeSpan(0, 0, 0, 0, (int)mili));
        // Debug.Log("After: " + Date);
    }

    public void SubtractSeconds(double sec)
    {
        //Debug.Log("Mili: " + mili);
        // Debug.Log("Before: " + Date);
        //Date = Date.AddMilliseconds(mili);
        span = span.Subtract(new TimeSpan(0, 0, 0, (int)sec, 0));
        // Debug.Log("After: " + Date);
    }

    public void add(int value)
    {
        SubtractSeconds(value);
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return sprite;
    }


    public float getDropChance()
    {
        return DropChance;
    }
    public int get()
    {
        throw new NotImplementedException();
    }
}
