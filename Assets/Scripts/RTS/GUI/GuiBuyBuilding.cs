using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiBuyBuilding : MonoBehaviour {

    public Text Description;
    public Text Title;
    public ItemShop ShopGameItem;
    public BuilderManager Builder;

    public Image BuildingImage;
    public Text Cost;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Build()
    {
        Builder.Build(ShopGameItem);
    }
}
