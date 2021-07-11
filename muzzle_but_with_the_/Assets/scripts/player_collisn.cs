using UnityEngine;
using UnityEngine.SceneManagement;

public class player_collisn : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       void OnCollisionEnter(Collision Collision_info)
       {
         if (Collision_info.collider.name == "level_1_end")
         {
           SceneManager.LoadScene(1);
         }
         if(Collision_info.collider.tag == "jump_1_tag")
         {

         }
       }
    }
}
