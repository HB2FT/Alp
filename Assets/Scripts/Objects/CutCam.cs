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
        Debug.Log("Bossfight0");
        yield return new WaitForSeconds(2f);

        if (music.index == 0 && music.session.name == "FirstCombat")
        {
            try
            {
                music.PlayNext(true);
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }

        cutCam.SetActive(false);
        mainCam.SetActive(true);
        player.isControllable = true;Debug.Log("Bossfight1");
    }
}
