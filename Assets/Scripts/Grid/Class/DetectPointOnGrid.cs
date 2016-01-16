using UnityEngine;
using System.Collections;

public class DetectPointOnGrid : MonoBehaviour
{

    private int GridSize;

    public void SetGridSize(int Size)
    {
        GridSize = Size;
    }

    public int[,] DetechTouchPositionOnGrid(GridElement[,] Grid, Vector2 TouchPosition)
    {

        int[,] Min_horizontally = new int[1, 2];
        int[,] Max_horizontally = new int[1, 2];

        int[,] Min_vertical = new int[1, 2];
        int[,] Max_vertical = new int[1, 2];

        Min_horizontally[0, 0] = 0;
        Min_horizontally[0, 1] = 0;

        Max_horizontally[0, 0] = 0;
        Max_horizontally[0, 0] = 0;

        for (int i = 0, j = GridSize - 1; i < GridSize; i++, j--)
        {
            if (Grid[i, j].getB().y > TouchPosition.y)
            {
                if (Grid[i, j].getA().y > TouchPosition.y)
                {

                    if (i - 1 >= 0)
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
                else if (Grid[i, j].getA().y <= TouchPosition.y)
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

        //   Debug.Log("Min Horizontally = " + Min_horizontally[0,0] + " , " + Min_horizontally[0,1]);
        //   Debug.Log("Max Horizontally = " + Max_horizontally[0, 0] + " , " + Max_horizontally[0, 1]);


        if (Grid[GridSize - 1, 0].getB().x >= TouchPosition.x)
        {
            for (int i = 0; i < GridSize; i++)
            {
                if (Grid[i, 0].getB().x > TouchPosition.x)
                {
                    Max_vertical[0, 0] = i;
                    Max_vertical[0, 1] = 0;
                    break;
                }

            }
        }

        else if (Grid[GridSize - 1, 0].getB().x < TouchPosition.x)
        {
            for (int i = 0; i < GridSize; i++)
            {
                if (Grid[GridSize - 1, i].getB().x > TouchPosition.x)
                {
                    Max_vertical[0, 0] = GridSize - 1;
                    Max_vertical[0, 1] = i;
                    break;
                }
                else if (i == GridSize - 1)
                {
                    Max_vertical[0, 0] = GridSize - 1;
                    Max_vertical[0, 1] = i;
                }

            }
        }

        //  Debug.Log("MAX VERTICAL: = " + Max_vertical[0, 0] + " , " + Max_vertical[0, 1]);
        Min_horizontally = (int[,])FindIndexTab(Min_horizontally[0, 0], Min_horizontally[0, 1], Max_vertical[0, 0], Max_vertical[0, 1]).Clone();
        Max_horizontally = (int[,])FindIndexTab(Max_horizontally[0, 0], Max_horizontally[0, 1], Max_vertical[0, 0], Max_vertical[0, 1]).Clone();


        //  Debug.Log("Sugerowany indeks - MIN: " + Min_horizontally[0,0] + " , " + Min_horizontally[0,1]);
        //  Debug.Log("Sugerowany indeks - MAX: " + Max_horizontally[0, 0] + " , " + Max_horizontally[0, 1]);


        if (Min_horizontally[0, 0] == Max_horizontally[0, 0])
        {

            if (Min_horizontally[0, 1] > Max_horizontally[0, 1])
            {
                int[,] tmp = new int[1, 2];
                tmp = (int[,])Min_horizontally.Clone();

                Min_horizontally = (int[,])Max_horizontally.Clone();
                Max_horizontally = (int[,])tmp.Clone();
            }

            Max_horizontally = (int[,])isDontGO(Max_horizontally);
            Min_horizontally = (int[,])isDontGO(Min_horizontally);

            GridElement elemnt = Grid[Max_horizontally[0, 0], Max_horizontally[0, 1]];
            double d1 = lenghtofsection(elemnt.getC().x, elemnt.getC().y, TouchPosition.x, TouchPosition.y);
            d1 = d1 + lenghtofsection(elemnt.getD().x, elemnt.getD().y, TouchPosition.x, TouchPosition.y);

            elemnt = Grid[Min_horizontally[0, 0], Min_horizontally[0, 1]];
            double d2 = lenghtofsection(elemnt.getA().x, elemnt.getA().y, TouchPosition.x, TouchPosition.y);
            d2 = d2 + lenghtofsection(elemnt.getB().x, elemnt.getB().y, TouchPosition.x, TouchPosition.y);

            if (d1 > d2)
            {
                //Debug.Log("1Poprawny indeks to " + Min_horizontally[0, 0] + " : " + Min_horizontally[0, 1]);
                return Min_horizontally;
            }
            else
            {
                // Debug.Log("1Poprawny indeks to " + Max_horizontally[0, 0] + " : " + Max_horizontally[0, 1]);
                return Max_horizontally;
            }
        }
        else
        {
            if (Min_horizontally[0, 0] > Max_horizontally[0, 0])
            {
                int[,] tmp = new int[1, 2];
                tmp = (int[,])Min_horizontally.Clone();

                Min_horizontally = (int[,])Max_horizontally.Clone();
                Max_horizontally = (int[,])tmp.Clone();
            }

            Max_horizontally = (int[,])isDontGO(Max_horizontally).Clone();
            Min_horizontally = (int[,])isDontGO(Min_horizontally).Clone();

            GridElement elemnt = Grid[Max_horizontally[0, 0], Max_horizontally[0, 1]];
            double d1 = lenghtofsection(elemnt.getA().x, elemnt.getA().y, TouchPosition.x, TouchPosition.y);
            d1 = d1 + lenghtofsection(elemnt.getB().x, elemnt.getB().y, TouchPosition.x, TouchPosition.y);
            d1 = d1 + lenghtofsection(elemnt.getC().x, elemnt.getC().y, TouchPosition.x, TouchPosition.y);
            d1 = d1 + lenghtofsection(elemnt.getD().x, elemnt.getD().y, TouchPosition.x, TouchPosition.y);

            elemnt = Grid[Min_horizontally[0, 0], Min_horizontally[0, 1]];
            double d2 = lenghtofsection(elemnt.getA().x, elemnt.getA().y, TouchPosition.x, TouchPosition.y);
            d2 = d2 + lenghtofsection(elemnt.getB().x, elemnt.getB().y, TouchPosition.x, TouchPosition.y);
            d2 = d2 + lenghtofsection(elemnt.getC().x, elemnt.getC().y, TouchPosition.x, TouchPosition.y);
            d2 = d2 + lenghtofsection(elemnt.getD().x, elemnt.getD().y, TouchPosition.x, TouchPosition.y);

            if (d1 > d2)
            {
                // Debug.Log("2Poprawny indeks to " + Min_horizontally[0, 0] + " : " + Min_horizontally[0, 1]);
                return Min_horizontally;
            }
            else
            {
                //Debug.Log("2Poprawny indeks to " + Max_horizontally[0, 0] + " : " + Max_horizontally[0, 1]);
                return Max_horizontally;
            }
        }

        // Debug.Log("Sugerowany indeks - MIN: " + Min_horizontally[0, 0] + " , " + Min_horizontally[0, 1]);
        //  Debug.Log("Sugerowany indeks - MAX: " + Max_horizontally[0, 0] + " , " + Max_horizontally[0, 1]);
    }


    public int[,] FindIndexTab(int i, int j, int max_i, int max_j)
    {
        int[,] tab = new int[1, 2];

        while (j <= GridSize)
        {
            if (j > max_i - i + max_j)
            {
                i -= 1;
                j -= 1;

                if (i < 0 || j < 0)
                {
                    i += 1;
                    j += 1;
                }

                tab[0, 0] = i;
                tab[0, 1] = j;

                return tab;
                break;
            }
            else
            {
                i += 1;
                j += 1;

            }
        }

        tab[0, 0] = 0;
        tab[0, 1] = 0;
        return tab;

    }

    private int[,] getHorizontallyCol(int i, int j)
    {
        int result = i - j;
        int[,] tab = new int[1, 2];

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

    private int[,] isDontGO(int[,] tab)
    {
        if (tab[0, 0] >= GridSize)
        {
            tab[0, 0] = GridSize - 1;
        }

        if (tab[0, 0] < 0)
        {
            tab[0, 0] = 0;
        }

        if (tab[0, 1] >= GridSize)
        {
            tab[0, 1] = GridSize - 1;
        }

        if (tab[0, 1] < 0)
        {
            tab[0, 1] = 0;
        }

        return tab;
    }
}
