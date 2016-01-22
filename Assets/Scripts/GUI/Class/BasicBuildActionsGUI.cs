using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class BasicBuildActionsGUI : MonoBehaviour {

    public DisplaceGUI_Action Displace;
    public PreviewGUI_Action Preview;
    public TransferGUI_Action Transfer;
    public UpgradesGUI_Action Upgrades;
    public GameObject ShopMenu;
    public GameObject CategoryMenu;
    public Button button;

    protected TouchedObject _TouchedObject;

    public abstract void InitializeDisplace();
    public abstract void InitializePreview();
    public abstract void InitializeTranfer();
    public abstract void InitializeUpgrades();

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
    }

    public void HideShopMenu()
    {
        ShopMenu.SetActive(false);
        CategoryMenu.SetActive(false);
    }


}
