using UnityEngine;
using System.Collections;

public class StandardActionsGUI : BasicBuildActionsGUI
{

    public EmployeeAction EmployeeGUI;

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


    public override void InitializeExtends()
    {
        EmployeeGUI.gameObject.SetActive(true);
        EmployeeGUI.Initialize(_TouchedObject.GetComponent<Building>());
    }

    public override void DisableExtends()
    {
        EmployeeGUI.gameObject.SetActive(false);
    }
}
