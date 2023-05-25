using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float span = 0.5f;
    float delta = 0;


    void Start()
    {
        
    }

    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            GameObject go = Instantiate(EnemyPrefab);
            int ex = Random.Range(-4, 5);
            go.transform.position = new Vector3(10, ex, 0);
        }
    }
}
