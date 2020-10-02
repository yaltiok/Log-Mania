using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private MeshCollider currentMeshCollider;

    public void setBounciness()
    {

        currentMeshCollider = transform.GetComponent<MeshCollider>();

        currentMeshCollider.material = null;

    }
}
