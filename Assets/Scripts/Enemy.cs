using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField] int health = 3;
    [SerializeField] float moveSpeed = 1;
    //***********************************
    //Unity methods
    void Start()
    {
        player = GameObject.FindWithTag ("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }
    //***********************************
    public void ToTakeDamageEnemy()
    {
        health--;
        if (health <= 0)
        {
            Destroy (gameObject);
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = player.position -transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * moveSpeed;
    }


    //Si toca al jugador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ToDamagePlayer(collision);
    }

    void ToDamagePlayer(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().ToTakeDamage();
        }
    }
}
