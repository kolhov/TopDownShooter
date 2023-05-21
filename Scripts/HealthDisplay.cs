using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    //Cached reference
    private Player _player;
    private TextMeshProUGUI text;
    void Start()
    {
        _player = FindObjectOfType<Player>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _player.GetHealth().ToString();
    }
}
