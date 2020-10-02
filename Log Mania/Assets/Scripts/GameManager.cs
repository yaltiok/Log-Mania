using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AnimationController animationController;
    [SerializeField] private GameObject endGamePanel;

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
        endGamePanel.SetActive(true);
        game = false;
    }

    public void startGame()
    {
        endGamePanel.SetActive(false);
        game = true;
    }

    public void reloadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
