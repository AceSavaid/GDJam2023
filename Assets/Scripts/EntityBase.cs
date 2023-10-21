using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public bool isEnemy = false;
    public int health = 5;
    public int maxhealth = 5;
    public int damage= 2;
    public int positionOrder; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Hurt(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        //does animatic effect and then calls the game manager
    }
}
