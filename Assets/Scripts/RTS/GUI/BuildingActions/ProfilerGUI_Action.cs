using UnityEngine;
using System.Collections;

public class ProfilerGUI_Action : MonoBehaviour {

    public BuildScene Scene;
    private Building Build;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(Building build)
    {
        Build = build;
    }

    public void ActionClick()
    {
        Scene.SetBuild(Build);
        Scene.goToScene();
    }

}
