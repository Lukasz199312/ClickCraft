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
        InitializeObjectPool();
    }

    public Vector3 GenerateNewPosition()
    {
        float x = Random.Range((int)(ScreenWidth * 0.15f), ScreenWidth - (int)(ScreenWidth * 0.15f));
        float y = Random.Range((int)(ScreenHeight * 0.15f), ScreenHeight - (int)(ScreenHeight * 0.20f));

        return new Vector3(x, y, this.transform.position.z + 50);
    }

    public abstract void ClickAction();
    public abstract void InitializeObjectPool();
}
