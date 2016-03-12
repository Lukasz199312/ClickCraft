using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmployeeAction : MonoBehaviour {

    public Button Add;
    public Button Remove;
    public Text EmployeeStack;

    private Building build;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(Building build)
    {
        this.build = build;
        RefresEmployeeStatus();
    }

    public void AddEmployee()
      {
        build.Employees.add(build.Employees);
        RefresEmployeeStatus();
    }

    public void RemoveEmployee()
    {
        if (build.Employees.isStandard == true) build.Employees.Remove();
        else build.Employees.BackToOwner();

        RefresEmployeeStatus();
    }

    private void RefresEmployeeStatus()
    {
        EmployeeStack.text = build.Employees.getCount().ToString() + " / " + build.Employees.getMaxSize().ToString();
    }
    
}
