using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator PlayerAnime;

    //x²•ûŒü‚ÌˆÚ“®”ÍˆÍ‚ÌÅ¬’l
    [SerializeField] private float _min = -1;

    //x²•ûŒü‚ÌˆÚ“®”ÍˆÍ‚ÌÅ‘å’l
    [SerializeField] private float _max = 1;

    

    void Start()
    {
        PlayerAnime = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = 0.09f;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x * speed, y * speed, 0);
        PlayerAnime.SetFloat("UpDown", y);
    }

    void OnTriggerEnther2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyTag")
        {
            Destroy(gameObject);
        }
    }
}
