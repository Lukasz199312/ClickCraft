using UnityEngine;
using System.Collections;

public class Tree : Building
{
    void Awake()
    {
        subject.Add(this);
        if (DefaultGrup.name != "Tree") return;
    }
	
	// Update is called once per frame
	void Update () {

	}

}
