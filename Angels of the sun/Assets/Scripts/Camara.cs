using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform emma;
    public Vector3 desplazamiento;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(emma.position.x + desplazamiento.x, desplazamiento.y, desplazamiento.z);
    }
}
