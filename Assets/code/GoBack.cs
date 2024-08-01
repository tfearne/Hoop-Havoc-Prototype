using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
     public void OnGoBack ()
    {
        SceneManager.LoadScene("MainMenu");
    }

      public void OnLevels ()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
