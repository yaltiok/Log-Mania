using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // TODO: Buraya bir şeyler yaz
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.tag);
        if (collision.transform.CompareTag("CuttingZone"))
        {
            Destroy(collision.gameObject);
        }
    }
}
