using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    private Text text;

    [SerializeField]
    private Image image;

    private Animator anim;
    private RectTransform Rect; 

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        Rect = this.gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
            gameObject.SetActive(false);
        }
	}

    public void setText(string strText)
    {
        text.text = strText;
    }

    public void setTexture(SpriteRenderer sprite)
    {
        image.sprite = sprite.sprite;
    }

    public void setTexture(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetPosition(Vector3 vec)
    {
        this.transform.parent.transform.position = new Vector3(vec.x, vec.y, vec.z);
    }
}
