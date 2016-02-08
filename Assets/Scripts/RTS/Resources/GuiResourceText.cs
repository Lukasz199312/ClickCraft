using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiResourceText : MonoBehaviour {

    public string ResourceName;
    public SimpleData Resource;
    public Text GUI_TEXT;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GUI_TEXT.text = ResourceName + Resource.Value;
	}
}
