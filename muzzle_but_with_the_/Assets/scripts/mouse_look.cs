using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{
    public float mouse_sensativetiy = 100f;

    public Transform player_body;

    float x_rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensativetiy * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensativetiy * Time.deltaTime;

        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);
    }
}
