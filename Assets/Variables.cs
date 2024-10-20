using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int b = 10;
    int health = 10;
    public int damage = 10;
    public float fireRate = 3.5f; // shots per second

    bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        int a = 2;
        a = b * 5;
        a = a + 3;
        a = a + 3;
        a += 3;
        a *= 2;
        a /= b;

        string text1 = "Coœ";
        string text2 = "Coœ dalej";

        //string text3 = text1 + damage;
        //Debug.Log("damage is " + damage + " Fire rate is " + fireRate);
        //Debug.Log($"damage is {damage} Fire rate ius {fireRate}");
        //Debug.Log(text3);


        // a += 3 to jest to samo co a = a + 3
    }

    // Update is called once per frame
    void Update()
    {

        isOn = !isOn;
        Debug.Log(isOn);
        //float damagePerSecond = damage * fireRate;
        //Debug.Log(damagePerSecond);
        //bool isHightDamage = damage != 10;
        //Debug.Log(isHightDamage);

        // && - Oba warunki s¹ spe³nione to true, inaczej false
        // || - Przynajmniej 1 warunek jest spe³niony to true, inaczej false
        bool isBetween2Planes = transform.position.y > 0 && transform.position.y < 5; // && - AND
        bool isNotBetween2Planes = transform.position.y  < 0 || transform.position.y > 5; // || - OR
        isNotBetween2Planes = !isBetween2Planes; // ! - odwrotnoœæ
        //Debug.Log(isBetween2Planes);
        //health -= damage;
        //bool isAlive = health > 0;
        //Debug.Log("Current health is " + health +" Is alvie? " + isAlive);
    }
}
