using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAdvance3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the Ball or the character
        if (other.gameObject.CompareTag("Ball"))
        {
             SceneManager.LoadScene("MainMenu");
        }
        
    }
}
