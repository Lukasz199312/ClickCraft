using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoActionsGUI : BasicBuildActionsGUI
{
    public Text Capacity;
    public Building Build;

    public EmployeeAction EmployeeGUI;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Capacity.text = "Capacity: " + ((I_ResourceBuildFunction)Build).getCapacity().get() + " / " 
                                     + ((I_ResourceBuildFunction)Build).getCapacity().getMax();
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

    }


    public override void InitializeExtends()
    {
        Build = _TouchedObject.GetComponent<Building>();
    }

    public override void DisableExtends()
    {

    }

}
