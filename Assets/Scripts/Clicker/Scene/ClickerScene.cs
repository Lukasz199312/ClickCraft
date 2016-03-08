using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class ClickerScene : MonoBehaviour {

    public PoolingManager pManager;
    public BasicProfil Profil;
    public Resource[] _Resources;
    public Button button;

    private float ScreenWidth;
    private float ScreenHeight;

    protected Building Build;
    protected Vector3 OldPosition;

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
        gameObject.SetActive(true);

        OldPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        Camera.main.GetComponent<ClickController>().Scene = this;

        InitializeResource();

        InitializeObjectPool(Profil.Resources[0].getSprite());

        button.gameObject.SetActive(true);
        button.onClick.AddListener(() => BackToMap());
    }

    public virtual void BackToMap()
    {
        Camera.main.transform.position = new Vector3(OldPosition.x, OldPosition.y, OldPosition.z);
        button.gameObject.SetActive(false);
        button.onClick.RemoveAllListeners();

        gameObject.SetActive(false);
        Build.GetComponent<TouchedObject>().HideGUI();
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

    public virtual void InitializeResource()
    {
        Profil.Resources = new Resource[_Resources.Length];
        _Resources.CopyTo(Profil.Resources, 0);
    }

    public void SetBuild(Building Build)
    {
        this.Build = Build;
    }

}
