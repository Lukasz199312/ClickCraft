using UnityEngine;
using System.Collections;
using System;

public class GlobalTimer : Subject {

    private StringData strData;

    void Awake()
    {
        strData = gameObject.GetComponent<StringData>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        strData.Value = DateTime.Now.ToString();
	}


}
