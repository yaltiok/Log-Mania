using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotation : MonoBehaviour
{
    private Vector3 rotationSpeed = new Vector3(10f, 0, 0);


    private void Update()
    {
        rotate();
    }

    private void rotate()
    {
        transform.Rotate(rotationSpeed);
    }
}
