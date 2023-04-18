using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 1;
    private float repeatRate =2 ;
    private PlayerController playerContScript;
    // Start is called before the first frame update
    void Start()
    {
        playerContScript= GameObject.Find("Player").GetComponent<PlayerController>();
       InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if(playerContScript.gameOver == false)
        {
             Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
