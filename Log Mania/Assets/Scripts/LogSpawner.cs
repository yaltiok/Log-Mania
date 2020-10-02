using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private float logSpawnInterval;
    private IEnumerator coroutine;


    public int logCount;
    public GameObject[] logList;
    public Texture[] textureList;

    public event Action endGameEvent;

    void Start()
    {
        coroutine = SpawnLogs(logCount);

        startCoroutine();
    }



    private IEnumerator SpawnLogs(int logCount)
    {
        int i = 0;
        while (i < logCount)
        {
            int index = UnityEngine.Random.Range(0,logList.Length);
            GameObject logToSpawn = logList[index];

            GameObject currentLog = Instantiate(logToSpawn, transform.position, logToSpawn.transform.rotation);

            currentLog.GetComponent<LogManager>().setTexture(textureList[i%textureList.Length]);

            yield return new WaitForSeconds(logSpawnInterval);
            i++;

        }
        coroutine = WaitForSeconds();
        startCoroutine();
    }

    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(4.3f);

        if (endGameEvent != null)
        {
            endGameEvent();
        }

    }

    private void startCoroutine()
    {
        StartCoroutine(coroutine);
    }
}
