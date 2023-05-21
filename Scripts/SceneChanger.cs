using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float delayBeforeGameOver = 2f ;
    private int currentScene;
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayBeforeGameOver);
        SceneManager.LoadScene("GameOverScene");
    }

    public void LoadStartMenu()
    {
        FindObjectOfType<ScoreCounter>().ResetGameScore();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
}
