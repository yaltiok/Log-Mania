using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public CameraShaker camShaker;
    public GameObject sawdustParticles;
    public GameObject particleHolder;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("CuttingZone"))
        {
            Destroy(collision.gameObject);
            //ContactPoint cp = collision.GetContact(0);
            print(collision.GetContact(0).point);
            Instantiate(sawdustParticles, collision.GetContact(0).point, Quaternion.identity, particleHolder.transform);
            StartCoroutine(camShaker.Shake(.4f,.2f));
        }
    }
}
