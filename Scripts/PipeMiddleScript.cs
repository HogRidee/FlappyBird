using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript bird;
    
    // Start is called before the first frame update
    void Start()
    {
        // As a new pipe spawns, it will look trough the hierarchy to find a Game Object with the tag Logic and Bird
        // Then, it will look through that objects components to find a script of the class LogicScript
        // If it finds one, it will put that in our reference slot
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking if the collision was with a Game Object on the Bird's layer and if the bird is still alive
        if (collision.gameObject.layer == 3 && bird.birdIsAlive)
        {
            logic.addScore(1);
        }
    }
}
