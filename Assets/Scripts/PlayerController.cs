using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    public int health = 5;
    public Text scoreText;

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
        //Store user input as a movement vector
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        // rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        rb.AddForce(movement * speed);
    }

    // Increment the value of score when the Player touches an object tagged Pickup
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score += 1;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health -= 1;
            Debug.Log($"Health: {health}");
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }
}
