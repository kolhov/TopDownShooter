using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score;

    public void AddScore(int newPoints)
    {
        score += newPoints;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetGameScore()
    {
        score = 0;
    }

    private void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
