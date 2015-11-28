﻿using UnityEngine;
using System.Collections;
using System;

public class GlobalTimer : Subject {

    public int RefreshTime;

    private StringData strData;
    private DateTime LastRefresh;
    private DateTime LastRun;

    void Awake()
    {
        strData = gameObject.GetComponent<StringData>();
        LastRefresh = new DateTime();
    }

	// Use this for initialization
	void Start () {
        if (strData.Value != "0") LastRun = DateTime.Parse(strData.Value);
        else LastRun = DateTime.Now;

        AdviseAll(new Initialize_Time_Behavior());
	}
	
	// Update is called once per frame
	void Update () {
        TimeUpdate();
	}

    private bool TimeUpdate()
    {
        strData.Value = DateTime.Now.ToString();

        if (LastRefresh.AddMilliseconds(RefreshTime).Ticks < DateTime.Now.Ticks)
        {
            LastRefresh = DateTime.Now;
            AdviseAll(new Time_Update_Behavior());
            return true;
        }
        else return false;
    }

    public DateTime getLastRun()
    {
        return LastRun;
    }

    public DateTime getTimeNow()
    {
        return DateTime.Now;
    }

    public TimeSpan getTimeSpan()
    {
        return new TimeSpan(getTimeNow().Ticks - getLastRun().Ticks);
    }
}
