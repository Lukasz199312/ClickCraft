using UnityEngine;
using System.Collections;

public class Mine : Building {

    void Awake()
    {
        subject.Add(this);
        if (DefaultGrup.name != "Mine") return;

       
    }
	

}
