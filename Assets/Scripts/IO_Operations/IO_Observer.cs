using UnityEngine;
using System.Collections;

public class IO_Observer : Observe {

    void Awake() {
        IO.Add(this);

        IO_Format format = gameobject().GetComponent<IO_Format>();
        ChangeBehavior(IO, new IO_LoadBehavior()).update(format);
    }

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
