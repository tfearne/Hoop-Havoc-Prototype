using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingCoin : MonoBehaviour
{
    public float bounceHeight = 0.5f;   // The height of the bounce
    public float bounceSpeed = 1.0f;    // The speed of the bounce
    public float rotationSpeed = 45.0f; // The speed of the rotation in degrees per second

    public GameObject coinPrefab;       // The coin prefab to instantiate
    public float spawnInterval = 5.0f;  // Time interval between spawns
    public Vector3 spawnAreaMin;        // Minimum position for spawning coins
    public Vector3 spawnAreaMax;        // Maximum position for spawning coins

    private Vector3 startPos;
    private float spawnTimer;
    private bool canSpawn = true; // Flag to control coin spawning

    void Start()
    {
        startPos = transform.position; // Store the starting position
        spawnTimer = spawnInterval;    // Initialize the spawn timer
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Apply the new position
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Apply the rotation around both the y and x axes
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        // Update the spawn timer
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && canSpawn)
        {
            // Spawn a new coin and reset the timer
            SpawnCoin();
            spawnTimer = spawnInterval;
            canSpawn = false; // Prevent additional spawning until the coin has been spawned
        }
    }

    void SpawnCoin()
    {
        // Generate a random position within the specified range
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Instantiate a new coin at the random position
        GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        
        // Allow new coins to be spawned again after a delay
        Invoke(nameof(AllowSpawn), spawnInterval);
    }

    void AllowSpawn()
    {
        canSpawn = true; // Reset the flag to allow spawning of a new coin
    }

    // This method will be called when the coin collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("character")) // Replace "Player" with the tag of the object that should trigger the coin's disappearance
        {
            Destroy(gameObject); // Destroy the coin when it collides with the player
        }
    }
}
