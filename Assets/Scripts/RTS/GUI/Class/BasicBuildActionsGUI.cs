using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class BasicBuildActionsGUI : MonoBehaviour {

    public DisplaceGUI_Action Displace;
    public PreviewGUI_Action Preview;
    public TransferGUI_Action Transfer;
    public UpgradesGUI_Action Upgrades;
    public ProfilerGUI_Action Profiler;
    public GameObject ShopMenu;
    public GameObject CategoryMenu;
    public Button button;

    protected TouchedObject _TouchedObject;
    public TouchController Controller;

    public abstract void InitializeDisplace();
    public abstract void InitializePreview();
    public abstract void InitializeTranfer();
    public abstract void InitializeUpgrades();
    public abstract void InitializeProfiler();

    public void setTouchedObject(TouchedObject TObject)
    {
        _TouchedObject = TObject;
    }

    public void ReloadData()
    {
        InitializeDisplace();
        InitializePreview();
        InitializeTranfer();
        InitializeUpgrades();
        InitializeProfiler();

    }

    public void HideShopMenu()
    {
        ShopMenu.SetActive(false);
        CategoryMenu.SetActive(false);
    }

    void OnDisable()
    {
        this.Controller.DisableDoubleTouch = false;
    }


}
