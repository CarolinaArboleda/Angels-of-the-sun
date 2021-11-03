using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud : MonoBehaviour
{
    public daño vidas;
    public GameObject barra_vida;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = barra_vida.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("vidas", vidas.Vidas);
    }
}
