using UnityEngine;
using System.Collections;

public class MoveTimerText : MonoBehaviour {

    private DisplayTimer Timer;
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
        GameObject ob = GameObject.Find("TIMER_PLACE");
        if (ob != null)
        {
            DisplayTimer displaytimer = ob.transform.GetChild(0).GetComponent<DisplayTimer>();

            Timer = Instantiate<DisplayTimer>(displaytimer);
            Timer.transform.parent = ob.gameObject.transform;
            Timer.name += "-" + gameObject.name;
            Timer.transform.localScale = new Vector3(1, 1, 1);

            RectTransform rect = Timer.GetComponent<RectTransform>();
            RectTransform rectorgi = displaytimer.GetComponent<RectTransform>();

            this.rect = rect;

            rect.offsetMin = new Vector2(rectorgi.offsetMin.x, rectorgi.offsetMin.y);
            rect.offsetMax = new Vector2(rectorgi.offsetMax.x, rectorgi.offsetMax.y);


        }
        else Debug.LogError("Cant Find TIMER_TEXT");
    }

    void OnBecameVisible()
    {
        Timer.gameObject.SetActive(true);
    }

    void OnBecameInvisible()
    {
        Timer.gameObject.SetActive(false);
    }

    void OnWillRenderObject()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(new Vector3( transform.position.x, transform.position.y, transform.position.z));
        Timer.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

        AnchorOpertion.SetAnchor(rect);
    }

    public DisplayTimer getTimer()
    {
        return Timer;
    }

    public void Remove()
    {
        Timer.gameObject.SetActive(false);
        Destroy(Timer);
        Destroy(this);

    }
}
