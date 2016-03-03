using UnityEngine;
using System.Collections;

public class House : Building {

    public Resource Humans;

    void Awake()
    {
        subject.Add(this);
        if (DefaultGrup.name != "House") return;
        Humans.add( ((HouseType)DefaultGrup).NumberPersonOnHuse );
    }
	
	// Update is called once per frame
	void Update () {

	}

}
