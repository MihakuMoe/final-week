using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2_logic : MonoBehaviour
{
    public int health = 150;
    public GameObject bullet_prefab;
    public manager manager;

    public Vector2 Velocity = new Vector2(1, 0);

    [Range(0, 5)]
    public float RotateSpeed = 5f;
    [Range(0, 5)]
    public float Radius = 1f;

    private Vector2 _centre;
    private float _angle;
    private void Start()
    {
        InvokeRepeating("fire_bullet_round", 0f, 2f);
        _centre = transform.position;
        manager = GameObject.Find("control").GetComponent<manager>();
    }
    public void take_damage(int damage_amount)
    {
        manager.score += 20;
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
        for (; i < 30; i++)
        {
            //Debug.Log("shooting: i = " + i.ToString());
            GameObject bullet_obj = Instantiate(bullet_prefab, transform.position, transform.rotation);
            Rigidbody2D bullet_rb = bullet_obj.GetComponent<Rigidbody2D>();
            float angle = 12f * i;
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            bullet_rb.AddForce(dir * 10, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _centre += Velocity * Time.deltaTime;

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;

        transform.position = _centre + offset;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
