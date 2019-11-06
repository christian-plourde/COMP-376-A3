﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public static float max_shark_speed = 18.0f;
    public static float min_shark_speed = 10.0f;
    Vector3 initial_position;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = UnityEngine.Random.Range(min_shark_speed, max_shark_speed);
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("here");
        if(col.gameObject.CompareTag("Wall"))
        {
            Debug.Log("fuckballs");
        }
    }
}
