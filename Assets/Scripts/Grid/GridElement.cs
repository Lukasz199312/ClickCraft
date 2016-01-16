using UnityEngine;
using System.Collections;

public class GridElement : MonoBehaviour
{
    private Vector2 A;
    private Vector2 B;
    private Vector2 C;
    private Vector2 D;

    private float z;
    private SpriteRenderer TextureObject;
    private Transform TextureTransform;
    private bool Free = true;
    private int col;
    private int row;

    public void GridInitialize(Vector2 A, Vector2 B, Vector2 C, Vector2 D, float z)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.D = D;

        this.z = z;
    }

    // Update is called once per frame
    public void CalculatePosition(float size, Vector2 Point, float z)
    {

        A.x = Point.x;
        A.y = Point.y;

        B.x = A.x + size / 2;
        B.y = A.y + size / (2 * Mathf.Sqrt(3));

        this.z = z;

        C.x = A.x + size;
        C.y = A.y;


        D.x = C.x + (size * -1) / 2;
        D.y = A.y + (size * -1) / (2 * Mathf.Sqrt(3));

    }

    public void setA(Vector2 Point)
    {
        this.A = new Vector2(Point.x, Point.y);
    }

    public void setB(Vector2 Point)
    {
        this.B = new Vector2(Point.x, Point.y);
    }

    public void setC(Vector2 Point)
    {
        this.C = new Vector2(Point.x, Point.y);
    }

    public void setD(Vector2 Point)
    {
        this.D = new Vector2(Point.x, Point.y);
    }

    public Vector2 getA()
    {
        return A;
    }

    public Vector2 getB()
    {
        return B;
    }

    public Vector2 getC()
    {
        return C;
    }

    public Vector2 getD()
    {
        return D;
    }

    public float getZ()
    {
        return z;
    }

    public bool isFree()
    {
        return Free;
    }

    public void setTexture(Transform Texture)
    {
        TextureTransform = Texture;
        this.TextureObject = Texture.GetComponent<SpriteRenderer>();
        TexturePositionSet();
    }

    public void ToggleOn()
    {
        TextureTransform.gameObject.SetActive(true);
        Free = true;
        TextureObject.gameObject.SetActive(true);
    }

    public void ToggleOff()
    {
        TextureTransform.gameObject.SetActive(false);
        Free = false;

    }
    private void TexturePositionSet()
    {

        TextureTransform.position = new Vector3(getA().x + (getB().x - getA().x),
                                                    getB().y - (getB().y - getA().y),
                                                   TextureTransform.position.z ); // Gdyby nie nie odpalalo
        ToggleOff();
    }

    public Vector3 getTexturePosition()
    {
        return TextureTransform.position;
    }

    public int getCol()
    {
        return col;
    }

    public int getRow()
    {
        return row;
    }

    public void setCol(int col)
    {
        this.col = col;
    }

    public void setRow(int row)
    {
        this.row = row;
    }

    public void setGreen(Color32 color)
    {
        TextureObject.color = color;
    }

    public void setRed(Color32 color)
    {
        TextureObject.color = color;
    }
}
