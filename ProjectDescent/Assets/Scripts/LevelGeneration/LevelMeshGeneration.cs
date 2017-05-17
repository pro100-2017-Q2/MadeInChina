using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMeshGeneration : MonoBehaviour {

    public SquareGrid squareGrid;
    public MeshFilter walls;

    List<Vector3> vertices;
    List<int> triangles;


    public void GenerateLevelMesh(int[,] level, float squareSize)
    {
        squareGrid = new SquareGrid(level, squareSize);

        vertices = new List<Vector3>();
        triangles = new List<int>();

        Dictionary<int, List<Triangle>> triangleDictionary = new Dictionary<int, List<Triangle>>();

        for(int x = 0; x < squareGrid.squares.GetLength(0); x++)
        {
            for(int y = 0; y < squareGrid.squares.GetLength(1); y++)
            {
                TriangulateSquare(squareGrid.squares[x, y]);
            }
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

    }

    void TriangulateSquare(Square square)
    {
        switch (square.configurationOfActive)
        {
            case 0:
                break;

            // 1 points:
            case 1:
                MeshFromActivePoints(square.centerLeft, square.centerBottom, square.bottomLeft);
                break;
            case 2:
                MeshFromActivePoints(square.bottomRight, square.centerBottom, square.centerRight);
                break;
            case 4:
                MeshFromActivePoints(square.topRight, square.centerRight, square.centerTop);
                break;
            case 8:
                MeshFromActivePoints(square.topLeft, square.centerTop, square.centerLeft);
                break;

            // 2 points:
            case 3:
                MeshFromActivePoints(square.centerRight, square.bottomRight, square.bottomLeft, square.centerLeft);
                break;
            case 6:
                MeshFromActivePoints(square.centerTop, square.topRight, square.bottomRight, square.centerBottom);
                break;
            case 9:
                MeshFromActivePoints(square.topLeft, square.centerTop, square.centerBottom, square.bottomLeft);
                break;
            case 12:
                MeshFromActivePoints(square.topLeft, square.topRight, square.centerRight, square.centerLeft);
                break;
            case 5:
                MeshFromActivePoints(square.centerTop, square.topRight, square.centerRight, square.centerBottom, square.bottomLeft, square.centerLeft);
                break;
            case 10:
                MeshFromActivePoints(square.topLeft, square.centerTop, square.centerRight, square.bottomRight, square.centerBottom, square.centerLeft);
                break;

            // 3 point:
            case 7:
                MeshFromActivePoints(square.centerTop, square.topRight, square.bottomRight, square.bottomLeft, square.centerLeft);
                break;
            case 11:
                MeshFromActivePoints(square.topLeft, square.centerTop, square.centerRight, square.bottomRight, square.bottomLeft);
                break;
            case 13:
                MeshFromActivePoints(square.topLeft, square.topRight, square.centerRight, square.centerBottom, square.bottomLeft);
                break;
            case 14:
                MeshFromActivePoints(square.topLeft, square.topRight, square.bottomRight, square.centerBottom, square.centerLeft);
                break;

            // 4 point:
            case 15:
                MeshFromActivePoints(square.topLeft, square.topRight, square.bottomRight, square.bottomLeft);
                break;
        }
       
    }

    void MeshFromActivePoints(params Node[] points)
    {
        AssignVertices(points);

        if (points.Length >= 3)
            CreateTriangle(points[0], points[1], points[2]);
        if (points.Length >= 4)
            CreateTriangle(points[0], points[2], points[3]);
        if (points.Length >= 5)
            CreateTriangle(points[0], points[3], points[4]);
        if (points.Length >= 6)
            CreateTriangle(points[0], points[4], points[5]);

    }

    void AssignVertices(Node[] points)
    {
        for(int i = 0; i < points.Length; i++)
        {
            if(points[i].vertexIndex == -1)
            {
                points[i].vertexIndex = vertices.Count;
                vertices.Add(points[i].pos);
            }
        }
    }

    void CreateTriangle(Node a, Node b, Node c)
    {
        triangles.Add(a.vertexIndex);
        triangles.Add(b.vertexIndex);
        triangles.Add(c.vertexIndex);
    }
}
