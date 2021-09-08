using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emma : MonoBehaviour
{
    public float altura_salto;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, altura_salto);
        }
        float horizontal = Input.GetAxis("Horizontal");
        //float jump = Input.GetAxis("Jump");
        Vector2 position = transform.position;
        position.x = position.x + 4.0f * horizontal * Time.deltaTime;
        //position.y = position.y + 6.0f * jump * Time.deltaTime;
        transform.position = position;

    }
}
