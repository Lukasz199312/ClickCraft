using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour {

    public Text TimetText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTime(TimeSpan date)
    {
        TimetText.text = TimerFormat.getFullTime(date);
    }
}
