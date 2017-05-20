using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrid  {

    public Square[,] squares; 

    public SquareGrid(int[,] level, float squareSize)
    {
        int nodeCountX = level.GetLength(0);
        int nodeCountY = level.GetLength(1);
        float levelWidth = nodeCountX * squareSize;
        float levelHeight = nodeCountY * squareSize;

        ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

        for(int x = 0; x < nodeCountX; x++)
        {
            for(int y = 0; y < nodeCountY; y++)
            {
                Vector3 pos = new Vector3(-levelWidth / 2 + x * squareSize + squareSize / 2, 0, -levelHeight / 2 + y * squareSize + squareSize / 2);
                controlNodes[x,y] = new ControlNode(pos, level[x, y] == 1, squareSize);
            }
        }

        squares = new Square[nodeCountX - 1, nodeCountY - 1];

        for (int x = 0; x < nodeCountX - 1; x++)
        {
            for (int y = 0; y < nodeCountY - 1; y++)
            {
                squares[x, y] = new Square(controlNodes[x, y+1], controlNodes[x+1, y+1], controlNodes[x+1, y], controlNodes[x, y]);
            }
        }
    }
}
