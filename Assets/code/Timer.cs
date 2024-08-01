using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; // Start at 60 seconds (1 minute)
    public bool timeIsRunning = false; // Initially set to false, will start on button click
    public TMP_Text timeText;
    public GameObject goButton; // Reference to the button
    public TMP_Text finalScoreText; // Reference to the TMP_Text for the final score
    public Scoring scoring; // Reference to the Scoring script

    // Start is called before the first frame update
    void Start()
    {
        DisplayTime(timeRemaining); // Display the initial time
        finalScoreText.gameObject.SetActive(false); // Hide the final score text initially
    }

    // Method to be called when the GoButton is clicked
    public void OnGoButton()
    {
        if (!timeIsRunning)
        {
            timeIsRunning = true;
            StartCoroutine(RunTimer());
            goButton.SetActive(false); // Hide the button
        }
    }

    // Coroutine to handle the timer countdown
    IEnumerator RunTimer()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            DisplayTime(timeRemaining);
        }
        timeIsRunning = false; // Stop the timer when it reaches 0
        ShowFinalScore(); // Display the final score
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ShowFinalScore()
    {
        int finalScore = scoring.GetScore(); // Get the final score from the Scoring script
        finalScoreText.text = "Great Job! Your Score Was " + finalScore;
        finalScoreText.gameObject.SetActive(true); // Show the final score text
    }
}


