using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VisualEffectsManager : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    public static VisualEffectsManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Event Manager in the scene.");
        }
        instance = this;
    }

    public void SetCurrentProfile(PostProcessProfile profile)
    {
        postProcessVolume.profile = profile;
    }

    public float weight
    {
        set
        {
            postProcessVolume.weight = value;
        }

        get
        {
            return postProcessVolume.weight;
        }
    }
}
