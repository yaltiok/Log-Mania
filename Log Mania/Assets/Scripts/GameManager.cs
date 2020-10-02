using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AnimationController animationController;

    [SerializeField] private float hatchDumpInterval, initialWaitTime;

    private bool game;

    private LogSpawner logSpawner;


    private void Start()
    {
        startGame();
        logSpawner = FindObjectOfType<LogSpawner>();
        logSpawner.endGameEvent += stopGame;
        StartCoroutine(WaitAndStart(initialWaitTime));
    }


    IEnumerator StartHatchLoop()
    {
        while (game)
        {
            animationController.startAnimation();
            yield return new WaitForSeconds(hatchDumpInterval);
        }   
    }

    IEnumerator WaitAndStart(float initialWaitTime) 
    {
        yield return new WaitForSeconds(initialWaitTime);
        StartCoroutine(StartHatchLoop());
    }


    public void stopGame()
    {
        game = false;
    }

    public void startGame()
    {
        game = true;
    }

    public void reloadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
