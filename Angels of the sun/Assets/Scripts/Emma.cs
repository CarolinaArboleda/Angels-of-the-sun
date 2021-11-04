using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Emma : MonoBehaviour
{
    public float altura_salto;
    public float velocidad_movimiento;
    private Rigidbody2D rb;
    private Animator anim;
    private bool touch_floor;
    private int vidas = 3;

    //asigna o retorna las vidas del personaje
    public int Vidas { get => vidas; set => vidas = value; }
    public int Puntos { get => puntos; set => puntos = value; }

    private Animator barra_anim;
    public GameObject barra_vida;

    private int puntos = 0;
    private int valor_punto = 15;

    public GameObject projectilePrefab;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        barra_anim = barra_vida.GetComponent<Animator>();
        anim.SetInteger("Estado", 0);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Floor"))
        {
            touch_floor = true;
        }
        else touch_floor = false;

        if (c.gameObject.tag.Equals("daño"))
        {
            vidas--;
            if (vidas > 0)
            {
                Debug.Log(Vidas + "/3");
            }
            else
            {
                Debug.Log("Se murió emma");
            }

            barra_anim.SetInteger("vidas", vidas);
        }

    }
    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            anim.SetInteger("Estado", 0);
        }

        if (touch_floor)
        {
            anim.SetInteger("Estado", 0);
        }
        if (Input.GetKey(KeyCode.Space) && touch_floor)
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto);
            touch_floor = false;
            anim.SetInteger("Estado", 2);
        }
        if (Input.GetKey(KeyCode.RightArrow) && touch_floor)
        {
            rb.velocity = new Vector2(velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(1, 1);
            touch_floor = true;
            anim.SetInteger("Estado", 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && touch_floor)
        {
            rb.velocity = new Vector2(-velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(-1, 1);
            touch_floor = true;
            anim.SetInteger("Estado", 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        Proyectil projectile = projectileObject.GetComponent<Proyectil>();
        projectile.Launch(lookDirection, 800);

    }

    //perder vidas si colisiona con objetos de daño
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("daño"))
        {
            vidas--;
            if (vidas > 0)
            {
                Debug.Log(Vidas + "/3");
            }
            else
            {
                SceneManager.LoadScene("gameover");
                Debug.Log("Se murió emma");
            }
            anim.SetInteger("Estado", 0);
            barra_anim.SetInteger("vidas", vidas);
        }

        //monedas

        if (other.gameObject.tag.Equals("moneda"))
        {
            puntos+=valor_punto;
        }
    }

}
