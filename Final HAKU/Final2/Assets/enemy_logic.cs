using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class enemy_logic : MonoBehaviour
{

    public int health = 50;
    public GameObject bullet_prefab;
    public manager manager;

    public float move_speed = 3f;

    public float freq = 0.5f;
    public float magnitude = 10f;
    public Vector3 axis;
    public Vector3 pos;
    private void Start()
    {
        InvokeRepeating("fire_bullet_round", 0f, 2f);
        axis = transform.up;
        pos = transform.position;
        manager = GameObject.Find("control").GetComponent<manager>();
    }
    public void take_damage(int damage_amount)
    {
        manager.score += 10;
        health -= damage_amount;
        Debug.Log("health remaining: " + health.ToString());
        Debug.Log("score: " + manager.score.ToString());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void fire_bullet_round()
    {
        int i = 0;
        int max_bullet = 20;
        for (; i < max_bullet; i++)
        {
            //Debug.Log("shooting: i = " + i.ToString());
            GameObject bullet_obj = Instantiate(bullet_prefab, transform.position, transform.rotation);
            Rigidbody2D bullet_rb = bullet_obj.GetComponent<Rigidbody2D>();
            float angle = 360f / max_bullet * i;
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            bullet_rb.AddForce(dir * 10, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.right * Time.deltaTime * move_speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * freq) * magnitude;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
