using UnityEngine;
using System.Collections;

public class SceneView : MonoBehaviour {

    public SpriteRenderer ShadowSprite;
    public SpriteRenderer OryginalSprite;
    public Material material;

    private BasicView View = new BuildViewScene();
    private Building build;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fill()
    {
        material.SetFloat("_Length", View.FillSprite(build));
    }


    public void Initialize(BasicView _View, Building Build)
    {
        ShadowSprite.sprite = Build.gameObject.GetComponent<SpriteRenderer>().sprite;
        OryginalSprite.sprite = ShadowSprite.sprite;

        ShadowSprite.transform.localScale = new Vector3(Build.transform.localScale.x, Build.transform.localScale.y, Build.transform.localScale.z);
        OryginalSprite.transform.localScale = new Vector3(Build.transform.localScale.x, Build.transform.localScale.y, Build.transform.localScale.z);

        material = OryginalSprite.material;

        _View = View;
        build = Build;
    }
}
