using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    Vector3 velocity;
    bool is_grounded;
    bool next_level;
    bool is_grounded_jump;

    public float gravity = -9.81f;

    public float jump_hieght = 3f;

    

    public Transform ground_check;
    public float ground_distance = 0.6f;
    public LayerMask ground_mask;
    public LayerMask end_level_mask;
    public LayerMask jump_1_mask;
   
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);
        is_grounded_jump = Physics.CheckSphere(ground_check.position, ground_distance, jump_1_mask);
        next_level = Physics.CheckSphere(ground_check.position, ground_distance, end_level_mask);

        if (is_grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && is_grounded)
        {
            velocity.y = Mathf.Sqrt(jump_hieght * -2f * gravity);
        }
        // collisins
        if (is_grounded_jump)
        {
            velocity.y = Mathf.Sqrt((jump_hieght + 9) * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if(ground_check.position.y < -11)
        {
            Restart();
        }
        if (next_level)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
