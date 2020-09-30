using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{

    private IEnumerator coroutine;
    public int logCount;
    public GameObject[] logList;

    void Start()
    {
        coroutine = SpawnLogs(logCount);

        StartCoroutine(coroutine);
    }



    private IEnumerator SpawnLogs(int logCount)
    {
        int i = 0;
        while (i < logCount)
        {
            int index = Random.Range(0,logList.Length);
            GameObject currentLog = logList[index];

            Instantiate(currentLog, transform.position, currentLog.transform.rotation, transform);

            yield return new WaitForSeconds(2f);
            i++;

        }
    }
}
