using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCam : MonoBehaviour
{
    public GameObject cutCam, mainCam;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnEndCutScene()
    {
        yield return new WaitForSeconds(2f);

        cutCam.SetActive(false);
        mainCam.SetActive(true);
        player.isControllable = true;
    }
}
