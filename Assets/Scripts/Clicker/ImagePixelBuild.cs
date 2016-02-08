using UnityEngine;
using System.Collections;

public class ImagePixelBuild : MonoBehaviour {

    public SpriteRenderer spriterender;
    private Texture2D SpriteTexture;

	// Use this for initialization
	void Start () {
        SpriteTexture = spriterender.sprite.texture;

        Color32[] pix = spriterender.sprite.texture.GetPixels32();
       // System.Array.Reverse(pix);

        SpriteTexture = new Texture2D(spriterender.sprite.texture.width, spriterender.sprite.texture.height);
        SpriteTexture.SetPixels32(pix);

        for (int x = 0; x < SpriteTexture.width; x++)
        {
            for (int y = 0; y < SpriteTexture.height; y++)
            {
                Color col = SpriteTexture.GetPixel(x,y);

                SpriteTexture.SetPixel(x, y, new Color(col.r,col.g, col.b, 1));
            }
        }



        SpriteTexture.Apply();

        Rect rec = new Rect(0,0,SpriteTexture.width,SpriteTexture.height);
        spriterender.sprite = Sprite.Create(SpriteTexture, rec, new Vector2(0.5f, 0.5f));
	}
	
	// Update is called once per frame
	void Update () {
	    

	}
}
