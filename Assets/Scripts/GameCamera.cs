using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameCamera : MonoBehaviour
{
    public static readonly Vector3 minBound = new Vector3(-45f, 0f, -10f);

    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothTime = 0.25f;
    public Vector3 velocity = Vector3.zero;

    public int yOffset = 0;
    private const int yEkseniKatsayisi = 10;

    [SerializeField] public Transform target;

    private void Start()
    {
        offset = new Vector3(0f, 0f, -10f);
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, yEkseniKatsayisi * yOffset, target.position.z) + offset;
        
        if (target.position.x < minBound.x)
        {
            //targetPosition = minBound + offset;
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void MoveDown() 
    {
        yOffset--;
    }

    public void MoveUp()
    {
        yOffset++;
    }
}
