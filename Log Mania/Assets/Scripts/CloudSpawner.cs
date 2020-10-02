using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{




    [SerializeField] private float cloudSpawnInterval;
    [SerializeField] private int cloudCount;
    private IEnumerator coroutine;

    public GameManager gm;
    public CloudManager cloudManager;


    public GameObject[] cloudList;

    void Start()
    {
        coroutine = SpawnClouds();

        StartCoroutine(coroutine);
    }




    private IEnumerator SpawnClouds()
    {
        int i = 0;
        while (i < cloudCount)
        {
            yield return new WaitForSeconds(cloudSpawnInterval);

            int a = Random.Range(0, cloudList.Length);
            Vector3 offsetVector = Random.insideUnitSphere * 50f;

            GameObject cloudToSpawn = cloudList[a];

            GameObject currentCloud = Instantiate(cloudToSpawn, transform.position + offsetVector, cloudToSpawn.transform.rotation, transform);

            cloudManager.addToCloudList(currentCloud);

            i++;

        }
    }
}
