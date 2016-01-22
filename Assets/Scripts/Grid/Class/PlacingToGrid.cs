using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacingToGrid : MonoBehaviour {

    public int Col;
    public int Row;
    public int Col_size;
    public int Row_size;
    public float X_Space_Mirror;
    public float Y_Space_Mirror;
    public float X_Space_Normal;
    public float Y_Space_Normal;

    public bool scale = false;

    public List<GridElement> GridElementList;
    public GridManager Manager;

    private float X_Space;
    private float Y_Space;

    public bool Debugdraw = false;

	// Use this for initialization
	void Start () {
        GridElementList = new List<GridElement>();
        if (scale == false)
        {
            X_Space = X_Space_Normal;
            Y_Space = Y_Space_Normal;

        }
        else
        {
            X_Space = X_Space_Mirror;
            Y_Space = Y_Space_Mirror;
        }

        Manager.Place(this);
	}
	
	// Update is called once per frame
	void Update () {
     if(Debugdraw == true) 
     {

         Manager.Place(this);
         if(scale == false)
         {
             X_Space = X_Space_Normal;
             Y_Space = Y_Space_Normal;

         }
         else
         {
             X_Space = X_Space_Mirror;
             Y_Space = Y_Space_Mirror;
         }

     }

	}

    public void setPosition(Vector3 vector)
    {
        transform.position = new Vector3(vector.x, vector.y, Manager.GridSize - Row + (Col / 100f));
    }

    public void RelaseAll()
    {
        IEnumerator iter = GridElementList.GetEnumerator();

        while(iter.MoveNext())
        {
            GridElement element = (GridElement)iter.Current;
            element.ToggleOff();
       
        }

        GridElementList.Clear();
    }

    public void addElementToList(GridElement element)
    {
        GridElementList.Add(element);
        Debug.Log("TTTTTTTTTTTTT");
    }

    public void MirrorScale()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        scale = !scale;

        int Tmpsize = Col_size;
        Col_size = Row_size;
        Row_size = Tmpsize;

        if (scale == false)
        {
            X_Space = X_Space_Normal;
            Y_Space = Y_Space_Normal;

        }
        else
        {
            X_Space = X_Space_Mirror;
            Y_Space = Y_Space_Mirror;
        }

        Manager.Place(this);
    }

    public void ReloadNormal()
    {
        X_Space = X_Space_Normal;
        Y_Space = Y_Space_Normal;
    }

    public float GetSpace_X()
    {
        return this.X_Space;
    }

    public float GetSpace_Y()
    {
        return this.Y_Space;
    }

    public void setNormalSpace_x(float space)
    {
        this.X_Space_Normal = space;
    }

    public void setNormalSpace_y(float space)
    {
        this.Y_Space_Normal = space;
    }

    public void setMirrorSpace_x(float space)
    {
        this.X_Space_Mirror = space;
    }

    public void setMirrorSpace_y(float space)
    {
        this.Y_Space_Mirror = space;
    }

    public float getNormalSpace_x()
    {
        return this.X_Space_Normal;
    }

    public float getNormalSpace_y()
    {
        return this.Y_Space_Normal;
    }

    public float getMirrorSpace_x()
    {
        return this.X_Space_Mirror;
    }

    public float getMirrorSpace_y()
    {
        return this.Y_Space_Mirror;
    }


}
