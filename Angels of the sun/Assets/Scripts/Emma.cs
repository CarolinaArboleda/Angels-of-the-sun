using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emma : MonoBehaviour
{
    public float altura_salto;
    public float velocidad_movimiento;
    private Rigidbody2D rb;
    private Animator anim;
    private bool touch_floor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("Estado", 0);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Floor"))
        {
            touch_floor = true;
        }
        else touch_floor = false;

    }
    // Update is called once per frame
    void Update()
    {
        if(touch_floor)
        {
            anim.SetInteger("Estado", 0);
        }
        if (Input.GetKey(KeyCode.Space) && touch_floor)
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto);
            touch_floor = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(1, 1);
            anim.SetInteger("Estado", 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(-1, 1);
            anim.SetInteger("Estado", 1);
        }
    }
}
