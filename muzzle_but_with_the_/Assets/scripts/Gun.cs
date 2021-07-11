using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float Range = 100f;

    public Camera fps_cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fps_cam.transform.position, fps_cam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
