using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if the space key is pressed and if the bird is alive
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            // Applying an upward velocity using unity libraries
            myRigidBody.velocity = Vector2.up * 10; 
        }
        
        // Checking if the bird goes out the screen
        if (transform.position.y is >= 16 or <= -16)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
