using UnityEngine;
using System.Collections;
using System;

public class LevelGeneration : MonoBehaviour
{

    int[,] levelMap;

    public int width;
    public int height;

    [Range(0,100)]
    public int fillPercent;

    string seed;

    void Start()
    {
        GenerateLevel();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateLevel();
        }
	}

    void GenerateLevel()
    {
        levelMap = new int[width, height];
        RandomFillLevel();

        for (int i = 0; i < 5; i++)
        {
            SmoothLevel();
        }

        LevelMeshGeneration levelMesh = GetComponent<LevelMeshGeneration>();
        levelMesh.GenerateLevelMesh(levelMap, 1);

    }

    void RandomFillLevel()
    {
        seed = Time.time.ToString();

        System.Random rand = new System.Random(seed.GetHashCode());

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    levelMap[x, y] = 1;
                }
                else
                {
                    levelMap[x, y] = (rand.Next(0, 100) < fillPercent) ? 1 : 0;
                }
            }
        }
    }

    void SmoothLevel()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighboorWallCount = GetSurroundingWallCount(x, y);

                if (neighboorWallCount > 4)
                {
                    levelMap[x, y] = 1;
                }
                else if(neighboorWallCount < 4)
                {
                    levelMap[x, y] = 0;
                }
            }
        }
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;

        for(int neighboorX = gridX - 1; neighboorX <= gridX + 1; neighboorX++)
        {
            for (int neighboorY = gridY - 1; neighboorY <= gridY + 1; neighboorY++)
            {
                if(neighboorX >= 0 && neighboorX < width && neighboorY >= 0 && neighboorY < height)
                {
                    if(neighboorX != gridX || neighboorY != gridY)
                    {
                        wallCount += levelMap[neighboorX, neighboorY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

}
