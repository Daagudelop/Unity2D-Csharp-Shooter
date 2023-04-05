using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables

    float ejeHorizontal;
    float ejeVertical;
    float fireRate = 1;

    bool actionRun = false;
    bool gunLoaded = true;

    Vector3 moveDirection;
    Vector2 facingDirection;

    [SerializeField] float moveSpeed;
    [SerializeField] Transform aim;
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform BulletPrefab;

    //***********************************
    //Unity methods
    void Start()
    {
        
    }

    void Update()
    {
        ActionRecolector();

    }

    private void FixedUpdate()
    {
        ToMove();
        Aim();
        ToShoot();
    }

    //***********************************
    void ActionRecolector()
    {
        //--------------------------------
        //walking.
        ejeHorizontal = Input.GetAxis("Horizontal");
        ejeVertical = Input.GetAxis("Vertical");
        moveDirection.x = ejeHorizontal;
        moveDirection.y = ejeVertical;
        //--------------------------------
        //Running
        actionRun = Input.GetButton("Fire3");
        //--------------------------------
    }

    void ToShoot()
    {
        //  Si click izq 
        if (Input.GetMouseButton(0) && gunLoaded)
        {
            //Calculará la dirección de la bala dada por la dirección de facingDirection usando atan2 que traduce posicione x,y en vectores normales y un vector de referencia que crearan un quaternion osea la rotación mas simple que tiene unity que se da con respecto al vector.forward de Player.
            gunLoaded = false;
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            Quaternion BulletDirection = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(BulletPrefab, transform.position, BulletDirection);
            StartCoroutine(ReloadGun());
        }
    }

    void ToMove()
    {
        if (actionRun)
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed*2;
        }
        else
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }
        
    }

    void Aim()
    {
        //Traduce un punto del espacio en la pantalla y lo traduce a un punto del espacio en el mundo.  El puntero vive en la pantalla, pero el jugador y la mira viven en el espacio del mundo.
        //Toma la posición del mouse de global(Espacio en pantalla) a la posición en el mundo del videojuego
        facingDirection = mainCamera.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        //En este algoritmo se coje el vector2 y se le dice a unity que lo interprete como un vector3 y se normaliza (magnitud = 1)
        aim.position = transform.position + (Vector3)facingDirection.normalized;
    }

    //********************************
    //Corutinas
    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }
}
