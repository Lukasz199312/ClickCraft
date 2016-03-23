using UnityEngine;
using System.Collections;

public class TouchedObject : MonoBehaviour {

    public BasicBuildActionsGUI BuildingActionGUI;
    public BasicBuildActionsGUI ActionGUIConstruction;
    //public UpgradeSystem Upgrades;
    public BuilderManager Builder;
    public PlacingToGrid Placing;
    private BasicBuildActionsGUI Default;
    public I_TouchaActions Action;

	// Use this for initialization
	void Start () {
        InitializeAsMenu();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void TouchAction()
    {
        Action.DoAction();
    }

    public void InitializeAsMenu()
    {
        Action = new ShowGuiTouchAction(Default, GetComponent<Building>(), this, BuildingActionGUI, ActionGUIConstruction);
    }

    public void InitializeAsCollectItem()
    {
        Action = new CollectProduceItem(GetComponent<Building>());
    }

}
