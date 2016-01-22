using UnityEngine;
using System.Collections;

public class TouchedObject : MonoBehaviour {

    public BuildActionsGUI BuildingActionGUI;
    public UpgradeSystem Upgrades;
    public BuilderManager Builder;
    public PlacingToGrid Placing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowGUI()
    {
        BuildingActionGUI.gameObject.SetActive(true);
        BuildingActionGUI.setTouchedObject(this);
        BuildingActionGUI.ReloadData();
        BuildingActionGUI.HideShopMenu();
    }

    public void HideGUI()
    {
        BuildingActionGUI.gameObject.SetActive(false);
    }
}
