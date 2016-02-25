using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testtext : MonoBehaviour {

    public Text tex;
    public int Value;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y , transform.position.z));

        //Debug.Log("target is " + screenPos.x + " pixels from the left");

        tex.transform.position = new Vector3(screenPos.x,screenPos.y, screenPos.z + Value);
        
	}


    void OnBecameVisible()
    {
        Debug.Log("I CAN SEE");
    }
}
