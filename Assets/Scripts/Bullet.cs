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
        Destroy(gameObject,5);
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

    //Si toca al enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ToDamageEnemy(collision);
    }

    void ToDamageEnemy(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().ToTakeDamageEnemy();
            //En cuanto ocurra se destruira
            Destroy(gameObject);
        }
    }
}
