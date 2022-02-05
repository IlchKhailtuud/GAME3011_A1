using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Text modeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text extractCountsText;
    [SerializeField] private Text scanCountsText;
    [SerializeField] private int winScore;
    
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
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Update()
    {
        if (ExtractCount <= 0)
        {
            if (Score < winScore)
                isGameOver = true;
            else
                isGameWin = true;
        }
        
        if (isGameOver)
        {
            SceneManager.LoadScene("lose");
        }

        if (isGameWin)
        {
            SceneManager.LoadScene("win");
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

    public void OnModeClick()
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

    public void OnResetClick()
    {
        SceneManager.LoadScene("game");
    }
}
