using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveItemCollect : MonoBehaviour {

    private RawImage Image;
    private RectTransform rect;

	// Use this for initialization
	void Start () {
       // Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize()
    {
        GameObject ob = GameObject.Find("COLLECT_PLACE");
        if (ob != null)
        {
            RawImage rawimage = ob.transform.GetChild(0).GetComponent<RawImage>();
            rawimage.gameObject.SetActive(true);

            Image = Instantiate<RawImage>(rawimage);
            Image.transform.parent = ob.gameObject.transform;
            Image.name += "-" + gameObject.name;
            Image.transform.localScale = new Vector3(1, 1, 1);

            RectTransform rect = Image.GetComponent<RectTransform>();
            RectTransform rectorgi = rawimage.GetComponent<RectTransform>();

            this.rect = rect;

            rect.offsetMin = new Vector2(rectorgi.offsetMin.x, rectorgi.offsetMin.y);
            rect.offsetMax = new Vector2(rectorgi.offsetMax.x, rectorgi.offsetMax.y);

            Image.texture = GetComponent<Building>().ResourceProduction.getSprite().texture;
            rawimage.gameObject.SetActive(false);

        }
        else Debug.LogError("Cant Find TIMER_TEXT");
    }

    void OnBecameVisible()
    {
        Image.gameObject.SetActive(true);
    }

    void OnBecameInvisible()
    {
        Image.gameObject.SetActive(false);
    }

    void OnWillRenderObject()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(new Vector3( transform.position.x, transform.position.y, transform.position.z));
        Image.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

        AnchorOpertion.SetAnchor(rect);
    }

    public RawImage getTimer()
    {
        return Image;
    }

    public void Remove()
    {
        Image.gameObject.SetActive(false);
        Destroy(Image);
        Destroy(this);

    }
}
