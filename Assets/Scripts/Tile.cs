using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private int row;
    private int col;
    private int tileValue;
    private Color tileColor;
    private bool isHidden;
    private TileType type = TileType.MIN;
    
    public int Row
    {
        get => row;
    }

    public int Col
    {
        get => col;
    }

    public int Value
    {
        get => tileValue;
        set => this.tileValue = value;
    }
    
    public Color Color
    {
        get => tileColor;
        set => tileColor = value;
    }
    
    public bool IsHidden
    {
        get => isHidden;
        set => isHidden = value;
    }

    private void Start()
    {
        Init();
        isHidden = true;
    }

    private void Init()
    {
        switch (type)
        {
            case TileType.MIN:
                tileValue = 0;
                tileColor = Color.black;
                break;
            case TileType.QUARTER:
                tileValue = 100;
                tileColor = Color.cyan;
                break;
            case TileType.HALF:
                tileValue = 200;
                tileColor = Color.blue;
                break;
            case TileType.MAX:
                tileValue = 400;
                tileColor = Color.black;
                break;
        }
    }

    public void Reveal()
    {
        isHidden = false;
        GetComponent<Image>().color = tileColor;
    }

    public void OnPointerClicked()
    {
        if (true)
        {
            
        }
        else if (true)
        {
            
        }
    }
}
