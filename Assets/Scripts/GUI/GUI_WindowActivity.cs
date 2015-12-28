using UnityEngine;
using System.Collections;

public class GUI_WindowActivity : MonoBehaviour {

    public GameObject Window;
    public GameObject Panel_Rewiew;
    public GameObject Cat_Buttons;
    public ItemShopSlot SelectecSlot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setActivity(bool Activity)
    {
        Window.SetActive(!Activity);
        Panel_Rewiew.SetActive(Activity);
        Cat_Buttons.SetActive(Activity);
    }

    public void setSlot(ItemShopSlot slot)
    {
        SelectecSlot = slot;
        GuiBuyBuilding BuyGUI = Window.GetComponent<GuiBuyBuilding>();
        BuyGUI.Title.text = slot.text.text;
        BuyGUI.BuildingImage = slot.Slot_Image;
        BuyGUI.ShopGameItem = slot.ShopItem;
    }
}
