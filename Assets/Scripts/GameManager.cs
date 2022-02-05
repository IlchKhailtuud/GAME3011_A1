using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Text modeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text extractCountsText;
    [SerializeField] private Text scanCountsText;
    
    private int score = 0;
    private int extractCount = 3;
    private int scanCount = 6;
    private bool isScanMode = false;
    private bool isGameOver = false;
    private bool isGameWin = false;

    public int Score
    {
        get => score;
        set => score = value;
    }

    public int ExtractCount
    {
        get => extractCount;
        set => extractCount = value;
    }

    public int ScanCount
    {
        get => scanCount;
        set => scanCount = value;
    }

    public bool IsScanMode
    {
        get => isScanMode;
        set => isScanMode = value;
    }
    
    public bool IsGameOver
    {
        get => isGameOver;
        set => isGameOver = value;
    }
    
    public bool IsGameWin
    {
        get => isGameWin;
        set => isGameWin = value;
    }
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (ExtractCount <= 0)
        {
            if (Score < 800)
                Instance.IsGameOver = true;
            else
                Instance.IsGameWin = true;
        }
        
        if (isGameOver)
        {
            Debug.Log("over");
        }

        if (isGameWin)
        {
            Debug.Log("win");
        }
    }

    public void UpdateMode()
    {
        if (isScanMode) 
            modeText.text = "Scan";
        else 
            modeText.text = "Extreact";
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        scanCountsText.text = "Scans: " + scanCount;
        extractCountsText.text = "Extracts: " + extractCount;
    }

    public void OnPointerClick()
    {
        if (!isGameOver || isGameWin)
        {
            if (isScanMode)
                isScanMode = false;
            else
                isScanMode = true;
            
            UpdateMode();
        }
    }
}
