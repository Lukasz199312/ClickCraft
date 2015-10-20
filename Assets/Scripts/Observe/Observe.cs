using UnityEngine;
using System.Collections;

public class Observe : MonoBehaviour, I_Observer {

    public Subject IO;

    private I_Observer_Behavior Behavior;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public I_Observer_Behavior ChangeBehavior(I_Subject subject, I_Observer_Behavior Behavior)
    {
        IO = (IO_Operations)subject;
        this.Behavior = Behavior;

        return this.Behavior;
    }

    public GameObject gameobject()
    {
        return gameObject;
    }
}
