using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("MyChar_0");
    }

    void Update()
    {
        transform.Translate(-0.03f, 0, 0);

        if(transform.position.x < -15.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        Vector2 dir = p1 - p2;
        float z = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.5f;

        if(z <r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DerceaseHp();

            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ShotTag")
        {
            Destroy(gameObject);
        }
    }

}
