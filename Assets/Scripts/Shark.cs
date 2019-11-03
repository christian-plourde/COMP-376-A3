using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public static float max_shark_speed = 18.0f;
    public static float min_shark_speed = 10.0f;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = UnityEngine.Random.Range(min_shark_speed, max_shark_speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
