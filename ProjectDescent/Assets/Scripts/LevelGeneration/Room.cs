using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : IComparable<Room> {

    public List<Tile> tiles;
    public List<Tile> edgeTiles;
    public List<Room> connectedRooms;
    public int roomSize;
    public bool isAccessibleFromMainRoom;
    public bool isMainRoom;

    public Room() { }

    public Room(List<Tile> roomTiles, int[,] levelMap)
    {
        tiles = roomTiles;
        roomSize = tiles.Count;
        connectedRooms = new List<Room>();

        edgeTiles = new List<Tile>();

        foreach(Tile tile in tiles)
        {
            for(int x = tile.X - 1; x <= tile.X + 1; x++)
            {
                for(int y = tile.Y - 1; y <= tile.Y + 1; y++)
                {
                    if(x == tile.X || y == tile.Y)
                    {
                        if(levelMap[x, y] == 1)
                        {
                            edgeTiles.Add(tile);
                        }
                    }
                }
            }
        }
    }

    public void SetAccessibleFromMainRoom()
    {
        if(!isAccessibleFromMainRoom)
        {
            isAccessibleFromMainRoom = true;
            foreach(Room connectedRoom in connectedRooms)
            {
                connectedRoom.SetAccessibleFromMainRoom();
            }
        }
    }

    public static void ConnectRooms(Room roomA, Room roomB)
    {
        if (roomA.isAccessibleFromMainRoom)
        {
            roomB.SetAccessibleFromMainRoom();
        }
        else if(roomB.isAccessibleFromMainRoom)
        {
            roomA.SetAccessibleFromMainRoom();
        }
        roomA.connectedRooms.Add(roomB);
        roomB.connectedRooms.Add(roomA);
    }

    public bool IsConnected(Room other)
    {
        return connectedRooms.Contains(other);
    }

    public int CompareTo(Room other)
    {
        return other.roomSize.CompareTo(roomSize);
    }

}
