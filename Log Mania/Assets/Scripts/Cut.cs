using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public CameraShaker camShaker;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("CuttingZone"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(camShaker.Shake(.4f,.2f));
        }
    }
}
