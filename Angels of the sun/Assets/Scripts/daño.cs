using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }
}
