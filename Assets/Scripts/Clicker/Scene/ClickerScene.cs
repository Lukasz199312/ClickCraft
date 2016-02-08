using UnityEngine;
using System.Collections;

public abstract class ClickerScene : MonoBehaviour {

    public PoolingManager pManager;

    private float ScreenWidth;
    private float ScreenHeight;

	// Use this for initialization
	void Start () {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToScene()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    public abstract void ClickAction();
}
