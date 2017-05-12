using UnityEngine;
using System.Collections;

public class LevelMeshGeneration : MonoBehaviour {

    public SquareGrid squareGrid;

    public void GenerateLevelMesh(int[,] level, float squareSize)
    {
        squareGrid = new SquareGrid(level, squareSize);
    }
}
