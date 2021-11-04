using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Emma controller = other.GetComponent<Emma>();
        if (controller != null)
        {
            Destroy(gameObject);
        }
    }
}
