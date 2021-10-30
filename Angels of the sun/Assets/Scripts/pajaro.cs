using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajaro : MonoBehaviour
{
    public GameObject target;

    public float speed = 2.5f;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.position = target.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if (direction == -1)
        {
            rigidbody2D.transform.localScale = new Vector2(1, 1);
        }

        if (direction == 1)
        {
            rigidbody2D.transform.localScale = new Vector2(-1, 1);
        }

        Vector2 position = rigidbody2D.position;

        position.x = position.x + Time.deltaTime * speed * direction; ;

        rigidbody2D.MovePosition(position);
    }
}
