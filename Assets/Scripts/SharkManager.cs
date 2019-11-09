using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SharkManager : MonoBehaviour
{
    public GameObject shark;
    static int shark_count;
    DateTime last_spawn_time;
    public static int max_shark_count = 5;
    public int spawn_interval_seconds = 2;
    public float floor_width = 200;
    public float wall_height = 100;
    public static float max_shark_size = 5;
    public static float min_shark_size = 3;

    // Start is called before the first frame update
    void Start()
    {
        last_spawn_time = DateTime.Now;
        shark_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((DateTime.Now - last_spawn_time).TotalSeconds > spawn_interval_seconds && shark_count < max_shark_count)
        {
            Vector3 position_offset;
            if (((this.gameObject.transform.parent.transform.rotation).eulerAngles.y / 2) % 2 == 0)
                position_offset = new Vector3(UnityEngine.Random.Range(-floor_width / 2, floor_width / 2), UnityEngine.Random.Range(-wall_height / 2, wall_height / 2), 0);
            else
                position_offset = new Vector3(0, UnityEngine.Random.Range(-wall_height / 2, wall_height / 2), UnityEngine.Random.Range(-floor_width / 2, floor_width / 2));

            position_offset *= 0.9f;

            shark_count++;
            //create a new shark coming out of one of the walls (the parent of this shark generator) it also has to have
            //the right rotation
            GameObject new_shark = Instantiate(shark, 
                this.gameObject.transform.parent.transform.position + position_offset,
                this.gameObject.transform.parent.transform.rotation * Quaternion.AngleAxis(90, new Vector3(0, 0, 1))
                * Quaternion.AngleAxis(-90, Vector3.right));

            new_shark.transform.localScale *= UnityEngine.Random.Range(min_shark_size, max_shark_size);

            last_spawn_time = DateTime.Now;
        }
    }
}
