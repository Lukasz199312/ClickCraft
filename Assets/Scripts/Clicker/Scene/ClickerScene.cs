using UnityEngine;
using System.Collections;

public abstract class ClickerScene : MonoBehaviour {

    public PoolingManager pManager;
    public BasicProfil Profil;

    public Resource[] _Resources;

    private float ScreenWidth;
    private float ScreenHeight;
    protected Building Build;

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
        Camera.main.GetComponent<ClickController>().Scene = this;

        Profil.Resources = new Resource[_Resources.Length];
        _Resources.CopyTo(Profil.Resources, 0);

        InitializeObjectPool(Profil.Resources[0].sprite);
    }

    public Vector3 GenerateNewPosition()
    {
        float x = Random.Range((int)(ScreenWidth * 0.15f), ScreenWidth - (int)(ScreenWidth * 0.15f));
        float y = Random.Range((int)(ScreenHeight * 0.15f), ScreenHeight - (int)(ScreenHeight * 0.20f));

        return new Vector3(x, y, this.transform.position.z + 50);
    }

    public abstract void ClickAction(int value);
    public abstract void ClickActionSpecial(int value, Sprite sprite);
    public abstract void ClickActionCric(int value, Sprite sprite);

    public abstract void InitializeObjectPool(Sprite sprite);

    public void SetBuild(Building Build)
    {
        this.Build = Build;
    }
}
