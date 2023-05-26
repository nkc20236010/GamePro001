using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    Animator PlayerAnime;

    //x�������̈ړ��͈͂̍ŏ��l
    [SerializeField] private float _minX = -10.5f;
    //x�������̈ړ��͈͂̍ő�l
    [SerializeField] private float _maxX = 10.5f;
    //y�������̈ړ��͈͂̍ŏ��l
    [SerializeField] private float _minY = -4.5f;
    //y�������̈ړ��͈͂̍ő�l
    [SerializeField] private float _maxY = 4.5f;


    void Start()
    {
        PlayerAnime = GetComponent<Animator>();
    }

    public void Update()
    {
        float speed = 0.09f;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x * speed, y * speed, 0);
        PlayerAnime.SetFloat("UpDown", y);

        Vector3 pos = transform.position;

        //x�������̈ړ��͈͐���
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        //y�������̈ړ��͈͐���
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;
    }

    void OnTriggerEnther2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyTag")
        {
            Destroy(gameObject);
        }
    }
}
