using UnityEngine;
using UnityEngine.UI;
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
        BuyGUI.BuildingImage.sprite = slot.Slot_Image.sprite;
        BuyGUI.ShopGameItem = slot.ShopItem;
        BuyGUI.Description.text = slot.ShopItem.GetComponent<Text>().text;

        if (DoAfford(slot, BuyGUI) == true) UnLock(BuyGUI);
        else Lock(BuyGUI);
   
    }

    public bool DoAfford(ItemShopSlot slot , GuiBuyBuilding BuyGui)
    {
        bool ErrorFlag = false;
        
        ItemShop item = slot.ShopItem;
        setPrice(item, BuyGui);

        if (BuyGui.Wood.get() < item.Wood)
        {
            ErrorFlag = true;
            BuyGui.setColor(BuyGui.WoodText, BuyGui.ErrorResourceColor);
        }
        else BuyGui.setColor(BuyGui.WoodText, BuyGui.NormarResourceColor);




        if (BuyGui.Stone.get() < item.Stone)
        {
            ErrorFlag = true;
            BuyGui.setColor(BuyGui.StoneText, BuyGui.ErrorResourceColor);
        }
        else BuyGui.setColor(BuyGui.StoneText, BuyGui.NormarResourceColor);

        if (BuyGui.ObsydianBrick.get() < item.ObsydianBrick)
        {
            ErrorFlag = true;
            BuyGui.setColor(BuyGui.ObsydianText, BuyGui.ErrorResourceColor);
        }
        else BuyGui.setColor(BuyGui.ObsydianText, BuyGui.NormarResourceColor);

        if (item.Recipe.CheckAfford() == false)
        {
            ErrorFlag = true;
            BuyGui.setColor(BuyGui.RecipeText, BuyGui.ErrorResourceColor);
        }
        else BuyGui.setColor(BuyGui.RecipeText, BuyGui.NormarResourceColor);

        if (ErrorFlag == true) return false;
        else return true;
       
    }

    public void Lock(GuiBuyBuilding BuyGui)
    {
        BuyGui.BuyButton.interactable = false;
        BuyGui.ErrorText.enabled = true;
    }

    public void UnLock(GuiBuyBuilding BuyGui)
    {
        BuyGui.BuyButton.interactable = true;
        BuyGui.ErrorText.enabled = false;
    }

    public void setPrice(ItemShop item, GuiBuyBuilding BuyGui)
    {
        BuyGui.GoldText.text = BuyGui.Gold.get() + " / " + item.Gold;
        BuyGui.WoodText.text = BuyGui.Wood.get() + " / " + item.Wood;
        BuyGui.StoneText.text = BuyGui.Stone.get() + " / " + item.Stone;
        BuyGui.ObsydianText.text = BuyGui.ObsydianBrick.get() + " / " + item.ObsydianBrick;
        BuyGui.RecipeText.text = (int)item.Recipe.simpladata.Value + " / " + item.Recipe.Cost;
    }
}
