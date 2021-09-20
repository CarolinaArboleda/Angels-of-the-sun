using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pajaro : MonoBehaviour
{
    public GameObject pajarito;
    public GameObject target;
    public Transform posicion_inicial;
    public Transform posicion_final;
    private Transform posicion_siguiente;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        posicion_siguiente = posicion_final;

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
        pajarito.transform.position = Vector2.MoveTowards(pajarito.transform.position, posicion_siguiente.position, Time.deltaTime * velocidad);

        if (pajarito.transform.position == posicion_siguiente.position)
        {
            posicion_siguiente = posicion_siguiente == posicion_final ? posicion_inicial : posicion_final;
        }
    }
}
