using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogo : MonoBehaviour
{
    public Text texto;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject boton_continuar;
    public GameObject barra_texto;

    void Start()
    {
        StartCoroutine(Type());
    }

    void update()
    {
        if(texto.text == sentences[index])
        {
            boton_continuar.SetActive(true);
            barra_texto.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            texto.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            texto.text = "";
            StartCoroutine(Type());
        }
        else
        {
            texto.text = "";
            boton_continuar.SetActive(false);
            barra_texto.SetActive(false);
        }
    }
}
