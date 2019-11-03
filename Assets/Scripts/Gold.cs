using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoldSize { SMALL, MEDIUM, LARGE}

public class Gold : MonoBehaviour
{
    GoldManager gold_manager;
    PlayerGoldInventory player_inventory;
    GoldSize size;

    public GoldSize Size
    {
        get { return size; }
        set { size = value; }
    }

    public int Value
    {
        get {

            if (size == GoldSize.SMALL)
                return 1;
            else if (size == GoldSize.MEDIUM)
                return 2;
            else
                return 10;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gold_manager = FindObjectOfType<GoldManager>();
        player_inventory = FindObjectOfType<PlayerGoldInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //when something collides with our collider, check if the colliding object is the player
        if(col.gameObject.CompareTag("Player"))
        {
            //if its the player we destroy this object and reduce the gold count in the gold manager
            Destroy(this.gameObject);
            player_inventory.AddGold(this);
            gold_manager.GoldCount--;
        }
    }
}
