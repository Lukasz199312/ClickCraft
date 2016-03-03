using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ItemShopReview : MonoBehaviour {

    public ItemShopList DefaultShopList;
    public List<ItemShopSlot> ItemShopSlot;

    private int PageCount;
    private int PageIndex = 1;
    private int SlotsCount = 3;

    private List<ItemShop> StuffList;

	// Use this for initialization
	void Start () {

        setPageCount(DefaultShopList);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PreviousPage()
    {
        if (PageIndex - 1 < 1) return;
        PageIndex--;
        LoadPage();
    }

    public void NextPage()
    {
        if (PageIndex + 1 > PageCount) return;
        PageIndex++;
        LoadPage();
    }

    public void LoadPage()
    {
        int ItemIndex = (PageIndex - 1) * SlotsCount;

        for (int i = 0; i < SlotsCount; i++)
        {
            if (StuffList.Count <= ItemIndex + i)
            {
                for (; i < SlotsCount; i++)
                    ItemShopSlot[i].gameObject.SetActive(false);
                    break;
            }


            ItemShopSlot[i].gameObject.SetActive(true);
            ItemShopSlot[i].text.text = StuffList[ItemIndex + i].name;
           
            ItemShopSlot[i].Slot_Image.sprite = StuffList[ItemIndex + i].Sprite.sprite;
            ItemShopSlot[i].ShopItem = StuffList[ItemIndex + i];

            if (StuffList[ItemIndex + i].DefaultGroup.isLimitStatusAvalible() == false) ItemShopSlot[i].LockItem();
            else ItemShopSlot[i].UnlockItem();
        }
    }

    public void SetStuffList(ItemShopList ItemList)
    {
        this.StuffList = ItemList.ItemList;
        setPageCount(ItemList);
        PageIndex = 1;
        LoadPage();
    }

    private void setPageCount(ItemShopList ItemList)
    {
        StuffList = ItemList.ItemList;
        PageCount = StuffList.Count / SlotsCount;

        if (StuffList.Count % SlotsCount != 0) PageCount++;
    }
}
