using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour {

    public float ElementSize;
    public int GridSize;
    public Transform StartPosition;
    public Material material;
    public LineRenderer Line;
    public Transform GreenField;
    public GridElement GridElement;

    public Color32 RedColor;
    public Color32 GreenColor;

    private GridElement grid  = new GridElement();
    private GridElement[,] Grid;
    private DetectPointOnGrid DetectPoint;
    private List<PlacingToGrid> TilleOnGrid = new List<PlacingToGrid>();
    private GridElement TouchedElement;


	// Use this for initialization
	void Awake () {
        Grid = new GridElement[GridSize, GridSize];
        InitializeGrid();

        GridChunk Chunk = new GridChunk(GridSize, 4);

        DetectPoint = new DetectPointOnGrid();
        DetectPoint.SetGridSize(GridSize);
        

        Vector2 Point = Camera.main.ViewportToWorldPoint(StartPosition.position);


        int Count = ( (5 * GridSize) * 2);
        Line.SetVertexCount(Count);

        int i = 0;
       // for (int i = 0; i < Count;)
       // {
            for(int j = 0; j< GridSize; j++)
            {
                Line.SetPosition(i, new Vector3(Grid[0, j].getA().x, Grid[0, j].getA().y, Grid[0, j].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[GridSize - 1, j].getB().x, Grid[GridSize - 1, j].getB().y, Grid[GridSize - 1, j].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[GridSize - 1, j].getC().x, Grid[GridSize - 1, j].getC().y, Grid[GridSize - 1, j].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[0, j].getD().x, Grid[0, j].getD().y, Grid[0, j].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[0, j].getA().x, Grid[0, j].getA().y, Grid[0, j].getZ()));
                i++;
            }
            int index = GridSize - 1;
            for (int l = 0; l < GridSize; l++)
            {
                Line.SetPosition(i, new Vector3(Grid[l, index].getD().x, Grid[l, index].getD().y, Grid[l, index].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[l, 0].getA().x, Grid[l, 0].getA().y, Grid[l, 0].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[l, 0].getB().x, Grid[l, 0].getB().y, Grid[l, 0].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[l, index].getC().x, Grid[l, index].getC().y, Grid[l, index].getZ()));
                i++;
                Line.SetPosition(i, new Vector3(Grid[l, index].getD().x, Grid[l, index].getD().y, Grid[l, index].getZ()));
                i++;
            }

       // }


	}
	

    public GridElement DetechTouchPositionOnGrid(Vector2 TouchPosition)
    {
        int[,] Index_tab = new int[1, 2];

        Index_tab = (int[,])DetectPoint.DetechTouchPositionOnGrid(Grid, TouchPosition).Clone();
        //Debug.Log(Index_tab[0, 0] + " " + Index_tab[0,1]);

        GridElement element = Grid[Index_tab[0,0] , Index_tab[0,1] ];

        Vector3 Apoint = Camera.main.ViewportToWorldPoint(new Vector3( element.getA().x,
                                                       element.getA().y,
                                                       element.getZ())
                                                       );

        Vector3 Bpoint = Camera.main.ViewportToWorldPoint(new Vector3(element.getC().x,
                                               element.getC().y,
                                               element.getZ())
                                               );
        float x = Bpoint.x - Bpoint.x;

        GreenField.transform.position = new Vector3(element.getA().x + (element.getB().x - element.getA().x),
                                                    element.getB().y - (element.getB().y - element.getA().y) ,
                                                    GreenField.transform.position.z);

        TouchedElement = element;
        return element;
    }

    public void Place(PlacingToGrid PlacingObject)
    {
        if (PlacingObject.Col_size == 0 && PlacingObject.Row_size == 0) return;
        PlacingObject.RelaseAll();


        GridElement element = Grid[PlacingObject.Col, PlacingObject.Row];

        PlacingObject.setPosition( new Vector3(element.getA().x + (element.getB().x - element.getA().x) + PlacingObject.GetSpace_X(),
                                            element.getB().y - (element.getB().y - element.getA().y) - PlacingObject.GetSpace_Y(),
                                            PlacingObject.transform.position.z));
        
        int ColSize = (int)Mathf.Ceil( (float)PlacingObject.Col_size / 2f);
        int RowSize = (int)Mathf.Ceil( (float)PlacingObject.Row_size / 2f);

        for(int i = 0; i < PlacingObject.Col_size; i++)
        {
            for(int j = 0; j < PlacingObject.Row_size; j++)
            {
                GridElement element1 = Grid[PlacingObject.Col + i, PlacingObject.Row + j];
                element1.ToggleOn();
                PlacingObject.addElementToList(Grid[PlacingObject.Col + i, PlacingObject.Row  + j]);

            }
        }




        if (TilleOnGrid.Contains(PlacingObject) == false)
        {
            TilleOnGrid.Add(PlacingObject);
        }
    }


	// Update is called once per frame
	void Update () {
      //  PlacingObject.setPosition(Grid[PlacingObject.Col, PlacingObject.Row].getTexturePosition());
      
	}

    private void InitializeGrid()
    {
        GridElement GridPoint = Instantiate<GridElement>(this.GridElement);
        GridPoint.transform.parent = this.gameObject.transform;
        Vector2 Point = StartPosition.position;

        for (int i = 0, j = 0; i < GridSize; i++)
        {
            for(; j < GridSize; j++)
            {
                GridPoint.CalculatePosition(ElementSize, Point, transform.position.z);
                Grid[i, j] = GridPoint;

                Point = GridPoint.getD();

                Transform tmp = Instantiate<Transform>(GreenField);
                tmp.transform.parent = GridPoint.transform;
            

                GridPoint.setTexture(tmp);
                GridPoint.setGreen(GreenColor);

                GridPoint.setCol(i);
                GridPoint.setRow(j);

                GridPoint.transform.parent = this.gameObject.transform;
                GridPoint = Instantiate<GridElement>(this.GridElement);
    
                tmp.name += "_" + i + "_" + j;
                GridPoint.name += "_" + i + "_" + j;

            }
            Point = Grid[i, 0].getB();
            j = 0;
        }
    }

    void OnEnable()
    {
       

    }

    // To show the lines in the editor
    void OnDrawGizmos()
    {
        //DrawConnectingLines();
    }

    void DrawConnectingLines()
    {
        Grid = new GridElement[GridSize, GridSize];
        InitializeGrid();

        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                GL.Begin(GL.LINES);
                material.SetPass(0);
                GL.Color(new Color(material.color.r, material.color.g, material.color.b, material.color.a));

                GL.Vertex3(Grid[i, j].getA().x, Grid[i, j].getA().y, Grid[i, j].getZ());
                GL.Vertex3(Grid[i, j].getB().x, Grid[i, j].getB().y, Grid[i, j].getZ());

                GL.Vertex3(Grid[i, j].getB().x, Grid[i, j].getB().y, Grid[i, j].getZ());
                GL.Vertex3(Grid[i, j].getC().x, Grid[i, j].getC().y, Grid[i, j].getZ());

                GL.Vertex3(Grid[i, j].getC().x, Grid[i, j].getC().y, Grid[i, j].getZ());
                GL.Vertex3(Grid[i, j].getD().x, Grid[i, j].getD().y, Grid[i, j].getZ());

                GL.Vertex3(Grid[i, j].getD().x, Grid[i, j].getD().y, Grid[i, j].getZ());
                GL.Vertex3(Grid[i, j].getA().x, Grid[i, j].getA().y, Grid[i, j].getZ());
                GL.End();

            }
        }

    }

    public List<PlacingToGrid> getTilles()
    {
        return TilleOnGrid;
    }

    public GridElement getTouchedElement()
    {
        return TouchedElement;
    }

}




        //for(int i = 1; i <= PlacingObject.Col_size; i++)
        //{
        //    for(int j = 1; j <= PlacingObject.Row_size; j++)
        //    {
        //        GridElement element1 = Grid[PlacingObject.Col - ColSize + i, PlacingObject.Row - RowSize + j];
        //        element1.ToggleOn();
        //        PlacingObject.addElementToList(Grid[PlacingObject.Col - ColSize + i, PlacingObject.Row - RowSize + j]);

        //    }
        //}