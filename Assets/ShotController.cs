using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    GameObject gameDirector;

    void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
    }

    void Update()
    {
        transform.Translate(0, 0.08f, 0);
        if (transform.position.x > 11.5f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "EnemyTag")
        {
            gameDirector.GetComponent<GameDirector>().KillCounter();
            Destroy(gameObject );
        }
    }

    
}
