using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb; // reference to the Rigidbody2D component attached to the player
    //AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();


    }

    private void movePlayer()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the position of the mouse in world coordinates
            if (touchPos.x < 0) //
            {
                rb.AddForce(Vector2.left * moveSpeed * Time.deltaTime); // move left
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed * Time.deltaTime); // move right
            }
        }
        else
        {
            rb.velocity = Vector2.zero; // stop the player when the mouse button is released
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the current scene when colliding with an object tagged "Apple"
            //audioSource.Play(); // play the audio source attached to the player
        }
    }

   
}
