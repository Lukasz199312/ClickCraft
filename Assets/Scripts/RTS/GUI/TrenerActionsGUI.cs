using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrenerActionsGUI : BasicBuildActionsGUI
{

    public Text Capacity;
    public Text Workers;
    public Text BuildName;
    public Building Build;

    public EmployeeAction EmployeeGUI;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Workers.text = "Workers: " + Build.Employees.getCount() + " / " + Build.Employees.getMaxSize();
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
        Build = _TouchedObject.GetComponent<Building>();
        BuildName.text = Build.BuildName;
    }

    public override void DisableExtends()
    {
        EmployeeGUI.gameObject.SetActive(false);
    }

    public void Collect()
    {
        Build.ResourceProduction.add((int)Build.Build_Statistic.Capacity);
        Build.Build_Statistic.Capacity = 0;
    }
}
