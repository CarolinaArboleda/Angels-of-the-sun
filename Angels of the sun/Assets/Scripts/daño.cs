using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{
    public GameObject target;
    private int vidas=3;

    //asigna o retorna las vidas del personaje
    public int Vidas { get => vidas; set => vidas = value; }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (--vidas > 0)
            {
                other.transform.position = target.transform.position;
            }
            else
            {
                Debug.Log("Se murió emma");
            }
        }
    }
}
