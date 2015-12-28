using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

    public float ElementSize;
    public int GridSize;
    public Transform StartPosition;
    public Material material;
    public LineRenderer Line;


    private GridElement GridElement = new GridElement();
    private GridElement grid  = new GridElement();
    private GridElement[,] Grid;
	// Use this for initialization
	void Start () {
        Grid = new GridElement[GridSize, GridSize];
        InitializeGrid();

        GridChunk Chunk = new GridChunk(GridSize, 4);
       // Chunk.setChunks(Grid, GridSize);

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
	

    public void DetechTouchPositionOnGrid(Vector2 TouchPosition)
    {

        int[,] Min_horizontally = new int[1, 2];
        int[,] Max_horizontally = new int[1, 2];

        int[,] Min_vertical = new int[1, 2];
        int[,] Max_vertical = new int[1, 2];

        Min_horizontally[0, 0] = 0;
        Min_horizontally[0, 1] = 0;

        Max_horizontally[0, 0] = 0;
        Max_horizontally[0, 0] = 0;

        for(int i=0,j = GridSize -1; i < GridSize; i ++, j--)
        {
            if(Grid[i,j].getB().y > TouchPosition.y)
            {
                if(Grid[i,j].getA().y > TouchPosition.y )
                {

                    if(i - 1 >= 0)
                    {
                        Min_horizontally = (int[,])getHorizontallyCol(i - 1, j).Clone();
                    }
                    else
                    {
                        Min_horizontally = (int[,])getHorizontallyCol(i, j).Clone();
                    }

                    Max_horizontally = (int[,])getHorizontallyCol(i, j).Clone();
                    break;


                }
                else if(Grid[i,j].getA().y <= TouchPosition.y )
                {
                    if (i + 1 < GridSize)
                    {
                        Min_horizontally = (int[,])getHorizontallyCol(i + 1, j).Clone();
                      
                    }
                    else
                    {
                        Min_horizontally = (int[,])getHorizontallyCol(i, j).Clone();
                    }

                    Max_horizontally = (int[,])getHorizontallyCol(i, j).Clone();
                    break;
                }
            }
        }

        Debug.Log("Min Horizontally = " + Min_horizontally[0,0] + " , " + Min_horizontally[0,1]);
        Debug.Log("Max Horizontally = " + Max_horizontally[0, 0] + " , " + Max_horizontally[0, 1]);


        if(Grid[GridSize - 1,0].getB().x >= TouchPosition.x)
        {
            for(int i= 0; i < GridSize; i++)
            {
                if( Grid[i,0].getB().x > TouchPosition.x )
                {
                    Max_vertical[0,0] = i;
                    Max_vertical[0, 1] = 0;
                    break;
                }

            }
        }

         else if(Grid[GridSize - 1,0].getB().x < TouchPosition.x)
        {
            for (int i = 0; i < GridSize; i++)
            {
                if (Grid[GridSize - 1, i].getB().x > TouchPosition.x)
                {
                    Max_vertical[0, 0] = GridSize - 1;
                    Max_vertical[0, 1] = i;
                    break;
                }
                else if(i == GridSize - 1)
                {
                    Max_vertical[0, 0] = GridSize - 1;
                    Max_vertical[0, 1] = i;
                }

            }
        }

        Debug.Log("MAX VERTICAL: = " + Max_vertical[0, 0] + " , " + Max_vertical[0, 1]);
        Min_horizontally = (int[,]) FindIndexTab(Min_horizontally[0, 0], Min_horizontally[0, 1], Max_vertical[0, 0], Max_vertical[0, 1]).Clone();
        Max_horizontally = (int[,]) FindIndexTab(Max_horizontally[0, 0], Max_horizontally[0, 1], Max_vertical[0, 0], Max_vertical[0, 1]).Clone();


        Debug.Log("Proponowany indeks: " + Min_horizontally[0,0] + " , " + Min_horizontally[0,1]);
        Debug.Log("Proponowany indeks: " + Max_horizontally[0, 0] + " , " + Max_horizontally[0, 1]);

    }


    public int[,] FindIndexTab(int i, int j, int max_i, int max_j)
    {
        int [,] tab = new int[1,2];

        while(j <= GridSize)
        {
            if (j > max_i - i + max_j)
            {
                i -= 1;
                j -= 1;

                if(i < 0 || j < 0)
                {
                    i += 1;
                    j += 1;
                }
               
                tab[0,0] = i;
                tab[0,1] = j;

                return tab;
                break;
            }
            else
            {
                i += 1;
                j += 1;
                
            }
        }

        tab[0,0] = 0;
        tab[0,1] = 0;
        return tab;

    }

    private int[,] getHorizontallyCol(int i, int j)
    {
        int result = i - j;
        int [,] tab = new int[1,2];

        if (result < 0)
        {

            tab[0, 0] = 0;
            tab[0, 1] = Mathf.Abs(result);
        }
        else
        {
            tab[0, 0] = result;
            tab[0, 1] = 0;
        }

        return tab;
    }

    private double lenghtofsection(float Ax, float Ay, float Bx, float By)
    {
        double d;
        d = Mathf.Pow((Bx - Ax), 2) + Mathf.Pow(By - Ay, 2);

        return d;
    }

	// Update is called once per frame
	void Update () {

	}

    private void InitializeGrid()
    {
        GridElement GridPoint  = new GridElement();
        Vector2 Point = StartPosition.position;

        for (int i = 0, j = 0; i < GridSize; i++)
        {
            for(; j < GridSize; j++)
            {
                GridPoint.CalculatePosition(ElementSize, Point, transform.position.z);
                Grid[i, j] = GridPoint;

                Point = GridPoint.getD();
                GridPoint = new GridElement();

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




    public void OLDDetechTouchPositionOnGrid(Vector2 TouchPosition)
    {
        GridElement Min_XPosition;
        GridElement Max_XPosition;

        GridElement Min_YPosition;
        GridElement Max_YPosition;

        int[,] Min_horizontally = new int[1, 2];
        int[,] Max_horizontally = new int[1, 2];

        int[,] Min_vertical = new int[1, 2];
        int[,] Max_vertical = new int[1, 2];

        if (Grid[0, 0].getA().y > TouchPosition.y)
        {
            Min_YPosition = Grid[0, 0];
            Max_YPosition = Grid[0, 0];

            for (int i = 0; i < GridSize; i++) // detect Y;
            {
                if (Grid[0, i].getB().y > TouchPosition.y)
                {
                    if (Grid[0, i].getA().y < TouchPosition.y)
                    {
                        Max_XPosition = Grid[0, i];

                        Max_horizontally[0, 0] = 0;
                        Max_horizontally[0, 1] = i;

                        if (i == 0)
                        {
                            // Debug.Log("Znalazlem punkt 0,0");
                            Min_XPosition = Grid[0, 0];

                            Min_horizontally[0, 0] = 0;
                            Min_horizontally[0, 1] = 0;
                            break;
                        }
                        else
                        {
                            // Debug.Log("Znalazlem punkt 0," + (i - 1));
                            Min_XPosition = Grid[0, i - 1];

                            Min_horizontally[0, 0] = 0;
                            Min_horizontally[0, 1] = i - 1;

                            break;
                        }


                    }
                }
            }
        }
        else if (Grid[0, 0].getA().y < TouchPosition.y)
        {
            Min_XPosition = Grid[0, 0];
            Max_XPosition = Grid[0, 0];


            for (int i = 0; i < GridSize; i++) // detect Y;
            {
                if (Grid[i, 0].getB().y > TouchPosition.y)
                {
                    if (Grid[i, 0].getA().y < TouchPosition.y)
                    {
                        Max_XPosition = Grid[i, 0];

                        Max_horizontally[0, 0] = i;
                        Max_horizontally[0, 1] = 0;

                        // Debug.Log("Punkt Max: " + i);
                        if (i == 0)
                        {
                            // Debug.Log("Znalazlem punkt 0,0");
                            Min_XPosition = Grid[0, 0];

                            Min_horizontally[0, 0] = 0;
                            Min_horizontally[0, 1] = 0;

                            break;
                        }
                        else
                        {
                            // Debug.Log("Znalazlem punkt " + (i - 1) +" ,0");
                            Min_XPosition = Grid[i - 1, 0];

                            Min_horizontally[0, 0] = i - 1;
                            Min_horizontally[0, 1] = 0;

                            break;
                        }


                    }
                }

            }
        }

        if (Grid[GridSize - 1, 0].getB().x < TouchPosition.x)
        {
            for (int i = 0; i < GridSize; i++)
            {
                if (Grid[GridSize - 1, i].getB().x > TouchPosition.x)
                {
                    Max_YPosition = Grid[GridSize - 1, i];

                    Max_vertical[0, 0] = GridSize - 1;
                    Max_vertical[0, 1] = i;

                    //   Debug.Log("Punkt Max Y : "+ (GridSize - 1) + " " + i);
                    if (i == 0)
                    {
                        // Debug.Log("Znalazlem punkt  Y 0,0 i==00");
                        Min_YPosition = Grid[0, 0];

                        Min_vertical[0, 0] = GridSize - 1;
                        Min_vertical[0, 1] = 0;

                        break;
                    }
                    else
                    {
                        // Debug.Log("Znalazlem punkt Y "  + (GridSize-1) + ", " + (i - 1));
                        Min_YPosition = Grid[GridSize - 1, i - 1];

                        Min_vertical[0, 0] = GridSize - 1;
                        Min_vertical[0, 1] = i - 1;

                        break;
                    }

                }
            }
        }

        else if (Grid[GridSize - 1, 0].getB().x > TouchPosition.x)
        {
            for (int i = 0; i < GridSize; i++)
            {
                if (Grid[i, 0].getB().x > TouchPosition.x)
                {
                    Max_YPosition = Grid[i, 0];

                    Max_vertical[0, 0] = i;
                    Max_vertical[0, 1] = 0;

                    // Debug.Log("Punkt Max Y : " + 0 + " " + i);
                    if (i == 0)
                    {
                        //  Debug.Log("Znalazlem punkt  Y 0,0 i==00");
                        Min_YPosition = Grid[0, 0];

                        Min_vertical[0, 0] = 0;
                        Min_vertical[0, 1] = 0;

                        break;
                    }
                    else
                    {
                        // Debug.Log("Znalazlem punkt Y " + (i - 1) + ", " + 0);
                        Max_YPosition = Grid[i - 1, 0];

                        Min_vertical[0, 0] = i - 1;
                        Min_vertical[0, 1] = 0;

                        break;
                    }

                }
            }
        }


        Debug.Log("Sugerowany Min punkt W lini poziomek: " + Min_horizontally[0, 0] + " " + Min_horizontally[0, 1]);
        Debug.Log("Sugerowany Max punkt W lini poziomek: " + Max_horizontally[0, 0] + " " + Max_horizontally[0, 1]);

        Debug.Log("Sugerowany Min punkt W lini pionowej: " + Min_vertical[0, 0] + " " + Min_vertical[0, 1]);
        Debug.Log("Sugerowany Max punkt W lini pionowej: " + Max_vertical[0, 0] + " " + Max_vertical[0, 1]);

        if (Min_vertical[0, 0] < GridSize - 1)
        {

            int i = Max_horizontally[0, 0];
            int j = Max_horizontally[0, 1];

            int max_col = Max_vertical[0, 0] + 1;

            while (j < GridSize)
            {
                if (j > max_col - i)
                {
                    i--;
                    j--;
                    Debug.Log("Znalazlem indeks: [" + i + " " + j);
                    break;

                }
                i++;
                j++;
            }

            int ii = Min_horizontally[0, 0];
            int jj = Min_horizontally[0, 1];

            max_col = Max_vertical[0, 0] + 1;

            while (jj < GridSize)
            {
                if (jj > max_col - ii)
                {
                    ii--;
                    jj--;
                    Debug.Log("Znalazlem indeks: MIN [" + ii + " " + jj);
                    break;

                }
                ii++;
                jj++;
            }


        }
        else
        {

            int i = Max_horizontally[0, 0];
            int j = Max_horizontally[0, 1];

            int max_col = GridSize;

            while (true)
            {
                if (j > max_col - i + Max_vertical[0, 1])
                {
                    i--;
                    j--;

                    Max_horizontally[0, 0] = i;
                    Max_horizontally[0, 1] = j;

                    Debug.Log("Znalazlem indekss: [" + i + " " + j);
                    break;
                }
                i++;
                j++;
            }

            int ii = Min_horizontally[0, 0];
            int jj = Min_horizontally[0, 1];

            max_col = GridSize;

            while (true)
            {
                if (jj > max_col - ii + Max_vertical[0, 1])
                {
                    ii--;
                    jj--;

                    Min_horizontally[0, 0] = ii;
                    Min_horizontally[0, 1] = jj;

                    Debug.Log("Znalazlem indekss min: [" + ii + " " + jj);
                    break;
                }
                ii++;
                jj++;
            }
        }


        if (Min_horizontally[0, 0] == Max_horizontally[0, 0])
        {
            GridElement elemnt = Grid[Max_horizontally[0, 0], Max_horizontally[0, 1]];
            double d1 = lenghtofsection(elemnt.getD().x, elemnt.getD().y, TouchPosition.x, TouchPosition.y);

            elemnt = Grid[Min_horizontally[0, 0], Min_horizontally[0, 1]];
            double d2 = lenghtofsection(elemnt.getA().x, elemnt.getA().y, TouchPosition.x, TouchPosition.y);

            if (d1 > d2) Debug.Log("1Poprawny indeks to " + Min_horizontally[0, 0] + " : " + Min_horizontally[0, 1]);
            else Debug.Log("1Poprawny indeks to " + Max_horizontally[0, 0] + " : " + Max_horizontally[0, 1]);
        }
        else
        {
            GridElement elemnt = Grid[Max_horizontally[0, 0], Max_horizontally[0, 1]];
            double d1 = lenghtofsection(elemnt.getB().x, elemnt.getB().y, TouchPosition.x, TouchPosition.y);

            elemnt = Grid[Min_horizontally[0, 0], Min_horizontally[0, 1]];
            double d2 = lenghtofsection(elemnt.getA().x, elemnt.getA().y, TouchPosition.x, TouchPosition.y);

            if (d1 > d2) Debug.Log("2Poprawny indeks to " + Min_horizontally[0, 0] + " : " + Min_horizontally[0, 1]);
            else Debug.Log("2Poprawny indeks to " + Max_horizontally[0, 0] + " : " + Max_horizontally[0, 1]);
        }

    }

}
