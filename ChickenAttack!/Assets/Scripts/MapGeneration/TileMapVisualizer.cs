using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorMap, wallMap;
    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private RuleTile walls;


    public void PaintFloorTile(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorMap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions) 
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleWall(Vector2Int position)
    {
        PaintSingleTile(wallMap, walls, position); 
    } 

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        wallMap.ClearAllTiles();
        floorMap.ClearAllTiles();
    }
}
