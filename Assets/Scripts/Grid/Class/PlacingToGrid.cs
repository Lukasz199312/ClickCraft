using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacingToGrid : MonoBehaviour {

    public int Col;
    public int Row;
    public int Col_size;
    public int Row_size;
    public float X_Space;
    public float Y_Space;

    public List<GridElement> GridElementList;
    public GridManager Manager;


	// Use this for initialization
	void Start () {
        GridElementList = new List<GridElement>();
        Manager.Place(this);
	}
	
	// Update is called once per frame
	void Update () {
        Manager.Place(this);
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
    }
}
