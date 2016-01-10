﻿using UnityEngine;
using System.Collections;

public class SetActivityShopElement : MonoBehaviour {

    public GameObject Category_buttons;
    public GameObject PanelReview;
    public GameObject SwordButton;

	// Use this for initialization
	void Start () {
	
	}
	
    public void ChangeActiveStatus()
    {
        Category_buttons.SetActive(!Category_buttons.activeSelf);
        PanelReview.SetActive(!PanelReview.activeSelf);
        SwordButton.SetActive(!PanelReview.activeSelf);
    }
}
