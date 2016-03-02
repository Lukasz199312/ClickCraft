using UnityEngine;
using System.Collections;

public class TouchedObject : MonoBehaviour {

    public BuildActionsGUI BuildingActionGUI;
    public BuildActionsGUI ActionGUIConstruction;
    //public UpgradeSystem Upgrades;
    public BuilderManager Builder;
    public PlacingToGrid Placing;
    private BuildActionsGUI Default;

	// Use this for initialization
	void Start () {
        Default = BuildingActionGUI;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowGUI()
    {
        if (GetComponent<Building>().InConstruction.active == true) setContructionGUI();
        else setNormalActionGui();

        Default.gameObject.SetActive(true);
        Default.setTouchedObject(this);
        Default.ReloadData();
        Default.HideShopMenu();
    }

    public void HideGUI()
    {
        Default.gameObject.SetActive(false);
    }

    public void setContructionGUI()
    {
        Default = ActionGUIConstruction;
    }

    public void setNormalActionGui()
    {
        Default = BuildingActionGUI;
    }
}
