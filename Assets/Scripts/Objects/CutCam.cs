using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCam : MonoBehaviour
{
    public GameObject cutCam, mainCam;
    public Player player;

    public Music music;

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

        if (music.index == 0)
        {
            music.PlayNext(true);
        }

        cutCam.SetActive(false);
        mainCam.SetActive(true);
        player.isControllable = true;
    }
}
