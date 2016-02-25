using UnityEngine;
using System.Collections;

public class MoveTimerText : MonoBehaviour {

    private DisplayTimer Timer;

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
            Timer = Instantiate<DisplayTimer>(ob.transform.GetChild(0).GetComponent<DisplayTimer>());
            Timer.transform.parent = ob.gameObject.transform;
            Timer.name += "-" + gameObject.name;
            Timer.transform.localScale = new Vector3(1, 1, 1);

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
    }

    public DisplayTimer getTimer()
    {
        return Timer;
    }
}
