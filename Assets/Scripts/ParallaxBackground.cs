using Mir.Entity;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public ParallaxCamera parallaxCamera;
    List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    private bool subscribed;

    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        SetLayers();
    }

    private void Update()
    {
        if (_Player.instance.transform.position.x > transform.position.x)
        {
            Subscribe();
        }
    }

    private void Subscribe()
    {
        if (!subscribed)
        {
            if (parallaxCamera != null)
            {
                parallaxCamera.onCameraTranslate += Move;
                subscribed = true;
            }
                
        }
    }

    void SetLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }

    void Move(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}