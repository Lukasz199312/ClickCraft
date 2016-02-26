using UnityEngine;
using System.Collections;
using System;

public static class TimerFormat  {

    public static String getFullTime(TimeSpan date)
    {
        String text = "";

        if (date.Hours.ToString().Length > 1) text += date.Hours + ":";
        else text += "0" + date.Hours + ":";

        if (date.Minutes.ToString().Length > 1) text += date.Minutes + ":";
        else text += "0" + date.Minutes + ":";

        if (date.Seconds.ToString().Length > 1) text += date.Seconds;
        else text += "0" + date.Seconds;

        return text;
    }
}
