using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMeshGeneration : MonoBehaviour {

    public SquareGrid squareGrid;
    List<Vector3> vertices;
    List<int> triangles;


    public void GenerateLevelMesh(int[,] level, float squareSize)
    {
        squareGrid = new SquareGrid(level, squareSize);

        vertices = new List<Vector3>();
        triangles = new List<int>();

        for(int x = 0; x < squareGrid.squares.GetLength(0); x++)
        {
            for(int y = 0; y < squareGrid.squares.GetLength(1); y++)
            {
                TriangulateSquare(squareGrid.squares[x, y]);
            }
        }
    }

    void TriangulateSquare(Square square)
    {
        switch (square.configurationOfActive)
        {
            case 0:
                break;
            
            //1 Point Active
            case 1:
                break;
            case 2:
                break;
            case 4:
                break;
            case 8:
                break;

            //2 Point Active
            case 3:
                break;
            case 5:
                break;
            case 6:
                break;
            case 9:
                break;
            case 10:
                break;
            case 12:
                break;

            //3 Point Active
            case 7:
                break;
            case 11:
                break;
            case 13:
                break;
            case 14:
                break;

            //4 Point Active
            case 15:
                break;
        }
    }
}
