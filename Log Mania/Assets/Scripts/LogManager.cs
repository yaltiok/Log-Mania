using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{

    private float shapeWidth;
    private Vector3 offsetVector;
    private LogMovement logMovement;

    public GameObject boundary;

    private void Start()
    {
        logMovement = GetComponent<LogMovement>();

        shapeWidth = GetComponentInChildren<MeshRenderer>().bounds.size.x; /*GetComponent<MeshRenderer>().bounds.size.x;*/


        float offset = Random.Range(-boundary.transform.position.x + shapeWidth * 0.5f, boundary.transform.position.x - shapeWidth * .5f);

        //int dir = Random.Range(0,2);

        //transform.Rotate(0, dir * 180f, 0);

        offsetVector = new Vector3(offset,0,0);

        transform.position += offsetVector;
    }


    public void setTexture(Texture texture)
    {
        GetComponentInChildren<Renderer>().material.SetTexture("_BaseMap", texture);
    }

    private void Update()
    {
        if (transform.position.z < 10f)
        {
            logMovement.setBounciness();
        }
    }
    
}
