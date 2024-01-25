using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BottomBarController : MonoBehaviour
{
    public GameObject BottomBar;

    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

    private AtomicBoolean startOnce = new AtomicBoolean(false);

    public static BottomBarController Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Bottom Bar Controller in the scene!");
        }
        Instance = this;
    }

    public bool StartOnce
    {
        get
        {
            return startOnce.Value;
        }

        set
        {
            startOnce.Value = value;
        }
    }

    public bool Enabled
    {
        get
        {
            return BottomBar.activeSelf;
        }

        set
        {
            BottomBar.SetActive(value);
            PlayerMovement.CanMove = !value;
        }
    }

    private enum State
    {
        COMPLETED, PLAYING
    }

    public void PlayScene(StoryScene scene)
    {
        Enabled = true;
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextScene();
    }

    public void PlayNextScene()
    {
        try
        {
            StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
            personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
            personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        }
        catch
        {
            Enabled = false;
        }
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);

            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
