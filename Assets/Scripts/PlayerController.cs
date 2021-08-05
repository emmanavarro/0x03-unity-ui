using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    public int health = 5;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of rb by getting a reference to the Rigidbody component
        // attached to the Player GameObject component
        rb = GetComponent<Rigidbody>();
    }

    // Predefined function for the changes in movement controls
    void OnMove(InputValue movementValue)
    {
        // Stores the input data as a vector
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // It is called just before performing any physics calculations
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    // Increment the value of score when the Player touches an object tagged Pickup
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score += 1;
            Debug.Log($"Score: {score}");
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health -= 1;
            Debug.Log($"Health: {health}");
        }
    }
}
