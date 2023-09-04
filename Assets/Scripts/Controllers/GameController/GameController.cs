using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public partial class GameController : MonoBehaviour // Oyunu genel hatlarýyla kontrol eder
{
    void Start()
    {
        //if (bottomBar.Enabled) BottomBarStart();
        HealthBarStart();
    }

    void Update()
    {
        if (bottomBar.Enabled && bottomBar.StartOnce) BottomBarStart();

        if (bottomBar.Enabled) BottomBarUpdate();
        HealthBarUpdate();
        MenuUpdate();


    }
}