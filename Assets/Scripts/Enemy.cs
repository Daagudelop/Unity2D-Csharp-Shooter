using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    [SerializeField] int health = 3;
    [SerializeField] float moveSpeed = 1;
    GameObject[] spawnPoint;

    //***********************************
    //Unity methods
    void Start()
    {
        ToSelectSpawnPoint();
    }

    void Update()
    {
        FollowPlayer();
    }
    //***********************************

    void ToSelectSpawnPoint()
    {
        ObjectRecolector();
        SpawnPointSelector();
    }

    void ObjectRecolector()
    {
        //---------------------------
        //Find the player
        player = GameObject.FindWithTag ("Player").transform;
        //Find the spawnpoints
        spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        //---------------------------
    }

    void SpawnPointSelector()
    {
        //Get the new position
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);

        //Asign the new position
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }

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
