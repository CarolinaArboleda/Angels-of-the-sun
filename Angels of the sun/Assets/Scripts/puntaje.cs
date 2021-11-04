using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntaje : MonoBehaviour
{
    public Emma emma;
    public GameObject centenas, decenas, unidades;
    private Animator ce, de, un;
    private string[] estados = { "estado_00", "estado_01", "estado_02", "estado_03", "estado_04", "estado_05", "estado_06", "estado_07", "estado_08", "estado_09" };

    // Start is called before the first frame update
    void Start()
    {
        ce = centenas.GetComponent<Animator>();
        de = decenas.GetComponent<Animator>();
        un = unidades.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarContador(emma.Puntos);
    }

    public void ActualizarContador(int numero)
    {
        int centenas, decenas, unidades;
        unidades = numero % 10;
        decenas = (numero % 100) - unidades;
        centenas = (numero % 1000) - decenas;

        decenas = decenas / 10;
        centenas = centenas / 100;

        if (numero > 9)
        {
            de.Play(estados[decenas]);
        }
        else
        {
            de.Play(estados[0]);
        }

        if (numero > 99)
        {
            ce.Play(estados[centenas]);
        }
        else
        {
            ce.Play(estados[0]);
        }

        un.Play(estados[unidades]);
    }

}
