using UnityEngine;
using System.Collections;

/// <summary>
/// Super Observer class
/// </summary>
public class Observe : MonoBehaviour, I_Observer {

    public Subject subject;

    protected I_Observer_Behavior Behavior;

	// Use this for initialization
	void Awake () {
        subject.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// This Function Change Behaviory (Change Functionality)
    /// </summary>
    /// <param name="subject">following class</param>
    /// <param name="Behavior">Function used when subject notify all Observe. Implement I_Observer Interface.</param>
    /// <returns>newly set behavior</returns>
    public I_Observer_Behavior ChangeBehavior(I_Subject subject, I_Observer_Behavior Behavior)
    {
        subject = (IO_Operations)subject;
        this.Behavior = Behavior;

        return this.Behavior;
    }

    public GameObject gameobject()
    {
        return gameObject;
    }
}
