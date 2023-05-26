using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGenerator : MonoBehaviour
{
    public GameObject ShotPre;
    GameObject Player;

    void Start()
    {
       Player = GameObject.Find("MyChar_0");
    }

    void Update()
    {
        //if (Input.GetButton("Jump"))
        //{
        //    GameObject go = Instantiate(ShotPre);
        //    go.transform.position = Player.transform.position;
        //}
    }
}
