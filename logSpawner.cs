using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logSpawner : MonoBehaviour
{
    public GameObject log;
    public float spawnTime;
    public float yPosMin, yPosMax;


    void Start()
    {
        StartCoroutine(spawnLogCoroutine());
    }

   IEnumerator spawnLogCoroutine()
   {
       yield return new WaitForSeconds(spawnTime);
       Instantiate(log, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), Quaternion.identity);
       StartCoroutine(spawnLogCoroutine());
   }
}
