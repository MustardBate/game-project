using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public static class WallGenerator 
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tileMapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, CardinalDirectionList);
        foreach (var position in basicWallPositions)
        {
            tileMapVisualizer.PaintSingleWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new();
        foreach (var position in floorPositions) 
        {
            foreach (var direction in directionList)
            {
                var neighbourPostion = position + direction;
                if (floorPositions.Contains(neighbourPostion) == false)             
                    wallPositions.Add(neighbourPostion);
            }
        }
        return wallPositions;
    }


    public static List<Vector2Int> CardinalDirectionList = new()
        {
            new Vector2Int(0, 1), //UP
            new Vector2Int(1, 0), //RIGHT
            new Vector2Int(0, -1), //DOWN
            new Vector2Int(-1, 0), //LEFT
        };

}
