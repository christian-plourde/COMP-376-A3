using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float move_speed = 5.0f; //the movement speed of the character
    float speed_multiplier = 1.0f;
    public float jet_pack_efficiency = 10.0f;
    public GameObject coin;
    public float coin_shoot_force_multiplier;

    public float SpeedMultiplier
    {
        get { return speed_multiplier; }
        set { speed_multiplier = value; }
    }

    public float MoveSpeed
    {
        get { return move_speed; }
        set { move_speed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if player presses escape go back to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
            

        //forward backward translation
        float front_back = Input.GetAxis("Vertical") * Time.deltaTime * move_speed * speed_multiplier;
        //left right translation
        float side = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed * speed_multiplier;

        transform.Translate(side, 0, front_back);

        //we also need to handle the upwards movement
        //this is done by a jetpack forcing the player upwards when space is pressed
        if(Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jet_pack_efficiency * speed_multiplier * 2, 0.0f));
        }

        //throwing shiny figurines
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject new_coin = Instantiate(coin, transform.position + transform.forward.normalized*2, Quaternion.identity);
            new_coin.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * coin_shoot_force_multiplier);
        }
    }
}
