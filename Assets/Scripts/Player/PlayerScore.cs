﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(float points)
    {
        _score += points;
        //_uiManager.AddScore(_score);
        Debug.Log("Current Score: " + _score);
    }

}