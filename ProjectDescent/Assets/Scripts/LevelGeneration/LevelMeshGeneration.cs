using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMeshGeneration : MonoBehaviour {

    public SquareGrid squareGrid;
    public MeshFilter walls;
    public MeshCollider wallCollider;
    public MeshFilter cave;

    List<Vector3> vertices;
    List<int> triangles;

    Dictionary<int, List<Triangle>> triangleDictionary = new Dictionary<int, List<Triangle>>();
    List<List<int>> outlines = new List<List<int>>();
    HashSet<int> checkedVerts = new HashSet<int>();

    public void GenerateLevelMesh(int[,] level, float squareSize)
    {
        squareGrid = new SquareGrid(level, squareSize);

        vertices = new List<Vector3>();
        triangles = new List<int>();

        triangleDictionary.Clear();
        outlines.Clear();
        checkedVerts.Clear();

        for(int x = 0; x < squareGrid.squares.GetLength(0); x++)
        {
            for(int y = 0; y < squareGrid.squares.GetLength(1); y++)
            {
                TriangulateSquare(squareGrid.squares[x, y]);
            }
        }

        Mesh mesh = new Mesh();
        cave.mesh = mesh;

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        CreateWallMesh();
    }

    void CreateWallMesh()
    {
        CalcMeshOutlines();

        List<Vector3> wallVerts = new List<Vector3>();
        List<int> wallTriangles = new List<int>();
        Mesh wallMesh = new Mesh();

        float wallHeight = 2.5f;

        foreach(List<int> outline in outlines)
        {
            for(int i = 0; i< outline.Count - 1; i++)
            {
                int startIndex = wallVerts.Count;

                wallVerts.Add(vertices[outline[i]]);
                wallVerts.Add(vertices[outline[i + 1]]);
                wallVerts.Add(vertices[outline[i]] - Vector3.up * wallHeight);
                wallVerts.Add(vertices[outline[i + 1]] - Vector3.up * wallHeight);

                wallTriangles.Add(startIndex + 0);
                wallTriangles.Add(startIndex + 2);
                wallTriangles.Add(startIndex + 3);

                wallTriangles.Add(startIndex + 3);
                wallTriangles.Add(startIndex + 1);
                wallTriangles.Add(startIndex + 0);
            }
        }

        wallMesh.vertices = wallVerts.ToArray();
        wallMesh.triangles = wallTriangles.ToArray();
        walls.mesh = wallMesh;

        wallCollider.sharedMesh = wallMesh;
    }

    void CalcMeshOutlines()
    {
        for(int vertIndex = 0; vertIndex < vertices.Count; vertIndex++)
        {
            if(!checkedVerts.Contains(vertIndex))
            {
                int newOutlineVert = GetConnectedVerts(vertIndex);
                if(newOutlineVert != -1)
                {
                    checkedVerts.Add(vertIndex);

                    List<int> newOutline = new List<int>();
                    newOutline.Add(vertIndex);
                    outlines.Add(newOutline);
                    FollowOutline(newOutlineVert, outlines.Count - 1);
                    outlines[outlines.Count - 1].Add(vertIndex);
                }
            }
        }
    }

    int GetConnectedVerts(int vertIndex)
    {
        List<Triangle> trianglesContainingVertex = triangleDictionary[vertIndex];

        for(int i = 0; i < trianglesContainingVertex.Count; i++)
        {
            Triangle triangle = trianglesContainingVertex[i];

            for(int j = 0; j < 3; j++)
            {
                int vertexB = triangle[j];
                if(vertexB != vertIndex && !checkedVerts.Contains(vertexB))
                {
                    if(IsOutlineEdge(vertIndex, vertexB))
                    {
                        return vertexB;
                    }
                }
            }
        }
        return -1;
    }

    bool IsOutlineEdge(int vertA, int vertB)
    {
        List<Triangle> trianglesContainingVertexA = triangleDictionary[vertA];
        int sharedTriangleCount = 0;

        for(int i = 0; i < trianglesContainingVertexA.Count; i++)
        {
            if(trianglesContainingVertexA[i].Contains(vertB))
            {
                sharedTriangleCount++;
                if(sharedTriangleCount > 1)
                {
                    break;
                }
            }
        }
        return sharedTriangleCount == 1;
    }

    void FollowOutline(int vertIndex, int outlineIndex)
    {
        outlines[outlineIndex].Add(vertIndex);
        checkedVerts.Add(vertIndex);
        int nextVertIndex = GetConnectedVerts(vertIndex);

        if(nextVertIndex != -1)
        {
            FollowOutline(nextVertIndex, outlineIndex);
        }
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
                checkedVerts.Add(square.topLeft.vertexIndex);
                checkedVerts.Add(square.topRight.vertexIndex);
                checkedVerts.Add(square.bottomLeft.vertexIndex);
                checkedVerts.Add(square.bottomRight.vertexIndex);
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

        Triangle tri = new Triangle(a.vertexIndex, b.vertexIndex, c.vertexIndex);
        AddTriangleToDictionary(tri.vertexIndexA, tri);
        AddTriangleToDictionary(tri.vertexIndexB, tri);
        AddTriangleToDictionary(tri.vertexIndexC, tri);
    }

    void AddTriangleToDictionary(int vertIndexKey, Triangle triangle)
    {
        if(triangleDictionary.ContainsKey(vertIndexKey))
        {
            triangleDictionary[vertIndexKey].Add(triangle);
        }
        else
        {
            List<Triangle> triangleList = new List<Triangle>() { triangle };
            triangleDictionary.Add(vertIndexKey, triangleList);
        }
    }

    struct Triangle
    {
        public int vertexIndexA;
        public int vertexIndexB;
        public int vertexIndexC;
        int[] vertices;

        public Triangle(int a, int b, int c)
        {
            vertexIndexA = a;
            vertexIndexB = b;
            vertexIndexC = c;

            vertices = new int[]
            {
                a,
                b,
                c
            };
        }

        public int this[int i]
        {
            get { return vertices[i]; }
        }

        public bool Contains(int vertexIndex)
        {
            return vertexIndex == vertexIndexA || vertexIndex == vertexIndexB || vertexIndex == vertexIndexC;
        }
    }
}
