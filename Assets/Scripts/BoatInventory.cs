using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatInventory : MonoBehaviour
{
    //this script manages the boat's inventory, which is essentially the player's score
    int gold_count;
    PlayerGoldInventory player_inventory;
    public Text score_text;

    public int Score
    {
        get { return gold_count; }
    }

    // Start is called before the first frame update
    void Start()
    {
        gold_count = 0;
        player_inventory = FindObjectOfType<PlayerGoldInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //if the colliding object is the player dump his gold into the boat
        if(col.CompareTag("Player"))
        {
            gold_count += player_inventory.TotalGold;
            player_inventory.EmptyGold();

            //finally update the score text
            score_text.text = "Score: " + Score;
        }
    }
}
