using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance
        ;

    public int time = 30;
    public int difficulty = 1;
    //********************************
    //Unity method
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    void Update()
    {
        
    }
    //********************************
    //Corutinas
    IEnumerator CountDownRoutine()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }
}
