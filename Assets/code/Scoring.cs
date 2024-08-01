using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoreText;  // Reference to the UI Text component
    private int score = 0;  // Score variable

    void Start()
    {
        UpdateScoreText();
    }

    // This method will be called when another object collides with this object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided is the Ball or the character
        if (other.gameObject.CompareTag("Ball"))
        {
            IncrementScore();
        }
        
    }

    // Method to increment the score
    private void IncrementScore()
    {
        score += 1;
        UpdateScoreText();
    }

    // Method to update the UI text with the current score
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Method to get the current score
    public int GetScore()
    {
        return score;
    }
}

