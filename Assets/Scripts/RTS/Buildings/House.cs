using UnityEngine;
using System.Collections;

public class House : Building {

    void Awake()
    {
        subject.Add(this);
        if (DefaultGrup.name != "House") return;
       
    }
	
	// Update is called once per frame
	void Update () {

	}

    public override void DefaultInitialize()
    {
        HumanResource.add(((HouseType)DefaultGrup).NumberPersonOnHuse);
        ((HouseType)DefaultGrup).UpdateWokrerOnHouse();
    }

    public override void OnDelete()
    {
        HumanResource.sub(((HouseType)DefaultGrup).NumberPersonOnHuse);
        HumanResource.setMax(((HouseType)DefaultGrup).Builds.Count * ((HouseType)DefaultGrup).NumberPersonOnHuse);
    }
}
