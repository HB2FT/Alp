using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Player player;
    public BottomBarController bottomBarController;
    public GameObject bottomBar;

    public List<StoryScene> stories;
    public int index;

    AtomicBoolean once = new AtomicBoolean(true);

    void Start()
    {
        index = 0;

        bottomBarController.PlayScene(stories[index++]); // Index'i oynattýktan sonra 1 arttýr
    }

    void Update()
    {
        if (!bottomBar.activeSelf)
        {
            if (index == 1)
            {
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                {
                    bottomBarController.PlayScene(stories[index++]); // Index'i oynattýktan sonra 1 arttýr
                }
            }

            if (index == 2)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(PlaySceneWithDelay(1f));
                }
            }

            if (index == 3)
            {
                if (once.Value) StartCoroutine(PlaySceneWithDelay(10f));
            }
        }
    }

    IEnumerator PlaySceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        bottomBarController.PlayScene(stories[index++]); // Index'i oynattýktan sonra 1 arttýr
    }
}
