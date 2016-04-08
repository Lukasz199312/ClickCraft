using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiBuyBuilding : MonoBehaviour {

    public Text Description;
    public Text Title;
    public Text ErrorText;
    public ItemShop ShopGameItem;
    public BuilderManager Builder;
    public Button BuyButton;


    public Color32 NormarResourceColor;
    public Color32 ErrorResourceColor;

    public Image BuildingImage;
    public Text Cost;

    public Resource Gold;
    public Resource Wood;
    public Resource Stone;
    public Resource ObsydianBrick;

    public Text GoldText;
    public Text WoodText;
    public Text StoneText;
    public Text ObsydianText;
    public Text RecipeText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Build()
    {
        Builder.Build(ShopGameItem, this);
    }

    public void Finalize()
    {
        Gold.subtract(ShopGameItem.Gold);
        Wood.subtract(ShopGameItem.Wood);
        Stone.subtract(ShopGameItem.Stone);
        ObsydianBrick.subtract(ShopGameItem.ObsydianBrick);

        ShopGameItem.Recipe.simpladata.Value -= ShopGameItem.Recipe.Cost;
    }

    public void setColor(Text ResourceText, Color32 color)
    {
        ResourceText.color = color;
    }
}
