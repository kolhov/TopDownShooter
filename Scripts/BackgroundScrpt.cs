using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrpt : MonoBehaviour
{
    [SerializeField] private float backgroundScrollSpeed = 0.1f;
    private Material myMaterial;
    private Vector2 offSet;

    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    private void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
