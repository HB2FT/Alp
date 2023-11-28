using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null) throw new Exception("Animator was null");

        animator.Play("Loop");
    }

    void Update()
    {
        
    }
}
