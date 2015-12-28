using UnityEngine;
using System.Collections;

public class GridChunk
{
    private GridElement[,] Chunk;
    private int ChunkElementCount;
    private int INDEX_X;
    private int INDEX_Y;
    private int ChunkArraySize;

    public GridChunk(int ArraySize, int Element_in_chunk)
    {
        Chunk = new GridElement[ArraySize, ArraySize];
        ChunkElementCount = Element_in_chunk;

        ChunkArraySize = ArraySize;
    }

    public void setChunks(GridElement[,] _GridElement, int size)
    {
        Debug.Log(_GridElement.Length);
        int GridIndex_X = 0;
        int GridIndex_Y = 0;

        for(int i = 0; i < ChunkArraySize; i++)
        {
            for(int j = 0; j < ChunkArraySize; j++)
            {
               GridElement element = new GridElement();

                element.setA(_GridElement[GridIndex_X, GridIndex_Y].getA());
                GridIndex_Y += ChunkElementCount;

                element.setD(_GridElement[GridIndex_X, GridIndex_Y].getD());
                GridIndex_Y -= ChunkElementCount;
                GridIndex_X += ChunkArraySize;

                element.setB(_GridElement[GridIndex_X, GridIndex_Y].getB());
                GridIndex_Y += ChunkElementCount;

                element.setC(_GridElement[GridIndex_X, GridIndex_Y].getC());
                GridIndex_Y++;
                GridIndex_X -= ChunkElementCount;
            }
        }
    }
}

