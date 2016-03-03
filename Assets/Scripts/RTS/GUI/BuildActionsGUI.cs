using UnityEngine;
using System.Collections;

public class BuildActionsGUI : BasicBuildActionsGUI {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void InitializeDisplace()
    {
        Displace.Initialize(_TouchedObject.gameObject);
    }

    public override void InitializePreview()
    {
        
    }

    public override void InitializeTranfer()
    {
        Transfer.Initialize(_TouchedObject.Placing, _TouchedObject.Builder);
    }

    public override void InitializeUpgrades()
    {
       
    }

    public override void InitializeProfiler()
    {
        Profiler.Initialize(_TouchedObject.GetComponent<Building>());
    }
}
