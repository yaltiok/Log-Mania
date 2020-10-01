using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private MeshCollider currentMeshCollider;

    public void setBounciness()
    {
        for (int i = 0; i <= transform.childCount-1; i++)
        {
            currentMeshCollider = transform.GetChild(i).GetComponent<MeshCollider>();

            currentMeshCollider.material = null;
        }
    }
}
