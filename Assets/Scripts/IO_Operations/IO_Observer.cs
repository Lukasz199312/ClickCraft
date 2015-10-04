using UnityEngine;
using System.Collections;

public class IO_Observer : MonoBehaviour, I_Observer {

    public IO_Operations IO;

    private I_Observer_Behavior Behavior;

    void Awake() {

    }

	// Use this for initialization
	void Start () {
        IO.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    I_Observer_Behavior I_Observer.ChangeBehavior(I_Subject subject, I_Observer_Behavior Behavior)
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
