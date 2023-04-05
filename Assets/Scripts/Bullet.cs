using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    //***********************************
    //Unity methods
    void Start()
    {
        
    }

    void Update()
    {
        ToMove();
    }
    //***********************************
    void ToMove()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
    }
}
