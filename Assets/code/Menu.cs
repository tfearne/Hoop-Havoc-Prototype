using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }

    public void OnHowToPlay ()
    {
        SceneManager.LoadScene("HowToPlay");
    }

   
}
