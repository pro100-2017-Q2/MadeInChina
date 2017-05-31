using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelGeneration : MonoBehaviour
{

    int[,] levelMap;

    public int width;
    public int height;

    [Range(0,100)]
    public int fillPercent;

    [Range(1, 5)]
    public int borderSize = 1;

    [Range(2, 5)]
    public int radius = 2;

    public List<Room> Rooms;
    public Room mainRoom;
    public List<Tile> allRoomTiles;

    string seed;
    public int levelCount = 1;

    void Start()
    {
        GenerateLevel();
    }
	
	void Update ()
    {
        
	}

    void GenerateLevel()
    {
        levelMap = new int[width, height];
        RandomFillLevel();

        for (int i = 0; i < 5; i++)
        {
            SmoothLevel();
        }

        allRoomTiles = new List<Tile>();

        ProcessLevel();

        int[,] borderedLevel = new int[width + borderSize * 2, height + borderSize * 2];

        for(int x = 0; x < borderedLevel.GetLength(0); x++)
        {
            for(int y = 0; y < borderedLevel.GetLength(1); y++)
            {
                if(x >= borderSize && x < width + borderSize && y >= borderSize && y < height + borderSize)
                {
                    borderedLevel[x, y] = levelMap[x - borderSize, y - borderSize];
                }
                else
                {
                    borderedLevel[x, y] = 1;
                }
            }
        }

        LevelMeshGeneration levelMesh = GetComponent<LevelMeshGeneration>();
        levelMesh.GenerateLevelMesh(borderedLevel, 1);

    }

    void ProcessLevel()
    {
        List<List<Tile>> wallRegions = GetRegions(1);
        int wallThreshold = 50;

        foreach(List<Tile> wallRegion in wallRegions)
        {
            if(wallRegion.Count < wallThreshold)
            {
                foreach(Tile tile in wallRegion)
                {
                    levelMap[tile.X, tile.Y] = 0;
                }
            }
        }

        List<List<Tile>> roomRegions = GetRegions(0);
        int roomThreshold = 50;
        List<Room> survivingRooms = new List<Room>();

        foreach (List<Tile> roomRegion in roomRegions)
        {
            if (roomRegion.Count < roomThreshold)
            {
                foreach (Tile tile in roomRegion)
                {
                    levelMap[tile.X, tile.Y] = 1;
                }
            }
            else
            {
                survivingRooms.Add(new Room(roomRegion, levelMap));
            }
        }

        survivingRooms.Sort();
        survivingRooms[0].isMainRoom = true;
        survivingRooms[0].isAccessibleFromMainRoom = true;
        Rooms = survivingRooms;
        mainRoom = survivingRooms[0];

        foreach(Room r in Rooms)
        {
            foreach(Tile t in r.tiles)
            {
                allRoomTiles.Add(t);
            }
        }

        ConnectClosestRooms(survivingRooms);
    }

    void ConnectClosestRooms(List<Room> allRooms, bool forceAccessibilityFromMainRoom = false)
    {

        List<Room> roomListA = new List<Room>();
        List<Room> roomListB = new List<Room>();

        if(forceAccessibilityFromMainRoom)
        {
            foreach(Room room in allRooms)
            {
                if(room.isAccessibleFromMainRoom)
                {
                    roomListB.Add(room);
                }
                else
                {
                    roomListA.Add(room);
                }
            }
        }
        else
        {
            roomListA = allRooms;
            roomListB = allRooms;
        }

        int bestDistance = 0;
        Tile bestTileA = new Tile();
        Tile bestTileB = new Tile();
        Room bestRoomA = new Room();
        Room bestRoomB = new Room();
        bool possibleConnection = false;

        foreach(Room roomA in roomListA)
        {
            if(!forceAccessibilityFromMainRoom)
            {
                possibleConnection = false;
                if(roomA.connectedRooms.Count > 0)
                {
                    continue;
                }
            }

            foreach(Room roomB in roomListB)
            {
                if(roomA == roomB || roomA.IsConnected(roomB))
                {
                    continue;
                }

                for(int tileIndexA = 0; tileIndexA < roomA.edgeTiles.Count; tileIndexA++)
                {
                    for (int tileIndexB = 0; tileIndexB < roomB.edgeTiles.Count; tileIndexB++)
                    {
                        Tile tileA = roomA.edgeTiles[tileIndexA];
                        Tile tileB = roomB.edgeTiles[tileIndexB];
                        int distanceBetweenRooms = (int)(Mathf.Pow(tileA.X - tileB.X, 2) + Mathf.Pow(tileA.Y - tileB.Y, 2));

                        if(distanceBetweenRooms < bestDistance || !possibleConnection)
                        {
                            bestDistance = distanceBetweenRooms;
                            possibleConnection = true;
                            bestTileA = tileA;
                            bestTileB = tileB;
                            bestRoomA = roomA;
                            bestRoomB = roomB;
                        }
                    }
                }
            }

            if(possibleConnection && !forceAccessibilityFromMainRoom)
            {
                CreatePassage(bestRoomA, bestRoomB, bestTileA, bestTileB);
            }
        }

        if(possibleConnection && forceAccessibilityFromMainRoom)
        {
            CreatePassage(bestRoomA, bestRoomB, bestTileA, bestTileB);
            ConnectClosestRooms(allRooms, true);
        }

        if (!forceAccessibilityFromMainRoom)
        {
            ConnectClosestRooms(allRooms, true);
        }

    }

    void CreatePassage(Room roomA, Room roomB, Tile tileA, Tile tileB)
    {
        Room.ConnectRooms(roomA, roomB);
        List<Tile> line = GetLine(tileA, tileB);
        foreach(Tile t in line)
        {
            OpenPassage(t, radius);
        }
    }

    void OpenPassage(Tile t, int r)
    {
        for(int x = -r; x <= r; x++)
        {
            for(int y = -r; y <= r; y++)
            {
                if(x*x + y*y <= r*r)
                {
                    int passageX = t.X + x;
                    int passageY = t.Y + y;
                    if(IsInLevelRange(passageX, passageY))
                    {
                        levelMap[passageX, passageY] = 0;
                    }
                }
            }
        }
    }

    List<Tile> GetLine(Tile from, Tile to)
    {
        List<Tile> line = new List<Tile>();
        int x = from.X;
        int y = from.Y;

        int dx = to.X - from.X;
        int dy = to.Y - from.Y;

        bool inverted = false;
        int step = Math.Sign(dx);
        int gradientStep = Math.Sign(dy);

        int longest = Mathf.Abs(dx);
        int shortest = Mathf.Abs(dy);

        if(longest < shortest)
        {
            inverted = true;
            longest = Mathf.Abs(dy);
            shortest = Mathf.Abs(dx);

            step = Math.Sign(dy);
            gradientStep = Math.Sign(dx);
        }

        int accumulation = longest / 2;
        for(int i = 0; i < longest; i++)
        {
            line.Add(new Tile(x, y));

            if (inverted)
            {
                y += step;
            }
            else
            {
                x += step;
            }

            accumulation += shortest;
            if(accumulation >= longest)
            {
                if (inverted)
                {
                    x += gradientStep;
                }
                else
                {
                    y += gradientStep;
                }
                accumulation -= longest;
            }
        }

        return line;
    }

    public Vector3 TileToWorld(Tile tile)
    {
        return new Vector3(-width / 2 + .5f + tile.X, 2, -height / 2 + .5f + tile.Y);
    }

    public Tile WorldToTile(Vector3 pos)
    {
        return new Tile((int)(width * 2 - .5f - pos.x), (int)(height * 2 - .5f - pos.z));
    }

    List<List<Tile>> GetRegions(int type)
    {
        List<List<Tile>> regions = new List<List<Tile>>();
        int[,] levelFlags = new int[width, height];

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(levelFlags[x, y] == 0 && levelMap[x, y] == type)
                {
                    List<Tile> newRegion = GetRegionTiles(x, y);
                    regions.Add(newRegion);

                    foreach(Tile tile in newRegion)
                    {
                        levelFlags[tile.X, tile.Y] = 1;
                    }
                }
            }
        }

        return regions;
    }

    List<Tile> GetRegionTiles(int startX, int startY)
    {
        List<Tile> tiles = new List<Tile>();
        int[,] levelFlags = new int[width, height];
        int tileType = levelMap[startX, startY];

        Queue<Tile> q = new Queue<Tile>();
        q.Enqueue(new Tile(startX, startY));
        levelFlags[startX, startY] = 1;
        
        while(q.Count > 0)
        {
            Tile tile = q.Dequeue();
            tiles.Add(tile);

            for(int x = tile.X - 1; x <= tile.X + 1; x++)
            {
                for(int y = tile.Y - 1; y <= tile.Y + 1; y++)
                {
                    if(IsInLevelRange(x, y) && (y == tile.Y || x == tile.X))
                    {
                        if(levelFlags[x,y] == 0 && levelMap[x, y] == tileType)
                        {
                            levelFlags[x, y] = 1;
                            q.Enqueue(new Tile(x, y));
                        }
                    }
                }
            }
        }
        return tiles;
    }

    bool IsInLevelRange(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
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
