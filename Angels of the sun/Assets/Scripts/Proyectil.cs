using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float destroyTime;
    public int Damage = 15;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        destroyTime = 1.0f;
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (transform.position.magnitude > 1000.0f || destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
