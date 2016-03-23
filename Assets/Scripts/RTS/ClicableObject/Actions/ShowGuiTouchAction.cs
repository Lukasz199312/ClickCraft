using System;
using System.Collections.Generic;

class ShowGuiTouchAction : I_TouchaActions
{
    private BasicBuildActionsGUI BuildingActionGUI;
    private BasicBuildActionsGUI ActionGUIConstruction;
    private BasicBuildActionsGUI Default;
    private Building Build;
    private TouchedObject tb;

    public ShowGuiTouchAction(BasicBuildActionsGUI Default, Building Build,TouchedObject tb, 
                                                            BasicBuildActionsGUI BuildingActionGUI,
                                                            BasicBuildActionsGUI ActionGUIConstruction)
    {
        this.Default = Default;
        this.tb = tb;
        this.Build = Build;

        this.BuildingActionGUI = BuildingActionGUI;
        this.ActionGUIConstruction = ActionGUIConstruction;
    }

    public void DoAction()
    {
        if (Build.InConstruction.active == true) setContructionGUI();
        else setNormalActionGui();

        Default.gameObject.SetActive(true);
        Default.setTouchedObject(tb);

        Default.ReloadData();
        Default.HideShopMenu();
    }

    public void setContructionGUI()
    {
        Default = ActionGUIConstruction;
    }

    public void setNormalActionGui()
    {
        Default = BuildingActionGUI;
    }

    public void HideGUI()
    {
        Default.gameObject.SetActive(false);
    }
}

