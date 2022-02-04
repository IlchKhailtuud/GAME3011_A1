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
}
