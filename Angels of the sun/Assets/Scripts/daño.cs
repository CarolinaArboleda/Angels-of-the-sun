using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{
    public GameObject target;
    private int vidas=3;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.position = target.transform.position;
        }
    }
}
