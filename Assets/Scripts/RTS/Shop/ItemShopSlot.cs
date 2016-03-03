using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemShopSlot : MonoBehaviour {

    public Image Slot_Image;
    public Text text;
    public ItemShop ShopItem;
    public Button button;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void LockItem()
    {
        button.interactable = false;
    }

    public void UnlockItem()
    {
        button.interactable = true;
    }
}
