using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoerController1 : MonoBehaviour
{
    public static int Kill;

    void Start()
    {
        GetComponent<Text>().text = Kill.ToString("000") + "Kill";
    }

    void Update()
    {
        
    }
}
