using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;
    public float movementSpeed = 1;
    public float jumpSpeed = 1;
    public float rotationSpeed = 1;
    private Rigidbody rb;
    private bool isJumping;
    public bool canJump;

    // Komentarz
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        // GetAxis : A = -1 , D = 1, Brak inputu = 0
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(horizontalInput, 0, verticalInput); // kierunek
        moveVector = Vector3.ClampMagnitude(moveVector, 1); // Ogranicza d³ugoœæ wektora do podanej wartoœæi ( w tym wypadku 1)
        moveVector *= movementSpeed;
        if (isJumping) // skok
        {
            moveVector.y = jumpSpeed;
            isJumping = false;
        }
        else
        {
            moveVector.y = rb.velocity.y;
        }

        rb.velocity = moveVector;
    }

    public void AddHealth(int value)
    {
        health += value;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        enabled = false;
    }
}
