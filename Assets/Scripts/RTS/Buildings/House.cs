using UnityEngine;
using System.Collections;

public class House : Building {

    void Awake()
    {
        subject.Add(this);
        if (DefaultGrup.name != "House") return;
        HumanResource.add( ((HouseType)DefaultGrup).NumberPersonOnHuse );
    }
	
	// Update is called once per frame
	void Update () {

	}

}
