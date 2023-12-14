using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Applying a left movement using Unity libraries
        // Time.deltaTime ensure multiplication happens the same, no matter the frame rate
        transform.position = transform.position + Vector3.left * (moveSpeed * Time.deltaTime);
        
        // Deleting pipes whenever they go out of the screen
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
