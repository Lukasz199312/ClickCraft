using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmployeeGUI : MonoBehaviour {

    public Button Add;
    public Button Remove;
    public Text EmployeeSize;

    private GameObject objectgame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(GameObject gm)
    {
        objectgame = gm;
        Building Build = gm.GetComponent<Building>();

        RefreshText(Build);
    }

    public void RefreshText(Building Build)
    {
        EmployeeSize.text = Build.Employees.getCount().ToString() + " / " + Build.Employees.getMaxSize().ToString();
    }
}
