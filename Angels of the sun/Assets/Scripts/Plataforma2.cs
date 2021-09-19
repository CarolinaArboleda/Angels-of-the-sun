using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma2 : MonoBehaviour
{
    public Transform centro;
    private float xo, yo,x,y, r, angulo, tiempo;
    // Start is called before the first frame update
    void Start()
    {
        r = 3f;
        angulo = Mathf.PI / 6;
        xo = centro.transform.position.x;
        yo = centro.transform.position.y;
        tiempo = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(tiempo >= 0.03f)
        {
            x = xo + r * Mathf.Cos(angulo);
            y = yo + r * Mathf.Sin(angulo);
            angulo = (angulo - Mathf.PI / 32) % (2 *Mathf.PI);
            transform.localPosition = new Vector2(x, y);
            tiempo = 0f;
        }
        else
        {
            tiempo += Time.deltaTime;
        }
    }
}
