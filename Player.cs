using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // How to define a variable
    // 1. Access modifier: public or private
    // 2. Data type: int, float, bool, string
    // 3. Variable name camelCase
    // 4. Value: optional

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;
    private float verticalMiddleLimit = 0f; // Middle of the screen

    public GameObject bulletPrefab;

    private void Start()
    {
        playerSpeed = 6f;
        // This function is called at the start of the game
    }

    private void Update()
    {
        // This function is called every frame; 60 frames/second
        Movement();
        Shooting();
    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectille
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
    void Movement()
    {
        // Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        // Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }

        // Restrict player movement to the bottom half of the screen
        if (transform.position.y > verticalMiddleLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalMiddleLimit, 0);
        }
        else if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
    }
}
