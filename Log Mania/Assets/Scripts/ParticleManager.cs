using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(DestroyParticleSystem());
    }

    IEnumerator DestroyParticleSystem()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
