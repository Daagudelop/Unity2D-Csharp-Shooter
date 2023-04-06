using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstanceGameManager;

    [SerializeField]int time = 30;
    //********************************
    //Unity method
    private void Awake()
    {
        if (sharedInstanceGameManager == null)
        {
            sharedInstanceGameManager = this;
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
        while (time > 0 ) { }
        yield return new WaitForSeconds(1);
        time--;
        
    }
}
