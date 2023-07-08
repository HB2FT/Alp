using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public StoryScene nextScene;

    [Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
    }
}
