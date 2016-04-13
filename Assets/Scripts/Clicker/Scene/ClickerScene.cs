using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class ClickerScene : MonoBehaviour {

    public PoolingManager pManager;
    public BasicProfil Profil;
    public Resource[] _Resources;
    public Resource[] _SpecialResources = null;
    public Button button;
    public SceneView View;

    protected float ScreenWidth;
    protected float ScreenHeight;
    protected Building Build;
    protected Vector3 OldPosition;
    protected BasicView basicView = new BuildViewScene();
    protected float SaveCameraSize;

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
        InitializeSceneView(basicView);
        gameObject.SetActive(true);

        OldPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        Camera.main.GetComponent<ClickController>().Scene = this;
        Camera.main.GetComponent<ClickController>().Initialize(getSceneGenerate());

        SaveCameraSize = Camera.main.orthographicSize;
        Camera.main.orthographicSize = 5f;

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
        ((ShowGuiTouchAction)Build.GetComponent<TouchedObject>().Action).HideGUI();
        Camera.main.orthographicSize = SaveCameraSize;
    }

    public Vector3 GenerateNewPosition()
    {
        float x = Random.Range((int)(ScreenWidth * 0.15f), ScreenWidth - (int)(ScreenWidth * 0.15f));
        float y = Random.Range((int)(ScreenHeight * 0.15f), ScreenHeight - (int)(ScreenHeight * 0.20f));

        return new Vector3(x, y, this.transform.position.z + 50);
    }

    public void InitializeSceneView(BasicView _BasicView)
    {
        if (_BasicView != null && View != null) 
          View.Initialize(_BasicView, Build);
    }

    public abstract void ClickAction(int value , I_Resource res);
    public abstract void ClickActionSpecial(int value, Sprite sprite, I_Resource res);
    public abstract void ClickActionCric(int value, Sprite sprite, I_Resource res);

    public abstract void InitializeObjectPool(Sprite sprite);

    public virtual void InitializeResource()
    {
        Profil.Resources = new Resource[_Resources.Length];
        _Resources.CopyTo(Profil.Resources, 0);

        if(_SpecialResources != null)
        {
            if (Profil.SpecialResources != null) return;
            Profil.SpecialResources = new I_Resource[_SpecialResources.Length];
            _SpecialResources.CopyTo(Profil.SpecialResources, 0);
        }
    }

    public virtual void ClickAction_NoPoolingAction(int value, I_Resource res)
    {
        res.add(value);
    }

    public void SetBuild(Building Build)
    {
        this.Build = Build;
    }

    public virtual I_SceneRandGenerator getSceneGenerate()
    {
        return new DefaultGenerateRand();
    }

}
