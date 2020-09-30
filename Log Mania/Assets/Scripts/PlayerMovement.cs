using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform holder, saw;
    private GameObject clampRight, clampLeft;
    private float minX;
    private float maxX;
    private Vector3 rotationSpeed = new Vector3(10f,0,0);

    private float dif;


    void Start()
    {
        initObjects();
        setMaxTravelDistance();
        initBoundaries();

    }

    void Update()
    {
        followMouse();
        rotate();
    }


    private void rotate()
    {
        transform.Rotate(rotationSpeed);
    }
    private void initBoundaries()
    {
        float sawWidth = saw.GetComponent<MeshRenderer>().bounds.size.x;
        float clampWidth = clampRight.GetComponent<MeshRenderer>().bounds.size.x;
        float holderWidth = holder.GetComponent<MeshRenderer>().bounds.size.x;
        float offset = ((clampWidth + sawWidth) * 0.5f + holderWidth);
        minX = clampLeft.transform.position.x + offset;
        maxX = clampRight.transform.position.x - offset;
    }
    private void setMaxTravelDistance()
    {
        dif = clampRight.transform.position.x - clampLeft.transform.position.x; // Maksimum gidebileceği mesafe
    }
    private void followMouse() 
    {
        Vector3 mouseInWorldPoint = Camera.main.ScreenToViewportPoint(Input.mousePosition); // Mouse pozisyonunu 0 ile 1 arasında veriyor.
        Vector3 pos = new Vector3((mouseInWorldPoint.x - 0.5f) * dif, transform.position.y, transform.position.z); // Bu değeri -0.5 ile 0.5 e çekiyoruz. Maksimum mesafe ile çarpıyoruz.
        pos.x = Mathf.Clamp(pos.x, minX, maxX); // Sınırlandırma
        transform.position = pos;
    }
    private void initObjects()
    {
        clampRight = GameObject.Find("Clamp_Right");
        clampLeft = GameObject.Find("Clamp_Left");
        holder = GameObject.Find("Holder_Right").transform;
        saw = GameObject.Find("Saw").transform;
    }
}
