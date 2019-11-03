using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGoldInventory : MonoBehaviour
{
    int total_gold;
    public int capacity = 20;
    Controller player_controller;
    public Image inventory_bar; //this is the ui element that shows how full the inventory is

    public void AddGold(Gold gold)
    {
        if(total_gold + gold.Value <= capacity)
        {
            total_gold += gold.Value;
            player_controller.SpeedMultiplier = 1.0f - 0.9f * (((float)total_gold / (float)capacity));

            //we also need to update the player inventory bar ui element
            float amount_filled = (float)total_gold / (float)capacity;
            inventory_bar.rectTransform.offsetMin = new Vector2(inventory_bar.rectTransform.offsetMin.x, 100.0f - 100.0f*amount_filled);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player_controller = FindObjectOfType<Controller>();
        total_gold = 0;
        inventory_bar.rectTransform.offsetMin = new Vector2(inventory_bar.rectTransform.offsetMin.x, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
