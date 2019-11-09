using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Screwdriver : MonoBehaviour
{
    PlayerHealth player_health;
    DateTime instantiated_time;
    public float life_span_seconds;

    // Start is called before the first frame update
    void Start()
    {
        player_health = FindObjectOfType<PlayerHealth>();
        instantiated_time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 10.0f);

        if ((DateTime.Now - instantiated_time).TotalSeconds > life_span_seconds)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player_health.reduce_health();
        }
    }
}
