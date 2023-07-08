using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameController : MonoBehaviour // Oyunu genel hatlarýyla kontrol eder
{
    public GameObject square;

    void Start()
    {
        //if (bottomBar.Enabled) BottomBarStart();
        PlayerStart();
    }

    void Update()
    {
        if (bottomBar.Enabled && bottomBar.StartOnce) BottomBarStart();

        if (bottomBar.Enabled) BottomBarUpdate();
        PlayerUpdate();
    }
}