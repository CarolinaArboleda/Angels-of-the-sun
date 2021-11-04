using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Animator musicAnim;
    public float wait_time;

    public void PlayGame()
    {
        StartCoroutine(ChangeScenePlay());
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    IEnumerator ChangeScenePlay()
    {
        musicAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
