using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{

    private float shapeWidth;
    private Vector3 offsetVector;

    public GameObject boundary;

    private void Start()
    {
        shapeWidth = GetComponent<MeshRenderer>().bounds.size.x;
        float offset = Random.Range(-boundary.transform.position.x, boundary.transform.position.x);

        int dir = Random.Range(0,2);

        transform.Rotate(dir * 180f, 0, 0);

        offsetVector = new Vector3(offset,0,0);

        transform.position += offsetVector;
    }
}
