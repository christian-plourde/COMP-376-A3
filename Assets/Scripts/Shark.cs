using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shark : MonoBehaviour
{
    public static float max_shark_speed = 18.0f;
    public static float min_shark_speed = 10.0f;
    public int levels_to_speed_double = 10;
    Vector3 initial_position;
    float speed;
    float initial_speed;
    bool resetable = false;
    PlayerHealth player_health;
    LevelManager level_manager;
    public float coin_distraction_radius;
    Vector3 initial_right;
    DateTime distraction_start;
    public float distraction_duration_seconds;
    GameObject distraction_object;

    public bool Distracted
    {
        get { return !(distraction_object == null) && !(distraction_start == null) && (DateTime.Now - distraction_start).TotalSeconds < distraction_duration_seconds; }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = UnityEngine.Random.Range(min_shark_speed, max_shark_speed);
        initial_speed = speed;
        initial_position = transform.position;
        player_health = FindObjectOfType<PlayerHealth>();
        level_manager = FindObjectOfType<LevelManager>();
        initial_right = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        //if there is a coin close by the shark should become distracted
        foreach (Coin c in coins)
        {
            if ((c.gameObject.transform.position - transform.position).magnitude < coin_distraction_radius && !Distracted)
            {
                distraction_object = c.gameObject;
                distraction_start = DateTime.Now;
            }   
        }
        

        if(!Distracted)
        {
            transform.right = initial_right;
            speed = (1.0f + level_manager.Level / 10.0f) * initial_speed;
            transform.position += transform.right * Time.deltaTime * speed;
        }

        else
        {
            transform.LookAt(distraction_object.transform);
            speed = (1.0f + level_manager.Level / 10.0f) * initial_speed;
            transform.position += transform.right * Time.deltaTime * speed;
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Wall"))
        {
            resetable = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Wall") && resetable)
        {
            transform.position = initial_position;
            resetable = false;
        }

        if(col.gameObject.CompareTag("Player"))
        {
            player_health.reduce_health();
        }
    }
}
