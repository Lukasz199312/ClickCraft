using UnityEngine;
using System.Collections;

public class BuildActionsGUI : BasicBuildActionsGUI {

    private TouchedObject _TouchedObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void InitializeDisplace()
    {
       
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


}
