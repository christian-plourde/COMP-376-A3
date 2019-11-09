using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabGenerator : MonoBehaviour
{
    public GameObject crab;
    LevelManager level_manager;
    bool crab_spawned_in_level;
    int current_level;
    public int first_level_with_crab;

    // Start is called before the first frame update
    void Start()
    {
        level_manager = FindObjectOfType<LevelManager>();
        current_level = level_manager.Level;
        crab_spawned_in_level = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (level_manager.Level < first_level_with_crab)
            return;

        if(level_manager.Level > current_level)
        {
            current_level = level_manager.Level;
            crab_spawned_in_level = false;
        }


        if (!crab_spawned_in_level)
        {
            Instantiate(crab, new Vector3(0, 0, 0), Quaternion.identity);
            crab_spawned_in_level = true;
        }
            

    }
}
