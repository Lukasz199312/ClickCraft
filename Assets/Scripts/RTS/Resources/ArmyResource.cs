using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArmyResource : Resource
{
    public Text DisplaceText;

	// Use this for initialization
	void Start () {
        UpdateArmyStatus();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateArmyStatus()
    {
        DisplaceText.text = Value.Value.ToString();
    }
}
