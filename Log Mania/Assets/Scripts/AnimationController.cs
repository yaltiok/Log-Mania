using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void startAnimation()
    {
        Debug.Log("Başlattım");
        anim.SetTrigger("Dump");
    }
}
