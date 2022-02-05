using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    [SerializeField] private GameObject tilePre;
    [SerializeField] private int maxValueTileNum;
    
    [SerializeField] private int rowNum = 32;
    [SerializeField] private int colNum = 32;
    
    private List<GameObject> tiles = new List<GameObject>();

    private void Start()
    {
        InstantiateTiles();
        InitTileMap();
    }
    
    private void InstantiateTiles()
    { 
        for (int col = 0; col < colNum; col++)
        {
            for (int row = 0; row < rowNum; row++)
            {
                GameObject go = Instantiate(tilePre, transform);
                
                Tile tile = go.GetComponent<Tile>();
                tile.Row = row;
                tile.Col = col;
                tiles.Add(go);
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
    
    private void InitTileMap()
    {
        for (int i = 0; i < maxValueTileNum; i++)
        {
            int row = UnityEngine.Random.Range(0, rowNum + 1);
            int col = UnityEngine.Random.Range(0, colNum + 1);
            
            Tile tile = GetTile(row, col);
            if (tile != null && tile.type != TileType.MAX)
            {
                tile.Type = TileType.MAX;
                SetTileValue(tile.Row - 2, tile.Col - 2, 5, TileType.QUARTER);
                SetTileValue(tile.Row -1, tile.Col -1, 3, TileType.HALF);
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

    public void DegradeTileValue(int Row, int Col, int oriRow, int oriCol, int length)
    {
        for (int col = Col; col < Col + length; col++)
        {
            for (int row = Row; row < Row + length; row++)
            {
                if (col != oriCol && row != oriRow)
                {
                    Tile tile = GetTile(row, col);
                    if (tile != null && tile.Type != TileType.MIN)
                    {
                        tile.Type -= 1;
                        tile.SetTileInfo();
                        tile.RevealTile();
                    }
                }
            }
        }
    }
    
    public void RevealTiles(int Row, int Col, int length)
    {
        for (int col = Col; col < Col + length; col++)
        {
            for (int row = Row;  row < Row + length; row++)
            {
                Tile t = GetTile(row, col);
                if (t != null)
                    t.RevealTile();
            }
        }
    }
}


