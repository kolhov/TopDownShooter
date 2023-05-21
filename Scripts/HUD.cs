using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    //Cached reference
    private ScoreCounter _scoreCounter;
    private TextMeshProUGUI text;
    void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _scoreCounter.GetScore().ToString();
    }
}
