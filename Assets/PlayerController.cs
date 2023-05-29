using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int hit = 0;
    [SerializeField]
    float span ;
    float delta = 0;
    public GameObject ShotPre;
    GameObject Player;
    GameObject gameDirector;

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
        gameDirector = GameObject.Find("GameDirector");
        PlayerAnime = GetComponent<Animator>();
    }

    public void Update()
    {
        float speed = 0.05f;
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

        Shot();

        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("a");

        if (collider.gameObject.tag == "EnemyTag")
        {
            gameDirector.GetComponent<GameDirector>().DerceaseHp();
            gameDirector.GetComponent<GameDirector>().HitCounter();
            Destroy(collider.gameObject);
        }
    }


    public void Shot()
    {
        if (Input.GetButton("Jump"))
        {
            delta += Time.deltaTime;
            if(delta > span)
            {
                delta = 0;
                GameObject go = Instantiate(ShotPre);
                go.transform.position = transform.position;
            }
        }
    } 
}
