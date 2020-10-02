using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{


    private List<GameObject> cloudList;
    private List<Vector3> startingPosList;
    private List<float> speedList;

    [SerializeField] private float maxX;

    void Start()
    {
        cloudList = new List<GameObject>();
        startingPosList = new List<Vector3>();
        speedList = new List<float>();
    }


    private void FixedUpdate()
    {
        for (int i = 0; i < cloudList.Count; i++)
        {
            GameObject currentCloud = cloudList[i];


            currentCloud.transform.position += Vector3.right * speedList[i] * Time.deltaTime;


            if(currentCloud.transform.position.x > maxX)
            {
                currentCloud.transform.position = startingPosList[i];
            }
        }
    }


    public void addToCloudList(GameObject cloud)
    {
        cloudList.Add(cloud);
        startingPosList.Add(cloud.transform.position);
        speedList.Add(Random.Range(15f,25f));
    }
}
