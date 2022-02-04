using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    [SerializeField] private GameObject tilePre;

    private int rowNum;
    private int colNum;
    private int maxValueTileNum;
    
    private List<GameObject> tiles = new List<GameObject>();

    private void Start()
    {
        rowNum = 32;
        colNum = 32;
        maxValueTileNum = 10;
        
        InstantiateTiles();
        InitTileMap();
    }

    private void InitTileMap()
    {
        // while (maxValueTileNum > 0)
        // {
        //     int row = UnityEngine.Random.Range(0, rowNum + 1);
        //     int col = UnityEngine.Random.Range(0, colNum + 1);
        //
        //     Tile tile = GetTile(row, col);
        //
        //     if (tile != null && tile.Type != TileType.MAX)
        //     {
        //         tile.Type = TileType.MAX;
        //         SetTileValue(tile.Row - 2, tile.Col - 2, 5, TileType.QUARTER);
        //     }
        //
        //     --maxValueTileNum;
        // }

        for (int i = 0; i < maxValueTileNum; i++)
        {
            int row = UnityEngine.Random.Range(0, rowNum + 1);
            int col = UnityEngine.Random.Range(0, colNum + 1);

            Tile tile = GetTile(row, col);

            if (tile != null && tile.Type != TileType.MAX)
            {
                tile.Type = TileType.MAX;
                SetTileValue(tile.Row - 2, tile.Col - 2, 5, TileType.QUARTER);
            }
        }
        
        foreach (var go in tiles)
        {
            Tile t = go.GetComponent<Tile>();

            if (t.Type == TileType.MAX)
            {
                SetTileValue(t.Row -1, t.Col -1, 3, TileType.HALF);
            }
        }
    }

    private Tile GetTile(int row, int col)
    {
        foreach (var go in tiles)
        {
            Tile tile = go.GetComponent<Tile>();

            if (tile.Row == row && tile.Col == col)
                return tile; 
        }
        return null;
    }

    private void InstantiateTiles()
    {
        for (int i = 0; i < colNum; i++)
        {
            for (int j = 0; j < rowNum; j++)
            {
                GameObject tile = Instantiate(tilePre, transform);
                if (!tile)
                {
                    tile.GetComponent<Tile>().Col = colNum;
                    tile.GetComponent<Tile>().Row = rowNum;
                    tiles.Add(tile);
                }
            }
        }
    }

    private void SetTileValue(int Row, int Col, int length, TileType type)
    {
        for (int col = Col; col < Col + length; col++)
        {
            for (int row = Row; row < Row + length; row++)
            {
                Tile tile = GetTile(row, col);

                if (tile != null && tile.Type != TileType.MAX)
                {
                    tile.Type = type;
                }
            }
        }
    }

    private void RevealTiles(int Row, int Col, int length)
    {
        for (int col = Col; col < Col + length; col++)
        {
            for (int row = 0;  row < Row + length; row++)
            {
                Tile t = GetTile(row, col);
                t.RevealTile();
            }
        }
    }
}


