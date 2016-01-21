﻿using UnityEngine;
using System.Collections;

public class SetActivityShopElement : MonoBehaviour {

    public GameObject Category_buttons;
    public GameObject PanelReview;
    public GameObject SwordButton;
    public GridManager Grid;

	// Use this for initialization
	void Start () {
	
	}
	
    public void ChangeActiveStatus()
    {
        Category_buttons.SetActive(!Category_buttons.activeSelf);
        PanelReview.SetActive(!PanelReview.activeSelf);
        SwordButton.SetActive(!PanelReview.activeSelf);
        Grid.gameObject.SetActive(!Grid.gameObject.activeSelf);
    }
}
