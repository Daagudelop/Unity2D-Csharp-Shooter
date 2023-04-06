using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 3;

    //***********************************
    //Unity methods
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //***********************************
    public void ToTakeDamage()
    {
        health--;
    }
}
