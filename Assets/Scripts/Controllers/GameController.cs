using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameController : MonoBehaviour // Oyunu genel hatlar�yla kontrol eder
{
    public GameObject square;

    void Start()
    {
        //if (bottomBar.Enabled) BottomBarStart();
        PlayerStart();
        HealthBarStart();
    }

    void Update()
    {
        if (bottomBar.Enabled && bottomBar.StartOnce) BottomBarStart();

        if (bottomBar.Enabled) BottomBarUpdate();
        PlayerUpdate();
        HealthBarUpdate();
        MenuUpdate();
    }
}