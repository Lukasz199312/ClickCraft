using UnityEngine;
using System.Collections;

public class DisabledObjectOnStart : MonoBehaviour {

    public GameObject ToDisable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        ToDisable.SetActive(false);

        Destroy(this);
    }
}
