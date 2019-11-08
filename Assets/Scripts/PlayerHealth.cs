using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int max_health = 2;
    int health;
    public Text life_counter;
    public Image oxygen_indicator;
    System.DateTime oxygen_start;
    public float cylinder_duration_seconds = 10.0f; 

    public bool IsDead
    {
        get {
            return (Health <= 0) || (CurrentOxygen <= 0); }
    }

    public float CurrentOxygen
    {
        get {

            if ((cylinder_duration_seconds - (float)(System.DateTime.Now - oxygen_start).TotalSeconds) * 100.0f/cylinder_duration_seconds <= 0.0f)
                return 0.0f;
            return ((cylinder_duration_seconds - (float)(System.DateTime.Now - oxygen_start).TotalSeconds) * 100.0f/cylinder_duration_seconds);

        }
    }

    public void reduce_health()
    {
        if(health > 0)
            health--;

        life_counter.text = "Lives: " + health;
    }

    public int Health
    {
        get { return health; }
    }

    // Start is called before the first frame update
    void Start()
    {
        oxygen_start = System.DateTime.Now;
        health = max_health;        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
            Debug.Log("You Died");
        oxygen_indicator.rectTransform.offsetMin = new Vector2(oxygen_indicator.rectTransform.offsetMin.x, 100.0f - CurrentOxygen);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("WaterSurface"))
            oxygen_start = System.DateTime.Now;
    }
}
