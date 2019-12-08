using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Transform fire_origin;
    public GameObject bullet;
    public float bullet_force = 5f;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet_obj = Instantiate(bullet, fire_origin.position, fire_origin.rotation);
            Rigidbody2D rb = bullet_obj.GetComponent<Rigidbody2D>();
            rb.AddForce(fire_origin.right * bullet_force, ForceMode2D.Impulse);
        }

    }

}
