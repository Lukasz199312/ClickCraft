using UnityEngine;
using System.Collections;

public class BuilderManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Build(ItemShop item)
    {
        Debug.Log("BUILDER: " + item.DefaultGroup.name);

        Vector3 Position = Camera.main.ScreenToWorldPoint( new Vector3(Camera.main.transform.position.x + Screen.width / 2 ,
                                       Camera.main.transform.position.y + Screen.height / 2,
                                       0));
        Position.z = 0;

        item.DefaultGroup.AddBuild(Position);
    }
}
