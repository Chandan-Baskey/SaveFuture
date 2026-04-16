using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject apple;  
    public float maxX;  
    public Transform spawnPoint;    
    public float spawnRate; //

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    int score = 0;
    bool gameStarted = false; // flag to check if the game has started
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0)) // start the game when the mouse button is clicked for the first time
        {
            gameStarted = true;
            tapText.SetActive(false);
            StartSpawning();
        }

    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnPos", 0.5f, spawnRate); // call the SpawnPos method repeatedly with a delay of 0.5 seconds and a repeat rate of spawnRate seconds
    }

    private void SpawnPos()
    {
        Vector3 spawnPos = spawnPoint.position; // start with the position of the spawn point
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(apple, spawnPos, Quaternion.identity); // spawn an apple at the calculated position with no rotation
        score++;
        scoreText.text = score.ToString();
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
