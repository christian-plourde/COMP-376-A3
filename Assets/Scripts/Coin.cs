using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    DateTime init_time;
    public float life_span_seconds = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        init_time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if ((DateTime.Now - init_time).TotalSeconds > life_span_seconds)
            Destroy(this.gameObject);
    }
}
