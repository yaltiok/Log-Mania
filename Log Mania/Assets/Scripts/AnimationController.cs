﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void startAnimation()
    {
        anim.SetTrigger("Dump");
    }
}
