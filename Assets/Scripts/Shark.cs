using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        speed = UnityEngine.Random.Range(min_shark_speed, max_shark_speed);
        initial_speed = speed;
        initial_position = transform.position;
        player_health = FindObjectOfType<PlayerHealth>();
        level_manager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = (1.0f + level_manager.Level / 10.0f) * initial_speed; 
        transform.position += transform.right * Time.deltaTime * speed;
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
