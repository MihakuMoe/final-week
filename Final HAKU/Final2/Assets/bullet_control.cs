using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_control : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("player bullet hitting: " + collision.collider.name);
        enemy_logic enemy1 = collision.collider.GetComponent<enemy_logic>();
        if (enemy1 != null)
        {
            enemy1.take_damage(10);
        }
        enemy2_logic enemy2 = collision.collider.GetComponent<enemy2_logic>();
        if (enemy2 != null)
        {
            enemy2.take_damage(10);
        }
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
    }
    */
}
