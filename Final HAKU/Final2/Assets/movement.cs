using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float move_speed = 5f;

    public Rigidbody2D rb;
    public Camera scene_camera;
    public manager manager;

    Vector2 player_move;
    Vector2 mouse_position;
    public int health = 100;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        player_move.x = Input.GetAxisRaw("Horizontal");
        player_move.y = Input.GetAxisRaw("Vertical");

        mouse_position = scene_camera.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 face_direction = mouse_position - rb.position;
        rb.MovePosition(rb.position + player_move * move_speed * Time.fixedDeltaTime);
        rb.rotation = Mathf.Atan2(face_direction.y, face_direction.x) * Mathf.Rad2Deg;
    }
    public void take_damage(int damage_amount)
    {
        health -= damage_amount;
        if (health <= 0)
        {
            manager.end_game();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // bullet collider is set to trigger
        Debug.Log("player hit by: " + collision.name);
        enmey_bullet bullet1 = collision.GetComponent<enmey_bullet>();
        if (bullet1 != null)
        {
            take_damage(33);
        }
        bullet2_logic bullet2 = collision.GetComponent<bullet2_logic>();
        if (bullet2 != null)
        {
            take_damage(50);
        }
    }

}
