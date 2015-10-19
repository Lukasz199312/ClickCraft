using UnityEngine;
using System.Collections;

public class IO_Observer : MonoBehaviour, I_Observer {

    public IO_Operations IO;

    private I_Observer_Behavior Behavior;

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
