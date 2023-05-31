using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int hit = 0;
    [SerializeField] float span ;
    
    float delta = 0;
    int EnemyKill = 0;

    public GameObject ShotPre;
    GameObject Player;
    GameObject gameDirector;

    Animator PlayerAnime;

    //x軸方向の移動範囲の最小値
    [SerializeField] private float _minX = -10.5f;
    //x軸方向の移動範囲の最大値
    [SerializeField] private float _maxX = 10.5f;
    //y軸方向の移動範囲の最小値
    [SerializeField] private float _minY = -4.5f;
    //y軸方向の移動範囲の最大値
    [SerializeField] private float _maxY = 4.5f;


    void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
        PlayerAnime = GetComponent<Animator>();
    }

    public void Update()
    {
        EnemyKill = gameDirector.GetComponent<GameDirector>().KillCount;

        float speed = 0.05f;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(x * speed, y * speed, 0);
        PlayerAnime.SetFloat("UpDown", y);

        Vector3 pos = transform.position;

        //x軸方向の移動範囲制限
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        //y軸方向の移動範囲制限
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;

        Shot();
        Debug.Log(EnemyKill);

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
            if (delta > span)
            {
                delta = 0;
                GameObject go = Instantiate(ShotPre);

                if (EnemyKill > 15)
                {
                    Instantiate(ShotPre, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, -90));

                }
                //if (EnemyKill > 30)
                //{
                //    Instantiate(ShotPre, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, -90));
                //}
            }
        }
    }
}
