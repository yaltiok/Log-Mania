using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{

    private IEnumerator coroutine;
    public int logCount;
    public GameObject[] logList;
    public Texture[] textureList;

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
            GameObject logToSpawn = logList[index];

            GameObject currentLog = Instantiate(logToSpawn, transform.position, logToSpawn.transform.rotation, transform);

            currentLog.GetComponent<LogManager>().setTexture(textureList[i%textureList.Length]);

            yield return new WaitForSeconds(2f);
            i++;

        }
    }
}
