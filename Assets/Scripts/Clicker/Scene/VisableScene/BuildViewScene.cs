using UnityEngine;
using System.Collections;

public class BuildViewScene : BasicView {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float FillSprite(Building build)
    {
        //Debug.Log("Oryginal: " + (float)(build.InConstruction.Oryginalspan.TotalSeconds));
        //Debug.Log("Sub: " + build.InConstruction.getTotalSecondSub());
        //Debug.Log("TIME: " + (float)(build.InConstruction.getTotalSecondSub() / build.InConstruction.Oryginalspan.TotalSeconds));
        return (float)(build.InConstruction.getTotalSecondSub() / build.InConstruction.Oryginalspan.TotalSeconds);
    }
}
