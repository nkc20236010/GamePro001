using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

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

        //x軸方向の移動範囲制限
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        //y軸方向の移動範囲制限
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
