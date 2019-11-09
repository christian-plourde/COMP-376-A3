using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crab : MonoBehaviour
{
    GameObject player;
    DateTime last_attack_time;
    public float attack_cooldown_seconds;
    public GameObject projectile;
    public float projectile_force_multiplier;
    DateTime instantiated_time;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
        last_attack_time = DateTime.Now;
        instantiated_time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        if ((DateTime.Now - instantiated_time).TotalSeconds > 4 * attack_cooldown_seconds)
            Destroy(this.gameObject);

        transform.rotation = player.transform.rotation;
        transform.LookAt(player.transform);
        transform.Rotate(Vector3.up, 90.0f);
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if ((DateTime.Now - last_attack_time).TotalSeconds > attack_cooldown_seconds)
        {
            GameObject proj = Instantiate(projectile, transform.position + new Vector3(0.0f, (float)0.5*transform.localScale.y, 0.0f), Quaternion.identity);
            Vector3 proj_dir = -1*transform.right.normalized;
            proj.GetComponent<Rigidbody>().AddForce(proj_dir * projectile_force_multiplier);
            last_attack_time = DateTime.Now;
        }
    }
}
