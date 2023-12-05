using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VisualEffects : MonoBehaviour
{
    [field: Header("Visual Effects")]
    [field: SerializeField] public PostProcessProfile deathVisualEffect { get; private set; }
    [field: SerializeField] public PostProcessProfile pauseMenuVisualEffect { get; private set; }

    public static VisualEffects instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Event Manager in the scene.");
        }
        instance = this;
    }
}
