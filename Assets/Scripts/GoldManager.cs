using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoldManager : MonoBehaviour
{
    //this class is responsible for spawning gold

    int gold_count; //the amount of gold that is currently in play
    DateTime last_spawn_time;
    public int max_gold_count = 5; //the maximum amount of gold that can be in play at any given time
    public int floor_offset = 1; //the offset from the floor of the level
    public int spawn_interval_seconds = 10; //the interval between gold bar spawns
    public float floor_width = 200.0f; //the width of the cube
    public GameObject gold;
    
    public int GoldCount
    {
        get { return gold_count; }
        set { gold_count = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        last_spawn_time = DateTime.Now;
        gold_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((DateTime.Now - last_spawn_time).TotalSeconds > spawn_interval_seconds && gold_count < max_gold_count)
        {
            //create a new gold piece at random orientation and position
            GameObject gold_obj = Instantiate(gold, new Vector3(UnityEngine.Random.Range(-0.8f * floor_width/2.0f, 0.8f*floor_width/2.0f), floor_offset, UnityEngine.Random.Range(-0.8f * floor_width/2.0f, 0.8f * floor_width/2.0f)), Quaternion.AngleAxis(UnityEngine.Random.Range(0.0f, 360.0f), Vector3.up) * Quaternion.AngleAxis(-90.0f, Vector3.right));
            Gold gold_class = gold_obj.GetComponent<Gold>();

            //we need to set the size of the new gold generated
            //this is based on probability
            float prob = UnityEngine.Random.Range(0.0f, 1.0f); //generate number between 0 and 1
            //if the number is in range 0 to 0.6 generate a small gold
            if (prob < 0.6)
                gold_class.Size = GoldSize.SMALL;
            else if (prob > 0.6 && prob < 0.9)
                gold_class.Size = GoldSize.MEDIUM;
            else
                gold_class.Size = GoldSize.LARGE;

            //now we need to scale the size of the actual gold bars that will appear in the game
            if (gold_class.Size == GoldSize.MEDIUM)
                gold_obj.transform.localScale *= 2;
            if (gold_class.Size == GoldSize.LARGE)
                gold_obj.transform.localScale *= 3;


            last_spawn_time = DateTime.Now;
            gold_count++;
        }
            
    }
}
