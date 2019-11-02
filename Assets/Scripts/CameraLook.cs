using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smooth_vec;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        //this gives us access to the player game object (the capsule)
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        movement = Vector2.Scale(movement, new Vector2(smoothing * sensitivity, smoothing * sensitivity));
        smooth_vec.x = Mathf.Lerp(smooth_vec.x, movement.x, 1.0f / smoothing);
        smooth_vec.y = Mathf.Lerp(smooth_vec.y, movement.y, 1.0f / smoothing);
        mouseLook += smooth_vec;
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
