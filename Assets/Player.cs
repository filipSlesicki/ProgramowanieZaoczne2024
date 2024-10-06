using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Zmienne
    // int - Liczba ca�kowita (1, 220, -234)
    // float - liczba z przeinkiem (1.2f, -0.23f, 102934f)
    // string - tekst ("jaki� tekst")
    // bool - zmienna logiczna (true,false)

    // Mpodyfikator dost�pu Typ nazwa 
    public float fallingSpeed = 1;
    public float rotationSpeed = 1;


    // Komentarz
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mno�ymy razy Time.deltaTime �eby zamieni� pr�dko�� na klatk� na pr�dko�� na sekund�
        //transform.Translate(0,-1 * Time.deltaTime,0);
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        //transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
        // Inny zapis
        // tansform.position = transform.position + Vector3.down * Time.deltaTime;
    }
}
