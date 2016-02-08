﻿using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        foreach(Touch touch in Input.touches)
        {
            PhaseAction(touch);
        }
	}


    private void PhaseAction(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {

        }
    }
}
