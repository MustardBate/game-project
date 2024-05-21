using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneration
{
    public static HashSet<Vector2Int> RandomWalk(Vector2Int startPostion, int walkLenght)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPostion);
        var previousPosition = startPostion;

        for (int i = 0; i < walkLenght; i++) 
        {
            var newPosition = previousPosition + Direction.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }

    public static class Direction
    {
        public static List<Vector2Int> CardinalDirectionList = new()
        {
            new Vector2Int(0, 1), //UP
            new Vector2Int(1, 0), //RIGHT
            new Vector2Int(0, -1), //DOWN
            new Vector2Int(-1, 0), //LEFT
        };

        public static Vector2Int GetRandomCardinalDirection()
        {
            return CardinalDirectionList[Random.Range(0, CardinalDirectionList.Count)];
        }
    }
} 
