using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectPool : MonoBehaviour {

    [SerializeField]
    private Text text;

    [SerializeField]
    private Image image;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
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
}
