using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int level_length_seconds = 10;
    DateTime game_start;
    public Text level_indicator;

    public int Level
    {
        get { return ((int)(DateTime.Now - game_start).TotalSeconds / level_length_seconds + 1); }
    }

    // Start is called before the first frame update
    void Start()
    {
        game_start = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        level_indicator.text = "Level: " + Level;
    }
}
