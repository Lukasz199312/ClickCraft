using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExperinceGUI : MonoBehaviour {

    public Image image;
    public Text LeveLText;
    public Text ExperinceText;
    public float StartSize;
    private RectTransform rec;

    void Awake()
    {
        rec = image.GetComponent<RectTransform>();
        // StartSize = rec.offsetMax.x;
        StartSize = rec.transform.localPosition.x - rec.rect.width;
        //rec.transform.localPosition = new Vector2(rec.transform.localPosition.x - rec.rect.width * 1f, rec.transform.localPosition.y);
    }

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Update(float CurrentExperince, float RequireExperince , int LeveL)
    {
        float percent = CurrentExperince / RequireExperince;
        rec.transform.localPosition = new Vector2(StartSize + rec.rect.width * percent, rec.transform.localPosition.y);
        LeveLText.text = LeveL.ToString();
        ExperinceText.text = CurrentExperince + " / " + RequireExperince;
    }
}
