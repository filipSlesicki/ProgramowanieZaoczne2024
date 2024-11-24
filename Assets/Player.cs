using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotationSpeed = 1;

    // Komentarz
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // GetAxis : A = -1 , D = 1, Brak inputu = 0
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector3(horizontalInput, verticalInput, 0); // kierunek
        //if(moveVector.magnitude > 1 )
        //{
        //    // Normalize() ustawia d³ugoœæ wektora na 1, zachowuj¹c kierunek
        //    moveVector.Normalize();
        //}

        moveVector = Vector3.ClampMagnitude(moveVector, 1); // Ogranicza d³ugoœæ wektora do podanej wartoœæi ( w tym wypadku 1)
        moveVector *= Time.deltaTime * movementSpeed; // prêdkoœæ
        transform.Translate(moveVector);
        //transform.position += moveVector;
        
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(0, movementSpeed * Time.deltaTime, 0);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(0, -movementSpeed * Time.deltaTime, 0);
        //}

        // Mno¿ymy razy Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê na prêdkoœæ na sekundê
        //transform.Translate(0,-1 * Time.deltaTime,0);
        //transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        //transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
        // Inny zapis
        // tansform.position = transform.position + Vector3.down * Time.deltaTime;
    }
}
